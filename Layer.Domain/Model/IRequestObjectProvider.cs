namespace Layer.Domain.Model
{
    public interface IRequestObjectProvider<T>
    {
        T Get();
        void Set(T obj);
    }
}
