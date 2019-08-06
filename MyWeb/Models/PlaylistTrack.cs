using System;
using System.Collections.Generic;

namespace MyWeb.Models
{
    public partial class PlaylistTrack
    {
        public long PlaylistId { get; set; }
        public long TrackId { get; set; }

        public virtual Playlists Playlist { get; set; }
        public virtual Tracks Track { get; set; }
    }
}
