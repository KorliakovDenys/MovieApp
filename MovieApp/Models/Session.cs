using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieApp.Models {
    [Table("Sessions")]
    public class Session {
        [Key] public int Id { get; set; }
        
        public string? Room { get; set; }
        
        public DateTime DateTime { get; set; } = DateTime.Today;
        
        public int AvailableTickets { get; set; }

        [ForeignKey("MovieId")] public int MovieId { get; set; }
        
        public Movie? Movie { get; set; }
    }
}