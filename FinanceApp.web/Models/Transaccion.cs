namespace FinanceApp.web.Models;

public class Transaccion
{
    public int Id { get; set; }
    public DateTime Fecha { get; set; }
    public int CuentaId { get; set; }
    public int CategoryId { get; set; }
    public decimal Monto { get; set; }
    public string Nota { get; set; }
}