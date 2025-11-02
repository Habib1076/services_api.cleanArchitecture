using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using services_api.Application.DTOs;
using services_api.Application.Services;

namespace services_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SectionsController : ControllerBase
    {
        private readonly ISectionService _SectionService;
        public SectionsController(ISectionService sectionService)
        {
            _SectionService = sectionService;
        }
        [HttpPost]
        public async Task<IActionResult> AddSection(AddSectionRequestDTO addSectionRequestDTO)
        {
            var result = await _SectionService.AddSection(addSectionRequestDTO);
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllSections()
        {
            var result = await _SectionService.GetAllSections();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSectionById(int id)
        {
            var result = await _SectionService.GetSectionById(id);
            return Ok(result);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSection(AddSectionRequestDTO updateSectionRequestDTO, int id)
        {
            var result = await _SectionService.UpdateSection(updateSectionRequestDTO, id);
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSection(int id)
        {
            var result = await _SectionService.DeleteSection(id);
            return Ok(result);
        }
    }
}
