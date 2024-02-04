using Core.Dtos;

namespace Core.Interfaces
{
    public interface IOfferService
    {
        Task<OfferToReturnDto> CreateOfferAsync(string email, int jobId, string message,
            int offerAmount, int daysToBeExpected );
        Task <IReadOnlyList<OfferToReturnDto>> GetOffersForAJobAsync(int jobId);
    }
    
}
