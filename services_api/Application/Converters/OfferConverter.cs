using services_api.Application.DTOs;
using services_api.Domain.Entities;

namespace services_api.Application;

internal static class OfferConverter
{
    public static Offer ToOfferEntity(this OfferRequestDTO addOfferRequestDTO)
    {
        return new Offer
        {
            Name = addOfferRequestDTO.OfferName,
            Description = addOfferRequestDTO.OfferDescription,
        };
    }

    public static OfferResponseDTO ToAddOfferResponse(this OfferRequestDTO addOfferRequestDTO, DateTime CreatedAt,int Id) {
        return new OfferResponseDTO
        {
            Id = Id,
            OfferName = addOfferRequestDTO.OfferName,
            OfferDescription = addOfferRequestDTO.OfferDescription,
            CreatedAt = CreatedAt,
        };
    }

    public static GetOffersDTO ToGetOfferResponse(this Offer offer) {
        return new GetOffersDTO
        {
            Id = offer.Id,
            OfferName = offer.Name,
            OfferDescription = offer.Description,
            CreatedAt = offer.CreatedAt,
        };
    }
    public static OfferResponseDTO ToUpdateOfferResponse(this Offer offer) {
        return new OfferResponseDTO
        {
            Id = offer.Id,
            OfferName = offer.Name,
            OfferDescription = offer.Description,
            CreatedAt = offer.CreatedAt,
        };
    }
}
