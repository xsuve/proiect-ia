using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect_IA {
    internal class Pawn : Piece {
        public Pawn(Color color, int priority) : base(color, priority) {
            image = color == Color.White ? Proiect_IA.Properties.Resources.pawn_w : Proiect_IA.Properties.Resources.pawn_b;
            priority = 1;
        }

        public override void Move(int Xcoord, int Ycoord, Box[,] board) {
            if (color == Color.White) {
                if (Xcoord + 1 < boardSize && board[Xcoord + 1, Ycoord].isOccupied == false) {
                    board[Xcoord + 1, Ycoord].panel.BackColor = Color.DarkSeaGreen;
                    board[Xcoord + 1, Ycoord].nextLegalMove = true;
                }

                if (Xcoord == 1 && Xcoord + 2 < boardSize && board[Xcoord + 1, Ycoord].isOccupied == false && board[Xcoord + 2, Ycoord].isOccupied == false) {
                    board[Xcoord + 2, Ycoord].panel.BackColor = Color.DarkSeaGreen;
                    board[Xcoord + 2, Ycoord].nextLegalMove = true;
                }

                if (Xcoord + 1 < boardSize && Ycoord + 1 < boardSize)
                    if (board[Xcoord + 1, Ycoord + 1].isOccupied == true && board[Xcoord + 1, Ycoord + 1].piece.color != color) {
                        board[Xcoord + 1, Ycoord + 1].panel.BackColor = Color.DarkSeaGreen;
                        board[Xcoord + 1, Ycoord + 1].nextLegalMove = true;

                    }

                if (Xcoord + 1 < boardSize && Ycoord - 1 >= 0)
                    if (board[Xcoord + 1, Ycoord - 1].isOccupied == true && board[Xcoord + 1, Ycoord - 1].piece.color != color) {
                        board[Xcoord + 1, Ycoord - 1].panel.BackColor = Color.DarkSeaGreen;
                        board[Xcoord + 1, Ycoord - 1].nextLegalMove = true;
                    }
            }

            else {
                if (Xcoord - 1 >= 0 && board[Xcoord - 1, Ycoord].isOccupied == false) {
                    board[Xcoord - 1, Ycoord].panel.BackColor = Color.DarkSeaGreen;
                    board[Xcoord - 1, Ycoord].nextLegalMove = true;
                }

                if (Xcoord == 6 && Xcoord - 2 >= 0 && board[Xcoord - 1, Ycoord].isOccupied == false && board[Xcoord - 2, Ycoord].isOccupied == false) {
                    board[Xcoord - 2, Ycoord].panel.BackColor = Color.DarkSeaGreen;
                    board[Xcoord - 2, Ycoord].nextLegalMove = true;
                }

                if (Xcoord - 1 >= 0 && Ycoord + 1 < boardSize)
                    if (board[Xcoord - 1, Ycoord + 1].isOccupied == true && board[Xcoord - 1, Ycoord + 1].piece.color != color) {
                        board[Xcoord - 1, Ycoord + 1].panel.BackColor = Color.DarkSeaGreen;
                        board[Xcoord - 1, Ycoord + 1].nextLegalMove = true;
                    }

                if (Xcoord - 1 >= 0 && Ycoord - 1 >= 0)
                    if (board[Xcoord - 1, Ycoord - 1].isOccupied == true && board[Xcoord - 1, Ycoord - 1].piece.color != color) {
                        board[Xcoord - 1, Ycoord - 1].panel.BackColor = Color.DarkSeaGreen;
                        board[Xcoord - 1, Ycoord - 1].nextLegalMove = true;
                    }
            }
        }
    }
}
