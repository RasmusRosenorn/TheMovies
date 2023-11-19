using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using theMovies.ViewModel;

namespace theMovies
{
    /// <summary>
    /// Interaction logic for Movies.xaml
    /// </summary>
    public partial class Movies : Window
    {
        MovieViewModel movievm = new MovieViewModel();
        public Movies()
        {
            InitializeComponent();
            DataContext = movievm;
        }
    }
}
