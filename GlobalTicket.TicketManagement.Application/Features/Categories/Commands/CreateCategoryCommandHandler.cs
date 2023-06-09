using AutoMapper;
using FluentValidation;
using GlobalTicket.TicketManagement.Application.Contracts.Persistence;
using GlobalTicket.TicketManagement.Domain.Entities;
using MediatR;

namespace GlobalTicket.TicketManagement.Application.Features.Categories.Commands;

public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, CreateCategoryCommandResponse>
{
    private readonly ICategoryRepository _categoryRepository;

    private readonly IMapper _mapper;

    public CreateCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }

    public async Task<CreateCategoryCommandResponse> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var createCategoryCommandResponse = new CreateCategoryCommandResponse();
        
        var validator = new CreateCategoryCommandValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (validationResult.Errors.Any())
        {
            createCategoryCommandResponse.IsSuccess = false;
            createCategoryCommandResponse.ValidationErrors =
                validationResult.Errors.Select(error => error.ErrorMessage).ToList();

        }

        if (createCategoryCommandResponse.IsSuccess)
        {
            var category = new Category { Name = request.Name };
            category = await _categoryRepository.AddAsync(category, cancellationToken);

            createCategoryCommandResponse.Category = _mapper.Map<CreateCategoryDto>(category);
        }

        return createCategoryCommandResponse;
    }
}

public class CreateCategoryDto
{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;
}

public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
{
}