using Layer.Domain.Entity;
using System.Collections.Generic;

namespace Layer.Domain.Repositories
{
    public interface IStateRepository
    {
        void Add(State item);
        void Update(State item);
        void Delete(long id);
        State GetById(long id);
        List<State> GetAll();

    }
}
