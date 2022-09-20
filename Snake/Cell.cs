using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    internal class Cell
    {
        public int Width { get { return 10; } }
        public int Height { get { return 10; } }
        public int X { get; set; }
        public int Y { get; set; }
        public bool IsSnake { get; set; }
        public bool IsApple { get; set; }

        public Cell(int x, int y) 
        {
            X = x;
            Y = y;
            IsSnake = false;
            IsApple = false;
        }
    }
}
