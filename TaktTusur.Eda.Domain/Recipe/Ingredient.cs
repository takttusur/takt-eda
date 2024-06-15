using TaktTusur.Eda.Domain.Base;

namespace TaktTusur.Eda.Domain.Recipe;

/// <summary>
/// Ingredint. It's a product which can be used in recipe.
/// </summary>
public class Ingredient : Entity
{
	protected Ingredient(string name)
	{
		Name = name;
	}

	/// <summary>
	/// Name of product.
	/// </summary>
	/// <example>Potato, rice, milk...</example>
	public string Name { get; protected set; }

	/// <summary>
	/// Rename ingredient.
	/// </summary>
	/// <param name="name">New name for ingredient.</param>
	/// <exception cref="EntityValidationException">
	///	Will be thrown if name is empty, or name is similar to current name;
	/// </exception>
	public void Rename(string name)
	{
		if (string.IsNullOrWhiteSpace(name))
			throw new EntityValidationException(nameof(Name), "cannot be empty");

		if (name == Name)
			throw new EntityValidationException(nameof(Name), "new name should be different");

		Name = name;
	}

	public static Ingredient Create(string name)
	{
		if (string.IsNullOrWhiteSpace(name))
			throw new EntityValidationException(nameof(Name), "cannot be empty");

		return new Ingredient(name);
	}
}