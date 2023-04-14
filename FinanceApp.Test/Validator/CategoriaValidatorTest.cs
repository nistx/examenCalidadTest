using FinanceApp.web;
using FinanceApp.web.Validators;
using FinanceApp.web.Models;
using Microsoft.EntityFrameworkCore;

namespace FinanceApp.Test.Validator;
using Moq;
using Moq.EntityFrameworkCore;

public class CategoriaValidatorTest
{
    [Test]
    public void hasUniqueNameCaso01()
    {
        var validator = new CategoriaValidator();

        var categorias = new List<Categoria>
        {
            new Categoria { Nombre = "Categoria1" },
            new Categoria { Nombre = "Categoria2" }
        };
        var rcMock = new Mock<DbEntities>(new DbContextOptions<DbEntities>());
        rcMock.Setup(o => o.Categorias).ReturnsDbSet(categorias);
        
        var resultado = validator.hasUniqueName(rcMock.Object,new Categoria {Nombre = "Categoria3"});
        Assert.IsFalse(resultado);
    }
    
    [Test]
    public void hasUniqueNameCaso02()
    {
        var validator = new CategoriaValidator();

        var categorias = new List<Categoria>
        {
            new Categoria { Nombre = "Categoria1" },
            new Categoria { Nombre = "Categoria2" }
        };
        var rcMock = new Mock<DbEntities>(new DbContextOptions<DbEntities>());
        rcMock.Setup(o => o.Categorias).ReturnsDbSet(categorias);
        
        var resultado = validator.hasUniqueName(rcMock.Object,new Categoria {Nombre = "Categoria1"});
        Assert.IsTrue(resultado);
    }
    
    [Test]
    public void hasUniqueNameCaso03()
    {
        var validator = new CategoriaValidator();

        var categorias = new List<Categoria>
        {
            new Categoria { Nombre = "Categoria1" },
            new Categoria { Nombre = "Categoria2" }
        };
        var rcMock = new Mock<DbEntities>(new DbContextOptions<DbEntities>());
        rcMock.Setup(o => o.Categorias).ReturnsDbSet(categorias);
        
        var resultado = validator.hasUniqueName(rcMock.Object,new Categoria {Nombre = "Categoria2"});
        Assert.IsTrue(resultado);
    }

    [Test]
    public void hasValidTypeCaso01()
    {
        var validator = new CategoriaValidator();
        var resultado = validator.hasValidType(new Categoria { Tipo = "INGRESO"});
        Assert.IsTrue(resultado);
    }
    
    [Test]
    public void hasValidTypeCaso02()
    {
        var validator = new CategoriaValidator();
        var resultado = validator.hasValidType(new Categoria { Tipo = "EGRESO"});
        Assert.IsTrue(resultado);
    }
    
    [Test]
    public void hasValidTypeCaso03()
    {
        var validator = new CategoriaValidator();
        var resultado = validator.hasValidType(new Categoria { Tipo = "NUEVO"});
        Assert.IsFalse(resultado);
    }
}