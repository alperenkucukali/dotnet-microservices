using Account.Application.Features.Accounts.Commands.CreateAccount;
using Account.Application.Features.Accounts.Queries.GetAccount;
using AutoMapper;

namespace Account.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateAccountCommand, Domain.Entities.Account>()
                .ForMember(dest => dest.CustomerId, opt => opt.MapFrom(src => src.CustomerId))
                .ForMember(dest => dest.Balance, opt => opt.MapFrom(src => 0));
            CreateMap<Domain.Entities.Account, GetAccountResponse>()
                .ForMember(dest => dest.AccountId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.CustomerId, opt => opt.MapFrom(src => src.CustomerId))
                .ForMember(dest => dest.Balance, opt => opt.MapFrom(src => src.Balance))
                .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(src => src.CreatedDate));
        }
    }
}
