using ezOverLay;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace ACMenu2
{
    public partial class Menu : Form
    {
        private System.Windows.Forms.Button currentBtn;
        private Panel leftBorderBtn;
        Form1 formulado;
        ez ez2 = new ez();
        Point pos = new Point();

        [DllImport("user32.dll")]

        static extern short GetAsyncKeyState(Keys vKey);
        public Menu()
        {
            InitializeComponent();

            leftBorderBtn = new Panel();
            leftBorderBtn.Size = new Size(7, 45);
            panel1.Controls.Add(leftBorderBtn);
            panel4.Controls.Add(esp);
            panel4.Controls.Add(panel3);
            panel4.Controls.Add(aimbot);
            panel4.Controls.Add(functions);
            panel4.Controls.Add(configpanel);
            esp.Visible = false;
            panel3.Visible = false;
            aimbot.Visible = false;
            functions.Visible = false;
            configpanel.Visible = false;

        }


        private struct RGBColors
        {
            public static Color color1 = Color.FromArgb(172, 126, 241);
            public static Color color2 = Color.FromArgb(249, 118, 176);
            public static Color color3 = Color.FromArgb(253, 138, 114);
            public static Color color4 = Color.FromArgb(95, 77, 221);
            public static Color color5 = Color.FromArgb(249, 88, 155);
            public static Color color6 = Color.FromArgb(24, 161, 251);
        }

        private void ActivateButton(object senderBtn, Color color)
        {
            if (currentBtn == null)
            {
               
            }
            else
            {
              //  DisableButton();
                if (senderBtn != null)
                {
                    currentBtn.BackColor = Color.FromArgb(37, 36, 81);
                    currentBtn.ForeColor = color;
                    currentBtn.TextAlign = ContentAlignment.MiddleCenter;
                    leftBorderBtn.BackColor = color;
                    leftBorderBtn.Location = new Point(0, currentBtn.Location.Y);
                    leftBorderBtn.Visible = true;
                    leftBorderBtn.BringToFront();
                }
            }
        }
        private void DisableButton()
        {
           if (currentBtn != null)
            {
               currentBtn.BackColor = Color.FromArgb(1, 12, 40);
                currentBtn.ForeColor = Color.Cyan;
                currentBtn.TextAlign = ContentAlignment.MiddleLeft;

            }
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            
          
        }
        public int cont = 4;
        private void timer1_Tick(object sender, EventArgs e)
        {
          
            }

        private void button1_Click(object sender, EventArgs e)
        {
            DisableButton();
            currentBtn = button1;
            ActivateButton(sender, RGBColors.color1);
            label1.Text = "ESP";
            
            //outros.Visible = false;
         //   aimbot.Visible = false;
            esp.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DisableButton();
            currentBtn = button2;
            ActivateButton(sender, RGBColors.color2);
            label1.Text = "AIMBOT";
            esp.Visible = false;
            aimbot.Visible = true;
            //panel3.Visible = true;
         //   outros.Visible = false;
         //   aimbot.Visible = true;
        }

        private void label2_Click(object sender, EventArgs e)
        {
          Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DisableButton();
            currentBtn = button3;
            ActivateButton(sender, RGBColors.color3);
            label1.Text = "FUNCTIONS";
            esp.Visible = false;
            aimbot.Visible = false;
            functions.Visible = true;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                variavel.ESPBOX = true;
            }
            else
            {
                variavel.ESPBOX = false;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                variavel.ESPLINE = true;
            }
            else
            {
                variavel.ESPLINE = false;
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked == true)
            {
                variavel.ESPNAME = true;
            }
            else
            {
                variavel.ESPNAME = false;
            }
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox5.Checked == true)
            {
                variavel.ESPVIDA = true;
            }
            else
            {
                variavel.ESPVIDA = false;
            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked == true)
            {
                variavel.ESPAmigo = true;
            }
            else
            {
                variavel.ESPAmigo = false;
            }
        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox7.Checked == true)
            {
                variavel.Aimbot = true;
            }
            else
            {
                variavel.Aimbot = false;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DisableButton();
            currentBtn = button4;
            ActivateButton(sender, RGBColors.color4);
            label1.Text = "FUNCTIONS";
            esp.Visible = false;
            aimbot.Visible = false;
            functions.Visible = false;
            configpanel.Visible = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {

            bool isNotepadRunning = Process.GetProcessesByName("csgo").Length > 0;
            if (isNotepadRunning)
            {
               formulado = new Form1();
                formulado.Show();
               
            }
            else
            {
                MessageBox.Show("Abra o game.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point mousePos = Control.MousePosition;
                this.Location = new Point(this.Location.X + (mousePos.X - pos.X),
                                          this.Location.Y + (mousePos.Y - pos.Y));
            }

            pos = Control.MousePosition;
        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void checkBox9_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkBox9.Checked == true)
            {

                formulado.balasin(true);
            }
            else
            {
                formulado.balasin(false);
            }
        }

        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox8.Checked == true)
            {

                formulado.vidain(true);
            }
            else
            {
                formulado.vidain(false);
            }
        }
    }
}


