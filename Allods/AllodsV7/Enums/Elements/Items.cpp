#include "../Enums.h"

enum Slot
{
	HELM = 0,
	ARMOR = 1,
	PANTS = 2,
	BOOTS = 3,
	MANTLE = 4,
	GLOVES = 5,
	BRACERS = 6,
	BELT = 7,
	RING1 = 8,
	RING2 = 9,
	EARRING1 = 10,
	NECKLACE = 11,
	CLOAK = 12,
	SHIRT = 13,
	MAINHAND = 14,
	OFFHAND = 15,
	RANGED = 16,
	AMMO = 17,
	TABARD = 18,
	TRINKET = 19,
	BAG = 20,
	DEATHINSURANCE = 21,
	LIFESTYLEHEAD = 22,
	LIFESTYLEBACK = 23,
	LIFESTYLESUIT = 24,
	LIFESTYLEUNDERWEAR = 25,
	EARRING2 = 26,
	DEPOSITBOX = 27,
	OFFENSIVERUNE1 = 28,
	OFFENSIVERUNE2 = 29,
	OFFENSIVERUNE3 = 30,
	DEFENSIVERUNE1 = 31,
	DEFENSIVERUNE2 = 32,
	DEFENSIVERUNE3 = 33,
	LIFESTYLESHOULDER = 34,
	LSWEAPON = 35,
	HIDDENPOWER = 36,
	LIFESTYLEPET = 37,
	UNDRESSABLE = 38,
	TWOHANDED = 39,
	DUALWIELD = 40,
	RING = 41,
	EARRINGS = 42,
	RUNE = 43
};
string Enums::GetSlot(DWORD slot)
{
	switch (slot)
	{
	default:
		return "HELM";
	case ARMOR:
		return "ARMOR";
	case PANTS:
		return "PANTS";
	case BOOTS:
		return "BOOTS";
	case MANTLE:
		return "MANTLE";
	case GLOVES:
		return "GLOVES";
	case BRACERS:
		return "BRACERS";
	case BELT:
		return "BELT";
	case RING1:
		return "RING1";
	case RING2:
		return "RING2";
	case EARRING1:
		return "EARRING1";
	case NECKLACE:
		return "NECKLACE";
	case CLOAK:
		return "CLOAK";
	case SHIRT:
		return "SHIRT";
	case MAINHAND:
		return "MAINHAND";
	case OFFHAND:
		return "OFFHAND";
	case RANGED:
		return "RANGED";
	case AMMO:
		return "AMMO";
	case TABARD:
		return "TABARD";
	case TRINKET:
		return "TRINKET";
	case BAG:
		return "BAG";
	case DEATHINSURANCE:
		return "DEATHINSURANCE";
	case LIFESTYLEHEAD:
		return "LIFESTYLEHEAD";
	case LIFESTYLEBACK:
		return "LIFESTYLEBACK";
	case LIFESTYLESUIT:
		return "LIFESTYLESUIT";
	case LIFESTYLEUNDERWEAR:
		return "LIFESTYLEUNDERWEAR";
	case EARRING2:
		return "EARRING2";
	case DEPOSITBOX:
		return "DEPOSITBOX";
	case OFFENSIVERUNE1:
		return "OFFENSIVERUNE1";
	case OFFENSIVERUNE2:
		return "OFFENSIVERUNE2";
	case OFFENSIVERUNE3:
		return "OFFENSIVERUNE3";
	case DEFENSIVERUNE1:
		return "DEFENSIVERUNE1";
	case DEFENSIVERUNE2:
		return "DEFENSIVERUNE2";
	case DEFENSIVERUNE3:
		return "DEFENSIVERUNE3";
	case LIFESTYLESHOULDER:
		return "LIFESTYLESHOULDER";
	case LSWEAPON:
		return "LSWEAPON";
	case HIDDENPOWER:
		return "HIDDENPOWER";
	case LIFESTYLEPET:
		return "LIFESTYLEPET";
	case UNDRESSABLE:
		return "UNDRESSABLE";
	case TWOHANDED:
		return "TWOHANDED";
	case DUALWIELD:
		return "DUALWIELD";
	case RING:
		return "RING";
	case EARRINGS:
		return "EARRINGS";
	case RUNE:
		return "RUNE";
	}
	return "";
}

enum ShowItemContextAction
{
	Default = 0,
	Always = 1,
	OnlyCurrentQuest = 2,
	Never = 3
};

enum ItemMallType
{
	NOTITEMMALLABLE = 0,
	ITEMMALLABLE = 1,
	SELLABLE = 2
};
enum Binding
{
	BindNone = 0,
	BindOnPickup = 1,
	BindOnEquip = 2,
	BindOnUse = 3
};
string Enums::GetBinding(DWORD bind)
{
	switch (bind)
	{
	case BindNone:
		return "BindNone";
	case BindOnPickup:
		return "BindOnPickup";
	case BindOnEquip:
		return "BindOnEquip";
	case BindOnUse:
		return "BindOnUse";
	}
	return "";
}

enum ItemSource
{
	Quest = 0,
	FixedDrop = 1,
	WorldDrop = 2,
	Crafted = 3,
	Conjured = 4,
	Vendor = 5,
	QuestItem = 6
};
enum Reputation
{
	Hostility = 0,
	Enemy = 1,
	Unfriendly = 2,
	Neutral = 3,
	Kindly = 4,
	Friendly = 5,
	Confidential = 6
};

string Enums::GetItemMallType(DWORD type)
{
	switch (type)
	{
	case NOTITEMMALLABLE:
		return "NOTITEMMALLABLE";
	case ITEMMALLABLE:
		return "ITEMMALLABLE";
	case SELLABLE:
		return "SELLABLE";
	}
	return "";
}
string Enums::GetAction(DWORD action)
{
	switch (action)
	{
	case 1:
		return "Always";
	case 2:
		return "OnlyCurrentQuest";
	case 3:
		return "Never";
	default:
		return "Default";
	}
	return "";
}
string Enums::GetSource(DWORD source)
{
	switch (source)
	{
	case Quest:
		return "Quest";
	case FixedDrop:
		return "FixedDrop";
	case WorldDrop:
		return "WorldDrop";
	case Crafted:
		return "Crafted";
	case Conjured:
		return "Conjured";
	case Vendor:
		return "Vendor";
	case QuestItem:
		return "QuestItem";
	}
	return "";
}
string Enums::GetReputation(DWORD rep)
{
	switch (rep)
	{
	case Hostility:
		return "Hostility";
	case Enemy:
		return "Enemy";
	case Unfriendly:
		return "Unfriendly";
	case Neutral:
		return "Neutral";
	case Kindly:
		return "Kindly";
	case Friendly:
		return "Friendly";
	case Confidential:
		return "Confidential";
	}
	return "";
}