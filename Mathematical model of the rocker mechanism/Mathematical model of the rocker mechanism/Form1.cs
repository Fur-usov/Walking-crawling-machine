using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mathematical_model_of_the_rocker_mechanism
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        const double PI = 3.14159265359;
        const double rad = PI / 180;
        int R = 3;
        int L = 5;
        int E = 8;
        int period = 11;

        static double Position_X(int R, int L, int E, double F)
        {
            double BC = Math.Sqrt(Math.Pow(E, 2) + Math.Pow(R, 2) - 2 * E * R * Math.Cos(PI / 2 + F)); // добавить квадрат BC
            double B = Math.Atan(R * Math.Cos(F) / E + R * Math.Sin(F));
            return Math.Cos(B) * (BC + L);
        }
        static double Position_Y(int R, int L, int E, double F)
        {
            double BC = Math.Sqrt(Math.Pow(E, 2) + Math.Pow(R, 2) - 2 * E * R * Math.Cos(PI / 2 + F)); // добавить квадрат BC
            double B = Math.Atan(R * Math.Cos(F) / E + R * Math.Sin(F));
            return Math.Sin(B) * (BC + L);
        }
        private void Form1_Paint_1(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            //g.TranslateTransform(g.Height/2, f.Width/2 );

            g.DrawRectangle(new Pen(Color.Blue), 100, 100, 200, 200);
            for (double i = 0.0; i <= 2 * PI; i += period * rad)
            {
                g.DrawLine(new Pen(Color.Black),
                    (int)Position_X(R, L, E, i), 
                    (int)Position_Y(R, L, E, i), 
                    (int)Position_X(R, L, E, i), 
                    (int)Position_Y(R, L, E, i));
            }
        }
    }
}
