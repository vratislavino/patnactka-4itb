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
        Segment[,] segments = new Segment[3, 3];
        Random rand = new Random();

        int size = 3;

        public Form1() {
            InitializeComponent();

        }

    }
}
