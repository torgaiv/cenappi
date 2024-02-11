using Cenappi.Cenappi_Data_Access.Model.Base;

namespace Cenappi.Cenappi_Data_Access.Model;

public class Rations : IBaseCenappi
{
    public string? Name { get; set; }
    public int? Id { get; set; }
    public Guid Guid { get; set; } 
    public decimal? Quantity { get; set; }
    public string? QuantityName { get; set; }
    public Ingredient Ingredient { get; set; }
}