using System.ComponentModel.DataAnnotations;

namespace CQRS_Read.Models
{
    public class ProductInfo
    {
        [Key] // Primary Identity Key
        public int ProductRowId { get; set; }
        [Required]
        [StringLength(100)]
        public string? ProductId { get; set; }
        [Required]
        [StringLength(200)]
        public string? ProductName { get; set; }
        [Required]
        [StringLength(400)]
        public string? Description { get; set; }
        [Required]
        [StringLength(100)]
        public string? Manufacturer { get; set; }
        public int BasePrice { get; set;}
    }
}
