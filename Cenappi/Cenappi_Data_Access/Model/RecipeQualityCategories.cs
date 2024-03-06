using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Cenappi.Cenappi_Data_Access.Model;

public static class RecipeTypeStatic
{
    public static  Dictionary<int, string> RecipeType =  new Dictionary<int, string>
    {
        { 1, "Pescado y Marisco" },
        { 2, "Carne" },
        { 3, "Cuchara" },
        { 4, "Ensalada" },
        { 5, "Huevo" },
        { 6, "Desayunos, Picoteos y Meriendas" },
        { 7, "Libre Saludable" },
        { 8, "Libre" },
    };
}