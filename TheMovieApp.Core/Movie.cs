using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheMovieApp.Core
{
    [ComplexType]
    public class Movie
    {
        public int Id { get; set; }
        [Required, MinLength(4)]
        public string Name { get; set; }
        [Required, MinLength(10),MaxLength(250)]
        public string Description { get; set; }
        [Required]
        public string Distributor { get; set; }
        public Person Director { get; set; }
        public List<Person> Starring { get; set; }
        public int Percentage { get; set; }
        [NotMapped]
        public List<Genre> Genres { get; set; }
        public Movie()
        {
            // Hello test
            Starring = new List<Person>();
            Genres = new List<Genre>();
        }
    }
}
