using System.ComponentModel.DataAnnotations;

namespace Eproject2025.DTOs
{
    public class CategoryDTO
    {
        public string? CategoryId { get; set; }
        [Required]
        public string CategoryName { get; set; } = null!;
        [Required]
        public string Description { get; set; }
        public string? Status { get; set; }
    }
}
