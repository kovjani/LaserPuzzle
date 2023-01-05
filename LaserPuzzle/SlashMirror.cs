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
    internal class SlashMirror : Block
    {
        public SlashMirror()
        {
            base.BackgroundImage = Properties.Resources.slash;
            base.BackgroundImageLayout = ImageLayout.Stretch;
        }
        protected override void Clicked(object sender, EventArgs e)
        {
            SelectMirror();
        }
        protected override bool NextBlockAction(ref LaserType laserType, ref LaserDirection laserDirection, ref int i, ref int j, int length0, int length1)
        {
            //Change laser direction

            Block newBlock = new Block();
            laserType = laserType == LaserType.Horizontal ? LaserType.Vertical : LaserType.Horizontal;

            if (laserDirection == LaserDirection.Up)
            {
                laserDirection = LaserDirection.Right;
                if (++j >= length1) return true;
            }
            else if (laserDirection == LaserDirection.Down)
            {
                laserDirection = LaserDirection.Left;
                if (--j < 0) return true;
            }
            else if (laserDirection == LaserDirection.Left)
            {
                laserDirection = LaserDirection.Down;
                if (++i >= length0) return true;
            }
            else //Right
            {
                laserDirection = LaserDirection.Up;
                if (--i < 0) return true;
            }

            //Create a new laser
            if (laserType == LaserType.Horizontal)
            {
                newBlock = new HorizontalLaser();
            }
            else //Vertical
            {
                newBlock = new VerticalLaser();
            }

            Block nextBlock = LaserPuzzle.TemplateField[i, j];

            newBlock.Location = nextBlock.Location;

            LaserPuzzle.TemplateField[i, j] = newBlock;

            LaserPuzzle.f.Controls.Remove(nextBlock);
            LaserPuzzle.f.Controls.Add(newBlock);

            return false;
        }
    }
}
