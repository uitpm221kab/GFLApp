using GFLApp.Data;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Net.Http.Json;

namespace GFLApp.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new GFLAppContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<GFLAppContext>>()))
            {
                // Look for any movies.
                if (context.Movie.Any())
                {
                    return;   // DB has been seeded
                }
                using (StreamReader reader = new StreamReader("C:\\Users\\Anatoliy\\source\\repos\\GFLApp\\GFLApp\\Data\\sample.json"))
                {
                    string jsonContent = reader.ReadToEnd();
                    List<Movie> movies = JsonConvert.DeserializeObject<List<Movie>>(jsonContent);

                    if (!context.Movie.Any())
                    {                      
                        context.Movie.AddRange(movies);
                        context.SaveChanges();
                    }
                }
 
            }
        }
    }
}
