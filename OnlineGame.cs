using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proiect_IA {
    class OnlineGame {
        public Form1 startingForm { get; }

        //Retea
        private TcpClient client;
        public StreamReader STR;
        public StreamWriter STW;
        public string receive;
        public int data_to_send;

        public OnlineGame(Form1 form1) {
            startingForm = form1;
        }


        public void StartServer(String serverIP) {
            TcpListener listener = new TcpListener(IPAddress.Any, 2133);
            listener.Start();
            client = listener.AcceptTcpClient();
            STR = new StreamReader(client.GetStream());
            STW = new StreamWriter(client.GetStream());
            STW.AutoFlush = true;
            startingForm.backgroundWorker1.RunWorkerAsync();                         //start receiving data in background
            startingForm.backgroundWorker2.WorkerSupportsCancellation = true;        //ability to cancel this thread

            //WhitePlayer TO DO
        }

        public void Connect(String connectIP) {
            client = new TcpClient();
            IPEndPoint IP_End = new IPEndPoint(IPAddress.Parse(connectIP), 2133);
            try {
                client.Connect(IP_End);
                if (client.Connected) {
                    STW = new StreamWriter(client.GetStream());
                    STR = new StreamReader(client.GetStream());
                    STW.AutoFlush = true;
                    startingForm.backgroundWorker1.RunWorkerAsync();                         //start receiving data in background
                    startingForm.backgroundWorker2.WorkerSupportsCancellation = true;        //ability to cancel this thread

                    //BlackPlAYER TO DO
                }
            }
            catch (Exception x) {
                MessageBox.Show(x.Message.ToString());
            }
        }
        //[tabla1] [tabla2] [inchisoare] [aeroport]
        //[00][10][-][-] 
        //[-][30][1n][-]
        public void ReceiveData() {
            while (client.Connected)
                try {

                    string data_received = STR.ReadLine();
                    int data = Int32.Parse(data_received);
                    //TO DO 

                }
                catch (Exception x) {
                    MessageBox.Show(x.Message.ToString());
                }
        }

        public void CreateDataToSend() {

            startingForm.backgroundWorker2.RunWorkerAsync();

        }

        public void SendData() {

            if (client.Connected) {
               // WhiteMove = !WhiteMove;
                STW.WriteLine(data_to_send.ToString());
            }
            else {
                MessageBox.Show("Send Faild ");
            }
            startingForm.backgroundWorker2.CancelAsync();

        }

       
    }
}
