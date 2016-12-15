using PinoyCode.Data.Infrastructure;


namespace PinoyCode.Data.Infrustracture
{
    public interface IBusinessObject
    {
        IDbContext Context { get; }
        IUnitOfWork UnitOfWork { get; }
    }
}
