namespace Pract02_GutierrezNina.Application.Dtos;

public class ClientOrderDto
{
    public string ClientName { get; set; } = string.Empty;
    public List<OrderDto> Orders { get; set; } = [];
}