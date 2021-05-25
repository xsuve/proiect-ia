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
        OnlineGame onlineGame;

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
            this.btnBackToMenu.Hide();

            startGame = new Game(this);
        }

        private void btnMultiPlayer_Click(object sender, EventArgs e) {
            this.btnSinglePlayer.Hide();
            this.btnMultiPlayer.Hide();
            this.btnArtificialIntelligence.Hide();

            this.serverBtn.Show();
            this.connectBtn.Show();
            this.serverTextBox.Show();
            this.connectTextBox.Show();
            this.btnBackToMenu.Show();

            onlineGame = new OnlineGame(this);
        }

        private void btnArtificialIntelligence_Click(object sender, EventArgs e) {
            this.Size = new Size(1050, 714);

            this.label1.Hide();
            this.label2.Hide();
            this.btnSinglePlayer.Hide();
            this.btnMultiPlayer.Hide();
            this.btnArtificialIntelligence.Hide();
            this.btnBackToMenu.Hide();

            startGame = new Game(this);
        }

        private void btnBackToMenu_Click(object sender, EventArgs e) {
            this.btnSinglePlayer.Show();
            this.btnMultiPlayer.Show();
            this.btnArtificialIntelligence.Show();

            this.serverBtn.Hide();
            this.connectBtn.Hide();
            this.serverTextBox.Hide();
            this.connectTextBox.Hide();
            this.btnBackToMenu.Hide();
        }

        private void button1_Click(object sender, EventArgs e) {
            onlineGame.StartServer(serverTextBox.Text);
        }

        private void button2_Click(object sender, EventArgs e) {
            onlineGame.Connect(connectTextBox.Text);
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e) {
            onlineGame.ReceiveData();
        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e) {
            onlineGame.SendData();
        }
    }
}
