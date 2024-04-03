using System.Collections.Generic;
namespace Nayttotyo
{
    public partial class Form1 : Form
    {
        public bool GameIsOn = false;
        public double TurnNumber = 0.5;
        public static List<int[]> OccupiedTiles = new List<int[]>([[0, 0], []]);
        public Form1()
        {
            InitializeComponent();
        }
        private void WhiteKing_Click(object sender, EventArgs e)
        {
            TableLayoutPanelCellPosition cellpos = new TableLayoutPanelCellPosition(1, 2);
            label1.Text = tableLayoutPanel1.GetCellPosition(WhiteKing).ToString();
            tableLayoutPanel1.SetCellPosition(WhiteKing, new TableLayoutPanelCellPosition(2, 3));
        }
        private void WhiteQueen_Click(object sender, EventArgs e)
        {

        }

        private void WhiteKnight1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            GameIsOn = true;
        }
        public void Turn()
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
