using Cenappi.Cenappi_Data_Access.Model.Base;

namespace Cenappi.Cenappi_Data_Access.Model;

public class DayConfigurator
{
    public DayConfigurator()
    {
    }

    public DateTime Days { get; set; }
    public int  RecipeTypeId { get; set; }
    public  WeekConfigurator  WeekConfigurator { get; set; }
    public  int  WeekConfiguratorId { get; set; }
    public string? Name { get; set; }
    public int? Id { get; set; }
    public Guid Guid { get; set; }
}