using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Text.Json.Serialization.Metadata;
using System.Windows.Forms;
namespace Nayttotyo
{
    public partial class Form1 : Form
    {
        public bool noDeleting = false;
        public bool gameIsOn = false;
        public bool isWhitesTurn = false;
        //public Control LastWhiteMovedPiece = null;
        //public Control LastBlackMovedPiece = null;
        public double turnNumber = 0.5;
        public List<int[]> occupiedTiles = new List<int[]>();
        //public TableLayoutPanel tableControlsCopy = new TableLayoutPanel();
        public List<int[]> piecesInDanger = new List<int[]>();
        public int dotNumber = 0;
        public int dotHide = 0;
        public Control clickedPiece = new Control();
        public bool IsInCheck = false;
        public Form1()
        {
            InitializeComponent();
            label1.Text = string.Empty;
            foreach (Control i in tableLayoutPanel1.Controls)
            {
                occupiedTiles.Add([tableLayoutPanel1.GetColumn(i), tableLayoutPanel1.GetRow(i)]);
            }
        }

        public void ClickingPiece(string piece, int[] cellPosition)
        {
            Control control = tableLayoutPanel1.GetControlFromPosition(cellPosition[0], cellPosition[1]);
            tableLayoutPanel1.SuspendLayout();
            if (!noDeleting)
            {
                DeleteMoveSignals();
            }
            noDeleting = false;
            char pieceColor = tableLayoutPanel1.GetControlFromPosition(cellPosition[0], cellPosition[1]).Tag.ToString()[0];
            Control king;
            if (pieceColor == 'W')
            {
                king = WhiteKing;
            }
            else { king = BlackKing; }
            int ekabonus = 0;
            if (piece == "w_pawn")
            {
                if (cellPosition[1] == 6)
                {
                    ekabonus++;
                }
                for (int i = 1; i < 2 + ekabonus; i++)
                {
                    if (!(occupiedTiles.Any(p => p.SequenceEqual([cellPosition[0], cellPosition[1] - i]))) && cellPosition[1] - i > -1)
                    {
                        if (!(IsGonnaCheck(WhiteKing, [cellPosition[0], cellPosition[1]], [cellPosition[0], cellPosition[1] - i])))
                        {
                            CreateDot([cellPosition[0], cellPosition[1] - i]);
                        }
                    }
                    else
                    {
                        break;
                    }

                }
                if ((occupiedTiles.Any(p => p.SequenceEqual([cellPosition[0] - 1, cellPosition[1] - 1]))) && tableLayoutPanel1.GetControlFromPosition(cellPosition[0] - 1, cellPosition[1] - 1).Tag.ToString()[0] == 'B')
                {
                    if (!(IsGonnaCheck(WhiteKing, [cellPosition[0], cellPosition[1]], [cellPosition[0] - 1, cellPosition[1] - 1])))
                    {
                        tableLayoutPanel1.GetControlFromPosition(cellPosition[0] - 1, cellPosition[1] - 1).BackColor = Color.Red;
                        piecesInDanger.Add([cellPosition[0] - 1, cellPosition[1] - 1]);
                    }
                }
                if ((occupiedTiles.Any(p => p.SequenceEqual([cellPosition[0] + 1, cellPosition[1] - 1]))) && tableLayoutPanel1.GetControlFromPosition(cellPosition[0] + 1, cellPosition[1] - 1).Tag.ToString()[0] == 'B')
                {
                    if (!(IsGonnaCheck(WhiteKing, [cellPosition[0], cellPosition[1]], [cellPosition[0] + 1, cellPosition[1] - 1])))
                    {
                        tableLayoutPanel1.GetControlFromPosition(cellPosition[0] + 1, cellPosition[1] - 1).BackColor = Color.Red;
                        piecesInDanger.Add([cellPosition[0] + 1, cellPosition[1] - 1]);
                    }
                }
                tableLayoutPanel1.ResumeLayout();
                return;
            }
            if (piece == "b_pawn")
            {
                if (cellPosition[1] == 1)
                {
                    ekabonus++;
                }
                for (int i = 1; i < 2 + ekabonus; i++)
                {
                    if (!(occupiedTiles.Any(p => p.SequenceEqual([cellPosition[0], cellPosition[1] + i]))) && cellPosition[1] + i < 7)
                    {
                        if (!(IsGonnaCheck(BlackKing, [cellPosition[0], cellPosition[1]], [cellPosition[0], cellPosition[1] + i])))
                        {
                            CreateDot([cellPosition[0], cellPosition[1] + i]);
                        }
                    }
                    else
                    {
                        break;
                    }

                }
                if ((occupiedTiles.Any(p => p.SequenceEqual([cellPosition[0] - 1, cellPosition[1] + 1]))) && tableLayoutPanel1.GetControlFromPosition(cellPosition[0] - 1, cellPosition[1] + 1).Tag.ToString()[0] == 'W')
                {
                    if (!(IsGonnaCheck(BlackKing, [cellPosition[0], cellPosition[1]], [cellPosition[0] - 1, cellPosition[1] + 1])))
                    {
                        tableLayoutPanel1.GetControlFromPosition(cellPosition[0] - 1, cellPosition[1] + 1).BackColor = Color.Red;
                        piecesInDanger.Add([cellPosition[0] - 1, cellPosition[1] + 1]);
                    }
                }
                if ((occupiedTiles.Any(p => p.SequenceEqual([cellPosition[0] + 1, cellPosition[1] + 1]))) && tableLayoutPanel1.GetControlFromPosition(cellPosition[0] + 1, cellPosition[1] + 1).Tag.ToString()[0] == 'W')
                {
                    if (!(IsGonnaCheck(BlackKing, [cellPosition[0], cellPosition[1]], [cellPosition[0] + 1, cellPosition[1] + 1])))
                    {
                        tableLayoutPanel1.GetControlFromPosition(cellPosition[0] + 1, cellPosition[1] + 1).BackColor = Color.Red;
                        piecesInDanger.Add([cellPosition[0] + 1, cellPosition[1] + 1]);
                    }
                }
                tableLayoutPanel1.ResumeLayout();
                return;
            }
            if (piece == "rook")
            {
                for (int i = 1; i < 8; i++)
                {
                    if (!(cellPosition[1] - i > -1))
                    {
                        break;
                    }
                    if (!(occupiedTiles.Any(p => p.SequenceEqual([cellPosition[0], cellPosition[1] - i]))))
                    {
                        if (!(IsGonnaCheck(king, [cellPosition[0], cellPosition[1]], [cellPosition[0], cellPosition[1] - i])))
                        {
                            CreateDot([cellPosition[0], cellPosition[1] - i]);
                        }
                    }
                    else
                    {
                        if (tableLayoutPanel1.GetControlFromPosition(cellPosition[0], cellPosition[1] - i).Tag.ToString()[0] != tableLayoutPanel1.GetControlFromPosition(cellPosition[0], cellPosition[1]).Tag.ToString()[0])
                        {
                            if (!(IsGonnaCheck(king, [cellPosition[0], cellPosition[1]], [cellPosition[0], cellPosition[1] - i])))
                            {
                                tableLayoutPanel1.GetControlFromPosition(cellPosition[0], cellPosition[1] - i).BackColor = Color.Red;
                                piecesInDanger.Add([cellPosition[0], cellPosition[1] - i]);
                            }
                        }
                        break;
                    }
                }
                for (int i = 1; i < 8; i++)
                {
                    if (!(cellPosition[1] + i < 8))
                    {
                        break;
                    }
                    if (!(occupiedTiles.Any(p => p.SequenceEqual([cellPosition[0], cellPosition[1] + i]))))
                    {
                        if (!(IsGonnaCheck(king, [cellPosition[0], cellPosition[1]], [cellPosition[0], cellPosition[1] + i])))
                        {
                            CreateDot([cellPosition[0], cellPosition[1] + i]);
                        }
                    }
                    else
                    {
                        if (tableLayoutPanel1.GetControlFromPosition(cellPosition[0], cellPosition[1] + i).Tag.ToString()[0] != tableLayoutPanel1.GetControlFromPosition(cellPosition[0], cellPosition[1]).Tag.ToString()[0])
                        {
                            if (!(IsGonnaCheck(king, [cellPosition[0], cellPosition[1]], [cellPosition[0], cellPosition[1] + i])))
                            {
                                tableLayoutPanel1.GetControlFromPosition(cellPosition[0], cellPosition[1] + i).BackColor = Color.Red;
                                piecesInDanger.Add([cellPosition[0], cellPosition[1] + i]);
                            }
                        }
                        break;
                    }
                }
                for (int i = 1; i < 8; i++)
                {
                    if (!(cellPosition[0] + i < 8))
                    {
                        break;
                    }
                    if (!(occupiedTiles.Any(p => p.SequenceEqual([cellPosition[0] + i, cellPosition[1]]))))
                    {
                        if (!(IsGonnaCheck(king, [cellPosition[0], cellPosition[1]], [cellPosition[0] + i, cellPosition[1]])))
                        {
                            CreateDot([cellPosition[0] + i, cellPosition[1]]);
                        }
                    }
                    else
                    {
                        if (tableLayoutPanel1.GetControlFromPosition(cellPosition[0] + i, cellPosition[1]).Tag.ToString()[0] != tableLayoutPanel1.GetControlFromPosition(cellPosition[0], cellPosition[1]).Tag.ToString()[0])
                        {
                            if (!(IsGonnaCheck(king, [cellPosition[0], cellPosition[1]], [cellPosition[0] + i, cellPosition[1]])))
                            {
                                tableLayoutPanel1.GetControlFromPosition(cellPosition[0] + i, cellPosition[1]).BackColor = Color.Red;
                                piecesInDanger.Add([cellPosition[0] + i, cellPosition[1]]);
                            }
                        }
                        break;
                    }
                }
                for (int i = 1; i < 8; i++)
                {
                    if (!(cellPosition[0] - i > -1))
                    {
                        break;
                    }
                    if (!(occupiedTiles.Any(p => p.SequenceEqual([cellPosition[0] - i, cellPosition[1]]))))
                    {
                        if (!(IsGonnaCheck(king, [cellPosition[0], cellPosition[1]], [cellPosition[0] - i, cellPosition[1]])))
                        {
                            CreateDot([cellPosition[0] - i, cellPosition[1]]);
                        }
                    }
                    else
                    {
                        if (tableLayoutPanel1.GetControlFromPosition(cellPosition[0] - i, cellPosition[1]).Tag.ToString()[0] != tableLayoutPanel1.GetControlFromPosition(cellPosition[0], cellPosition[1]).Tag.ToString()[0])
                        {
                            if (!(IsGonnaCheck(king, [cellPosition[0], cellPosition[1]], [cellPosition[0] - i, cellPosition[1]])))
                            {
                                tableLayoutPanel1.GetControlFromPosition(cellPosition[0] - i, cellPosition[1]).BackColor = Color.Red;
                                piecesInDanger.Add([cellPosition[0] - i, cellPosition[1]]);
                            }
                        }
                        break;
                    }
                }
                tableLayoutPanel1.ResumeLayout();
                return;
            }
            if (piece == "knight")
            {
                if ((cellPosition[0] + 2 < 8) && (cellPosition[1] - 1 > -1))
                {
                    if (!(occupiedTiles.Any(p => p.SequenceEqual([cellPosition[0] + 2, cellPosition[1] - 1]))))
                    {
                        if (!(IsGonnaCheck(king, [cellPosition[0], cellPosition[1]], [cellPosition[0] + 2, cellPosition[1] - 1])))
                        {
                            CreateDot([cellPosition[0] + 2, cellPosition[1] - 1]);
                        }
                    }
                    else if (tableLayoutPanel1.GetControlFromPosition(cellPosition[0] + 2, cellPosition[1] - 1).Tag.ToString()[0] != control.Tag.ToString()[0])
                    {
                        if (!(IsGonnaCheck(king, [cellPosition[0], cellPosition[1]], [cellPosition[0] + 2, cellPosition[1] - 1])))
                        {
                            tableLayoutPanel1.GetControlFromPosition(cellPosition[0] + 2, cellPosition[1] - 1).BackColor = Color.Red;
                        }
                    }
                }
                if ((cellPosition[0] + 2 < 8) && (cellPosition[1] + 1 < 8))
                {
                    if (!(occupiedTiles.Any(p => p.SequenceEqual([cellPosition[0] + 2, cellPosition[1] + 1]))))
                    {
                        if (!(IsGonnaCheck(king, [cellPosition[0], cellPosition[1]], [cellPosition[0] + 2, cellPosition[1] + 1])))
                        {
                            CreateDot([cellPosition[0] + 2, cellPosition[1] + 1]);
                        }
                    }
                    else if (tableLayoutPanel1.GetControlFromPosition(cellPosition[0] + 2, cellPosition[1] + 1).Tag.ToString()[0] != control.Tag.ToString()[0])
                    {
                        if (!(IsGonnaCheck(king, [cellPosition[0], cellPosition[1]], [cellPosition[0] + 2, cellPosition[1] + 1])))
                        {
                            tableLayoutPanel1.GetControlFromPosition(cellPosition[0] + 2, cellPosition[1] + 1).BackColor = Color.Red;
                        }
                    }
                }
                if ((cellPosition[0] - 2 > -1) && (cellPosition[1] - 1 > -1))
                {
                    if (!(occupiedTiles.Any(p => p.SequenceEqual([cellPosition[0] - 2, cellPosition[1] - 1]))))
                    {
                        if (!(IsGonnaCheck(king, [cellPosition[0], cellPosition[1]], [cellPosition[0] - 2, cellPosition[1] - 1])))
                        {
                            CreateDot([cellPosition[0] - 2, cellPosition[1] - 1]);
                        }
                    }
                    else if (tableLayoutPanel1.GetControlFromPosition(cellPosition[0] - 2, cellPosition[1] - 1).Tag.ToString()[0] != control.Tag.ToString()[0])
                    {
                        if (!(IsGonnaCheck(king, [cellPosition[0], cellPosition[1]], [cellPosition[0] - 2, cellPosition[1] - 1])))
                        {
                            tableLayoutPanel1.GetControlFromPosition(cellPosition[0] - 2, cellPosition[1] - 1).BackColor = Color.Red;
                        }
                    }
                }
                if ((cellPosition[0] - 2 > -1) && (cellPosition[1] + 1 < 8))
                {
                    if (!(occupiedTiles.Any(p => p.SequenceEqual([cellPosition[0] - 2, cellPosition[1] + 1]))))
                    {
                        if (!(IsGonnaCheck(king, [cellPosition[0], cellPosition[1]], [cellPosition[0] - 2, cellPosition[1] + 1])))
                        {
                            CreateDot([cellPosition[0] - 2, cellPosition[1] + 1]);
                        }
                    }
                    else if (tableLayoutPanel1.GetControlFromPosition(cellPosition[0] - 2, cellPosition[1] + 1).Tag.ToString()[0] != control.Tag.ToString()[0])
                    {
                        if (!(IsGonnaCheck(king, [cellPosition[0], cellPosition[1]], [cellPosition[0] - 2, cellPosition[1] + 1])))
                        {
                            tableLayoutPanel1.GetControlFromPosition(cellPosition[0] - 2, cellPosition[1] + 1).BackColor = Color.Red;
                        }
                    }
                }
                if ((cellPosition[0] - 1 > -1) && (cellPosition[1] + 2 < 8))
                {
                    if (!(occupiedTiles.Any(p => p.SequenceEqual([cellPosition[0] - 1, cellPosition[1] + 2]))))
                    {
                        if (!(IsGonnaCheck(king, [cellPosition[0], cellPosition[1]], [cellPosition[0] - 1, cellPosition[1] + 2])))
                        {
                            CreateDot([cellPosition[0] - 1, cellPosition[1] + 2]);
                        }
                    }
                    else if (tableLayoutPanel1.GetControlFromPosition(cellPosition[0] - 1, cellPosition[1] + 2).Tag.ToString()[0] != control.Tag.ToString()[0])
                    {
                        if (!(IsGonnaCheck(king, [cellPosition[0], cellPosition[1]], [cellPosition[0] - 1, cellPosition[1] + 2])))
                        {
                            tableLayoutPanel1.GetControlFromPosition(cellPosition[0] - 1, cellPosition[1] + 2).BackColor = Color.Red;
                        }
                    }
                }
                if ((cellPosition[0] + 1 < 8) && (cellPosition[1] + 2 < 8))
                {
                    if (!(occupiedTiles.Any(p => p.SequenceEqual([cellPosition[0] + 1, cellPosition[1] + 2]))))
                    {
                        if (!(IsGonnaCheck(king, [cellPosition[0], cellPosition[1]], [cellPosition[0] + 1, cellPosition[1] + 2])))
                        {
                            CreateDot([cellPosition[0] + 1, cellPosition[1] + 2]);
                        }
                    }
                    else if (tableLayoutPanel1.GetControlFromPosition(cellPosition[0] + 1, cellPosition[1] + 2).Tag.ToString()[0] != control.Tag.ToString()[0])
                    {
                        if (!(IsGonnaCheck(king, [cellPosition[0], cellPosition[1]], [cellPosition[0] + 1, cellPosition[1] + 2])))
                        {
                            tableLayoutPanel1.GetControlFromPosition(cellPosition[0] + 1, cellPosition[1] + 2).BackColor = Color.Red;
                        }
                    }
                }
                if ((cellPosition[0] - 1 > -1) && (cellPosition[1] - 2 > -1))
                {
                    if (!(occupiedTiles.Any(p => p.SequenceEqual([cellPosition[0] - 1, cellPosition[1] - 2]))))
                    {
                        if (!(IsGonnaCheck(king, [cellPosition[0], cellPosition[1]], [cellPosition[0] - 1, cellPosition[1] - 2])))
                        {
                            CreateDot([cellPosition[0] - 1, cellPosition[1] - 2]);
                        }
                    }
                    else if (tableLayoutPanel1.GetControlFromPosition(cellPosition[0] - 1, cellPosition[1] - 2).Tag.ToString()[0] != control.Tag.ToString()[0])
                    {
                        if (!(IsGonnaCheck(king, [cellPosition[0], cellPosition[1]], [cellPosition[0] - 1, cellPosition[1] - 2])))
                        {
                            tableLayoutPanel1.GetControlFromPosition(cellPosition[0] - 1, cellPosition[1] - 2).BackColor = Color.Red;
                        }
                    }
                }
                if ((cellPosition[0] + 1 < 8) && (cellPosition[1] - 2 > -1))
                {
                    if (!(occupiedTiles.Any(p => p.SequenceEqual([cellPosition[0] + 1, cellPosition[1] - 2]))))
                    {
                        if (!(IsGonnaCheck(king, [cellPosition[0], cellPosition[1]], [cellPosition[0] + 1, cellPosition[1] - 2])))
                        {
                            CreateDot([cellPosition[0] + 1, cellPosition[1] - 2]);
                        }
                    }
                    else if (tableLayoutPanel1.GetControlFromPosition(cellPosition[0] + 1, cellPosition[1] - 2).Tag.ToString()[0] != control.Tag.ToString()[0])
                    {
                        if (!(IsGonnaCheck(king, [cellPosition[0], cellPosition[1]], [cellPosition[0] + 1, cellPosition[1] - 2])))
                        {
                            tableLayoutPanel1.GetControlFromPosition(cellPosition[0] + 1, cellPosition[1] - 2).BackColor = Color.Red;
                        }
                    }
                }
                tableLayoutPanel1.ResumeLayout();
                return;
            }
            if (piece == "bishop")
            {
                for (int i = 1; i < 8; i++)
                {
                    if ((cellPosition[0] + i < 8) && (cellPosition[1] + i < 8))
                    {
                        if (!(occupiedTiles.Any(p => p.SequenceEqual([cellPosition[0] + i, cellPosition[1] + i]))))
                        {
                            if (!(IsGonnaCheck(king, [cellPosition[0], cellPosition[1]], [cellPosition[0] + i, cellPosition[1] + i])))
                            {
                                CreateDot([cellPosition[0] + i, cellPosition[1] + i]);
                            }
                        }
                        else
                        {
                            if (tableLayoutPanel1.GetControlFromPosition(cellPosition[0] + i, cellPosition[1] + i).Tag.ToString()[0] != control.Tag.ToString()[0])
                            {
                                if (!(IsGonnaCheck(king, [cellPosition[0], cellPosition[1]], [cellPosition[0] + i, cellPosition[1] + i])))
                                {
                                    tableLayoutPanel1.GetControlFromPosition(cellPosition[0] + i, cellPosition[1] + i).BackColor = Color.Red;
                                    piecesInDanger.Add([cellPosition[0] + i, cellPosition[1] + i]);
                                    break;
                                }
                            }
                            break;
                        }
                    }
                    else { break; }
                }
                for (int i = 1; i < 8; i++)
                {
                    if ((cellPosition[0] + i < 8) && (cellPosition[1] - i > -1))
                    {
                        if (!(occupiedTiles.Any(p => p.SequenceEqual([cellPosition[0] + i, cellPosition[1] - i]))))
                        {
                            if (!(IsGonnaCheck(king, [cellPosition[0], cellPosition[1]], [cellPosition[0] + i, cellPosition[1] - i])))
                            {
                                CreateDot([cellPosition[0] + i, cellPosition[1] - i]);
                            }
                        }
                        else
                        {
                            if (tableLayoutPanel1.GetControlFromPosition(cellPosition[0] + i, cellPosition[1] - i).Tag.ToString()[0] != control.Tag.ToString()[0])
                            {
                                if (!(IsGonnaCheck(king, [cellPosition[0], cellPosition[1]], [cellPosition[0] + i, cellPosition[1] - i])))
                                {
                                    tableLayoutPanel1.GetControlFromPosition(cellPosition[0] + i, cellPosition[1] - i).BackColor = Color.Red;
                                    piecesInDanger.Add([cellPosition[0] + i, cellPosition[1] - i]);
                                    break;
                                }
                            }
                            break;
                        }
                    }
                    else { break; }
                }
                for (int i = 1; i < 8; i++)
                {
                    if ((cellPosition[0] - i > -1) && (cellPosition[1] + i < 8))
                    {
                        if (!(occupiedTiles.Any(p => p.SequenceEqual([cellPosition[0] - i, cellPosition[1] + i]))))
                        {
                            if (!(IsGonnaCheck(king, [cellPosition[0], cellPosition[1]], [cellPosition[0] - i, cellPosition[1] + i])))
                            {
                                CreateDot([cellPosition[0] - i, cellPosition[1] + i]);
                            }
                        }
                        else
                        {
                            if (tableLayoutPanel1.GetControlFromPosition(cellPosition[0] - i, cellPosition[1] + i).Tag.ToString()[0] != control.Tag.ToString()[0])
                            {
                                if (!(IsGonnaCheck(king, [cellPosition[0], cellPosition[1]], [cellPosition[0] - i, cellPosition[1] + i])))
                                {
                                    tableLayoutPanel1.GetControlFromPosition(cellPosition[0] - i, cellPosition[1] + i).BackColor = Color.Red;
                                    piecesInDanger.Add([cellPosition[0] - i, cellPosition[1] + i]);
                                    break;
                                }
                            }
                            break;
                        }
                    }
                    else { break; }
                }
                for (int i = 1; i < 8; i++)
                {
                    if ((cellPosition[0] - i > -1) && (cellPosition[1] - i > -1))
                    {
                        if (!(occupiedTiles.Any(p => p.SequenceEqual([cellPosition[0] - i, cellPosition[1] - i]))))
                        {
                            if (!(IsGonnaCheck(king, [cellPosition[0], cellPosition[1]], [cellPosition[0] - i, cellPosition[1] - i])))
                            {
                                CreateDot([cellPosition[0] - i, cellPosition[1] - i]);
                            }
                        }
                        else
                        {
                            if (tableLayoutPanel1.GetControlFromPosition(cellPosition[0] - i, cellPosition[1] - i).Tag.ToString()[0] != control.Tag.ToString()[0])
                            {
                                if (!(IsGonnaCheck(king, [cellPosition[0], cellPosition[1]], [cellPosition[0] - i, cellPosition[1] - i])))
                                {
                                    tableLayoutPanel1.GetControlFromPosition(cellPosition[0] - i, cellPosition[1] - i).BackColor = Color.Red;
                                    piecesInDanger.Add([cellPosition[0] - i, cellPosition[1] - i]);
                                    break;
                                }
                            }
                            break;
                        }
                    }
                    else { break; }
                }
                tableLayoutPanel1.ResumeLayout();
                return;
            }
            if (piece == "queen")
            {
                ClickingPiece("rook", cellPosition);
                noDeleting = true;
                ClickingPiece("bishop", cellPosition);
                tableLayoutPanel1.ResumeLayout();
                return;
            }
            if (piece == "king")
            {
                for (int i = -1; i < 2; i++)
                {
                    for (int j = -1; j < 2; j++)
                    {
                        if ((cellPosition[0] + i > -1) && (cellPosition[1] + j > -1) && (cellPosition[0] + i < 8) && (cellPosition[1] + j < 8))
                        {
                            if (!(occupiedTiles.Any(p => p.SequenceEqual([cellPosition[0] + i, cellPosition[1] + j]))))
                            {
                                if (!(IsGonnaCheck(king, [cellPosition[0], cellPosition[1]], [cellPosition[0] + i, cellPosition[1] + j])))
                                {
                                    CreateDot([cellPosition[0] + i, cellPosition[1] + j]);
                                }
                            }
                            else
                            {
                                if (tableLayoutPanel1.GetControlFromPosition(cellPosition[0] + i, cellPosition[1] + j).Tag.ToString()[0] != control.Tag.ToString()[0])
                                {
                                    if (!(IsGonnaCheck(king, [cellPosition[0], cellPosition[1]], [cellPosition[0] + i, cellPosition[1] + j])))
                                    {
                                        tableLayoutPanel1.GetControlFromPosition(cellPosition[0] + i, cellPosition[1] + j).BackColor = Color.Red;
                                        piecesInDanger.Add([cellPosition[0] + i, cellPosition[1] + j]);
                                    }
                                }
                            }
                        }
                    }
                }
                tableLayoutPanel1.ResumeLayout();
                return;
            }
        }
        public void IsCheckmate(Control king, int[] cellPosition)
        {
            List<checkingPiece> realCheckingPieces = checkingPieces;
            char kingColor = king.Tag.ToString()[0];
            king.BackColor = Color.Red;
            Control realClickedPiece = clickedPiece;
            switch (realCheckingPieces.Count)
            {
                case 1:
                    if (CanTake(realCheckingPieces[0].Place, cellPosition))
                    {
                        return;
                    }
                    for (int i = -1; i < 2; i++)
                    {
                        for (int j = -1; j < 2; j++)
                        {
                            if ((cellPosition[0] + i > -1) && (cellPosition[1] + j > -1) && (cellPosition[0] + i < 8) && (cellPosition[1] + j < 8))
                            {
                                if (!(occupiedTiles.Any(p => p.SequenceEqual([cellPosition[0] + i, cellPosition[1] + j]))))
                                {
                                    clickedPiece = king;
                                    if (!(IsGonnaCheck(king, [cellPosition[0], cellPosition[1]], [cellPosition[0] + i, cellPosition[1] + j])))
                                    {
                                        clickedPiece = realClickedPiece;
                                        return;
                                    }
                                    clickedPiece = realClickedPiece;
                                }
                                else
                                {
                                    if (tableLayoutPanel1.GetControlFromPosition(cellPosition[0] + i, cellPosition[1] + j).Tag.ToString()[0] != kingColor)
                                    {
                                        clickedPiece = king;
                                        if (!(IsGonnaCheck(king, [cellPosition[0], cellPosition[1]], [cellPosition[0] + i, cellPosition[1] + j])))
                                        {
                                            clickedPiece = realClickedPiece;
                                            return;
                                        }
                                        clickedPiece = realClickedPiece;
                                    }
                                }
                            }
                        }
                    }
                    if (realCheckingPieces[0].Piece == 'H')
                    {
                        //break;
                        for (int i = -1; i < 2; i++)
                        {
                            for (int j = -1; j < 2; j++)
                            {
                                if ((cellPosition[0] + i > -1) && (cellPosition[1] + j > -1) && (cellPosition[0] + i < 8) && (cellPosition[1] + j < 8))
                                {
                                    if (!(occupiedTiles.Any(p => p.SequenceEqual([cellPosition[0] + i, cellPosition[1] + j]))))
                                    {
                                        if (!(IsGonnaCheck(king, [cellPosition[0], cellPosition[1]], [cellPosition[0] + i, cellPosition[1] + j])))
                                        {
                                            return;
                                        }
                                    }
                                    else
                                    {
                                        if (tableLayoutPanel1.GetControlFromPosition(cellPosition[0] + i, cellPosition[1] + j).Tag.ToString()[0] != kingColor)
                                        {
                                            if (!(IsGonnaCheck(king, [cellPosition[0], cellPosition[1]], [cellPosition[0] + i, cellPosition[1] + j])))
                                            {
                                                return;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    if (realCheckingPieces[0].Piece == 'R' ^ realCheckingPieces[0].Piece == 'Q')
                    {
                        if (cellPosition[0] == realCheckingPieces[0].Place[0])
                        {
                            if (cellPosition[1] < realCheckingPieces[0].Place[1])
                            {
                                for (int i = 1; cellPosition[1] + i < realCheckingPieces[0].Place[1]; i++)
                                {
                                    if (CanBlock([cellPosition[0], cellPosition[1] + i], kingColor))
                                    {
                                        return;
                                    }
                                }
                            }
                            else
                                for (int i = 1; cellPosition[1] - i > realCheckingPieces[0].Place[1]; i++)
                                {
                                    if (CanBlock([cellPosition[0], cellPosition[1] - i], kingColor))
                                    {
                                        return;
                                    }
                                }
                        }
                        else if (cellPosition[1] == realCheckingPieces[0].Place[1])
                        {
                            if (cellPosition[0] < realCheckingPieces[0].Place[0])
                            {
                                for (int i = 1; cellPosition[0] + i < realCheckingPieces[0].Place[0]; i++)
                                {
                                    if (CanBlock([cellPosition[0] + i, cellPosition[1]], kingColor))
                                    {
                                        return;
                                    }
                                }
                            }
                            else
                                for (int i = 1; cellPosition[0] - i > realCheckingPieces[0].Place[0]; i++)
                                {
                                    if (CanBlock([cellPosition[0] - i, cellPosition[1]], kingColor))
                                    {
                                        return;
                                    }
                                }
                        }
                    }
                    if (realCheckingPieces[0].Piece == 'B' ^ realCheckingPieces[0].Piece == 'Q')
                    {
                        if (cellPosition[0] < realCheckingPieces[0].Place[0])
                        {
                            if (cellPosition[1] < realCheckingPieces[0].Place[1])
                            {
                                for (int i = 1; i < realCheckingPieces[0].Place[1] - cellPosition[1]; i++)
                                {
                                    if (CanBlock([cellPosition[0] + i, cellPosition[1] + i], kingColor))
                                    {
                                        return;
                                    }
                                }
                            }
                            else
                            {
                                for (int i = 1; i < realCheckingPieces[0].Place[0] - cellPosition[0]; i++)
                                {
                                    if (CanBlock([cellPosition[0] + i, cellPosition[1] - i], kingColor))
                                    {
                                        return;
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (cellPosition[1] > realCheckingPieces[0].Place[1])
                            {
                                for (int i = 1; i < cellPosition[1] - realCheckingPieces[0].Place[1]; i++)
                                {
                                    if (CanBlock([cellPosition[0] - i, cellPosition[1] - i], kingColor))
                                    {
                                        return;
                                    }
                                }
                            }
                            else
                            {
                                for (int i = 1; i < cellPosition[0] - realCheckingPieces[0].Place[0]; i++)
                                {
                                    if (CanBlock([cellPosition[0] - i, cellPosition[1] + i], kingColor))
                                    {
                                        return;
                                    }
                                }
                            }
                        }

                    }
                    if (realCheckingPieces[0].Piece == 'P')
                    {
                        clickedPiece = king;
                        if (!(IsGonnaCheck(king, cellPosition, realCheckingPieces[0].Place)))
                        {
                            clickedPiece = realClickedPiece;
                            return;
                        }
                        clickedPiece = realClickedPiece;
                    }
                    break;
                default:
                    for (int i = -1; i < 2; i++)
                    {
                        for (int j = -1; j < 2; j++)
                        {
                            if ((cellPosition[0] + i > -1) && (cellPosition[1] + j > -1) && (cellPosition[0] + i < 8) && (cellPosition[1] + j < 8))
                            {
                                if (!(occupiedTiles.Any(p => p.SequenceEqual([cellPosition[0] + i, cellPosition[1] + j]))))
                                {
                                    if (!(IsGonnaCheck(king, [cellPosition[0], cellPosition[1]], [cellPosition[0] + i, cellPosition[1] + j])))
                                    {
                                        return;
                                    }
                                }
                                else
                                {
                                    if (tableLayoutPanel1.GetControlFromPosition(cellPosition[0] + i, cellPosition[1] + j).Tag.ToString()[0] != kingColor)
                                    {
                                        if (!(IsGonnaCheck(king, [cellPosition[0], cellPosition[1]], [cellPosition[0] + i, cellPosition[1] + j])))
                                        {
                                            return;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    break;
            }
            label1.Text = "CheckMate";
            //Shakki Matti
        }
        public bool CanBlock(int[] position, char color)
        {
            char kingColor = color;
            if (color == 'W')
            {
                kingColor = 'B';
            }
            else
            {
                kingColor = 'W';
            }
            char[] controlCharArray = [];
            checkingPieces = new List<checkingPiece>();
            if ((position[0] + 2 < 8) && (position[1] - 1 > -1) && (tableLayoutPanel1.GetControlFromPosition(position[0] + 2, position[1] - 1) != null))
            {
                controlCharArray = tableLayoutPanel1.GetControlFromPosition(position[0] + 2, position[1] - 1).Tag.ToString().ToCharArray();
                if (controlCharArray[0] != kingColor && controlCharArray[1] == 'H')
                {
                    return true;
                }
            }
            if ((position[0] + 2 < 8) && (position[1] + 1 < 8) && (tableLayoutPanel1.GetControlFromPosition(position[0] + 2, position[1] + 1) != null))
            {
                controlCharArray = tableLayoutPanel1.GetControlFromPosition(position[0] + 2, position[1] + 1).Tag.ToString().ToCharArray();
                if (controlCharArray[0] != kingColor && controlCharArray[1] == 'H')
                {
                    return true;
                }
            }
            if ((position[0] - 2 > -1) && (position[1] - 1 > -1) && (tableLayoutPanel1.GetControlFromPosition(position[0] - 2, position[1] - 1) != null))
            {
                controlCharArray = tableLayoutPanel1.GetControlFromPosition(position[0] - 2, position[1] - 1).Tag.ToString().ToCharArray();
                if (controlCharArray[0] != kingColor && controlCharArray[1] == 'H')
                {
                    return true;
                }
            }

            if ((position[0] - 2 > -1) && (position[1] + 1 < 8) && (tableLayoutPanel1.GetControlFromPosition(position[0] - 2, position[1] + 1) != null))
            {
                controlCharArray = tableLayoutPanel1.GetControlFromPosition(position[0] - 2, position[1] + 1).Tag.ToString().ToCharArray();
                if (controlCharArray[0] != kingColor && controlCharArray[1] == 'H')
                {
                    return true;
                }
            }
            if ((position[0] - 1 > -1) && (position[1] + 2 < 8) && (tableLayoutPanel1.GetControlFromPosition(position[0] - 1, position[1] + 2) != null))
            {
                controlCharArray = tableLayoutPanel1.GetControlFromPosition(position[0] - 1, position[1] + 2).Tag.ToString().ToCharArray();
                if (controlCharArray[0] != kingColor && controlCharArray[1] == 'H')
                {
                    return true;
                }
            }

            if ((position[0] + 1 < 8) && (position[1] + 2 < 8) && (tableLayoutPanel1.GetControlFromPosition(position[0] + 1, position[1] + 2) != null))
            {
                controlCharArray = tableLayoutPanel1.GetControlFromPosition(position[0] + 1, position[1] + 2).Tag.ToString().ToCharArray();
                if (controlCharArray[0] != kingColor && controlCharArray[1] == 'H')
                {
                    return true;
                }
            }
            if ((position[0] - 1 > -1) && (position[1] - 2 > -1) && (tableLayoutPanel1.GetControlFromPosition(position[0] - 1, position[1] - 2) != null))
            {
                controlCharArray = tableLayoutPanel1.GetControlFromPosition(position[0] - 1, position[1] - 2).Tag.ToString().ToCharArray();
                if (controlCharArray[0] != kingColor && controlCharArray[1] == 'H')
                {
                    return true;
                }
            }
            if ((position[0] + 1 < 8) && (position[1] - 2 > -1) && (tableLayoutPanel1.GetControlFromPosition(position[0] + 1, position[1] - 2) != null))
            {
                controlCharArray = tableLayoutPanel1.GetControlFromPosition(position[0] + 1, position[1] - 2).Tag.ToString().ToCharArray();
                if (controlCharArray[0] != kingColor && controlCharArray[1] == 'H')
                {
                    return true;
                }
            } //aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa
            for (int i = 1; i < 8; i++)
            {
                if ((position[0] + i < 8) && (position[1] + i < 8))
                {
                    if (!(occupiedTiles.Any(p => p.SequenceEqual([position[0] + i, position[1] + i]))))
                    {
                        continue;
                    }
                    controlCharArray = tableLayoutPanel1.GetControlFromPosition(position[0] + i, position[1] + i).Tag.ToString().ToCharArray();
                    if (controlCharArray[0] != kingColor && (controlCharArray[1] == 'B' ^ controlCharArray[1] == 'Q'))
                    {
                        return true;
                    }
                    else break;
                }
                else { break; }
            }
            for (int i = 1; i < 8; i++)
            {
                if ((position[0] + i < 8) && (position[1] - i > -1))
                {
                    if (!(occupiedTiles.Any(p => p.SequenceEqual([position[0] + i, position[1] - i]))))
                    {
                        continue;
                    }
                    controlCharArray = tableLayoutPanel1.GetControlFromPosition(position[0] + i, position[1] - i).Tag.ToString().ToCharArray();
                    if (controlCharArray[0] != kingColor && (controlCharArray[1] == 'B' ^ controlCharArray[1] == 'Q'))
                    {
                        return true;
                    }
                    else break;
                }
                else { break; }
            }
            for (int i = 1; i < 8; i++)
            {
                if ((position[0] - i > -1) && (position[1] + i < 8))
                {
                    if (!(occupiedTiles.Any(p => p.SequenceEqual([position[0] - i, position[1] + i]))))
                    {
                        continue;
                    }
                    controlCharArray = tableLayoutPanel1.GetControlFromPosition(position[0] - i, position[1] + i).Tag.ToString().ToCharArray();
                    if (controlCharArray[0] != kingColor && (controlCharArray[1] == 'B' ^ controlCharArray[1] == 'Q'))
                    {
                        return true;
                    }
                    else break;
                }
                else { break; }
            }
            for (int i = 1; i < 8; i++)
            {
                if ((position[0] - i > -1) && (position[1] - i > -1))
                {
                    if (!(occupiedTiles.Any(p => p.SequenceEqual([position[0] - i, position[1] - i]))))
                    {
                        continue;
                    }
                    controlCharArray = tableLayoutPanel1.GetControlFromPosition(position[0] - i, position[1] - i).Tag.ToString().ToCharArray();
                    if (controlCharArray[0] != kingColor && (controlCharArray[1] == 'B' ^ controlCharArray[1] == 'Q'))
                    {
                        return true;
                    }
                    else break;
                }
                else { break; }
            }//aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa
            for (int i = 1; i < 8; i++)
            {
                if (!(position[1] - i > -1))
                {
                    break;
                }
                if (!(occupiedTiles.Any(p => p.SequenceEqual([position[0], position[1] - i]))))
                {
                    continue;
                }
                if (tableLayoutPanel1.GetControlFromPosition(position[0], position[1] - i).Tag.ToString()[0] != kingColor && (tableLayoutPanel1.GetControlFromPosition(position[0], position[1] - i).Tag.ToString()[1] == 'R' ^ tableLayoutPanel1.GetControlFromPosition(position[0], position[1] - i).Tag.ToString()[1] == 'Q'))
                {
                    return true;
                }
                else break;
            }
            for (int i = 1; i < 8; i++)
            {
                if (!(position[1] + i < 8))
                {
                    break;
                }
                if (!(occupiedTiles.Any(p => p.SequenceEqual([position[0], position[1] + i]))))
                {
                    continue;
                }
                else
                {
                    if (tableLayoutPanel1.GetControlFromPosition(position[0], position[1] + i).Tag.ToString()[0] != kingColor && (tableLayoutPanel1.GetControlFromPosition(position[0], position[1] + i).Tag.ToString()[1] == 'R' ^ tableLayoutPanel1.GetControlFromPosition(position[0], position[1] + i).Tag.ToString()[1] == 'Q'))
                    {
                        return true;
                    }
                    break;
                }
            }
            for (int i = 1; i < 8; i++)
            {
                if (!(position[0] + i < 8))
                {
                    break;
                }
                if (!(occupiedTiles.Any(p => p.SequenceEqual([position[0] + i, position[1]]))))
                {
                    continue;
                }
                else
                {
                    if (tableLayoutPanel1.GetControlFromPosition(position[0] + i, position[1]).Tag.ToString()[0] != kingColor && (tableLayoutPanel1.GetControlFromPosition(position[0] + i, position[1]).Tag.ToString()[1] == 'R' ^ tableLayoutPanel1.GetControlFromPosition(position[0] + i, position[1]).Tag.ToString()[1] == 'Q'))
                    {
                        return true;
                    }
                    break;
                }
            }
            for (int i = 1; i < 8; i++)
            {
                if (!(position[0] - i > -1))
                {
                    break;
                }
                if (!(occupiedTiles.Any(p => p.SequenceEqual([position[0] - i, position[1]]))))
                {
                    continue;
                }
                else
                {
                    if (tableLayoutPanel1.GetControlFromPosition(position[0] - i, position[1]).Tag.ToString()[0] != kingColor && (tableLayoutPanel1.GetControlFromPosition(position[0] - i, position[1]).Tag.ToString()[1] == 'R' ^ tableLayoutPanel1.GetControlFromPosition(position[0] - i, position[1]).Tag.ToString()[1] == 'Q'))
                    {
                        return true;
                    }
                    break;
                }
            }
            if ((occupiedTiles.Any(p => p.SequenceEqual([position[0], position[1] - 1]))))
            {
                controlCharArray = tableLayoutPanel1.GetControlFromPosition(position[0], position[1] - 1).Tag.ToString().ToCharArray();
                if (controlCharArray[0] != kingColor && kingColor == 'W' && controlCharArray[1] == 'P')
                {
                    return true;
                }
            }
            if ((occupiedTiles.Any(p => p.SequenceEqual([position[0], position[1] - 2]))) && position[1] == 1)
            {
                controlCharArray = tableLayoutPanel1.GetControlFromPosition(position[0], position[1] - 2).Tag.ToString().ToCharArray();
                if (controlCharArray[0] != kingColor && kingColor == 'W' && controlCharArray[1] == 'P')
                {
                    return true;
                }
            }
            if ((occupiedTiles.Any(p => p.SequenceEqual([position[0], position[1] + 1]))))
            {
                controlCharArray = tableLayoutPanel1.GetControlFromPosition(position[0], position[1] + 1).Tag.ToString().ToCharArray();
                if (controlCharArray[0] != kingColor && kingColor == 'B' && controlCharArray[1] == 'P')
                {
                    return true;
                }
            }
            if ((occupiedTiles.Any(p => p.SequenceEqual([position[0], position[1] + 2]))) && position[1] == 6)
            {
                controlCharArray = tableLayoutPanel1.GetControlFromPosition(position[0], position[1] + 2).Tag.ToString().ToCharArray();
                if (controlCharArray[0] != kingColor && kingColor == 'B' && controlCharArray[1] == 'P')
                {
                    return true;
                }
            }
            if (checkingPieces.Count > 0)
            {
                return true;
            }
            return false;
        }
        public bool CanTake(int[] kingCellPosition, int[] realKingPosition)
        {
            Control king = tableLayoutPanel1.GetControlFromPosition(kingCellPosition[0], kingCellPosition[1]);
            Control realKing = tableLayoutPanel1.GetControlFromPosition(realKingPosition[0], realKingPosition[1]);
            char kingColor = king.Name.ToCharArray()[0];
            char[] controlCharArray = [];
            checkingPieces = new List<checkingPiece>();
            if ((kingCellPosition[0] + 2 < 8) && (kingCellPosition[1] - 1 > -1) && (tableLayoutPanel1.GetControlFromPosition(kingCellPosition[0] + 2, kingCellPosition[1] - 1) != null))
            {
                controlCharArray = tableLayoutPanel1.GetControlFromPosition(kingCellPosition[0] + 2, kingCellPosition[1] - 1).Tag.ToString().ToCharArray();
                if (controlCharArray[0] != kingColor && controlCharArray[1] == 'H')
                {
                    if (IsGonnaCheck(realKing, kingCellPosition, [kingCellPosition[0] + 2, kingCellPosition[1] - 1]))
                    {
                        return true;
                    }
                }
            }
            if ((kingCellPosition[0] + 2 < 8) && (kingCellPosition[1] + 1 < 8) && (tableLayoutPanel1.GetControlFromPosition(kingCellPosition[0] + 2, kingCellPosition[1] + 1) != null))
            {
                controlCharArray = tableLayoutPanel1.GetControlFromPosition(kingCellPosition[0] + 2, kingCellPosition[1] + 1).Tag.ToString().ToCharArray();
                if (controlCharArray[0] != kingColor && controlCharArray[1] == 'H')
                {
                    if (IsGonnaCheck(realKing, kingCellPosition, [kingCellPosition[0] + 2, kingCellPosition[1] + 1]))
                    {
                        return true;
                    }
                }
            }
            if ((kingCellPosition[0] - 2 > -1) && (kingCellPosition[1] - 1 > -1) && (tableLayoutPanel1.GetControlFromPosition(kingCellPosition[0] - 2, kingCellPosition[1] - 1) != null))
            {
                controlCharArray = tableLayoutPanel1.GetControlFromPosition(kingCellPosition[0] - 2, kingCellPosition[1] - 1).Tag.ToString().ToCharArray();
                if (controlCharArray[0] != kingColor && controlCharArray[1] == 'H')
                {
                    if (IsGonnaCheck(realKing, kingCellPosition, [kingCellPosition[0] - 2, kingCellPosition[1] - 1]))
                    {
                        return true;
                    }
                }
            }

            if ((kingCellPosition[0] - 2 > -1) && (kingCellPosition[1] + 1 < 8) && (tableLayoutPanel1.GetControlFromPosition(kingCellPosition[0] - 2, kingCellPosition[1] + 1) != null))
            {
                controlCharArray = tableLayoutPanel1.GetControlFromPosition(kingCellPosition[0] - 2, kingCellPosition[1] + 1).Tag.ToString().ToCharArray();
                if (controlCharArray[0] != kingColor && controlCharArray[1] == 'H')
                {
                    if (IsGonnaCheck(realKing, kingCellPosition, [kingCellPosition[0] - 2, kingCellPosition[1] + 1]))
                    {
                        return true;
                    }
                }
            }
            if ((kingCellPosition[0] - 1 > -1) && (kingCellPosition[1] + 2 < 8) && (tableLayoutPanel1.GetControlFromPosition(kingCellPosition[0] - 1, kingCellPosition[1] + 2) != null))
            {
                controlCharArray = tableLayoutPanel1.GetControlFromPosition(kingCellPosition[0] - 1, kingCellPosition[1] + 2).Tag.ToString().ToCharArray();
                if (controlCharArray[0] != kingColor && controlCharArray[1] == 'H')
                {
                    if (IsGonnaCheck(realKing, kingCellPosition, [kingCellPosition[0] - 1, kingCellPosition[1] + 2]))
                    {
                        return true;
                    }
                }
            }

            if ((kingCellPosition[0] + 1 < 8) && (kingCellPosition[1] + 2 < 8) && (tableLayoutPanel1.GetControlFromPosition(kingCellPosition[0] + 1, kingCellPosition[1] + 2) != null))
            {
                controlCharArray = tableLayoutPanel1.GetControlFromPosition(kingCellPosition[0] + 1, kingCellPosition[1] + 2).Tag.ToString().ToCharArray();
                if (controlCharArray[0] != kingColor && controlCharArray[1] == 'H')
                {
                    if (IsGonnaCheck(realKing, kingCellPosition, [kingCellPosition[0] + 1, kingCellPosition[1] + 2]))
                    {
                        return true;
                    }
                }
            }
            if ((kingCellPosition[0] - 1 > -1) && (kingCellPosition[1] - 2 > -1) && (tableLayoutPanel1.GetControlFromPosition(kingCellPosition[0] - 1, kingCellPosition[1] - 2) != null))
            {
                controlCharArray = tableLayoutPanel1.GetControlFromPosition(kingCellPosition[0] - 1, kingCellPosition[1] - 2).Tag.ToString().ToCharArray();
                if (controlCharArray[0] != kingColor && controlCharArray[1] == 'H')
                {
                    if (IsGonnaCheck(realKing, kingCellPosition, [kingCellPosition[0] - 1, kingCellPosition[1] - 2]))
                    {
                        return true;
                    }
                }
            }
            if ((kingCellPosition[0] + 1 < 8) && (kingCellPosition[1] - 2 > -1) && (tableLayoutPanel1.GetControlFromPosition(kingCellPosition[0] + 1, kingCellPosition[1] - 2) != null))
            {
                controlCharArray = tableLayoutPanel1.GetControlFromPosition(kingCellPosition[0] + 1, kingCellPosition[1] - 2).Tag.ToString().ToCharArray();
                if (controlCharArray[0] != kingColor && controlCharArray[1] == 'H')
                {
                    if (IsGonnaCheck(realKing, kingCellPosition, [kingCellPosition[0] + 1, kingCellPosition[1] - 2]))
                    {
                        return true;
                    }
                }
            } //aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa
            for (int i = 1; i < 8; i++)
            {
                if ((kingCellPosition[0] + i < 8) && (kingCellPosition[1] + i < 8))
                {
                    if (!(occupiedTiles.Any(p => p.SequenceEqual([kingCellPosition[0] + i, kingCellPosition[1] + i]))))
                    {
                        continue;
                    }
                    controlCharArray = tableLayoutPanel1.GetControlFromPosition(kingCellPosition[0] + i, kingCellPosition[1] + i).Tag.ToString().ToCharArray();
                    if (controlCharArray[0] != kingColor && (controlCharArray[1] == 'B' ^ controlCharArray[1] == 'Q'))
                    {
                        if (IsGonnaCheck(realKing, kingCellPosition, [kingCellPosition[0] + i, kingCellPosition[1] + i]))
                        {
                            return true;
                        }
                        break;
                    }
                    else break;
                }
                else { break; }
            }
            for (int i = 1; i < 8; i++)
            {
                if ((kingCellPosition[0] + i < 8) && (kingCellPosition[1] - i > -1))
                {
                    if (!(occupiedTiles.Any(p => p.SequenceEqual([kingCellPosition[0] + i, kingCellPosition[1] - i]))))
                    {
                        continue;
                    }
                    controlCharArray = tableLayoutPanel1.GetControlFromPosition(kingCellPosition[0] + i, kingCellPosition[1] - i).Tag.ToString().ToCharArray();
                    if (controlCharArray[0] != kingColor && (controlCharArray[1] == 'B' ^ controlCharArray[1] == 'Q'))
                    {
                        if (IsGonnaCheck(realKing, kingCellPosition, [kingCellPosition[0] + i, kingCellPosition[1] - i]))
                        {
                            return true;
                        }
                        break;
                    }
                    else break;
                }
                else { break; }
            }
            for (int i = 1; i < 8; i++)
            {
                if ((kingCellPosition[0] - i > -1) && (kingCellPosition[1] + i < 8))
                {
                    if (!(occupiedTiles.Any(p => p.SequenceEqual([kingCellPosition[0] - i, kingCellPosition[1] + i]))))
                    {
                        continue;
                    }
                    controlCharArray = tableLayoutPanel1.GetControlFromPosition(kingCellPosition[0] - i, kingCellPosition[1] + i).Tag.ToString().ToCharArray();
                    if (controlCharArray[0] != kingColor && (controlCharArray[1] == 'B' ^ controlCharArray[1] == 'Q'))
                    {
                        if (IsGonnaCheck(realKing, kingCellPosition, [kingCellPosition[0] - i, kingCellPosition[1] + i]))
                        {
                            return true;
                        }
                        break;
                    }
                    else break;
                }
                else { break; }
            }
            for (int i = 1; i < 8; i++)
            {
                if ((kingCellPosition[0] - i > -1) && (kingCellPosition[1] - i > -1))
                {
                    if (!(occupiedTiles.Any(p => p.SequenceEqual([kingCellPosition[0] - i, kingCellPosition[1] - i]))))
                    {
                        continue;
                    }
                    controlCharArray = tableLayoutPanel1.GetControlFromPosition(kingCellPosition[0] - i, kingCellPosition[1] - i).Tag.ToString().ToCharArray();
                    if (controlCharArray[0] != kingColor && (controlCharArray[1] == 'B' ^ controlCharArray[1] == 'Q'))
                    {
                        if (IsGonnaCheck(realKing, kingCellPosition, [kingCellPosition[0] - i, kingCellPosition[1] - i]))
                        {
                            return true;
                        }
                        break;
                    }
                    else break;
                }
                else { break; }
            }//aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa
            for (int i = 1; i < 8; i++)
            {
                if (!(kingCellPosition[1] - i > -1))
                {
                    break;
                }
                if (!(occupiedTiles.Any(p => p.SequenceEqual([kingCellPosition[0], kingCellPosition[1] - i]))))
                {
                    continue;
                }
                if (tableLayoutPanel1.GetControlFromPosition(kingCellPosition[0], kingCellPosition[1] - i).Tag.ToString()[0] != kingColor && (tableLayoutPanel1.GetControlFromPosition(kingCellPosition[0], kingCellPosition[1] - i).Tag.ToString()[1] == 'R' ^ tableLayoutPanel1.GetControlFromPosition(kingCellPosition[0], kingCellPosition[1] - i).Tag.ToString()[1] == 'Q'))
                {
                    if (IsGonnaCheck(realKing, kingCellPosition, [kingCellPosition[0], kingCellPosition[1] - i]))
                    {
                        return true;
                    }
                    break;
                }
                else break;
            }
            for (int i = 1; i < 8; i++)
            {
                if (!(kingCellPosition[1] + i < 8))
                {
                    break;
                }
                if (!(occupiedTiles.Any(p => p.SequenceEqual([kingCellPosition[0], kingCellPosition[1] + i]))))
                {
                    continue;
                }
                else
                {
                    if (tableLayoutPanel1.GetControlFromPosition(kingCellPosition[0], kingCellPosition[1] + i).Tag.ToString()[0] != kingColor && (tableLayoutPanel1.GetControlFromPosition(kingCellPosition[0], kingCellPosition[1] + i).Tag.ToString()[1] == 'R' ^ tableLayoutPanel1.GetControlFromPosition(kingCellPosition[0], kingCellPosition[1] + i).Tag.ToString()[1] == 'Q'))
                    {
                        if (IsGonnaCheck(realKing, kingCellPosition, [kingCellPosition[0], kingCellPosition[1] + i]))
                        {
                            return true;
                        }
                        break;
                    }
                    break;
                }
            }
            for (int i = 1; i < 8; i++)
            {
                if (!(kingCellPosition[0] + i < 8))
                {
                    break;
                }
                if (!(occupiedTiles.Any(p => p.SequenceEqual([kingCellPosition[0] + i, kingCellPosition[1]]))))
                {
                    continue;
                }
                else
                {
                    if (tableLayoutPanel1.GetControlFromPosition(kingCellPosition[0] + i, kingCellPosition[1]).Tag.ToString()[0] != kingColor && (tableLayoutPanel1.GetControlFromPosition(kingCellPosition[0] + i, kingCellPosition[1]).Tag.ToString()[1] == 'R' ^ tableLayoutPanel1.GetControlFromPosition(kingCellPosition[0] + i, kingCellPosition[1]).Tag.ToString()[1] == 'Q'))
                    {
                        if (IsGonnaCheck(realKing, kingCellPosition, [kingCellPosition[0] + i, kingCellPosition[1] + i]))
                        {
                            return true;
                        }
                        break;
                    }
                    break;
                }
            }
            for (int i = 1; i < 8; i++)
            {
                if (!(kingCellPosition[0] - i > -1))
                {
                    break;
                }
                if (!(occupiedTiles.Any(p => p.SequenceEqual([kingCellPosition[0] - i, kingCellPosition[1]]))))
                {
                    continue;
                }
                else
                {
                    if (tableLayoutPanel1.GetControlFromPosition(kingCellPosition[0] - i, kingCellPosition[1]).Tag.ToString()[0] != kingColor && (tableLayoutPanel1.GetControlFromPosition(kingCellPosition[0] - i, kingCellPosition[1]).Tag.ToString()[1] == 'R' ^ tableLayoutPanel1.GetControlFromPosition(kingCellPosition[0] - i, kingCellPosition[1]).Tag.ToString()[1] == 'Q'))
                    {
                        if (IsGonnaCheck(realKing, kingCellPosition, [kingCellPosition[0] - i, kingCellPosition[1]]))
                        {
                            return true;
                        }
                        break;
                    }
                    break;
                }
            }
            if ((occupiedTiles.Any(p => p.SequenceEqual([kingCellPosition[0] + 1, kingCellPosition[1] + 1]))))
            {
                controlCharArray = tableLayoutPanel1.GetControlFromPosition(kingCellPosition[0] + 1, kingCellPosition[1] + 1).Tag.ToString().ToCharArray();
                if (controlCharArray[0] != kingColor && kingColor == 'B' && controlCharArray[1] == 'P')
                {
                    if (IsGonnaCheck(realKing, kingCellPosition, [kingCellPosition[0] + 1, kingCellPosition[1] + 1]))
                    {
                        return true;
                    }
                }
            }
            if ((occupiedTiles.Any(p => p.SequenceEqual([kingCellPosition[0] - 1, kingCellPosition[1] + 1]))))
            {
                controlCharArray = tableLayoutPanel1.GetControlFromPosition(kingCellPosition[0] - 1, kingCellPosition[1] + 1).Tag.ToString().ToCharArray();
                if (controlCharArray[0] != kingColor && kingColor == 'B' && controlCharArray[1] == 'P')
                {
                    if (IsGonnaCheck(realKing, kingCellPosition, [kingCellPosition[0] - 1, kingCellPosition[1] + 1]))
                    {
                        return true;
                    }
                }
            }
            if ((occupiedTiles.Any(p => p.SequenceEqual([kingCellPosition[0] + 1, kingCellPosition[1] - 1]))))
            {
                controlCharArray = tableLayoutPanel1.GetControlFromPosition(kingCellPosition[0] + 1, kingCellPosition[1] - 1).Tag.ToString().ToCharArray();
                if (controlCharArray[0] != kingColor && kingColor == 'W' && controlCharArray[1] == 'P')
                {
                    if (IsGonnaCheck(realKing, kingCellPosition, [kingCellPosition[0] + 1, kingCellPosition[1] - 1]))
                    {
                        return true;
                    }
                }
            }
            if ((occupiedTiles.Any(p => p.SequenceEqual([kingCellPosition[0] - 1, kingCellPosition[1] - 1]))))
            {
                controlCharArray = tableLayoutPanel1.GetControlFromPosition(kingCellPosition[0] - 1, kingCellPosition[1] - 1).Tag.ToString().ToCharArray();
                if (controlCharArray[0] != kingColor && kingColor == 'W' && controlCharArray[1] == 'P')
                {
                    if (IsGonnaCheck(realKing, kingCellPosition, [kingCellPosition[0] - 1, kingCellPosition[1] - 1]))
                    {
                        return true;
                    }
                }
            }
            if (checkingPieces.Count > 0)
            {
                return true;
            }
            return false;
        }
        public class checkingPiece
        {
            public int[] Place { get; set; }
            public char Piece { get; set; }
            public checkingPiece(char piece, int[] place)
            {
                Place = place;
                Piece = piece;
            }
        }
        public List<checkingPiece> checkingPieces = new List<checkingPiece>();
        public bool DidCheck(int[] kingCellPosition)
        {
            Control king = tableLayoutPanel1.GetControlFromPosition(kingCellPosition[0], kingCellPosition[1]);
            char kingColor = king.Name.ToCharArray()[0];
            char[] controlCharArray = [];
            checkingPieces = new List<checkingPiece>();
            if ((kingCellPosition[0] + 2 < 8) && (kingCellPosition[1] - 1 > -1) && (tableLayoutPanel1.GetControlFromPosition(kingCellPosition[0] + 2, kingCellPosition[1] - 1) != null))
            {
                controlCharArray = tableLayoutPanel1.GetControlFromPosition(kingCellPosition[0] + 2, kingCellPosition[1] - 1).Tag.ToString().ToCharArray();
                if (controlCharArray[0] != kingColor && controlCharArray[1] == 'H')
                {
                    checkingPieces.Add(new checkingPiece('H', [kingCellPosition[0] + 2, kingCellPosition[1] - 1]));
                }
            }
            if ((kingCellPosition[0] + 2 < 8) && (kingCellPosition[1] + 1 < 8) && (tableLayoutPanel1.GetControlFromPosition(kingCellPosition[0] + 2, kingCellPosition[1] + 1) != null))
            {
                controlCharArray = tableLayoutPanel1.GetControlFromPosition(kingCellPosition[0] + 2, kingCellPosition[1] + 1).Tag.ToString().ToCharArray();
                if (controlCharArray[0] != kingColor && controlCharArray[1] == 'H')
                {
                    checkingPieces.Add(new checkingPiece('H', [kingCellPosition[0] + 2, kingCellPosition[1] + 1]));
                }
            }
            if ((kingCellPosition[0] - 2 > -1) && (kingCellPosition[1] - 1 > -1) && (tableLayoutPanel1.GetControlFromPosition(kingCellPosition[0] - 2, kingCellPosition[1] - 1) != null))
            {
                controlCharArray = tableLayoutPanel1.GetControlFromPosition(kingCellPosition[0] - 2, kingCellPosition[1] - 1).Tag.ToString().ToCharArray();
                if (controlCharArray[0] != kingColor && controlCharArray[1] == 'H')
                {
                    checkingPieces.Add(new checkingPiece('H', [kingCellPosition[0] - 2, kingCellPosition[1] - 1]));
                }
            }

            if ((kingCellPosition[0] - 2 > -1) && (kingCellPosition[1] + 1 < 8) && (tableLayoutPanel1.GetControlFromPosition(kingCellPosition[0] - 2, kingCellPosition[1] + 1) != null))
            {
                controlCharArray = tableLayoutPanel1.GetControlFromPosition(kingCellPosition[0] - 2, kingCellPosition[1] + 1).Tag.ToString().ToCharArray();
                if (controlCharArray[0] != kingColor && controlCharArray[1] == 'H')
                {
                    checkingPieces.Add(new checkingPiece('H', [kingCellPosition[0] - 2, kingCellPosition[1] + 1]));
                }
            }
            if ((kingCellPosition[0] - 1 > -1) && (kingCellPosition[1] + 2 < 8) && (tableLayoutPanel1.GetControlFromPosition(kingCellPosition[0] - 1, kingCellPosition[1] + 2) != null))
            {
                controlCharArray = tableLayoutPanel1.GetControlFromPosition(kingCellPosition[0] - 1, kingCellPosition[1] + 2).Tag.ToString().ToCharArray();
                if (controlCharArray[0] != kingColor && controlCharArray[1] == 'H')
                {
                    checkingPieces.Add(new checkingPiece('H', [kingCellPosition[0] - 1, kingCellPosition[1] + 2]));
                }
            }

            if ((kingCellPosition[0] + 1 < 8) && (kingCellPosition[1] + 2 < 8) && (tableLayoutPanel1.GetControlFromPosition(kingCellPosition[0] + 1, kingCellPosition[1] + 2) != null))
            {
                controlCharArray = tableLayoutPanel1.GetControlFromPosition(kingCellPosition[0] + 1, kingCellPosition[1] + 2).Tag.ToString().ToCharArray();
                if (controlCharArray[0] != kingColor && controlCharArray[1] == 'H')
                {
                    checkingPieces.Add(new checkingPiece('H', [kingCellPosition[0] + 1, kingCellPosition[1] + 2]));
                }
            }
            if ((kingCellPosition[0] - 1 > -1) && (kingCellPosition[1] - 2 > -1) && (tableLayoutPanel1.GetControlFromPosition(kingCellPosition[0] - 1, kingCellPosition[1] - 2) != null))
            {
                controlCharArray = tableLayoutPanel1.GetControlFromPosition(kingCellPosition[0] - 1, kingCellPosition[1] - 2).Tag.ToString().ToCharArray();
                if (controlCharArray[0] != kingColor && controlCharArray[1] == 'H')
                {
                    checkingPieces.Add(new checkingPiece('H', [kingCellPosition[0] - 1, kingCellPosition[1] - 2]));
                }
            }
            if ((kingCellPosition[0] + 1 < 8) && (kingCellPosition[1] - 2 > -1) && (tableLayoutPanel1.GetControlFromPosition(kingCellPosition[0] + 1, kingCellPosition[1] - 2) != null))
            {
                controlCharArray = tableLayoutPanel1.GetControlFromPosition(kingCellPosition[0] + 1, kingCellPosition[1] - 2).Tag.ToString().ToCharArray();
                if (controlCharArray[0] != kingColor && controlCharArray[1] == 'H')
                {
                    checkingPieces.Add(new checkingPiece('H', [kingCellPosition[0] + 1, kingCellPosition[1] - 2]));
                }
            } //aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa
            for (int i = 1; i < 8; i++)
            {
                if ((kingCellPosition[0] + i < 8) && (kingCellPosition[1] + i < 8))
                {
                    if (!(occupiedTiles.Any(p => p.SequenceEqual([kingCellPosition[0] + i, kingCellPosition[1] + i]))))
                    {
                        continue;
                    }
                    controlCharArray = tableLayoutPanel1.GetControlFromPosition(kingCellPosition[0] + i, kingCellPosition[1] + i).Tag.ToString().ToCharArray();
                    if (controlCharArray[0] != kingColor && (controlCharArray[1] == 'B' ^ controlCharArray[1] == 'Q'))
                    {
                        checkingPieces.Add(new checkingPiece(controlCharArray[1], [kingCellPosition[0] + i, kingCellPosition[1] + i]));
                        break;
                    }
                    else break;
                }
                else { break; }
            }
            for (int i = 1; i < 8; i++)
            {
                if ((kingCellPosition[0] + i < 8) && (kingCellPosition[1] - i > -1))
                {
                    if (!(occupiedTiles.Any(p => p.SequenceEqual([kingCellPosition[0] + i, kingCellPosition[1] - i]))))
                    {
                        continue;
                    }
                    controlCharArray = tableLayoutPanel1.GetControlFromPosition(kingCellPosition[0] + i, kingCellPosition[1] - i).Tag.ToString().ToCharArray();
                    if (controlCharArray[0] != kingColor && (controlCharArray[1] == 'B' ^ controlCharArray[1] == 'Q'))
                    {
                        checkingPieces.Add(new checkingPiece(controlCharArray[1], [kingCellPosition[0] + i, kingCellPosition[1] - i]));
                        break;
                    }
                    else break;
                }
                else { break; }
            }
            for (int i = 1; i < 8; i++)
            {
                if ((kingCellPosition[0] - i > -1) && (kingCellPosition[1] + i < 8))
                {
                    if (!(occupiedTiles.Any(p => p.SequenceEqual([kingCellPosition[0] - i, kingCellPosition[1] + i]))))
                    {
                        continue;
                    }
                    controlCharArray = tableLayoutPanel1.GetControlFromPosition(kingCellPosition[0] - i, kingCellPosition[1] + i).Tag.ToString().ToCharArray();
                    if (controlCharArray[0] != kingColor && (controlCharArray[1] == 'B' ^ controlCharArray[1] == 'Q'))
                    {
                        checkingPieces.Add(new checkingPiece(controlCharArray[1], [kingCellPosition[0] - i, kingCellPosition[1] + i]));
                        break;
                    }
                    else break;
                }
                else { break; }
            }
            for (int i = 1; i < 8; i++)
            {
                if ((kingCellPosition[0] - i > -1) && (kingCellPosition[1] - i > -1))
                {
                    if (!(occupiedTiles.Any(p => p.SequenceEqual([kingCellPosition[0] - i, kingCellPosition[1] - i]))))
                    {
                        continue;
                    }
                    controlCharArray = tableLayoutPanel1.GetControlFromPosition(kingCellPosition[0] - i, kingCellPosition[1] - i).Tag.ToString().ToCharArray();
                    if (controlCharArray[0] != kingColor && (controlCharArray[1] == 'B' ^ controlCharArray[1] == 'Q'))
                    {
                        checkingPieces.Add(new checkingPiece(controlCharArray[1], [kingCellPosition[0] - i, kingCellPosition[1] - i]));
                        break;
                    }
                    else break;
                }
                else { break; }
            }//aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa
            for (int i = 1; i < 8; i++)
            {
                if (!(kingCellPosition[1] - i > -1))
                {
                    break;
                }
                if (!(occupiedTiles.Any(p => p.SequenceEqual([kingCellPosition[0], kingCellPosition[1] - i]))))
                {
                    continue;
                }
                controlCharArray = tableLayoutPanel1.GetControlFromPosition(kingCellPosition[0], kingCellPosition[1] - i).Tag.ToString().ToCharArray();
                if (tableLayoutPanel1.GetControlFromPosition(kingCellPosition[0], kingCellPosition[1] - i).Tag.ToString()[0] != kingColor && (tableLayoutPanel1.GetControlFromPosition(kingCellPosition[0], kingCellPosition[1] - i).Tag.ToString()[1] == 'R' ^ tableLayoutPanel1.GetControlFromPosition(kingCellPosition[0], kingCellPosition[1] - i).Tag.ToString()[1] == 'Q'))
                {
                    checkingPieces.Add(new checkingPiece(controlCharArray[1], [kingCellPosition[0], kingCellPosition[1] - i]));
                    break;
                }
                else break;
            }
            for (int i = 1; i < 8; i++)
            {
                if (!(kingCellPosition[1] + i < 8))
                {
                    break;
                }
                if (!(occupiedTiles.Any(p => p.SequenceEqual([kingCellPosition[0], kingCellPosition[1] + i]))))
                {
                    continue;
                }
                else
                {
                    controlCharArray = tableLayoutPanel1.GetControlFromPosition(kingCellPosition[0], kingCellPosition[1] + i).Tag.ToString().ToCharArray();
                    if (tableLayoutPanel1.GetControlFromPosition(kingCellPosition[0], kingCellPosition[1] + i).Tag.ToString()[0] != kingColor && (tableLayoutPanel1.GetControlFromPosition(kingCellPosition[0], kingCellPosition[1] + i).Tag.ToString()[1] == 'R' ^ tableLayoutPanel1.GetControlFromPosition(kingCellPosition[0], kingCellPosition[1] + i).Tag.ToString()[1] == 'Q'))
                    {
                        checkingPieces.Add(new checkingPiece(controlCharArray[1], [kingCellPosition[0], kingCellPosition[1] + i]));
                        break;
                    }
                    break;
                }
            }
            for (int i = 1; i < 8; i++)
            {
                if (!(kingCellPosition[0] + i < 8))
                {
                    break;
                }
                if (!(occupiedTiles.Any(p => p.SequenceEqual([kingCellPosition[0] + i, kingCellPosition[1]]))))
                {
                    continue;
                }
                else
                {
                    controlCharArray = tableLayoutPanel1.GetControlFromPosition(kingCellPosition[0] + i, kingCellPosition[1]).Tag.ToString().ToCharArray();
                    if (tableLayoutPanel1.GetControlFromPosition(kingCellPosition[0] + i, kingCellPosition[1]).Tag.ToString()[0] != kingColor && (tableLayoutPanel1.GetControlFromPosition(kingCellPosition[0] + i, kingCellPosition[1]).Tag.ToString()[1] == 'R' ^ tableLayoutPanel1.GetControlFromPosition(kingCellPosition[0] + i, kingCellPosition[1]).Tag.ToString()[1] == 'Q'))
                    {
                        checkingPieces.Add(new checkingPiece(controlCharArray[1], [kingCellPosition[0] + i, kingCellPosition[1]]));
                        break;
                    }
                    break;
                }
            }
            for (int i = 1; i < 8; i++)
            {
                if (!(kingCellPosition[0] - i > -1))
                {
                    break;
                }
                if (!(occupiedTiles.Any(p => p.SequenceEqual([kingCellPosition[0] - i, kingCellPosition[1]]))))
                {
                    continue;
                }
                else
                {
                    controlCharArray = tableLayoutPanel1.GetControlFromPosition(kingCellPosition[0] - i, kingCellPosition[1]).Tag.ToString().ToCharArray();
                    if (tableLayoutPanel1.GetControlFromPosition(kingCellPosition[0] - i, kingCellPosition[1]).Tag.ToString()[0] != kingColor && (tableLayoutPanel1.GetControlFromPosition(kingCellPosition[0] - i, kingCellPosition[1]).Tag.ToString()[1] == 'R' ^ tableLayoutPanel1.GetControlFromPosition(kingCellPosition[0] - i, kingCellPosition[1]).Tag.ToString()[1] == 'Q'))
                    {
                        checkingPieces.Add(new checkingPiece(controlCharArray[1], [kingCellPosition[0] - i, kingCellPosition[1]]));
                        break;
                    }
                    break;
                }
            }
            if ((occupiedTiles.Any(p => p.SequenceEqual([kingCellPosition[0] + 1, kingCellPosition[1] + 1]))))
            {
                controlCharArray = tableLayoutPanel1.GetControlFromPosition(kingCellPosition[0] + 1, kingCellPosition[1] + 1).Tag.ToString().ToCharArray();
                if (controlCharArray[0] != kingColor && kingColor == 'B' && controlCharArray[1] == 'P')
                {
                    checkingPieces.Add(new checkingPiece('P', [kingCellPosition[0] + 1, kingCellPosition[1] + 1]));
                }
            }
            if ((occupiedTiles.Any(p => p.SequenceEqual([kingCellPosition[0] - 1, kingCellPosition[1] + 1]))))
            {
                controlCharArray = tableLayoutPanel1.GetControlFromPosition(kingCellPosition[0] - 1, kingCellPosition[1] + 1).Tag.ToString().ToCharArray();
                if (controlCharArray[0] != kingColor && kingColor == 'B' && controlCharArray[1] == 'P')
                {
                    checkingPieces.Add(new checkingPiece('P', [kingCellPosition[0] - 1, kingCellPosition[1] + 1]));
                }
            }
            if ((occupiedTiles.Any(p => p.SequenceEqual([kingCellPosition[0] + 1, kingCellPosition[1] - 1]))))
            {
                controlCharArray = tableLayoutPanel1.GetControlFromPosition(kingCellPosition[0] + 1, kingCellPosition[1] - 1).Tag.ToString().ToCharArray();
                if (controlCharArray[0] != kingColor && kingColor == 'W' && controlCharArray[1] == 'P')
                {
                    checkingPieces.Add(new checkingPiece('P', [kingCellPosition[0] + 1, kingCellPosition[1] - 1]));
                }
            }
            if ((occupiedTiles.Any(p => p.SequenceEqual([kingCellPosition[0] - 1, kingCellPosition[1] - 1]))))
            {
                controlCharArray = tableLayoutPanel1.GetControlFromPosition(kingCellPosition[0] - 1, kingCellPosition[1] - 1).Tag.ToString().ToCharArray();
                if (controlCharArray[0] != kingColor && kingColor == 'W' && controlCharArray[1] == 'P')
                {
                    checkingPieces.Add(new checkingPiece('P', [kingCellPosition[0] - 1, kingCellPosition[1] - 1]));
                }
            }
            if (checkingPieces.Count > 0)
            {
                return true;
            }
            return false;
        }
        public bool IsGonnaCheck(Control king, int[] ogPosition, int[] movingPosition)
        {
            occupiedTiles.RemoveAll(s => s.SequenceEqual(ogPosition));
            if (tableLayoutPanel1.GetControlFromPosition(movingPosition[0], movingPosition[1]) != null)
            {
                Control attackedPiece = tableLayoutPanel1.GetControlFromPosition(movingPosition[0], movingPosition[1]);
                attackedPiece.Parent = null;
                tableLayoutPanel1.SetCellPosition(clickedPiece, new TableLayoutPanelCellPosition(movingPosition[0], movingPosition[1]));
                if (DidCheck([tableLayoutPanel1.GetColumn(king), tableLayoutPanel1.GetRow(king)]))
                {
                    occupiedTiles.Add(ogPosition);
                    tableLayoutPanel1.SetCellPosition(clickedPiece, new TableLayoutPanelCellPosition(ogPosition[0], ogPosition[1]));
                    attackedPiece.Parent = tableLayoutPanel1;
                    return true;
                }
                occupiedTiles.Add(ogPosition);
                tableLayoutPanel1.SetCellPosition(clickedPiece, new TableLayoutPanelCellPosition(ogPosition[0], ogPosition[1]));
                attackedPiece.Parent = tableLayoutPanel1;
                return false;
            }
            occupiedTiles.Add(movingPosition);
            tableLayoutPanel1.SetCellPosition(clickedPiece, new TableLayoutPanelCellPosition(movingPosition[0], movingPosition[1]));
            if (DidCheck([tableLayoutPanel1.GetColumn(king), tableLayoutPanel1.GetRow(king)]))
            {
                occupiedTiles.RemoveAll(s => s.SequenceEqual(movingPosition));
                occupiedTiles.Add(ogPosition);
                tableLayoutPanel1.SetCellPosition(clickedPiece, new TableLayoutPanelCellPosition(ogPosition[0], ogPosition[1]));
                return true;
            }
            occupiedTiles.RemoveAll(s => s.SequenceEqual(movingPosition));
            occupiedTiles.Add(ogPosition);
            tableLayoutPanel1.SetCellPosition(clickedPiece, new TableLayoutPanelCellPosition(ogPosition[0], ogPosition[1]));
            return false;
        }
        public void CreateDot(int[] Position)
        {
            PictureBox DotCopy = new PictureBox();
            DotCopy = new PictureBox();
            DotCopy.Name = "Dot" + dotNumber;
            DotCopy.Image = imageList1.Images[1];
            DotCopy.BackColor = Color.Transparent;
            DotCopy.SizeMode = PictureBoxSizeMode.CenterImage;
            DotCopy.Visible = true;
            DotCopy.Click += new EventHandler(DotMove);
            DotCopy.Tag = "XX";
            tableLayoutPanel1.Controls.Add(DotCopy);
            tableLayoutPanel1.SetCellPosition(DotCopy, new TableLayoutPanelCellPosition(Position[0], Position[1]));
            dotNumber++;

        }
        public void DotMove(object sender, EventArgs e)
        {
            Moving((Control)sender);
        }
        public void Moving(Control control)
        {
            IsInCheck = false;
            DeleteMoveSignals();
            char[] name = control.Name.ToCharArray();
            if ((name[0] == 'B' && isWhitesTurn) || (name[0] == 'W' && !isWhitesTurn))
            {
                tableLayoutPanel1.Controls.Remove(control); tableLayoutPanel1.Controls.Remove(control);
                occupiedTiles.RemoveAll(s => s.SequenceEqual([tableLayoutPanel1.GetCellPosition(clickedPiece).Column, tableLayoutPanel1.GetCellPosition(clickedPiece).Row]));
                tableLayoutPanel1.SetCellPosition(clickedPiece, tableLayoutPanel1.GetCellPosition(control)); tableLayoutPanel1.SetCellPosition(clickedPiece, tableLayoutPanel1.GetCellPosition(control));
            }
            else
            {
                occupiedTiles.RemoveAll(s => s.SequenceEqual([tableLayoutPanel1.GetCellPosition(clickedPiece).Column, tableLayoutPanel1.GetCellPosition(clickedPiece).Row]));
                tableLayoutPanel1.SetCellPosition(clickedPiece, tableLayoutPanel1.GetCellPosition(control)); tableLayoutPanel1.SetCellPosition(clickedPiece, tableLayoutPanel1.GetCellPosition(control));
                occupiedTiles.Add([tableLayoutPanel1.GetCellPosition(control).Column, tableLayoutPanel1.GetCellPosition(control).Row]);
            }
            if (!isWhitesTurn)
            {
                if (DidCheck([tableLayoutPanel1.GetColumn(WhiteKing), tableLayoutPanel1.GetRow(WhiteKing)]))
                {
                    IsInCheck = true;
                    WhiteKing.BackColor = Color.Red;
                    piecesInDanger.Add([tableLayoutPanel1.GetColumn(WhiteKing), tableLayoutPanel1.GetRow(WhiteKing)]);
                    IsCheckmate(WhiteKing, [tableLayoutPanel1.GetColumn(WhiteKing), tableLayoutPanel1.GetRow(WhiteKing)]);
                }
            }
            if (isWhitesTurn)
            {
                if (DidCheck([tableLayoutPanel1.GetColumn(BlackKing), tableLayoutPanel1.GetRow(BlackKing)]))
                {
                    IsInCheck = true;
                    BlackKing.BackColor = Color.Red;
                    piecesInDanger.Add([tableLayoutPanel1.GetColumn(BlackKing), tableLayoutPanel1.GetRow(BlackKing)]);
                    IsCheckmate(BlackKing, [tableLayoutPanel1.GetColumn(BlackKing), tableLayoutPanel1.GetRow(BlackKing)]);
                }
            }
            isWhitesTurn = !isWhitesTurn;

        }
        public void DeleteMoveSignals()
        {
            for (int i = 0; i < (dotNumber - dotHide);)
            {
                tableLayoutPanel1.Controls.Remove(tableLayoutPanel1.Controls.Find("Dot" + dotHide, false)[0]);
                dotHide++;
            }
            for (int i = 0; i < piecesInDanger.Count;)
            {
                tableLayoutPanel1.GetControlFromPosition(piecesInDanger[0][0], piecesInDanger[0][1]).BackColor = Color.Transparent;
                piecesInDanger.RemoveAt(0);
            }
        }
        private void WhiteKing_Click(object sender, EventArgs e)
        {
            if (!gameIsOn)
            {
                //foreach (Control i in tableLayoutPanel1.Controls)
                //{
                    //label1.Text += " ";
                    //label1.Text += tableLayoutPanel1.GetCellPosition(i).ToString();
                    //Console.WriteLine(i.Name);
                    //occupiedTiles.Add(tableLayoutPanel1.GetCellPosition(i));
                //}
            }
            if (isWhitesTurn)
            {
                clickedPiece = WhiteKing;
                ClickingPiece("king", [tableLayoutPanel1.GetColumn(WhiteKing), tableLayoutPanel1.GetRow(WhiteKing)]);
                return;
            }
            if ((!isWhitesTurn) && WhiteKing.BackColor == Color.Red)
            {
                Moving(WhiteKing);
                //Häviäs koko pelin
            }
        }
        private void WhiteQueen_Click(object sender, EventArgs e)
        {
            if (!gameIsOn)
            {
                return;
            }
            if (isWhitesTurn)
            {
                clickedPiece = WhiteQueen;
                ClickingPiece("queen", [tableLayoutPanel1.GetColumn(WhiteQueen), tableLayoutPanel1.GetRow(WhiteQueen)]);
                return;
            }
            if ((!isWhitesTurn) && WhiteQueen.BackColor == Color.Red)
            {
                Moving(WhiteQueen);
            }
        }

        private void WhiteKnight1_Click(object sender, EventArgs e)
        {
            if (!gameIsOn)
            {
                return;
            }
            if (isWhitesTurn)
            {
                clickedPiece = WhiteKnight1;
                ClickingPiece("knight", [tableLayoutPanel1.GetColumn(WhiteKnight1), tableLayoutPanel1.GetRow(WhiteKnight1)]);
                return;
            }
            if ((!isWhitesTurn) && WhiteKnight1.BackColor == Color.Red)
            {
                Moving(WhiteKnight1);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            gameIsOn = true;
            isWhitesTurn = true;
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
            if (!gameIsOn)
            {
                return;
            }
            if ((isWhitesTurn) && BlackPawn3.BackColor == Color.Red)
            {
                Moving(BlackPawn3);
                return;
            }
            if (!isWhitesTurn)
            {
                clickedPiece = BlackPawn3;
                ClickingPiece("b_pawn", [tableLayoutPanel1.GetColumn(BlackPawn3), tableLayoutPanel1.GetRow(BlackPawn3)]);
                return;
            }
        }

        private void WhitePawn3_Click(object sender, EventArgs e)
        {
            if (!gameIsOn)
            {
                return;
            }
            if (isWhitesTurn)
            {
                clickedPiece = WhitePawn3;
                ClickingPiece("w_pawn", [tableLayoutPanel1.GetColumn(WhitePawn3), tableLayoutPanel1.GetRow(WhitePawn3)]);
                return;
            }
            if ((!isWhitesTurn) && WhitePawn3.BackColor == Color.Red)
            {
                Moving(WhitePawn3);
            }
        }

        private void WhitePawn4_Click(object sender, EventArgs e)
        {
            if (!gameIsOn)
            {
                return;
            }
            if (isWhitesTurn)
            {
                clickedPiece = WhitePawn4;
                ClickingPiece("w_pawn", [tableLayoutPanel1.GetColumn(WhitePawn4), tableLayoutPanel1.GetRow(WhitePawn4)]);
                return;
            }
            if ((!isWhitesTurn) && WhitePawn4.BackColor == Color.Red)
            {
                Moving(WhitePawn4);
            }
        }

        private void BlackPawn4_Click(object sender, EventArgs e)
        {
            if (!gameIsOn)
            {
                return;
            }
            if ((isWhitesTurn) && BlackPawn4.BackColor == Color.Red)
            {
                Moving(BlackPawn4);
                return;
            }
            if (!isWhitesTurn)
            {
                clickedPiece = BlackPawn4;
                ClickingPiece("b_pawn", [tableLayoutPanel1.GetColumn(BlackPawn4), tableLayoutPanel1.GetRow(BlackPawn4)]);
                return;
            }
        }

        private void WhitePawn1_Click(object sender, EventArgs e)
        {
            if (!gameIsOn)
            {
                return;
            }
            if (isWhitesTurn)
            {
                clickedPiece = WhitePawn1;
                ClickingPiece("w_pawn", [tableLayoutPanel1.GetColumn(WhitePawn1), tableLayoutPanel1.GetRow(WhitePawn1)]);
                return;
            }
            if ((!isWhitesTurn) && WhitePawn1.BackColor == Color.Red)
            {
                Moving(WhitePawn1);
            }
        }

        private void WhitePawn2_Click(object sender, EventArgs e)
        {
            if (!gameIsOn)
            {
                return;
            }
            if (isWhitesTurn)
            {
                clickedPiece = WhitePawn2;
                ClickingPiece("w_pawn", [tableLayoutPanel1.GetColumn(WhitePawn2), tableLayoutPanel1.GetRow(WhitePawn2)]);
                return;
            }
            if ((!isWhitesTurn) && WhitePawn2.BackColor == Color.Red)
            {
                Moving(WhitePawn2);
            }
        }

        private void WhitePawn5_Click(object sender, EventArgs e)
        {
            if (!gameIsOn)
            {
                return;
            }
            if (isWhitesTurn)
            {
                clickedPiece = WhitePawn5;
                ClickingPiece("w_pawn", [tableLayoutPanel1.GetColumn(WhitePawn5), tableLayoutPanel1.GetRow(WhitePawn5)]);
                return;
            }
            if ((!isWhitesTurn) && WhitePawn5.BackColor == Color.Red)
            {
                Moving(WhitePawn5);
            }
        }

        private void WhitePawn6_Click(object sender, EventArgs e)
        {
            if (!gameIsOn)
            {
                return;
            }
            if (isWhitesTurn)
            {
                clickedPiece = WhitePawn6;
                ClickingPiece("w_pawn", [tableLayoutPanel1.GetColumn(WhitePawn6), tableLayoutPanel1.GetRow(WhitePawn6)]);
                return;
            }
            if ((!isWhitesTurn) && WhitePawn6.BackColor == Color.Red)
            {
                Moving(WhitePawn6);
            }
        }

        private void WhitePawn7_Click(object sender, EventArgs e)
        {
            if (!gameIsOn)
            {
                return;
            }
            if (isWhitesTurn)
            {
                clickedPiece = WhitePawn7;
                ClickingPiece("w_pawn", [tableLayoutPanel1.GetColumn(WhitePawn7), tableLayoutPanel1.GetRow(WhitePawn7)]);
                return;
            }
            if ((!isWhitesTurn) && WhitePawn7.BackColor == Color.Red)
            {
                Moving(WhitePawn7);
            }
        }

        private void WhitePawn8_Click(object sender, EventArgs e)
        {
            if (!gameIsOn)
            {
                return;
            }
            if (isWhitesTurn)
            {
                clickedPiece = WhitePawn8;
                ClickingPiece("w_pawn", [tableLayoutPanel1.GetColumn(WhitePawn8), tableLayoutPanel1.GetRow(WhitePawn8)]);
                return;
            }
            if ((!isWhitesTurn) && WhitePawn8.BackColor == Color.Red)
            {
                Moving(WhitePawn8);
            }
        }

        private void BlackPawn1_Click(object sender, EventArgs e)
        {
            if (!gameIsOn)
            {
                return;
            }
            if ((isWhitesTurn) && BlackPawn1.BackColor == Color.Red)
            {
                Moving(BlackPawn1);
                return;
            }
            if (!isWhitesTurn)
            {
                clickedPiece = BlackPawn1;
                ClickingPiece("b_pawn", [tableLayoutPanel1.GetColumn(BlackPawn1), tableLayoutPanel1.GetRow(BlackPawn1)]);
                return;
            }
        }

        private void BlackPawn2_Click(object sender, EventArgs e)
        {
            if (!gameIsOn)
            {
                return;
            }
            if ((isWhitesTurn) && BlackPawn2.BackColor == Color.Red)
            {
                Moving(BlackPawn2);
                return;
            }
            if (!isWhitesTurn)
            {
                clickedPiece = BlackPawn2;
                ClickingPiece("b_pawn", [tableLayoutPanel1.GetColumn(BlackPawn2), tableLayoutPanel1.GetRow(BlackPawn2)]);
                return;
            }
        }

        private void BlackPawn5_Click(object sender, EventArgs e)
        {
            if (!gameIsOn)
            {
                return;
            }
            if ((isWhitesTurn) && BlackPawn5.BackColor == Color.Red)
            {
                Moving(BlackPawn5);
                return;
            }
            if (!isWhitesTurn)
            {
                clickedPiece = BlackPawn5;
                ClickingPiece("b_pawn", [tableLayoutPanel1.GetColumn(BlackPawn5), tableLayoutPanel1.GetRow(BlackPawn5)]);
                return;
            }
        }

        private void BlackPawn6_Click(object sender, EventArgs e)
        {
            if (!gameIsOn)
            {
                return;
            }
            if ((isWhitesTurn) && BlackPawn6.BackColor == Color.Red)
            {
                Moving(BlackPawn6);
                return;
            }
            if (!isWhitesTurn)
            {
                clickedPiece = BlackPawn6;
                ClickingPiece("b_pawn", [tableLayoutPanel1.GetColumn(BlackPawn6), tableLayoutPanel1.GetRow(BlackPawn6)]);
                return;
            }
        }

        private void BlackPawn7_Click(object sender, EventArgs e)
        {
            if (!gameIsOn)
            {
                return;
            }
            if ((isWhitesTurn) && BlackPawn7.BackColor == Color.Red)
            {
                Moving(BlackPawn7);
                return;
            }
            if (!isWhitesTurn)
            {
                clickedPiece = BlackPawn7;
                ClickingPiece("b_pawn", [tableLayoutPanel1.GetColumn(BlackPawn7), tableLayoutPanel1.GetRow(BlackPawn7)]);
                return;
            }
        }

        private void BlackPawn8_Click(object sender, EventArgs e)
        {
            if (!gameIsOn)
            {
                return;
            }
            if ((isWhitesTurn) && BlackPawn8.BackColor == Color.Red)
            {
                Moving(BlackPawn8);
                return;
            }
            if (!isWhitesTurn)
            {
                clickedPiece = BlackPawn8;
                ClickingPiece("b_pawn", [tableLayoutPanel1.GetColumn(BlackPawn8), tableLayoutPanel1.GetRow(BlackPawn8)]);
                return;
            }
        }

        private void WhiteRook1_Click(object sender, EventArgs e)
        {
            if (!gameIsOn)
            {
                return;
            }
            if (isWhitesTurn)
            {
                clickedPiece = WhiteRook1;
                ClickingPiece("rook", [tableLayoutPanel1.GetColumn(WhiteRook1), tableLayoutPanel1.GetRow(WhiteRook1)]);
                return;
            }
            if ((!isWhitesTurn) && WhiteRook1.BackColor == Color.Red)
            {
                Moving(WhiteRook1);
            }
        }

        private void WhiteRook2_Click(object sender, EventArgs e)
        {
            if (!gameIsOn)
            {
                return;
            }
            if (isWhitesTurn)
            {
                clickedPiece = WhiteRook2;
                ClickingPiece("rook", [tableLayoutPanel1.GetColumn(WhiteRook2), tableLayoutPanel1.GetRow(WhiteRook2)]);
                return;
            }
            if ((!isWhitesTurn) && WhiteRook2.BackColor == Color.Red)
            {
                Moving(WhiteRook2);
            }
        }

        private void BlackRook1_Click(object sender, EventArgs e)
        {
            if (!gameIsOn)
            {
                return;
            }
            if ((isWhitesTurn) && BlackRook1.BackColor == Color.Red)
            {
                Moving(BlackRook1);
                return;
            }
            if (!isWhitesTurn)
            {
                clickedPiece = BlackRook1;
                ClickingPiece("rook", [tableLayoutPanel1.GetColumn(BlackRook1), tableLayoutPanel1.GetRow(BlackRook1)]);
            }
        }

        private void BlackRook2_Click(object sender, EventArgs e)
        {
            if (!gameIsOn)
            {
                return;
            }
            if ((isWhitesTurn) && BlackRook2.BackColor == Color.Red)
            {
                Moving(BlackRook2);
                return;
            }
            if (!isWhitesTurn)
            {
                clickedPiece = BlackRook2;
                ClickingPiece("rook", [tableLayoutPanel1.GetColumn(BlackRook2), tableLayoutPanel1.GetRow(BlackRook2)]);
            }
        }

        private void WhiteKnight2_Click(object sender, EventArgs e)
        {
            if (!gameIsOn)
            {
                return;
            }
            if (isWhitesTurn)
            {
                clickedPiece = WhiteKnight2;
                ClickingPiece("knight", [tableLayoutPanel1.GetColumn(WhiteKnight2), tableLayoutPanel1.GetRow(WhiteKnight2)]);
                return;
            }
            if ((!isWhitesTurn) && WhiteKnight2.BackColor == Color.Red)
            {
                Moving(WhiteKnight2);
            }
        }

        private void BlackKnight1_Click(object sender, EventArgs e)
        {
            if (!gameIsOn)
            {
                return;
            }
            if (!gameIsOn)
            {
                return;
            }
            if ((isWhitesTurn) && BlackKnight1.BackColor == Color.Red)
            {
                Moving(BlackKnight1);
                return;
            }
            if (!isWhitesTurn)
            {
                clickedPiece = BlackKnight1;
                ClickingPiece("knight", [tableLayoutPanel1.GetColumn(BlackKnight1), tableLayoutPanel1.GetRow(BlackKnight1)]);
            }
        }

        private void BlackKnight2_Click(object sender, EventArgs e)
        {
            if (!gameIsOn)
            {
                return;
            }
            if ((isWhitesTurn) && BlackKnight2.BackColor == Color.Red)
            {
                Moving(BlackKnight2);
                return;
            }
            if (!isWhitesTurn)
            {
                clickedPiece = BlackKnight2;
                ClickingPiece("knight", [tableLayoutPanel1.GetColumn(BlackKnight2), tableLayoutPanel1.GetRow(BlackKnight2)]);
            }
        }

        private void WhiteBishop1_Click(object sender, EventArgs e)
        {
            if (!gameIsOn)
            {
                return;
            }
            if (isWhitesTurn)
            {
                clickedPiece = WhiteBishop1;
                ClickingPiece("bishop", [tableLayoutPanel1.GetColumn(WhiteBishop1), tableLayoutPanel1.GetRow(WhiteBishop1)]);
                return;
            }
            if ((!isWhitesTurn) && WhiteBishop1.BackColor == Color.Red)
            {
                Moving(WhiteBishop1);
            }
        }

        private void WhiteBishop2_Click(object sender, EventArgs e)
        {
            if (!gameIsOn)
            {
                return;
            }
            if (isWhitesTurn)
            {
                clickedPiece = WhiteBishop2;
                ClickingPiece("bishop", [tableLayoutPanel1.GetColumn(WhiteBishop2), tableLayoutPanel1.GetRow(WhiteBishop2)]);
                return;
            }
            if ((!isWhitesTurn) && WhiteBishop2.BackColor == Color.Red)
            {
                Moving(WhiteBishop2);
            }
        }

        private void BlackBishop1_Click(object sender, EventArgs e)
        {
            if (!gameIsOn)
            {
                return;
            }
            if ((isWhitesTurn) && BlackBishop1.BackColor == Color.Red)
            {
                Moving(BlackBishop1);
                return;
            }
            if (!isWhitesTurn)
            {
                clickedPiece = BlackBishop1;
                ClickingPiece("bishop", [tableLayoutPanel1.GetColumn(BlackBishop1), tableLayoutPanel1.GetRow(BlackBishop1)]);
            }
        }

        private void BlackBishop2_Click(object sender, EventArgs e)
        {
            if (!gameIsOn)
            {
                return;
            }
            if ((isWhitesTurn) && BlackBishop2.BackColor == Color.Red)
            {
                Moving(BlackBishop2);
                return;
            }
            if (!isWhitesTurn)
            {
                clickedPiece = BlackBishop2;
                ClickingPiece("bishop", [tableLayoutPanel1.GetColumn(BlackBishop2), tableLayoutPanel1.GetRow(BlackBishop2)]);
            }
        }

        private void BlackQueen_Click(object sender, EventArgs e)
        {
            if (!gameIsOn)
            {
                return;
            }
            if ((isWhitesTurn) && BlackQueen.BackColor == Color.Red)
            {
                Moving(BlackQueen); return;
            }
            if (!isWhitesTurn)
            {
                clickedPiece = BlackQueen;
                ClickingPiece("queen", [tableLayoutPanel1.GetColumn(BlackQueen), tableLayoutPanel1.GetRow(BlackQueen)]);
            }
        }

        private void BlackKing_Click(object sender, EventArgs e)
        {
            if (!gameIsOn)
            {
                return;
            }
            if ((isWhitesTurn) && BlackKing.BackColor == Color.Red)
            {
                Moving(BlackKing);
                return;
                //Häviäs koko pelin
            }
            if (!isWhitesTurn)
            {
                clickedPiece = BlackKing;
                ClickingPiece("king", [tableLayoutPanel1.GetColumn(BlackKing), tableLayoutPanel1.GetRow(BlackKing)]);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
