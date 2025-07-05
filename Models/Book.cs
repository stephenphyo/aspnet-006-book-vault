using System.ComponentModel.DataAnnotations;

namespace ASPNET_006_Book_Vault.Models
{
    public class Book : Metadata
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        [Required]
        public string Author { get; set; }
        public string Genre { get; set; }
        public float Rating { get; set; }
        public string CoverUrl { get; set; }
    }
}