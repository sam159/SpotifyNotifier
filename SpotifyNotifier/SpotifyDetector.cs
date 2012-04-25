using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace SpotifyNotifier
{
    class SpotifyDetector
    {
        /// <summary>
        /// The current detected spotify process
        /// </summary>
        Process spotifyProcess = null;

        string artist = String.Empty;
        string track = String.Empty;

        /// <summary>
        /// Gets the spotify process ID or 0 if not found
        /// </summary>
        public int ProcessID
        {
            get
            {
                if (spotifyProcess == null)
                    return 0;
                return spotifyProcess.Id;
            }
        }
        /// <summary>
        /// True if artist/track has changed from the last time
        /// </summary>
        public bool Changed
        {
            get
            {
                return UpdateDetails();
            }
        }

        /// <summary>
        /// Gets the playing artist
        /// </summary>
        public string Artist
        {
            get
            {
                if (spotifyProcess == null)
                    return "";
                return this.artist;
            }
        }
        /// <summary>
        /// Gets the playing track
        /// </summary>
        public string Track
        {
            get
            {
                if (spotifyProcess == null)
                    return "";
                return this.track;
            }
        }

        public SpotifyDetector()
        {
            FindProcess();
        }

        /// <summary>
        /// Finds a running spotify process based on its process name
        /// </summary>
        /// <returns>Process found</returns>
        private bool FindProcess()
        {
            var processes = Process.GetProcesses();
            foreach (var process in processes)
            {

                if (process.ProcessName == "spotify")
                {
                    spotifyProcess = process;
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Detectes the artist/track from the spotify main title.
        /// </summary>
        /// <returns>True if artist/track has changed since last call</returns>
        private bool UpdateDetails()
        {
            if (spotifyProcess == null
                && FindProcess() == false)
                return false;
            //Reload the process info
            spotifyProcess.Refresh();

            //Clear info if spotify has exited
            if (spotifyProcess.HasExited)
            {
                spotifyProcess = null;
                this.artist = String.Empty;
                this.track = String.Empty;
                return false;
            }
            
            //Find the track artist from the format "Spotify - <Artist> - <Track>"
            string title = spotifyProcess.MainWindowTitle;
            title = title.Replace("Spotify - ", "");

            int position = title.IndexOf('–');
            if (position < 0)
                return false;

            var currentArtist = title.Substring(0, position).Trim();
            var currentTrack = title.Substring(position+1).Trim();
            //Update if changed
            if (currentArtist != this.artist
                || currentTrack != this.track)
            {
                this.artist = currentArtist;
                this.track = currentTrack;
                return true;
            }
            return false;
        }

    }
}
