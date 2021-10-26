using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hra_15
{
    public partial class Form1 : Form
    {
        Segment[ , ] segments = new Segment[3, 3];
        Random rand = new Random();

        public Form1() {
            InitializeComponent();

            GenerateSegments();
            ShuffleSegments();
        }

        private void GenerateSegments() 
        {
            for(int i = 0; i < 3; i++) {
                for(int j = 0; j < 3; j++) {
                    if (i + j * 3 != 0) {
                        Segment segment = new Segment(i + j * 3);
                        segments[i, j] = segment;
                        this.Controls.Add(segment);
                    }
                }
            }
            this.Width = segments.GetLength(0) * 200 + 15;
            this.Height = segments.GetLength(1) * 200 + 40;
        }

        private void ShuffleSegments() 
        {
            int x = 0;
            int y = 0;
            for(int i = 0; i < 2; i++) {
                int smer = GenerateDirection(x, y);
                int newx = x;
                int newy = y;
                ChangeXY(smer, ref newx, ref newy);
                segments[x, y] = segments[newx, newy];
                segments[newx, newy] = null;
                x = newx;
                y = newy;
            }
            for (int i = 0; i < 3; i++) {
                for (int j = 0; j < 3; j++) {
                    if (segments[i, j] != null)
                    segments[i, j].Location = new Point(i * segments[i, j].Width, j * segments[i, j].Height);
                }
            }

        }

        private void ChangeXY(int smer, ref int a, ref int b) {
            
            if (smer == 0)
                a += 1;
            if (smer == 1)
                a -= 1;
            if (smer == 2)
                b += 1;
            if (smer == 3)
                b -= 1;
        }

        private int GenerateDirection(int x2, int y2) {

            int x = x2;
            int y = y2;
            int smer = rand.Next(0, 3);

            ChangeXY(smer, ref x, ref y);

            if (x < 0 || x > 2 || y < 0 || y > 2)
                return GenerateDirection(x2, y2);
            else 
                return smer;
        }

    }
}
