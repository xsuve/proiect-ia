using System.Drawing;

namespace Proiect_IA {
    internal class Piece {

        public Color color;
        public Image image;
        protected int boardSize = 8;
        public Piece(Color color) {
            this.color = color;
        }

        public virtual void Move(int Xcoord, int Ycoord, Box[,] board) {

        }
        


    }
}