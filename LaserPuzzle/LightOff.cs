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
            base.BackgroundImage = Properties.Resources.lightbulb_off;
            base.BackgroundImageLayout = ImageLayout.Stretch;
            base.FlatAppearance.MouseDownBackColor = Color.FromArgb(25, 255, 255, 255);
            base.FlatAppearance.MouseOverBackColor = Color.FromArgb(25, 255, 255, 255);
            base.BackColor = Color.FromArgb(25, 255, 255, 255);
        }

        protected override bool NextBlockAction(ref LaserType laserType, ref LaserDirection laserDirection, ref int i, ref int j, int length0, int length1)
        {
            Block newBlock = new LightOn();
            Light = newBlock;

            Block nextBlock = LaserPuzzle.TemplateField[i, j];

            newBlock.Location = nextBlock.Location;

            LaserPuzzle.TemplateField[i, j] = newBlock;

            LaserPuzzle.f.Controls.Remove(nextBlock);
            LaserPuzzle.f.Controls.Add(newBlock);

            Form finish = new Congratulations();
            LaserPuzzle.f.Enabled = false;
            finish.Show(LaserPuzzle.f);

            return true; //no more lasers
        }
    }
}
