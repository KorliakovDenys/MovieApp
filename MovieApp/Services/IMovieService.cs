using MovieApp.Models;

namespace MovieApp.Services {
    public interface IMovieService {
        List<Movie>? Movies { get; set; }
        public string Url { get; }
        Task GetMoviesAsync();
        Task<Movie?> GetMovieByIdAsync(int id);
        Task<Session?> GetSessionByIdAsync(int id);
        Task CreateMovieAsync(Movie movie);
        Task UpdateMovieAsync(int id, Movie movie);
        Task DeleteMovieAsync(int id);
    }
}