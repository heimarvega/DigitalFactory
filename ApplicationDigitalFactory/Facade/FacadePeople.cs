using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities;
using Model;
using Remotion.Linq.Utilities;

namespace Facade
{
    public class FacadePeople : IFacadePeople
    {
        private readonly IRepository<People> _repository;
        public FacadePeople(IRepository<People> repository)
        {
            _repository = repository;
        }
        public IEnumerable<People> GetAll()
        {
            return _repository.GetAll();
        }

        public void Initialize()
        {
            _repository.Initialize();
        }

        public decimal GetAmountByNameAndRegion(string name, string region)
        {
            var result = _repository.GetAll().Where(i => i.Name.Equals(name) && i.Region.Equals(region)).Sum(item => item.Amount);
            return result;
        }

        public void Add(People people)
        {
            _repository.Add(people);
        }

        public void Delete(People people)
        {
            _repository.Remove(people.Id);
        }
    }
}
