using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
namespace Nayttotyo
{
    public partial class Form1 : Form
    {
        public bool NoDeleting = false;
        public bool GameIsOn = false;
        public bool IsWhitesTurn = false;
        //public Control LastWhiteMovedPiece = null;
        //public Control LastBlackMovedPiece = null;
        public double TurnNumber = 0.5;
        public List<int[]> OccupiedTiles = new List<int[]>();
        public List<int[]> PiecesInDanger = new List<int[]>();
        public int DotNumber = 0;
        public int DotHide = 0;
        public Control ClickedPiece = new Control();
        public Form1()
        {
            InitializeComponent();
            foreach (Control i in tableLayoutPanel1.Controls)
            {
                //OccupiedTiles.Add([tableLayoutPanel1.GetRow(i), tableLayoutPanel1.GetColumn(i)]);
                OccupiedTiles.Add([tableLayoutPanel1.GetColumn(i), tableLayoutPanel1.GetRow(i)]);
                label1.Text += OccupiedTiles[OccupiedTiles.Count - 1][0].ToString();
                label1.Text += OccupiedTiles[OccupiedTiles.Count - 1][1].ToString();
                label1.Text += " ";
            }

        }

        public void ClickingPiece(string Piece, int[] CellPosition)
        {
            Control control = tableLayoutPanel1.GetControlFromPosition(CellPosition[0], CellPosition[1]);
            if (!NoDeleting)
            {
                DeleteMoveSignals();
            }
            NoDeleting = false;
            if (Piece == "w_pawn")
            {
                for (int i = 1; i < 3; i++)
                {
                    //bool yks = !(OccupiedTiles.Any( p => p.SequenceEqual([CellPosition[0], CellPosition[1] - i])));
                    //bool kaks = CellPosition[1] - i > -1;
                    if (!(OccupiedTiles.Any(p => p.SequenceEqual([CellPosition[0], CellPosition[1] - i]))) && CellPosition[1] - i > -1)
                    //if (yks && kaks)
                    {
                        CreateDot([CellPosition[0], CellPosition[1] - i]);
                    }
                    else
                    {
                        break;
                    }

                }
                if ((OccupiedTiles.Any(p => p.SequenceEqual([CellPosition[0] - 1, CellPosition[1] - 1]))) && tableLayoutPanel1.GetControlFromPosition(CellPosition[0] - 1, CellPosition[1] - 1).Tag == "Black")
                {
                    tableLayoutPanel1.GetControlFromPosition(CellPosition[0] - 1, CellPosition[1] - 1).BackColor = Color.Red;
                    PiecesInDanger.Add([CellPosition[0] - 1, CellPosition[1] - 1]);
                }
                if ((OccupiedTiles.Any(p => p.SequenceEqual([CellPosition[0] + 1, CellPosition[1] - 1]))) && tableLayoutPanel1.GetControlFromPosition(CellPosition[0] + 1, CellPosition[1] - 1).Tag == "Black")
                {
                    tableLayoutPanel1.GetControlFromPosition(CellPosition[0] + 1, CellPosition[1] - 1).BackColor = Color.Red;
                    PiecesInDanger.Add([CellPosition[0] + 1, CellPosition[1] - 1]);
                }
                return;
            }
            if (Piece == "b_pawn")
            {
                for (int i = 1; i < 3; i++)
                {
                    if (!(OccupiedTiles.Any(p => p.SequenceEqual([CellPosition[0], CellPosition[1] + i]))) && CellPosition[1] + i < 7)
                    {
                        CreateDot([CellPosition[0], CellPosition[1] + i]);
                    }
                    else
                    {
                        break;
                    }

                }
                if ((OccupiedTiles.Any(p => p.SequenceEqual([CellPosition[0] - 1, CellPosition[1] + 1]))) && tableLayoutPanel1.GetControlFromPosition(CellPosition[0] - 1, CellPosition[1] + 1).Tag == "White")
                {
                    tableLayoutPanel1.GetControlFromPosition(CellPosition[0] - 1, CellPosition[1] + 1).BackColor = Color.Red;
                    PiecesInDanger.Add([CellPosition[0] - 1, CellPosition[1] + 1]);
                }
                if ((OccupiedTiles.Any(p => p.SequenceEqual([CellPosition[0] + 1, CellPosition[1] + 1]))) && tableLayoutPanel1.GetControlFromPosition(CellPosition[0] + 1, CellPosition[1] + 1).Tag == "White")
                {
                    tableLayoutPanel1.GetControlFromPosition(CellPosition[0] + 1, CellPosition[1] + 1).BackColor = Color.Red;
                    PiecesInDanger.Add([CellPosition[0] + 1, CellPosition[1] + 1]);
                }
                return;
            }
            if (Piece == "rook")
            {
                for (int i = 1; i < 8; i++)
                {
                    if (!(CellPosition[1] - i > -1))
                    {
                        break;
                    }
                    if (!(OccupiedTiles.Any(p => p.SequenceEqual([CellPosition[0], CellPosition[1] - i]))))
                    {
                        CreateDot([CellPosition[0], CellPosition[1] - i]);
                    }
                    else
                    {
                        if (tableLayoutPanel1.GetControlFromPosition(CellPosition[0], CellPosition[1] - i).Tag != tableLayoutPanel1.GetControlFromPosition(CellPosition[0], CellPosition[1]).Tag)
                        {
                            tableLayoutPanel1.GetControlFromPosition(CellPosition[0], CellPosition[1] - i).BackColor = Color.Red;
                            PiecesInDanger.Add([CellPosition[0], CellPosition[1] - i]);
                        }
                        break;
                    }
                }
                for (int i = 1; i < 8; i++)
                {
                    if (!(CellPosition[1] + i < 8))
                    {
                        break;
                    }
                    if (!(OccupiedTiles.Any(p => p.SequenceEqual([CellPosition[0], CellPosition[1] + i]))))
                    {
                        CreateDot([CellPosition[0], CellPosition[1] + i]);
                    }
                    else
                    {
                        if (tableLayoutPanel1.GetControlFromPosition(CellPosition[0], CellPosition[1] + i).Tag != tableLayoutPanel1.GetControlFromPosition(CellPosition[0], CellPosition[1]).Tag)
                        {
                            tableLayoutPanel1.GetControlFromPosition(CellPosition[0], CellPosition[1] + i).BackColor = Color.Red;
                            PiecesInDanger.Add([CellPosition[0], CellPosition[1] + i]);
                        }
                        break;
                    }
                }
                for (int i = 1; i < 8; i++)
                {
                    if (!(CellPosition[0] + i < 8))
                    {
                        break;
                    }
                    if (!(OccupiedTiles.Any(p => p.SequenceEqual([CellPosition[0] + i, CellPosition[1]]))))
                    {
                        CreateDot([CellPosition[0] + i, CellPosition[1]]);
                    }
                    else
                    {
                        if (tableLayoutPanel1.GetControlFromPosition(CellPosition[0] + i, CellPosition[1]).Tag != tableLayoutPanel1.GetControlFromPosition(CellPosition[0], CellPosition[1]).Tag)
                        {
                            tableLayoutPanel1.GetControlFromPosition(CellPosition[0] + i, CellPosition[1]).BackColor = Color.Red;
                            PiecesInDanger.Add([CellPosition[0] + i, CellPosition[1]]);
                        }
                        break;
                    }
                }
                for (int i = 1; i < 8; i++)
                {
                    if (!(CellPosition[0] - i > -1))
                    {
                        break;
                    }
                    if (!(OccupiedTiles.Any(p => p.SequenceEqual([CellPosition[0] - i, CellPosition[1]]))))
                    {
                        CreateDot([CellPosition[0] - i, CellPosition[1]]);
                    }
                    else
                    {
                        if (tableLayoutPanel1.GetControlFromPosition(CellPosition[0] - i, CellPosition[1]).Tag != tableLayoutPanel1.GetControlFromPosition(CellPosition[0], CellPosition[1]).Tag)
                        {
                            tableLayoutPanel1.GetControlFromPosition(CellPosition[0] - i, CellPosition[1]).BackColor = Color.Red;
                            PiecesInDanger.Add([CellPosition[0] - i, CellPosition[1]]);
                        }
                        break;
                    }
                }
                return;
            }
            if (Piece == "knight")
            {
                if ((CellPosition[0] + 2 < 8) && (CellPosition[1] - 1 > -1))
                {
                    if (!(OccupiedTiles.Any(p => p.SequenceEqual([CellPosition[0] + 2, CellPosition[1] - 1]))))
                    {
                        CreateDot([CellPosition[0] + 2, CellPosition[1] - 1]);
                    }
                    else if (tableLayoutPanel1.GetControlFromPosition(CellPosition[0] + 2, CellPosition[1] - 1).Tag != control.Tag)
                    {
                        tableLayoutPanel1.GetControlFromPosition(CellPosition[0] + 2, CellPosition[1] - 1).BackColor = Color.Red;
                    }
                }
                if ((CellPosition[0] + 2 < 8) && (CellPosition[1] + 1 < 8))
                {
                    if (!(OccupiedTiles.Any(p => p.SequenceEqual([CellPosition[0] + 2, CellPosition[1] + 1]))))
                    {
                        CreateDot([CellPosition[0] + 2, CellPosition[1] + 1]);
                    }
                    else if (tableLayoutPanel1.GetControlFromPosition(CellPosition[0] + 2, CellPosition[1] + 1).Tag != control.Tag)
                    {
                        tableLayoutPanel1.GetControlFromPosition(CellPosition[0] + 2, CellPosition[1] + 1).BackColor = Color.Red;
                    }
                }
                if ((CellPosition[0] - 2 > -1) && (CellPosition[1] - 1 > -1))
                {
                    if (!(OccupiedTiles.Any(p => p.SequenceEqual([CellPosition[0] - 2, CellPosition[1] - 1]))))
                    {
                        CreateDot([CellPosition[0] - 2, CellPosition[1] - 1]);
                    }
                    else if (tableLayoutPanel1.GetControlFromPosition(CellPosition[0] - 2, CellPosition[1] - 1).Tag != control.Tag)
                    {
                        tableLayoutPanel1.GetControlFromPosition(CellPosition[0] - 2, CellPosition[1] - 1).BackColor = Color.Red;
                    }
                }
                if ((CellPosition[0] - 2 > -1) && (CellPosition[1] + 1 < 8))
                {
                    if (!(OccupiedTiles.Any(p => p.SequenceEqual([CellPosition[0] - 2, CellPosition[1] + 1]))))
                    {
                        CreateDot([CellPosition[0] - 2, CellPosition[1] + 1]);
                    }
                    else if (tableLayoutPanel1.GetControlFromPosition(CellPosition[0] - 2, CellPosition[1] + 1).Tag != control.Tag)
                    {
                        tableLayoutPanel1.GetControlFromPosition(CellPosition[0] - 2, CellPosition[1] + 1).BackColor = Color.Red;
                    }
                }
                if ((CellPosition[0] - 1 > -1) && (CellPosition[1] + 2 < 8))
                {
                    if (!(OccupiedTiles.Any(p => p.SequenceEqual([CellPosition[0] - 1, CellPosition[1] + 2]))))
                    {
                        CreateDot([CellPosition[0] - 1, CellPosition[1] + 2]);
                    }
                    else if (tableLayoutPanel1.GetControlFromPosition(CellPosition[0] - 1, CellPosition[1] + 2).Tag != control.Tag)
                    {
                        tableLayoutPanel1.GetControlFromPosition(CellPosition[0] - 1, CellPosition[1] + 2).BackColor = Color.Red;
                    }
                }
                if ((CellPosition[0] + 1 < 8) && (CellPosition[1] + 2 < 8))
                {
                    if (!(OccupiedTiles.Any(p => p.SequenceEqual([CellPosition[0] + 1, CellPosition[1] + 2]))))
                    {
                        CreateDot([CellPosition[0] + 1, CellPosition[1] + 2]);
                    }
                    else if (tableLayoutPanel1.GetControlFromPosition(CellPosition[0] + 1, CellPosition[1] + 2).Tag != control.Tag)
                    {
                        tableLayoutPanel1.GetControlFromPosition(CellPosition[0] + 1, CellPosition[1] + 2).BackColor = Color.Red;
                    }
                }
                if ((CellPosition[0] - 1 > -1) && (CellPosition[1] - 2 > -1))
                {
                    if (!(OccupiedTiles.Any(p => p.SequenceEqual([CellPosition[0] - 1, CellPosition[1] - 2]))))
                    {
                        CreateDot([CellPosition[0] - 1, CellPosition[1] - 2]);
                    }
                    else if (tableLayoutPanel1.GetControlFromPosition(CellPosition[0] - 1, CellPosition[1] - 2).Tag != control.Tag)
                    {
                        tableLayoutPanel1.GetControlFromPosition(CellPosition[0] - 1, CellPosition[1] - 2).BackColor = Color.Red;
                    }
                }
                if ((CellPosition[0] + 1 < 8) && (CellPosition[1] - 2 > -1))
                {
                    if (!(OccupiedTiles.Any(p => p.SequenceEqual([CellPosition[0] + 1, CellPosition[1] - 2]))))
                    {
                        CreateDot([CellPosition[0] + 1, CellPosition[1] - 2]);
                    }
                    else if (tableLayoutPanel1.GetControlFromPosition(CellPosition[0] + 1, CellPosition[1] - 2).Tag != control.Tag)
                    {
                        tableLayoutPanel1.GetControlFromPosition(CellPosition[0] + 1, CellPosition[1] - 2).BackColor = Color.Red;
                    }
                }
                return;
            }
            if (Piece == "bishop")
            {
                for (int i = 1; i < 8; i++)
                {
                    if ((CellPosition[0] + i < 8) && (CellPosition[1] + i < 8))
                    {
                        if (!(OccupiedTiles.Any(p => p.SequenceEqual([CellPosition[0] + i, CellPosition[1] + i]))))
                        {
                            CreateDot([CellPosition[0] + i, CellPosition[1] + i]);
                        }
                        else
                        {
                            if (tableLayoutPanel1.GetControlFromPosition(CellPosition[0] + i, CellPosition[1] + i).Tag != control.Tag)
                            {
                                tableLayoutPanel1.GetControlFromPosition(CellPosition[0] + i, CellPosition[1] + i).BackColor = Color.Red;
                                PiecesInDanger.Add([CellPosition[0] + i, CellPosition[1] + i]);
                                break;
                            }
                            break;
                        }
                    }
                    else { break; }
                }
                for (int i = 1; i < 8; i++)
                {
                    if ((CellPosition[0] + i < 8) && (CellPosition[1] - i > -1))
                    {
                        if (!(OccupiedTiles.Any(p => p.SequenceEqual([CellPosition[0] + i, CellPosition[1] - i]))))
                        {
                            CreateDot([CellPosition[0] + i, CellPosition[1] - i]);
                        }
                        else
                        {
                            if (tableLayoutPanel1.GetControlFromPosition(CellPosition[0] + i, CellPosition[1] - i).Tag != control.Tag)
                            {
                                tableLayoutPanel1.GetControlFromPosition(CellPosition[0] + i, CellPosition[1] - i).BackColor = Color.Red;
                                PiecesInDanger.Add([CellPosition[0] + i, CellPosition[1] - i]);
                                break;
                            }
                            break;
                        }
                    }
                    else { break; }
                }
                for (int i = 1; i < 8; i++)
                {
                    if ((CellPosition[0] - i > -1) && (CellPosition[1] + i < 8))
                    {
                        if (!(OccupiedTiles.Any(p => p.SequenceEqual([CellPosition[0] - i, CellPosition[1] + i]))))
                        {
                            CreateDot([CellPosition[0] - i, CellPosition[1] + i]);
                        }
                        else
                        {
                            if (tableLayoutPanel1.GetControlFromPosition(CellPosition[0] - i, CellPosition[1] + i).Tag != control.Tag)
                            {
                                tableLayoutPanel1.GetControlFromPosition(CellPosition[0] - i, CellPosition[1] + i).BackColor = Color.Red;
                                PiecesInDanger.Add([CellPosition[0] - i, CellPosition[1] + i]);
                                break;
                            }
                            break;
                        }
                    }
                    else { break; }
                }
                for (int i = 1; i < 8; i++)
                {
                    if ((CellPosition[0] - i > -1) && (CellPosition[1] - i > -1))
                    {
                        if (!(OccupiedTiles.Any(p => p.SequenceEqual([CellPosition[0] - i, CellPosition[1] - i]))))
                        {
                            CreateDot([CellPosition[0] - i, CellPosition[1] - i]);
                        }
                        else
                        {
                            if (tableLayoutPanel1.GetControlFromPosition(CellPosition[0] - i, CellPosition[1] - i).Tag != control.Tag)
                            {
                                tableLayoutPanel1.GetControlFromPosition(CellPosition[0] - i, CellPosition[1] - i).BackColor = Color.Red;
                                PiecesInDanger.Add([CellPosition[0] - i, CellPosition[1] - i]);
                                break;
                            }
                            break;
                        }
                    }
                    else { break; }
                }
                return;
            }
            if (Piece == "queen")
            {
                ClickingPiece("rook", CellPosition);
                NoDeleting = true;
                ClickingPiece("bishop", CellPosition);
                return;
            }
            if (Piece == "king")
            {
                for (int i = -1; i < 2; i++)
                {
                    for (int j = -1; j < 2; j++)
                    {
                        if ((CellPosition[0] + i > -1) && (CellPosition[1] + j > -1) && (CellPosition[0] + i < 8) && (CellPosition[1] + j < 8))
                        {
                            if (!(OccupiedTiles.Any(p => p.SequenceEqual([CellPosition[0] + i, CellPosition[1] + j]))))
                            {
                                CreateDot([CellPosition[0] + i, CellPosition[1] + j]);
                            }
                            else
                            {
                                if (tableLayoutPanel1.GetControlFromPosition(CellPosition[0] + i, CellPosition[1] + j).Tag != control.Tag)
                                {
                                    tableLayoutPanel1.GetControlFromPosition(CellPosition[0] + i, CellPosition[1] + j).BackColor = Color.Red;
                                    PiecesInDanger.Add([CellPosition[0] + i, CellPosition[1] + j]);
                                }
                            }
                        }
                    }
                }
                return;
            }
        }
        public void CreateDot(int[] Position)
        {
            PictureBox DotCopy = new PictureBox();
            DotCopy = new PictureBox();
            DotCopy.Name = "Dot" + DotNumber;
            DotCopy.Image = imageList1.Images[1];
            DotCopy.BackColor = Color.Transparent;
            DotCopy.SizeMode = PictureBoxSizeMode.CenterImage;
            DotCopy.Visible = true;
            DotCopy.Click += new EventHandler(DotMove);
            tableLayoutPanel1.Controls.Add(DotCopy);
            tableLayoutPanel1.SetCellPosition(DotCopy, new TableLayoutPanelCellPosition(Position[0], Position[1]));
            DotNumber++;

        }
        public void DotMove(object sender, EventArgs e)
        {
            Moving((Control)sender);
        }
        public void Moving(Control control)
        {
            DeleteMoveSignals();
            char[] name = control.Name.ToCharArray();
            if ((name[0] == 'B' && IsWhitesTurn) || (name[0] == 'W' && !IsWhitesTurn))
            {
                tableLayoutPanel1.Controls.Remove(control);
                OccupiedTiles.RemoveAll(s => s.SequenceEqual([tableLayoutPanel1.GetCellPosition(ClickedPiece).Column, tableLayoutPanel1.GetCellPosition(ClickedPiece).Row]));
                tableLayoutPanel1.SetCellPosition(ClickedPiece, tableLayoutPanel1.GetCellPosition(control));
                label1.Text = "Noniiin";
                IsWhitesTurn = !IsWhitesTurn;
                return;
            }
            OccupiedTiles.RemoveAll(s => s.SequenceEqual([tableLayoutPanel1.GetCellPosition(ClickedPiece).Column, tableLayoutPanel1.GetCellPosition(ClickedPiece).Row]));
            tableLayoutPanel1.SetCellPosition(ClickedPiece, tableLayoutPanel1.GetCellPosition(control));
            OccupiedTiles.Add([tableLayoutPanel1.GetCellPosition(control).Column, tableLayoutPanel1.GetCellPosition(control).Row]);
            label1.Text = tableLayoutPanel1.GetCellPosition(control).Column.ToString() + tableLayoutPanel1.GetCellPosition(control).Row.ToString();
            IsWhitesTurn = !IsWhitesTurn;

        }
        public void DeleteMoveSignals()
        {
            for (int i = 0; i < (DotNumber - DotHide);)
            {
                tableLayoutPanel1.Controls.Remove(tableLayoutPanel1.Controls.Find("Dot" + DotHide, false)[0]);
                DotHide++;
            }
            for (int i = 0; i < PiecesInDanger.Count;)
            {
                tableLayoutPanel1.GetControlFromPosition(PiecesInDanger[0][0], PiecesInDanger[0][1]).BackColor = Color.Transparent;
                PiecesInDanger.RemoveAt(0);
            }
        }
        private void WhiteKing_Click(object sender, EventArgs e)
        {
            if (!GameIsOn)
            {
                label1.Text = string.Empty;
                TableLayoutPanelCellPosition cellpos = new TableLayoutPanelCellPosition(1, 2);
                label1.Text = tableLayoutPanel1.GetCellPosition(WhiteKing).ToString();
                tableLayoutPanel1.SetCellPosition(WhiteKing, new TableLayoutPanelCellPosition(2, 3));
                foreach (Control i in tableLayoutPanel1.Controls)
                {
                    label1.Text += " ";
                    label1.Text += tableLayoutPanel1.GetCellPosition(i).ToString();
                    Console.WriteLine(i.Name);
                    //OccupiedTiles.Add(tableLayoutPanel1.GetCellPosition(i));
                }
            }
            if (IsWhitesTurn)
            {
                ClickingPiece("king", [tableLayoutPanel1.GetColumn(WhiteKing), tableLayoutPanel1.GetRow(WhiteKing)]);
                ClickedPiece = WhiteKing;
                return;
            }
            if ((!IsWhitesTurn) && WhiteKing.BackColor == Color.Red)
            {
                Moving(WhiteKing);
                //Häviäs koko pelin
            }
        }
        private void WhiteQueen_Click(object sender, EventArgs e)
        {
            if (!GameIsOn)
            {
                return;
            }
            if (IsWhitesTurn)
            {
                ClickingPiece("queen", [tableLayoutPanel1.GetColumn(WhiteQueen), tableLayoutPanel1.GetRow(WhiteQueen)]);
                ClickedPiece = WhiteQueen;
                return;
            }
            if ((!IsWhitesTurn) && WhiteQueen.BackColor == Color.Red)
            {
                Moving(WhiteQueen);
            }
        }

