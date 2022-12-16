using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LaserPuzzle
{
    internal class Empty : Block
    {
        public Empty() { 
            base.BackColor = Color.Transparent;
        }
        protected override void Clicked(object sender, EventArgs e)
        {
            if (SelectedMirror != null)
            {
                ChangeLocation();
                FinishAction();
            }
        }
    }
}
