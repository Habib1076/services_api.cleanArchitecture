using Azure;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using services_api.Application.DTOs;
using services_api.Domain.Repositories;

namespace services_api.Application.Services;

public interface IOfferService
{
    Task<OfferResponseDTO> AddOffer(OfferRequestDTO addOfferRequestDTO);
    Task<IEnumerable<GetOffersDTO>> GetAllOffers();
    Task<GetOffersDTO> GetOfferById(int id);
    Task<OfferResponseDTO> UpdateOffer(OfferRequestDTO addOfferRequestDTO, int id);
    Task<OfferResponseDTO> DeleteOffer(int id);
}
internal sealed class OfferService : IOfferService
{
    private readonly IOfferRepository _servicesRepository;
    public OfferService(IOfferRepository servicesRepository) {
        _servicesRepository = servicesRepository;
    }
    public async Task<OfferResponseDTO> AddOffer(OfferRequestDTO addOfferRequestDTO)
    {
        try
        {
            if (addOfferRequestDTO == null || !addOfferRequestDTO.IsValid())
            {
                return OfferErrors.InvalidRequest();
            }

            var OfferEntity = addOfferRequestDTO.ToOfferEntity();
            await _servicesRepository.AddOfferAsync(OfferEntity);
            var response = addOfferRequestDTO.ToAddOfferResponse(OfferEntity.CreatedAt,OfferEntity.Id);

            return response;
        }
        catch (Exception ex)
        {

            throw new ArgumentException("Unexpected Error!");
        }
    }

    public async Task<IEnumerable<GetOffersDTO>> GetAllOffers()
    {

        var offers = await _servicesRepository.GetAllAsync();
        var response = offers.Select(o => o.ToGetOfferResponse());
        return response;
    }

    public async Task<GetOffersDTO> GetOfferById(int id)
    {
        var offer = await _servicesRepository.GetByIdAsync(id);

        if (offer == null) return null;

        var response = offer.ToGetOfferResponse();
        return response;
    }
    public async Task<OfferResponseDTO> UpdateOffer(OfferRequestDTO updateOfferRequestDTO,int id)
    {
        if(updateOfferRequestDTO == null || !updateOfferRequestDTO.IsValid())
        {
            return OfferErrors.InvalidRequest();
        }

        var offer = await _servicesRepository.GetByIdAsync(id);
        if (offer is null)
            return OfferErrors.NotFound(id);

        offer.Name = updateOfferRequestDTO.OfferName;
        offer.Description = updateOfferRequestDTO.OfferDescription;

        await _servicesRepository.UpdateOfferAsync(offer);


        var response = offer.ToUpdateOfferResponse();
        return response;
    }
    public async Task<OfferResponseDTO> DeleteOffer(int id) { 
        if (id <= 0)
        {
            return OfferErrors.NotFound(id);
        }
        var offer = await _servicesRepository.GetByIdAsync(id);
        if (offer is null)
            return OfferErrors.NotFound(id);
        
        await _servicesRepository.DeleteOfferAsync(offer);
        return new OfferResponseDTO()
        {
            Id = id,
            OfferName = offer.Name,
            OfferDescription = offer.Description,
            CreatedAt = offer.CreatedAt,
        };
    }
}


public static class OfferErrors
{
    public static OfferResponseDTO InvalidRequest()
    {
        return new OfferResponseDTO();
    }

    public static OfferResponseDTO NotFound(int id)
    {
        return new OfferResponseDTO
        {
            Id = id,
            OfferName = "Not Found",
            OfferDescription = $"Offer with id {id} was not found."
        };
    }
}