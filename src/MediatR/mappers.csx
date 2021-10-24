#load "entities.csx"
#load "commands.csx"

using AutoMapper;

public class DomainProfile : Profile
{
    public DomainProfile()
    {
        CreateMap<CreateCustomerCommand, Customer>()
            .ForMember(customer => customer.RegistrationDate, opt =>
                opt.MapFrom(_ => DateTime.Now));

        CreateMap<Customer, CustomerDto>()
            .ForMember(customerDto => customerDto.RegistrationDate, opt =>
                opt.MapFrom(customer => customer.RegistrationDate.ToShortDateString()));
    }
}
