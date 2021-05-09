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
                BackColor = (i % 2 == 0 && j % 2 == 0 || i % 2 == 1 && j % 2 == 1) ? Color.BurlyWood : Color.Moccasin
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
                    Location = new System.Drawing.Point(30, 30),
                    Text = (9-i).ToString(),
                    Font = new Font("Arial", 12, FontStyle.Bold),
                    ForeColor = Color.Gray
                });
                startingForm.Controls.Add(left);

                Panel up = new Panel {
                    Location = new System.Drawing.Point(i * 75, 0),
                    Size = new System.Drawing.Size(75, 75),
                    BackColor = Color.LightGray
                };
                up.Controls.Add(new Label {
                    Location = new System.Drawing.Point(30, 30),
                    Text = Convert.ToChar('A' + i - 1).ToString(),
                    Font = new Font("Arial", 12, FontStyle.Bold),
                    ForeColor = Color.Gray
                });
                startingForm.Controls.Add(up);

                // Colt
                Panel corner = new Panel {
                    Location = new System.Drawing.Point(0, 0),
                    Size = new System.Drawing.Size(75, 75),
                    BackColor = Color.LightGray
                };
                startingForm.Controls.Add(corner);
            }     
            
        }

        static public void createHostageJail(Form1 startingForm) {
            Panel player1Jail = new Panel {
                Location = new System.Drawing.Point(9 * 75, 75),
                Size = new System.Drawing.Size(5 * 75, 75),
                BackColor = Color.LightGray
            };
            startingForm.Controls.Add(player1Jail);

            Panel player2Jail = new Panel {
                Location = new System.Drawing.Point(10 * 75, 7 * 75),
                Size = new System.Drawing.Size(3 * 75, 75),
                BackColor = Color.LightGray
            };
            startingForm.Controls.Add(player2Jail);
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
