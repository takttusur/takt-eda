using System.Xml.Linq;
using TaktTusur.Eda.Domain.Recipe;

namespace TaktTusur.Eda.RecipesLoader.Services;

public interface IRecipesXmlLoader
{
	void IndexFolder(string path, string xsdPath);

	XDocument? GetNextRecipe();
}