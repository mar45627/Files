#include "VisObjectTemplate.h"

VisObjectTemplate::VisObjectTemplate(Item item)
{
	doc = new XDocument;
	doc->InsertEndChild(doc->NewDeclaration("xml version=\"1.0\" encoding=\"UTF-8\" "));
	root = doc->NewElement(item.constructor_name);
	doc->InsertEndChild(root);
	main = item.struct_addr;
	Init();
}

VisObjectTemplate::~VisObjectTemplate()
{
}

void VisObjectTemplate::Init()
{
	OPENEX("defaultState", 0x18)
	{
		FORCONX("keySounds", 0x4, 0x14)
		{
			FORCONX("tunedSounds", 0x4, 0x24)
			{
				m->AddFloat("pitch", 0x4);
				m->AddSFX("sound", 0x8);
				m->AddFloat("volume", 0x20);
			}
		}
		FORCONX("objects", 0x14, 0x18)
		{
			m->AddSource("locatorName", 0x4);
			m->AddHref("visObject", 0x10);
		}
		m->AddSFX("sound", 0x24);
		m->AddBool("allowMultipleSoundInstances", 0x3C);
		m->AddBool("playSoundOnKeys", 0x3D);
		m->AddHref("animation", 0x44);
		m->AddBool("isNecessaryAnim", 0x4C);
	}
	AddInt("fadeInMS", 0x68);
	AddInt("fadeOutMS", 0x6C);
	AddHref("geometry", 0x70);
	AddHref("particle", 0x78);
	AddHref("questHighlight", 0x80);
	AddFloat("replaceDistance", 0x88);
	AddHref("replacement", 0x8C);
	AddFloat("scale", 0x94);
	AddSFX("sound", 0x98);
	FORCON("states", 0xB0, 0x50)
	{
		FORCONX("keySounds", 0x4, 0x14)
		{
			FORCONX("tunedSounds", 0x4, 0x24)
			{
				m->AddFloat("pitch", 0x4);
				m->AddSFX("sound", 0x8);
				m->AddFloat("volume", 0x20);
			}
		}
		FORCONX("objects", 0x14, 0x18)
		{
			m->AddSource("locatorName", 0x4);
			m->AddHref("visObject", 0x10);
		}
		m->AddSFX("sound", 0x24);
		m->AddBool("allowMultipleSoundInstances", 0x3C);
		m->AddBool("playSoundOnKeys", 0x3D);
		m->AddHref("animation", 0x44);
		m->AddBool("isNecessaryAnim", 0x4C);
	}
	FORNOT("visObjComponents", 0xC0, 0x4)
	{
		m->OpenCon("Item", i);
	}
	AddBool("softReplace", 0xD0);
}
