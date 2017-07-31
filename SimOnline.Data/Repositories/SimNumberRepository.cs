using System;
using System.Collections.Generic;
using System.Linq;
using SimOnline.Data.Infrastructure;
using SimOnline.Model.Models;

namespace SimOnline.Data.Repositories
{
    public interface ISimNumberRepository : IRepository<SimNumber>
    {
        IEnumerable<SimNumber> SearchSimNumber(string keyword, int consignerId, int networkId, decimal minPrice, decimal maxPrice, string[] includes = null);
    }

    public class SimNumberRepository : RepositoryBase<SimNumber>, ISimNumberRepository
    {
        public SimNumberRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public IEnumerable<SimNumber> SearchSimNumber(string keyword, int consignerId, int networkId, decimal minPrice, decimal maxPrice, string[] includes = null)
        {
            IEnumerable<SimNumber> listSim = this.DbContext.SimNumbers;

            if (keyword != null && keyword.IndexOf("*") < 0)
            {
                listSim = listSim.Where(x => x.SimID.Contains(keyword));
            }
            if (keyword != null && keyword.IndexOf("*") >= 0)
            {
                string[] key  = keyword.Split('*');
                listSim = listSim.Where(x => x.SimID.StartsWith((key[0]).Replace("_0", ""))
                && x.SimID.EndsWith(key[1]));
            }
            if (consignerId != 0)
            {
                listSim = listSim.Where(x=>x.ConsignerID==consignerId);
            }
            if (networkId != 0)
            {
                listSim = listSim.Where(x => x.NetWorkID == networkId);
            }
            if (minPrice != 0)
            {
                listSim = listSim.Where(x => x.Price >= minPrice);
            }
            if (maxPrice != 0)
            {
                listSim = listSim.Where(x => x.Price <= maxPrice);
            }
            return listSim;
        }
    }
}