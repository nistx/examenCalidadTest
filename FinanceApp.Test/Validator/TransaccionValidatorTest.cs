using FinanceApp.web;
using FinanceApp.web.Validators;
using FinanceApp.web.Models;
using Microsoft.EntityFrameworkCore;
namespace FinanceApp.Test.Validator;
using Moq;
using Moq.EntityFrameworkCore;

public class TransaccionValidatorTest
{
    [Test]
    public void hasValidCategoryCaso01()
    {
        var validator = new TransaccionValidator();

        var categorias = new List<Categoria>
        {
            new Categoria { Id = 1 },
            new Categoria { Id = 2 }
        };
        var rcMock = new Mock<DbEntities>(new DbContextOptions<DbEntities>());
        rcMock.Setup(o => o.Categorias).ReturnsDbSet(categorias);
        
        var resultado = validator.hasValidCategory(rcMock.Object,new Transaccion {CategoryId = 1});
        Assert.IsTrue(resultado);
    }
    
    [Test]
    public void hasValidCategoryCaso02()
    {
        var validator = new TransaccionValidator();

        var categorias = new List<Categoria>
        {
            new Categoria { Id = 1 },
            new Categoria { Id = 2 }
        };
        var rcMock = new Mock<DbEntities>(new DbContextOptions<DbEntities>());
        rcMock.Setup(o => o.Categorias).ReturnsDbSet(categorias);
        
        var resultado = validator.hasValidCategory(rcMock.Object,new Transaccion {CategoryId = 4});
        Assert.IsFalse(resultado);
    }
    
    [Test]
    public void hasValidCategoryCaso03()
    {
        var validator = new TransaccionValidator();

        var categorias = new List<Categoria>
        {
            new Categoria { Id = 1 },
            new Categoria { Id = 2 },
            new Categoria { Id = 5 }
        };
        var rcMock = new Mock<DbEntities>(new DbContextOptions<DbEntities>());
        rcMock.Setup(o => o.Categorias).ReturnsDbSet(categorias);
        
        var resultado = validator.hasValidCategory(rcMock.Object,new Transaccion {CategoryId = 5});
        Assert.IsTrue(resultado);
    }

    [Test]
    public void isValidAmountBasedCategoryCaso01()
    {
        var validator = new TransaccionValidator();

        var categorias = new List<Categoria>
        {
            new Categoria { Id = 1 , Tipo = "INGRESO"},
            new Categoria { Id = 2 , Tipo = "EGRESO"}
        };
        var rcMock = new Mock<DbEntities>(new DbContextOptions<DbEntities>());
        rcMock.Setup(o => o.Categorias).ReturnsDbSet(categorias);

        var transaccion = new Transaccion
        {
            CategoryId = 1,
            Monto = 1000.0m
        };

        var resultado = validator.isValidAmountBasedCategory(rcMock.Object, transaccion);
        Assert.IsTrue(resultado);
    }
    
    [Test]
    public void isValidAmountBasedCategoryCaso02()
    {
        var validator = new TransaccionValidator();

        var categorias = new List<Categoria>
        {
            new Categoria { Id = 1 , Tipo = "INGRESO"},
            new Categoria { Id = 2 , Tipo = "EGRESO"}
        };
        var rcMock = new Mock<DbEntities>(new DbContextOptions<DbEntities>());
        rcMock.Setup(o => o.Categorias).ReturnsDbSet(categorias);

        var transaccion = new Transaccion
        {
            CategoryId = 2,
            Monto = -500m
        };

        var resultado = validator.isValidAmountBasedCategory(rcMock.Object, transaccion);
        Assert.IsTrue(resultado);
    }

    [Test]
    public void isValidAmountBasedCategoryCaso03()
    {
        var validator = new TransaccionValidator();

        var categorias = new List<Categoria>
        {
            new Categoria { Id = 1 , Tipo = "INGRESO"},
            new Categoria { Id = 2 , Tipo = "EGRESO"}
        };
        var rcMock = new Mock<DbEntities>(new DbContextOptions<DbEntities>());
        rcMock.Setup(o => o.Categorias).ReturnsDbSet(categorias);

        var transaccion = new Transaccion
        {
            CategoryId = 1,
            Monto = -600m
        };

        var resultado = validator.isValidAmountBasedCategory(rcMock.Object, transaccion);
        Assert.IsFalse(resultado);
    }
}