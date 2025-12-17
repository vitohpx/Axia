using Axia.Domain.Enums;

namespace Axia.Domain.Entities;
public class Veiculo
{
    public Guid Id { get; set; }
    public string Descricao { get; set; } = null!;
    public Marca Marca { get; set; }
    public string Modelo { get; set; } = null!;
    public decimal? Valor { get; set; }
}