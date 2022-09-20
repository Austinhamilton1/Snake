namespace Snake
{
    public partial class Canvas : Form
    {
        SolidBrush brush = new SolidBrush(Color.Green);
        Graphics g = null;

        public Canvas()
        {
            InitializeComponent();
        }

        private void screen_Paint(object sender, PaintEventArgs e)
        {
            g = screen.CreateGraphics();
        }

        private void Canvas_Load(object sender, EventArgs e)
        {
            MessageBox.Show($"Height: {screen.Height}, Width: {screen.Width}");
        }
    }
}