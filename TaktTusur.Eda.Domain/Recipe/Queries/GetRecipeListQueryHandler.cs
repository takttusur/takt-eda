using MediatR;

namespace TaktTusur.Eda.Domain.Recipe.Queries;

public class GetRecipeListQueryHandler : IRequestHandler<GetRecipeListQuery, GetRecipeListQueryResult>
{
	private readonly IRecipeRepository _repository;

	public GetRecipeListQueryHandler(IRecipeRepository repository)
	{
		_repository = repository;
	}

	public Task<GetRecipeListQueryResult> Handle(GetRecipeListQuery request, CancellationToken cancellationToken)
	{
		// GetAll From repository and filter it
		throw new NotImplementedException();
	}
}