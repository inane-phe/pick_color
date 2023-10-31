using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PickColor
{
    public partial class Form1 : Form
    {
        static Random R = new Random();
        static Random G = new Random();
        static Random B = new Random();
        Random ans = new Random();
        int r = R.Next(0, 255);
        int g = G.Next(0, 255);
        int b = B.Next(0, 255);
        int c = 50;

        int m = 0;
        int n = 2;
        int n3 = 3;
        int number = 2;

        Button[] buttons = new Button[4];
        Button[] buttons3 = new Button[9];
        public Form1()
        {
            InitializeComponent();
        }
        void btn_Click(object sender, EventArgs e)
        {

        }
        void btn_TClick(object sender, EventArgs e)
        {
            createBtn();
            if (number == 3)
            {
                m = ans.Next(0, number);
                if ((b + c) > 255)
                {
                    buttons3[m].BackColor = Color.FromArgb(r, g, b - c);
                }
                else
                {
                    buttons3[m].BackColor = Color.FromArgb(r, g, b + c);
                }
                buttons3[m].Click += new EventHandler(btn_TClick);
            }
        }
        void createBtn()
        {
            r = R.Next(0, 255);
            g = G.Next(0, 255);
            b = B.Next(0, 255);
            for (int i = 0; i < 4; i++)
            {
                this.Controls.Remove(buttons[i]);//移除                 
            }
            for (int i = 0; i < n3; i++)
            {
                for (int j = 0; j < n3; j++)
                {
                    buttons3[i * n3 + j] = new Button();
                    buttons3[i * n3 + j].Name = "button" + (i * n3 + j);
                    buttons3[i * n3 + j].Text = "";
                    buttons3[i * n3 + j].Size = new Size(400 / n3, 400 / n3);
                    buttons3[i * n3 + j].BackColor = Color.FromArgb(r, g, b);
                    buttons3[i * n3 + j].Location = new Point(100 + j * (400 / n3), i * (400 / n3));
                    buttons3[i * n3 + j].Click += new EventHandler(btn_TClick);
                }
            }
            this.Controls.AddRange(buttons3);
            c = 90;
            number++;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.Width = 600;
            this.Height = 500;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    buttons[i * n + j] = new Button();
                    buttons[i * n + j].Name = "button" + (i * 2 + j);
                    buttons[i * n + j].Text = "";
                    buttons[i * n + j].Size = new Size(400 / n, 400 / n);
                    buttons[i * n + j].BackColor = Color.YellowGreen;
                    buttons[i * n + j].Location = new Point(100 + j * (400 / n), i * (400 / n));
                    buttons[i * n + j].Click += new EventHandler(btn_Click);
                }
            }
            this.Controls.AddRange(buttons);
        }
        private void start_Click(object sender, EventArgs e)
        {
            m = ans.Next(0, number);
            if ((b+c)>255)
            {
                buttons[m].BackColor = Color.FromArgb(r, g, b - c);
            }
            else
            {
                buttons[m].BackColor = Color.FromArgb(r, g, b + c);
            }
            buttons[m].Click += new EventHandler(btn_TClick);
        }
    }

}