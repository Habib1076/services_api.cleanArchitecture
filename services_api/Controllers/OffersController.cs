using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using services_api.Application.DTOs;
using services_api.Application.Services;
using services_api.Domain.Entities;

namespace services_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OffersController : ControllerBase
    {
        private readonly IOfferService _offerService;
        public OffersController(IOfferService offerService) {
            _offerService = offerService;
        }
        [HttpPost]
        public async Task<IActionResult> AddOffer(AddOfferRequestDTO addOfferRequestDTO)
        {
            var result = await _offerService.AddOffer(addOfferRequestDTO);
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllOffers()
        {
            var result = await _offerService.GetAllOffers();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOfferById(int id)
        {
            var result = await _offerService.GetOfferById(id);
            return Ok(result);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOffer(AddOfferRequestDTO updateOfferRequestDTO, int id)
        {
            var result = await _offerService.UpdateOffer(updateOfferRequestDTO, id);
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOffer(int id)
        {
            var result = await _offerService.DeleteOffer(id);
            return Ok(result);
        }
    }
    
}
