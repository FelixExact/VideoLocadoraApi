namespace FD.Videolocadora.Infra.Data.Interface
{
    public interface IUnitOfWork
    {
        void BeginTransaction();
        void Commit();
    }
}
