using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            over.Visible = false;
            floor.Visible = false;
            
        }

        

        int collectedCoins = 0;
        int gamespeed = 4;
        int hearts = 3;

        private void timer1_Tick(object sender, EventArgs e)
        {
            moveLine(gamespeed);
            enemy(gamespeed);
            gameOver();
        }

        void moveLine(int speed)
        {
            if (pictureBox1.Top >= 500)
            {  pictureBox1.Top = 0; }
            else
            { pictureBox1.Top += speed; }

            if (pictureBox2.Top >= 500)
            { pictureBox2.Top = 0; }
            else
            {pictureBox2.Top += speed;}

            if (pictureBox3.Top >= 500)
            { pictureBox3.Top = 0; }
            else
            { pictureBox3.Top += speed; }

            if (pictureBox4.Top >= 500)
            { pictureBox4.Top = 0; }
            else
            { pictureBox4.Top += speed; }

            if (pictureBox5.Top >= 500)
            { pictureBox5.Top = 0; }
            else
            { pictureBox5.Top += speed; }
        }

        Random r = new Random();
        int x, y;

        void enemy(int speed) {

            if (pictureBox6.Top >= 500)
            {
                x = r.Next(0, 200);
                pictureBox6.Location = new Point(x, 0);
             }
            else
            { pictureBox6.Top += speed; }


            if (pictureBox7.Top >= 500)
            {
                x = r.Next(0, 350);
                pictureBox7.Location = new Point(x, 0);
            }
            else
            { pictureBox7.Top += speed; }

            if (pictureBox8.Top >= 500)
            {
                x = r.Next(200, 350);
                pictureBox8.Location = new Point(x, 0);
            }
            else
            { pictureBox8.Top += speed; }

        }

        
        private void timer2_Tick(object sender, EventArgs e)
        {
            if (MousePosition.X > 10 && MousePosition.X < 340)
            {
                var screen = Screen.FromPoint(Location);
                vlad.Left = MousePosition.X;
                label1.Text = vlad.Left.ToString();
                label2.Text = MousePosition.X.ToString();
                coinsCollection();
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        void coinsCollection()
        {
            if (vlad.Bounds.IntersectsWith(pictureBox6.Bounds))
            {
                collectedCoins++;
                coins.Text = "Coins:" + collectedCoins.ToString();
                x = r.Next(50, 300);
                pictureBox6.Location = new Point(x, 0);
                gamespeed += 1;
            }

            if (vlad.Bounds.IntersectsWith(pictureBox7.Bounds))
            {
                collectedCoins++;
                coins.Text = "Alina:" + collectedCoins.ToString();
                x = r.Next(50, 300);
                pictureBox7.Location = new Point(x, 0);
                gamespeed += 0;
            }

            if (vlad.Bounds.IntersectsWith(pictureBox8.Bounds))
            {
                collectedCoins++;
                coins.Text = "Alina:" + collectedCoins.ToString();
                x = r.Next(50, 300);
                pictureBox8.Location = new Point(x, 0);
                gamespeed += 1;
            }
            coins.Text = "Alina:" + collectedCoins.ToString();

        }


        void gameOver()
        {

            if (hearts < 1)
            {
                over.Visible = true;
                timer1.Enabled = false;
            }
            if (floor.Bounds.IntersectsWith(pictureBox6.Bounds))
            {
                hearts--;
                lives.Text = "Lives:" + hearts.ToString();
                x = r.Next(50, 300);
                pictureBox6.Location = new Point(x, 0);
            }

            if (floor.Bounds.IntersectsWith(pictureBox7.Bounds))
            {
                hearts--;
                lives.Text = "Lives:" + hearts.ToString();
                x = r.Next(50, 300);
                pictureBox7.Location = new Point(x, 0);
            }

            if (floor.Bounds.IntersectsWith(pictureBox8.Bounds))
            {
                hearts--;
                lives.Text = "Lives:"+hearts.ToString();
                x = r.Next(50, 300);
                pictureBox8.Location = new Point(x, 0);
            }

        
            lives.Text = "Lives:" + hearts.ToString();
        }
        
       
    }
}
