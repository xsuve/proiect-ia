using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proiect_IA {
    internal class King : Piece {

        public King(Color color) : base(color) {
            image = Proiect_IA.Properties.Resources.Image1;

        }

        public override void Move(int Xcoord, int Ycoord, Box[,] board) {
            //down move
            if (Xcoord + 1 < boardSize)
                if (board[Xcoord + 1, Ycoord].isOccupied == false) {
                    board[Xcoord + 1, Ycoord].nextLegalMove = true;
                    board[Xcoord + 1, Ycoord].panel.BackColor = Color.Green;

                }
                else if (board[Xcoord + 1, Ycoord].piece.color != color) {
                    board[Xcoord + 1, Ycoord].nextLegalMove = true;
                    board[Xcoord + 1, Ycoord].panel.BackColor = Color.Green;

                }


            //upper move
            if (Xcoord - 1 >= 0)
                if (board[Xcoord - 1, Ycoord].isOccupied == false) {
                    board[Xcoord - 1, Ycoord].nextLegalMove = true;
                    board[Xcoord - 1, Ycoord].panel.BackColor = Color.Green;

                }
                else if (board[Xcoord - 1, Ycoord].piece.color != color) {
                    board[Xcoord - 1, Ycoord].nextLegalMove = true;
                    board[Xcoord - 1, Ycoord].panel.BackColor = Color.Green;

                }


            //right move
            if (Ycoord + 1 < boardSize)
                if (board[Xcoord, Ycoord + 1].isOccupied == false) {
                    board[Xcoord, Ycoord + 1].panel.BackColor = Color.Green;
                    board[Xcoord, Ycoord + 1].nextLegalMove = true;

                }
                else if (board[Xcoord, Ycoord + 1].piece.color != color) {
                    board[Xcoord, Ycoord + 1].panel.BackColor = Color.Green;
                    board[Xcoord, Ycoord + 1].nextLegalMove = true;

                }


            //left move
            if (Ycoord - 1 >= 0)
                if (board[Xcoord, Ycoord - 1].isOccupied == false) {
                    board[Xcoord, Ycoord - 1].panel.BackColor = Color.Green;
                    board[Xcoord, Ycoord - 1].nextLegalMove = true;

                }
                else if (board[Xcoord, Ycoord - 1].piece.color != color) {
                    board[Xcoord, Ycoord - 1].panel.BackColor = Color.Green;
                    board[Xcoord, Ycoord - 1].nextLegalMove = true;

                }


            //down right move
            if (Xcoord + 1 < boardSize && Ycoord + 1 < boardSize)
                if (board[Xcoord + 1, Ycoord + 1].isOccupied == false) {
                    board[Xcoord + 1, Ycoord + 1].panel.BackColor = Color.Green;
                    board[Xcoord + 1, Ycoord + 1].nextLegalMove = true;

                }
                else if (board[Xcoord + 1, Ycoord + 1].piece.color != color) {
                    board[Xcoord + 1, Ycoord + 1].panel.BackColor = Color.Green;
                    board[Xcoord + 1, Ycoord + 1].nextLegalMove = true;

                }


            //upper right move
            if (Xcoord - 1 >= 0 && Ycoord + 1 < boardSize)
                if (board[Xcoord - 1, Ycoord + 1].isOccupied == false) {
                    board[Xcoord - 1, Ycoord + 1].panel.BackColor = Color.Green;
                    board[Xcoord - 1, Ycoord + 1].nextLegalMove = true;

                }
                else if (board[Xcoord - 1, Ycoord + 1].piece.color != color) {
                    board[Xcoord - 1, Ycoord + 1].panel.BackColor = Color.Green;
                    board[Xcoord - 1, Ycoord + 1].nextLegalMove = true;

                }


            //down left move
            if (Xcoord + 1 < boardSize && Ycoord - 1 >= 0)
                if (board[Xcoord + 1, Ycoord - 1].isOccupied == false) {
                    board[Xcoord + 1, Ycoord - 1].panel.BackColor = Color.Green;
                    board[Xcoord + 1, Ycoord - 1].nextLegalMove = true;

                }
                else  if (board[Xcoord + 1, Ycoord - 1].piece.color != color) {
                    board[Xcoord + 1, Ycoord - 1].panel.BackColor = Color.Green;
                    board[Xcoord + 1, Ycoord - 1].nextLegalMove = true;

                }

            //upper left move
            if (Xcoord - 1 >= 0 && Ycoord - 1 >= 0)
                if (board[Xcoord - 1, Ycoord - 1].isOccupied == false) {
                    board[Xcoord - 1, Ycoord - 1].panel.BackColor = Color.Green;
                    board[Xcoord - 1, Ycoord - 1].nextLegalMove = true;

                }
                else  if (board[Xcoord - 1, Ycoord - 1].piece.color != color) {
                    board[Xcoord - 1, Ycoord - 1].panel.BackColor = Color.Green;
                    board[Xcoord - 1, Ycoord - 1].nextLegalMove = true;

                }

        }

    }
}
