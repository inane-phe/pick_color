﻿using System;
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
        static Random C = new Random();
        static Random S = new Random();
        Random ans = new Random();
        int r = R.Next(0, 255);
        int g = G.Next(0, 255);
        int b = B.Next(0, 255);
        int c = 50,cMax=30,cMin=0;
        int s= S.Next(0,100);
        int m = 0, n = 2, limit = 32, sorce = 0, time = 500, maxS = 0, ;
        Button[] buttons = new Button[4];
        Button[] buttons3 = new Button[9];
        public Form1()
        {
            InitializeComponent();
        } 
        private void Form1_Load(object sender, EventArgs e)
        {
            this.Width = 700;
            this.Height = 600;
            int needCheck = ans.Next();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    buttons[i * n + j] = creatButton(i, j);
                }
            }
            this.Controls.AddRange(buttons);
        }
        private Button creatButton(int i, int j)
        {
            Button temp = new Button();
            temp.Name = "button" + (i * 2 + j);
            temp.Text = "";
            temp.ForeColor = Color.FromArgb(Math.Abs(r-255),g, b); ;
            temp.Size = new Size(400 / n, 400 / n);
            if (s >= 33 && s <= 66)
            {
                r -= r / 3;
                temp.BackColor = Color.FromArgb(r, g, b);
     
            }
            else if (s > 66)
            {
                g -= g / 3;
                temp.BackColor = Color.FromArgb(r, g, b);
            }
            else
            {
                b -= b / 3;
                temp.BackColor = Color.FromArgb(r, g, b);
            }
            
            temp.Location = new Point(250 + j * (400 / n), i * (400 / n));
            temp.Click += new EventHandler(btn_Click);
            return temp;
        }
        void btn_Click(object sender, EventArgs e)
        {
            if (sender.Equals(buttons[m]))
            {
                removeButton();
                if (n < limit)
                {
                    n += 1;
                }
                sorce += 1;
                time  += 1;
                label5.Text = "目前得分" + sorce;
                buttons = new Button[n * n];
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        buttons[i * n + j] = creatButton(i, j);
                        if (checkBox1.Checked)
                        {
                            buttons[i * n + j].Text = i + "-" + j;
                        }
                    }

                }
                start_Click(sender, e);
                this.Controls.AddRange(buttons);
            }
            else
            {
                sorce -= 1;
                time -= 1;
                label5.Text = "目前得分" + sorce;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (time > 0 && time < 500)
            {
                time -= 1;
                label7.Text = "剩餘時間為" + time / 60 + "分" + time % 60 + "秒";
            }
            else
            {
                timer1.Enabled = false;
                MessageBox.Show("計時結束囉，得分為" + sorce);
                if (sorce > maxS)
                {
                    maxS = sorce;
                    label8.Text = "最佳分數為" + maxS;
                }
                reset_Click(sender, e);
            }
        }
        private void removeButton()
        {
            for (int i = 0; i < n * n; i++)
            {
                this.Controls.Remove(buttons[i]);
            }
            if (s >= 33 && s <=66)
            {
                r = R.Next(0, 255);
                g = G.Next(0, 255);
                b = B.Next(0, 255);
                r -= r/3;
            }
            else if (s>66)
            {
                r = R.Next(0, 255);
                g = G.Next(0, 255);
                b = B.Next(0, 255);
                g -= g/3;
            }
            else
            {
                r = R.Next(0, 255);
                g = G.Next(0, 255);
                b = B.Next(0, 255);
                b -= b/3;
            }
        }
        private void start_Click(object sender, EventArgs e)
        {
            if (time < 500 && time > 0)
            {
                timer1.Enabled = true;
            }
            else
            {
                label6.Text = "不計時";
            }
            m = ans.Next(0, n * n);
            start.Enabled = false;
            reset.Enabled = true;
            c = C.Next(cMin, cMax);
            if ((b + c) > 255 || s<c)
            {
                if (n % 3 == 0)
                    buttons[m].BackColor = Color.FromArgb(r - c, g, b);
                else if (n % 3 == 1)
                    buttons[m].BackColor = Color.FromArgb(r, g - c, b);
                else
                    buttons[m].BackColor = Color.FromArgb(r, g, b - c);
            }
            else
            {
                if (n % 3 == 0)
                    buttons[m].BackColor = Color.FromArgb(r + c, g, b);
                else if (n % 3 == 1)
                    buttons[m].BackColor = Color.FromArgb(r, g + c, b);
                else
                    buttons[m].BackColor = Color.FromArgb(r, g, b + c);
            }
            if (checkBox1.Checked)
                label4.Text = "目前答案" + m / n + "-" + m % n + "色差為" + c;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            cMax = trackBar1.Value;
            if (cMax == 0)
            {
                MessageBox.Show("打咩٩(๑`^´๑)۶");
            }
            else
            {
                if (cMax <= cMin)
                {
                    cMin = cMax - 1;
                    trackBar2.Value = cMin;
                    label3.Text = "最小色差" + cMin.ToString();
                }
                label2.Text = "最大色差" + cMax.ToString();
            }
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            cMin = trackBar2.Value;
            if (cMin == 50)
            {
                MessageBox.Show("打咩٩(๑`^´๑)۶");
            }
            else
            {
                if (cMin >= cMax)
                {
                    cMax = cMin + 1;
                    trackBar1.Value = cMax;
                    label2.Text = "最大色差" + cMax.ToString();
                }
                label3.Text = "最小色差" + cMin.ToString();
            }
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            time = trackBar3.Value * 5;
            if (time == 100 || time == 0)
            {
                label6.Text = "不計時";
            }
            else
            {
                label6.Text = "倒數計時設定為" + time / 60 + "分" + time % 60 + "秒";
                label7.Text = "剩餘時間為" + time / 60 + "分" + time % 60 + "秒";
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                for (int i = 0; i < n * n; i++)
                {
                    buttons[i].ForeColor = Color.White;
                    buttons[i].Text = i / n + "-" + i % n;

                }
                label4.Text = "目前答案" + m / n + "-" + m % n +"色差為"+c;
            }
            else
            {
                for (int i = 0; i < n * n; i++)
                {
                    buttons[i].Text = "";
                    buttons[i].ForeColor = Color.White;
                }
                label4.Text = "作弊是不可能作弊的 這輩子都(ry";
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Length != 0)
                limit = Int32.Parse(textBox1.Text);
        }
        private void reset_Click(object sender, EventArgs e)
        {
            start.Enabled = true;
            reset.Enabled = false;
            timer1.Enabled = false;
            removeButton();
            n = 2;
            sorce = 0;
            time = trackBar2.Value * 5;
            if (time == 500 || time == 0)
            {
                label6.Text = "不計時";
            }
            else
            {
                label6.Text = "倒數計時設定為" + time / 60 + "分" + time % 60 + "秒";
                label7.Text = "剩餘時間為" + time / 60 + "分" + time % 60 + "秒";
            }
            buttons = new Button[n * n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    buttons[i * n + j] = creatButton(i, j);
                    if (checkBox1.Checked)
                    {
                        buttons[i * n + j].ForeColor = Color.White;
                        buttons[i * n + j].Text = i + "-" + j;
                    }
                }

            }
            this.Controls.AddRange(buttons);
        }
    }

}