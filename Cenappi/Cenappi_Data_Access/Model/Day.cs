using Cenappi.Cenappi_Data_Access.Model.Base;

namespace Cenappi.Cenappi_Data_Access.Model;

public class Day : IBaseCenappi
{
    public Day()
    {
        Date = Date.Date;
        Meals = null;
    }

    public DateTime Date { get; set; }
    public ICollection<Recipe>? Meals { get; set; }
    public string? Name { get; set; }
    public int? Id { get; set; }
    public Guid Guid { get; set; }
 
}