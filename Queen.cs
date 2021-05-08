﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect_IA {
    class Queen : Piece {
        public Queen(Color color) :base(color) {
            image = color == Color.White ? Proiect_IA.Properties.Resources.queen_w : Proiect_IA.Properties.Resources.queen_b;

        }

        public override void Move(int Xcoord, int Ycoord, Box[,] board) {
            Rook MyRook = new Rook(color);
            Bishop MyBishop = new Bishop(color);
            MyBishop.Move(Xcoord, Ycoord, board);
            MyRook.Move(Xcoord, Ycoord, board);
        }
    }
}
