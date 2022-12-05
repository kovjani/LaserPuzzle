using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LaserPuzzle
{
    internal static class LaserPuzzle
    {
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
                { "EMP", "LON", "EMP", "VEL", "EMP" },
                { "EMP", "EMP", "EMP", "VEL", "EMP" },
                { "EMP", "EMP", "EMP", "VEL", "EMP" },
                { "EMP", "EMP", "EMP", "LAG", "EMP" },
                { "EMP", "EMP", "EMP", "EMP", "EMP" },
                { "EMP", "EMP", "EMP", "EMP", "EMP" }
            };

            NewField(ref f, templateField);

            Application.Run(f);
        }
        static void NewField(ref Field f, string[,] templateField)
        {
            Object[,] blocksField = new Object[7, 5];

            CreateBlocks(templateField, ref blocksField);

            for (int i = 0; i < blocksField.GetLength(0); i++)
            {
                for (int j = 0; j < blocksField.GetLength(1); j++)
                {
                    f.Controls.Add((System.Windows.Forms.Control)blocksField[i, j]);
                }
            }
        }
        static void CreateBlocks(string[,] template, ref Object[,] blocksField)
        {
            Block btn;
            for (int i = 0; i < template.GetLength(0); i++)
            {
                for (int j = 0; j < template.GetLength(1); j++)
                {
                    switch (template[i, j])
                    {
                        //Empty
                        case "EMP":
                            btn = new EmptyBlock();
                            btn.Location = new System.Drawing.Point(20 + j * 56, 132 + i * 56);
                            btn.Name = "btn" + i + j;
                            blocksField[i, j] = btn;
                            break;
                        //Slash
                        case "SLA":
                            btn = new SlashBlock();
                            btn.Location = new System.Drawing.Point(20 + j * 56, 132 + i * 56);
                            btn.Name = "btn" + i + j;
                            blocksField[i, j] = btn;
                            break;
                        //Backslash
                        case "BAS":
                            btn = new BackslashBlock();
                            btn.Location = new System.Drawing.Point(20 + j * 56, 132 + i * 56);
                            btn.Name = "btn" + i + j;
                            blocksField[i, j] = btn;
                            break;
                        //Horizontal
                        case "HOR":
                            btn = new HorizontalBlock();
                            btn.Location = new System.Drawing.Point(20 + j * 56, 132 + i * 56);
                            btn.Name = "btn" + i + j;
                            blocksField[i, j] = btn;
                            break;
                        //Vertical
                        case "VER":
                            btn = new VerticalBlock();
                            btn.Location = new System.Drawing.Point(20 + j * 56, 132 + i * 56);
                            btn.Name = "btn" + i + j;
                            blocksField[i, j] = btn;
                            break;
                        //Horizontal Laser
                        case "HOL":
                            btn = new HorizontalLaserBlock();
                            btn.Location = new System.Drawing.Point(20 + j * 56, 132 + i * 56);
                            btn.Name = "btn" + i + j;
                            blocksField[i, j] = btn;
                            break;
                        //Vertical Laser
                        case "VEL":
                            btn = new VerticalLaserBlock();
                            btn.Location = new System.Drawing.Point(20 + j * 56, 132 + i * 56);
                            btn.Name = "btn" + i + j;
                            blocksField[i, j] = btn;
                            break;
                        //Laser Gun
                        case "LAG":
                            btn = new LaserGunBlock();
                            btn.Location = new System.Drawing.Point(20 + j * 56, 132 + i * 56);
                            btn.Name = "btn" + i + j;
                            blocksField[i, j] = btn;
                            break;
                        //Lightbulb On
                        case "LON":
                            btn = new LightOnBlock();
                            btn.Location = new System.Drawing.Point(20 + j * 56, 132 + i * 56);
                            btn.Name = "btn" + i + j;
                            blocksField[i, j] = btn;
                            break;
                        //Lightbulb Off
                        case "LOF":
                            btn = new LightOffBlock();
                            btn.Location = new System.Drawing.Point(20 + j * 56, 132 + i * 56);
                            btn.Name = "btn" + i + j;
                            blocksField[i, j] = btn;
                            break;
                    }
                }
            }
        }
    }
}
