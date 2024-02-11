using Cenappi.Cenappi_Data_Access.Model.Base;

namespace Cenappi.Cenappi_Data_Access.Model;

public class Ingredient : IBaseCenappi
{
    public Ingredient()
    {
        this.Guid = Guid.NewGuid();
        this.Id = null;
    }
    
    public string? Description { get; set; }
    public ICollection<Ingredient>? Ingredients { get; set; } 
    public string? Name { get; set; }
    public int? Id { get; set; }
    public Guid Guid { get; set; }
}