using System;
using System.Collections.Generic;
using System.Threading;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba
{
    class Labirinth
    {
        CellType[,] _labirinth;

        internal Labirinth(int Level)
        {
            _labirinth = new CellType[Level*2-1, Level*2-1];
            InitializeLabirinth(Level);
            GenerateWays(Level);
        }
        
        internal CellType[,] GeneratedLabirint
        {
            get
            {
                return _labirinth;
            }
        }


        private void InitializeLabirinth(int Level)
        {
            for (int x = 0; x < Level * 2 - 1; x++)
            {
                for (int y = 0; y < Level * 2 - 1; y++)
                {
                    if (x % 2 == 0 && y % 2 == 0)
                    {
                        _labirinth[x, y] = CellType.voidCell;
                    }
                    else
                    {
                        _labirinth[x, y] = CellType.wall;
                    }
                }
            }
        }
        private void GenerateWays(int Level)
        {
            int Lenght = Level * 2 - 1;
            Stack<Point> cells = new Stack<Point>();
            _labirinth[0, 0] = CellType.visitedCell;
            cells.Push(new Point(0,0));
            while (cells.Count > 0)
            {
                Point currentCell = cells.Peek();
                Point nextCell = NextRandomCell(currentCell,Lenght);
                if (nextCell != null)
                {
                    cells.Push(nextCell);
                    _labirinth[nextCell.X, nextCell.Y] = CellType.visitedCell;
                    _labirinth[(nextCell.X - currentCell.X  ) / 2 + currentCell.X , (nextCell.Y -currentCell.Y) / 2 + currentCell.Y ] = CellType.visitedCell;
                }
                else
                {
                    cells.Pop();
                }
            }
        }
        private Point NextRandomCell(Point cell,int lenght)
        {
            List<Point> points = new List<Point>();
            if (cell.X > 1 && _labirinth[cell.X - 2,cell.Y] == CellType.voidCell)
            {
                points.Add(new Point(cell.X - 2, cell.Y));
            }
            if (cell.X < lenght-1 && _labirinth[cell.X + 2, cell.Y] == CellType.voidCell)
            {
                points.Add(new Point(cell.X + 2, cell.Y));
            }
            if (cell.Y > 1 && _labirinth[cell.X, cell.Y - 2] == CellType.voidCell)
            {
                points.Add(new Point(cell.X , cell.Y - 2));
            }
            if (cell.Y < lenght-1 && _labirinth[cell.X , cell.Y+2] == CellType.voidCell)
            {
                points.Add(new Point(cell.X , cell.Y+2));
            }
            if (points.Count != 0)
            {
                Thread.Sleep(10);
                Random random = new Random();
                return points[random.Next(points.Count)];
            }
            else
            {
                return null;
            }
        }

        private class Point
        {
            internal Point(int x, int y)
            {
                this.X = x;
                this.Y = y;
            }

            public int X { get ; set; }
            public int Y { get; set; }
        }
        internal enum CellType
        {
            voidCell,
            wall,
            visitedCell
        }

    }
}
