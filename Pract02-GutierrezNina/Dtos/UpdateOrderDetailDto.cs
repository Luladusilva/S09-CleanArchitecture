using System.ComponentModel.DataAnnotations;

namespace Pract02_GutierrezNina.Dtos;

public class UpdateOrderDetailDto
{
    [Range(1, int.MaxValue)]
    public int OrderId { get; set; }

    [Range(1, int.MaxValue)]
    public int ProductId { get; set; }

    [Range(1, int.MaxValue)]
    public int Quantity { get; set; }
}
