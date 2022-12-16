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
    internal class BackslashMirror : Block
    {
        public BackslashMirror()
        {
            BackgroundImage = Properties.Resources.backslash;
            BackgroundImageLayout = ImageLayout.Stretch;
        }
        protected override void Clicked(object sender, EventArgs e) 
        {
            SelectMirror();
        }
    }
}