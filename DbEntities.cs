using FinanceApp.web.Models;
using Microsoft.EntityFrameworkCore;

namespace FinanceApp.web;

public class DbEntities: DbContext
{
    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<Cuenta> Cuentas { get; set; }
    public DbSet<Transaccion> Transacciones { get; set; }
    
    public DbEntities(DbContextOptions<DbEntities> options): base(options) {}

}