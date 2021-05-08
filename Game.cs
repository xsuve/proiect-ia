using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proiect_IA {
    class Game {
        static int index = 0;
        static Box clickedBox = null;
        static Boolean clicked = false;
        private Player currentPlayer;

        private Form1 startingForm;
        static public Box[,] board = new Box[8,8];
        private List<Player> players = new List<Player>();
       
        public Game(Form1 form) {
            startingForm = form;
            createTable();

            players.Add(new Player("alb", Color.White));
            players.Add(new Player("negru", Color.Black));
            currentPlayer = players[index++ % 2];
        }

        private bool winner() { 
          
            return false;
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

        internal void pieceClick( int xCoord, int yCoord) {
            if (!winner()) 
                if (clicked) {
                    secondClick(xCoord, yCoord);
                }  else {
                    firstClick(xCoord, yCoord);
                }            
        }
        public void firstClick(int xCoord, int yCoord) {
            if (board[xCoord, yCoord].isOccupied && currentPlayer.color == board[xCoord, yCoord].piece.color) {
                clickedBox = board[xCoord, yCoord];
                clicked = true;
                board[xCoord, yCoord].piece.Move(xCoord, yCoord, board);
                board[xCoord, yCoord].panel.BackColor = Color.Cyan;
            }
        }
        public void secondClick(int xCoord, int yCoord) {
            if (clickedBox == board[xCoord, yCoord]) {

                ResetBoard();
                clicked = false;
                clickedBox = null;

            } else if(board[xCoord, yCoord].nextLegalMove){

                board[xCoord, yCoord].SwithBoxes(clickedBox);  
                ResetBoard();
                //schimbare rand la jucatori
                currentPlayer = players[index++ % 2];

                clicked = false;
                clickedBox = null;
                removeClickEvents();
                //verificarePiesaAdversarPeBox();  TO DO
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

        private void removeClickEvents() {
            for (int i = 0; i < 8; i++) {
                for (int j = 0; j < 8; j++) {
                    Panel b = board[i, j].panel;
                    FieldInfo f1 = typeof(Control).GetField("EventClick", BindingFlags.Static | BindingFlags.NonPublic);

                    object obj = f1.GetValue(b);
                    PropertyInfo pi = b.GetType().GetProperty("Events",
                        BindingFlags.NonPublic | BindingFlags.Instance);

                    EventHandlerList list = (EventHandlerList)pi.GetValue(b, null);
                    list.RemoveHandler(obj, list[obj]);

                }
            }

            MessageBox.Show("MA SUGI DE PULA CIOCAN");
        }
    }
}
