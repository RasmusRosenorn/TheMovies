using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace theMovies.Model
{
    public class Show
    {
        public Movie MovieToShow {get; set; }
        public DateTime StartDateAndTime {get; set; }
        public int DurationInMinutes {get; set; }
    }
}
