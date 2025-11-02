
using services_api.Application.DTOs;
using services_api.Domain.Repositories;

namespace services_api.Application.Services;

public interface ISectionService
{
    Task<AddSectionResponseDTO> AddSection(AddSectionRequestDTO addSectionRequestDTO);
    Task<IEnumerable<GetSectionsDTO>> GetAllSections();
    Task<GetSectionsDTO> GetSectionById(int id);
    Task<AddSectionResponseDTO> UpdateSection(AddSectionRequestDTO addSectionRequestDTO, int id);
    Task<AddSectionResponseDTO> DeleteSection(int id);
}
internal sealed class SectionService : ISectionService
{
    private readonly ISectionRepository _servicesRepository;
    public SectionService(ISectionRepository servicesRepository) {
        _servicesRepository = servicesRepository;
    }
    public async Task<AddSectionResponseDTO> AddSection(AddSectionRequestDTO addSectionRequestDTO)
    {
        try
        {
            if (addSectionRequestDTO == null || !addSectionRequestDTO.IsValid())
            {
                return SectionErrors.InvalidRequest();
            }

            var SectionEntity = addSectionRequestDTO.ToSectionEntity();
            await _servicesRepository.AddSectionAsync(SectionEntity);
            var response = addSectionRequestDTO.ToAddSectionResponse(SectionEntity.CreatedAt,SectionEntity.Id);

            return response;
        }
        catch (Exception ex)
        {
            throw new ArgumentException("Unexpected Error!");
        }
    }

    public async Task<IEnumerable<GetSectionsDTO>> GetAllSections()
    {

        var sections = await _servicesRepository.GetAllAsync();
        var response = sections.Select(o => o.ToGetSectionResponse());
        return response;
    }

    public async Task<GetSectionsDTO> GetSectionById(int id)
    {
        var section = await _servicesRepository.GetByIdAsync(id);

        if (section == null) return null;

        var response = section.ToGetSectionResponse();
        return response;
    }
    public async Task<AddSectionResponseDTO> UpdateSection(AddSectionRequestDTO updateSectionRequestDTO,int id)
    {
        if(updateSectionRequestDTO == null || !updateSectionRequestDTO.IsValid())
        {
            return SectionErrors.InvalidRequest();
        }

        var section = await _servicesRepository.GetByIdAsync(id);
        if (section is null)
            return SectionErrors.NotFound(id);

        section.Name = updateSectionRequestDTO.SectionName;
        section.Description = updateSectionRequestDTO.SectionDescription;

        await _servicesRepository.UpdateSectionAsync(section);


        var response = section.ToUpdateSectionResponse();
        return response;
    }
    public async Task<AddSectionResponseDTO> DeleteSection(int id) { 
        if (id <= 0)
        {
            return SectionErrors.NotFound(id);
        }
        var section = await _servicesRepository.GetByIdAsync(id);
        if (section is null)
            return SectionErrors.NotFound(id);
        
        await _servicesRepository.DeleteSectionAsync(section);
        return new AddSectionResponseDTO()
        {
            Id = id,
            SectionName = section.Name,
            SectionDescription = section.Description,
            CreatedAt = section.CreatedAt,
        };
    }
}


public static class SectionErrors
{
    public static AddSectionResponseDTO InvalidRequest()
    {
        return new AddSectionResponseDTO();
    }

    public static AddSectionResponseDTO NotFound(int id)
    {
        return new AddSectionResponseDTO
        {
            Id = id,
            SectionName = "Not Found",
            SectionDescription = $"Section with id {id} was not found."
        };
    }
}