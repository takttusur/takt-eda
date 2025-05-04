using System.Xml.Linq;
using Microsoft.Extensions.Logging;

namespace TaktTusur.Eda.RecipesLoader.Services;

public class App : IApp
{
	private readonly IRecipesXmlLoader _xmlLoader;
	private readonly IRecipesXmlProcessor _processor;
	private readonly ILogger<IApp> _logger;

	public App(IRecipesXmlLoader xmlLoader, IRecipesXmlProcessor processor, ILogger<IApp> logger)
	{
		_xmlLoader = xmlLoader;
		_processor = processor;
		_logger = logger;
	}

	/* Implement this function */
	public void Run(string directoryPath, string recipeXsdPath)
	{
		try
		{
			_xmlLoader.IndexFolder(directoryPath, recipeXsdPath);
			var recipeDocument = _xmlLoader.GetNextRecipe();
			while (recipeDocument != null)
			{
				_processor.Process(recipeDocument);
				recipeDocument = _xmlLoader.GetNextRecipe();
			}
		}
		catch (Exception ex)
		{
			_logger.LogError(ex, "An error occurred while running the application");
		}
	}
}
