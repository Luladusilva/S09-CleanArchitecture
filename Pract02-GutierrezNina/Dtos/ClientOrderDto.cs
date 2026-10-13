namespace Pract02_GutierrezNina.Dtos;

public class ClientOrderDto
{
    public string ClientName { get; set; } = string.Empty;
    public List<OrderDto> Orders { get; set; } = [];
}