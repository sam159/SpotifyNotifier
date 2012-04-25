using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace SpotifyNotifier
{
    class SpotifyDetector
    {
        Process spotifyProcess = null;

        string artist = String.Empty;
        string track = String.Empty;

        public int ProcessID
        {
            get
            {
                if (spotifyProcess == null)
                    return 0;
                return spotifyProcess.Id;
            }
        }

        public bool Changed
        {
            get
            {
                return UpdateDetails();
            }
        }

        public string Artist
        {
            get
            {
                if (spotifyProcess == null)
                    return "";
                return this.artist;
            }
        }
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

        private bool UpdateDetails()
        {
            if (spotifyProcess == null
                && FindProcess() == false)
                return false;

            spotifyProcess.Refresh();

            if (spotifyProcess.HasExited)
            {
                spotifyProcess = null;
                this.artist = String.Empty;
                this.track = String.Empty;
                return false;
            }

            string title = spotifyProcess.MainWindowTitle;
            title = title.Replace("Spotify - ", "");

            int position = title.IndexOf('–');
            if (position < 0)
                return false;

            var currentArtist = title.Substring(0, position).Trim();
            var currentTrack = title.Substring(position+1).Trim();

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
