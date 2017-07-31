namespace SimOnline.Data.Infrastructure
{
    public interface IUnitOfWork
    {
        void Commit();
    }
}