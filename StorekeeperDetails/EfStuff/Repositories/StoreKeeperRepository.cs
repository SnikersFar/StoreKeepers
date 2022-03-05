using StorekeeperDetails.EfStuff.DbModel;

namespace StorekeeperDetails.EfStuff.Repositories
{
    public class StoreKeeperRepository : BaseRepository<StoreKeeper>
    {
        public StoreKeeperRepository(WebContext webContext) : base(webContext)
        {
        }
    }
}
