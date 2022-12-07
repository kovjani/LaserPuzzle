using System;
using System.Drawing;
using System.Windows.Forms;

namespace LaserPuzzle
{
    internal static class LaserPuzzle
    {
        public static Block firstClicked = null;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Field f = new Field();

            //Level 1
            string[,] templateField = {
                { "EMP", "EMP", "EMP", "VEL", "BAS" },
                { "EMP", "LOF", "EMP", "VEL", "EMP" },
                { "EMP", "EMP", "EMP", "VEL", "EMP" },
                { "EMP", "EMP", "EMP", "VEL", "EMP" },
                { "EMP", "EMP", "EMP", "LAG", "EMP" },
                { "EMP", "EMP", "EMP", "EMP", "EMP" },
                { "EMP", "EMP", "EMP", "EMP", "EMP" }
            };

            NewField(ref f, templateField);

            Application.Run(f);
        }
        static public void Clicked(object sender, EventArgs e)
        {
            Block clickedBlock = (Block)sender;
            Type clickedType = clickedBlock.GetType();

            if (firstClicked == null)
            {
                if (clickedBlock.GetType().Equals(typeof(BackslashBlock)))
                {
                    firstClicked = clickedBlock;
                    firstClicked.FlatAppearance.BorderColor = Color.LightSkyBlue;
                }
            }
            else if (clickedType.Equals(typeof(EmptyBlock)))
            {
                Block secondClicked = clickedBlock;
                Point firstLocation = firstClicked.Location;

                firstClicked.Location = secondClicked.Location;
                secondClicked.Location = firstLocation;

                firstClicked.FlatAppearance.BorderColor = Color.Gray;
                firstClicked = null;
            }
        }
        static void NewField(ref Field f, string[,] templateField)
        {
            Block btn;
            for (int i = 0; i < templateField.GetLength(0); i++)
            {
                for (int j = 0; j < templateField.GetLength(1); j++)
                {
                    switch (templateField[i, j])
                    {
                        //Slash
                        case "SLA":
                            btn = new SlashBlock();
                            break;
                        //Backslash
                        case "BAS":
                            btn = new BackslashBlock();
                            break;
                        //Horizontal
                        case "HOR":
                            btn = new HorizontalBlock();
                            break;
                        //Vertical
                        case "VER":
                            btn = new VerticalBlock();
                            break;
                        //Horizontal Laser
                        case "HOL":
                            btn = new HorizontalLaserBlock();
                            break;
                        //Vertical Laser
                        case "VEL":
                            btn = new VerticalLaserBlock();
                            break;
                        //Laser Gun
                        case "LAG":
                            btn = new LaserGunBlock();
                            break;
                        //Lightbulb On
                        case "LON":
                            btn = new LightOnBlock();
                            break;
                        //Lightbulb Off
                        case "LOF":
                            btn = new LightOffBlock();
                            break;
                        //Empty
                        default:
                            btn = new EmptyBlock();
                            break;
                    }
                    btn.Location = new System.Drawing.Point(20 + j * 56, 132 + i * 56);
                    btn.Name = "btn" + i + j;
                    f.Controls.Add(btn);    //Add block to the field
                }
            }
        }
    }
}
