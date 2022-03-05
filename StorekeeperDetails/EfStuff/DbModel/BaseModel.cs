namespace StorekeeperDetails.EfStuff.DbModel
{
    public abstract class BaseModel
    {
        public long Id { get; set; }
        public bool isActive { get; set; }
    }
}
