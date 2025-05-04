using System.Xml.Linq;
using System.Xml.Schema;
using TaktTusur.Eda.RecipesLoader.Exceptions;

namespace TaktTusur.Eda.RecipesLoader.Services;

public class RecipesXmlLoader : IRecipesXmlLoader
{
	private const string SEARCH_PATTERN = "*.xml";
	private List<string> _filePaths = new List<string>();
	private XmlSchemaSet? _xmlSchema = null;

	public void IndexFolder(string recipesPath, string xsdPath)
	{
		if (string.IsNullOrWhiteSpace(recipesPath))
			throw new ArgumentException("Path cannot be null, empty or whitespace.", nameof(recipesPath));

		if (string.IsNullOrWhiteSpace(xsdPath))
			throw new ArgumentException("Path cannot be null, empty or whitespace.", nameof(xsdPath));

		if (!Directory.Exists(recipesPath))
			throw new DirectoryNotFoundException($"The directory '{recipesPath}' was not found.");

		if (!File.Exists(xsdPath))
			throw new FileNotFoundException($"XSD file was not found at '{xsdPath}'");

		_xmlSchema = new XmlSchemaSet();
		_xmlSchema.Add("", xsdPath);
		_filePaths = [..Directory.GetFiles(recipesPath, SEARCH_PATTERN)];
	}

	public XDocument? GetNextRecipe()
	{
		if (_filePaths.Count == 0)
			return null;
		if (_xmlSchema == null)
			throw new XmlLoadingException($"XSD Scheme is not set. Please, set it first using {nameof(IndexFolder)}");

		var nextFile = _filePaths.First();
		_filePaths.RemoveAt(0);

		var xDoc = XDocument.Load(nextFile);

		string errorMessage = string.Empty;
		xDoc.Validate(_xmlSchema, (o, e) => { errorMessage = e.Message; });

		if (!string.IsNullOrEmpty(errorMessage))
			throw new XmlSchemaValidationException(errorMessage);

		return xDoc;
	}
}