using SimOnline.Data.Infrastructure;
using SimOnline.Model.Models;

namespace SimOnline.Data.Repositories
{
    public interface IConsignerRepository : IRepository<Consigner>
    {
    }

    internal class ConsignerRepository : RepositoryBase<Consigner>, IConsignerRepository
    {
        public ConsignerRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}