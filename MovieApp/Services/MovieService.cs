using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MovieApp.Data;
using MovieApp.Models;

namespace MovieApp.Services {
    public class MovieService : IMovieService {
        private readonly DataContext _dataContext;
        private readonly NavigationManager _navigationManager;
        private ILogger<MovieService> _logger;

        public MovieService(ILogger<MovieService> logger, IOptions<MovieServiceSettings> settings,DataContext dataContext, NavigationManager navigationManager) {
            Url = settings.Value.Url!;
            _logger = logger;
            _dataContext = dataContext;
            _navigationManager = navigationManager;
        }
        
        public List<Movie>? Movies { get; set; } = new();

        public string Url { get; }

        public async Task GetMoviesAsync() {
            var result = await _dataContext.Movies?.Include(m => m.Sessions).ToListAsync()!;
            Movies = result;
        }
        
        public async Task<Movie?> GetMovieByIdAsync(int id) {
            var sessions = _dataContext.Sessions.ToList();
            var result = await _dataContext.Movies!.FindAsync(id);
            
            return result;
        }
        
        public async Task<Session?> GetSessionByIdAsync(int id) {
            var result = await _dataContext.Sessions!.FindAsync(id);
            
            return result;
        }
        
        public async Task CreateMovieAsync(Movie movie) {
            _dataContext.Add(movie);
            await _dataContext.SaveChangesAsync();
            
            _navigationManager.NavigateTo("movies");
        }
        
        public async Task UpdateMovieAsync(int id, Movie movie) {
            var dbMovie = await _dataContext.Movies!.FindAsync(id);
            if (dbMovie is null) return;
            
            dbMovie.Name = movie.Name;
            dbMovie.Description = movie.Description;
            dbMovie.Director = movie.Director;
            dbMovie.Style = movie.Style;
            dbMovie.Description = movie.Description;
            dbMovie.Sessions = movie.Sessions.ToList();
            await _dataContext.SaveChangesAsync();
            
            _navigationManager.NavigateTo("movies");
        }
        
        public async Task DeleteMovieAsync(int id) {
            var dbMovie = await _dataContext.Movies!.FindAsync(id);
            if (dbMovie is null) return;
            _dataContext.Remove(dbMovie);
            await _dataContext.SaveChangesAsync();
            
            _navigationManager.NavigateTo("movies");
        }
    }
}