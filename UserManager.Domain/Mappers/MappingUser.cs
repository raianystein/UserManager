using AutoMapper;
using UserManager.Domain.Entities;
using UserManager.Domain.Models;

namespace UserManager.Domain.Mappers;

public class MappingUser : Profile
{
    public MappingUser()
    {
        CreateMap<User, UserResponse>();
    }
}
