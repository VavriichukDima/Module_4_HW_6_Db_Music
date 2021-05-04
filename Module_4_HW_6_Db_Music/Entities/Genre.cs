using System.Collections.Generic;

namespace Module_4_HW_6_Db_Music.Entities
{
    public class Genre
    {
        public int GenreId { get; set; }
        public string Title { get; set; }

        public virtual List<Song> Songs { get; set; } = new List<Song>();
    }
}