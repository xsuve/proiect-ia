using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect_IA {
    public class Player {
        public string name;
        public Color color;
        List<Piece> pieces = new List<Piece>();

        public Player(string name, Color color) {
            this.name = name;
            this.color = color;
            setPieces();
        }

        private void setPieces() {
            if (color == Color.Black)
                blackPieces();
            else
                whitePieces();
 
        }
        private void whitePieces() {
           
            for (int i = 0; i < 8; i++) {
                pieces.Add(new Pawn(color));
                Game.board[1, i].piece = pieces[pieces.Count - 1];
            }

            pieces.Add(new Rook(color));
            Game.board[0, 0].piece = pieces[pieces.Count - 1];

            pieces.Add(new Knight(color, Game.board[0, 1]));
            Game.board[1, i].piece = pieces[pieces.Count - 1];

            pieces.Add(new Bishop(color, Game.board[0, 2]));
            Game.board[1, i].piece = pieces[pieces.Count - 1];

            pieces.Add(new King(color, Game.board[0, 3]));
            Game.board[1, i].piece = pieces[pieces.Count - 1];

            pieces.Add(new Queen(color, Game.board[0, 4]));
            Game.board[1, i].piece = pieces[pieces.Count - 1];

            pieces.Add(new Bishop(color, Game.board[0, 5]));
            Game.board[1, i].piece = pieces[pieces.Count - 1];

            pieces.Add(new Knight(color, Game.board[0, 6]));
            Game.board[1, i].piece = pieces[pieces.Count - 1];

            pieces.Add(new Rook(color, Game.board[0, 7]));
            Game.board[1, i].piece = pieces[pieces.Count - 1];

        }

        private void blackPieces() {
            
            for (int i = 0; i < 8; i++) {
                pieces.Add(new Pawn(color, Game.board[6, i]));
            }
            pieces.Add(new Rook(color, Game.board[7, 0]));
            pieces.Add(new Knight(color, Game.board[7, 1]));
            pieces.Add(new Bishop(color, Game.board[7, 2]));
            pieces.Add(new King(color, Game.board[7, 3]));
            pieces.Add(new Queen(color, Game.board[7, 4]));
            pieces.Add(new Bishop(color, Game.board[7, 5]));
            pieces.Add(new Knight(color, Game.board[7, 6]));
            pieces.Add(new Rook(color, Game.board[7, 7]));

            

        }
    }
}
