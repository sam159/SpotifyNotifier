using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace SpotifyNotifier
{
    public partial class NotifyForm : Form
    {
        SpotifyDetector sd = new SpotifyDetector();

        Toaster currentToast = null;

        public NotifyForm()
        {
            InitializeComponent();
            //Also minimized, timer will hide window as can't do it here.
            ShowInTaskbar = false;
        }

        private void ShowToaster()
        {
            if (currentToast != null)
                currentToast.Close();
            currentToast = new Toaster(sd.Artist, sd.Track);
            currentToast.Show();
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
                ShowToaster();
            }
            //This form should not be visible
            if (this.Visible)
                this.Hide();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void trayIcon_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;

            if (sd.ProcessID != 0)
                ShowToaster();
        }

    }
}
