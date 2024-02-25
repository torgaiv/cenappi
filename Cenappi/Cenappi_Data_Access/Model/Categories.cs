using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Cenappi.Cenappi_Data_Access.Model;

public static class CategoriesStatic
{
    public static  Dictionary<int, string> Categories =  new Dictionary<int, string>
    {
        { 1, "Todo" },
        { 2, "Almuerzo" },
        { 3, "Comida" },
        { 4, "Merienda" },
        { 5, "Cena" }
    };
}