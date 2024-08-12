using AutoMapper;
using PaparaFinal.DtoLayer.DigitalWalletDtos;
using PaparaFinal.EntityLayer.Entities;

namespace PaparaFinal.BusinessLayer.Mapper;

public class DigitalWalletMapping : Profile
{
    public DigitalWalletMapping()
    {
        CreateMap<DigitalWallet, CreateDigitalWalletDto>().ReverseMap();
        CreateMap<DigitalWallet, UpdateDigitalWalletDto>().ReverseMap();
        CreateMap<DigitalWallet, ResultDigitalWalletDto>().ReverseMap();
    }
}