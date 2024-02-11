using Cenappi.Cenappi_Data_Access.Model;
using Cenappi.Cenappi_Data_Access.Model.Context;
using Microsoft.EntityFrameworkCore;

namespace Cenappi.Cenappi_Services
{
    public class IngredientService
    {
        private readonly CenappiContext _ctx = new();

        public async Task DeleteIngredientAsync(int id)
        {
            var ingredientToDelete = await _ctx.Ingredient.FindAsync(id);
            if (ingredientToDelete != null)
            {
                _ctx.Ingredient.Remove(ingredientToDelete);
                await _ctx.SaveChangesAsync();
            }
        }

        public async Task<List<Ingredient?>> GetAllIngredientsAsync()
        {
            return await _ctx.Ingredient.ToListAsync();
        }
        public  List<Ingredient?> GetAllIngredientsSync()
        {
            return  _ctx.Ingredient.ToList();
        }

        public async Task<Ingredient?> GetIngredientByIdAsync(int id)
        {
            return await _ctx.Ingredient.FindAsync(id);
        }

        public async Task AddIngredientAsync(Ingredient? ingredient)
        {
            _ctx.Ingredient.Add(ingredient);
            await _ctx.SaveChangesAsync();
        }

        public async Task UpdateIngredientAsync(Ingredient ingredient)
        {
            _ctx.Entry(ingredient).State = EntityState.Modified;
            await _ctx.SaveChangesAsync();
        }
 
        public async Task<int> CreateIngredientAsync(Ingredient ingredient)
        {
            _ctx.Ingredient.Add(ingredient);
            await _ctx.SaveChangesAsync();
            return ingredient.Id ?? 0;
        }
    }
}