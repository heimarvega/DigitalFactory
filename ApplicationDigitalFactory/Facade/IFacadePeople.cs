using System.Collections.Generic;
using Entities;

namespace Facade
{
    /// <summary>
    /// Interface to People
    /// </summary>
    public interface IFacadePeople
    {
        IEnumerable<People> GetAll();
        void Initialize();
        decimal GetAmountByNameAndRegion(string name, string region);
        void Delete(People people);
        void Add(People people);
    }
}