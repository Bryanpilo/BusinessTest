using businessProject.DTO;

namespace businessProject.Business.Interface
{
    public interface ITypeOfTransportBL
    {
         bool addTransport(AddTypeOfTransportDto addTypeOfTransportDto);
         List<TypeOfTransportDto> getAll();
         TypeOfTransportDto getById(int id);
         bool updateTransport(int id, AddTypeOfTransportDto addTypeOfTransportDto);
         bool deleteTransport(int id);
    }
}