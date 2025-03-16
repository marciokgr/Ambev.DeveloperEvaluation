using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Mappings.Users;

public class GetUserProfile : Profile
{
    public GetUserProfile()
    {
        CreateMap<Guid, Application.Users.GetUser.GetUserCommand>()
            .ConstructUsing(id => new Application.Users.GetUser.GetUserCommand(id));
    }
}
