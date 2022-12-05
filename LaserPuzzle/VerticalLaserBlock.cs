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
    internal class VerticalLaserBlock : Block
    {
        public VerticalLaserBlock()
        {
            base.BackgroundImage = global::LaserPuzzle.Properties.Resources.vertical_laser;
            base.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
        }
    }
}
