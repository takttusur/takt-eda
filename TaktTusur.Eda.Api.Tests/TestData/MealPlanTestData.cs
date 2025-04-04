using TaktTusur.Eda.Domain.MealPlan;
using TaktTusur.Eda.Domain.Recipe;
using TaktTusur.Eda.Infrastructure.Contexts;

namespace TaktTusur.Eda.Api.Tests.TestData;

public static class MealPlanTestData
{
	public static Action<EdaDbContext> SeedMealPlansData(this Action<EdaDbContext>? seedData)
	{
		return (EdaDbContext dbContext) =>
		{
			seedData?.Invoke(dbContext);
			dbContext.MealPlans.AddRange(TestData.Value);
			dbContext.SaveChanges();
		};
	}

	public static Lazy<MealPlan[]> TestData { get; } = new Lazy<MealPlan[]>(MealPlanFactory);

	private static MealPlan[] MealPlanFactory()
	{
		var tomatoSoup = RecipesTestData.TestData.Value.First(x => x.Name == "Tomato soup");
		var potatoSoup = RecipesTestData.TestData.Value.First(x => x.Name == "Potato soup");
		var appleSalad = RecipesTestData.TestData.Value.First(x => x.Name == "Apple Salad");
		var veggieSalad = RecipesTestData.TestData.Value.First(x => x.Name == "Veggie Salad");
		var fruitSalad = RecipesTestData.TestData.Value.First(x => x.Name == "Fruit Salad");

		var list = new List<MealPlan>();

		var plan1 = MealPlan.Create();
		// Day 1
		var day1 = DateTimeOffset.Now;
		plan1.AddRecord(EatingTime.Breakfast, 2, day1, tomatoSoup);
		plan1.AddRecord(EatingTime.Breakfast, 2, day1, veggieSalad);
		plan1.AddRecord(EatingTime.Lunch, 2, day1, potatoSoup);
		plan1.AddRecord(EatingTime.Lunch, 2, day1, appleSalad);
		plan1.AddRecord(EatingTime.Dinner, 3, day1, fruitSalad);
		// Day 2
		var day2 = DateTimeOffset.Now.AddDays(1);
		plan1.AddRecord(EatingTime.Breakfast, 3, day2, veggieSalad);
		plan1.AddRecord(EatingTime.Dinner, 3, day2, fruitSalad);
		// Day 3
		var day3 = DateTimeOffset.Now.AddDays(2);
		plan1.AddRecord(EatingTime.Breakfast, 3, day3, tomatoSoup);
		plan1.AddRecord(EatingTime.Dinner, 3, day3, potatoSoup);
		plan1.AddRecord(EatingTime.Breakfast, 3, day3, tomatoSoup);
		list.Add(plan1);

		var plan2 = MealPlan.Create();
		plan2.AddRecord(EatingTime.Breakfast, 2, DateTimeOffset.Now, tomatoSoup);
		list.Add(plan2);

		var plan3 = MealPlan.Create();
		plan3.AddRecord(EatingTime.Breakfast, 2, DateTimeOffset.Now, tomatoSoup);
		list.Add(plan3);

		var plan4 = MealPlan.Create();
		plan4.AddRecord(EatingTime.Breakfast, 2, DateTimeOffset.Now, tomatoSoup);
		list.Add(plan4);

		var plan5 = MealPlan.Create();
		plan5.AddRecord(EatingTime.Breakfast, 2, DateTimeOffset.Now, tomatoSoup);
		list.Add(plan5);

		var plan6 = MealPlan.Create();
		plan6.AddRecord(EatingTime.Breakfast, 2, DateTimeOffset.Now, tomatoSoup);
		list.Add(plan6);

		return list.ToArray();
	}
}