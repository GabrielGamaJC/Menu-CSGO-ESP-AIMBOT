using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Runtime.InteropServices;
using Microsoft.VisualBasic.Logging;
using ezOverLay;
using System.Security.Permissions;
using swed32;
//using Swed32;
//using Swed64;
using System.IO;
using System.Security.Cryptography.X509Certificates;

namespace ACMenu2
{
    public partial class Form1 : Form
    {
        
        ez ez = new ez();
        methods? m;
        Entity localPlayer = new Entity();
        List<Entity> entities = new List<Entity>();
        
        [DllImport("user32.dll")]

        static extern short GetAsyncKeyState(Keys vKey);
        public Form1()
        {
            InitializeComponent();
        }

        public Boolean box = false;
        public Boolean line = false;
        public Boolean aimb = false;
        public Boolean amigo = false;
        public Boolean ammo = false;
        public Boolean health = false;
        public Boolean esphealth = false;
        public Boolean espname = false;
        public IntPtr ptr;
        public int j;

        //public static int n = 2;
        //   byte[] nopBytes = Enumerable.Repeat((byte)0x90, n).ToArray();
        // byte[] bytesmun = BitConverter.GetBytes(0xFF08);
        private void Form1_Load(object sender, EventArgs e)
        {

            CheckForIllegalCrossThreadCalls = false;
            m = new methods();
            if (m != null)
            {
                ez.SetInvi(this);
                ez.DoStuff("Counter-Strike: Global Offensive - Direct3D 9", this);
                Thread thread = new Thread(main) { IsBackground = true };
                thread.Start();
            }
             ptr= m.mem.GetModuleBase("client.dll");
            //ptrbala = m.mem.ReadPointer(modulobase, 0x00195404);

          //  ptr = m.mem.ReadPointer(modulobase, 0x00195404);


            //   m.mem.GetProcess("ac_client"); 



            // Gerar array de bytes contendo opcodes NOP


            //int i = 0;
        }
        //funcões menu

        float pixdist = 40;
        void main()
        {
            while (true)
            {
                localPlayer = m.ReadLocalPlayer();
                entities = m.ReadEntities(localPlayer, Height, Width);

                entities = entities.OrderBy(o => o.xdist).ToList();
                if (aimb == true)
                {
                    if (GetAsyncKeyState(Keys.LShiftKey) < 0)
                {
                    if (entities.Count > 0)
                    {
                        foreach (var ent in entities)
                        {
                            if (ent.team != localPlayer.team)
                            {
                                var angles = m.CalcAngles(localPlayer, ent);
                                    if (ent.xdist <= pixdist)
                                        m.aim(localPlayer, angles.X, angles.Y);
                                break;
                                
                            }
                        }
                    }
                }
               }

                box = variavel.ESPBOX;
                line = variavel.ESPLINE;
                aimb = variavel.Aimbot;
                amigo = variavel.ESPAmigo;
               // ammo = variavel.ammo;
                //health = variavel.health;
                esphealth = variavel.ESPVIDA;
                espname = variavel.ESPNAME;
               // if (ammo == true) 
             //   {
              //      m.mem.WriteBytes(ptr, 0x140, BitConverter.GetBytes(998));
             //   }

             //   if (health == true)
              //  {
              //      m.mem.WriteBytes(ptr, 0xEC, BitConverter.GetBytes(998));
              //  }

                Form1 f = this;
                f.Refresh();

                Thread.Sleep(20);
            }
        }
        
        public void balasin(bool ativado)
        {

            if (ativado == true)
            {
                // m.mem.WriteBytes(ptr, 0xE4, BitConverter.GetBytes(998));
                m.mem.WriteBytes(ptr, 0x140, BitConverter.GetBytes(998));
               // MessageBox.Show("oi");
                //  m.mem.WriteBytes(ptr,0xE4)

            }
            else
            {
                m.mem.WriteBytes(ptr, 0x140, BitConverter.GetBytes(20));
            }

        }


