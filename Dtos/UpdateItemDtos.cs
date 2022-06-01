using System.ComponentModel.DataAnnotations;

namespace Catalog.Dtos {
    public record UpdateItemDto {
        [Required]
        public string Name { get; init; }
        [Required]
        public int Price { get; init; }
    }
}