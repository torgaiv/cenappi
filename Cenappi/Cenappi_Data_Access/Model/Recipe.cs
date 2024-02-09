using Cenappi.Cenappi_Data_Access.Model.Base;

namespace Cenappi.Cenappi_Data_Access.Model;

public class Recipe : IBaseCenappi
{
    public Recipe()
    {
        Ingredients = new List<Ingredient>();
        Tags = null;
    }

    public ICollection<Ingredient> Ingredients { get; set; }
    public ICollection<Category>? Tags { get; set; }
    public string? Name { get; set; }
    public int? Id { get; set; }
    public Guid Guid { get; set; }
}