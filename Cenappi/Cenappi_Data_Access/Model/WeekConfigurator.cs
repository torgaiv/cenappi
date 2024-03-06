using Cenappi.Cenappi_Data_Access.Model.Base;

namespace Cenappi.Cenappi_Data_Access.Model;

public class WeekConfigurator :IBaseCenappi
{
    public ICollection<DayConfigurator>? Days { get; set; } = new List<DayConfigurator>();
    public string? Name { get; set; }
    public int? Id { get; set; }
    public Guid Guid { get; set; }
}