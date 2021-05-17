using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proiect_IA {
    public partial class Form1 : Form {
        Game startGame;

        public Form1() {
            InitializeComponent();
        }

        public void Panel_Click(object sender, EventArgs e, int i, int j) {           
            startGame.pieceClick(i, j);
        }

        public void Jail_Click(object sender, EventArgs e, int i, Player player) {
            startGame.jailClick(i, player);
        }

        public void Airport_Click(object sender, EventArgs e, int i, Player player) {
            startGame.airportClick(i, player);
        }

        private void btnSinglePlayer_Click(object sender, EventArgs e) {
            this.Size = new Size(1050, 714);

            this.label1.Hide();
            this.label2.Hide();
            this.btnSinglePlayer.Hide();
            this.btnMultiPlayer.Hide();
            this.btnArtificialIntelligence.Hide();

            startGame = new Game(this);
        }

        private void btnMultiPlayer_Click(object sender, EventArgs e) {
            this.Size = new Size(1050, 714);

            this.label1.Hide();
            this.label2.Hide();
            this.btnSinglePlayer.Hide();
            this.btnMultiPlayer.Hide();
            this.btnArtificialIntelligence.Hide();

            startGame = new Game(this);
        }

        private void btnArtificialIntelligence_Click(object sender, EventArgs e) {
            this.Size = new Size(1050, 714);

            this.label1.Hide();
            this.label2.Hide();
            this.btnSinglePlayer.Hide();
            this.btnMultiPlayer.Hide();
            this.btnArtificialIntelligence.Hide();

            startGame = new Game(this);
        }
    }
}
