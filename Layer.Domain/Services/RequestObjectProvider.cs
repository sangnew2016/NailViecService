using System.Web;
using Layer.Domain.Model;

namespace Layer.Domain.Services
{
    public class RequestObjectProvider<T> : IRequestObjectProvider<T> where T : class
    {
        public T Get()
        {
            return HttpContext.Current.Items[this] as T;
        }

        public void Set(T obj)
        {
            HttpContext.Current.Items[this] = obj;
        }
    }
}
