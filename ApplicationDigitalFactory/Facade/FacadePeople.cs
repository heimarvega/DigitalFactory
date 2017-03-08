using System.Collections.Generic;
using System.Linq;
using DataAccess;
using Entities;

namespace Facade
{
    /// <summary>
    /// Facade for People
    /// </summary>
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
        /// <summary>
        /// Find Amount by Name and Region in Peoples
        /// </summary>
        /// <param name="name">Name of people</param>
        /// <param name="region">Region of people</param>
        /// <returns></returns>
        public decimal GetAmountByNameAndRegion(string name, string region)
        {
            var result = _repository.GetAll().Where(i => i.Name.Equals(name) && i.Region.Equals(region)).Sum(item => item.Amount);
            return result;
        }
        /// <summary>
        /// Add People
        /// </summary>
        /// <param name="people">People to Add</param>
        public void Add(People people)
        {
            _repository.Add(people);
        }
        /// <summary>
        /// Delete people
        /// </summary>
        /// <param name="people">People to delete</param>
        public void Delete(People people)
        {
            _repository.Remove(people.Id);
        }
    }
}
