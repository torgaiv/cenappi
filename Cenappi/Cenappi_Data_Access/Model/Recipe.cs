using Cenappi.Cenappi_Data_Access.Model.Base;

namespace Cenappi.Cenappi_Data_Access.Model;

public class Recipe : IBaseCenappi
{
    public Recipe()
    {
    }

    public List<Rations?> Rations { get; set; } = new();
    public int CategoryKey { get; set; } 
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? Preparation { get; set; }
    public string? Quantity { get; set; }
    public string? Time { get; set; }
    public int? Id { get; set; }
    public Guid Guid { get; set; }
}