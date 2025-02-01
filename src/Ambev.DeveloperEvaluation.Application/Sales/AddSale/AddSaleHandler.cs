using Ambev.DeveloperEvaluation.Domain.Sales.Entities;
using Ambev.DeveloperEvaluation.Domain.Sales.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.AddSale
{
    public class AddSaleHandler : IRequestHandler<AddSaleCommand, AddSaleResult>
    {
        private readonly ISaleRepository saleRepository;
        private readonly IMapper mapper;
        public AddSaleHandler(ISaleRepository saleRepository, IMapper mapper)
        {
            this.saleRepository = saleRepository;
            this.mapper = mapper;
        }
        public async Task<AddSaleResult> Handle(AddSaleCommand command, CancellationToken cancellationToken)
        {
            var addsaleValidator = new AddSaleValidator();
            var validationResult = await addsaleValidator.ValidateAsync(command, cancellationToken);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            /*
                Verify if product exist on Product Context
             */

            var sale = mapper.Map<Sale>(command);

            var createdSale = await saleRepository.CreateAsync(sale, cancellationToken);

            var result = mapper.Map<AddSaleResult>(createdSale);
            return result;
        }
    }
}
