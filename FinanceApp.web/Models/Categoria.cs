namespace FinanceApp.web.Models;

public class Categoria
{
    public int Id { get; set; }
    // Solo puede ser ["INGRESO", "EGRESO"]
    public string Tipo { get; set; }
    public string Nombre { get; set; }
    
}