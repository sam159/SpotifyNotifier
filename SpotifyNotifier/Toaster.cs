using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SpotifyNotifier
{
    public partial class Toaster : Form
    {
        bool fadeIn = true;

        public Toaster(string artist, string track)
        {
            InitializeComponent();

            lblArtist.Text = artist;
            lblTrack.Text = track;
            Top = Properties.Settings.Default.ToasterX;
            Left = Properties.Settings.Default.ToasterY;

            ShowInTaskbar = false;
            ShowIcon = false;
        }

        private void Toaster_Load(object sender, EventArgs e)
        {

        }

        private void tmrFade_Tick(object sender, EventArgs e)
        {
            if (fadeIn)
                Opacity += 0.1;
            else
                Opacity -= 0.05;

            if (Opacity == 1 && fadeIn)
            {
                tmrFade.Enabled = false;
                fadeIn = false;
                tmrShow.Enabled = true;
            }
            if (this.Opacity == 0 && !fadeIn)
            {
                tmrFade.Enabled = false;
                this.Close();
            }
        }

        private void tmrShow_Tick(object sender, EventArgs e)
        {
            tmrFade.Enabled = true;
        }

        private void Toaster_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.ToasterX = Top;
            Properties.Settings.Default.ToasterY = Left;
            Properties.Settings.Default.Save();
        }
    }
}
