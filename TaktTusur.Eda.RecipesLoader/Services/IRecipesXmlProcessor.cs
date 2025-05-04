using System.Xml;
using System.Xml.Linq;

namespace TaktTusur.Eda.RecipesLoader.Services;

public interface IRecipesXmlProcessor
{
	void Process(XDocument xDocument);
}