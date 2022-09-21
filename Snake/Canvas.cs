using System.Drawing.Drawing2D;

namespace Snake
{
    public partial class Canvas : Form
    {
        SolidBrush brush = new SolidBrush(Color.Green);
        Graphics g;
        LinkedList<Cell> Snake;
        Cell head;
        Direction currentDirection;
        Direction desiredDirection;

        Cell[,] cells = new Cell[1000 / 20, 1000 / 20];

        public Canvas()
        {
            InitializeComponent();

            Init();
        }

        public void Init() 
        {
            Snake = new LinkedList<Cell>();

            for (int i = 0; i < cells.GetLength(0); i++)
            {
                for (int j = 0; j < cells.GetLength(1); j++)
                {
                    cells[i, j] = new Cell(i, j);
                }
            }

            head = cells[15, 25];
            MakeSnake(head);
            cells[35, 25].IsApple = true;
            currentDirection = Direction.East;
        }

        public void MakeSnake(Cell cell)
        {
            Snake.AddFirst(cell);
            cell.IsSnake = true;
        }

        public void GenerateApple()
        {
            Cell[] possibleApples = new Cell[cells.Length - Snake.Count];
            int counter = 0;

            for(int i = 0; i < cells.GetLength(0); i++)
            {
                for(int j = 0; j < cells.GetLength(1); j++)
                {
                    if (!cells[i, j].IsSnake)
                        possibleApples[counter++] = cells[i, j];
                }
            }

            Random random = new Random();

            possibleApples[random.Next(possibleApples.Length)].IsApple = true;
        }

        public void MoveSnake(Direction direction)
        {
            try
            {
                Cell next = null;

                if (direction == Direction.East)
                {
                    next = cells[++head.X, head.Y];
                    currentDirection = Direction.East;
                }
                else if (direction == Direction.West)
                {
                    next = cells[--head.X, head.Y];
                    currentDirection = Direction.West;
                }
                else if (direction == Direction.North)
                {
                    next = cells[head.X, --head.Y];
                    currentDirection = Direction.North;
                }
                else if (direction == Direction.South)
                {
                    next = cells[head.X, ++head.Y];
                    currentDirection= Direction.South;
                }

                if (next.IsSnake)
                    GameOver();
                else if(next.IsApple)
                {
                    next.IsApple = false;
                    MakeSnake(next);
                    GenerateApple();
                }
                else
                {
                    MakeSnake(next);
                    Snake.Last().IsSnake = false;
                    Snake.RemoveLast();
                }

            }
            catch(IndexOutOfRangeException ex)
            {
                GameOver();
            }
        }

        public void GameOver()
        {
            clock.Enabled = false;
            MessageBox.Show("Game Over.");
        }

        public void PaintCells()
        {
            for(int i = 0; i < cells.GetLength(0); i++)
            {
                for(int j = 0; j < cells.GetLength(1); j++)
                {
                    cells[i, j].PaintCell(g, brush);
                }
            }
        }

        private void screen_Paint(object sender, PaintEventArgs e)
        {
            g = screen.CreateGraphics();
            PaintCells();
        }

        private void clock_Tick(object sender, EventArgs e)
        {
            if(desiredDirection == Direction.West && currentDirection == Direction.East
                || desiredDirection == Direction.East && currentDirection == Direction.West
                || desiredDirection == Direction.North && currentDirection == Direction.South
                || desiredDirection == Direction.South && currentDirection == Direction.North)
                desiredDirection = currentDirection;

            MoveSnake(desiredDirection);
            screen.Refresh();
        }
        
        private void Canvas_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Up || e.KeyCode == Keys.W)
                desiredDirection = Direction.North;
            else if(e.KeyCode == Keys.Down || e.KeyCode == Keys.S)
                desiredDirection = Direction.South;
            else if(e.KeyCode == Keys.Left || e.KeyCode == Keys.A)
                desiredDirection = Direction.West;
            else if(e.KeyCode == Keys.Right || e.KeyCode == Keys.D)
                desiredDirection= Direction.East;
        }
    }
}