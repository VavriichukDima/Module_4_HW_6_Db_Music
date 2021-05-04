using System.Threading.Tasks;

namespace Module_4_HW_6_Db_Music
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            await using (var context = new SampleContextFactory().CreateDbContext(args))
            {
                await new Requests(context).FirstRequestAsync();
            }

            await using (var context = new SampleContextFactory().CreateDbContext(args))
            {
                await new Requests(context).SecondRequestAsync();
            }

            await using (var context = new SampleContextFactory().CreateDbContext(args))
            {
                await new Requests(context).ThirdRequestAsync();
            }
        }
    }
}