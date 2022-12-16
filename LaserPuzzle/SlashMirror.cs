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
    internal class SlashMirror : Block
    {
        public SlashMirror()
        {
            base.BackgroundImage = Properties.Resources.slash;
            base.BackgroundImageLayout = ImageLayout.Stretch;
        }
        protected override void Clicked(object sender, EventArgs e)
        {
            SelectMirror();
        }

        //The ChangeLaserDirection method is called from a laser class, when this object is a mirror block.
        protected override void ChangeLaserDirection()
        {
            
            

        }
    }
}
