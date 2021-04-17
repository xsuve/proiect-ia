using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proiect_IA {
    class Board {
        private Form1 startingForm;

        private Cell[,] board = new Cell[8,8];
        public Board(Form1 form) {
            startingForm = form;
        }

        public void createTable() {
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

            for (int i = 1; i <= 8; i++) {
                for (int j = 1; j <= 8; j++) {
                    board[i-1, j-1] = new Cell {
                        panel = new Panel {
                            Location = new System.Drawing.Point(j * 75, i * 75),
                            Size = new System.Drawing.Size(75, 75),
                            BackColor = (i % 2 == 0 && j % 2 == 0 || i % 2 == 1 && j % 2 == 1) ? Color.White : Color.Black
                        },
                        y = j + 1,
                        x = Convert.ToChar('A' + i-1).ToString(),
                    };
                   
                    startingForm.Controls.Add(board[i-1,j-1].panel);
                }
            }
        }
    }    
}
