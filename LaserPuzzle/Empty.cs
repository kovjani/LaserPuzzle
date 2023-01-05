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
    internal class Empty : Block
    {
        public Empty() { 
            base.BackColor = Color.Transparent;
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
        protected override bool NextBlockAction(ref LaserType laserType, ref LaserDirection laserDirection, ref int i, ref int j, int length0, int length1)
        {
            //Create a new laser

            Block newBlock = new Block();
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
