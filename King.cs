using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proiect_IA {
   internal class King : Piece {

        public King (Color color):base(color) {
            Cell position;
            if (color == Color.White) {
                position = Board.board[0, 3];
                position.isOccupied = true;
                position.piece = this;
            }
            else {
                position = Board.board[7, 3];
                position.isOccupied = true;
                position.piece = this;
            }
        }
    }
}
