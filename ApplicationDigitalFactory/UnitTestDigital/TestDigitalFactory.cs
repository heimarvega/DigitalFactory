using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationDigitalFactory.Controllers;
using Entities;
using Microsoft.EntityFrameworkCore;
using Model;
using NUnit.Framework;
namespace UnitTestDigital
{
    [TestFixture]
    public class TestDigitalFactory
    {
        [OneTimeSetUp]
        public void RunBeforeAnyTests()
        {
            var options = new DbContextOptionsBuilder<DigitalFactoryMemoryContext>()
                .UseInMemoryDatabase(databaseName: "Add_peoples_to_database")
                .Options;
            using (DigitalFactoryMemoryContext context = new DigitalFactoryMemoryContext(options))
            {
                Initialize(context);
            }
        }
        [OneTimeTearDown]
        public void RunAfterAllTests()
        {
            var options = new DbContextOptionsBuilder<DigitalFactoryMemoryContext>()
                .UseInMemoryDatabase(databaseName: "Add_peoples_to_database")
                .Options;
            using (DigitalFactoryMemoryContext context = new DigitalFactoryMemoryContext(options))
            {
                PeopleModel modelo = new PeopleModel(context);
                foreach (var item in modelo.GetAll())
                {
                    modelo.Remove(item.Id);
                }
            }
        }
        [Test]
        public void GetInFacade_ByNameAndRegionExist_TotalAmount()
        {
            //Arange
            decimal totalAmountExpected = 75000;
            string name = "Jhon Smith";
            string region = "Ontario";
             var options = new DbContextOptionsBuilder<DigitalFactoryMemoryContext>()
                .UseInMemoryDatabase(databaseName: "Add_peoples_to_database")
                .Options;
            using (DigitalFactoryMemoryContext context = new DigitalFactoryMemoryContext(options))
            {
                PeopleModel modelo = new PeopleModel(context);
                Facade.FacadePeople sut = new Facade.FacadePeople(modelo);
                //Act
                decimal totalAmount = sut.GetAmountByNameAndRegion(name,region);
                //Assert
                Assert.AreEqual(totalAmount, totalAmountExpected);
            }
        }
        [Test]
        public void GetInFacade_AllPeople_CountTotalValid()
        {
            //Arange
            int totalCount = 6;
            var options = new DbContextOptionsBuilder<DigitalFactoryMemoryContext>()
                .UseInMemoryDatabase(databaseName: "Add_peoples_to_database")
                .Options;
            using (DigitalFactoryMemoryContext context = new DigitalFactoryMemoryContext(options))
            {
                PeopleModel modelo = new PeopleModel(context);
                Facade.FacadePeople sut = new Facade.FacadePeople(modelo);
                //Act
                var listPeople = sut.GetAll();
                //Assert
                Assert.AreEqual(totalCount, listPeople.Count());
            }
        }
        [Test]
        public void GetInController_ByNameAndRegionExist_TotalAmount()
        {
            //Arange
            decimal totalAmountExpected = 75000;
            string name = "Jhon Smith";
            string region = "Ontario";
            var options = new DbContextOptionsBuilder<DigitalFactoryMemoryContext>()
               .UseInMemoryDatabase(databaseName: "Add_peoples_to_database")
               .Options;
            using (DigitalFactoryMemoryContext context = new DigitalFactoryMemoryContext(options))
            {
                PeopleModel modelo = new PeopleModel(context);
                PeopleController sut = new PeopleController(modelo);
                //Act
                var totalAmount = sut.Get(name, region);
                //Assert
                Assert.AreEqual(decimal.Parse(totalAmount.Value.ToString()), totalAmountExpected);
            }
        }
        public void Initialize(DigitalFactoryMemoryContext contextDb)
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
                Amount = 35000
            });
            listPeoples.Add(new People
            {
                Id = 3,
                Name = "Jhon Smith",
                Region = "Ontario",
                Amount = 25000
            });
            listPeoples.Add(new People
            {
                Id = 4,
                Name = "Jhon Smith",
                Region = "Ontario",
                Amount = 10000
            });
            listPeoples.Add(new People
            {
                Id = 5,
                Name = "Jhon Smith",
                Region = "Ontario",
                Amount = 5000
            });
            listPeoples.Add(new People
            {
                Id = 6,
                Name = "Ben Chang",
                Region = "BC",
                Amount = 240
            });
            contextDb.Peoples.AddRange(listPeoples);
            contextDb.SaveChanges();
        }
    }
}
