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
    internal class VerticalLaser : Block
    {
        public VerticalLaser()
        {
            base.BackgroundImage = Properties.Resources.vertical_laser;
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

        protected override void ChangeLaserDirection()
        {
            Block from, to;
            Dictionary<char, int> mirrorIndex = IndexOf2dArray(SelectedMirror, LaserPuzzle.TemplateField);
            int mi = mirrorIndex['i'];
            int mj = mirrorIndex['j'];

            Console.WriteLine("{0}, {1}", mi, mj);
            if (mi == -1 || mj == -1) return;

            //Reflect laser from under the mirror to the left of the mirror.
            // 
            // to mirror
            //     from
            from = LaserPuzzle.TemplateField[mi + 1, mj];
            to = LaserPuzzle.TemplateField[mi, mj - 1];
            if (to.GetType().Equals(typeof(Empty)) && (from.GetType().Equals(typeof(VerticalLaser)) || from.GetType().Equals(typeof(LaserGun))))
            {
                Block newLaser = new HorizontalLaser();
                newLaser.Location = to.Location;

                LaserPuzzle.f.Controls.Remove(to);
                LaserPuzzle.f.Controls.Add(newLaser);
                LaserPuzzle.TemplateField[mi, mj - 1] = newLaser;
            }
        }
    }
}
