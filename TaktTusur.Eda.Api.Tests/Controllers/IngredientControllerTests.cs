using FluentAssertions;
using NUnit.Framework;
using System.Linq;
using System.Threading.Tasks;
using TaktTusur.Eda.Api.Tests.Helpers;
using TaktTusur.Eda.Api.Tests.Infrastructure;
using TaktTusur.Eda.Api.Tests.TestData;
using TaktTusur.Eda.Application.ViewModels;
using TaktTusur.Eda.Infrastructure.Contexts;

namespace TaktTusur.Eda.Api.Tests.Controllers
{
	[TestFixture]
	public class IngredientControllerTests : TestsBase
	{
		public const string BASE_URL = "api/v1/Ingredient";

		[SetUp]
		public void SetUp()
		{
			WebAppFactory = CustomWebApplicationFactory<Program>
				.CreateWithInMemoryDb<Program, EdaDbContext>(IngredientsTestData.SeedIngredientsData(null));
		}

		[Test]
		public async Task GetWithoutParameters()
		{
			var httpClient = WebAppFactory!.CreateClient();
			var response = await httpClient.GetStringAsync(BASE_URL);
			var result = response.FromJson<ListResponse<IdNameViewModel>>();
			result!.Data
				.Should().HaveCount(10, "By default 10 items should be returned");
			result!.Skip
				.Should().Be(0, "Default skip is 0");
			result!.Take
				.Should().Be(10, "Default take is 10");
			result!.TotalCount
				.Should().Be(IngredientsTestData.TestData.Count(),
					"Total count should match the total ingredients in test data.");
		}

		[Test]
		public async Task GetWithGivenParameters_CheckCorrectSequence()
		{
			var client = WebAppFactory!.CreateClient();
			var firstFive = IngredientsTestData.TestData.Take(5)
				.Select(x => x.Name)
				.ToArray();
			var response = await client.GetStringAsync($"{BASE_URL}?skip=0&take=5");
			var result = response.FromJson<ListResponse<IdNameViewModel>>();
			result!.Data
				.Should().HaveCount(5, "5 items requested");
			result!.Data
				.Select(x => x.Name)
				.Should().BeEquivalentTo(firstFive, "Names should match and order should not matter");
		}

		[Test]
		public async Task Get_SkipAll()
		{
			var client = WebAppFactory!.CreateClient();
			var response = await client.GetStringAsync($"{BASE_URL}?skip=100");
			var result = response.FromJson<ListResponse<IdNameViewModel>>();
			result!.Data
				.Should().BeEmpty("All items were skipped");
		}

		[Test]
		public async Task Get_NegativeParams()
		{
			var client = WebAppFactory!.CreateClient();
			var response = await client.GetStringAsync($"{BASE_URL}?take=-1&skip=0");
			var result = response.FromJson<ListResponse<IdNameViewModel>>();
			result!.Data
				.Should().BeEmpty("Invalid parameters were given");
		}
	}
}