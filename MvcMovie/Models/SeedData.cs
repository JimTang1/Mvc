using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcMovie.Data;
using System;
using System.Linq;

namespace MvcMovie.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MvcMovieContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MvcMovieContext>>()))
            {
                // Look for any movies.
                if (context.Movie.Any())
                {
                    return;   // DB has been seeded
                }

                context.Movie.AddRange(
                    new Movie
                    {
                        Title = "The RM",
                        ImageUrl = "Jesus.jpg",
                        ReleaseDate = DateTime.Parse("1989-2-12"),
                        GenreId = 1,
                        Price = 7.99M,
                        Rating = "R"
                    },

                    new Movie
                    {
                        Title = "Other Side of Heaven",
                        ImageUrl = "Jesus.jpg",
                        ReleaseDate = DateTime.Parse("1984-3-13"),
                        GenreId = 2,
                        Price = 8.99M,
                        Rating = "R"
                    },

                    new Movie
                    {
                        Title = "Meet the Mormons",
                        ImageUrl = "Jesus.jpg",
                        ReleaseDate = DateTime.Parse("1986-2-23"),
                        GenreId = 3,
                        Price = 9.99M,
                        Rating = "R"
                    },

                    new Movie
                    {
                        Title = "One Church movie!",
                        ImageUrl = "~/img/Jesus.jpg",
                        ReleaseDate = DateTime.Parse("1959-4-15"),
                        GenreId = 4,
                        Price = 3.99M,
                        Rating = "R"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}