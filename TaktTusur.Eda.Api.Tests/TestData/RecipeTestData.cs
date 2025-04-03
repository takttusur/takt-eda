using TaktTusur.Eda.Domain.Recipe;
using TaktTusur.Eda.Infrastructure.Contexts;

namespace TaktTusur.Eda.Api.Tests.TestData
{
	public static class RecipesTestData
	{
		public static Action<EdaDbContext> SeedRecipesData(this Action<EdaDbContext>? seedData)
		{
			return (dbContext) =>
			{
				seedData?.Invoke(dbContext);

				dbContext.Recipes.AddRange(TestData.Value);
				dbContext.SaveChanges();
			};
		}

		public static Lazy<Recipe[]> TestData { get; } = new Lazy<Recipe[]>(RecipesFactory);

		private static Recipe[] RecipesFactory()
		{
			var list = new List<Recipe>();

			// Tomato Soup recipe
			var onion = IngredientsTestData.TestData.First(x => x.Name == "лук");
			var tomato = IngredientsTestData.TestData.First(x => x.Name == "томат");
			var gr = MeasurementUnitsTestData.TestData.First(x => x.Name == "грамм");
			var tomatoSoup = Recipe.Create(
				"Tomato soup",
				5 * 60,
				10 * 60,
				"Boil water, add chicken to make a chicken bouillon, next add mixed tomatos.");
			tomatoSoup.AddIngredient(onion, gr, 100);
			tomatoSoup.AddIngredient(tomato, gr, 200);
			list.Add(tomatoSoup);

			// Additional Recipes

			// Soup Recipe
			var potato = IngredientsTestData.TestData.First(x => x.Name == "картофель");
			var carrot = IngredientsTestData.TestData.First(x => x.Name == "морковь");
			var potatoSoup = Recipe.Create(
				"Potato soup",
				5 * 60,
				10 * 60,
				"Boil water, add onions, carrots and potatoes. Add seasoning to taste.");
			potatoSoup.AddIngredient(onion, gr, 100);
			potatoSoup.AddIngredient(carrot, gr, 100);
			potatoSoup.AddIngredient(potato, gr, 300);
			list.Add(potatoSoup);

			// Apple Salad Recipe
			var apple = IngredientsTestData.TestData.First(x => x.Name == "яблоко");
			var appleSalad = Recipe.Create(
				"Apple Salad",
				10 * 60,
				5 * 60,
				"Peel and dice the apple. Mix with diced onions.");
			appleSalad.AddIngredient(onion, gr, 50);
			appleSalad.AddIngredient(apple, gr, 100);
			list.Add(appleSalad);

			// Veggie Salad Recipe
			var cucumber = IngredientsTestData.TestData.First(x => x.Name == "огурец");
			var broccoli = IngredientsTestData.TestData.First(x => x.Name == "брокколи");
			var veggieSalad = Recipe.Create(
				"Veggie Salad",
				10 * 60,
				10 * 60,
				"Chop and mix cucumber, tomato, onion, and broccoli. Add olive oil and vinegar.");
			veggieSalad.AddIngredient(onion, gr, 50);
			veggieSalad.AddIngredient(tomato, gr, 50);
			veggieSalad.AddIngredient(cucumber, gr, 50);
			veggieSalad.AddIngredient(broccoli, gr, 50);
			list.Add(veggieSalad);

			// Fruit Salad Recipe
			var orange = IngredientsTestData.TestData.First(x => x.Name == "апельсин");
			var fruitSalad = Recipe.Create(
				"Fruit Salad",
				10 * 60,
				0,
				"Peel and dice the orange and apple. Mix together.");
			fruitSalad.AddIngredient(orange, gr, 100);
			fruitSalad.AddIngredient(apple, gr, 100);
			list.Add(fruitSalad);


			return list.ToArray();
		}
	}
}