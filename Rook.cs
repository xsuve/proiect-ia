using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect_IA {
    class Rook : Piece { 
        public Rook(Color color) :base(color) {
            image = color == Color.White ? Proiect_IA.Properties.Resources.rook_w : Proiect_IA.Properties.Resources.rook_b;
        }
    }
}
