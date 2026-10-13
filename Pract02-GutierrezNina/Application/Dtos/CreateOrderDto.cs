using System.ComponentModel.DataAnnotations;

namespace Pract02_GutierrezNina.Application.Dtos;

public class CreateOrderDto
{
    [Range(1, int.MaxValue)]
    public int ClientId { get; set; }

    public DateTime? OrderDate { get; set; }

    [Required]
    [MinLength(1)]
    public List<CreateOrderItemDto> Products { get; set; } = [];
}
