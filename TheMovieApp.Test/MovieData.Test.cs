using NUnit.Framework;
using NUnit.Framework.Constraints;
using System;
using System.Collections.Generic;
using TheMovieApp.Core;
using TheMovieApp.Data;

namespace TheMovieApp.Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            // Arrange
            IMovieData movieData = new MovieData();
            Movie actual = new Movie();
            actual = movieData.GetById(1);
            // Act
            var expected = "Bad Boys for Life";
            Console.WriteLine(actual.Name);
            Assert.AreEqual(expected, actual.Name);
        }
        [Test]
        public void GetByGenre_Test()
        {
            // Arrange
            IMovieData movieData = new MovieData();
            IEnumerable<Movie> actual = new List<Movie>();
            List<Genre> g = new List<Genre>() { Genre.Adventure, Genre.Action};
            
            actual = movieData.GetByGenre(g);
            // Act
            foreach (var item in actual)
            {
                Console.WriteLine($"{item.Name}, {item.Genres}");
            }
            
        }
        [Test]
        public void CheckStarring_Test()
        {
            // Arrange
            IMovieData movieData = new MovieData();
            IEnumerable<Movie> actual = new List<Movie>();
            Movie m = new Movie();
            m = movieData.GetById(1);
            // Act
            foreach (var item in m.Starring)
            {
                Console.WriteLine($"{item.FirstName}, {item.LastName}");
            }

        }
        [Test]
        public void GenreCheck_Test()
        {
            // Arrange
            List<Genre> g = new List<Genre>();
            IMovieData movieData = new MovieData();
            IEnumerable<Movie> actual = new List<Movie>();
            Movie m = new Movie();
            m = movieData.GetById(1);
            g = m.Genres;
            // Act
            foreach (var item in m.Starring)
            {
                Console.WriteLine($"{item.FirstName}, {item.LastName}");
            }
            foreach (var item in g)
            {
                Console.WriteLine($"{item}");
            }

        }
    }
}