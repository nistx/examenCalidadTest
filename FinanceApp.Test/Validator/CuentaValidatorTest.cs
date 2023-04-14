namespace FinanceApp.Test.Validator;

using FinanceApp.web;
using FinanceApp.web.Validators;
using FinanceApp.web.Models;
using Microsoft.EntityFrameworkCore;
using Moq;
using Moq.EntityFrameworkCore;

public class CuentaValidatorTest
{
    [Test]
    public void hasUniqueNameCaso01()
    {
        var validator = new CuentaValidator();

        var cuentas = new List<Cuenta>
        {
            new Cuenta { Nombre = "Usuario1" },
            new Cuenta { Nombre = "Usuario2" }
        };
        var rcMock = new Mock<DbEntities>(new DbContextOptions<DbEntities>());
        rcMock.Setup(o => o.Cuentas).ReturnsDbSet(cuentas);
        
        var resultado = validator.hasUniqueName(rcMock.Object,new Cuenta() {Nombre = "Usuario3"});
        Assert.IsFalse(resultado);
    }
    [Test]
    public void hasUniqueNameCaso02()
    {
        var validator = new CuentaValidator();

        var cuentas = new List<Cuenta>
        {
            new Cuenta { Nombre = "Usuario1" },
            new Cuenta { Nombre = "Usuario2" }
        };
        var rcMock = new Mock<DbEntities>(new DbContextOptions<DbEntities>());
        rcMock.Setup(o => o.Cuentas).ReturnsDbSet(cuentas);
        
        var resultado = validator.hasUniqueName(rcMock.Object,new Cuenta() {Nombre = "Usuario1"});
        Assert.IsTrue(resultado);
    }
    [Test]
    public void hasUniqueNameCaso03()
    {
        var validator = new CuentaValidator();

        var cuentas = new List<Cuenta>
        {
            new Cuenta { Nombre = "Usuario0" },
            new Cuenta { Nombre = "Usuario01" }
        };
        var rcMock = new Mock<DbEntities>(new DbContextOptions<DbEntities>());
        rcMock.Setup(o => o.Cuentas).ReturnsDbSet(cuentas);
        
        var resultado = validator.hasUniqueName(rcMock.Object,new Cuenta() {Nombre = "Usuario01"});
        Assert.IsTrue(resultado);
    }
}