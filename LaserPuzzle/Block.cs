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
        public static Block SelectedMirror { get; set; }
        public Block() {
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
        //When SelectMirror method is called, this object is a mirror block.
        public void SelectMirror()
        {
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
        //When ChangeLocation method is called, this object is an empty or a laser block.
        public void ChangeLocation()
        {
            Point SelectedMirrorLocation = SelectedMirror.Location;
            SelectedMirror.Location = Location;
            Location = SelectedMirrorLocation;
        }
        //When ChangeLaserDirection method is called, this object is a laser block.
        public void ChangeLaserDirection()
        {
            //Remove laser block and create a new one.

            Block btn = new EmptyBlock();
            btn.Location = Location;
            LaserPuzzle.f.Controls.Add(btn);
            LaserPuzzle.f.Controls.Remove(this);
        }
        public void FinishAction()
        {
            SelectedMirror.FlatAppearance.BorderColor = Color.Gray;
            SelectedMirror.BackColor = Color.Transparent;
            SelectedMirror.FlatAppearance.MouseDownBackColor = Color.Transparent;
            SelectedMirror.FlatAppearance.MouseOverBackColor = Color.Transparent;
            SelectedMirror = null;
        }
        //The Clicked method is called when you click on an object.
        //The Clicked method calls another methods depends on the type of the clicked object.
        public virtual void Clicked(object sender, EventArgs e) { }
    }
}
