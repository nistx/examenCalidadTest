using FinanceApp.web.Models;
using Microsoft.EntityFrameworkCore;

namespace FinanceApp.web;

public class DbEntities: DbContext
{
    public virtual DbSet<Categoria> Categorias { get; set; }
    public virtual DbSet<Cuenta> Cuentas { get; set; }
    public virtual DbSet<Transaccion> Transacciones { get; set; }
    
    public DbEntities(DbContextOptions<DbEntities> options): base(options) {}

}