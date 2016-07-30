using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PS3Lib;


namespace BO2_Menu_Base__1._19___By_Shadow_
{
    class Funcs
    {
        public static PS3API PS3 = new PS3API();

        public class Offsets
        {

            public static uint function_address = 0x007AA050; // 1.19
            public static uint G_Client = 0x1780F28; // 1.19
            public static uint G_Entity = 0x16B9F20; // 1.19
            public static uint G_ModelIndex = 0x00275FE0; // 1.19
            public static uint G_EntLink = 0x002AD2A0; // 1.19
            public static uint G_EntUnlink = 0x002AD420; // 1.19
            public static uint G_SetOrigin = 0x002794F8; // 1.19
            public static uint G_AddEvent = 0x002797B0; // 1.19
            public static uint G_GivePlayerWeapon = 0x002A81C4; // 1.19
            public static uint G_InitializeAmmo = 0x001E6838; // 1.19
            public static uint SetClientViewAngles = 0x01E1BF0; // 1.19
            public static uint Player_Die = 0x1FD370; // 1.19
            public static uint Scr_PlayerKilled = 0x00248D80; // 1.19     /*0x248F20 - 1.18*/
            public static uint ScriptEntCmdGetCommandTimes = 0x267208;
            public static uint ScriptMover_SetupMove = 0x268A38;
            public static uint Trace_GetEntityHitID = 0x306CC0; // 1.19
            public static uint G_GetPlayerViewOrigin = 0x1E5F30; // 1.19
            public static uint G_LocationalTrace = 0x35C338; // 1.19
            public static uint SV_LinkEntity = 0x00359990; // 1.19
            public static uint G_TempEntity = 0x279740;
            public static uint G_SetModel = 0x2774a4; // 1.19
            public static uint G_Spawn = 0x00278AC0; // 1.19
            public static uint G_SpawnTurret = 0x2BA5C8;
            public static uint G_SpawnHelicopter = 0x22C558;
            public static uint SP_Turret = 0x2BAE58;
            public static uint SP_Script_Model = 0x266F48; // 1.19
            public static uint R_SetFrameFog = 0x007AA050; // 1.19
            public static uint FPS = 0x37FEC; // 1.19
            public static uint CheatProtection = 0x3DBF70;
            public static uint ServerDetails = 0xF57FC5;
            public static uint ServerCache = 0xF57FE4;
            public static uint G_LocalizedStringIndex = 0x275B84; // 1.19
            public static uint G_SoundAliasIndex = 0x4F494C;
            public static uint SV_GameSendServerCommand = 0x00349F6C; // 1.19
            public static uint Cbuf_AddText = 0x00313C18; // 1.19
            public static uint G_GetWeaponIndexForName = 0x2A6BE8;
            public static uint cl_ingame = 0x1CB68E8; // 1.19
            public static uint LocalPlayerName = 0x26C067F; // 1.19
            public static uint level_locals_t = 0x1608100; // 1.19
            public static uint G_MaterialIndex = 0x276020;
            public static uint G_HudElems = 0x15DDB00; // 1.19
            public static uint HudelemSize = 0x88; // 1.19
            public static uint Key_IsDow = 0x001185C0;
            public static uint Play_sound = 0x004F45BC;
        }

        public enum KeyboardType : int
        {
            Numpad = 1,
            Normal = 2
        }

        public enum GClient : uint
        {
            ClientWeapIndex = 0x1B8,
            ClientVelocity = 0x34,
            ClientFriction = 0xC,
            ClientFreeze = 0x5694,
            ClientViewModel = 0x54F4,
            ClientButtonMonitoring = 0x569C,
            ClientPlayerName = 0x5544,
            ClientOrigin = 0x28,
            ClientAngles = 0x56BC,
            ClientTeam = 0x5504,
            ClientIsAlive = 0x55D0,
            ClientStance = 0xFC,
            ClientGodMode = 0x18,
            ClientPerks = 0x548,
            ClientPrimaryCamo = 0x2D8,
            ClientSecondaryCamo = 0x2BC,
            ClientTactical = 0x30C,
            ClientLethal = 0x2F0,
            ClientKillstreak1 = 0x42B,
            ClientKillstreak2 = 0x430,
            ClientKillstreak3 = 0x434,
            PrimaryAmmo = 0x43C,
            SecondaryAmmo = 0x438,
            LethalAmmo = 0x440,
            TacticalAmmo = 0x444,
            LocationSelectorMap = 0x4B0,
            LocationSelectorType = 0x4B4
        }


