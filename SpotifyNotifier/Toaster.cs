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
            Width = Properties.Settings.Default.ToasterWidth;
            Height = Properties.Settings.Default.ToasterHeight;

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

        /// <summary>
        /// Returns true to stop focus stealing
        /// </summary>
        protected override bool ShowWithoutActivation
        {
            get
            {
                return true;
            }
        }

        const int WS_EX_NOACTIVATE = 0x08000000;
        const int WS_EX_TOPMOST = 0x00000008;

        /// <summary>
        /// stop focus stealing
        /// </summary>
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams param = base.CreateParams;
                param.ExStyle |= WS_EX_TOPMOST; // make the form topmost
                param.ExStyle |= WS_EX_NOACTIVATE; // prevent the form from being activated
                return param;
            }
        }


        private void SavePosition(object sender, EventArgs e)
        {
            //Save the forms poisition when moving
            Properties.Settings.Default.ToasterX = Top;
            Properties.Settings.Default.ToasterY = Left;
            Properties.Settings.Default.ToasterWidth = Width;
            Properties.Settings.Default.ToasterHeight = Height;
            Properties.Settings.Default.Save();
        }

        private void Toaster_Shown(object sender, EventArgs e)
        {
            //Attatch at runtime. This is to stop it being fired when the form is first shown with the default values
            this.Move += new EventHandler(SavePosition);
            this.Resize += new EventHandler(SavePosition);
        }
    }
}
