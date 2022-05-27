#pragma once
#include "../Header.h"

#define OPENIN(name, offset) if(Module * m = OpenIn((name), (offset)))
#define OPENIN_B(name, offset) if(Module * b = m->OpenIn((name), (offset)))
#define OPENIN_C(name, offset) if(Module * c = b->OpenIn((name), (offset)))
#define OPENIN_D(name, offset) if(Module * d = c->OpenIn((name), (offset)))
#define OPENIN_E(name, offset) if(Module * e = d->OpenIn((name), (offset)))
#define OPENEX_F(name, offset) if(Module * f = e->OpenEx((name), (offset)))

#define OPENEX(name, offset) if(Module * m = OpenEx((name), (offset)))
#define OPENEX_B(name, offset) if(Module * b = m->OpenEx((name), (offset)))
#define OPENEX_C(name, offset) if(Module * c = b->OpenEx((name), (offset)))
#define OPENEX_D(name, offset) if(Module * d = c->OpenEx((name), (offset)))
#define OPENEX_E(name, offset) if(Module * e = d->OpenEx((name), (offset)))
#define OPENEX_F(name, offset) if(Module * f = e->OpenEx((name), (offset)))

//--------UNIVERSAL--------//
#define OPENIN_X(name, offset) if(Module * x = m->OpenIn((name), (offset))) if(Module * m = x)
#define OPENEX_X(name, offset) if(Module * x = m->OpenEx((name), (offset))) if(Module * m = x)

#define FORNOTX(name, offset, step) \
if(Module * x = m->OpenIn(name, offset)) \
for (DWORD i = 0x0, size = m->GetForSize(offset); i < size; i += step)  if(Module * m = x)

#define FORCONX(name, offset, step) \
if(Module * x = m->OpenIn(name, offset)) \
for (DWORD i = 0x0, size = m->GetForSize(offset); i < size; i += step) \
	if (Module * m = x->OpenEx("Item", i))

#define FORTYPEX(name, offset, step) \
if(Module * x = m->OpenIn(name, offset)) \
for (DWORD i = 0x0, size = m->GetForSize(offset); i < size; i += step) \
	x->OpenCon("Item", i)
//--------UNIVERSAL--------//

#define FORNOT(name, offset, step) \
if(Module * m = OpenIn(name, offset)) \
for (DWORD i = 0x0, size = GetForSize(offset); i < size; i += step)

#define FORCON(name, offset, step) \
if(Module * x = OpenIn(name, offset)) \
for (DWORD i = 0x0, size = GetForSize(offset); i < size; i += step) \
	if (Module * m = x->OpenEx("Item", i))

#define FORTYPE(name, offset, step) \
if(Module * x = OpenIn(name, offset)) \
for (DWORD i = 0x0, size = GetForSize(offset); i < size; i += step) \
	x->OpenCon("Item", i)

#define FORCON_BC(name, offset, step) \
if(Module * x = b->OpenIn(name, offset)) \
for (DWORD i = 0x0; i < b->GetForSize(offset); i += step) \
	if (Module * c = x->OpenEx("Item", i))

#define FORCON_CD(name, offset, step) \
if(Module * x = c->OpenIn((name), (offset))) \
for (DWORD i = 0x0; i < c->GetForSize((offset)); i += (step)) \
	if (Module * d = x->OpenEx("Item", i))


class Module
{
private:
	XElement Href(string name, string href);
	XElement Type(string name, string type);
	XElement Value(string name, string value);

	Module(string name, DWORD offset, XDocument * d, XElement elem);
	Module(DWORD struct_addr, string mod_name);
	Module(DWORD struct_addr, string mod_name, XDocument * d, XElement elem);

protected:
	DWORD main;
	XElement root = NULL;
	XDocument * doc = NULL;

	Module * CheckMod(string con, string name, DWORD addr);

public:
	Module();
	Module(Item item, long * count);
	~Module();

	bool CheckXDB(Item item);
	//===================================================================================================//
	Module * GetXDB(Item item); // ������� ��������� �� ����������� � XDB
	XElement GetRoot(); // ������� ���������
	XDocument * GetDocument(); // ������� ��������
	string GetPatch(); // ��� XDB
	DWORD GetMain(); // ���������
	//===================================================================================================//

	//===================================================================================================//
	DWORD Read(DWORD offset); // ������� �������� ��� �������
	string GetHref(DWORD offset); // ������ ������
	string GetBool(DWORD offset); // ������ ������
	string GetFloat(DWORD offset); // ������ ��������� �����
	string GetInt(DWORD offset); // ������ �����������
	string GetLong(DWORD offset); // ������ ����������� 8 ���������
	string GetTxt(DWORD offset); // ������ ������ �� txt
	string GetText(DWORD offset); // ������ ������
	//===================================================================================================//

	//===================================================================================================//
	void AddHref(string name, DWORD offset); //������� ������ �� xdb
	void AddHrefSource(string name, DWORD offset); // ������� ����� � ���������� � href

	void AddBool(string name, DWORD offset); // �������� ������ ���
	void AddInt(string name, DWORD offset); // �������� ����������
	void AddLong(string name, DWORD offset); // �������� ���������� 8 ��������
	void AddFloat(string name, DWORD offset); // �������� ���������
	void AddTxt(string name, DWORD offset); // �������� ������ �� txt
	void AddSource(string name, DWORD offset); // �������� ������ �� ��������� ��� �������
	void AddText(string name, string text); // �������� ������� �����
	void AddAttribute(string attribute, string value); // �������� ��������
	void AddContainer(XElement container); // �������� ���������\������

	void AddBinFile(string name, DWORD offset); // �������������� ����� ��������� �����, ��� txt ���� ����������
	//===================================================================================================//
	void AddVector2(string name, DWORD offset);
	void AddVector3(string name, DWORD offset);
	void AddRotation3(string name, DWORD offset);
	void AddSFX(string name, DWORD offset);
	void AddAABB(string name, DWORD offset);
	//void AddBinSize(string xdb);
	//===================================================================================================//

	//===================================================================================================//
	// ��������� ���������� ���������
	// �������������� ����������� � ��������� ���������
	// Name = ��� ����������
	Module * OpenIn(string name, DWORD offset);
	// ��������� ������� ���������. MoveOffset - �������� �� ��������� �� ������ ����������?
	// �������������� ����������� � ��������� ���������
	// Name = ��� ����������
	Module * OpenEx(string name, DWORD offset, bool MoveOffset = true);
	// ��������� ��������� �� ���� ������������ � ��������� ���
	// Value_name = ��� ���������� ��� ������� ������� ���
	// ������ NULL ���� �� ����� ���
	Module * OpenCon(string name, DWORD offset);
	//===================================================================================================//

	DWORD GetForSize(DWORD offset); // �������� ������ ������� ����������������
	string GetConstructor(DWORD offset); // NOT XDB CONSTRUCTOR!!!
	string GetConstructorFromAddr(DWORD Addr); // NOT XDB CONSTRUCTOR!!!

	void SaveXDB();
};

