using System.Drawing;

namespace Proiect_IA {
    internal class Piece {

        public Color color;
        public Image image;

        public Piece(Color color) {
            this.color = color;
        }

        public virtual void Move() {

        }
        


    }
}