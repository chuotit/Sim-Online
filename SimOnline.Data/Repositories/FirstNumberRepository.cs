using SimOnline.Data.Infrastructure;
using SimOnline.Model.Models;

namespace SimOnline.Data.Repositories
{
    public interface IFirstNumberRepository : IRepository<FirstNumber>
    {
    }

    public class FirstNumberRepository : RepositoryBase<FirstNumber>, IFirstNumberRepository
    {
        public FirstNumberRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}