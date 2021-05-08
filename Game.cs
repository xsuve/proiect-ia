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
        static Boolean clicked = false;
        private Player currentPlayer;

        private Form1 startingForm;
        static public Box[,] board = new Box[8,8];
        private List<Player> players = new List<Player>();
       
        public Game(Form1 form) {
            startingForm = form;
            createTable();
            players.Add(new Player("sugi", Color.Black));
            players.Add(new Player("bei", Color.White));

        }


        private void startGame() {
            players.Add(new Player("sugi", Color.Black));
            players.Add(new Player("bei", Color.White));
            int i = 0;
            while (!winner()) {
                playerMove(players[++i % 2]);
            }
        }

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
            if (clicked) { 
                if(clickedBox == board[i, j]) {
                    ResetBoard();                     
                } else {
                    board[i, j].SwithBoxes(clickedBox);
                    //verificarePiesaAdversarPeBox();  TO DO
                    ResetBoard();
                }

                clicked = false;
                clickedBox = null;
            } else if (board[i, j].isOccupied) {
                clickedBox = board[i, j];
                clicked = true;
                board[i, j].piece.Move(i, j, board);
            }
        }

        private void ResetBoard() {
            for (int i = 0; i < 8; i++) {
                for (int j = 0; j < 8; j++) {
                    board[i, j].nextLegalMove = false;
                    board[i, j].panel.BackColor = (i % 2 == 0 && j % 2 == 0 || i % 2 == 1 && j % 2 == 1) ? Color.White : Color.Black;
                }
            }
        }
    }
}
