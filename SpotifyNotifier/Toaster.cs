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

        /// <summary>
        /// New Toaster (using new fadeable bread)
        /// </summary>
        /// <param name="artist">The artist</param>
        /// <param name="track">The track</param>
        public Toaster(string artist, string track)
        {
            InitializeComponent();

            lblArtist.Text = artist;
            lblTrack.Text = track;
            //Set position from previous toaster (See Form_Closing)
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
                //Stop Fading
                tmrFade.Enabled = false;
                //Fade out next time enabled
                fadeIn = false;

                tmrShow.Enabled = true;
            }
            if (this.Opacity == 0 && !fadeIn)
            {
                //Faded out, exit.
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
            //Save the forms poisition when closing
            Properties.Settings.Default.ToasterX = Top;
            Properties.Settings.Default.ToasterY = Left;
            Properties.Settings.Default.Save();
        }
    }
}
