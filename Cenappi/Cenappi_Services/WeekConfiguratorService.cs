using Cenappi.Cenappi_Data_Access.Model;
using Cenappi.Cenappi_Data_Access.Model.Context;
using Microsoft.EntityFrameworkCore;

namespace Cenappi.Cenappi_Services
{
    public class WeekConfiguratorService
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

        public async Task<WeekConfigurator?> GetWeekConfigurator()
        {
            var weekConfig= await _ctx.WeekConfigurator
                .Include(r => r.Days)
                .FirstOrDefaultAsync() ;
            
            if (weekConfig is null)
            {
                return  await Initialize();
            }

            return weekConfig;
        }

        public WeekConfigurator? GetWeekConfiguratorSync()
        {
            return _ctx.WeekConfigurator.FirstOrDefault();
        }

        public async Task<DayConfigurator> UpdateDay(DayConfigurator day)
        {
            var updateday = _ctx.DayConfigurator.Find(day.Id);
            if (updateday != null)
            {
                updateday.RecipeTypeId = day.RecipeTypeId;
                await _ctx.SaveChangesAsync();
            }

            return updateday;
        }

        public async Task<WeekConfigurator> Initialize()
        {
            WeekConfigurator newWeekconfig = new WeekConfigurator();
            newWeekconfig.Guid = Guid.NewGuid();
            newWeekconfig.Name = "CoreWeekConfiguration";

            
            _ctx.WeekConfigurator.Add(newWeekconfig);
            await _ctx.SaveChangesAsync();

            if (newWeekconfig.Id is null)
            {
                throw new Exception("Cannot create CoreWeekConfiguration ");
            }
            DateTime dayOfWeek = new DateTime();
            
            int period = 1;
            for (int i = 1; i <= 35; i++)
            {
                DayConfigurator dayConfigurator = new DayConfigurator();
                dayConfigurator.Guid = Guid.NewGuid();
                dayConfigurator.Days = dayOfWeek;
                dayConfigurator.RecipeTypeId = 1;
                dayConfigurator.Name = dayOfWeek.DayOfWeek +"_"+period;
                dayConfigurator.WeekConfigurator = newWeekconfig;
                dayConfigurator.WeekConfiguratorId = newWeekconfig.Id.Value;
                period++;
                
                if (i % 5 == 0)
                {
                    dayOfWeek =  dayOfWeek.AddDays(1);
                    period = 1;
                }

                _ctx.DayConfigurator.Add(dayConfigurator);
            }
            
            await _ctx.SaveChangesAsync();

            return newWeekconfig;
        }
        
    }
}