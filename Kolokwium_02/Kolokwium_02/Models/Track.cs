using System;
using System.Collections.Generic;

namespace Kolokwium_02.Models
{
    public partial class Track
    {
        public Track()
        {
            MusicianTrack = new HashSet<MusicianTrack>();
        }

        public int IdTrack { get; set; }
        public string TrackName { get; set; }
        public float Duration { get; set; }
        public int? IdMusicAlbum { get; set; }

        public virtual Album IdMusicAlbumNavigation { get; set; }
        public virtual ICollection<MusicianTrack> MusicianTrack { get; set; }
    }
}
