using AutoMapper;

namespace Notes.Application.Common.Mapping;

public interface IMapWith<T>
{
    void Map(Profile profile) => profile.CreateMap(typeof(T),GetType());
}
