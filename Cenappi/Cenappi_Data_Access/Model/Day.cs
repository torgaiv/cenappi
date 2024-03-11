using Cenappi.Cenappi_Data_Access.Model.Base;

namespace Cenappi.Cenappi_Data_Access.Model;

public class Day : IBaseCenappi
{
    public Day()
    {
        
    }

    public DateTime Date { get; set; }
    public int  RecipeTypeId { get; set; }
    public int  RecipeId { get; set; }
    public Recipe Recipe { get; set; }
    public  Week  Week { get; set; }
    public  int  WeekId { get; set; }
    public string? Name { get; set; }
    public int? Id { get; set; }
    public Guid Guid { get; set; }
 
}