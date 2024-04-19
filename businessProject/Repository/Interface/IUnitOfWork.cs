namespace businessProject.Repository.Interface
{
    public interface IUnitOfWork: IDisposable
    {

        void Save();
         
    }
}