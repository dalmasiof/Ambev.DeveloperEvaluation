using Ambev.DeveloperEvaluation.Application.Sales.AddSale;
using Ambev.DeveloperEvaluation.Application.Sales.GetSale;
using Ambev.DeveloperEvaluation.Application.Users.CreateUser;
using Ambev.DeveloperEvaluation.WebApi.Common;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.AddSale;
using Ambev.DeveloperEvaluation.WebApi.Features.Users.CreateUser;
using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetSale;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaleController : BaseController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public SaleController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        // POST: api/<SaleController>
        [HttpPost]
        [ProducesResponseType(typeof(ApiResponseWithData<AddSaleResult>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromBody] AddSaleRequest request, CancellationToken cancellationToken)
        {
            var validator = new AddSaleRequestRequestValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var command = _mapper.Map<AddSaleCommand>(request);
            var response = await _mediator.Send(command, cancellationToken);

            return Created(string.Empty, new ApiResponseWithData<AddSaleResult>
            {
                Success = true,
                Message = "Sale created successfully",
                Data = _mapper.Map<AddSaleResult>(response)
            });
        }

        // GET: api/<SaleController>
        [HttpGet]
        [ProducesResponseType(typeof(ApiResponseWithData<GetSaleResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get([FromQuery] GetSaleRequest request, CancellationToken cancellationToken)
        {
            var handlers = _mediator.GetType().Assembly.GetTypes()
            .Where(t => typeof(IRequestHandler<,>).IsAssignableFrom(t));

            foreach (var handler in handlers)
            {
                Console.WriteLine($"Handler registrado: {handler.Name}");
            }

            var validator = new GetSaleRequestValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);
            try
            {
                var query = _mapper.Map<GetSaleQuery>(request);
                var response = await _mediator.Send(query, cancellationToken);

                return Ok(new ApiResponseWithData<GetSaleResult>
                {
                    Success = true,
                    Message = "Sale retrieved successfully",
                    Data = _mapper.Map<GetSaleResult>(response)
                });
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
