using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Cenappi.Cenappi_Data_Access.Model;
using Cenappi.Cenappi_Data_Access.Model.Context;
using Cenappi.Cenappi_Services;
using NUnit.Framework;
using NUnit.Framework.Internal;
using NUnit.Framework.Legacy;

namespace Cenappi.Tests.Cenappi_Data_Access.Model;

[TestFixture]
[TestOf(typeof(Ingredient))]
public class IngredientTest
{
    public static object[] IngridientsCases =
    {
        new object[] { "Patata", "Patata Lavada" },
        new object[] { "Lechuga", "Pieza" },
        new object[] { "Tomate", "Pieza" }
    };

    [Test]
    [TestCaseSource(nameof(IngridientsCases))] 
    public void Create_Test(string name, string description)
    {
        var testGuid = Guid.NewGuid();
        var ingredient = new Ingredient() { Name = name, Description = description, Guid = testGuid };

        using (CenappiContext ctx = new CenappiContext())
        {
            ingredient = ctx.Ingredient.Add(ingredient).Entity;
            ctx.SaveChanges();
            ClassicAssert.NotNull(ingredient.Id);
            ClassicAssert.AreEqual(ingredient.Guid, testGuid);
        }
    }
    
    [Test]
    [TestCaseSource(nameof(IngridientsCases))] 
    public void Create_Service_Test(string name, string description)
    {
        var testGuid = Guid.NewGuid();
        var ingredient = new Ingredient() { Name = name, Description = description, Guid = testGuid };
        IngredientService service = new IngredientService();

        var newIngredient =   service.AddIngredientAsync(ingredient);
        
        ClassicAssert.NotNull(newIngredient.Id);
        ClassicAssert.AreEqual(testGuid, newIngredient);
    }
     
    
}