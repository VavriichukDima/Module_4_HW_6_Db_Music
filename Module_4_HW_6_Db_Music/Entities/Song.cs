using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_4_HW_6_Db_Music.Entities
{
    public class Song
    {
        public int SongId { get; set; }
        public string SongTitle { get; set; }
        public TimeSpan Duration { get; set; }
        public DateTime ReleasedDate { get; set; }

        public Genre Genre { get; set; }
        public List<Artist> Artists { get; set; } = new List<Artist>();
    }
}
