using Layer.Data.RepositoryBase;
using Layer.Domain.Entity;
using Layer.Domain.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Layer.Data.Repository
{
    internal class StateRepository: IStateRepository
    {
        private readonly GenericRepository<State> _genericRepository;

        public StateRepository(GenericRepository<State> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        private NailViecAppContext Context { get { return _genericRepository.Context; } }

        public void Add(State item)
        {
            _genericRepository.Add(item);
        }

        public void Delete(long id)
        {
            _genericRepository.Remove(GetById(id));
        }

        public void Update(State item)
        {
            _genericRepository.Update(item);
        }

        public State GetById(long id)
        {
            return Context.States.FirstOrDefault(p => p.Id == id);
        }

        public List<State> GetAll()
        {
            return Context.States.ToList();
        }
    }
}
