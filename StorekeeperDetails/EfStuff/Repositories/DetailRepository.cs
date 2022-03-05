using StorekeeperDetails.EfStuff.DbModel;

namespace StorekeeperDetails.EfStuff.Repositories
{
    public class DetailRepository : BaseRepository<Detail>
    {
        public DetailRepository(WebContext webContext) : base(webContext)
        {
        }
    }
}
