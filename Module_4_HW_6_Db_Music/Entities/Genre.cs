using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_4_HW_6_Db_Music.Entities
{
    public class Genre
    {
        public int GenreId { get; set; }
        public string Title { get; set; }

        public List<Song> Songs { get; set; } = new List<Song>();
    }
}
