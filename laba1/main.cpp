#pragma comment (lib, "Setupapi.lib")
#include <Windows.h>
#include <stdio.h>
#include <SetupAPI.h>
#include <devguid.h>
#include <RegStr.h>
#include <vector>
#include <string.h>
#include <locale.h>
#include <conio.h>
#include "library.h"

using namespace std;

void init(HDEVINFO& hDevInfo);
vector<string> getInfo(HDEVINFO, SP_DEVINFO_DATA);
vector<STRUCT_DEVICES_TABLE> getDescriptions(vector<string>);

int main(int argc, char *argv[])
{
	setlocale(LC_ALL, "Russian");

	HDEVINFO hDev;
	init(hDev);

	SP_DEVINFO_DATA deviceInfo;
	deviceInfo.cbSize = sizeof(SP_DEVINFO_DATA);
	vector<STRUCT_DEVICES_TABLE> devices = getDescriptions(getInfo(hDev, deviceInfo));

	for (int i = 0; i < devices.size(); i++)
	{
		cout << i + 1;
		cout << ". DeviceID: " << devices[i]._deviceID.c_str() << endl << "   VendorID: " << devices[i]._vendorID.c_str()
			<< endl << "   Description: " << devices[i]._name.c_str() << endl << "   Producer: " << devices[i]._description.c_str() << endl << endl;
	}

	_getch();

	return 0;
}

void init(HDEVINFO& hDevInfo)
{
	// returns a handle to a device information set that contains requested device information elements for a local computer.
	if ((hDevInfo = SetupDiGetClassDevs(NULL,
		REGSTR_KEY_PCIENUM,
		0,
		DIGCF_PRESENT | DIGCF_ALLCLASSES)) == INVALID_HANDLE_VALUE)		//Return only devices that are currently present.
	{
		exit(1);
	}
}

vector<string> getInfo(HDEVINFO _hDev, SP_DEVINFO_DATA _deviceInfo)
{
	vector<string> result;

	for (DWORD i = 0; SetupDiEnumDeviceInfo(_hDev, i, &_deviceInfo); i++)
	{
		LPTSTR buffer = NULL;
		DWORD bufferSize = 0;

		while (!SetupDiGetDeviceRegistryProperty(_hDev,  // retrieves a specified Plug and Play device property
			&_deviceInfo,
			SPDRP_HARDWAREID, //retrieves a REG_MULTI_SZ string that contains the list of hardware IDs for a device. 
			NULL,
			(PBYTE)buffer,
			bufferSize,
			&bufferSize))
		{
			if (GetLastError() == ERROR_INSUFFICIENT_BUFFER) //The data area passed to a system call is too small
			{
				if (buffer) LocalFree(buffer);
				buffer = (LPTSTR)LocalAlloc(LPTR, bufferSize * 2);
			}
			else break;
		}

		result.push_back(string(buffer));

		if (buffer) LocalFree(buffer);
	}

	return result;
}

vector<STRUCT_DEVICES_TABLE> getDescriptions(vector<string> _devices)
{
	vector<STRUCT_DEVICES_TABLE> result;
	DeviceLibrary *lib = new DeviceLibrary();

	while (_devices.size() != 0)
	{
		string vendor = "0x" + _devices.back().substr(8, 4);
		string device = "0x" + _devices.back().substr(17, 4);
		_devices.pop_back();
		STRUCT_DEVICES_TABLE temp;
		temp._vendorID = vendor;
		temp._deviceID = device;
		result.push_back(temp);
	}
	lib->GetDescription(&result);
	return result;
}

//Device Identification Strings: PCI\VEN_1000&DEV_0001&SUBSYS_00000000&REV_02   -example