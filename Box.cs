using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proiect_IA {
    class Box {
        private const int  boxSize = 75;
        public int x { get; set; }
        public string y { get; set; }

        public Panel panel;

        public Boolean isOccupied;

        public Piece piece;

        public Boolean nextLegalMove;

        public Box(int i, int j) {

            panel = new Panel {
                Location = new System.Drawing.Point(( j+1 ) * boxSize, (8-i) * boxSize),
                Size = new System.Drawing.Size(boxSize, boxSize),
                BackColor = (i % 2 == 0 && j % 2 == 0 || i % 2 == 1 && j % 2 == 1) ? Color.White : Color.Black
            };          
            x = i + 1;
            y = Convert.ToChar('A' + j).ToString();
            isOccupied = false;
            nextLegalMove = false;


        }

        public void AddPiece(Piece piece) {
            this.piece = piece;
            panel.BackgroundImage = piece.image;
            isOccupied = true;
        }
        static public void createBoundries(Form1 startingForm) {
            for (int i = 1; i <= 8; i++) {
                Panel left = new Panel {
                    Location = new System.Drawing.Point(0, i * 75),
                    Size = new System.Drawing.Size(75, 75),
                    BackColor = Color.LightGray                   
                };
                left.Controls.Add(new Label {
                    Location = new System.Drawing.Point(37, 37),
                    Text = (9-i).ToString() 
                });
                startingForm.Controls.Add(left);

                Panel up = new Panel {
                    Location = new System.Drawing.Point(i * 75, 0),
                    Size = new System.Drawing.Size(75, 75),
                    BackColor = Color.LightGray
                };
                up.Controls.Add(new Label {
                    Location = new System.Drawing.Point(37, 37),
                    Text = Convert.ToChar('A' + i - 1).ToString() 
                });
                startingForm.Controls.Add(up);
            }     
            
        }

        public void SwithBoxes(Box clickedBox) {
            panel.BackgroundImage = clickedBox.panel.BackgroundImage;
            clickedBox.panel.BackgroundImage = null;

            isOccupied = true;
            clickedBox.isOccupied = false;

            piece = clickedBox.piece;
            clickedBox.piece = null;
        }
    }    
}
