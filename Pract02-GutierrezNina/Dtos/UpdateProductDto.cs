using System.ComponentModel.DataAnnotations;

namespace Pract02_GutierrezNina.Dtos;

public class UpdateProductDto
{
    [Required]
    [StringLength(100)]
    public string Name { get; set; } = string.Empty;

    [StringLength(100)]
    public string? Description { get; set; }

    [Range(typeof(decimal), "0.01", "99999999.99")]
    public decimal Price { get; set; }
}
