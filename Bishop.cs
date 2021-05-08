using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect_IA {
    internal class Bishop : Piece {
        public Bishop(Color color) :base(color) {
            image = Proiect_IA.Properties.Resources.Image1;

        }
    }
}
