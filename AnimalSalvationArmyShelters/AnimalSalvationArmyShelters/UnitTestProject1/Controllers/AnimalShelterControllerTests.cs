using AnimalSalvationArmy.Services.AnimalShelterServices;
using AnimalSalvationArmyShelters.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace AnimalSalvationArmySheltersUnitTest.Controllers
{
    [TestClass]
    public class AnimalShelterControllerTests
    {
        private MockRepository mockRepository;



        [TestInitialize]
        public void TestInitialize()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);


        }

        [TestCleanup]
        public void TestCleanup()
        {
            this.mockRepository.VerifyAll();
        }

        private AnimalShelterController CreateAnimalShelterController()
        {
            var mockService = new Mock<IAnimalShelterServices>();
            return new AnimalShelterController(mockService.Object);
        }



        [TestMethod]
        public void Post_CreateNewAnimalShelter_Return200()
        {
            // Arrange
            var animalShelterController = CreateAnimalShelterController();
            string shelterName = "sheltername1";

            // Act
            var result = animalShelterController.Post(
                shelterName);

            // Assert
            Assert.IsInstanceOfType(result, typeof(Microsoft.AspNetCore.Mvc.OkObjectResult));
        }

        //[TestMethod]
        //public void Delete_StateUnderTest_ExpectedBehavior()
        //{
        //    // Arrange
        //    var unitUnderTest = CreateAnimalShelterController();
        //    int uniqueIdentifierForPetSelter = 1;

        //    // Act
        //    var result = unitUnderTest.Delete(
        //        uniqueIdentifierForPetSelter);

        //    // Assert
        //    Assert.Fail();
        //}
    }
}
