﻿using Core.Dtos;
using Core.Errors;
using Core.Interfaces;
using Jobby.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Jobby.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class OfferController : ControllerBase
    {
        private readonly IOfferService _offerService;
        private readonly IHttpContextAccessor _httpContextAccessor;

 
        public OfferController(IOfferService offerService, IHttpContextAccessor httpContextAccessor)
        {
            _offerService = offerService;
            _httpContextAccessor = httpContextAccessor;
        }
        [HttpPost("make-offer")]
        public async Task<ActionResult<OfferToReturnDto>> CreateOfferAsync(OfferToCreateDto dto)
        {
            var email = _httpContextAccessor.HttpContext?.User.RetrieveEmailFromPrincipal();
            var offer = await _offerService.CreateOfferAsync(email, dto.JobId, dto.Message, dto.Amount, dto.DaysExpected);
            if (offer == null) return BadRequest(new ApiResponse(400, "Problem Creating Your Offer"));
            return Ok(offer);
        }

        [HttpGet("get-offers")]
        public async Task<ActionResult<IReadOnlyList<OfferToReturnDto>>> GetOffersForAJob(int jobId)
        {
            var offers = await _offerService.GetOffersForAJobAsync(jobId);
            if (offers == null) return NotFound();
            return Ok(offers);
        }


        [HttpPost("accept-offer")]
        public async Task<IActionResult> AcceptOffer(int offerId)
        {
            var isAccepted = await _offerService.AcceptOffer(offerId);
            if(!isAccepted) return NotFound();
            return Ok();
            
        }
    }
}
