using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace theMovies.Model
{
    public class Movie
    {   
        //static int idCounter = 1;
        public int ID { get; set; }
        public string Title { get; set; }
        public int DurationInMinutes { get; set; }
        public string Genre { get; set; }
        public string Director {get; set; }
        public DateOnly PremiereDate {get; set; }
        public Movie(string title, int durationInMinutes, string genre)
        {
            //ID = idCounter;
            //idCounter++;
            Title = title;
            DurationInMinutes = durationInMinutes;
            Genre = genre;
        }
        //public Movie(int id, string title, int durationInMinutes, string genre)
        //{
        //    ID = id;
        //    Title = title;
        //    DurationInMinutes = durationInMinutes;
        //    Genre = genre;
        //}
    }
}
