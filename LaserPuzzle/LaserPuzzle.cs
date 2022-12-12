using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Media;

namespace LaserPuzzle
{
    internal static class LaserPuzzle
    {
        public static Field f = new Field();
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
            string[,] templateField = {
                { "EMP", "EMP", "VLR", "EMP", "BSM" },
                { "EMP", "LBF", "VLR", "EMP", "EMP" },
                { "EMP", "EMP", "VLR", "EMP", "EMP" },
                { "EMP", "EMP", "LGN", "EMP", "EMP" },
                { "EMP", "EMP", "EMP", "EMP", "EMP" },
                { "EMP", "EMP", "EMP", "EMP", "EMP" },
                { "EMP", "EMP", "EMP", "EMP", "EMP" },
            };

            //Create a Field using a given template.
            NewField(templateField);

            Application.Run(f);
        }
        static void NewField(string[,] templateField)
        {
            Block btn;
            for (int i = 0; i < templateField.GetLength(0); i++)
            {
                for (int j = 0; j < templateField.GetLength(1); j++)
                {
                    switch (templateField[i, j])
                    {
                        //Slash Mirror
                        case "SLM":
                            btn = new SlashMirrorBlock();
                            break;
                        //Backslash Mirror
                        case "BSM":
                            btn = new BackslashMirrorBlock();
                            break;
                        //Horizontal Laser
                        case "HLR":
                            btn = new HorizontalLaserBlock();
                            break;
                        //Vertical Laser
                        case "VLR":
                            btn = new VerticalLaserBlock();
                            break;
                        //Laser Gun
                        case "LGN":
                            btn = new LaserGunBlock();
                            break;
                        //Lightbulb On
                        case "LBN":
                            btn = new LightOnBlock();
                            break;
                        //Lightbulb Off
                        case "LBF":
                            btn = new LightOffBlock();
                            break;
                        //EMP := Empty
                        default:
                            btn = new EmptyBlock();
                            break;
                    }
                    btn.Location = new Point(20 + j * 56, 132 + i * 56);
                    btn.Name = "btn" + i + j;
                    f.Controls.Add(btn);    //Add block to the field
                }
            }
        }
    }
}
