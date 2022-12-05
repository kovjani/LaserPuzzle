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
    internal class VerticalBlock : Block
    {
        public VerticalBlock()
        {
            base.BackgroundImage = global::LaserPuzzle.Properties.Resources.vertical_line;
            base.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
        }
    }
}
