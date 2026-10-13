namespace Pract02_GutierrezNina.Application.Dtos;

public class ClientOrderCountDto
{
    public int ClientId { get; set; }
    public string ClientName { get; set; } = string.Empty;
    public int OrderCount { get; set; }
}
