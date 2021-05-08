using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proiect_IA {
   internal class King : Piece {

        public King(Color color) : base(color) {
            image = color == Color.White ? Proiect_IA.Properties.Resources.king_w : Proiect_IA.Properties.Resources.king_b;
        }
       
    }
}
