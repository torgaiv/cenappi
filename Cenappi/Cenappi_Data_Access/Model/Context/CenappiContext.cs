using Microsoft.EntityFrameworkCore;

namespace Cenappi.Cenappi_Data_Access.Model.Context;

public partial class CenappiContext : DbContext
{
    //private readonly string connectionStringLocalDB= "Server=(localdb)\\\\MSSQLLocalDB;Database=cenappi;Trusted_Connection=True;";
    private readonly string connectionStringSOMEEDB= "workstation id=cenappi.mssql.somee.com;packet size=4096;user id=torgaiv_SQLLogin_1;pwd=42hx2p47wc;data source=cenappi.mssql.somee.com;persist security info=False;initial catalog=cenappi;TrustServerCertificate=True";
    public CenappiContext()
    {
    }

    public CenappiContext(DbContextOptions<CenappiContext> options)
        : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer(connectionStringSOMEEDB);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreatingPartial(modelBuilder);
    }
    
    public DbSet<Ingredient> Ingredient { get; set; }
    public DbSet<Day> Day { get; set; }
    public DbSet<Recipe> Recipe { get; set; }
    public DbSet<Week> Week { get; set; }
    public DbSet<Year> Year { get; set; }
    public DbSet<Rations> Rations { get; set; }
    public DbSet<Tags> Tags { get; set; }
    public DbSet<WeekConfigurator> WeekConfigurator { get; set; }
    public DbSet<DayConfigurator> DayConfigurator { get; set; }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
