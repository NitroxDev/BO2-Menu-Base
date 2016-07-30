using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PS3Lib; // Déclaration de l'extension PS3lib

namespace BO2_Menu_Base__1._19___By_Shadow_
{
    public partial class Form1 : Form
    {
        public static PS3API PS3 = new PS3API(); // Cela permet d'utiliser le PS3lib avec la fonction " PS3 "
        private int AllClientHUD = 0x3ff;
        public Form1()
        {
            InitializeComponent();
        }

        #region Déplacement_Form
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case 0x84:
                    base.WndProc(ref m);
                    if ((int)m.Result == 0x1)
                        m.Result = (IntPtr)0x2;
                    return;
            }

            base.WndProc(ref m);
        }
        #endregion // Premet de déplacer une form sans bordure

        private void Form1_Load(object sender, EventArgs e)
        {
            // à vous de mettre quelque chose quand l'application se lance
        }
        
        private void timer1_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < 12; i++)
            {
                if (MenuBase.Vars.Verification[i] >= 1)
                {
                    MenuBase.DoMenuBase(i);
                }
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            MenuBase.InitializeMenu();
            timer1.Start();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Do you want use CCAPI 2.70 ?", "API Connexion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                PS3.ChangeAPI(SelectAPI.ControlConsole);
                if (PS3.ConnectTarget() && PS3.AttachProcess())
                {
                    RPC.Enable(); // Activation du RPC
                    textBox1.Text += "[" + DateTime.Now.ToString() + "] Connected to target and attached to process..." + Environment.NewLine;
                    Huds.doTypeWriter(100, AllClientHUD, "Welcome To: ^5" + Funcs.ReturnHostName() + "^7's Lobby!", 0, 9.0, 100f, 150f, 100, 0xfa0, 900, 0xff, 0xff, 0xff, 0xff, 0x8f, 60, 0x4d, 0xff);
                }
                else
                    textBox1.Text += "[" + DateTime.Now.ToString() + "] Failed to connect and attach..." + Environment.NewLine;
            }
            else if (dialogResult == DialogResult.No)
            {
                PS3.ChangeAPI(SelectAPI.TargetManager);
                if (PS3.ConnectTarget() && PS3.AttachProcess())
                {
                    RPC.Enable();
                    textBox1.Text += "[" + DateTime.Now.ToString() + "] Connected to target and attached to process..." + Environment.NewLine;
                    Huds.doTypeWriter(100, AllClientHUD, "Welcome To: ^5" + Funcs.ReturnHostName() + "^7's Lobby!", 0, 9.0, 100f, 150f, 100, 0xfa0, 900, 0xff, 0xff, 0xff, 0xff, 0x8f, 60, 0x4d, 0xff);
                }
                else
                    textBox1.Text += "[" + DateTime.Now.ToString() + "] Failed to connect and attach..." + Environment.NewLine;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Voici la liste des crédits pour la base du Menu : \n \nSticky : Une base créé en 1.18 que j'ai entièrement modifié \niMCSx : Pour le PS3lib \nEnstone : Pour le CCAPI \nChoco : Pour la création du RPC \nShadow : Mise à jour + Amélioration du HUD inspiré d'un menu GSC \n \nJe tiens à dire que j'ai entièrement mis à jours les adresse avec IDA.", "[BO2] Menu Base : Informations", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }
    }
}
