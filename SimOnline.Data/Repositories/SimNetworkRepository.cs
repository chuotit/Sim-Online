using System.Collections.Generic;
using System.Linq;
using SimOnline.Data.Infrastructure;
using SimOnline.Model.Models;

namespace SimOnline.Data.Repositories
{
    public interface ISimNetworkRepository : IRepository<SimNetwork>
    {
        IEnumerable<SimNetwork> GetByAlias(string alias);
    }

    public class SimNetworkRepository : RepositoryBase<SimNetwork>, ISimNetworkRepository
    {
        public SimNetworkRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public IEnumerable<SimNetwork> GetByAlias(string alias)
        {
            return this.DbContext.SimNetworks.Where(x => x.Alias == alias);
        }
    }
}