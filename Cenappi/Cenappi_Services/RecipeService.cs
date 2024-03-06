using Cenappi.Cenappi_Data_Access.Model;
using Cenappi.Cenappi_Data_Access.Model.Context;
using Microsoft.EntityFrameworkCore;

namespace Cenappi.Cenappi_Services
{
    public class RecipeService
    {
        private readonly CenappiContext _ctx = new();

        public async Task DeleteRecipeAsync(int id)
        {
            var RecipeToDelete = await _ctx.Recipe.FindAsync(id);
            if (RecipeToDelete != null)
            {
                _ctx.Recipe.Remove(RecipeToDelete);
                await _ctx.SaveChangesAsync();
            }
        }

        public async Task<List<Recipe>> GetAllRecipesAsync()
        {
            return await _ctx.Recipe.OrderBy(x => x.Name).ToListAsync();
        }
        

        public async Task<Recipe?> GetRecipeByIdAsync(int id)
        {
            return await _ctx.Recipe
                .Include(r => r.Rations)
                .ThenInclude(i => i.Ingredient)
                .FirstOrDefaultAsync(r => r.Id == id);
        }

        public Recipe? GetRecipeById(int id)
        { 
                return  _ctx.Recipe
                    .Include(r => r.Rations)
                    .ThenInclude(r => r.Ingredient)
                    .FirstOrDefault(r => r.Id == id);
            }
          
        public async Task AddRecipeAsync(Recipe? Recipe)
        {
            foreach (Rations ration in Recipe.Rations)
            {
                ration.Guid = Guid.NewGuid();
                ration.Ingredient = _ctx.Ingredient.Find(ration.Ingredient.Id);
                ration.Name = string.Empty;
                ration.IngredientId = ration.Ingredient.Id.GetValueOrDefault();
            }

            _ctx.Recipe.Add(Recipe);
            await _ctx.SaveChangesAsync();
        }

        public async Task UpdateRecipeAsync(Recipe? Recipe)
        {
            _ctx.Entry(Recipe).State = EntityState.Modified;
            await _ctx.SaveChangesAsync();
        }

        public async Task<int> CreateRecipeAsync(Recipe? Recipe)
        {
            _ctx.Recipe.Add(Recipe);
            await _ctx.SaveChangesAsync();
            return Recipe.Id ?? 0;
        }
    }
}