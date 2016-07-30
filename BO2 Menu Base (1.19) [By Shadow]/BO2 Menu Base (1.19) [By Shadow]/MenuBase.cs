using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PS3Lib;

namespace BO2_Menu_Base__1._19___By_Shadow_
{

    class Functions_Modz
    {
        public static PS3API PS3 = new PS3API();
        private static bool Exemple_;

        public static void Exemple(int client)
        {
            if (!Exemple_)
            {
                PS3.SetMemory((uint)(0x0000000 + (client * 0x5808)), new byte[] { 1 }); // Fonction qui active le godmode par " exemple "
                Funcs.iPrintln(client, "Exemple ^2Activé "); // Message dans la killfeed en partie
                Exemple_ = true;
            }
            else
            {
                PS3.SetMemory((uint)(0x0000000 + (client * 0x5808)), new byte[] { 0 }); // Fonction qui désactive le godmode par " exemple "
                Funcs.iPrintln(client, "Exemple ^1Désavtivé "); // Message dans la killfeed en partie
                Exemple_ = false;
            }
        }
    }
    
    class MenuBase
    {
        public static uint[] Shader = new uint[12];
        public static uint[] SideBar = new uint[12];
        public static uint[] MenuTitle = new uint[12];
        public static uint[] OptionsText = new uint[12];
        public static uint[] Scrollbar = new uint[12];
        public static float[] xPosition = new float[12];
        public static uint[] Scrollbar2 = new uint[12];
        public static uint[] Shader2 = new uint[12];
        public static uint[] MenuInfo = new uint[12];
        public static uint[] MenuBut = new uint[12];

        public static class Vars
        {
            public static bool MenuIsRunning;
            public static bool MenuIsStored;
            public static bool HostIsVerified;

            public static bool[] MenuOpen = new bool[12];
            public static bool[] MenuClosed = new bool[12];

            public static int[] SubMenu = new int[12];
            public static int[] Scroll = new int[12];
            public static int[] MaxScrollNum = new int[12];
            public static int[] Verification = new int[12];
            public static int[] SelectedOption = new int[12];
        }

        public static void StoreMenu(int Client)
        {
            xPosition[Client] = 320f;
            MenuInfo[Client] = Huds.SetText(Client, "   Welcome: ^5" + Funcs.ReturnLocalName() + "\n^7Host:^5" + Funcs.ReturnHostName() + "\n^7Developed By: ^5Shadow", 200, 1.5, 1000f, 255f, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0);//MenuBut[Client] = Huds.SetText(Client, "[{+cross}]/[{+cross}]: ^5Scroll\n^7[{+cross}]: ^5Return\n^7[{+cross}]: ^5Select", 300, 1.7999999523162842, -39f, 170f, 0x3e8, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0);
            Shader[Client] = Huds.SetShader(Client, 3, 220, 0x3e8, 1000f, 0f, 0, 0, 0, 200);
            Shader2[Client] = Huds.SetShader(Client, 100, 50, 60, 1000f, 0f, 0xff, 0xff, 0xff, 0xff);
            SideBar[Client] = Huds.SetShader(Client, 3, 2, 0x3e8, 1000f, 0f, 0, 100, 0x59, 150);
            Scrollbar2[Client] = Huds.SetText(Client, "[{+cross}]", 300, 1.5, 1000f, 1002f, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0);
            Scrollbar[Client] = Huds.SetShader(Client, 0x45, 0xda, 0x12, 1002f, 90f, 0, 100, 0x59, 150);
            MenuTitle[Client] = Huds.SetText(Client, MenuTextStructure(Client, 0)[0], 4, 2.2000000476837158, 1010f, 50f, 0xff, 0x7d, 100, 0xff, 0, 100, 0x55, 0xff);
            OptionsText[Client] = Huds.SetText(Client, MenuTextStructure(Client, 0)[1], 4, 1.5, 1010f, 90f, 0xff, 100, 0x55, 0xff, 0xff, 0xff, 0xff, 0);
        }

