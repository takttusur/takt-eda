using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TaktTusur.Eda.Domain.Recipe;
using TaktTusur.Eda.Infrastructure.Contexts;
using TaktTusur.Eda.Infrastructure.Repositories;
using TaktTusur.Eda.RecipesLoader.Services;

namespace TaktTusur.Eda.RecipesLoader;

class Program
{
	static void Main()
	{
		var builder = new ConfigurationBuilder();
		builder.AddJsonFile("appsettings.json");
		IConfiguration configuration = builder.Build();


		var serviceCollection = new ServiceCollection();

		serviceCollection.AddDbContext<EdaDbContext>(options =>
		{
			var connectionString = configuration.GetConnectionString("EdaDbContext");
			options.UseNpgsql(connectionString);
		});
		serviceCollection.AddSingleton<IRecipesXmlLoader, RecipesXmlLoader>();
		serviceCollection.AddSingleton<IRecipesXmlProcessor, RecipesXmlProcessor>();
		serviceCollection.AddSingleton<IRecipeRepository, RecipeRepository>();
		serviceCollection.AddSingleton<IMeasurementUnitsRepository, MeasurementUnitsRepository>();
		serviceCollection.AddSingleton<IIngredientsRepository, IngredientsRepository>();
		serviceCollection.AddSingleton<IApp, App>();
		serviceCollection.AddLogging();

		var serviceProvider = serviceCollection.BuildServiceProvider();

		var app = serviceProvider.GetService<IApp>()!;
		var recipesXsd = configuration["RecipesXsd"];
		var recipesStorage = configuration["RecipesStorage"];
		app.Run(recipesStorage, recipesXsd);
	}
}