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
    internal class EmptyBlock : Block
    {
        public EmptyBlock() { 
            base.BackColor = Color.Transparent;
        }
        public override void Clicked(object sender, EventArgs e)
        {
            if (SelectedMirror != null)
            {
                ChangeLocation();
                FinishAction();
            }
        }
    }
}
