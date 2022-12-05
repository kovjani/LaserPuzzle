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
    internal class LaserGunBlock : Block
    {
        public LaserGunBlock()
        {
            base.BackgroundImage = global::LaserPuzzle.Properties.Resources.laser_gun;
            base.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
        }
    }
}
