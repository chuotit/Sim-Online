using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimOnline.Data.Infrastructure;
using SimOnline.Model.Models;

namespace SimOnline.Data.Repositories
{
    public interface IAppUserGroupRepository : IRepository<AppUserGroup>
    {

    }
    public class AppUserGroupRepository : RepositoryBase<AppUserGroup>, IAppUserGroupRepository
    {
        public AppUserGroupRepository(IDbFactory dbFactory) : base(dbFactory)
        {

        }
    }
}
