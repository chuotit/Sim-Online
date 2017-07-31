using SimOnline.Data.Infrastructure;
using SimOnline.Model.Models;

namespace SimOnline.Data.Repositories
{
    public interface IConsignerLevelRepository : IRepository<ConsignerLevel>
    {
    }

    internal class ConsignerLevelRepository : RepositoryBase<ConsignerLevel>, IConsignerLevelRepository
    {
        public ConsignerLevelRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}