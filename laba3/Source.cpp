#include <iostream>
#include <iomanip>
#include <Windows.h>
#include <conio.h>
using namespace std;

DWORD* calculateLifeTime(DWORD time) {
	DWORD dwBatteryLifeTimeHours = time / 3600;
	DWORD dwBatteryLifeTimeMinutes = time / 60 - dwBatteryLifeTimeHours * 60;
	DWORD result[2] = { dwBatteryLifeTimeHours, dwBatteryLifeTimeMinutes };
	return result;
}

SYSTEM_POWER_STATUS getBatteryLevel()
{
	SYSTEM_POWER_STATUS status;
	GetSystemPowerStatus(&status);
	return status;
}

void viewBatteryLevel(SYSTEM_POWER_STATUS status)
{
	system("cls");

	cout << "ACLineStatus: ";
	switch (status.ACLineStatus)
	{
	case 0:
		cout << "Offline\n";
		break;
	case 1:
		cout << "Online\n";
		break;
	default:
		cout << "Unknown status\n";
		break;
	}

	cout << "Charge status: ";
	switch (status.BatteryFlag)
	{
	case 1:
		cout << "High\n";
		break;
	case 2:
		cout << "Low\n";
		break;
	case 4:
		cout << "Critical\n";
		break;
	case 8:
		cout << "Charging\n";
		break;
	case 128:
		cout << "No system battery\n";
		break;
	default:
		cout << "Unknown status\n";
		break;
	}
	
	DWORD dwBatteryLifePercent = status.BatteryLifePercent;
	cout << "Battery life percent: " << dwBatteryLifePercent << '\n';

	DWORD* dwBatteryLifeTime = calculateLifeTime(status.BatteryLifeTime);
	cout << "Battery life time: " << dwBatteryLifeTime[0] << " h. " << dwBatteryLifeTime[1] << " min." << '\n';

	DWORD* dwBatteryFullLifeTime = calculateLifeTime(status.BatteryFullLifeTime);
	cout << "Battery full life time: " << dwBatteryFullLifeTime[0] << " h. " << dwBatteryFullLifeTime[1] << " min." << '\n';
}

int main()
{
	while (1)
	{
		viewBatteryLevel(getBatteryLevel());
	}
	return 0;
}
