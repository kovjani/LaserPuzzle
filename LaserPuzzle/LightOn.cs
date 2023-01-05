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
    internal class LightOn : Block
    {
        public LightOn()
        {
            base.BackgroundImage = Properties.Resources.lightbulb_on;
            base.BackgroundImageLayout = ImageLayout.Stretch;
            base.FlatAppearance.MouseDownBackColor = Color.FromArgb(25, 255, 255, 255);
            base.FlatAppearance.MouseOverBackColor = Color.FromArgb(25, 255, 255, 255);
            base.BackColor = Color.FromArgb(25, 255, 255, 255);
        }
    }
}
