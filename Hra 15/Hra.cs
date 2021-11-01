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
    public abstract partial class Hra : Form
    {
        protected Segment[,] segments;
        Random rand = new Random();

        protected int size;

        public Hra(int size, List<Image> images) {
            InitializeComponent();
            this.size = size;
            GenerateSegments();
            ShuffleSegments();

            BindImages(images);
        }


        private void GenerateSegments() {
            segments = new Segment[size,size];
            for (int i = 0; i < size; i++) {
                for (int j = 0; j < size; j++) {
                    if (i + j * size != 0) {
                        Segment segment = new Segment(i + j * size);
                        segments[i, j] = segment;
                        segment.PositionChangeRequested += SwapWithEmpty;
                        this.Controls.Add(segment);
                    }
                }
            }
            this.Width = segments.GetLength(0) * 200 + 15;
            this.Height = segments.GetLength(1) * 200 + 40;
        }

        private void SwapWithEmpty(Segment obj) {
            int x = obj.IndexX;
            int y = obj.IndexY;
            if (x + 1 < size && segments[x + 1, y] == null) {
                SwapSegWithNull(obj, x + 1, y);
                CheckForWin();
                return;
            }
            if (x - 1 >= 0 && segments[x - 1, y] == null) {


                SwapSegWithNull(obj, x - 1, y);
                CheckForWin();
                return;
            }
            if (y + 1 < size && segments[x, y + 1] == null) {

                SwapSegWithNull(obj, x, y + 1);
                CheckForWin();
                return;
            }
            if (y - 1 >= 0 && segments[x, y - 1] == null) {
                SwapSegWithNull(obj, x, y - 1);
                CheckForWin();
            }


        }

        protected abstract void CheckForWin();

        private void SwapSegWithNull(Segment s, int x, int y) {
            segments[s.IndexX, s.IndexY] = null;
            segments[x, y] = s;
            s.Location = new Point(x * s.Width, y * s.Height);

        }

        private void ShuffleSegments() {
            int x = 0;
            int y = 0;
            for (int i = 0; i < size - 1; i++) {
                int smer = GenerateDirection(x, y);
                int newx = x;
                int newy = y;
                ChangeXY(smer, ref newx, ref newy);
                segments[x, y] = segments[newx, newy];
                segments[newx, newy] = null;
                x = newx;
                y = newy;
            }
            for (int i = 0; i < size; i++) {
                for (int j = 0; j < size; j++) {
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

            if (x < 0 || x > size-1 || y < 0 || y > size-1)
                return GenerateDirection(x2, y2);
            else
                return smer;
        }
    }
}
