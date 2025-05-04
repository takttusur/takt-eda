using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using TaktTusur.Eda.Domain.Recipe;
using TaktTusur.Eda.RecipesLoader.Exceptions;

namespace TaktTusur.Eda.RecipesLoader.Services
{
	public class RecipesXmlProcessor(
		IRecipeRepository recipeRepository,
		IIngredientsRepository ingredientsRepository,
		IMeasurementUnitsRepository measurementUnitsRepository) : IRecipesXmlProcessor
	{
		public void Process(XDocument xDocument)
		{
			var recipeNameElement = xDocument.Root?.Element("Name")?.Value;

			if (string.IsNullOrWhiteSpace(recipeNameElement))
			{
				throw new XmlLoadingException("Recipe name cannot be null or empty");
			}

			var recipe = recipeRepository.GetAll().FirstOrDefault(x => x.Name == recipeNameElement);
			if (recipe != null)
			{
				EditRecipe(xDocument, recipe);
				return;
			}

			CreateRecipe(xDocument);
		}

		private void EditRecipe(XDocument document, Recipe recipe)
		{
			var recipeName = document.Root?.Element("Name")?.Value;
			var timeToPrepare = int.Parse(document.Root?.Element("TimeToPrepare")?.Value ?? "0");
			var timeToCook = int.Parse(document.Root?.Element("TimeToCook")?.Value ?? "0");
			var cookingGuide = document.Root?.Element("CookingGuide")?.Value;

			if (string.IsNullOrWhiteSpace(recipeName) || string.IsNullOrWhiteSpace(cookingGuide))
			{
				throw new EntityReadingException(
					$"{nameof(recipe)} and {nameof(cookingGuide)} cannot be empty for {recipe.Id}");
			}

			recipe.UpdateRecipe(recipeName, timeToPrepare, timeToCook, cookingGuide);

			var ingredientsXml = document.Root?.Element("Ingredients")?.Descendants().ToArray() ?? [];
			var ingredientsNames = new string[ingredientsXml.Length];
			var measurementUnitNames = new string[ingredientsXml.Length];

			for (var index = 0; index < ingredientsXml.Length; index++)
			{
				var xIngredient = ingredientsXml[index];
				ingredientsNames[index] = xIngredient.Attribute("name")?.Value ?? string.Empty;
				measurementUnitNames[index] = xIngredient.Attribute("unit")?.Value ?? string.Empty;
			}

			var existingIngredients = ingredientsRepository.GetAll(true)
				.Where(x => ingredientsNames.Contains(x.Name))
				.ToDictionary(x => x.Name, x => x);

			var existingMeasurementUnits = measurementUnitsRepository.GetAll(true)
				.Where(x => measurementUnitNames.Contains(x.Name))
				.ToDictionary(x => x.Name, x => x);

			for (var index = 0; index < ingredientsNames.Length; index++)
			{
				var ingredient = existingIngredients.TryGetValue(ingredientsNames[index], out var value)
					? value
					: Ingredient.Create(ingredientsNames[index]);

				var unit = existingMeasurementUnits.TryGetValue(measurementUnitNames[index], out var unitValue)
					? unitValue
					: MeasurementUnit.Create(measurementUnitNames[index]);

				var amountPerPerson = double.Parse(ingredientsXml[index].Attribute("amountPerPerson")?.Value ?? "0");

				recipe.AddIngredient(ingredient, unit, amountPerPerson);
			}

			recipeRepository.Update(recipe);
		}

		private void CreateRecipe(XDocument document)
		{
			var recipeName = document.Root?.Element("Name")?.Value;
			var timeToPrepare = int.Parse(document.Root?.Element("TimeToPrepare")?.Value ?? "0");
			var timeToCook = int.Parse(document.Root?.Element("TimeToCook")?.Value ?? "0");
			var cookingGuide = document.Root?.Element("CookingGuide")?.Value ?? "";

			if (string.IsNullOrWhiteSpace(recipeName) || string.IsNullOrWhiteSpace(cookingGuide))
			{
				throw new EntityReadingException($"Entity has empty fields");
			}

			var recipe = Recipe.Create(recipeName, timeToPrepare, timeToCook, cookingGuide);

			var ingredientsXml = document.Root?.Element("Ingredients")?.Descendants().ToArray() ?? [];
			var ingredientsNames = new string[ingredientsXml.Length];
			var measurementUnitNames = new string[ingredientsXml.Length];


			for (var index = 0; index < ingredientsXml.Length; index++)
			{
				var xIngredient = ingredientsXml[index];
				ingredientsNames[index] = xIngredient.Attribute("name")?.Value ?? string.Empty;
				measurementUnitNames[index] = xIngredient.Attribute("unit")?.Value ?? string.Empty;
			}

			var existingIngredients = ingredientsRepository.GetAll(true)
				.Where(x => ingredientsNames.Contains(x.Name))
				.ToDictionary(x => x.Name, x => x);

			var existingMeasurementUnits = measurementUnitsRepository.GetAll(true)
				.Where(x => measurementUnitNames.Contains(x.Name))
				.ToDictionary(x => x.Name, x => x);

			for (var index = 0; index < ingredientsNames.Length; index++)
			{
				var ingredient = existingIngredients.TryGetValue(ingredientsNames[index], out var value)
					? value
					: Ingredient.Create(ingredientsNames[index]);

				var unit = existingMeasurementUnits.TryGetValue(measurementUnitNames[index], out var unitValue)
					? unitValue
					: MeasurementUnit.Create(measurementUnitNames[index]);

				var amountPerPerson = double.Parse(ingredientsXml[index].Attribute("amountPerPerson")?.Value ?? "0");

				recipe.AddIngredient(ingredient, unit, amountPerPerson);
			}

			recipeRepository.Create(recipe);
		}
	}
}