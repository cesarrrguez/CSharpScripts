#load "entities.csx"
#load "viewModels.csx"

using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

public class DomainToViewModelMappingProfile : Profile
{
    public DomainToViewModelMappingProfile()
    {
        CreateMap<User, UserViewModel>();
        CreateMap<UserAddress, UserAddressViewModel>();
        CreateMap<UserEmail, UserEmailViewModel>();
    }
}

public class ViewModelToDomainMappingProfile : Profile
{
    public ViewModelToDomainMappingProfile()
    {
        CreateMap<UserViewModel, User>()
            .ForMember(u => u.Addresses, opt => opt.Ignore())
            .ForMember(u => u.Emails, opt => opt.Ignore())
            .ConstructUsing(u => new User(u.FirstName, u.LastName, u.Age))
            .AfterMap((uvm, u) =>
            {
                if (uvm.Addresses != null)
                {
                    foreach (var ua in uvm.Addresses)
                        u.AddAddress(ua.Id, ua.Street, ua.City, ua.State, ua.ZipCode);
                }

                if (uvm.Emails != null)
                {
                    foreach (var ue in uvm.Emails)
                        u.AddEmail(ue.Id, ue.EmailAddress);
                }
            });
    }
}
