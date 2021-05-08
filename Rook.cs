using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect_IA {
    class Rook : Piece {
        public Rook(Color color) : base(color) {
            image = color == Color.White ? Proiect_IA.Properties.Resources.rook_w : Proiect_IA.Properties.Resources.rook_b;
        }

        public override void Move(int Xcoord, int Ycoord, Box[,] board) {
            //collum possible move under the rook
            for (int i = 1; i < boardSize; i++)
                if (Xcoord + i < boardSize)
                    if (board[Xcoord + i, Ycoord].isOccupied == false) {
                        board[Xcoord + i, Ycoord].panel.BackColor = Color.Green;
                        board[Xcoord + i, Ycoord].nextLegalMove = true;
                    }
                    else if (board[Xcoord + i, Ycoord].piece.color != color) {
                        board[Xcoord + i, Ycoord].panel.BackColor = Color.Green;
                        board[Xcoord + i, Ycoord].nextLegalMove = true;
                        break;
                    }
                    else
                        break;
                else
                    break;


            //raw possible move to the right of the rook
            for (int i = 1; i < boardSize; i++)
                if (Ycoord + i < boardSize)
                    if (board[Xcoord, Ycoord + i].isOccupied == false) {
                        board[Xcoord, Ycoord + i].panel.BackColor = Color.Green;
                        board[Xcoord, Ycoord + i].nextLegalMove = true;
                    }
                    else if (board[Xcoord, Ycoord + i].piece.color != color) {
                        board[Xcoord, Ycoord + i].panel.BackColor = Color.Green;
                        board[Xcoord, Ycoord + i].nextLegalMove = true;
                        break;
                    }
                    else
                        break;
                else
                    break;

            //collum possible move above the rook
            for (int i = 1; i < boardSize; i++)
                if (Xcoord - i >= 0)
                    if (board[Xcoord - i, Ycoord].isOccupied == false) {
                        board[Xcoord - i, Ycoord].panel.BackColor = Color.Green;
                        board[Xcoord - i, Ycoord].nextLegalMove = true;
                    }
                    else if (board[Xcoord - i, Ycoord].piece.color != color) {
                        board[Xcoord - i, Ycoord].panel.BackColor = Color.Green;
                        board[Xcoord - i, Ycoord].nextLegalMove = true;
                        break;
                    }
                    else
                        break;
                else
                    break;

            //possible move to the left of the rook
            for (int i = 1; i < boardSize; i++)
                if (Ycoord - i >= 0)
                    if (board[Xcoord, Ycoord - i].isOccupied == false) {
                        board[Xcoord, Ycoord - i].panel.BackColor = Color.Green;
                        board[Xcoord, Ycoord - i].nextLegalMove = true;
                    }
                    else if (board[Xcoord, Ycoord - i].piece.color != color) {
                        board[Xcoord, Ycoord - i].panel.BackColor = Color.Green;
                        board[Xcoord, Ycoord - i].nextLegalMove = true;
                        break;
                    }
                    else
                        break;
                else
                    break;


        }

    }
}
