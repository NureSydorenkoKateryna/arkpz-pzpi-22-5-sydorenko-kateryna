using AutoMapper;
using FoodFlow.Modules.Users.Api.Features.User.Create;

namespace FoodFlow.Modules.Users.Api.Features.User;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<CreateUserCommand, Application.Domain.Entities.User>();
    }
}