        public void vidain(bool ativado)
        {


            //while(ativado)
            //{

            //    m.mem.WriteBytes(ptr, 0xEC, BitConverter.GetBytes(4000));
            //    Thread.Sleep(100);
            //}
            //m.mem.WriteBytes(ptr, 0xEC, BitConverter.GetBytes(100));

            if (ativado == true)
            {
                // m.mem.WriteBytes(ptr, 0xE4, BitConverter.GetBytes(998));
                m.mem.WriteBytes(ptr, 0xEC, BitConverter.GetBytes(4000));
                // MessageBox.Show("oi");
                //  m.mem.WriteBytes(ptr,0xE4)

            }
            else
            {
                m.mem.WriteBytes(ptr, 0xEC, BitConverter.GetBytes(100));
            }

        }




        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen red = new Pen(Color.Red, 2);
            Pen green = new Pen(Color.Green, 2);
            Font fonte = new Font("Arial", 10, FontStyle.Bold);
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SingleBitPerPixelGridFit;

            Brush cor = Brushes.OrangeRed;
            Brush pincel = new SolidBrush(Color.Green);
            Brush pincelver = new SolidBrush(Color.Red);
            Brush azul = new SolidBrush(Color.Blue);

            Pen fovaim = new Pen(Color.DarkCyan, 2);

            g.DrawEllipse(fovaim, (Width / 2) - 50, (Height / 2) - 36, 100, 100);



            // var vida = m.mem.ReadBytes(ptr, 0xE4, 4);





            foreach (var ent in entities.ToList())
            {
                //var localz = ent.head;
                //localz.Z += 58;
                // g.Clear();
                var wtsHead = m.WorldToScreen(m.ReadMatrix(), ent.head, Width, Height);
                var wtsFeet = m.WorldToScreen(m.ReadMatrix(), ent.feet, Width, Height);
              

                if (wtsFeet.X > 0)
                {
                    if (localPlayer.team == ent.team)
                    {
                        var localvida = wtsHead;
                        localvida.X += 28;
                        if (amigo == true) {
                            if (line == true)
                            {
                                g.DrawLine(green, new Point(Width / 2, Height), wtsFeet);

                            }
                            // g.DrawLine(green, new Point(Width / 2, Height), wtsFeet);
                            if (box == true)
                            {
                                g.DrawRectangle(green, m.CalcRec(wtsFeet, wtsHead));
                                
                            }
                            if(esphealth == true)
                            {
                                if (ent.health > 80)
                                {
                                    g.DrawString(ent.health.ToString(), fonte, pincel, localvida);
                                }
                                else if (ent.health > 40 && ent.health < 80)
                                {
                                    g.DrawString(ent.health.ToString(), fonte, azul, localvida);
                                }
                                else
                                {
                                    g.DrawString(ent.health.ToString(), fonte, pincelver, localvida);
                                }
                            }
                            if(espname == true)
                            {
                                g.DrawString(ent.name, fonte, cor, wtsFeet);
                            }

                            }
                       
                    }
                    else
                    {
                      
                        var localvida = wtsHead;
                        localvida.X += 28;
                      //  j = ent.health;
                    //    MessageBox.Show("vida" + j);
                        //  local.Y += 40;
                        //line = true;
                        if (line == true)
                        {
                            g.DrawLine(red, new Point(Width / 2, Height), wtsFeet);
                            //  g.DrawString(ent.health.ToString(), fonte, pincel, wtsFeet);
                            
                        }
                       if (box == true)
                        {
                            g.DrawRectangle(red, m.CalcRec(wtsFeet, wtsHead));
                            // g.DrawString(ent.name, fonte, cor, wtsFeet);
                         
                        }

                       if(esphealth == true)
                        {
                            if (ent.health > 80)
                            {
                                g.DrawString(ent.health.ToString(), fonte, pincel, localvida);
                            }
                            else if (ent.health > 40 && ent.health < 80)
                            {
                                g.DrawString(ent.health.ToString(), fonte, azul, localvida);
                            }
                            else
                            {
                                g.DrawString(ent.health.ToString(), fonte, pincelver, localvida);
                            }
                        }
                       if(espname == true)
                        {
                            g.DrawString(ent.name, fonte, cor, wtsFeet);

                        }
                    }
                }
            }
        }
    }
}
