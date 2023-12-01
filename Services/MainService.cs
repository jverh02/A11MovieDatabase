using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieDatabaseA11.Contexts;

namespace MovieDatabaseA11.Services
{
    internal class MainService : IMainService
    {
        private MovieContext _context = new MovieContext();
        public void Invoke()
        {
            var done = false;
            while (!done)
            {
                Console.Write("Choose an option:\n1. Search for a movie by title\n2. Add movie\n3. List all movies\n4. Exit\n>");
                var choice = Int32.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.Write("Please enter what you'd like to search for.\n>");
                        var toSearch = Console.ReadLine();
                        _context.SearchMovie(toSearch);
                        break;
                    case 2:
                        _context.AddMovie();
                        break;
                    case 3:
                        _context.ReadMovies();
                        break;
                    case 4:
                        done = true;
                        Console.WriteLine("Exiting...\n");
                        break;
                    default:
                        Console.WriteLine("ERROR: Please choose one of the given options.\n");
                        break;
                }
                Console.WriteLine(""); //formatting
            }
        }
    }
}
