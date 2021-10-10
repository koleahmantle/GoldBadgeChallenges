using Greeting.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Greeting.UnitTest
{
    [TestClass]
    public class GreetingUnitTest
    {
        private readonly GreetingRepo _repo = new GreetingRepo();
        [TestInitialize]
        public void Arrange()
        {
            Customer person = new Customer("Karen", "Smith", "Potential", 1);
            _repo.AddPersonContent(person);
        }
        [TestMethod]
        public void AddPersonContent_PersonIsNull_ReturnFalse()
        {
            Customer person = null;
            GreetingRepo greetingrepo = new GreetingRepo();
            //Act
            bool result = greetingrepo.AddPersonContent(person);
            //Assert
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void AddPersonContent_PersonIsNotNull_ReturnTrue()
        {
            Customer person = new Customer("Karen", "Smith", "Potential", 1);
            GreetingRepo greetingrepo = new GreetingRepo();
            //Act
            bool result = greetingrepo.AddPersonContent(person);
            //Assert
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void GetPersonContentById_PersonExists_ReturnCandle()
        {
            //Arrange
            int id = 1;
            //Act
            Customer result = _repo.GetPersonContentById(id);
            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Id, id);
        }
        [TestMethod]
        public void GetPersonContentById_PersonDoesnotExist_ReturnNull()
        {
            int id = 52;
            //Act
            Customer result = _repo.GetPersonContentById(id);
            //Assert
            Assert.IsNull(result);
        }
        [TestMethod]
        public void DeletePerson_CandleDoesNotExist_ReturnFalse()
        {
            int id = 59;
            //Act
            bool result = _repo.DeletePerson(id);
            //Assert
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void DeletePerson_CandleDoesExist_ReturnTrue()
        {
            int id = 1;
            //Act
            bool result = _repo.DeletePerson(id);
            //Assert
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void UpdatePerson_PersonDoesExist_RetrunTrue()
        {
            //Arrange
            int id = 1;
            Customer updatedPerson = new Customer("Sean", "Kodak", "Potential", 2);
            //Act
            bool result = _repo.UpdatePerson(id, updatedPerson);
            //Assert
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void UpdatePerson_PersonDoesExist_PropertiesUpdated()
        {
            //Arrange
            int id = 1;
            Customer updatedPerson = new Customer("Jim", "Jones", "Existing", 3);
            //Act
            _repo.UpdatePerson(id, updatedPerson);
            Customer person = _repo.GetPersonContentById(id);
            //Assert
            Assert.AreEqual("Charlie", person.FirstName);
            Assert.AreEqual("Hernandez", person.LastName);
            Assert.AreEqual("Existing", person.CustomerType);
            Assert.AreEqual(15, person.Id);
        }
        [TestMethod]
        public void UpdatePerson_PersonDoesNotExist_RetrunFalse()
        {
            int id = 123;
            Customer updatedPerson = new Customer("Sean", "Jackson", "Potential", 45);
            //Act
            bool result = _repo.UpdatePerson(id, updatedPerson);
            //Assert
            Assert.IsFalse(result);
        }
    }
}
