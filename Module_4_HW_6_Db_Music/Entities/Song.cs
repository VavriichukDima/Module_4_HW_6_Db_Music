using System;
using System.Collections.Generic;

namespace Module_4_HW_6_Db_Music.Entities
{
    public class Song
    {
        public int SongId { get; set; }
        public string SongTitle { get; set; }
        public TimeSpan Duration { get; set; }
        public DateTime ReleasedDate { get; set; }
        public int GenreId { get; set; }

        public virtual Genre Genre { get; set; }
        public virtual List<Artist> Artists { get; set; } = new List<Artist>();
    }
}