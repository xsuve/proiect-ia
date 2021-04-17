using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proiect_IA {
    class Cell {
        public string x { get; set; }
        public int y { get; set; }

        public Panel panel;

        Boolean isOccupied;

        Piece piece;
    }
}
