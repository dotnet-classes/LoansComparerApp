﻿using LoansComparer.CrossCutting.DTO;
using LoansComparer.CrossCutting.DTO.LoaningBank;
using LoansComparer.Services.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LoansComparer.Presentation.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/inquiries")]
    public class InquiryController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public InquiryController(IServiceManager serviceManager) => _serviceManager = serviceManager;

        [HttpGet]
        public async Task<ActionResult<List<GetInquiryDTO>>> GetAll()
        {
            var userId = User.FindFirst("Id")?.Value!;

            var inquiries = await _serviceManager.InquiryService.GetAllByUser(Guid.Parse(userId));
            return Ok(inquiries);
        }

        [AllowAnonymous]
        [HttpPost("add")]
        public async Task<ActionResult<CreateInquiryResponse>> Add([FromBody] AddInquiryDTO inquiry)
        {
            var userId = User.FindFirst("Id")?.Value;
            await _serviceManager.InquiryService.Add(inquiry, userId);

            var response = await _serviceManager.LoaningService.Inquire(inquiry);
            if (response.IsSuccessful)
            {
                return Ok(response.Content);
            }

            return StatusCode(500);
        }

        [AllowAnonymous]
        [HttpPatch("{inquiryId}/chooseOffer")]
        public async Task<ActionResult> ChooseOffer(Guid inquiryId, [FromBody] ChooseOfferDTO chosenOffer)
        {
            await _serviceManager.InquiryService.ChooseOffer(inquiryId, chosenOffer);
            return Ok();
        }
    }
}