        public static void OpenMenu(int Client)
        {

            Funcs.Offsets.G_GivePlayerWeapon = 0x77;
            Huds.MoveOverTime(MenuInfo[Client], 450, xPosition[Client], 380f);
            Huds.MoveOverTime(Shader[Client], 500, xPosition[Client], 0f);
            Huds.MoveOverTime(Shader2[Client], 500, 460f, 20f);
            Huds.MoveOverTime(Scrollbar2[Client], 500, 302f, 90f);
            Huds.MoveOverTime(SideBar[Client], 500, xPosition[Client], 0f);
            Huds.MoveOverTime(Scrollbar[Client], 500, xPosition[Client] + 2f, 90f);
            Huds.MoveOverTime(MenuTitle[Client], 500, xPosition[Client] + 25f, 50f);
            Huds.MoveOverTime(OptionsText[Client], 500, xPosition[Client] + 25f, 90f);
            Vars.MenuOpen[Client] = true;
            Funcs.setBlur(200, 2f);
            Vars.MaxScrollNum[Client] = MaxScroll(Client, 0);
            Vars.Scroll[Client] = 0;
        }

        public static void CloseMenu(int Client)
        {
            Funcs.setBlur(0, 0f);
            Huds.MoveOverTime(MenuInfo[Client], 500, 1000f, 0f);
            Huds.MoveOverTime(Shader[Client], 500, 1000f, 0f);
            Huds.MoveOverTime(Shader2[Client], 500, 1000f, 0f);
            Huds.MoveOverTime(SideBar[Client], 500, 1000f, 0f);
            Huds.MoveOverTime(Scrollbar[Client], 500, 1002f, 90f);
            Huds.MoveOverTime(Scrollbar2[Client], 500, 1002f, 90f);
            Huds.MoveOverTime(MenuTitle[Client], 500, 1010f, 50f);
            Huds.MoveOverTime(OptionsText[Client], 500, 1010f, 90f);
            Vars.MenuOpen[Client] = false;
        }

        public static void ChangeSubMenu(int Client, int MenuID)
        {
            Huds.FontScaleOverTime(OptionsText[Client], 0.0, 250);
            Huds.FontScaleOverTime(MenuTitle[Client], 0.0, 250);
            Huds.ChangeText(OptionsText[Client], MenuTextStructure(Client, MenuID)[1]);
            Huds.ChangeText(MenuTitle[Client], MenuTextStructure(Client, MenuID)[0]);
            Huds.FontScaleOverTime(OptionsText[Client], 1.5, 0xff);
            Huds.FontScaleOverTime(MenuTitle[Client], 2.2000000476837158, 0xff);
            Huds.MoveOverTime(Scrollbar[Client], 250, xPosition[Client] + 2f, 90f);
            Huds.MoveOverTime(Scrollbar2[Client], 250, 302f, 90f);
            Vars.MaxScrollNum[Client] = MaxScroll(Client, MenuID);
            Vars.Scroll[Client] = 0;
        }

        public static void MoveScroller(int Client)
        {
            Huds.MoveOverTime(Scrollbar[Client], 250, xPosition[Client] + 2f, (float)(90 + (Vars.Scroll[Client] * 0x12)));
            Huds.MoveOverTime(Scrollbar2[Client], 250, 302f, (float)(90 + (Vars.Scroll[Client] * 0x12)));
        }

        public static string[] MenuTextStructure(int Client, int MenuID)
        {
            Vars.SubMenu[Client] = MenuID;

            if (Vars.SubMenu[Client] == 0)
            {
                return new string[] { "BO2 Menu Base", "Option 1\nOption 2\nOption 3\nOption 4\nOption 5\nOption 6\nOption 7\nOption 8\nOption 9\nOption 10" };
            }
            else if (Vars.SubMenu[Client] == 1)
            {
                return new string[] { "Option 1", "Option 1\nOption 2\nOption 3\nOption 4\nOption 5\nOption 6\nOption 7\nOption 8" };
            }
            else if (Vars.SubMenu[Client] == 2)
            {
                return new string[] { "Option 2", "Option 1\nOption 2\nOption 3\nOption 4\nOption 5\nOption 6\nOption 7\nOption 8" };
            }
            else if (Vars.SubMenu[Client] == 3)
            {
                return new string[] { "Option 3", "Option 1\nOption 2\nOption 3\nOption 4\nOption 5\nOption 6\nOption 7\nOption 8" };
            }
            else if (Vars.SubMenu[Client] == 4)
            {
                return new string[] { "Option 4", "Option 1\nOption 2\nOption 3\nOption 4\nOption 5\nOption 6\nOption 7\nOption 8" };
            }
            else if (Vars.SubMenu[Client] == 5)
            {
                return new string[] { "Option 5", "Option 1\nOption 2\nOption 3\nOption 4\nOption 5\nOption 6\nOption 7\nOption 8" };
            }
            else if (Vars.SubMenu[Client] == 6)
            {
                return new string[] { "Option 6", "Option 1\nOption 2\nOption 3\nOption 4\nOption 5\nOption 6\nOption 7\nOption 8" };
            }
            else if (Vars.SubMenu[Client] == 7)
            {
                return new string[] { "Option 7", "Option 1\nOption 2\nOption 3\nOption 4\nOption 5\nOption 6\nOption 7\nOption 8" };
            }
            else if (Vars.SubMenu[Client] == 8)
            {
                return new string[] { "Option 8", "Option 1\nOption 2\nOption 3\nOption 4\nOption 5\nOption 6\nOption 7\nOption 8" };
            }
            else if (Vars.SubMenu[Client] == 9)
            {
                return new string[] { "Option 9", "Option 1\nOption 2\nOption 3\nOption 4\nOption 5\nOption 6\nOption 7\nOption 8" };
            }
            else if (Vars.SubMenu[Client] == 10)
            {
                return new string[] { "Option 10", "Option 1\nOption 2\nOption 3\nOption 4\nOption 5\nOption 6\nOption 7\nOption 8" };
            }
            else if (Vars.SubMenu[Client] == 11)
            {
                return new string[] { "Option 11", "Option 1\nOption 2\nOption 3\nOption 4\nOption 5\nOption 6\nOption 7\nOption 8" };
            }
            else if (Vars.SubMenu[Client] == 12)
            {
                return new string[] { "Option 12", "Option 1\nOption 2\nOption 3\nOption 4\nOption 5\nOption 6\nOption 7\nOption 8" };
            }
            return new string[] { "", "" };
        }

