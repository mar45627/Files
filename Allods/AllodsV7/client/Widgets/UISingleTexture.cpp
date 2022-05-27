#include "UISingleTexture.h"

UISingleTexture::UISingleTexture(Item item)
{
	doc = new XDocument;
	doc->InsertEndChild(doc->NewDeclaration("xml version =\"1.0\" encoding=\"UTF-8\" ")); 
	root = doc->NewElement(item.constructor_name);
	doc->InsertEndChild(root);
	main = item.struct_addr;
	Init();
}

UISingleTexture::~UISingleTexture()
{
}

void UISingleTexture::Init()
{
	AddInt("permanentCache", 0x18);
	AddHref("singleTexture", 0x1C);
}