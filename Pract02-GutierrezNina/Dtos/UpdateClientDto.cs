using System.ComponentModel.DataAnnotations;

namespace Pract02_GutierrezNina.Dtos;

public class UpdateClientDto
{
    [Required]
    [StringLength(100)]
    public string Name { get; set; } = string.Empty;

    [Required]
    [EmailAddress]
    [StringLength(100)]
    public string Email { get; set; } = string.Empty;
}
