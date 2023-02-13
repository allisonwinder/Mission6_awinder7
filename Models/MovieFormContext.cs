using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.Models
{
    public class MovieFormContext : DbContext
    {
        public MovieFormContext (DbContextOptions <MovieFormContext> options) : base (options)
        {
            //come back
        }

        public DbSet<MovieFormResponse> Responses { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<MovieFormResponse>().HasData(
                new MovieFormResponse
                {
                    FormId = 1,
                    Category = "Family",
                    Title = "Tangled",
                    Year = 2010,
                    Director = "Nathan Greno & Byron Howard",
                    Rating = "PG",
                    Edited = false,
                    LentTo = "",
                    Notes = "The best movie to ever exist."
                },
                new MovieFormResponse
                {
                    FormId = 2,
                    Category = "Family",
                    Title = "The Greatest Showman",
                    Year = 2017,
                    Director = "Michael Gracey",
                    Rating = "PG",
                    Edited = false,
                    LentTo = "",
                    Notes = ""
                },
                new MovieFormResponse
                {
                    FormId = 3,
                    Category = "Action/Adventure",
                    Title = "Thor: Ragnarok",
                    Year = 2017,
                    Director = "Taika Waititi",
                    Rating = "PG-13",
                    Edited = false,
                    LentTo = "",
                    Notes = ""
                }
                );
        }
    }
}
