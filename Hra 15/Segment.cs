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
    public partial class Segment : UserControl
    {
        public event Action<Segment> PositionChangeRequested;

        int cislo;

        public int Cislo {
            get {
                return cislo;
            }
        }
        public int IndexX {
            get {
                return this.Location.X / this.Width;
            }
        }
        public int IndexY {
            get {
                return this.Location.Y / this.Height;
            }
        }
        public Segment(int a):this() {
            cislo = a;
            label1.Text = cislo.ToString();


        }


        public Segment() {

            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e) {
            PositionChangeRequested?.Invoke(this);
        }
    }
}
