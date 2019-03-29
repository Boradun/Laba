using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Laba
{
    static class Draw
    {
        static Bitmap bitmap = new Bitmap(800, 800);
        static PictureBox _pictureBox = new PictureBox() { Width = 800, Height = 800, Location = new Point(10, 10),BackgroundImage=bitmap };
        
        


        static internal PictureBox GetNewPictureBox(int Level)
        {
            DrawBackgroundImage(30);
            return _pictureBox;
        }

        private static void DrawBackgroundImage(int Level)
        {
            Graphics g = Graphics.FromImage(bitmap);
            Labirinth laba = new Labirinth(Level);


            g.FillRectangle(Brushes.White, 0, 0, 800, 800);
            g.DrawRectangle(new Pen(Color.Red, 1.0f), 0, 0, 799, 799);

            DrawGeneratedLabirinth(laba.GeneratedLabirint ,g ,Level);
        }

        private static void DrawGeneratedLabirinth(Labirinth.CellType[,] cells,Graphics graphics,int level)
        {
            float cellWeight = 800.0f / ((float)level*2.0f-1.0f);
            for (int x = 0; x < level * 2 - 1; x++)
            {
                for (int y = 0; y < level * 2 - 1; y++)
                {
                    if (cells[x, y] != Labirinth.CellType.visitedCell)
                        graphics.FillRectangle(Brushes.Black, (float)x * cellWeight, (float)y * cellWeight, cellWeight, cellWeight);
                }
            }
        }
    }
}
