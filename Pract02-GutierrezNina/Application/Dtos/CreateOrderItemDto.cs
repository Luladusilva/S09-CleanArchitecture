using System.ComponentModel.DataAnnotations;

namespace Pract02_GutierrezNina.Application.Dtos;

public class CreateOrderItemDto
{
    [Range(1, int.MaxValue)]
    public int ProductId { get; set; }

    [Range(1, int.MaxValue)]
    public int Quantity { get; set; }
}
