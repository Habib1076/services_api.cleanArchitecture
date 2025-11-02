using services_api.Application.DTOs;
using services_api.Domain.Entities;

namespace services_api.Application;

internal static class SectionConverter
{
    public static Section ToSectionEntity(this AddSectionRequestDTO addSectionRequestDTO)
    {
        return new Section
        {
            Name = addSectionRequestDTO.SectionName,
            Description = addSectionRequestDTO.SectionDescription,
        };
    }

    public static AddSectionResponseDTO ToAddSectionResponse(this AddSectionRequestDTO addSectionRequestDTO, DateTime CreatedAt,int Id) {
        return new AddSectionResponseDTO
        {
            Id = Id,
            SectionName = addSectionRequestDTO.SectionName,
            SectionDescription = addSectionRequestDTO.SectionDescription,
            CreatedAt = CreatedAt,
        };
    }

    public static GetSectionsDTO ToGetSectionResponse(this Section section) {
        return new GetSectionsDTO
        {
            Id = section.Id,
            SectionName = section.Name,
            SectionDescription = section.Description,
            Offers = section.Offers.Select(o => new GetOffersDTO
            {
                Id = o.Id,
                OfferName = o.Name,
                OfferDescription = o.Description,
                SectionId = o.SectionId,
                CreatedAt = o.CreatedAt
            }).ToList(),
            CreatedAt = section.CreatedAt,
        };
    }
    public static AddSectionResponseDTO ToUpdateSectionResponse(this Section section) {
        return new AddSectionResponseDTO
        {
            Id = section.Id,
            SectionName = section.Name,
            SectionDescription = section.Description,
            CreatedAt = section.CreatedAt,
        };
    }
}
