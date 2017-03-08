using Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class DigitalFactoryMemoryContext: DbContext
    {
        public DigitalFactoryMemoryContext(DbContextOptions<DigitalFactoryMemoryContext> options)
            : base(options)
        {
        }

        public DbSet<People> Peoples { get; set; }
    }
}
