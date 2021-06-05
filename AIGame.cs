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
    public class MinMaxMove {
        public Box initialMove;
        public Box nextMove;
        public int value;

        public MinMaxMove(Box initialMove, Box nextMove, int value) {
            this.initialMove = initialMove;
            this.nextMove = nextMove;
            this.value = value;
        }
    };


    class AIGame {
        static int index = 0;
        static Box clickedBox = null;
        static Boolean clicked = false;
        public static Boolean jailClicked = false;
        static Boolean airportClicked = false;
        private Player currentPlayer;

        private Form1 startingForm;
        static public Box[,] board = new Box[8, 8];
        private List<Player> players = new List<Player>();
       
        public AIGame(Form1 form) {
            startingForm = form;
            createTable();

            players.Add(new Player("alb", Color.White, board));
            players.Add(new Player("negru", Color.Black, board));
            currentPlayer = players[index++ % 2];

            createJails();
        }

        private bool winner() { 
            var piece = currentPlayer.pieces.Find(pi => pi is King);

            foreach (var pieces in players[index % 2].pieces)
                pieces.canMove(board);
            if (board[piece.x, piece.y].nextLegalMove == true) {
                board[piece.x, piece.y].panel.BackColor = Color.Red;      
            }

            ResetBoard();
            return false;
        }

        public void pieceClick(int xCoord, int yCoord) {
            if (clicked) {
                secondClick(xCoord, yCoord);
            }
            else {
                firstClick(xCoord, yCoord);
            }
        }          
    

        public void jailClick(int i, Player player) {
            if (!jailClicked) {
                if (player.jails[i].piece.priority != -1 && currentPlayer.color == player.color) {
                    if (player.jails[i].piece.priority <= players[index % 2].jails.Max(pi => pi.piece.priority)) {
                        player.jails[i].panel.BackColor = Color.Khaki;
                        clickedBox = player.jails[i];
                        jailClicked = true;
                    } else {
                        player.jails[i].panel.BackColor = Color.Tomato;
                        jailClicked = true;
                    }
                }
            } else {
                player.jails[i].panel.BackColor = Color.DarkGray;
                jailClicked = false;
            }
        }

        public void airportClick(int i, Player player) {
            if (!airportClicked) {
                if (player.airport[i].piece.priority != -1 && currentPlayer.color == player.color) {
                    player.airport[i].panel.BackColor = Color.Khaki;
                    clickedBox = player.airport[i];
                    airportClicked = true;
                }
            } else {
                player.airport[i].panel.BackColor = Color.Silver;
                airportClicked = false;
            }
        }

        public void firstClick(int xCoord, int yCoord) {
            if (jailClicked || airportClicked) {
                if (clickedBox.piece is Pawn && xCoord != 0 && xCoord != 7) {
                    AddToTable(xCoord, yCoord);
                } else {
                    return;
                }

                AddToTable(xCoord, yCoord);
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
            } else if(board[xCoord, yCoord].nextLegalMove) {
                if (board[xCoord, yCoord].piece != null && board[xCoord, yCoord].piece.color != currentPlayer.color) {
                    board[xCoord, yCoord].addToJail(players[index % 2]);
                }

                // Piece priority in jail
                // TO DO

                // Pawn on last row
                if (clickedBox.piece is Pawn && (xCoord == 0 || xCoord == 7)) {
                    if (currentPlayer.jails.Max(pi => pi.piece.priority) != -1) {
                        board[xCoord, yCoord].SwitchBoxes(currentPlayer.jails.OrderByDescending(i => i.piece.priority).First());
                        clickedBox.resetBox();
                        goto JumpSwitch;
                    } else {
                        board[xCoord, yCoord].SwitchBoxes(clickedBox);
                        goto JumpSwitch;
                    }
                }

                // Rocada
                if (clickedBox.piece is King && board[xCoord, yCoord].piece is Rook && !board[xCoord, yCoord].piece.moved) {
                    if (clickedBox.y - yCoord > 0) {
                        board[xCoord, 1].SwitchBoxes(board[xCoord, 3]);
                        board[xCoord, 2].SwitchBoxes(board[xCoord, 0]);
                        goto JumpSwitch;
                    } else {
                        board[xCoord, 5].SwitchBoxes(board[xCoord, 3]);
                        board[xCoord, 4].SwitchBoxes(board[xCoord, 7]);
                        goto JumpSwitch;
                    }
                } else {

                    if (clickedBox.piece is King && clickedBox.piece is Rook) {
                        clickedBox.piece.moved = true;
                    } 
                }

                changePieces(board[xCoord, yCoord], clickedBox);

            JumpSwitch:               

                ResetBoard();
                //schimbare rand la jucatori
                switchPlayer();

                clicked = false;
                clickedBox = null;
                //removeClickEvents();
                //verificarePiesaAdversarPeBox();  TO DO
            }
        }
             
        public void switchPlayer() {
            currentPlayer = players[index++ % 2];

            players[index % 2].disablePieces();
            currentPlayer.enablePieces();

            for (int i = 0; i < 8; i++) {
                for (int j = 0; j < 8; j++) {
                    if (board[i, j].piece != null) {
                        board[i, j].panel.BackgroundImage = board[i, j].piece.image;
                    }
                }
            }

            winner();

            // Random move
            if (currentPlayer.color == Color.Black) {
                randomMove();
            }
        }

        private void randomMove() {
            MinMaxMove randMove = calcBestMove(2, currentPlayer.color);
            /*List<Box> randMoves;

            do {
                randPiece = currentPlayer.getRandomPiece();
                randMoves = randPiece.getAvailableMoves(board);
            } while (randMoves.Count() <= 0);

            Random r = new Random();
            int rInt = r.Next(0, randMoves.Count());
            Box randMove = randMoves[rInt];

            if (randMove.piece != null && randMove.piece.color != currentPlayer.color) {
                randMove.addToJail(players[index % 2]);
            }*/

            changePieces(board[randMove.initialMove.x, randMove.initialMove.y], board[randMove.nextMove.x, randMove.nextMove.y]);
            switchPlayer();
        }

        private void AddToTable(int xCoord, int yCoord) {
            if (jailClicked) {
                if (!board[xCoord, yCoord].isOccupied) {
                    if (clickedBox != null) {
                        //Adaugare piesa pe tabla
                        changePieces(board[xCoord, yCoord], clickedBox);
                        //board[xCoord, yCoord].SwitchBoxes(clickedBox);
                        clickedBox.panel.BackColor = Color.DarkGray;

                        //Adaugare piesa adversar pe airport
                        var airportPiece = players[index % 2].jails.OrderByDescending(i => i.piece.priority).First();
                        airportPiece.addToAirport(players[index % 2]);
                        airportPiece.panel.BackgroundImage = null;
                        airportPiece.piece = new Piece(-1);

                        jailClicked = false;
                        switchPlayer();
                    }
                }
            }
            else {
                if (!board[xCoord, yCoord].isOccupied) {
                    changePieces(board[xCoord, yCoord], clickedBox);
                    //board[xCoord, yCoord].SwitchBoxes(clickedBox);
                    clickedBox.panel.BackColor = Color.Silver;

                    airportClicked = false;
                    switchPlayer();
                }
            }
        }

        private void ResetBoard() {
            for (int i = 0; i < 8; i++) {
                for (int j = 0; j < 8; j++) {
                    board[i, j].nextLegalMove = false;
                    board[i, j].panel.BackColor = (i % 2 == 0 && j % 2 == 0 || i % 2 == 1 && j % 2 == 1) ? Color.Moccasin : Color.BurlyWood;
                }
            }

            // Airport
            foreach (Player player in players) {
                foreach (var airportBox in player.airport) {
                    airportBox.panel.BackColor = Color.Silver;
                }
            }

            // Jails
            foreach (Player player in players) {
                foreach (var jailsBox in player.jails) {
                    jailsBox.panel.BackColor = Color.DarkGray;
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

        public void createJails() {
            // Airports
            for (int i = 1; i <= 5; i++) {
                int k = i - 1;
                Box box = new Box(7, 7 + i, -1);

                box.panel.BackColor = Color.Silver;
                box.panel.Click += (sender, EventArgs) => { startingForm.Airport_Click(sender, EventArgs, k, players[1]); };

                startingForm.Controls.Add(box.panel);
                players[1].airport.Add(box);
            }
            for (int i = 1; i <= 5; i++) {
                int k = i - 1;
                Box box = new Box(2, 7 + i, -1);

                box.panel.BackColor = Color.Silver;
                box.panel.Click += (sender, EventArgs) => { startingForm.Airport_Click(sender, EventArgs, k, players[0]); };

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
                }
                else {
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
                }
                else {
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

        public void changePieces(Box currentBoxClicked, Box clickedBox) {
            currentBoxClicked.SwitchBoxes(clickedBox);

            if (players[index % 2].pieces.Find(pi => pi.x == clickedBox.x && pi.y == clickedBox.y) != null)
                players[index % 2].pieces.Find(pi => pi.x == clickedBox.x && pi.y == clickedBox.y).setCoords(0, 0);

            if(currentPlayer.pieces.Find(pi => pi.x == clickedBox.x && pi.y == clickedBox.y) != null) {
                currentPlayer.pieces.Find(pi => pi.x == clickedBox.x && pi.y == clickedBox.y).setCoords(currentBoxClicked.x, currentBoxClicked.y);
            } else {
                clickedBox.piece.setCoords(currentBoxClicked.x, currentBoxClicked.y);
                currentPlayer.pieces.Add(clickedBox.piece);
            }
        }


        // Minimax
        public int value = 0;
        public MinMaxMove calcBestMove(int depth, Color playerColor, Boolean isMaximizingPlayer = true) {
            if(depth == 0) {
                value = evaluateBoard(playerColor);
                return new MinMaxMove(null, null, value);
            }

            Box bestMove = null;
            Box initialMove = null;
            Dictionary<Box, Box> possibleMoves = getPossibleMoves(playerColor);

            int bestMoveValue = isMaximizingPlayer ? int.MinValue : int.MaxValue;

            // Random possible moves
            Random rand = new Random();
            possibleMoves.OrderBy(item => rand.Next());

            // Search through all possible moves
            foreach(var possibleMove in possibleMoves) {
                Box move = possibleMove.Value;

                changePiecesIA(possibleMove.Key, possibleMove.Value);

                value = calcBestMove(depth - 1, playerColor, !isMaximizingPlayer).value;

                if(isMaximizingPlayer) {
                    if(value > bestMoveValue) {
                        bestMoveValue = value;
                        bestMove = move;
                        initialMove = possibleMove.Key;
                    }
                } else {
                    if(value < bestMoveValue) {
                        bestMoveValue = value;
                        bestMove = move;
                        initialMove = possibleMove.Key;
                    }
                }

                changePiecesIA(possibleMove.Value, possibleMove.Key);
            }

            if(possibleMoves.Count > 1) {
                return new MinMaxMove(initialMove, bestMove, value);
            } else {
                return new MinMaxMove(possibleMoves.First().Key, possibleMoves.First().Value, value);
            }
        }

        // Get possible moves
        public Dictionary<Box, Box> getPossibleMoves(Color playerColor) {
            Dictionary<Box, Box> allPossibleMoves = new Dictionary<Box, Box>();
            Player myPlayer = players.Find(pl => pl.color == playerColor);

            foreach (var myPiece in myPlayer.pieces) {
                List<Box> onePieceMove = myPiece.getAvailableMoves(board);
                if (onePieceMove != null) {
                    foreach (var item in onePieceMove) {
                        allPossibleMoves[board[myPiece.x, myPiece.y]] = item;
                    }
                }
            }

            return allPossibleMoves;

        }

        // Change pieces
        public void changePiecesIA(Box nextMove, Box currentMove) {
            currentMove.SwitchBoxesIA(nextMove);

            if (players[index % 2].pieces.Find(pi => pi.x == currentMove.x && pi.y == currentMove.y) != null)
                players[index % 2].pieces.Find(pi => pi.x == currentMove.x && pi.y == currentMove.y).setCoords(0, 0);

            if (currentPlayer.pieces.Find(pi => pi.x == currentMove.x && pi.y == currentMove.y) != null) {
                currentPlayer.pieces.Find(pi => pi.x == currentMove.x && pi.y == currentMove.y).setCoords(nextMove.x, nextMove.y);
            } else {
                if (currentMove.piece.priority != -1) {
                    currentMove.piece.setCoords(nextMove.x, nextMove.y);
                    currentPlayer.pieces.Add(currentMove.piece);
                }
            }
        }

        // Evaluate board
        public int evaluateBoard(Color playerColor) {
            int _value = 0;
            Player myPlayer = players.Find(pl => pl.color == playerColor);
            foreach (var myPiece in myPlayer.pieces) {
                _value += myPiece.priority;
            }

            myPlayer = players.Find(pl => pl.color != playerColor);
            foreach (var myPiece in myPlayer.pieces) {
                _value -= myPiece.priority;
            }

            return _value;
        }
    }
}
