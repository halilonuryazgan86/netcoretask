﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NetCoreTask.WindowsApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnHesapla_Click(object sender, EventArgs e)
        {
            int number = Convert.ToInt32(textBox1.Text);
            var result = new CalculateWorker().GetConditionResultByInput(number).ResultValue;
            lblSonuc.Text = result.ToString();
        }
    }
}
