using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using NUnit.Framework.Internal;
using TaktTusur.Eda.Infrastructure.Contexts;

namespace TaktTusur.Eda.Api.Tests.Infrastructure;

public class CustomWebApplicationFactory<T> : WebApplicationFactory<T> where T : class
{
	private readonly Action<IServiceCollection> _configureServices;

	public CustomWebApplicationFactory(Action<IServiceCollection> configureServices)
	{
		_configureServices = configureServices;
	}

	protected override void ConfigureWebHost(IWebHostBuilder builder)
	{
		base.ConfigureWebHost(builder);
		builder.ConfigureServices(_configureServices);
	}

	public static CustomWebApplicationFactory<TProgram> CreateWithInMemoryDb<TProgram, TDbContext>(
		Action<TDbContext>? seedData = null) where TProgram : class where TDbContext : DbContext
	{
		var webAppFactory = new CustomWebApplicationFactory<TProgram>((services) =>
		{
			services.RemoveAll(typeof(TDbContext));
			services.RemoveAll(typeof(DbContextOptions<TDbContext>));
			var options = new DbContextOptionsBuilder<TDbContext>()
				.UseInMemoryDatabase(TestExecutionContext.CurrentContext.CurrentTest.FullName)
				.Options;
			services.AddSingleton(options);
			services.AddSingleton<TDbContext>();

			if (seedData is null) return;
			var sp = services.BuildServiceProvider();
			using (var scope = sp.CreateScope())
			{
				var context = scope.ServiceProvider.GetRequiredService<TDbContext>();
				seedData(context);
			}
		});

		return webAppFactory;
	}
}