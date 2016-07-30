using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PS3Lib;

namespace BO2_Menu_Base__1._19___By_Shadow_
{
    class Huds
    {
        public static PS3API PS3 = new PS3API();
        public class Offsets
        {
            public static uint
            G_LocalizedStringIndex = Funcs.Offsets.G_LocalizedStringIndex,
            level_locals_t = Funcs.Offsets.level_locals_t,
            G_HudElems = Funcs.Offsets.G_HudElems,
            HudelemSize = Funcs.Offsets.HudelemSize;
        }

        public class HElems
        {
            public static uint ElemIndex = Offsets.G_HudElems;
            public static uint HudsLength = 0x88;
            public static uint abilityFlag = 0x84;
            public static uint alignOrg = 0x72;
            public static uint alignScreen = 0x73;
            public static uint color = 0x18;
            public static uint duration = 0x38;
            public static uint fadeStartTime = 0x20;
            public static uint fadeTime = 0x54;
            public static uint flag2 = 0x7A;
            public static uint flags = 0x4C;
            public static uint Font = 0x70;
            public static uint FontSize = 0xC;
            public static uint fontScaleStartTime = 0x14;
            public static uint fontScaleTime = 0x52;
            public static uint fromAlignOrg = 0x76;
            public static uint fromAlignScreen = 0x77;
            public static uint fromColor = 0x1C;
            public static uint fromFontScale = 0x10;
            public static uint fromHeight = 0x5e;
            public static uint fromWidth = 0x5c;
            public static uint fromX = 0x28;
            public static uint fromY = 0x2C;
            public static uint fxBirthTime = 0x48;
            public static uint fxDecayDuration = 0x6A;
            public static uint fxDecayStartTime = 0x68;
            public static uint fxLetterTime = 0x66;
            public static uint fxRedactDecayDuration = 110;
            public static uint fxRedactDecayStartTime = 0x6c;
            public static uint glowColor = 0x44;
            public static uint Height = 0x5A;
            public static uint label = 0x56;
            public static uint materialIndex = 0x71;
            public static uint moveStartTime = 0x30;
            public static uint moveTime = 0x62;
            public static uint offscreenMaterialIdx = 0x75;
            public static uint clientOffset = 0x7c;
            public static uint scaleStartTime = 0x24;
            public static uint scaleTime = 0x60;
            public static uint sort = 0x40;
            public static uint soundID = 0x78;
            public static uint targetEntNum = 80;
            public static uint team = 0x80;
            public static uint text = 0x62;
            public static uint time = 0x34;
            public static uint type = 0x6D;
            public static uint ui3dWindow = 0x4f;
            public static uint value = 60;
            public static uint Width = 0x58;
            public static uint X = 0x00;
            public static uint Y = 0x04;
            public static uint Z = 0x08;
            public static uint width = 0x58;
            public static uint xOffset = 0;
            public static uint yOffset = 4;
            public static uint zOffset = 8;
            public static uint fontScale = 12;
        }

        public static int G_LocalizedStringIndex(string Text)
        {
            return (int)RPC.Call(Offsets.G_LocalizedStringIndex, new object[] { Text });
        }

        public static void ChangeText(uint Element, string Text)
        {
            PS3.Extension.WriteInt32(Element + HElems.text, G_LocalizedStringIndex(Text));
        }

        public static byte[] RGBA(decimal R, decimal G, decimal B, decimal A)
        {
            byte[] RGBA = new byte[4];
            byte[] RVal = BitConverter.GetBytes(Convert.ToInt32(R));
            byte[] GVal = BitConverter.GetBytes(Convert.ToInt32(G));
            byte[] BVal = BitConverter.GetBytes(Convert.ToInt32(B));
            byte[] AVal = BitConverter.GetBytes(Convert.ToInt32(A));
            RGBA[0] = RVal[0];
            RGBA[1] = GVal[0];
            RGBA[2] = BVal[0];
            RGBA[3] = AVal[0];
            return RGBA;
        }

        public static uint GetLevelTime()
        {
            return PS3.Extension.ReadUInt32(Offsets.level_locals_t + 0x798);
        }

