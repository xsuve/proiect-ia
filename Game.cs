using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect_IA {
    class Game {
        private Form1 startingForm;
        private Board board;
        private Player[] players = new Player[2];
        public Game(Form1 form) {
            startingForm = form;
            board = new Board(startingForm);
            createTable();
            startGame();
        }

        private void startGame() {
            players[0] = new Player("Marcel",Color.White);
            Board.board[0, 0].isOccupied = true;
            int i = 0;
            while (!winner()) {
                playerMove(players[++i%2]);
            }
        }

        private void playerMove(Player player) {
            throw new NotImplementedException();
        }

        private bool winner() {
            throw new NotImplementedException();
        }

        public void createTable() {
            board.createTable();
        }


    }
}
