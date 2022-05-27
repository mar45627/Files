#pragma once
#include "../Header.h"

DWORD FAddr = 0x01697955;//AOgame + 0x1297955;
DWORD FOff = 0x01697999;//AOgame + 0x1297999;
void __declspec(naked) FileHack(void) {
	__asm {
		jmp[FOff]
	}
}

void BypassFileCheck()
{
	BP.AddAddr(FAddr, &FileHack, 3);
}