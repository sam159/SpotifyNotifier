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
            //Also minimized, timer will hide window as can't do it here.
            ShowInTaskbar = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Get the programs icon that is embedded
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
                //Show the new track info, as each timer call is a new thread, many toasters could be show at once.
                new Toaster(sd.Artist, sd.Track).ShowDialog();
            }
            //This form should not be visible
            if (this.Visible)
                this.Hide();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}
