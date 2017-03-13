namespace Layer.Domain.Model
{
    public interface IUnitOfWorkFactory
    {
        IUnitOfWork Create();
    }
}
