using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect_IA {
    class Game {
        private Form1 startingForm;
        private Board board;
        public Game(Form1 form) {
            startingForm = form;
            board = new Board(startingForm);
            createTable();
        } 

        public void createTable() {
            board.createTable();
        }


    }
}
