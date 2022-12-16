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
    internal class LaserGun : Block
    {
        public LaserGun()
        {
            base.BackgroundImage = Properties.Resources.laser_gun;
            base.BackgroundImageLayout = ImageLayout.Stretch;
        }
    }
}
