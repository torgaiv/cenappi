using Cenappi.Cenappi_Data_Access.Model;
using Cenappi.Cenappi_Data_Access.Model.Context;
using Humanizer;
using Microsoft.EntityFrameworkCore;

namespace Cenappi.Cenappi_Services
{
    public class CoreService
    {
        private readonly CenappiContext _ctx = new();

        private DateTime LastDayOfWeek(DateTime date)
        {
            var weekstarts = FirstDayOfWeek(date);
            return weekstarts.AddDays(7).AddSeconds(-1);
        }

        private DateTime FirstDayOfWeek(DateTime date)
        {
            int adjustment = date.DayOfWeek == DayOfWeek.Sunday ? -6 : 1;
            return date.AddDays(-(int)date.DayOfWeek + adjustment);
        }

        public async Task<Week> GetWeek(DateTime dateTimeSelected)
        {
            var selectedWeek = await GetSelectedWeek(dateTimeSelected);

            if (selectedWeek != null)
            {
                return selectedWeek;
            }

            DateTime FirstDayOfNewWeek = FirstDayOfWeek(dateTimeSelected);
            DateTime LastDayOfNewWeek = LastDayOfWeek(dateTimeSelected);
            int yearNumber = dateTimeSelected.Year;

            var selectedYear = await GetSelectedYear(yearNumber);

            var weekConfig = await GetWeekConfig();

            var newWeek = CreateNewWeek(selectedYear, FirstDayOfNewWeek, LastDayOfNewWeek);

            await _ctx.Week.AddAsync(newWeek);

            var allRecipes = await _ctx.Recipe.ToListAsync();

            await CreateDaysForWeek(allRecipes, weekConfig, newWeek, FirstDayOfNewWeek);

            await _ctx.SaveChangesAsync();
            return newWeek;
        }

        private async Task<Week> GetSelectedWeek(DateTime dateTimeSelected)
        {
            return await _ctx.Week.Include(x => x.Days).ThenInclude(x => x.Recipe).FirstOrDefaultAsync(x =>
                x.StartingDay.Date <= dateTimeSelected.Date &&
                x.EndDay.Date >= dateTimeSelected.Date);
        }

        private async Task<Year> GetSelectedYear(int yearNumber)
        {
            var selectedYear = await _ctx.Year.FirstOrDefaultAsync(x => x.YearNumber == yearNumber);

            if (selectedYear == null)
            {
                selectedYear = new Year()
                {
                    YearNumber = yearNumber,
                    Name = yearNumber.ToString(),
                    Guid = Guid.NewGuid(),
                    Weeks = new List<Week>()
                };

                await _ctx.Year.AddAsync(selectedYear);
            }

            return selectedYear;
        }

        private async Task<WeekConfigurator> GetWeekConfig()
        {
            var weekConfig = await _ctx.WeekConfigurator.Include(x => x.Days).FirstOrDefaultAsync();

            if (weekConfig == null)
            {
                throw new Exception("Week needs a setup configuration");
            }

            return weekConfig;
        }

        private Week CreateNewWeek(Year selectedYear, DateTime FirstDayOfNewWeek, DateTime LastDayOfNewWeek)
        {
            return new Week
            {
                Year = selectedYear,
                Guid = Guid.NewGuid(),
                YearId = selectedYear.Id.GetValueOrDefault(),
                Days = new List<Day>(),
                StartingDay = FirstDayOfNewWeek.Date,
                EndDay = LastDayOfNewWeek.Date
            };
        }

        private async Task CreateDaysForWeek(List<Recipe> allRecipes, WeekConfigurator weekConfig, Week newWeek,
            DateTime FirstDayOfNewWeek)
        {
            int period = 1;
            for (int i = 0; i < 35; i++)
            {
                var dayconfig = weekConfig.Days.ToList()[i];
                var selectedRecipe = allRecipes
                    .Where(x => x.TypeId == dayconfig.RecipeTypeId)
                    .OrderBy(n => Guid.NewGuid())
                    .FirstOrDefault();
                if (selectedRecipe == null)
                {
                    var fail = dayconfig;
                }

                var newDay = new Day
                {
                    Guid = Guid.NewGuid(),
                    Date = FirstDayOfNewWeek,
                    RecipeTypeId = dayconfig.RecipeTypeId,
                    Recipe = selectedRecipe,
                    RecipeId = selectedRecipe.Id.Value,
                    Name = $"{FirstDayOfNewWeek.Date}_{period}",
                    Week = newWeek,
                    WeekId = newWeek.Id.GetValueOrDefault()
                };

                period++;

                if (i > 0 && i % 5 == 0)
                {
                    FirstDayOfNewWeek = FirstDayOfNewWeek.AddDays(1);
                    period = 1;
                }

                await _ctx.Day.AddAsync(newDay);
            }
        }
    }
}