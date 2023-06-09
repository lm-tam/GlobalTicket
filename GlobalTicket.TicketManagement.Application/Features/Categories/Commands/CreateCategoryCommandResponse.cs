using GlobalTicket.TicketManagement.Application.Responses;
using MediatR;

namespace GlobalTicket.TicketManagement.Application.Features.Categories.Commands;

public class CreateCategoryCommandResponse : BaseResponse, IRequest
{
    public CreateCategoryCommandResponse() : base()
    {
        
    }

    public CreateCategoryDto Category { get; set; } = default!;
}