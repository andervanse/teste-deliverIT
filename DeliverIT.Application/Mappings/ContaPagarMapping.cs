using AutoMapper;

namespace DeliverIT.Application.Mappings
{
    public class ContaPagarMapping: Profile
    {
        public ContaPagarMapping()
        {
            CreateMap<Domain.ContaPagar, DTO.ContaPagar>().ReverseMap();
        }
    }
}
