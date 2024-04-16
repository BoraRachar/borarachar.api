using AutoMapper;

namespace BoraRachar.Domain.Service.Abstract.Mappers;

public class BaseAutoMapper : Profile
{
    public BaseAutoMapper()
    {
        AllowNullDestinationValues = true;
        AllowNullCollections = true;
    }
}