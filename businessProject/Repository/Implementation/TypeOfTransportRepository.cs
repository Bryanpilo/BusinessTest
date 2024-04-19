using businessProject.Models;
using businessProject.Repository.Interface;

namespace businessProject.Repository.Implementation
{
    public class TypeOfTransportRepository : RepositoryBase<TypeOfTransport>, ITypeOfTransportRepository
    {
        public TypeOfTransportRepository(BusinessProjectContext context) : base(context)
        {
        }

    }
}