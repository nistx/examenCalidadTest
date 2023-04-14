using FinanceApp.web.Helpers;
using FinanceApp.web.Models;

namespace FinanceApp.web.Validators;

public class TransaccionValidator
{
    /* la categoria debe existir en la base de datos */
    public bool hasValidCategory(DbEntities entities, Transaccion transaccion)
    {
        return entities.Categorias.Any(o => o.Id == transaccion.CategoryId);
    }
    
    /* si la categoria es INGRESO, el monto debe ser positivo, si es EGRESO debe ser negativo*/
    public bool isValidAmountBasedCategory(DbEntities entities,Transaccion transaccion)
    {
        var category = entities.Categorias.FirstOrDefault(o => o.Id == transaccion.CategoryId);
        if (category == null) return false;

        switch (category.Tipo)
        {
            case CONSTANTES.INGRESO:
                return transaccion.Monto > 0;
            case CONSTANTES.EGRESO:
                return transaccion.Monto < 0;
            default:
                return false;
        }
    }
    
    // Si es un egreso, debe validar que la cuenta tenga fondos
    public bool IsValidAmount(DbEntities entities, Transaccion transaccion)
    {
        var cuenta = entities.Cuentas.FirstOrDefault(o => o.Id == transaccion.CuentaId);
        var categoria = entities.Categorias.FirstOrDefault(o => o.Id == transaccion.CategoryId);

        if (categoria.Tipo == "EGRESO" && transaccion.Monto < 0)
            return cuenta.Monto - Math.Abs(transaccion.Monto) >= 0;
        
        return false;
    }
}