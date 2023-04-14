using FinanceApp.web.Helpers;
using FinanceApp.web.Models;

namespace FinanceApp.web.Validators;

public class CategoriaValidator
{
    public static readonly string[] VALID_CATEGORY_TYPES = new string[] {CONSTANTES.INGRESO, CONSTANTES.EGRESO};

    public bool hasUniqueName(DbEntities entities, Categoria categoria)
    {
        return entities.Categorias.Any(o => o.Nombre == categoria.Nombre);
    }

    public bool hasValidType(Categoria categoria)
    {
        return VALID_CATEGORY_TYPES.Contains(categoria.Tipo);
    }
}