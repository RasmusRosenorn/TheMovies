using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using theMovies.Commands;
using theMovies.Model;
using System.ComponentModel;
using System.Windows;

namespace theMovies.ViewModel
{
    public class MovieViewModel : INotifyPropertyChanged
    {
        MovieRepository movieRepo = new MovieRepository();
        public ObservableCollection<Movie> MoviesVM { get; set; } = new ObservableCollection<Movie>();
        private Movie _selectedMovie;
        private string? oldTitle = null;
        public Movie SelectedMovie
        {
            get { return _selectedMovie; }
            set
            {
                UpdateSelectedMovie();
                _selectedMovie = value;
                OnPropertyChanged("SelectedMovie");
            }
        }
        public ICommand NewMovieCmd {get; set; } = new NewMovieCommand();
        public ICommand DeleteMovieCmd {get; set; } = new DeleteMovieCommand();

        public MovieViewModel()
        {
            foreach (Movie movie in movieRepo.GetAll())
            {
                MoviesVM.Add(movie);
            }
        }   
        public void AddDefaultMovie()
        {
            Movie movie = new Movie("Title", 1, "Genre");
            //movie.ID = MoviesVM.Count() + 1;
            movieRepo.Create(movie);
            movie.ID = movieRepo.Read("Title").ID;
            MoviesVM.Add(movie);
            SelectedMovie = MoviesVM.Last();
        }
        public void DeleteSelectedMovie()
        {
            movieRepo.Delete(SelectedMovie.ID);
            MoviesVM.Remove(SelectedMovie);
            SelectedMovie = MoviesVM.Last();
        }   
        public void UpdateSelectedMovie()
        {
            if(SelectedMovie != null)
                movieRepo.Update(SelectedMovie.ID, SelectedMovie.Title, SelectedMovie.DurationInMinutes, SelectedMovie.Genre);
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if (propertyChanged != null)
            {
                propertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        

    }

}