        private static uint HudElem_Alloc()
        {
            for (int i = 30; i < 0x400; i++)
            {
                uint offset = Offsets.G_HudElems + (uint)(i) * 0x88;
                if (PS3.Extension.ReadInt16(offset + 0x70) == 0)
                {
                    PS3.SetMemory(offset, new byte[0x88]);
                    return offset;
                }
            }
            return 0;
        }

        public static uint SetShader(int clientIndex, int Material, short width, short height, float x, float y, int r = 255, int g = 255, int b = 255, int a = 255)
        {
            uint elem = HudElem_Alloc();
            PS3.Extension.WriteInt32(elem + HElems.type, 8);
            PS3.Extension.WriteInt32(elem + HElems.materialIndex, (int)Material);
            PS3.Extension.WriteInt16(elem + HElems.Height, height);
            PS3.Extension.WriteInt16(elem + HElems.Width, width);
            PS3.Extension.WriteFloat(elem + HElems.X, x);
            PS3.Extension.WriteFloat(elem + HElems.Y, y);
            PS3.Extension.WriteInt32(elem + HElems.clientOffset, clientIndex);
            PS3.SetMemory(elem + 0x79, new byte[] { 0xFF });
            PS3.SetMemory(elem + HElems.color, RGBA(r, g, b, a));
            return elem;
        }

        public static uint SetText(int clientIndex, string Text, short Font, double FontSize, float x, float y, int r = 255, int g = 255, int b = 255, int a = 255, int glowr = 255, int glowg = 255, int glowb = 255, int glowa = 0)
        {
            uint elem = HudElem_Alloc();
            PS3.Extension.WriteInt32(elem + HElems.type, 1);
            PS3.Extension.WriteFloat(elem + HElems.FontSize, (float)FontSize);
            PS3.Extension.WriteInt16(elem + HElems.Font, Font);
            PS3.Extension.WriteFloat(elem + HElems.X, x);
            PS3.Extension.WriteFloat(elem + HElems.Y, y);
            PS3.Extension.WriteInt32(elem + HElems.clientOffset, clientIndex);
            PS3.Extension.WriteInt32(elem + HElems.text, G_LocalizedStringIndex(Text));
            PS3.SetMemory(elem + HElems.color, RGBA(r, g, b, a));
            PS3.SetMemory(elem + HElems.glowColor, RGBA(glowr, glowg, glowb, glowa));
            PS3.SetMemory(elem + 0x79, new byte[] { 0xFF });
            PS3.SetMemory(elem + HElems.Font, new byte[] { 0x01 });
            return elem;
        }

        public static void DestroyElement(uint Element)
        {
            PS3.SetMemory(Element, new byte[HElems.HudsLength]);
        }

        public static void DestroyAllElems()
        {
            for (uint i = 30; i < 0x400; i++)
            {
                DestroyElement(i);
            }
        }

