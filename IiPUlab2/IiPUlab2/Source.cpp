#define _CRT_SECURE_NO_WARNINGS
#include <iostream>
#include <iomanip>
#include <Windows.h>
#include <WinIoCtl.h>
#include <ntddscsi.h>
#include <conio.h>
#include <math.h>

using namespace std;

#define bThousand 1024
#define Hundred 100
#define BYTE_SIZE 8
#define BUFSIZE 100

char* busType[] = { "UNKNOWN", "SCSI", "ATAPI", "ATA", "ONE_TREE_NINE_FOUR", "SSA", "FIBRE", "USB", "RAID", "ISCSI", "SAS", "SATA", "SD", "MMC" };

void init(HANDLE& diskHandle) {
	//�������� ����� � ����������� � �����
	diskHandle = CreateFile("\\\\.\\PhysicalDrive0", GENERIC_READ | GENERIC_WRITE, FILE_SHARE_READ, NULL, OPEN_EXISTING, NULL, NULL);
	if (diskHandle == INVALID_HANDLE_VALUE) {
		cout << GetLastError();
		_getch();
		return;
	}
}

void getDeviceInfo(HANDLE diskHandle, STORAGE_PROPERTY_QUERY storagePropertyQuery) {

	//��������� ������ ��� ���������� ����������
	STORAGE_DEVICE_DESCRIPTOR* deviceDescriptor = (STORAGE_DEVICE_DESCRIPTOR*)calloc(bThousand, 1);
	DWORD dwBytesReturned = 0;

	//���������� ����������� ��� ��������������� ���������� �������� ����������, ��������� ���������� ��������� ��������������� ��������.
	if (!DeviceIoControl(diskHandle,
		IOCTL_STORAGE_QUERY_PROPERTY,				//���������� ������ �� ������� ������� ����������.
		&storagePropertyQuery, sizeof(storagePropertyQuery), deviceDescriptor, bThousand, &dwBytesReturned, 0)) {
		printf("%d", GetLastError());
		CloseHandle(diskHandle);
		exit(-1);
	}

	//������� �������� �����.
	cout << "Model:         " << (char*)(deviceDescriptor)+deviceDescriptor->ProductIdOffset << endl;
	cout << "Version        " << (char*)(deviceDescriptor)+deviceDescriptor->ProductRevisionOffset << endl;
	cout << "Bus type:      " << busType[deviceDescriptor->BusType] << endl;
	cout << "Serial number: " << (char*)(deviceDescriptor)+deviceDescriptor->SerialNumberOffset << endl;
}

void getMemoryInfo() {
	string path;
	_ULARGE_INTEGER diskSpace;
	_ULARGE_INTEGER freeSpace;

	diskSpace.QuadPart = 0;
	freeSpace.QuadPart = 0;

	_ULARGE_INTEGER totalDiskSpace;
	_ULARGE_INTEGER totalFreeSpace;

	totalDiskSpace.QuadPart = 0;				//����� ��������� ������ ������ �����.
	totalFreeSpace.QuadPart = 0;				//����� ��������� ��������� ����� �����.

	char szTemp[BUFSIZE];
	szTemp[0] = '\0';

	GetLogicalDriveStrings(BUFSIZE - 1, szTemp);

	cout.setf(ios::left);
	cout << setw(16) << "Total space[Mb]"
		<< setw(16) << "Free space[Mb]"
		<< setw(16) << "Busy space[%]"
		<< endl;

	int count = 0;
	while (szTemp[count])
	{
		path = szTemp[count];
		path.append(":\\");
		GetDiskFreeSpaceEx(path.c_str(), 0, &diskSpace, &freeSpace);
		diskSpace.QuadPart = diskSpace.QuadPart / (bThousand * bThousand);
		freeSpace.QuadPart = freeSpace.QuadPart / (bThousand * bThousand);
		totalDiskSpace.QuadPart += diskSpace.QuadPart;
		totalFreeSpace.QuadPart += freeSpace.QuadPart;
		count += 4;
	}

	cout << setw(16) << totalDiskSpace.QuadPart
		<< setw(16) << totalFreeSpace.QuadPart
		<< setw(16) << setprecision(3) << 100.0 - (double)totalFreeSpace.QuadPart / (double)totalDiskSpace.QuadPart * Hundred
		<< endl;
}

