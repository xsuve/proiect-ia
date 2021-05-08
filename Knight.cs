using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect_IA {
    class Knight : Piece {
        public Knight(Color color) : base(color) {
            image = Proiect_IA.Properties.Resources.Image1;


        }

        public override void Move(int Xcoord, int Ycoord, Box[,] board) {
            //upper right
            if (Xcoord - 2 >= 0 && Ycoord + 1 < boardSize)
                if (board[Xcoord - 2, Ycoord + 1].isOccupied == false) {
                    board[Xcoord - 2, Ycoord + 1].panel.BackColor = Color.Green;
                    board[Xcoord - 2, Ycoord + 1].nextLegalMove = true;
                }
                else
                    if (board[Xcoord - 2, Ycoord + 1].piece.color != color) {
                    board[Xcoord - 2, Ycoord + 1].panel.BackColor = Color.Green;
                    board[Xcoord - 2, Ycoord + 1].nextLegalMove = true;
                }

            //upper left
            if (Xcoord - 2 >= 0 && Ycoord - 1 >= 0)
                if (board[Xcoord - 2, Ycoord - 1].isOccupied == false) {
                    board[Xcoord - 2, Ycoord - 1].panel.BackColor = Color.Green;
                    board[Xcoord - 2, Ycoord - 1].nextLegalMove = true;
                }
                else
                    if (board[Xcoord - 2, Ycoord - 1].piece.color != color) {
                    board[Xcoord - 2, Ycoord - 1].panel.BackColor = Color.Green;
                    board[Xcoord - 2, Ycoord - 1].nextLegalMove = true;
                }

            //lower right
            if (Xcoord + 2 < boardSize && Ycoord + 1 < boardSize)
                if (board[Xcoord + 2, Ycoord + 1].isOccupied == false) {
                    board[Xcoord + 2, Ycoord + 1].panel.BackColor = Color.Green;
                    board[Xcoord + 2, Ycoord + 1].nextLegalMove = true;
                }
                else
                    if (board[Xcoord + 2, Ycoord + 1].piece.color != color) {
                    board[Xcoord + 2, Ycoord + 1].panel.BackColor = Color.Green;
                    board[Xcoord + 2, Ycoord + 1].nextLegalMove = true;
                }

            ///lower left
            if (Xcoord + 2 < boardSize && Ycoord - 1 >= 0)
                if (board[Xcoord + 2, Ycoord - 1].isOccupied == false) {
                    board[Xcoord + 2, Ycoord - 1].panel.BackColor = Color.Green;
                    board[Xcoord + 2, Ycoord - 1].nextLegalMove = true;
                }
                else
                    if (board[Xcoord + 2, Ycoord - 1].piece.color != color) {
                    board[Xcoord + 2, Ycoord - 1].panel.BackColor = Color.Green;
                    board[Xcoord + 2, Ycoord - 1].nextLegalMove = true;
                }

            //left upper
            if (Xcoord - 1 >= 0 && Ycoord - 2 >= 0)
                if (board[Xcoord - 1, Ycoord - 2].isOccupied == false) {
                    board[Xcoord - 1, Ycoord - 2].panel.BackColor = Color.Green;
                    board[Xcoord - 1, Ycoord - 2].nextLegalMove = true;
                }
                else
                      if (board[Xcoord - 1, Ycoord - 2].piece.color != color) {
                    board[Xcoord - 1, Ycoord - 2].panel.BackColor = Color.Green;
                    board[Xcoord - 1, Ycoord - 2].nextLegalMove = true;
                }


            //left down
            if (Xcoord + 1 < boardSize && Ycoord - 2 >= 0)
                if (board[Xcoord + 1, Ycoord - 2].isOccupied == false) {
                    board[Xcoord + 1, Ycoord - 2].panel.BackColor = Color.Green;
                    board[Xcoord + 1, Ycoord - 2].nextLegalMove = true;
                }
                else
                      if (board[Xcoord + 1, Ycoord - 2].piece.color != color) {
                    board[Xcoord + 1, Ycoord - 2].panel.BackColor = Color.Green;
                    board[Xcoord + 1, Ycoord - 2].nextLegalMove = true;
                }

            //right upper
            if (Xcoord - 1 >= 0 && Ycoord + 2 < boardSize)
                if (board[Xcoord - 1, Ycoord + 2].isOccupied == false) {
                    board[Xcoord - 1, Ycoord + 2].panel.BackColor = Color.Green;
                    board[Xcoord - 1, Ycoord + 2].nextLegalMove = true;
                }
                else
                      if (board[Xcoord - 1, Ycoord + 2].piece.color != color) {
                    board[Xcoord - 1, Ycoord + 2].panel.BackColor = Color.Green;
                    board[Xcoord - 1, Ycoord + 2].nextLegalMove = true;
                }

            //right down
            if (Xcoord + 1 < boardSize && Ycoord + 2 < boardSize)
                if (board[Xcoord + 1, Ycoord + 2].isOccupied == false) {
                    board[Xcoord + 1, Ycoord + 2].panel.BackColor = Color.Green;
                    board[Xcoord + 1, Ycoord + 2].nextLegalMove = true;
                }
                else
                      if (board[Xcoord + 1, Ycoord + 2].piece.color != color) {
                    board[Xcoord + 1, Ycoord + 2].panel.BackColor = Color.Green;
                    board[Xcoord + 1, Ycoord + 2].nextLegalMove = true;
                }

        }
    }
}
