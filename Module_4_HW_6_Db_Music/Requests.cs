using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Module_4_HW_6_Db_Music
{
    public class Requests
    {
        private readonly ApplicationContext _context;

        public Requests(ApplicationContext context)
        {
            _context = context;
        }

        public async Task FirstRequestAsync()
        {
            var allInfo = await _context.Songs
                .Select(z => new { SongName = z.SongTitle, Artist = z.Artists.Select(x => x.Name), Genre = z.Genre.Title })
                .ToListAsync();

            Console.WriteLine("----FirstRequest----");
            foreach (var temp in allInfo)
            {
                Console.WriteLine($"SongName: {temp.SongName}, Artist name: {temp.Artist}, Genre: {temp.Genre}");
            }

            _context.SaveChanges();
        }

        public async Task SecondRequestAsync()
        {
            var numOfSongs = await _context.Songs
                .GroupBy(x => x.Genre.Title)
                .Select(c => new { c.Key, Count = c.Count() })
                .ToListAsync();

            Console.WriteLine("----SecondRequest----");
            foreach (var temp in numOfSongs)
            {
                Console.WriteLine($"Genre: {temp.Key}, CountOfSongs: {temp.Count}");
            }

            _context.SaveChanges();
        }

        public async Task ThirdRequestAsync()
        {
            var someSongs = await _context.Songs
                .Where(z => z.ReleasedDate < z.Artists.Max(x => x.DateOfBirth))
                .ToListAsync();

            Console.WriteLine("----ThirdRequest----");
            foreach (var temp in someSongs)
            {
                Console.WriteLine($"Song: {temp.SongTitle}, ReleasedDate: {temp.ReleasedDate}");
            }

            _context.SaveChanges();
        }
    }
}