using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proiect_IA {
    class Cell {
        public int x { get; set; }
        public string y { get; set; }

        public Panel panel;

        public  Boolean isOccupied;

        public Piece piece;
    }
}
