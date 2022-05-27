#include "VisualMount.h"

VisualMount::VisualMount(Item item)
{
	doc = new XDocument;
	doc->InsertEndChild(doc->NewDeclaration("xml version=\"1.0\" encoding=\"UTF-8\" "));
	root = doc->NewElement(item.constructor_name);
	doc->InsertEndChild(root);
	main = item.struct_addr;
	Init();
}

VisualMount::~VisualMount()
{
}

void VisualMount::Init()
{
	AddHref("visualMountClass", 0x7C);
	AddHref("mount", 0x58);
	AddSFX("additionalWhoosh", 0x1C);
	AddSFX("hitSoundOverride", 0x40);
	FORCON("scales", 0x6C, 0x10)
	{
		m->AddHref("character", 0x4);
		m->AddFloat("mountScale", 0x0C);
	}
	OPENEX("cameraShift", 0x34)
	{
		m->AddFloat("absoluteHeight", 0x4);
		m->AddFloat("additionalShift", 0x8);
	}
	AddFloat("additionalStableAngle", 0x18);
	AddFloat("mountSize", 0x68);
	AddBool("useCharacterMorphHeightScale", 0x84);
}
