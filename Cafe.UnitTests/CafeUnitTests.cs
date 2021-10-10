using Cafe.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Cafe.UnitTests
{
    [TestClass]
    public class CafeUnitTests
    {
        private readonly MenuRepository _repo = new MenuRepository();
        [TestInitialize]
        public void Arrange()
        {
            MenuContent menu = new MenuContent(1, "Roasted Chicken", "oven roasted chicken with vegetables", "chicken, olive oil, garlic, onion, green peppers", 15.99);
            _repo.AddMenuContent(menu);
        }
        [TestMethod]
        public void AddMenuContent_MenuIsNull_ReturnFalse()
        {
            //Arrange
            MenuContent menu = null;
            MenuRepository menuRepository = new MenuRepository();
            //Act
            bool result = menuRepository.AddMenuContent(menu);
            //Assert
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void AddMenuContent_MenuIsNotNull_ReturnTrue()
        {
            //Arrange
            MenuContent menu = new MenuContent(15, "Roasted Chicken", "oven roasted chicken with vegetables", "chicken, olive oil, garlic, onion, green peppers", 15.99);
            MenuRepository menuRepository = new MenuRepository();
            //Act
            bool result = menuRepository.AddMenuContent(menu);
            //Assert
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void DeleteMenuContent_CandleDoesNotExist_ReturnFalse()
        {
            //Arrange
            int id = 123;
            //Act
            bool result = _repo.DeleteMenuContent(id);
            //Assert
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void DeleteMenuContent_CandleDoesExist_ReturnTrue()
        {
            //Arrange
            int id = 1;
            //Act
            bool result = _repo.DeleteMenuContent(id);
            //Assert
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void GetMenuContentById_CandleDoesExist_ReturnCandle()
        {
            //Assert
            MenuContent menu = new MenuContent(15, "Roasted Chicken", "oven roasted chicken with vegetables", "chicken, olive oil, garlic, onion, green peppers", 15.99);
            MenuRepository menuRepository = new MenuRepository();
            menuRepository.AddMenuContent(menu);
            int id = 123;
            //Act
            MenuContent result = menuRepository.GetMenuContentById(id);
            //Assert
            Assert.IsNull(menu);
        }
        [TestMethod]
        public void GetMenuContentById_CandleDoesNotExist_ReturnNull()
        {
            //Assert
            MenuContent menu = new MenuContent(15, "Roasted Chicken", "oven roasted chicken with vegetables", "chicken, olive oil, garlic, onion, green peppers", 15.99);
            MenuRepository menuRepository = new MenuRepository();
            menuRepository.AddMenuContent(menu);
            int id = 1;
            //Act
            MenuContent result = menuRepository.GetMenuContentById(id);
            //Assert
            Assert.IsNotNull(menu);
            Assert.AreEqual(result, id);
        }
    }
        
    
}