        public static void FadeOverTime(uint elem, short Time, byte R = 0, byte G = 0, byte B = 0, byte A = 0)
        {
            PS3.Extension.WriteBytes(elem + HElems.fromColor, PS3.Extension.ReadBytes(elem + HElems.color, 4));
            PS3.Extension.WriteInt16(elem + HElems.fadeTime, Time);
            PS3.Extension.WriteUInt32(elem + HElems.fadeStartTime, GetLevelTime());
            PS3.Extension.WriteBytes(elem + HElems.color, new byte[] { R, G, B, A });
        }
        public static void FadeAlphaOverTime(uint elem, short Time, byte A = 0)
        {
            byte b = PS3.Extension.ReadByte(elem + HElems.color);
            byte b2 = PS3.Extension.ReadByte(elem + (HElems.color + 1));
            byte b3 = PS3.Extension.ReadByte(elem + (HElems.color + 2));
            PS3.Extension.WriteBytes(elem + HElems.fromColor, PS3.Extension.ReadBytes(elem + HElems.color, 4));
            PS3.Extension.WriteInt16(elem + HElems.fadeTime, Time);
            PS3.Extension.WriteUInt32(elem + HElems.fadeStartTime, GetLevelTime());
            PS3.Extension.WriteBytes(elem + HElems.color, new byte[] { b, b2, b3, A });
        }
        public static void FontScaleOverTime(uint elem, double FontSize, short time)
        {
            PS3.Extension.WriteFloat(elem + HElems.fromFontScale, PS3.Extension.ReadFloat(elem + HElems.FontSize));
            PS3.Extension.WriteUInt32(elem + HElems.fontScaleStartTime, GetLevelTime());
            PS3.Extension.WriteInt16(elem + HElems.fontScaleTime, time);
            PS3.Extension.WriteFloat(elem + HElems.FontSize, (float)FontSize);
        }
        public static void MoveOverTime(uint Elem, short time, float x, float y)
        {
            PS3.Extension.WriteFloat(Elem + HElems.fromX, PS3.Extension.ReadFloat(Elem));
            PS3.Extension.WriteFloat(Elem + HElems.fromY, PS3.Extension.ReadFloat(Elem + HElems.Y));
            PS3.Extension.WriteInt32(Elem + HElems.moveStartTime, (int)GetLevelTime());
            PS3.Extension.WriteInt16(Elem + HElems.moveTime, time);
            PS3.Extension.WriteFloat(Elem, x);
            PS3.Extension.WriteFloat(Elem + HElems.Y, y);
        }
        public static void ScaleOverTime(uint elem, short time, short width, short height)
        {
            PS3.Extension.WriteUInt32(elem + HElems.scaleStartTime, GetLevelTime());
            PS3.Extension.WriteInt32(elem + HElems.fromHeight, (int)PS3.Extension.ReadInt16(elem + HElems.Width));
            PS3.Extension.WriteInt32(elem + HElems.fromWidth, (int)PS3.Extension.ReadInt16(elem + HElems.Height));
            PS3.Extension.WriteInt16(elem + HElems.Width, width);
            PS3.Extension.WriteInt16(elem + HElems.Height, height);
            PS3.Extension.WriteInt16(elem + HElems.scaleTime, time);
        }

        public static byte[] ReverseBytes(byte[] inArray)
        {
            Array.Reverse(inArray);
            return inArray;
        }

        public static uint getLevelTime()
        {
            return PS3.Extension.ReadUInt32(Funcs.Offsets.level_locals_t + 0x798);
        }

        public static byte[] ToHexFloat(float Axis)
        {
            byte[] bytes = BitConverter.GetBytes(Axis);
            Array.Reverse(bytes);
            return bytes;
        }

        public static void doTypeWriter(uint Index, int clientIndex, string Text, short font, double fontSize, float x, float y, ushort fxLetterTime, ushort fxDecayStartTime, ushort fxDecayDuration, int r, int g, int b, int a, int r1, int g1, int b1, int a1)
        {
            uint offset = Funcs.Offsets.G_HudElems + (Convert.ToUInt32(Index) * 0x88);
            byte[] buffer = ReverseBytes(BitConverter.GetBytes(Convert.ToInt32(clientIndex)));
            PS3.SetMemory(offset, new byte[0x88]);
            PS3.SetMemory(offset + HElems.type, ReverseBytes(BitConverter.GetBytes(1)));
            PS3.SetMemory(offset + 0x79, new byte[] { 0xff });
            PS3.Extension.WriteInt32(offset + HElems.text, G_LocalizedStringIndex(Text));
            PS3.Extension.WriteFloat(offset + HElems.fontScale, (float)fontSize);
            PS3.SetMemory(offset + HElems.xOffset, ToHexFloat(x));
            PS3.SetMemory(offset + HElems.yOffset, ToHexFloat(y));
            PS3.SetMemory(offset + HElems.color, RGBA(r, g, b, a));
            PS3.SetMemory(offset + HElems.glowColor, RGBA(r1, g1, b1, a1));
            PS3.Extension.WriteInt16(offset + 0x70, font);
            PS3.SetMemory(offset + 0x70, new byte[] { 1 });
            PS3.SetMemory(offset + HElems.clientOffset, buffer);
            PS3.Extension.WriteUInt32(offset + HElems.flags, PS3.Extension.ReadUInt32(offset + 0x4c) | 0x800);
            PS3.Extension.WriteUInt32(offset + HElems.fxBirthTime, getLevelTime());
            PS3.Extension.WriteUInt16(offset + HElems.fxLetterTime, fxLetterTime);
            PS3.Extension.WriteUInt16(offset + HElems.fxDecayStartTime, fxDecayStartTime);
            PS3.Extension.WriteUInt16(offset + HElems.fxDecayDuration, fxDecayDuration);
        }
    }
}
