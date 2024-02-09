namespace Cenappi.Cenappi_Data_Access.Model.Base;

public interface  IBaseCenappi
{
    public string? Name { get; set; }
    public int? Id { get; set; }    
    public Guid Guid { get; set; }
}