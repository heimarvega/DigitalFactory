using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace Model
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
