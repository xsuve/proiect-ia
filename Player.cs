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
        public List<Box> airport = new List<Box>();
        public List<Box> jails = new List<Box>();

        public Player(string name, Color color) {
            this.name = name;
            this.color = color;
            setPieces();
        }

        public void enablePieces() {
            for (int i = 0; i < pieces.Count; i++) {
                pieces[i].enable();
            }
        }
        public void disablePieces() {
            for (int i = 0; i < pieces.Count; i++) {
                pieces[i].disable();
            }
        }

        private void setPieces() {
            if (color == Color.Black)
                blackPieces();
            else
                whitePieces();
 
        }
        private void whitePieces() {
           
            for (int i = 0; i < 8; i++) {
                pieces.Add(new Pawn(color, 1));
                Game.board[1, i].AddPiece(pieces[pieces.Count - 1]);
            }

            pieces.Add(new Rook(color, 3));
            Game.board[0, 0].AddPiece(pieces[pieces.Count - 1]);

            pieces.Add(new Knight(color, 2));
            Game.board[0, 1].AddPiece(pieces[pieces.Count - 1]);

            pieces.Add(new Bishop(color, 2));
            Game.board[0, 2].AddPiece(pieces[pieces.Count - 1]);

            pieces.Add(new King(color, 5));
            Game.board[0, 3].AddPiece(pieces[pieces.Count - 1]);

            pieces.Add(new Queen(color, 4));
            Game.board[0, 4].AddPiece(pieces[pieces.Count - 1]);

            pieces.Add(new Bishop(color, 2));
            Game.board[0, 5].AddPiece(pieces[pieces.Count - 1]);

            pieces.Add(new Knight(color, 2));
            Game.board[0, 6].AddPiece(pieces[pieces.Count - 1]);

            pieces.Add(new Rook(color, 3));
            Game.board[0, 7].AddPiece(pieces[pieces.Count - 1]);

        }

        private void blackPieces() {

            for (int i = 0; i < 8; i++) {
                pieces.Add(new Pawn(color, 1));
                Game.board[6, i].AddPiece(pieces[pieces.Count - 1]);
            }

            pieces.Add(new Rook(color, 3));
            Game.board[7, 0].AddPiece(pieces[pieces.Count - 1]);

            pieces.Add(new Knight(color, 2));
            Game.board[7, 1].AddPiece(pieces[pieces.Count - 1]);

            pieces.Add(new Bishop(color, 2));
            Game.board[7, 2].AddPiece(pieces[pieces.Count - 1]);

            pieces.Add(new King(color, 5));
            Game.board[7, 3].AddPiece(pieces[pieces.Count - 1]);

            pieces.Add(new Queen(color, 4));
            Game.board[7, 4].AddPiece(pieces[pieces.Count - 1]);

            pieces.Add(new Bishop(color, 2));
            Game.board[7, 5].AddPiece(pieces[pieces.Count - 1]);

            pieces.Add(new Knight(color, 2));
            Game.board[7, 6].AddPiece( pieces[pieces.Count - 1]);

            pieces.Add(new Rook(color, 3));
            Game.board[7, 7].AddPiece(pieces[pieces.Count - 1]);

        }
    }
}
