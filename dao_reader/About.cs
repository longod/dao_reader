// (c) hikami, aka longod
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace dao_reader {
    public partial class About : Form {
        string url = @"http://blackmasqueradegames.com/";

        public About() {
            InitializeComponent();
        }

        public About( string version ) {
            InitializeComponent();
            label2.Text += " " + version;
            linkLabel1.Text = url;
        }

        private void buttonOK_Click( object sender, EventArgs e ) {
            this.Close();
        }

        private void linkLabel1_LinkClicked( object sender, LinkLabelLinkClickedEventArgs e ) {
            linkLabel1.LinkVisited = true;
            System.Diagnostics.Process.Start( url );
        }
    }
}