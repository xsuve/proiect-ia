using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proiect_IA {
    class OnlineGame {
        public Form1 startingForm { get; }

        static int index = 0;
        static Box clickedBox = null;
        static Boolean clicked = false;
        public static Boolean jailClicked = false;
        static Boolean airportClicked = false;
        private Player currentPlayer;

        static public Box[,] board  = new Box[8, 8];
        private List<Player> players = new List<Player>();

        //Retea
        private TcpClient client;
        public StreamReader STR;
        public StreamWriter STW;
        public string receive;
        public int data_to_send;

        public OnlineGame(Form1 form1) {
            startingForm = form1;
            
        }
        public void StartGame() {
            createTable();
            players.Add(new Player("alb", Color.White, board));
            players.Add(new Player("negru", Color.Black, board));
            currentPlayer = players[index++ % 2];
            createJails();

        }
        public void StartServer(String serverIP) {
            TcpListener listener = new TcpListener(IPAddress.Any, 2133);
            listener.Start();
            client = listener.AcceptTcpClient();
            STR = new StreamReader(client.GetStream());
            STW = new StreamWriter(client.GetStream());
            STW.AutoFlush = true;
            startingForm.backgroundWorker1.RunWorkerAsync();                         //start receiving data in background
            startingForm.backgroundWorker2.WorkerSupportsCancellation = true;        //ability to cancel this thread

            //WhitePlayer TO DO
            StartGame();

        }
        public void Connect(String connectIP) {
            client = new TcpClient();
            IPEndPoint IP_End = new IPEndPoint(IPAddress.Parse(connectIP), 2133);
            try {
                client.Connect(IP_End);
                if (client.Connected) {
                    STW = new StreamWriter(client.GetStream());
                    STR = new StreamReader(client.GetStream());
                    STW.AutoFlush = true;
                    startingForm.backgroundWorker1.RunWorkerAsync();                         //start receiving data in background
                    startingForm.backgroundWorker2.WorkerSupportsCancellation = true;        //ability to cancel this thread

                    //BlackPlAYER TO DO
                    StartGame();
                }
            }
            catch (Exception x) {
                MessageBox.Show(x.Message.ToString());
            }
        }

        public void ReceiveData() {
            while (client.Connected)
                try {

                    string data_received = STR.ReadLine();
                    int data = Int32.Parse(data_received);
                    //TO DO 

                }
                catch (Exception x) {
                    MessageBox.Show(x.Message.ToString());
                }
        }
        public void CreateDataToSend() {

            startingForm.backgroundWorker2.RunWorkerAsync();

        }
        public void SendData() {

            if (client.Connected) {
               // WhiteMove = !WhiteMove;
                STW.WriteLine(data_to_send.ToString());
            }
            else {
                MessageBox.Show("Send Faild ");
            }
            startingForm.backgroundWorker2.CancelAsync();

        }
        private bool winner() {

            var piece = currentPlayer.pieces.Find(pi => pi is King);

            foreach (var pieces in players[index % 2].pieces)
                pieces.canMove(board);
            if (board[piece.x, piece.y].nextLegalMove == true) {
                board[piece.x, piece.y].panel.BackColor = Color.Red;
            }
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
                    }
                    else {
                        player.jails[i].panel.BackColor = Color.Tomato;
                        jailClicked = true;
                    }
                }
            }
            else {
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
            }
            else {
                player.airport[i].panel.BackColor = Color.Silver;
                airportClicked = false;
            }
        }

        public void firstClick(int xCoord, int yCoord) {
            if (jailClicked || airportClicked) {
                AddToTable(xCoord, yCoord);
            }
            else {
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


            }
            else if (board[xCoord, yCoord].nextLegalMove) {
                if (board[xCoord, yCoord].piece != null && board[xCoord, yCoord].piece.color != currentPlayer.color) {
                    board[xCoord, yCoord].addToJail(players[index % 2]);
                }

                // Rocada
                if (clickedBox.piece is King && board[xCoord, yCoord].piece is Rook && !board[xCoord, yCoord].piece.moved) {
                    if (clickedBox.y - yCoord > 0) {
                        board[xCoord, 1].SwitchBoxes(board[xCoord, 3]);
                        board[xCoord, 2].SwitchBoxes(board[xCoord, 0]);
                        goto JumpSwitch;
                    }
                    else {
                        board[xCoord, 5].SwitchBoxes(board[xCoord, 3]);
                        board[xCoord, 4].SwitchBoxes(board[xCoord, 7]);
                        goto JumpSwitch;
                    }
                }
                else {
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

        public void changePieces(Box currentBoxClicked, Box clickedBox) {

            currentBoxClicked.SwitchBoxes(clickedBox);

            if (players[index % 2].pieces.Find(pi => pi.x == clickedBox.x && pi.y == clickedBox.y) != null)
                players[index % 2].pieces.Find(pi => pi.x == clickedBox.x && pi.y == clickedBox.y).newPosition(0, 0);

            currentPlayer.pieces.Find(pi => pi.x == clickedBox.x && pi.y == clickedBox.y).newPosition(currentBoxClicked.x, currentBoxClicked.y);
        }

    }
}
