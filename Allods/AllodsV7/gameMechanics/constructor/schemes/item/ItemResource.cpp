#include "ItemResource.h"

ItemResource::ItemResource(Item item)
{
	doc = new XDocument;
	doc->InsertEndChild(doc->NewDeclaration("xml version =\"1.0\" encoding=\"UTF-8\" ")); 
	root = doc->NewElement(item.constructor_name);
	doc->InsertEndChild(root);
	main = item.struct_addr;
	Init();
}

ItemResource::~ItemResource()
{
}

void ItemResource::Init()
{
	FORCON("actionGroupsBonuses", 0x1C, 0x1C)
	{
		m->AddHref("actionGroup", 0x4);
		//
	}
	OPENEX("actionPreviewInfo", 0x2C)
	{
		OPENEX_X("elseInfo", 0x4)
		{
			m->AddHref("mount", 0x4);
			m->AddHref("mountSkin", 0x0C);
			m->AddHref("mountSkinUnlock", 0x14);
		}
		OPENEX_X("info", 0x20)
		{
			m->AddHref("mount", 0x4);
			m->AddHref("mountSkin", 0x0C);
			m->AddHref("mountSkinUnlock", 0x14);
		}
		FORTYPEX("predicates", 0x3C, 0x4);
	}
	AddTxt("bindDescription", 0x78);
	AddText("binding", Enums::GetBinding(Read(0x88)));
	//FORCON("calcers", 0x8C, 0x14)
	//{
	//	m->OpenCon("calcer", 0x4);
	//	m->AddSource("name", 0x8);
	//}
	AddHref("category", 0x9C);
	OpenCon("counter", 0xA4);
	//FORCON("descVars", 0xA8, 0x28)
	//{
	//	m->AddSource("name", 0x4);
	//	m->OpenCon("scaler", 0x10);
	//	m->AddTxt("text", 0x14);
	//	m->AddFloat("value", 0x24);
	//}
	AddTxt("description", 0xB8);
	FORNOT("dressSet", 0xC8, 0x8)
	{
		m->AddHref("Item", i);
	}
	//FORCON("extraDescParts", 0xD8, 0x1C)
	//{
	//	m->AddTxt("descPart", 0x4);
	//	m->AddHref("descVarsSource", 0x14);
	//}
	OpenCon("functionalPart", 0xE8);
	AddHref("image", 0xEC);
	OpenCon("interactions", 0xF4);
	AddHref("itemClass", 0xF8);
	AddTxt("itemMallDescription", 0x100);
	AddHref("itemMallImage", 0x110);
	AddText("itemMallType", Enums::GetItemMallType(Read(0x118)));
	AddInt("level", 0x11C);
	AddLong("lifeLengthCap", 0x120);
	AddHref("lifestyleCollection", 0x128);
	FORTYPE("lifestylePredicates", 0x130, 0x4);
	AddTxt("name", 0x140);
	FORCON("names", 0x150, 0x18)
	{
		m->AddInt("level", 0x4);
		m->AddTxt("name", 0x8);
	}
	OpenCon("onExpire", 0x160);
	OpenCon("prices", 0x164);
	AddHref("quality", 0x168);
	AddInt("requiredLevel", 0x170);
	AddText("requiredReputation", Enums::GetReputation(Read(0x174)));
	AddText("showItemContextAction", Enums::GetAction(Read(0x178)));
	AddText("slot", Enums::GetSlot(Read(0x17C)));
	AddText("source", Enums::GetSource(Read(0x180)));
	AddHref("spell", 0x184);
	AddInt("stackLimit", 0x18C);
	AddSource("sysName", 0x190);
	AddHref("visualElement", 0x19C);
	AddHref("visualElementAlias", 0x1A4);
	AddTxt("worldDropNamePrefix", 0x1AC);
	AddTxt("worldDropNameRoot", 0x1BC);
	AddTxt("worldDropNameSuffix", 0x1CC);
	AddBool("canBeDeposited", 0x1DC);
	AddBool("clearAllOnTry", 0x1DD);
	AddBool("forceShowQuality", 0x1DE);
	AddBool("ignoreDressSlotLevel", 0x1DF);
	AddBool("isHideLifestyleWhileNotEquipped", 0x1E0);
	AddBool("isProbe", 0x1E1);
	AddBool("isQuestRelated", 0x1E2);
	AddBool("needCheckPredicates", 0x1E3);
	AddBool("ritual", 0x1E4);
	AddBool("soldForAltCurrency", 0x1E5);
}