using services_api.Application.DTOs;
using services_api.Domain.Entities;

namespace services_api.Application;

internal static class OfferConverter
{
    public static Offer ToOfferEntity(this AddOfferRequestDTO addOfferRequestDTO)
    {
        return new Offer
        {
            Name = addOfferRequestDTO.OfferName,
            Description = addOfferRequestDTO.OfferDescription,
            SectionId = addOfferRequestDTO.SectiontId
        };
    }

    public static AddOfferResponseDTO ToAddOfferResponse(this AddOfferRequestDTO addOfferRequestDTO, DateTime CreatedAt,int Id) {
        return new AddOfferResponseDTO
        {
            Id = Id,
            OfferName = addOfferRequestDTO.OfferName,
            OfferDescription = addOfferRequestDTO.OfferDescription,
            SectionId = addOfferRequestDTO.SectiontId,
            CreatedAt = CreatedAt,
        };
    }

    public static GetOffersDTO ToGetOfferResponse(this Offer offer) {
        return new GetOffersDTO
        {
            Id = offer.Id,
            OfferName = offer.Name,
            OfferDescription = offer.Description,
            SectionId = offer.SectionId,
            CreatedAt = offer.CreatedAt,
        };
    }
    public static AddOfferResponseDTO ToUpdateOfferResponse(this Offer offer) {
        return new AddOfferResponseDTO
        {
            Id = offer.Id,
            OfferName = offer.Name,
            OfferDescription = offer.Description,
            SectionId = offer.SectionId,
            CreatedAt = offer.CreatedAt,
        };
    }
}
