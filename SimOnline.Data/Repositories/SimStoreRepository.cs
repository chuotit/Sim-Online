using System;
using System.Collections.Generic;
using System.Linq;
using SimOnline.Data.Infrastructure;
using SimOnline.Model.Models;

namespace SimOnline.Data.Repositories
{
    public interface ISimStoreRepository : IRepository<SimStore>
    {
        int CheckSim(string simName, string price, string agentId);
    }

    public class SimStoreRepository : RepositoryBase<SimStore>, ISimStoreRepository
    {
        public SimStoreRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public int CheckSim(string simName, string price, string agentId)
        {
            int simErrorCode = 1;
            int priceErrorcode = 1;
            int SimTem;
            decimal priTem;
            string simN = simName.Trim().Replace("   ", " ").Replace("  ", " ").Replace(" ", ".").Replace("-", ".");
            string pri = price.Trim().Replace("K", "k").Replace("k", "000").Replace(",", ".").Replace(".", "");

            if (!simN.StartsWith("0") || int.TryParse(simN, out SimTem))
            {
                simErrorCode = 2;
            }
            if (simN.IndexOf(".") < 0)
            {
                simErrorCode = 3;
            }
            if ((simN.StartsWith("01") && simN.Replace(".", "").Length > 11)
                || (simN.StartsWith("09") && simN.Replace(".", "").Length > 10))
            {
                simErrorCode = 4;
            }

            if(pri.Length<5 || decimal.TryParse(simN, out priTem))
            {
                priceErrorcode = 2;
            }

            return Int32.Parse(simErrorCode.ToString() + priceErrorcode.ToString());
        }
    }
}