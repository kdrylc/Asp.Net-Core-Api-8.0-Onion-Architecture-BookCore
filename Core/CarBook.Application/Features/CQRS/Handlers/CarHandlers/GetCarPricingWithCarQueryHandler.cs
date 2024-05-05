using MediatR;
using CarBook.Application.Features.Mediator.Results.CarPricingResults;
using CarBook.Application.Interfaces.CarInterfaces;

namespace CarBook.Application.Features.Mediator.Handlers.CarPricingHandlers
{
    public class GetCarPricingWithCarQueryHandler
    {
        private readonly ICarRepository _repository;
        public GetCarPricingWithCarQueryHandler(ICarRepository repository)
        {
            _repository = repository;
        }
        public List<GetCarPricingWithCarQueryResult> Handle()
            
        {
            var values = _repository.GetCarsWithPricings();
            return values.Select(x => new GetCarPricingWithCarQueryResult
            {
                Model =x.Car.Model,
                CoverImageUrl= x.Car.CoverImageUrl,
                BrandName =x.Car.Brand.Name,
                PricingAmount=x.Amount,
            }).ToList();
        }
    }
}
