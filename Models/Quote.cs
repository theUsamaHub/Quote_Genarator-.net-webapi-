using System.ComponentModel.DataAnnotations;

namespace Quote_genarator.Models
{
    public class Quote
    {
        public int Id { get; set; }

        [Required]
        public string Text { get; set; }

        [Required]
        public string Author { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}