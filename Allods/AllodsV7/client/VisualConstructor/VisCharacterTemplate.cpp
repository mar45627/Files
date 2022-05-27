#include "VisCharacterTemplate.h"

VisCharacterTemplate::VisCharacterTemplate(Item item)
{
	doc = new XDocument;
	doc->InsertEndChild(doc->NewDeclaration("xml version=\"1.0\" encoding=\"UTF-8\" "));
	root = doc->NewElement(item.constructor_name);
	doc->InsertEndChild(root);
	main = item.struct_addr;
	Init();
}

VisCharacterTemplate::~VisCharacterTemplate()
{
}

void VisCharacterTemplate::Init()
{
	FORCON("additionalPortraitSettings", 0x18, 0x3C)
	{
		m->AddSource("name", 0x4);
		OPENEX_X("portraitSettings", 0x10)
		{
			m->AddText("animation", Enums::GetAnimation(m->Read(0x4)));
			m->AddInt("animationTime", 0x8);
			m->AddVector3("cameraAnchor", 0x0C);
			m->AddRotation3("cameraRotation", 0x18);
			m->AddFloat("projSettingsVWidth", 0x28);
		}
	}
	AddSFX("agroSound", 0x28);
	AddHref("animationKeysAction", 0x40);
	AddHref("animationKeysActionPeriod", 0x48);
	AddHref("animationKeysSound", 0x50);
	AddHref("animationProperties", 0x58);
	AddHref("characterVisObject", 0x60);
	OPENEX("creatureParameters", 0x68)
	{
		m->AddBool("disableProceduralAndColorEffects", 0x4);
	}
	AddHref("defaultDress", 0x70);
	AddHref("defaultSoundVariation", 0x78);
	AddHref("extension", 0x80);
	AddText("gender", Enums::GetGender(Read(0x88)));
	FORNOT("hairColoredGeosets", 0x8C, 0x0C)
	{
		m->AddSource("Item", i);
	}
	AddFloat("height", 0x9C);
	AddSource("helmGeoset", 0xA0);
	AddInt("hitAnimationCooldown", 0xAC);
	AddInt("hitCritAnimationCooldown", 0xB0);
	AddHref("hitCriticalEffects", 0xB4);
	AddHref("hitEffects", 0xBC);
	AddHref("lower", 0xC4);
	AddHref("mainBakedTexture", 0xCC);
	AddHref("mainHand", 0xD4);
	AddFloat("massCoefficient", 0xDC);
	OpenCon("meleeAttack", 0xE0);
	AddHref("mobAnimations", 0xE4);
	AddHref("morphSettings", 0xEC);
	AddSFX("moveSFX", 0xF4);
	AddHref("offHand", 0x10C);
	OPENEX("portraitSettings", 0x114)
	{
		m->AddText("animation", Enums::GetAnimation(m->Read(0x4)));
		m->AddInt("animationTime", 0x8);
		m->AddVector3("cameraAnchor", 0x0C);
		m->AddRotation3("cameraRotation", 0x18);
		m->AddFloat("projSettingsVWidth", 0x28);
	}
	AddSFX("preAggroSound", 0x140);
	AddFloat("radius", 0x158);
	AddHref("sfxArmorSet", 0x15C);
	FORCON("specialControllers", 0x164, 0x2C)
	{
		m->AddHref("controller", 0x4);
		m->AddSource("name", 0x0C);
		m->OpenCon("parentController", 0x18);
	}
	FORCON("specialHairTexPatch", 0x174, 0x20)
	{
		OPENEX_X("rectangle", 0x4)
		{
			m->AddFloat("x1", 0x4);
			m->AddFloat("y1", 0x0C);
			m->AddFloat("x2", 0x8);
			m->AddFloat("y2", 0x10);
		}
		m->AddHref("texture", 0x18);
	}
	AddHref("traceProperties", 0x184);
	OPENEX("uiSceneSettings", 0x18C)
	{
		m->AddVector3("cameraAnchor", 0x4);
		m->AddFloat("cameraBodyAnchorCoeff", 0x10);
		m->AddFloat("preMissionAdditionalAway", 0x14);
		m->AddVector3("preMissionFaceCameraAnchor", 0x18);
		m->AddFloat("scale", 0x24);
	}
	AddFloat("uiSelectionScale", 0x1B4);
	AddHref("underwear", 0x1B8);
	AddHref("upper", 0x1C0);
	AddHref("variations", 0x1C8);
	OPENEX("visualAliases", 0x1D0)
	{
		FORCONX("creatureVisActions", 0x18, 0x14)
		{
			m->AddHref("alias", 0x4);
			m->AddHref("resource", 0x0C);
		}
		FORCONX("visualItems", 0x28, 0x14)
		{
			m->AddHref("alias", 0x4);
			m->AddHref("resource", 0x0C);
		}
		FORCONX("visualMounts", 0x38, 0x14)
		{
			m->AddHref("alias", 0x4);
			m->AddHref("resource", 0x0C);
		}
	}
	OpenCon("visualScript", 0x218);
	AddSFX("weaponSound", 0x21C);
	AddBool("disableCorpseThrowing", 0x234);
	AddBool("isBreathe", 0x235);
	AddBool("showDecal", 0x236);
	AddBool("useMobAnimationsSet", 0x237);
	AddBool("useWeaponItemsAnimations", 0x238);
}
