using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;
using TaktTusur.Eda.Api.Tests.Helpers;

namespace TaktTusur.Eda.Api.Tests;

public class TestsBase
{
	public IConfiguration Configuration { get; protected set; }

	protected WebApplicationFactory<Program>? WebAppFactory
	{
		get => TestContextHelper.GetTestContextProperty<WebApplicationFactory<Program>>(nameof(WebAppFactory));
		set => TestContextHelper.SetTestContextProperty(nameof(WebAppFactory), value);
	}

	[OneTimeSetUp]
	public void OneTimeSetUpBase()
	{
		Configuration = new ConfigurationBuilder().Build();
	}

	[TearDown]
	public void TearDownBase()
	{
		WebAppFactory?.Dispose();
	}
}