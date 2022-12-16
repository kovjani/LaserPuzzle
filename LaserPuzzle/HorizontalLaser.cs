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
    internal class HorizontalLaser : Block
    {
        public HorizontalLaser()
        {
            base.BackgroundImage = Properties.Resources.horizontalal_laser;
            base.BackgroundImageLayout = ImageLayout.Stretch;
        }
        protected override void Clicked(object sender, EventArgs e)
        {
            if (SelectedMirror != null)
            {
                ChangeLocation();
                ChangeLaserDirection();
                FinishAction();
            }
        }
    }
}
