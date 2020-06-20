using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using TheMovieApp.Core;

namespace TheMovieApp.Data
{

    public class MovieData : IMovieData
    {
        List<Movie> movies;
        IPersonData _db = new PersonData();
        Person person1 = new Person();
        Person person2 = new Person();
        
        public MovieData()
        {
            person1 = _db.GetById(1);
            person2 = _db.GetById(2);
            movies = new List<Movie>()
            {
                new Movie()
                {
                    Id = 1,
                    Name = "Bad Boys for Life",
                    Description = "It is the sequel to Bad Boys II (2003) and the third installment in the Bad Boys trilogy.",
                    Distributor = "Sony Pictures",
                    Percentage = 78,
                    Genres = {Genre.Comedy, Genre.Action },
                    Starring = new List<Person>(){ person1, person2 }
                },
                new Movie()
                {
                    Id = 2,
                    Name = "Sonic the Hedgehog",
                    Description = "Sonic the Hedgehog is a 2020 action-adventure comedy film based on" +
                    " the video game franchise published by Sega. ",
                    Distributor = "Paramount Pictures",
                    Percentage = 76,
                    Genres ={ Genre.Adventure },
                },
                new Movie()
                {
                    Id = 3,
                    Name = "Black Widow",
                    Description = "A film about Natasha Romanoff in her quests between the films Civil War and Infinity War. ",
                    Distributor = "Marvel Studios",
                    Percentage = 82,
                    Genres = {Genre.Comedy, Genre.Action },
                },
                new Movie()
                {
                    Id = 4,
                    Name = "The King's of Man",
                    Description = "As a collection of history's worst tyrants and criminal masterminds gather " +
                    "to plot a war to wipe out millions, one man must race against time to stop them. ",
                    Distributor = "20th Centuary Fox",
                    Percentage = 85,
                    Genres = {Genre.Action, Genre.Adventure },
                }
                
            };
        }

        public Movie Add(Movie addMovie)
        {
            movies.Add(addMovie);
            addMovie.Id = movies.Max(m => m.Id) + 1;
            return addMovie;
        }
        public int Commit()
        {
            return 0;
        }
        public Movie Delete(int id)
        {
            var movie =  movies.FirstOrDefault(m => m.Id == id);
            if (movie != null)
            {
                movies.Remove(movie);
            }
            return movie;
        }

        public IEnumerable<Movie> GetAll()
        {
            return movies.OrderBy(m => m.Name);
        }

        public IEnumerable<Movie> GetByGenre(List<Genre> genre)
        {
            return movies.FindAll(m => m.Genres.Contains(genre[0]));
        }

        public Movie GetById(int id)
        {
            return movies.FirstOrDefault(m => m.Id == id);
        }

        public Movie Update(Movie updateMovie)
        {
            var movie = movies.SingleOrDefault(m => m.Id == updateMovie.Id);
            if (movie != null)
            {
                movie.Name = updateMovie.Name;
                movie.Distributor = updateMovie.Distributor;
                movie.Description = updateMovie.Description;
                for (int i = 0; i < movie.Genres.Count; i++)
                {
                    movie.Genres[i] = updateMovie.Genres[i];
                }
            }
            return movie;
        }
    }
}
