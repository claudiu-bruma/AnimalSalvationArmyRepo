using AnimalSalvationArmy.DataAccessLayer;
using AnimalSalvationArmy.DataAccessLayer.DataHelpers;
using AnimalSalvationArmy.Services.AnimalShelterServices;
using AnimalSalvationArmy.Services.Entities;
using AnimalSalvationArmyShelters.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AnimalSalvationArmySheltersUnitTest.Controllers
{
    [TestClass]
    public class AnimalShelterControllerTests
    {
        private AnimalShelterApplicationDataStore _dataStore;

        [TestInitialize]
        public void TestInitialize()
        {
            _dataStore = new AnimalShelterApplicationDataStore(new UniqueIdentityGenerator() );
        } 

        private AnimalShelterController CreateAnimalShelterController()
        {
            var service = new AnimalShelterServices(_dataStore);
            return new AnimalShelterController(service);
        }
        
        [TestMethod]
        public void Post_CreateNewAnimalShelter_Return200()
        {
            // Arrange
            var animalShelterController = CreateAnimalShelterController();
            string shelterName = "test shelter name";

            // Act
            var result = animalShelterController.Post(
                shelterName);

            // Assert
            Assert.IsInstanceOfType(result, typeof(Microsoft.AspNetCore.Mvc.OkObjectResult));
        }
        [TestMethod]
        public void Post_CreateNewAnimalShelter_EmptyShelterName_BadRequest()
        {
            // Arrange
            var animalShelterController = CreateAnimalShelterController();
            string shelterName = "";

            // Act
            var result = animalShelterController.Post(
                shelterName);

            // Assert
            Assert.IsInstanceOfType(result, typeof(Microsoft.AspNetCore.Mvc.BadRequestObjectResult));
        }
 
        [TestMethod]
        public void Post_CreateNewAnimalShelter_ExistingShelterName_Conflict()
        {
            var animalShelterController = CreateAnimalShelterController();
            string shelterName = "test shelter name";
            _dataStore.AnimalShelters = new List<AnimalShelterEntity>();
            _dataStore.AnimalShelters.Add(new AnimalShelterEntity()
            {
                Id = 1,
                Name = shelterName //this should be a conflict
            });
            _dataStore.AnimalShelters.Add(new AnimalShelterEntity()
            {
                Id = 2,
                Name = "shelter name 2"
            });
            // Act
            var result = animalShelterController.Post(
                shelterName);


            // Assert

            Assert.IsInstanceOfType(result, typeof(Microsoft.AspNetCore.Mvc.ConflictObjectResult));
        }
        [TestMethod]
        public void Post_CreateNewAnimalShelter_AddItemToListWithExistingShelters()
        {
            // Arrange
            var animalShelterController = CreateAnimalShelterController();
            string shelterName = "test shelter name";
            _dataStore.AnimalShelters = new List<AnimalShelterEntity>();
            _dataStore.AnimalShelters.Add(new AnimalShelterEntity() {
                Id =1,
                Name = "shelter name 1"
            });
            _dataStore.AnimalShelters.Add(new AnimalShelterEntity()
            {
                Id = 2,
                Name = "shelter name 2"
            });
            // Act
            var result = (Microsoft.AspNetCore.Mvc.OkObjectResult)animalShelterController.Post(
                shelterName);


            // Assert

            Assert.AreEqual(3,result.Value );
        }
        [TestMethod]
        public void Post_CreateNewAnimalShelter_AddItemToListWithExistingShelters_NoColision()
        {
            // Arrange
            var animalShelterController = CreateAnimalShelterController();
            string shelterName = "test shelter name";
            _dataStore.AnimalShelters = new List<AnimalShelterEntity>();
            _dataStore.AnimalShelters.Add(new AnimalShelterEntity()
            {
                Id = 105,
                Name = "shelter name 105"
            });
            _dataStore.AnimalShelters.Add(new AnimalShelterEntity()
            {
                Id = 188,
                Name = "shelter name 189"
            });
            // Act
            var result = (Microsoft.AspNetCore.Mvc.OkObjectResult)animalShelterController.Post(
                shelterName);


            // Assert

            Assert.AreEqual(189,result.Value  );
        }
        [TestMethod]
        public void Delete_ItemExists_ItemDeleted()
        {
            // Arrange
            var animalShelterController = CreateAnimalShelterController();
             
            _dataStore.AnimalShelters = new List<AnimalShelterEntity>();
            _dataStore.AnimalShelters.Add(new AnimalShelterEntity()
            {
                Id = 105,
                Name = "shelter name 105"
            });
            _dataStore.AnimalShelters.Add(new AnimalShelterEntity()
            {
                Id = 188,
                Name = "shelter name 189"
            });
            // Act
            var result = (Microsoft.AspNetCore.Mvc.OkResult)animalShelterController.Delete(
                105);


            // Assert

            Assert.IsFalse(_dataStore.AnimalShelters.Any(x=>x.Id==105));
            Assert.AreEqual(1,_dataStore.AnimalShelters.Count());
        }
        [TestMethod]
        public void Delete_ItemNotFound_NotFound()
        {
            // Arrange
            var animalShelterController = CreateAnimalShelterController();

            _dataStore.AnimalShelters = new List<AnimalShelterEntity>();
            _dataStore.AnimalShelters.Add(new AnimalShelterEntity()
            {
                Id = 105,
                Name = "shelter name 105"
            });
            _dataStore.AnimalShelters.Add(new AnimalShelterEntity()
            {
                Id = 188,
                Name = "shelter name 189"
            });
            // Act
            var result = animalShelterController.Delete(
                999);


            // Assert

            Assert.IsInstanceOfType(result, typeof(Microsoft.AspNetCore.Mvc.NotFoundObjectResult));
        }
    }
}
