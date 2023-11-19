using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace theMovies.Model
{
    public class Cinema
    {
        public string City {get; set; }
        public TimeOnly Open {get; set; }
        public TimeOnly Close {get; set; }

    }
}
