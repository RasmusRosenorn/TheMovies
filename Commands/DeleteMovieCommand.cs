using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using theMovies.ViewModel;

namespace theMovies.Commands
{
    internal class DeleteMovieCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            if(parameter is MovieViewModel movievm)
            {
                movievm.DeleteSelectedMovie();
            }
        }
    }
}
