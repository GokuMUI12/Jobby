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

        public async Task<OfferToReturnDto> CreateOfferAsync(string email, int jobId, string message, int offerAmount, int daysToBeExpected)
        {
            var offer = new Offer(daysToBeExpected, offerAmount, email, message,jobId );
            _unitOfWork.Repository<Offer>().Add(offer);
            var result = await _unitOfWork.Complete();
            //var job = await _unitOfWork.Repository<Job>().GetByIdAsync(jobId);
            //var spec = new JobWithSkillsSpecification(jobId);
            //var jobSkills = await _unitOfWork.Repository<Job>().GetEntityWithSpec(spec);
            if (result <= 0) return null;
            return _mapper.Map<OfferToReturnDto>(offer);
        }
        public async Task <IReadOnlyList<OfferToReturnDto>> GetOffersForAJobAsync(int jobId)
        {
            var spec = new OfferSpecifications(jobId);
            var offers = await _unitOfWork.Repository<Offer>().ListAsync(spec);
            return _mapper.Map<List<OfferToReturnDto>>(offers);

        }
    }
}
