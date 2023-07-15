using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieApp.Models {
    [Table("Movies")]
    public class Movie {
        [Key] public int Id { get; set; }

        public string Name { get; set; }

        public string Director { get; set; }

        public string Style { get; set; }

        public string Description { get; set; }
        
        public ICollection<Session> Sessions { get; set; } = new List<Session>();
    }
}