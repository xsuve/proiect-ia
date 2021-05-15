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
        static Boolean jailClicked = false;
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

            createJails();
        }

        private bool winner() { 
          
            return false;
        }

        public void createJails() {
            // Airports
            for (int i = 1; i <= 5; i++) {
                Box box = new Box(7, 7 + i, -1);
                box.panel.BackColor = Color.Silver;
                startingForm.Controls.Add(box.panel);
                players[1].airport.Add(box);
            }
            for (int i = 1; i <= 5; i++) {
                Box box = new Box(2, 7 + i, -1);
                box.panel.BackColor = Color.Silver;
                startingForm.Controls.Add(box.panel);
                players[0].airport.Add(box);
            }

            // Jails
            for (int i = 1; i <= 10; i++) {
                int k = i - 1;
                //Box box = new Box(6, 7 + i);
                Box box;
                if (i > 5) {
                    box = new Box(5, 7 + (i - 5), -1);
                } else {
                    box = new Box(6, 7 + i, -1);
                }

                box.panel.BackColor = Color.DarkGray;
                box.panel.Click += (sender, EventArgs) => { startingForm.Jail_Click(sender, EventArgs, k, players[1]); };

                startingForm.Controls.Add(box.panel);
                players[1].jails.Add(box);
            }
            for (int i = 1; i <= 10; i++) {
                int k = i - 1;
                //Box box = new Box(0, 7 + i);
                Box box;
                if (i > 5) {
                    box = new Box(0, 7 + (i - 5), -1);
                } else {
                    box = new Box(1, 7 + i, -1);
                }

                box.panel.BackColor = Color.DarkGray;
                box.panel.Click += (sender, EventArgs) => { startingForm.Jail_Click(sender, EventArgs, k, players[0]); };

                startingForm.Controls.Add(box.panel);
                players[0].jails.Add(box);
            }
        }

        public void createTable() {
            Box.createBoundries(startingForm);

            for (int i = 0; i < 8; i++) {
                for (int j = 0; j < 8; j++) {
                    int h = i, l = j;
                    board[i, j] = new Box(i, j);
                    board[i, j].panel.Click += (sender, EventArgs) => { startingForm.Panel_Click(sender, EventArgs, h, l); };
                    startingForm.Controls.Add(board[i, j].panel);
                }
            }
        }

        public void pieceClick(int xCoord, int yCoord) {
            if (!winner()) 
                if (clicked) {
                    secondClick(xCoord, yCoord);
                }  else {
                    firstClick(xCoord, yCoord);
                }            
        }

        public void jailClick(int i, Player player) {
            if (!jailClicked) {
                if (player.jails[i].piece != null && currentPlayer.color == player.color) {
                    if (player.jails[i].piece.priority <= players[index % 2].jails.Max(pi => pi.piece.priority)) {
                        player.jails[i].panel.BackColor = Color.Khaki;
                        clickedBox = player.jails[i];
                        jailClicked = true;
                    }
                    else
                        MessageBox.Show("Prioritatea piesei este prea mare");
                }              
            } else {
                player.jails[i].panel.BackColor = Color.DarkGray;
                jailClicked = false;
            }
        }

        public void firstClick(int xCoord, int yCoord) {
            if (jailClicked) {
                AddFromJailToTable(xCoord, yCoord);
            } else {
                if (board[xCoord, yCoord].isOccupied && currentPlayer.color == board[xCoord, yCoord].piece.color) {
                    clickedBox = board[xCoord, yCoord];
                    clicked = true;
                    board[xCoord, yCoord].piece.Move(xCoord, yCoord, board);
                    board[xCoord, yCoord].panel.BackColor = Color.Khaki;
                }
            }
        }
        public void secondClick(int xCoord, int yCoord) {
            if (clickedBox == board[xCoord, yCoord]) {
                ResetBoard();
                clicked = false;
                clickedBox = null;

            } else if(board[xCoord, yCoord].nextLegalMove){
                if (board[xCoord, yCoord].piece != null) {
                    board[xCoord, yCoord].addToJail(players[index % 2]);
                }

                board[xCoord, yCoord].SwitchBoxes(clickedBox);  
                ResetBoard();
                //schimbare rand la jucatori
                currentPlayer = players[index++ % 2];

                clicked = false;
                clickedBox = null;
                //removeClickEvents();
                //verificarePiesaAdversarPeBox();  TO DO
            } 
        }

        private void AddFromJailToTable(int xCoord, int yCoord) {
            if (!board[xCoord, yCoord].isOccupied) {
                //Adaugare piesa pe tabla
                board[xCoord, yCoord].SwitchBoxes(clickedBox);
                clickedBox.panel.BackColor = Color.DarkGray;

                //Adaugare piesa adversar pe airport
                var airportPiece = players[index % 2].jails.OrderByDescending(i => i.piece.priority).First();
                airportPiece.addToAirport(players[index % 2]);
                airportPiece.panel.BackgroundImage = null;
                airportPiece.piece = new Piece(-1);

                jailClicked = false;
                currentPlayer = players[index++ % 2];
            }
        }
        private void ResetBoard() {
            for (int i = 0; i < 8; i++) {
                for (int j = 0; j < 8; j++) {
                    board[i, j].nextLegalMove = false;
                    board[i, j].panel.BackColor = (i % 2 == 0 && j % 2 == 0 || i % 2 == 1 && j % 2 == 1) ? Color.BurlyWood : Color.Moccasin;
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
        }
    }
}
