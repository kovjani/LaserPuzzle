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
    internal class Block : Button
    {
        protected static Block SelectedMirror { get; set; }
        public static LaserGun Gun { get; set; }
        public static Block Light { get; set; }
        public Block()
        {
            Cursor = Cursors.Hand;
            FlatAppearance.BorderColor = Color.Gray;
            FlatAppearance.MouseDownBackColor = Color.Transparent;
            FlatAppearance.MouseOverBackColor = Color.Transparent;
            FlatStyle = FlatStyle.Flat;
            Size = new Size(50, 50);
            TabIndex = 0;
            UseVisualStyleBackColor = false;
            //When you click on an object, the Clicked method is called.
            Click += Clicked;
        }

        protected void SelectMirror()
        {
            //This is a mirror block.

            //If you click on different mirror objects, the selection will be change.
            if (SelectedMirror != null)
            {
                SelectedMirror.BackColor = Color.Transparent;
                SelectedMirror.FlatAppearance.BorderColor = Color.Gray;
                SelectedMirror.FlatAppearance.MouseDownBackColor = Color.Transparent;
                SelectedMirror.FlatAppearance.MouseOverBackColor = Color.Transparent;
            }

            //When you click on a mirror, this object will be the selected mirror.
            SelectedMirror = this;

            //Change border and background color of this object, when it selected.
            BackColor = Color.FromArgb(50, 135, 206, 250);
            FlatAppearance.MouseDownBackColor = Color.FromArgb(50, 135, 206, 250);
            FlatAppearance.MouseOverBackColor = Color.FromArgb(50, 135, 206, 250);
            FlatAppearance.BorderColor = Color.LightSkyBlue;
        }

        protected void ChangeLocation()
        {
            //This is a laser or an empty block.

            Block newEmptyBlock = new Empty();
            Point SelectedMirrorLocation = SelectedMirror.Location;

            //Move the mirror to the place of the secondly selected block.
            //Location is a property of the secondly clicked object (this)
            //which is a laser ro an empty block.
            SelectedMirror.Location = Location;
            //Remove the seconly selected block (this).
            LaserPuzzle.f.Controls.Remove(this);

            //Move newEmptyBlock to the old place of the mirror.
            newEmptyBlock.Location = SelectedMirrorLocation;
            LaserPuzzle.f.Controls.Add(newEmptyBlock);

            //Change mirror locaton in the TemplateField array.
            Dictionary<char, int> thisIndex = IndexOf2dArray(this, LaserPuzzle.TemplateField);
            Dictionary<char, int> mirrorOldIndex = IndexOf2dArray(SelectedMirror, LaserPuzzle.TemplateField);

            LaserPuzzle.TemplateField[mirrorOldIndex['i'], mirrorOldIndex['j']] = newEmptyBlock;
            LaserPuzzle.TemplateField[thisIndex['i'], thisIndex['j']] = SelectedMirror;
        }

        protected void FinishAction()
        {
            SelectedMirror.FlatAppearance.BorderColor = Color.Gray;
            SelectedMirror.BackColor = Color.Transparent;
            SelectedMirror.FlatAppearance.MouseDownBackColor = Color.Transparent;
            SelectedMirror.FlatAppearance.MouseOverBackColor = Color.Transparent;
            SelectedMirror = null;

        }

        protected Dictionary<char, int> IndexOf2dArray<T>(T element, T[,] array)
        {

            int w = LaserPuzzle.TemplateField.GetLength(0); //width
            int h = LaserPuzzle.TemplateField.GetLength(1); //height

            for (int i = 0; i < w; i++)
            {
                for (int j = 0; j < h; j++)
                {
                    //The == operator is undefined for generic.
                    if (array[i, j].Equals(element))
                        return new Dictionary<char, int>
                        {
                            { 'i', i },
                            { 'j', j }
                        };
                }
            }

            return new Dictionary<char, int>
            {
                { 'i', -1 },
                { 'j', -1 }
            };
        }

        //The Clicked method is called when you click on an object
        //and it calls another methods depends on the type of the clicked object.
        protected virtual void Clicked(object sender, EventArgs e) { }

        //The ChangeLaserDirection method is overrided in mirror classes,
        //and the appropriate one will be called from a laser class.
        protected virtual void ChangeLaserDirection() { }
    }
}