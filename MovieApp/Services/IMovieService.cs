using MovieApp.Models;

namespace MovieApp.Services {
    public interface IMovieService {
        List<Movie>? Movies { get; set; }
        public string? Filter { get; set; }
        Task GetMoviesAsync();
        Task GetMoviesAsync(string filter);
        Task<List<Session>> GetSessionsAsync(int movieId);
        Task<Movie?> GetMovieByIdAsync(int id);
        Task<Session?> GetSessionByIdAsync(int id);
        Task CreateMovieAsync(Movie movie);
        Task CreateSessionAsync(Session session);
        Task UpdateMovieAsync(int id, Movie movie);
        Task UpdateSessionAsync(int id, Session session);
        Task DeleteMovieAsync(int id);
        Task DeleteSessionAsync(int id);
    }
}