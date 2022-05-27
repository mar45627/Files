#pragma once
#include "../../Header.h"
class VICPack : public Module
{
public:
	VICPack(DWORD struct_addr, string name, XDocument * d);
	~VICPack();

	void Init();
};