using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proiect_IA {
    class Game {      
        static Box clickedBox = null;

        private Form1 startingForm;
        static public Box[,] board = new Box[8,8];
        private List<Player> players = new List<Player>();
        public Game(Form1 form) {
            startingForm = form;
            createTable();
            players.Add(new Player("sugi", Color.Black));
            players.Add(new Player("bei", Color.White));

        }


        //private void startGame() {
        //    players[0] = new Player("Marcel",Color.White);
        //    Board.board[0, 0].isOccupied = true;
        //    int i = 0;
        //    while (!winner()) {
        //        playerMove(players[++i%2]);
        //    }
        //}

        private void playerMove(Player player) {
            throw new NotImplementedException();
        }

        private bool winner() {
            throw new NotImplementedException();
        }

        public void createTable() {
            Box.createBoundries(startingForm);
            for (int i = 0; i < 8; i++) {
                for (int j = 0; j < 8; j++) {
                    int h = i, l = j;
                    board[i, j] = new Box(i, j);
                    board[i, j].panel.Click  += (sender, EventArgs) => { startingForm.Panel_Click(sender, EventArgs, h, l); };
                    startingForm.Controls.Add(board[i, j].panel);
                }
            }       
        }

        internal void pieceClick( int i, int j) {
            if (board[i, j].isOccupied && board[i, j].piece.color == currentPlayer.color) {
                if (board[i, j].clicked) {
                    board[i, j].clicked = false;
                    //TO DO RESET TABLE Boxes
                    box.BackColor = Color.Aquamarine;
                }
                else {
                                   
                    if (!board[i,j].clicked) {

                        board[i, j].clicked = true;
                        board[i, j].piece.Move();
                    }
                    else {
                        board[i, j].piece = clickedBox;
                        clickedBox = new Box();

                    }

                    clicked = !clicked;
                }
            }
        }
    }
}
