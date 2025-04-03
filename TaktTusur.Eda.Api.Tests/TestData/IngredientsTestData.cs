using TaktTusur.Eda.Domain.Recipe;
using TaktTusur.Eda.Infrastructure.Contexts;

namespace TaktTusur.Eda.Api.Tests.TestData
{
	public static class IngredientsTestData
	{
		public static Action<EdaDbContext> SeedIngredientsData(this Action<EdaDbContext>? seedData)
		{
			return (EdaDbContext dbContext) =>
			{
				seedData?.Invoke(dbContext);
				dbContext.Ingredients.AddRange(TestData);
				dbContext.SaveChanges();
			};
		}

		public static IEnumerable<Ingredient> TestData { get; } = new[]
		{
			Ingredient.Create("картофель"),
			Ingredient.Create("лук"),
			Ingredient.Create("томат"),
			Ingredient.Create("огурец"),
			Ingredient.Create("брокколи"),
			Ingredient.Create("морковь"),
			Ingredient.Create("перец"),
			Ingredient.Create("апельсин"),
			Ingredient.Create("яблоко"),
			Ingredient.Create("капуста"),
			Ingredient.Create("арбуз"),
			Ingredient.Create("батат"),
			Ingredient.Create("шпинат"),
			Ingredient.Create("баклажан"),
			Ingredient.Create("цуккини")
		};
	}
}