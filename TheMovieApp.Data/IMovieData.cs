using System.Collections.Generic;
using TheMovieApp.Core;

namespace TheMovieApp.Data
{
    public interface IMovieData
    {
        
        Movie GetById(int id);
        IEnumerable<Movie> GetByGenre(List<Genre> genre);
        IEnumerable<Movie> GetAll();
        Movie Update(Movie updateMovie);
        Movie Add(Movie addMovie);
        Movie Delete(int id);
        int Commit();
    }
}
