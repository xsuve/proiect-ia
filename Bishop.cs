using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect_IA {
    internal class Bishop : Piece {
        public Bishop(Color color) :base(color) {
            image = color == Color.White ? Proiect_IA.Properties.Resources.bishop_w : Proiect_IA.Properties.Resources.bishop_b;

        }
    }
}
