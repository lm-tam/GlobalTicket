using MediatR;

namespace GlobalTicket.TicketManagement.Application.Features.Categories.Queries.GetCategoriesListWithEvents;

public class GetCategoriesListWithEventQuery : IRequest<List<CategoryEventListVm>>
{
    public bool IncludeHistory { get; set; }
}