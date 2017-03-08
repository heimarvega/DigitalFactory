using System;
using System.Collections.Generic;
using System.Linq;
using Entities;

namespace DataAccess
{
    /// <summary>
    /// Model to Entity People
    /// </summary>
    public class PeopleModel : IRepository<People>
    {
        private readonly DigitalFactoryMemoryContext _contextDb;
        public PeopleModel(DigitalFactoryMemoryContext context)
        {
            _contextDb = context;
        }

        public void Add(People item)
        {
            _contextDb.Peoples.Add(item);
            _contextDb.SaveChanges();
        }

        public People Find(int id)
        {
            return _contextDb.Peoples.FirstOrDefault(t => t.Id == id);
        }

        public IEnumerable<People> GetAll()
        {
            return _contextDb.Peoples;
        }

        public People GetById()
        {
            throw new NotImplementedException();
        }

        public People GetByNameAndRegion(string name, string region)
        {
            return _contextDb.Peoples.Where(item => item.Name.Equals(name) && item.Region.Equals(region)).FirstOrDefault();
        }

        public void Remove(int id)
        {
            var entity = _contextDb.Peoples.First(t => t.Id == id);
            _contextDb.Peoples.Remove(entity);
            _contextDb.SaveChanges();
        }

        public void Update(People item)
        {
            _contextDb.Peoples.Update(item);
            _contextDb.SaveChanges();
        }

        public void Initialize()
        {
            IList<People> listPeoples = new List<People>();
            listPeoples.Add(new People
            {
                Id = 1,
                Name = "Luke",
                Region = "Colombia",
                Amount = 24000
            });
            listPeoples.Add(new People
            {
                Id = 2,
                Name = "Jhon Smith",
                Region = "Ontario",
                Amount = 27000
            });
            listPeoples.Add(new People
            {
                Id = 3,
                Name = "Jhon Smith",
                Region = "Ontario",
                Amount = 27000
            });
            listPeoples.Add(new People
            {
                Id = 4,
                Name = "Jhon Smith",
                Region = "Ontario",
                Amount = 27000
            });
            listPeoples.Add(new People
            {
                Id = 5,
                Name = "Jhon Smith",
                Region = "Ontario",
                Amount = 27000
            });
            listPeoples.Add(new People
            {
                Id = 6,
                Name = "Ben Chang",
                Region = "BC",
                Amount = 240
            });
            _contextDb.Peoples.AddRange(listPeoples);
            _contextDb.SaveChanges();
        }
    }
}
