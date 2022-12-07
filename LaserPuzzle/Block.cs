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
        public Block() {
            base.Cursor = Cursors.Hand;
            base.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            base.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            base.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            base.FlatStyle = FlatStyle.Flat;
            base.Size = new System.Drawing.Size(50, 50);
            base.TabIndex = 0;
            base.UseVisualStyleBackColor = false;
            Click += LaserPuzzle.Clicked;
        }
        
    }
}