        private void WhiteKnight1_Click(object sender, EventArgs e)
        {
            if (!GameIsOn)
            {
                return;
            }
            if (IsWhitesTurn)
            {
                ClickingPiece("knight", [tableLayoutPanel1.GetColumn(WhiteKnight1), tableLayoutPanel1.GetRow(WhiteKnight1)]);
                ClickedPiece = WhiteKnight1;
                return;
            }
            if ((!IsWhitesTurn) && WhiteKnight1.BackColor == Color.Red)
            {
                Moving(WhiteKnight1);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GameIsOn = true;
            IsWhitesTurn = true;
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

        private void BlackPawn3_Click(object sender, EventArgs e)
        {
            if (!GameIsOn)
            {
                return;
            }
            if ((IsWhitesTurn) && BlackPawn3.BackColor == Color.Red)
            {
                Moving(BlackPawn3);
                return;
            }
            if (!IsWhitesTurn)
            {
                ClickingPiece("b_pawn", [tableLayoutPanel1.GetColumn(BlackPawn3), tableLayoutPanel1.GetRow(BlackPawn3)]);
                ClickedPiece = BlackPawn3;
                return;
            }
        }

        private void WhitePawn3_Click(object sender, EventArgs e)
        {
            if (!GameIsOn)
            {
                return;
            }
            if (IsWhitesTurn)
            {
                //ClickingPiece("w_pawn", [tableLayoutPanel1.GetCellPosition(WhitePawn3).Column, tableLayoutPanel1.GetCellPosition(WhitePawn3).Row]);
                ClickingPiece("w_pawn", [tableLayoutPanel1.GetColumn(WhitePawn3), tableLayoutPanel1.GetRow(WhitePawn3)]);
                ClickedPiece = WhitePawn3;
                return;
            }
            if ((!IsWhitesTurn) && WhitePawn3.BackColor == Color.Red)
            {
                Moving(WhitePawn3);
            }
        }

        private void WhitePawn4_Click(object sender, EventArgs e)
        {
            if (!GameIsOn)
            {
                return;
            }
            if (IsWhitesTurn)
            {
                ClickingPiece("w_pawn", [tableLayoutPanel1.GetColumn(WhitePawn4), tableLayoutPanel1.GetRow(WhitePawn4)]);
                ClickedPiece = WhitePawn4;
                return;
            }
            if ((!IsWhitesTurn) && WhitePawn4.BackColor == Color.Red)
            {
                Moving(WhitePawn4);
            }
        }

        private void BlackPawn4_Click(object sender, EventArgs e)
        {
            if (!GameIsOn)
            {
                return;
            }
            if ((IsWhitesTurn) && BlackPawn4.BackColor == Color.Red)
            {
                Moving(BlackPawn4);
                return;
            }
            if (!IsWhitesTurn)
            {
                ClickingPiece("b_pawn", [tableLayoutPanel1.GetColumn(BlackPawn4), tableLayoutPanel1.GetRow(BlackPawn4)]);
                ClickedPiece = BlackPawn4;
                return;
            }
        }

        private void WhitePawn1_Click(object sender, EventArgs e)
        {
            if (!GameIsOn)
            {
                return;
            }
            if (IsWhitesTurn)
            {
                ClickingPiece("w_pawn", [tableLayoutPanel1.GetColumn(WhitePawn1), tableLayoutPanel1.GetRow(WhitePawn1)]);
                ClickedPiece = WhitePawn1;
                return;
            }
            if ((!IsWhitesTurn) && WhitePawn1.BackColor == Color.Red)
            {
                Moving(WhitePawn1);
            }
        }

        private void WhitePawn2_Click(object sender, EventArgs e)
        {
            if (!GameIsOn)
            {
                return;
            }
            if (IsWhitesTurn)
            {
                ClickingPiece("w_pawn", [tableLayoutPanel1.GetColumn(WhitePawn2), tableLayoutPanel1.GetRow(WhitePawn2)]);
                ClickedPiece = WhitePawn2;
                return;
            }
            if ((!IsWhitesTurn) && WhitePawn2.BackColor == Color.Red)
            {
                Moving(WhitePawn2);
            }
        }

        private void WhitePawn5_Click(object sender, EventArgs e)
        {
            if (!GameIsOn)
            {
                return;
            }
            if (IsWhitesTurn)
            {
                ClickingPiece("w_pawn", [tableLayoutPanel1.GetColumn(WhitePawn5), tableLayoutPanel1.GetRow(WhitePawn5)]);
                ClickedPiece = WhitePawn5;
                return;
            }
            if ((!IsWhitesTurn) && WhitePawn5.BackColor == Color.Red)
            {
                Moving(WhitePawn5);
            }
        }

        private void WhitePawn6_Click(object sender, EventArgs e)
        {
            if (!GameIsOn)
            {
                return;
            }
            if (IsWhitesTurn)
            {
                ClickingPiece("w_pawn", [tableLayoutPanel1.GetColumn(WhitePawn6), tableLayoutPanel1.GetRow(WhitePawn6)]);
                ClickedPiece = WhitePawn6;
                return;
            }
            if ((!IsWhitesTurn) && WhitePawn6.BackColor == Color.Red)
            {
                Moving(WhitePawn6);
            }
        }

        private void WhitePawn7_Click(object sender, EventArgs e)
        {
            if (!GameIsOn)
            {
                return;
            }
            if (IsWhitesTurn)
            {
                ClickingPiece("w_pawn", [tableLayoutPanel1.GetColumn(WhitePawn7), tableLayoutPanel1.GetRow(WhitePawn7)]);
                ClickedPiece = WhitePawn7;
                return;
            }
            if ((!IsWhitesTurn) && WhitePawn7.BackColor == Color.Red)
            {
                Moving(WhitePawn7);
            }
        }

        private void WhitePawn8_Click(object sender, EventArgs e)
        {
            if (!GameIsOn)
            {
                return;
            }
            if (IsWhitesTurn)
            {
                ClickingPiece("w_pawn", [tableLayoutPanel1.GetColumn(WhitePawn8), tableLayoutPanel1.GetRow(WhitePawn8)]);
                ClickedPiece = WhitePawn8;
                return;
            }
            if ((!IsWhitesTurn) && WhitePawn8.BackColor == Color.Red)
            {
                Moving(WhitePawn8);
            }
        }

        private void BlackPawn1_Click(object sender, EventArgs e)
        {
            if (!GameIsOn)
            {
                return;
            }
            if ((IsWhitesTurn) && BlackPawn1.BackColor == Color.Red)
            {
                Moving(BlackPawn1);
                return;
            }
            if (!IsWhitesTurn)
            {
                ClickingPiece("b_pawn", [tableLayoutPanel1.GetColumn(BlackPawn1), tableLayoutPanel1.GetRow(BlackPawn1)]);
                ClickedPiece = BlackPawn1;
                return;
            }
        }

        private void BlackPawn2_Click(object sender, EventArgs e)
        {
            if (!GameIsOn)
            {
                return;
            }
            if ((IsWhitesTurn) && BlackPawn2.BackColor == Color.Red)
            {
                Moving(BlackPawn2);
                return;
            }
            if (!IsWhitesTurn)
            {
                ClickingPiece("b_pawn", [tableLayoutPanel1.GetColumn(BlackPawn2), tableLayoutPanel1.GetRow(BlackPawn2)]);
                ClickedPiece = BlackPawn2;
                return;
            }
        }

        private void BlackPawn5_Click(object sender, EventArgs e)
        {
            if (!GameIsOn)
            {
                return;
            }
            if ((IsWhitesTurn) && BlackPawn5.BackColor == Color.Red)
            {
                Moving(BlackPawn5);
                return;
            }
            if (!IsWhitesTurn)
            {
                ClickingPiece("b_pawn", [tableLayoutPanel1.GetColumn(BlackPawn5), tableLayoutPanel1.GetRow(BlackPawn5)]);
                ClickedPiece = BlackPawn5;
                return;
            }
        }

        private void BlackPawn6_Click(object sender, EventArgs e)
        {
            if (!GameIsOn)
            {
                return;
            }
            if ((IsWhitesTurn) && BlackPawn6.BackColor == Color.Red)
            {
                Moving(BlackPawn6);
                return;
            }
            if (!IsWhitesTurn)
            {
                ClickingPiece("b_pawn", [tableLayoutPanel1.GetColumn(BlackPawn6), tableLayoutPanel1.GetRow(BlackPawn6)]);
                ClickedPiece = BlackPawn6;
                return;
            }
        }

        private void BlackPawn7_Click(object sender, EventArgs e)
        {
            if (!GameIsOn)
            {
                return;
            }
            if ((IsWhitesTurn) && BlackPawn7.BackColor == Color.Red)
            {
                Moving(BlackPawn7);
                return;
            }
            if (!IsWhitesTurn)
            {
                ClickingPiece("b_pawn", [tableLayoutPanel1.GetColumn(BlackPawn7), tableLayoutPanel1.GetRow(BlackPawn7)]);
                ClickedPiece = BlackPawn7;
                return;
            }
        }

        private void BlackPawn8_Click(object sender, EventArgs e)
        {
            if (!GameIsOn)
            {
                return;
            }
            if ((IsWhitesTurn) && BlackPawn8.BackColor == Color.Red)
            {
                Moving(BlackPawn8);
                return;
            }
            if (!IsWhitesTurn)
            {
                ClickingPiece("b_pawn", [tableLayoutPanel1.GetColumn(BlackPawn8), tableLayoutPanel1.GetRow(BlackPawn8)]);
                ClickedPiece = BlackPawn8;
                return;
            }
        }

        private void WhiteRook1_Click(object sender, EventArgs e)
        {
            if (!GameIsOn)
            {
                return;
            }
            if (IsWhitesTurn)
            {
                ClickingPiece("rook", [tableLayoutPanel1.GetColumn(WhiteRook1), tableLayoutPanel1.GetRow(WhiteRook1)]);
                ClickedPiece = WhiteRook1;
                return;
            }
            if ((!IsWhitesTurn) && WhiteRook1.BackColor == Color.Red)
            {
                Moving(WhiteRook1);
            }
        }

        private void WhiteRook2_Click(object sender, EventArgs e)
        {
            if (!GameIsOn)
            {
                return;
            }
            if (IsWhitesTurn)
            {
                ClickingPiece("rook", [tableLayoutPanel1.GetColumn(WhiteRook2), tableLayoutPanel1.GetRow(WhiteRook2)]);
                ClickedPiece = WhiteRook2;
                return;
            }
            if ((!IsWhitesTurn) && WhiteRook2.BackColor == Color.Red)
            {
                Moving(WhiteRook2);
            }
        }

        private void BlackRook1_Click(object sender, EventArgs e)
        {
            if (!GameIsOn)
            {
                return;
            }
            if ((IsWhitesTurn) && BlackRook1.BackColor == Color.Red)
            {
                Moving(BlackRook1);
                return;
            }
            if (!IsWhitesTurn)
            {
                ClickingPiece("rook", [tableLayoutPanel1.GetColumn(BlackRook1), tableLayoutPanel1.GetRow(BlackRook1)]);
                ClickedPiece = BlackRook1;
            }
        }

        private void BlackRook2_Click(object sender, EventArgs e)
        {
            if (!GameIsOn)
            {
                return;
            }
            if ((IsWhitesTurn) && BlackRook2.BackColor == Color.Red)
            {
                Moving(BlackRook2);
                return;
            }
            if (!IsWhitesTurn)
            {
                ClickingPiece("rook", [tableLayoutPanel1.GetColumn(BlackRook2), tableLayoutPanel1.GetRow(BlackRook2)]);
                ClickedPiece = BlackRook2;
            }
        }

        private void WhiteKnight2_Click(object sender, EventArgs e)
        {
            if (!GameIsOn)
            {
                return;
            }
            if (IsWhitesTurn)
            {
                ClickingPiece("knight", [tableLayoutPanel1.GetColumn(WhiteKnight2), tableLayoutPanel1.GetRow(WhiteKnight2)]);
                ClickedPiece = WhiteKnight2;
                return;
            }
            if ((!IsWhitesTurn) && WhiteKnight2.BackColor == Color.Red)
            {
                Moving(WhiteKnight2);
            }
        }

        private void BlackKnight1_Click(object sender, EventArgs e)
        {
            if (!GameIsOn)
            {
                return;
            }
            if (!GameIsOn)
            {
                return;
            }
            if ((IsWhitesTurn) && BlackKnight1.BackColor == Color.Red)
            {
                Moving(BlackKnight1);
                return;
            }
            if (!IsWhitesTurn)
            {
                ClickingPiece("knight", [tableLayoutPanel1.GetColumn(BlackKnight1), tableLayoutPanel1.GetRow(BlackKnight1)]);
                ClickedPiece = BlackKnight1;
            }
        }

        private void BlackKnight2_Click(object sender, EventArgs e)
        {
            if (!GameIsOn)
            {
                return;
            }
            if ((IsWhitesTurn) && BlackKnight2.BackColor == Color.Red)
            {
                Moving(BlackKnight2);
                return;
            }
            if (!IsWhitesTurn)
            {
                ClickingPiece("knight", [tableLayoutPanel1.GetColumn(BlackKnight2), tableLayoutPanel1.GetRow(BlackKnight2)]);
                ClickedPiece = BlackKnight2;
            }
        }

        private void WhiteBishop1_Click(object sender, EventArgs e)
        {
            if (!GameIsOn)
            {
                return;
            }
            if (IsWhitesTurn)
            {
                ClickingPiece("bishop", [tableLayoutPanel1.GetColumn(WhiteBishop1), tableLayoutPanel1.GetRow(WhiteBishop1)]);
                ClickedPiece = WhiteBishop1;
                return;
            }
            if ((!IsWhitesTurn) && WhiteBishop1.BackColor == Color.Red)
            {
                Moving(WhiteBishop1);
            }
        }

        private void WhiteBishop2_Click(object sender, EventArgs e)
        {
            if (!GameIsOn)
            {
                return;
            }
            if (IsWhitesTurn)
            {
                ClickingPiece("bishop", [tableLayoutPanel1.GetColumn(WhiteBishop2), tableLayoutPanel1.GetRow(WhiteBishop2)]);
                ClickedPiece = WhiteBishop2;
                return;
            }
            if ((!IsWhitesTurn) && WhiteBishop2.BackColor == Color.Red)
            {
                Moving(WhiteBishop2);
            }
        }

        private void BlackBishop1_Click(object sender, EventArgs e)
        {
            if (!GameIsOn)
            {
                return;
            }
            if ((IsWhitesTurn) && BlackBishop1.BackColor == Color.Red)
            {
                Moving(BlackBishop1);
                return;
            }
            if (!IsWhitesTurn)
            {
                ClickingPiece("bishop", [tableLayoutPanel1.GetColumn(BlackBishop1), tableLayoutPanel1.GetRow(BlackBishop1)]);
                ClickedPiece = BlackBishop1;
            }
        }

        private void BlackBishop2_Click(object sender, EventArgs e)
        {
            if (!GameIsOn)
            {
                return;
            }
            if ((IsWhitesTurn) && BlackBishop2.BackColor == Color.Red)
            {
                Moving(BlackBishop2);
                return;
            }
            if (!IsWhitesTurn)
            {
                ClickingPiece("bishop", [tableLayoutPanel1.GetColumn(BlackBishop2), tableLayoutPanel1.GetRow(BlackBishop2)]);
                ClickedPiece = BlackBishop2;
            }
        }

        private void BlackQueen_Click(object sender, EventArgs e)
        {
            if (!GameIsOn)
            {
                return;
            }
            if ((IsWhitesTurn) && BlackQueen.BackColor == Color.Red)
            {
                Moving(BlackQueen); return;
            }
            if (!IsWhitesTurn)
            {
                ClickingPiece("queen", [tableLayoutPanel1.GetColumn(BlackQueen), tableLayoutPanel1.GetRow(BlackQueen)]);
                ClickedPiece = BlackQueen;
            }
        }

        private void BlackKing_Click(object sender, EventArgs e)
        {
            if (!GameIsOn)
            {
                return;
            }
            if ((IsWhitesTurn) && BlackKing.BackColor == Color.Red)
            {
                Moving(BlackKing);
                return;
                //Häviäs koko pelin
            }
            if (!IsWhitesTurn)
            {
                ClickingPiece("king", [tableLayoutPanel1.GetColumn(BlackKing), tableLayoutPanel1.GetRow(BlackKing)]);
                ClickedPiece = BlackKing;
            }
        }
    }
}