        public struct Buttons
        {
            public static uint
            X = 8192,
            O = 16384,
            Square = 4,
            L3 = 1088,
            R3 = 32,
            L2 = 256,
            R2 = 512,
            L1 = 2147487744,
            R1 = 128,
            Crouch = 16384,
            Prone = 32768,
            L1andR1 = L1 + R1;
        }

        public static int HostNumber, NearestPlayer;

        public static uint
        DPADUp = 0x34,
        DPADDown = 0x38,
        DPADLeft = 0x3C,
        DPADRight = 0x40;

        public static uint G_Client(int Client, GClient Mod = 0)
        {
            return (Offsets.G_Client + (0x5808 * (uint)Client) + (uint)Mod);
        }

        public static uint G_Entity(int Client, uint Mod = 0)
        {
            return (Offsets.G_Entity + (0x31C * (uint)Client) + Mod);
        }

        public static bool ButtonPressed(int clientIndex, uint Button)
        {
            byte[] Sticky = PS3.Extension.ReadBytes(Offsets.G_Client + 0x547C + ((uint)clientIndex * 0x5808), 4);
            uint Buttonz = BitConverter.ToUInt32(Sticky, 0);
            if (Buttonz == Button)
                return true;
            return false;
        }

        public static bool DPADPressed(int Client, uint Button)
        {
            int ButtonIndex = PS3.Extension.ReadInt32(0x009460FC + Button); // 0094641C  ( 1.18 )
            int B1 = PS3.Extension.ReadInt32(G_Client(Client) + 0x56B8);
            int B2 = PS3.Extension.ReadInt32(G_Client(Client) + 0x56A0);
            if ((B1 == ButtonIndex) || (B2 == ButtonIndex))
                return true;
            return false;
        }

        public static bool cl_ingame()
        {
            return PS3.Extension.ReadBool(Offsets.cl_ingame);
        }

        public static string ReturnName(int Client)
        {
            return PS3.Extension.ReadString(G_Client(Client, GClient.ClientPlayerName));
        }

        public static string ReturnLocalName()
        {
            return PS3.Extension.ReadString(Offsets.LocalPlayerName);
        }

        public static string ReturnHostName()
        {
            return ReturnName(ReturnHostNumber());
        }

        public static int ReturnActivePlayers()
        {
            int Active = -1;

            for (int i = 0; i < 12; i++)
            {
                if (ReturnName(i) != "")
                {
                    Active++;
                }
            }
            return Active;
        }

        public static int ReturnHostNumber()
        {
            string LocalName = ReturnLocalName();

            for (int i = -1; i < 18; i++)
            {
                if (ReturnName(i) == LocalName)
                {
                    HostNumber = i;
                }
            }
            return HostNumber;
        }

        public static void SV_GameSendServerCommand(int Client, string Command)
        {
            RPC.Call(Offsets.SV_GameSendServerCommand, Client, 0, Command);
        }

        public static void iPrintln(int Client, string Message)
        {
            SV_GameSendServerCommand(Client, "O \"" + Message + "\"");
        }

        public static void iPrintlnBold(int Client, string Message)
        {
            SV_GameSendServerCommand(Client, "< \"" + Message + "\"");
        }

        public static void setBlur(int transitionTime, float Strength)
        {
            Funcs.SV_GameSendServerCommand(0, string.Concat(new object[] { "( ", transitionTime, " ", Strength }));
        }

        public static void playSound(int clientIndex, string soundName)
        {
            SV_GameSendServerCommand(0, "B " + RPC.Call(Offsets.Play_sound, new object[] { soundName }));
        }
    }
}
