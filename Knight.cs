using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect_IA {
    class Knight : Piece {
        public Knight(Color color) : base(color) {
            image = color == Color.White ? Proiect_IA.Properties.Resources.knight_w : Proiect_IA.Properties.Resources.knight_b;

        }
    }
}
