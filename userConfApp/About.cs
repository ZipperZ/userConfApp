﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace userConfApp
{
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
        }

        private void About_Load(object sender, EventArgs e)
        {
            versionContLabel.Text = mainWindow.version;
            uptimeCont.Text = "Not Stored";//mainWindow.uptime.ToString();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
