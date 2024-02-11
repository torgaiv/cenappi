using System;
using System.Collections.Generic;
using Cenappi.Cenappi_Data_Access.Model;
using Cenappi.Cenappi_Data_Access.Model.Context;
using Cenappi.Cenappi_Services;
using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace Cenappi.Tests.Cenappi_Data_Access.Model;

[TestFixture]
[TestOf(typeof(Recipe))]
public class RecipeTest
{
    public static string[] Categories =
    {
        "Desayuno",
        "Comida",
        "Cena"
    };
    public static object[] IngridientsCases =
    {
        new object[] { "Ensalada", "Cortar los ingredientes  y mezclar",  new List<string>() { Categories[1] }},
        new object[] { "Desayuno", "Aleatorio",  new List<string>() { Categories[1] }},
        new object[] { "Tomate", "Cena o Comida",  new List<string>() { Categories[1],Categories[2] }},
    };

    [Test]
    [TestCaseSource(nameof(IngridientsCases))]
    public void Create_Test(string name, string description, List<string> cat)
    {
        var testGuid = Guid.NewGuid();
        var recipe = new Recipe()
        {
            Name = name,
            Guid = testGuid,
            Tags =cat,
            Description = "Description",
            Preparation = "Preparation",
            Quantity = "Quantity",
            Time = "Time"
        };

        using (CenappiContext ctx = new CenappiContext())
        {
            recipe = ctx.Recipe.Add(recipe).Entity;
            ctx.SaveChanges();
            ClassicAssert.NotNull(recipe.Id);
            ClassicAssert.AreEqual(recipe.Guid, testGuid);
        }
    }

    [Test]
    [TestCaseSource(nameof(IngridientsCases))]
    public void Create_Service_Test(string name, string description)
    { 
    }
}