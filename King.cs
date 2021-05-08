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
            image = Proiect_IA.Properties.Resources.Image1;
        }
       
    }
}
