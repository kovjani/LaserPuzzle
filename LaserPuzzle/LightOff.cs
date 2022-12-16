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
    internal class LightOff : Block
    {
        public LightOff()
        {
            base.BackgroundImage = global::LaserPuzzle.Properties.Resources.lightbulb_off;
            base.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            base.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(25, 255, 255, 255);
            base.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(25, 255, 255, 255);
            base.BackColor = Color.FromArgb(25, 255, 255, 255);
        }
    }
}
