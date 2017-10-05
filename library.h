#pragma once
#define FILE_PATH "pci.ids.txt"
#include <iostream>
#include <fstream>
#include <cstdio>
#include <string>
#include <vector>

using namespace std;

struct STRUCT_DEVICES_TABLE
{
public:
	string _deviceID;
	string _vendorID;
	string _name;
	string _description;
};

class DeviceLibrary
{
public:
	DeviceLibrary();
	~DeviceLibrary();

	void GetDescription(vector<STRUCT_DEVICES_TABLE>*);

private:
	fstream file;

	void IdenticVendor(string, vector<STRUCT_DEVICES_TABLE>*);
	void IdenticDevice(string, vector<STRUCT_DEVICES_TABLE>*);
};