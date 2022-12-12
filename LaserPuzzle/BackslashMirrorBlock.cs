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
    internal class BackslashMirrorBlock : Block
    {
        public BackslashMirrorBlock()
        {
            BackgroundImage = Properties.Resources.backslash;
            BackgroundImageLayout = ImageLayout.Stretch;
        }
        public override void Clicked(object sender, EventArgs e) 
        {
            SelectMirror();
        }
    }
}