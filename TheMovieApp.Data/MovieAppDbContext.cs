using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheMovieApp.Core;

namespace TheMovieApp.Data
{
    public class MovieAppDbContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public MovieAppDbContext(DbContextOptions<MovieAppDbContext> options) : base (options)
        {

        }
    }
}
