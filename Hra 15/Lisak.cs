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
    public partial class Lisak : Hra
    {
        public Lisak(int size) : base(size) {
            
        }


        protected override void CheckForWin() {
            if (segments[1, 1] != null) return;
            int value = 1;
            for (int y = 0; y < size; y++) {
                for (int x = 0; x < size; x++) {
                    if (y == 1 && x == 1) continue;
                    if (segments[x, y].Cislo != value) {
                        return;
                    }
                    value++;
                }
            }
            MessageBox.Show("WIN");
        }
    }
}
