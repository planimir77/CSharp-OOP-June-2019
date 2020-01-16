using System.ComponentModel.DataAnnotations;

namespace CompetitorEntries.Models
{
    public class Competitor
    {
        // TODO: Implement me
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        [Required]
        public int Age { get; set; }     // Not null or empty

        [Required]
        public string Team { get; set; }

        [Required]
        public string Category  { get; set; }

    }
}
