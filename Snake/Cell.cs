using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    /// <summary>
    /// This class is the base unit for what makes up the game grid
    /// </summary>
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

        /// <summary>
        /// Fills the Cell with the color of green if it is part of the snake
        /// red if it is an apple, and black if it has nothing in it
        /// </summary>
        /// <param name="g"></param>
        /// <param name="brush"></param>
        public void PaintCell(Graphics g, SolidBrush brush)
        {
            if (IsSnake)
                brush.Color = Color.Green;
            else if (IsApple)
                brush.Color = Color.Red;
            else
                brush.Color = Color.Black;

            g.FillRectangle(brush, new Rectangle(X, Y, Width, Height));
        }
    }
}
