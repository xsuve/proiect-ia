﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect_IA {
    class Queen : Piece {
        public Queen(Color color, int priority) : base(color, priority) {
            image = color == Color.White ? (Proiect_IA.Properties.Resources.queen_w) : (Proiect_IA.Properties.Resources.queen_b_d);
            priority = 4;
        }

        public override void enable() {
            image = color == Color.White ? (Proiect_IA.Properties.Resources.queen_w) : (Proiect_IA.Properties.Resources.queen_b);
        }
        public override void disable() {
            image = color == Color.White ? (Proiect_IA.Properties.Resources.queen_w_d) : (Proiect_IA.Properties.Resources.queen_b_d);
        }

        public override void Move(int Xcoord, int Ycoord, Box[,] board) {
            Rook MyRook = new Rook(color, priority);
            Bishop MyBishop = new Bishop(color, priority);
            MyBishop.Move(Xcoord, Ycoord, board);
            MyRook.Move(Xcoord, Ycoord, board);
        }
    }
}
