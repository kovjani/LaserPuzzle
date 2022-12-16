using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Media;
using System.Collections.Generic;

namespace LaserPuzzle
{
    internal static class LaserPuzzle
    {
        public static Field f = new Field();
        public static Block[,] TemplateField { get; set; }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);

            //Create templates of levels.

            //Level 1
            Block.Gun = new LaserGun();
            Block.Light = new LightOff();
            TemplateField = new Block[,] {
                { new Empty(), new Empty(),    new Empty(), new VerticalLaser(), new BackslashMirror() },
                { new Empty(), Block.Light,    new Empty(), new VerticalLaser(), new Empty() },
                { new Empty(), new Empty(),    new Empty(), new VerticalLaser(), new Empty() },
                { new Empty(), new Empty(),    new Empty(), new VerticalLaser(), new Empty() },
                { new Empty(), new Empty(),    new Empty(), Block.Gun,           new Empty() },
                { new Empty(), new Empty(),    new Empty(), new Empty(),         new Empty() },
                { new Empty(), new Empty(),    new Empty(), new Empty(),         new Empty() }
            };

            //Create the Field using TemplateField;
            NewField();

            Application.Run(f);
        }
        static void NewField()
        {
            for (int i = 0; i < TemplateField.GetLength(0); i++)
            {
                for (int j = 0; j < TemplateField.GetLength(1); j++)
                {
                    TemplateField[i,j].Location = new Point(20 + j * 56, 132 + i * 56);

                    //Add block to the field
                    f.Controls.Add(TemplateField[i, j]); 
                }
            }
        }
    }
}
