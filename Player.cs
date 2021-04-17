using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect_IA {
    class Player {
        public string name;
        public Color color;
        List<Piece> pieces = new List<Piece>();

        public Player(string name, Color color) {
            this.name = name;
            this.color = color;
            setPieces();
        }

        private void setPieces() {

            Piece piece = new King(color);

        }
    }
}
