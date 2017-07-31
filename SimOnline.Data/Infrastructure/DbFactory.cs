namespace SimOnline.Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        private SimOnlineDbContext dbContext;

        public SimOnlineDbContext Init()
        {
            return dbContext ?? (dbContext = new SimOnlineDbContext());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}