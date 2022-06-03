using ChallengeDotnetAPI.Models;

namespace ChallengeDotnetAPI.Data
{
    public class DbInitializer
    {
        public static void Initialize(DisneyContext context)
        {
            // Look for any movies.
            if (context.Movies.Any())
            {
                return;   // DB has been seeded
            }

            
            
            var movies = new Movie[]
            {
                new Movie{Title="Avengers: Infinity War", CreationDate=new System.DateTime(2018, 4, 25), Genre=new Genre{Name="Action"}, Score=1},
                new Movie{Title="Avengers: Endgame", CreationDate=new System.DateTime(2019, 4, 25), Genre=new Genre{Name="Action"}, Score=2},
                new Movie{Title="Avengers: Age of Ultron", CreationDate=new System.DateTime(2015, 4, 25), Genre=new Genre{Name="Action"}, Score=3},
                new Movie{Title="Avengers: The Avengers 2", CreationDate=new System.DateTime(2012, 4, 25), Genre=new Genre{Name="Action"}, Score=4},
                new Movie{Title="Avengers: Infinity War 2", CreationDate=new System.DateTime(2018, 4, 25), Genre=new Genre{Name="Action"}, Score=5},
                new Movie{Title="Avengers: Endgame 2", CreationDate=new System.DateTime(2019, 4, 25), Genre=new Genre{Name="Action"}, Score=5},
                new Movie{Title="Avengers: Age of Ultron 2", CreationDate=new System.DateTime(2015, 4, 25), Genre=new Genre{Name="Action"}, Score=3},
                new Movie{Title="Avengers: The Avengers 3", CreationDate=new System.DateTime(2012, 4, 25), Genre=new Genre{Name="Action"}, Score=1},
                new Movie{Title="Avengers: Infinity War 3 ", CreationDate=new System.DateTime(2018, 4, 25), Genre=new Genre{Name="Action"}, Score=2}
            };

            //context.Movies.AddRange(movies);  No es necesario

            var characters = new Character[]
            {
                new Character{Name="Mickey Mouse", Age=10, Weight=10, History="Mickey Mouse is a fictional character in the Disney animated series The Mouse and the Magic Mouse.", Movies= new List<Movie>{movies[0], movies[1]} },
                new Character{Name="Donald Duck", Age=10, Weight=10, History="Donald Duck is a fictional character in the Disney animated series The Mouse and the Magic Mouse.", Movies= new List<Movie>{movies[2], movies[3]} },
                new Character{Name="Goofy", Age=10, Weight=10, History="Goofy is a fictional character in the Disney animated series The Mouse and the Magic Mouse.", Movies= new List<Movie>{movies[1], movies[3]} },
                new Character{Name="Pluto", Age=10, Weight=10, History="Pluto is a fictional character in the Disney animated series The Mouse and the Magic Mouse.", Movies= new List<Movie>{movies[2], movies[1]} },
            };

            context.Characters.AddRange(characters);
            
            context.SaveChanges();


            

        }
    }
}
