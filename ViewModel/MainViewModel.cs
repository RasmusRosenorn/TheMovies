using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Collections.ObjectModel;
using theMovies.Commands;
using theMovies.Model;


namespace theMovies.ViewModel
{
    public class MainViewModel
    {   
        public ICommand GoToMoviesCmd { get; set; } = new GoToMoviesCommand();
    }
}
