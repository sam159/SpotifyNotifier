using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace SpotifyNotifier
{
    public partial class NotifyForm : Form
    {
        SpotifyDetector sd = new SpotifyDetector();

        public NotifyForm()
        {
            InitializeComponent();
            ShowInTaskbar = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            using (Stream s = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("SpotifyNotifier.Icon.ico"))
            {
                trayIcon.Icon = new Icon(s);
            }
            trayIcon.ContextMenuStrip = mnuTray;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (sd.Changed)
            {
                new Toaster(sd.Artist, sd.Track).ShowDialog();
            }
            if (this.Visible)
                this.Hide();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}
