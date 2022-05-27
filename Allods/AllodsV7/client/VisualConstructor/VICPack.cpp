#include "VICPack.h"

VICPack::VICPack(DWORD struct_addr, string name, XDocument * d)
{
	doc = d;
	root = doc->NewElement(name.c_str());
	main = struct_addr;
	AddAttribute("type", "client.VisualConstructor.VICPack");
	Init();
}

VICPack::~VICPack()
{
}

void VICPack::Init()
{
	FORTYPE("dynamicComponents", 0x18, 0x4);
	FORTYPE("staticComponents", 0x28, 0x4);
}