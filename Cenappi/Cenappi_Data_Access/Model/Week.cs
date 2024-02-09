using Cenappi.Cenappi_Data_Access.Model.Base;

namespace Cenappi.Cenappi_Data_Access.Model;

public class Week :IBaseCenappi
{
    public Week()
    {
        Days = new List<Day>();
    }

    public ICollection<Day>? Days { get; set; }
    public string? Name { get; set; }
    public int? Id { get; set; }
    public Guid Guid { get; set; }
}