        public static int MaxScroll(int Client, int MenuID)
        {
            int ScrollNum = 0;
            foreach (char NewLines in MenuTextStructure(Client, MenuID)[1])
            {
                if (NewLines == '\n')
                {
                    ScrollNum++;
                }
            }
            return ScrollNum;
        }

        public static void InitializeMenu()
        {
            if (Funcs.cl_ingame())
            {
                if (!Vars.MenuIsRunning)
                {
                    MenuBase.Vars.MenuIsRunning = true;
                    Vars.MenuClosed[Funcs.ReturnHostNumber()] = true;

                    if (!Vars.HostIsVerified)
                    {
                        Vars.Verification[Funcs.ReturnHostNumber()] = 3;

                        Vars.HostIsVerified = true;

                        if (!Vars.MenuIsStored)
                        {
                            StoreMenu(Funcs.ReturnHostNumber());
                            Vars.MenuIsStored = true;
                        }
                    }
                }
                else
                    System.Windows.Forms.MessageBox.Show("Menu has already been started!", "Information", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Asterisk);
            }
            else
                System.Windows.Forms.MessageBox.Show("Please start the menu while in game!", "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
        }

        public static void DoMenuBase(int Client)
        {
            if (Funcs.cl_ingame())
            {
                if (Vars.MenuIsRunning && Vars.HostIsVerified)
                {
                    if (Vars.Verification[Client] >= 1)
                    {
                        if (!Vars.MenuOpen[Client] && Vars.MenuClosed[Client])
                        {
                            if (Funcs.ButtonPressed(Client, Funcs.Buttons.R3))
                            {
                                OpenMenu(Client);
                                Vars.MenuClosed[Client] = false;
                                Funcs.playSound(Client, "uin_alert_lockon");
                            }
                        }
                        if (Vars.MenuOpen[Client] && !Vars.MenuClosed[Client])
                        {
                            if (Funcs.ButtonPressed(Client, Funcs.Buttons.R3))
                            {
                                if (Vars.SubMenu[Client] == 0)
                                {
                                    CloseMenu(Client);
                                    Vars.MenuClosed[Client] = true;
                                    Funcs.playSound(Client, "uin_alert_lockon");
                                }
                                if (Funcs.ButtonPressed(Client, Funcs.Buttons.R3))
                                {
                                    if (Vars.SubMenu[Client] > 0)
                                    {
                                        ChangeSubMenu(Client, 0);
                                        Funcs.playSound(Client, "uin_alert_lockon");
                                    }
                                }
                            }
                            if (Funcs.ButtonPressed(Client, Funcs.Buttons.X))
                            {
                                for (int i = 0; i < 10; i++)
                                {
                                    if (Vars.SubMenu[Client] == 0)
                                    {
                                        if (Vars.Scroll[Client] == i)
                                        {
                                            ChangeSubMenu(Client, i + 1);
                                            Funcs.playSound(Client, "uin_alert_lockon");
                                        }
                                    }
                                }
                            }
                            if (Funcs.ButtonPressed(Client, Funcs.Buttons.R1))
                            {
                                if (Vars.Scroll[Client] == Vars.MaxScrollNum[Client])
                                {
                                    Vars.Scroll[Client] = 0;
                                    Huds.MoveOverTime(Scrollbar[Client], 250, xPosition[Client] + 2, 90);
                                    Funcs.playSound(Client, "uin_alert_lockon");
                                }
                                else
                                {
                                    Vars.Scroll[Client]++;
                                    MoveScroller(Client);
                                }
                            }

                            if (Funcs.ButtonPressed(Client, Funcs.Buttons.L1))
                            {
                                if (Vars.Scroll[Client] == 0)
                                {
                                    Vars.Scroll[Client] = Vars.MaxScrollNum[Client];
                                    Huds.MoveOverTime(Scrollbar[Client], 250, xPosition[Client] + 2, 90 + (Vars.MaxScrollNum[Client] * 18));
                                    Funcs.playSound(Client, "uin_alert_lockon");
                                }
                                else
                                {
                                    Vars.Scroll[Client]--;
                                    MoveScroller(Client);
                                }
                            }
                            if (Funcs.ButtonPressed(Client, Funcs.Buttons.X))
                            {
                                if (Vars.SubMenu[Client] == 0)
                                {
                                    if (Vars.Scroll[Client] == 0)
                                    {
                                        // Ne pas toucher
                                    }
                                    if (Vars.Scroll[Client] == 1)
                                    {
                                        // Ne pas toucher
                                    }
                                    if (Vars.Scroll[Client] == 2)
                                    {
                                        // Ne pas toucher
                                    }
                                    if (Vars.Scroll[Client] == 3)
                                    {
                                        // Ne pas toucher
                                    }
                                    if (Vars.Scroll[Client] == 4)
                                    {
                                        // Ne pas toucher
                                    }
                                    if (Vars.Scroll[Client] == 5)
                                    {
                                        // Ne pas toucher
                                    }
                                    if (Vars.Scroll[Client] == 6)
                                    {
                                        // Ne pas toucher
                                    }
                                    if (Vars.Scroll[Client] == 7)
                                    {
                                        // Ne pas toucher
                                    }
                                }
                            }

                            if (Funcs.ButtonPressed(Client, Funcs.Buttons.X))
                            {
                                if (Vars.SubMenu[Client] == 1)
                                {
                                    if (Vars.Scroll[Client] == 0)
                                    {
                                        Functions_Modz.Exemple(1); // cliquez sur aperçu de la définition de Functions_Modz pour comprendre
                                    }
                                    if (Vars.Scroll[Client] == 1)
                                    {
                                        // Fonction de l'option 1 => Option 2
                                    }
                                    if (Vars.Scroll[Client] == 2)
                                    {
                                        // Fonction de l'option 1 => Option 3
                                    }
                                    if (Vars.Scroll[Client] == 3)
                                    {
                                        // Fonction de l'option 1 => Option 4
                                    }
                                    if (Vars.Scroll[Client] == 4)
                                    {
                                        // Fonction de l'option 1 => Option 5
                                    }
                                    if (Vars.Scroll[Client] == 5)
                                    {
                                        // Fonction de l'option 1 => Option 6
                                    }
                                    if (Vars.Scroll[Client] == 6)
                                    {
                                        // Fonction de l'option 1 => Option 7
                                    }
                                    if (Vars.Scroll[Client] == 7)
                                    {
                                        // Fonction de l'option 1 => Option 8
                                    }
                                }
                            }

                            if (Funcs.ButtonPressed(Client, Funcs.Buttons.X))
                            {
                                if (Vars.SubMenu[Client] == 2)
                                {
                                    if (Vars.Scroll[Client] == 0)
                                    {
                                        // Fonction de l'option 2 => Option 1
                                    }
                                    if (Vars.Scroll[Client] == 1)
                                    {
                                        // Fonction de l'option 2 => Option 2
                                    }
                                    if (Vars.Scroll[Client] == 2)
                                    {
                                        // Fonction de l'option 2 => Option 3
                                    }
                                    if (Vars.Scroll[Client] == 3)
                                    {
                                        // Fonction de l'option 2 => Option 4
                                    }
                                    if (Vars.Scroll[Client] == 4)
                                    {
                                        // Fonction de l'option 2 => Option 5
                                    }
                                    if (Vars.Scroll[Client] == 5)
                                    {
                                        // Fonction de l'option 2 => Option 6
                                    }
                                    if (Vars.Scroll[Client] == 6)
                                    {
                                        // Fonction de l'option 2 => Option 7
                                    }
                                    if (Vars.Scroll[Client] == 7)
                                    {
                                        // Fonction de l'option 2 => Option 8
                                    }
                                }
                            }

                            if (Funcs.ButtonPressed(Client, Funcs.Buttons.X))
                            {
                                if (Vars.SubMenu[Client] == 3)
                                {
                                    if (Vars.Scroll[Client] == 0)
                                    {
                                        // Fonction de l'option 3 => Option 1
                                    }
                                    if (Vars.Scroll[Client] == 1)
                                    {
                                        // Fonction de l'option 3 => Option 2
                                    }
                                    if (Vars.Scroll[Client] == 2)
                                    {
                                        // Fonction de l'option 3 => Option 3
                                    }
                                    if (Vars.Scroll[Client] == 3)
                                    {
                                        // Fonction de l'option 3 => Option 4
                                    }
                                    if (Vars.Scroll[Client] == 4)
                                    {
                                        // Fonction de l'option 3 => Option 5
                                    }
                                    if (Vars.Scroll[Client] == 5)
                                    {
                                        // Fonction de l'option 3 => Option 6
                                    }
                                    if (Vars.Scroll[Client] == 6)
                                    {
                                        // Fonction de l'option 3 => Option 7
                                    }
                                    if (Vars.Scroll[Client] == 7)
                                    {
                                        // Fonction de l'option 3 => Option 8
                                    }
                                }
                            }

                            if (Funcs.ButtonPressed(Client, Funcs.Buttons.X))
                            {
                                if (Vars.SubMenu[Client] == 4)
                                {
                                    if (Vars.Scroll[Client] == 0)
                                    {
                                        // Fonction de l'option 4 => Option 1
                                    }
                                    if (Vars.Scroll[Client] == 1)
                                    {
                                        // Fonction de l'option 4 => Option 2
                                    }
                                    if (Vars.Scroll[Client] == 2)
                                    {
                                        // Fonction de l'option 4 => Option 3
                                    }
                                    if (Vars.Scroll[Client] == 3)
                                    {
                                        // Fonction de l'option 4 => Option 4
                                    }
                                    if (Vars.Scroll[Client] == 4)
                                    {
                                        // Fonction de l'option 4 => Option 5
                                    }
                                    if (Vars.Scroll[Client] == 5)
                                    {
                                        // Fonction de l'option 4 => Option 6
                                    }
                                    if (Vars.Scroll[Client] == 6)
                                    {
                                        // Fonction de l'option 4 => Option 7
                                    }
                                    if (Vars.Scroll[Client] == 7)
                                    {
                                        // Fonction de l'option 4 => Option 8
                                    }
                                }
                            }

                            if (Funcs.ButtonPressed(Client, Funcs.Buttons.X))
                            {
                                if (Vars.SubMenu[Client] == 5)
                                {
                                    if (Vars.Scroll[Client] == 0)
                                    {
                                        // Fonction de l'option 5 => Option 1
                                    }
                                    if (Vars.Scroll[Client] == 1)
                                    {
                                        // Fonction de l'option 5 => Option 2
                                    }
                                    if (Vars.Scroll[Client] == 2)
                                    {
                                        // Fonction de l'option 5 => Option 3
                                    }
                                    if (Vars.Scroll[Client] == 3)
                                    {
                                        // Fonction de l'option 5 => Option 4
                                    }
                                    if (Vars.Scroll[Client] == 4)
                                    {
                                        // Fonction de l'option 5 => Option 5
                                    }
                                    if (Vars.Scroll[Client] == 5)
                                    {
                                        // Fonction de l'option 5 => Option 6
                                    }
                                    if (Vars.Scroll[Client] == 6)
                                    {
                                        // Fonction de l'option 5 => Option 7
                                    }
                                    if (Vars.Scroll[Client] == 7)
                                    {
                                        // Fonction de l'option 5 => Option 8
                                    }
                                }
                            }

                            if (Funcs.ButtonPressed(Client, Funcs.Buttons.X))
                            {
                                if (Vars.SubMenu[Client] == 6)
                                {
                                    if (Vars.Scroll[Client] == 0)
                                    {
                                        // etc ......
                                    }
                                    if (Vars.Scroll[Client] == 1)
                                    {
                                        // etc ......
                                    }
                                    if (Vars.Scroll[Client] == 2)
                                    {

                                    }
                                    if (Vars.Scroll[Client] == 3)
                                    {
                                        // etc ......
                                    }
                                    if (Vars.Scroll[Client] == 4)
                                    {
                                        // etc ......
                                    }
                                    if (Vars.Scroll[Client] == 5)
                                    {
                                        // etc ......
                                    }
                                    if (Vars.Scroll[Client] == 6)
                                    {
                                        // etc ......
                                    }
                                    if (Vars.Scroll[Client] == 7)
                                    {
                                        // etc ......
                                    }
                                }
                            }

                            if (Funcs.ButtonPressed(Client, Funcs.Buttons.X))
                            {
                                if (Vars.SubMenu[Client] == 7)
                                {
                                    if (Vars.Scroll[Client] == 0)
                                    {
                                        // etc ......
                                    }
                                    if (Vars.Scroll[Client] == 1)
                                    {
                                        // etc ......
                                    }
                                    if (Vars.Scroll[Client] == 2)
                                    {
                                        // etc ......
                                    }
                                    if (Vars.Scroll[Client] == 3)
                                    {
                                        // etc ......
                                    }
                                    if (Vars.Scroll[Client] == 4)
                                    {
                                        // etc ......
                                    }
                                    if (Vars.Scroll[Client] == 5)
                                    {
                                        // etc ......
                                    }
                                    if (Vars.Scroll[Client] == 6)
                                    {
                                        // etc ......
                                    }
                                    if (Vars.Scroll[Client] == 7)
                                    {
                                        // etc ......
                                    }
                                }
                            }

                            if (Funcs.ButtonPressed(Client, Funcs.Buttons.X))
                            {
                                if (Vars.SubMenu[Client] == 8)
                                {
                                    if (Vars.Scroll[Client] == 0)
                                    {
                                        // etc ......
                                    }
                                    if (Vars.Scroll[Client] == 1)
                                    {
                                        // etc ......
                                    }
                                    if (Vars.Scroll[Client] == 2)
                                    {
                                        // etc ......
                                    }
                                    if (Vars.Scroll[Client] == 3)
                                    {
                                        // etc ......
                                    }
                                    if (Vars.Scroll[Client] == 4)
                                    {
                                        // etc ......
                                    }
                                    if (Vars.Scroll[Client] == 5)
                                    {
                                        // etc ......
                                    }
                                    if (Vars.Scroll[Client] == 6)
                                    {
                                        // etc ......
                                    }
                                    if (Vars.Scroll[Client] == 7)
                                    {
                                        // etc ......
                                    }
                                }
                            }

                            if (Funcs.ButtonPressed(Client, Funcs.Buttons.X))
                            {
                                if (Vars.SubMenu[Client] == 9)
                                {
                                    if (Vars.Scroll[Client] == 0)
                                    {
                                        // etc ......
                                    }
                                    if (Vars.Scroll[Client] == 1)
                                    {
                                        // etc ......
                                    }
                                    if (Vars.Scroll[Client] == 2)
                                    {
                                        // etc ......
                                    }
                                    if (Vars.Scroll[Client] == 3)
                                    {
                                        // etc ......
                                    }
                                    if (Vars.Scroll[Client] == 4)
                                    {
                                        // etc ......
                                    }
                                    if (Vars.Scroll[Client] == 5)
                                    {
                                        // etc ......
                                    }
                                    if (Vars.Scroll[Client] == 6)
                                    {
                                        // etc ......
                                    }
                                    if (Vars.Scroll[Client] == 7)
                                    {
                                        // etc ......
                                    }
                                }
                            }
                            if (Funcs.ButtonPressed(Client, Funcs.Buttons.X))
                            {
                                if (Vars.SubMenu[Client] == 10)
                                {
                                    if (Vars.Scroll[Client] == 0)
                                    {
                                        // etc ......
                                    }
                                    if (Vars.Scroll[Client] == 1)
                                    {
                                        // etc ......
                                    }
                                    if (Vars.Scroll[Client] == 2)
                                    {
                                        // etc ......
                                    }
                                    if (Vars.Scroll[Client] == 3)
                                    {
                                        // etc ......
                                    }
                                    if (Vars.Scroll[Client] == 4)
                                    {
                                        // etc ......
                                    }
                                    if (Vars.Scroll[Client] == 5)
                                    {
                                        // etc ......
                                    }
                                    if (Vars.Scroll[Client] == 6)
                                    {
                                        // etc ......
                                    }
                                    if (Vars.Scroll[Client] == 7)
                                    {
                                        // etc ......
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}