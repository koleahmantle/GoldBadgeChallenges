using Claims.Repo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Claims.UnitTest
{
    [TestClass]
    public class ClaimUnitTests
    {
        private readonly ClaimRepo _repo = new ClaimRepo();
        [TestInitialize]
        public void Arrange()
        {
            Claim claim = new Claim(1, "car", "car crash on I95", 569.12, "12/25/2019", "12/30/2019", true);
            _repo.AddClaimsToList(claim);
        }
        [TestMethod]
        public void AddClaimsToList_ClaimIsNotNull_ReturnTrue()
        {
            //Arrange 
            Claim claim = null;
            ClaimRepo claimRepo = new ClaimRepo();
            //Act
            bool result = claimRepo.AddClaimsToList(claim);
            //Assert
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void AddClaimsToList_ClaimIsNull_ReturnFalse()
        {
            //Arrange 
            Claim claim = new Claim();
            ClaimRepo claimRepo = new ClaimRepo();
            //Act
            bool result = claimRepo.AddClaimsToList(claim);
            //Assert
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void GetClaimByID_ClaimDoesNotExist_ReturnNull()
        {
            //Arrange 
            Claim claim = new Claim();
            ClaimRepo claimRepo = new ClaimRepo();
            claimRepo.AddClaimsToList(claim);
            int id = 1489;
            //Act
            Claim result = claimRepo.GetClaimByID(id);
            //Assert
            Assert.IsNull(result);
        }
        [TestMethod]
        public void GetClaimByID_ClaimDoesExist_ReturnCandle()
        {
            //Arrange 
            int id = 1;

            //Act
            Claim result = _repo.GetClaimByID(id);
            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Id, id);
        }
    }
}
