namespace Pract02_GutierrezNina.Dtos;

public class OrderProductsDto
{
    public int OrderId { get; set; }
    public string ClientName { get; set; } = string.Empty;
    public DateTime OrderDate { get; set; }
    public List<OrderProductItemDto> Products { get; set; } = [];
}

public class OrderProductItemDto
{
    public string ProductName { get; set; } = string.Empty;
    public int Quantity { get; set; }
}
