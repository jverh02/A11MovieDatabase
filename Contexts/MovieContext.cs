using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MovieDatabaseA11.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDatabaseA11.Contexts
{
    public class MovieContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(AppDomain.CurrentDomain.BaseDirectory).AddJsonFile("appsettings.json").Build();

            optionsBuilder.UseSqlServer(configuration.GetConnectionString("MovieContext"));
        }
        public void ReadMovies()
        {
            foreach (var item in Movies)
            {
                Console.WriteLine(item.Id + " - " + item.Title + ", " + item.Genres);
            }
        }
        public void AddMovie()
        {
            var movie = new Movie();
            Console.Write("Please insert the movie's title.\n>");
            movie.Title = Console.ReadLine();
            Console.Write("Please insert the movie's genre(s).\n>");
            movie.Genres = Console.ReadLine();
            Add(movie);
            SaveChanges();
        }
        public void SearchMovie(string query)
        {
            var listMovies = Movies.ToList();
            var result = listMovies.Where(x => x.Title.Contains(query, StringComparison.CurrentCultureIgnoreCase)).ToList();
            Console.WriteLine("Here's what we found:");
            foreach (var item in result)
            {
                Console.WriteLine(item.Id + " - " + item.Title + ", " + item.Genres);
            }
            }
        }
}
