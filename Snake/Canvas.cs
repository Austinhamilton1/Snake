using System.Drawing.Drawing2D;

namespace Snake
{
    public partial class Canvas : Form
    {
        SolidBrush brush = new SolidBrush(Color.Green);
        Graphics g;

        Cell[,] cells = new Cell[1000 / 20, 1000 / 20];

        public Canvas()
        {
            InitializeComponent();

            Init();
        }

        public void Init() 
        {
            for (int i = 0; i < cells.GetLength(0); i++)
            {
                for (int j = 0; j < cells.GetLength(1); j++)
                {
                    cells[i, j] = new Cell(i * 20, j * 20);
                }
            }
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

        public void Loop()
        {
            while (true) ;
        }

        private void screen_Paint(object sender, PaintEventArgs e)
        {
            g = screen.CreateGraphics();
            PaintCells();
        }

        private void clock_Tick(object sender, EventArgs e)
        {
            screen.Refresh();
        }
    }
}