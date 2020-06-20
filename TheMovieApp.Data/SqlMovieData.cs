using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TheMovieApp.Core;

namespace TheMovieApp.Data
{
    public class SqlMovieData : IMovieData
    {
        private readonly MovieAppDbContext db;

        public SqlMovieData(MovieAppDbContext db)
        {
            this.db = db;
        }
        public Movie Add(Movie addMovie)
        {
            db.Movies.Add(addMovie);
            return addMovie;
            
        }

        public int Commit()
        {
            return db.SaveChanges();
        }

        public Movie Delete(int id)
        {
            var movie = GetById(id);
            if (movie != null)
            {
                db.Movies.Remove(movie);
            }
            return movie;
        }

        public IEnumerable<Movie> GetAll()
        {
            return db.Movies.OrderBy(m => m.Name);
        }

        public IEnumerable<Movie> GetByGenre(List<Genre> genre)
        {
            return db.Movies.Where(m => m.Genres.Contains(genre[0]));
        }

        public Movie GetById(int id)
        {
            return db.Movies.Find(id);
        }

        public Movie Update(Movie updateMovie)
        {
            var movie = db.Movies.Attach(updateMovie);
            movie.State = EntityState.Modified;
            
            return updateMovie;
        }
    }
}
