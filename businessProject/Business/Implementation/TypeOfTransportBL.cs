using businessProject.Business.Interface;
using businessProject.DTO;
using businessProject.Models;
using businessProject.Repository.Interface;

namespace businessProject.Business.Implementation
{
    public class TypeOfTransportBL : ITypeOfTransportBL
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITypeOfTransportRepository _typeOfTransport;
        public TypeOfTransportBL(IUnitOfWork unitOfWork, ITypeOfTransportRepository typeOfTransport)
        {
            _typeOfTransport = typeOfTransport;
            _unitOfWork = unitOfWork;

        }

        public bool addTransport(AddTypeOfTransportDto addTypeOfTransportDtot)
        {

            TypeOfTransport typeOfTransport = new TypeOfTransport
            {
                Id = 0,
                Name = addTypeOfTransportDtot.Name,
                Speed = addTypeOfTransportDtot.Speed
            };

            _typeOfTransport.Add(typeOfTransport);
            _unitOfWork.Save();
            return true;
        }

        public bool deleteTransport(int id)
        {
            _typeOfTransport.DeleteWhere(x => x.Id == id);
            _unitOfWork.Save();
            return true;
        }

        public List<TypeOfTransportDto> getAll()
        {
            var values = _typeOfTransport.GetAll();

            List<TypeOfTransportDto> typeOfTransportDtosList = new List<TypeOfTransportDto>();
            foreach (var item in values)
            {
                TypeOfTransportDto typeOfTransportDto = new TypeOfTransportDto
                {
                    Name = item.Name,
                    Speed = item.Speed
                };

                typeOfTransportDtosList.Add(typeOfTransportDto);
            }

            return typeOfTransportDtosList;
        }

        public TypeOfTransportDto getById(int id)
        {
            var value = _typeOfTransport.GetSingle(x => x.Id == id);

            if (value == null)
            {
                return null;
            }
            TypeOfTransportDto typeOfTransportDto = new TypeOfTransportDto
            {
                Name = value.Name,
                Speed = value.Speed
            };
            return typeOfTransportDto;

        }

        public bool updateTransport(int id, AddTypeOfTransportDto addTypeOfTransportDto)
        {
            var value = _typeOfTransport.GetSingle(x => x.Id == id);
            if (value == null)
            {
                return false;
            }
            value.Name = addTypeOfTransportDto.Name;
            value.Speed = addTypeOfTransportDto.Speed;
            _unitOfWork.Save();
            return true;

        }

    }
}