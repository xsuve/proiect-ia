using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect_IA {
    class Rook : Piece {
        public Rook(Color color, Box box) :base(color, box) {
            image = Proiect_IA.Properties.Resources.Image1;
            box.panel.BackgroundImage = image;
            box.isOccupied = true;
        }
    }
}
