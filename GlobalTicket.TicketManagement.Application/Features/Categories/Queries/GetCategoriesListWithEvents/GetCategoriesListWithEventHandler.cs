using AutoMapper;
using GlobalTicket.TicketManagement.Application.Contracts.Persistence;
using MediatR;

namespace GlobalTicket.TicketManagement.Application.Features.Categories.Queries.GetCategoriesListWithEvents;

public class GetCategoriesListWithEventHandler : IRequestHandler<GetCategoriesListWithEventQuery, List<CategoryEventListVm>>
{
    private readonly IMapper _mapper;

    private readonly ICategoryRepository _categoryRepository;

    public GetCategoriesListWithEventHandler(IMapper mapper, ICategoryRepository categoryRepository)
    {
        _mapper = mapper;
        _categoryRepository = categoryRepository;
    }

    public async Task<List<CategoryEventListVm>> Handle(GetCategoriesListWithEventQuery request, CancellationToken cancellationToken)
    {
        var list = (await _categoryRepository.GetCategoriesWithEventsAsync(request.IncludeHistory));

        return _mapper.Map<List<CategoryEventListVm>>(list);
    }
}