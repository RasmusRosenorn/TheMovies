using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace theMovies.Model
{
    public class MovieRepository
    {
        public void Create(Movie movie)
        {
            string queryString = "insert into tm_Movies (Title, DurationInMinutes, Genre) values (@Title, @DurationInMinutes, @Genre);";
            using (SqlConnection connection = new SqlConnection(SqlCon.ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@Title", movie.Title);
                command.Parameters.AddWithValue("@DurationInMinutes", movie.DurationInMinutes);
                command.Parameters.AddWithValue("@Genre", movie.Genre);
                command.ExecuteNonQuery();
            }
        }
        public Movie Read(string title)
        {
            string queryString = "select * from tm_Movies where Title = @Title;";
            using (SqlConnection connection = new SqlConnection(SqlCon.ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@Title", title);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (reader.GetString(1) == title)
                        {
                            Movie movie = new Movie(reader.GetString(1), reader.GetInt32(2), reader.GetString(3));
                            movie.ID = reader.GetInt32(0);
                            return movie;
                        }
                    }
                }
            }
            return null;
        }
        //$"Title: {reader.GetString(1)}, Duration: {reader.GetInt32(2)} Minutes, Genre: {reader.GetString(3)}"
        public void Update(int ID, string newTitle, int? newDurationInMinutes, string newGenre)
        {
            string queryString = "update tm_Movies set Title = @Title, DurationInMinutes = @DurationInMinutes, Genre = @Genre where ID = @ID;";
            using (SqlConnection connection = new SqlConnection(SqlCon.ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@Title", newTitle);
                command.Parameters.AddWithValue("@DurationInMinutes", newDurationInMinutes);
                command.Parameters.AddWithValue("@Genre", newGenre);
                command.Parameters.AddWithValue("@ID", ID);
                command.ExecuteNonQuery();
            }
        }
        public void Delete(int ID)
        {
            string queryString = "delete from tm_Movies where ID = @ID;";

            using (SqlConnection connection = new SqlConnection(SqlCon.ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@ID", ID);
                command.ExecuteNonQuery();
            }
        }
        public List<Movie> GetAll()
        {
            string queryString = "select * from tm_Movies;";
            List<Movie> movies = new List<Movie>();
            using (SqlConnection connection = new SqlConnection(SqlCon.ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(queryString, connection);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        movies.Add(new Movie(reader.GetString(1), reader.GetInt32(2), reader.GetString(3)));
                    }
                }
            }
            return movies;
        }


    }
}