void getAtaPioDmaSupportStandarts(HANDLE diskHandle) {

	UCHAR identifyDataBuffer[512 + sizeof(ATA_PASS_THROUGH_EX)] = { 0 };

	ATA_PASS_THROUGH_EX &PTE = *(ATA_PASS_THROUGH_EX *)identifyDataBuffer;	//��������� ��� �������� ��� ������� ����������
	PTE.Length = sizeof(PTE);
	PTE.TimeOutValue = 10;									//������ ���������
	PTE.DataTransferLength = 512;							//������ ������ ��� ������
	PTE.DataBufferOffset = sizeof(ATA_PASS_THROUGH_EX);		//�������� � ������ �� ������ ��������� �� ������ ������
	PTE.AtaFlags = ATA_FLAGS_DATA_IN;						//����, ��������� � ������ ������ �� ����������

	IDEREGS *ideRegs = (IDEREGS *)PTE.CurrentTaskFile;
	ideRegs->bCommandReg = 0xEC;

	DWORD dwBytesReturned = 0;

	//���������� ������ ����������
	if (!DeviceIoControl(diskHandle,
		IOCTL_ATA_PASS_THROUGH,								//����, ��������� ��� �� �������� ��������� � ��������� ���� ATA_PASS_THROUGH_EX
		&PTE, sizeof(identifyDataBuffer), &PTE, sizeof(identifyDataBuffer), &dwBytesReturned, NULL)) {
		cout << GetLastError() << std::endl;
		return;
	}
	WORD *data = (WORD *)(identifyDataBuffer + sizeof(ATA_PASS_THROUGH_EX));	//�������� ��������� �� ������ ���������� ������
	
	unsigned short ataSupportByte = data[80];
	int i = 2 * BYTE_SIZE;
	int bitArray[2 * BYTE_SIZE];
	//���������� ����� � ����������� � ��������� ATA � ������ ���
	while (i--) {
		bitArray[i] = ataSupportByte & 32768 ? 1 : 0;
		ataSupportByte = ataSupportByte << 1;
	}

	//����������� ���������� ������ ���.
	cout << "ATA Support:   ";
	for (int i = 8; i >= 4; i--) {
		if (bitArray[i] == 1) {
			if (i != 8) cout << ", ";
			cout << "ATA " << i;
		}
	}
	cout << endl;

	//����� �������������� ������� DMA
	unsigned short dmaSupportByte = data[63];
	int i2 = 2 * BYTE_SIZE;
	//���������� ����� � ����������� � ��������� DMA � ������ ���
	while (i2--) {
		bitArray[i2] = dmaSupportByte & 32768 ? 1 : 0;
		dmaSupportByte = dmaSupportByte << 1;
	}

	//����������� ���������� ������ ���.
	cout << "DMA Support:   ";
	for (int i = 0; i <= 2; i++) {
		if (bitArray[i] == 1) {
			if (i != 0) cout << ", ";
			cout << "DMA mode " << i;
		}
	}
	cout << endl;

	unsigned short pioSupportByte = data[64];
	int i3 = 2 * BYTE_SIZE;
	//���������� ����� � ����������� � ��������� PIO � ������ ���
	while (i3--) {
		bitArray[i3] = pioSupportByte & 32768 ? 1 : 0;
		pioSupportByte = pioSupportByte << 1;
	}

	//����������� ���������� ������ ���.
	cout << "PIO Support:   ";
	for (int i = 0; i <= 7; i++) {
		if (bitArray[i] == 1) {
			if (i != 0) cout << ", ";
			cout << "PIO mode " << i;
		}
	}
	cout << endl;
}

int main()
{
	STORAGE_PROPERTY_QUERY storagePropertyQuery;				//��������� � ����������� �� �������
	storagePropertyQuery.QueryType = PropertyStandardQuery;		//������ ��������, ����� �� ������ ���������� ����������.
	storagePropertyQuery.PropertyId = StorageDeviceProperty;	//����, ��������� �� ����� �������� ���������� ����������.
	HANDLE diskHandle;

	init(diskHandle);
	getDeviceInfo(diskHandle, storagePropertyQuery);
	getMemoryInfo();
	getAtaPioDmaSupportStandarts(diskHandle);
	_getch();
	return 0;
}