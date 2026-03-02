using Microsoft.EntityFrameworkCore;
using Jeremy_Sanchez_AP1_P2.Models;

namespace Jeremy_Sanchez_AP1_P2.DAL;

public class Contexto : DbContext
{
    public Contexto(DbContextOptions<Contexto> options) : base(options) { }

    public DbSet<ViajesEspaciales> ViajesEspaciales { get; set; }
}
