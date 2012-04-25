namespace SpotifyNotifier
{
    partial class Toaster
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblArtist = new System.Windows.Forms.Label();
            this.lblTrack = new System.Windows.Forms.Label();
            this.tmrFade = new System.Windows.Forms.Timer(this.components);
            this.tmrShow = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // lblArtist
            // 
            this.lblArtist.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblArtist.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblArtist.Location = new System.Drawing.Point(12, 9);
            this.lblArtist.Name = "lblArtist";
            this.lblArtist.Size = new System.Drawing.Size(304, 23);
            this.lblArtist.TabIndex = 0;
            this.lblArtist.Text = "Artist";
            this.lblArtist.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTrack
            // 
            this.lblTrack.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTrack.Location = new System.Drawing.Point(12, 39);
            this.lblTrack.Name = "lblTrack";
            this.lblTrack.Size = new System.Drawing.Size(304, 23);
            this.lblTrack.TabIndex = 1;
            this.lblTrack.Text = "Track";
            this.lblTrack.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // tmrFade
            // 
            this.tmrFade.Enabled = true;
            this.tmrFade.Interval = 50;
            this.tmrFade.Tick += new System.EventHandler(this.tmrFade_Tick);
            // 
            // tmrShow
            // 
            this.tmrShow.Interval = 5000;
            this.tmrShow.Tick += new System.EventHandler(this.tmrShow_Tick);
            // 
            // Toaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(328, 71);
            this.Controls.Add(this.lblTrack);
            this.Controls.Add(this.lblArtist);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Toaster";
            this.Opacity = 0;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "New Song";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Toaster_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Toaster_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblArtist;
        private System.Windows.Forms.Label lblTrack;
        private System.Windows.Forms.Timer tmrFade;
        private System.Windows.Forms.Timer tmrShow;
    }
}