﻿using System.Drawing;

namespace Proiect_IA {
    public class Piece {

        public Color color;
        public Image image;
        public int priority;
        protected int boardSize = 8;

        public Piece(int priority) {
            this.priority = priority;
        }

        public Piece(Color color, int priority) {
            this.color = color;
            this.priority = priority;
        }

        public virtual void Move(int Xcoord, int Ycoord, Box[,] board) {

        }
        
        public virtual void enable() {

        }

        public virtual void disable() {

        }

    }
}