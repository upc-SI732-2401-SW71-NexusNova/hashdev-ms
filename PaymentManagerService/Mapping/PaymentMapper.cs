using AutoMapper;

namespace PaymentManagerService.Mapping
{
    public class PaymentMapper : Profile
    {
        public PaymentMapper()
        {
            // Source -> Target
            CreateMap<Models.Payment, Dtos.PaymentReadDto>();
            CreateMap<Dtos.PaymentCreateDto, Models.Payment>();
        }
    }
}
