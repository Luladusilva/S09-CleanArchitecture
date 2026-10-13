using System.ComponentModel.DataAnnotations;

namespace Pract02_GutierrezNina.Dtos;

public class UpdateOrderDto
{
    [Range(1, int.MaxValue)]
    public int ClientId { get; set; }

    public DateTime OrderDate { get; set; }
}
