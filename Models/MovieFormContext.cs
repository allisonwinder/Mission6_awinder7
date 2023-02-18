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
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Category>().HasData(
                new Category
                {
                    CategoryId = 1, CategoryName = "Action/Adventure"
                },
                new Category
                {
                    CategoryId = 2, CategoryName = "Comedy"
                },
                new Category
                {
                    CategoryId=3, CategoryName="Drama"
                },
                new Category
                {
                    CategoryId = 4, CategoryName="Family"
                },
                new Category
                {
                    CategoryId = 5, CategoryName ="Horror/Suspense"
                },
                new Category
                {
                    CategoryId = 6, CategoryName = "Miscellaneous"
                },
                new Category
                {
                    CategoryId = 7, CategoryName = "Television"
                },
                new Category
                {
                    CategoryId=8, CategoryName="VHS"
                }
                );
            mb.Entity<MovieFormResponse>().HasData(
                new MovieFormResponse
                {
                    FormId = 1,
                    CategoryId = 4,
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
                    CategoryId = 4,
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
                    CategoryId = 1,
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
