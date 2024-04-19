using AutoMapper;
using Core.Dtos;
using Core.Entities;
using Core.Interfaces;
using Core.Specification;

namespace Infrastructure.Services
{
    public class OfferService : IOfferService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public OfferService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<bool> AcceptOffer(int offerId)
        {
            // Grab Offer
            var offer = await _unitOfWork.Repository<Offer>().GetByIdAsync(offerId);

            //Check if a contract exists before for offer

            //Define Contract
            var contract = new Contract()
            {
                OfferId = offer.Id,
                Days = offer.ExpectedDaysCompletion,
                Price = offer.Amount,
                Offer = offer,
            };
                                                                                            
            _unitOfWork.Repository<Contract>().Add(contract);
            var result = await _unitOfWork.Complete();
            if (result <= 0) return false;
            return true;

        }

        public async Task<OfferToReturnDto> CreateOfferAsync(string email, int jobId, string message, int offerAmount, int daysToBeExpected)
        {
            var offer = new Offer(daysToBeExpected, offerAmount, email, message,jobId );
            _unitOfWork.Repository<Offer>().Add(offer);
            var result = await _unitOfWork.Complete();         
            if (result <= 0) return null;
            return _mapper.Map<OfferToReturnDto>(offer);
        }

        public async Task <IReadOnlyList<OfferToReturnDto>> GetOffersForAJobAsync(int jobId)
        {
            var spec = new OfferSpecifications(jobId);
            var offers = await _unitOfWork.Repository<Offer>().ListAsync(spec);
            return _mapper.Map<IReadOnlyList<OfferToReturnDto>>(offers);

        }
    }
}
