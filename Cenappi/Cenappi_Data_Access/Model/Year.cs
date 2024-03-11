using Cenappi.Cenappi_Data_Access.Model.Base;

namespace Cenappi.Cenappi_Data_Access.Model;

public class Year :IBaseCenappi
{
    public Year()
    {
        Weeks = new List<Week>();
    }

    public ICollection<Week>  Weeks { get; set; }
    public string? Name { get; set; }
    public int? Id { get; set; }
    public Guid Guid { get; set; }
    public int YearNumber { get; set; }
}