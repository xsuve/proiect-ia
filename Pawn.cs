using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect_IA {
    internal class Pawn : Piece {
        public Pawn(Color color) :base(color) {
            image = color == Color.White ? Proiect_IA.Properties.Resources.pawn_w : Proiect_IA.Properties.Resources.pawn_b;


        }
    }
}
