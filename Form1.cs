﻿using System;
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
        public Form1() {
            InitializeComponent();
            Game startGame = new Game(this);
        }
    }
}
