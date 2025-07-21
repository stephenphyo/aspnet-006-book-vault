using AutoMapper;
using ASPNET_006_Book_Vault.Models;
using ASPNET_006_Book_Vault.DTOs.BookDTO;

namespace ASPNET_006_Book_Vault.Profiles
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<CreateBookDTO, Book>();
        }
    }
}