using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication8
{
    public partial class Form1 : Form
    {
        Bitmap bmp;
        Bitmap bmpBK;
        int x, y;
        int []xx=new int[10];
        int []yy=new int[10];

        int[] rr = new int[4];
        int[] gg = new int[4];
        int[] bb = new int[4];
        int p = 0;
        int mR = 0, mG = 0, mB = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Todos|*.*|Archivos JPEG|*.jpg|Archivos GIF|*.gif";
            openFileDialog1.FileName = "";
            openFileDialog1.ShowDialog();
            bmp = new Bitmap(openFileDialog1.FileName);
            bmpBK = bmp;
            pictureBox1.Image = bmp;
            
        }



        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            x = e.X;
            y = e.Y;
            p++;
            xx[p] = x;
            yy[p] = y;
            textBox7.Text = xx[1].ToString();
            textBox8.Text = yy[1].ToString();
            textBox9.Text = xx[2].ToString();
            textBox10.Text = yy[2].ToString();
            textBox11.Text = xx[3].ToString();
            textBox12.Text = yy[3].ToString();
           
            Color c = new Color();
            mR = 0; mG = 0; mB = 0;
            for (int i=x; i<x+10; i++)
                for (int j = y; j < y + 10; j++)
                {
                    c = bmp.GetPixel(i, j);
                    mR = mR + c.R;
                    mG = mG + c.G;
                    mB = mB + c.B;
                }

            mR = mR / 100;
            mG = mG / 100;
            mB = mB / 100;

            rr[p] = mR;
            gg[p] = mG;
            bb[p] = mB;
            
            textBox1.Text = rr[1].ToString();
            textBox2.Text = gg[1].ToString();
            textBox3.Text = bb[1].ToString();
            textBox15.Text = rr[2].ToString();
            textBox14.Text = gg[2].ToString();
            textBox13.Text = bb[2].ToString();
            textBox18.Text = rr[3].ToString();
            textBox17.Text = gg[3].ToString();
            textBox16.Text = bb[3].ToString();
            if (p == 3) {p = 0;}
        }

        void colorearXY(int a)
        {   Color cleido = new Color();
            cleido = bmp.GetPixel(xx[a], yy[a]);
            Bitmap bmp2 = new Bitmap(bmp.Width, bmp.Height);
            Color c = new Color();
            for (int i = 0; i < bmp.Width; i++)
                for (int j = 0; j < bmp.Height; j++)
                {
                    c = bmp.GetPixel(i, j);
                    if (((cleido.R - 10 <= c.R) && (c.R <= cleido.R + 10)) &&
                        ((cleido.G - 10 <= c.G) && (c.G <= cleido.G + 10)) &&
                        ((cleido.B - 10 <= c.B) && (c.B <= cleido.B + 10)))
                    {
                        switch (a)
                        {   case 1:
                                bmp2.SetPixel(i, j, Color.DarkOrchid);
                                break;
                            case 2:
                                bmp2.SetPixel(i, j, Color.Chartreuse);
                                break;
                            default:
                                bmp2.SetPixel(i, j, Color.Brown);
                                break;
                        } 
                    }
                    else
                    {
                        bmp2.SetPixel(i, j, Color.FromArgb(c.R, c.G, c.B));
                    }
                }
            pictureBox1.Image = bmp2;
            bmp = bmp2;
        }

        void colorearRGB(int a)
        {   int mRn = 0, mGn = 0, mBn = 0;
            Bitmap bmp2 = new Bitmap(bmp.Width, bmp.Height);
            Color c = new Color();
            for (int i = 0; i < bmp.Width - 10; i = i + 10)
                for (int j = 0; j < bmp.Height - 10; j = j + 10)
                {   for (int i2 = i; i2 < i + 10; i2++)
                        for (int j2 = j; j2 < j + 10; j2++)
                        {
                            c = bmp.GetPixel(i2, j2);
                            mRn = mRn + c.R;
                            mGn = mGn + c.G;
                            mBn = mBn + c.B;
                        }
                    mRn = mRn / 100;
                    mGn = mGn / 100;
                    mBn = mBn / 100;
                    if (((rr[a] - 10 <= mRn) && (mRn <= rr[a] + 10)) &&
                        ((gg[a] - 10 <= mGn) && (mGn <= gg[a] + 10)) &&
                        ((bb[a] - 10 <= mBn) && (mBn <= bb[a] + 10)))
                    {
                        for (int i2 = i; i2 < i + 10; i2++)
                            for (int j2 = j; j2 < j + 10; j2++)
                            {
                                switch (a)
                                {
                                    case 1:
                                        bmp2.SetPixel(i2, j2, Color.Yellow);
                                        break;
                                    case 2:
                                        bmp2.SetPixel(i2, j2, Color.Blue);
                                        break;
                                    default:
                                        bmp2.SetPixel(i2, j2, Color.Red);
                                        break;
                                } 
                            }
                    }
                    else
                    {
                        for (int i2 = i; i2 < i + 10; i2++)
                            for (int j2 = j; j2 < j + 10; j2++)
                            {
                                c = bmp.GetPixel(i2, j2);
                                bmp2.SetPixel(i2, j2, Color.FromArgb(c.R, c.G, c.B));
                            }
                    }
                }
            bmp = bmp2;
            pictureBox1.Image = bmp2;
        }       


        private void button7_Click(object sender, EventArgs e)
        {
            for (int i = 1; i < 4; i++)
            {
                colorearRGB(i);
            }

        }
        private void button8_Click(object sender, EventArgs e)
        {
                for (int i = 1; i < 4; i++)
                {
                    colorearXY(i);    
                }
        }

        private void button2_Click(object sender, EventArgs e)
        {   //limpiar
            pictureBox1.Image = bmpBK;
            bmp = bmpBK;
            textBox7.Text = "0";
            textBox8.Text = "0";
            textBox9.Text = "0";
            textBox10.Text = "0";
            textBox11.Text = "0";
            textBox12.Text = "0";
            textBox1.Text = "0";
            textBox2.Text = "0";
            textBox3.Text = "0";
            textBox15.Text = "0";
            textBox14.Text = "0";
            textBox13.Text = "0";
            textBox18.Text = "0";
            textBox17.Text = "0";
            textBox16.Text = "0";
            for (int i = 1; i < 4; i++)
            {
                xx[i] = 0; yy[i] = 0;
                rr[i] = 0; gg[i] = 0; bb[i] = 0;
            }
        }
    }
}
