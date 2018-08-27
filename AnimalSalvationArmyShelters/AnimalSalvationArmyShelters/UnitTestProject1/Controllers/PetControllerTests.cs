using AnimalSalvationArmy.DataAccessLayer;
using AnimalSalvationArmy.DataAccessLayer.DataHelpers;
using AnimalSalvationArmy.Services.AnimalShelterServices;
using AnimalSalvationArmy.Services.DataTransferObjects;
using AnimalSalvationArmy.Services.Entities;
using AnimalSalvationArmy.Services.PetService;
using AnimalSalvationArmyShelters.Controllers;
using AnimalSalvationArmyShelters.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AnimalSalvationArmy.UnitTests.Controllers
{
    [TestClass]
    public class PetControllerTests
    {
        private AnimalShelterApplicationDataStore _dataStore;

        [TestInitialize]
        public void TestInitialize()
        {
            _dataStore = new AnimalShelterApplicationDataStore(new UniqueIdentityGenerator());
        }

        private PetController CreatePetController()
        {
            var animalService = new AnimalShelterServices(_dataStore);
            var petService = new PetService(_dataStore);
            return new PetController(petService,animalService);
        }  

        [TestMethod]
        public void Get_EmptyList_NotFound()
        {
            // Arrange
            var unitUnderTest = CreatePetController();
            int id = 342;

            // Act
            var result = unitUnderTest.Get(
                id);

            // Assert
            Assert.IsInstanceOfType(result, typeof(Microsoft.AspNetCore.Mvc.NotFoundObjectResult));
        }
        [TestMethod]
        public void Get_PetExists_OkResult()
        {
            // Arrange
            var unitUnderTest = CreatePetController();
            _dataStore.Pets = new List<PetEntity>();
            _dataStore.Pets.Add(new PetEntity() {
                Id =342,
                MedicalCondition ="healthy",
                Name="goofy",
                Race = "german shepard",
                ShelterId= 1
            });
            int id = 342;

            // Act
            var result = unitUnderTest.Get(
                id);

            // Assert
            Assert.IsInstanceOfType(result, typeof(Microsoft.AspNetCore.Mvc.OkObjectResult));
        }
        [TestMethod]
        public void Get_PetExists_CorrectPetRetuned()
        {
            // Arrange
            var unitUnderTest = CreatePetController();
            _dataStore.Pets = new List<PetEntity>();
            var myPet = new PetEntity()
            {
                Id = 342,
                MedicalCondition = "healthy",
                Name = "goofy",
                Race = "german shepard",
                ShelterId = 1
            };
            _dataStore.Pets.Add(myPet);
            var anotherPet = new PetEntity()
            {
                Id = 344,
                MedicalCondition = "healthy",
                Name = "dexter",
                Race = "french bulldog",
                ShelterId = 1
            };
            int id = 342;

            // Act
            var result = (Microsoft.AspNetCore.Mvc.OkObjectResult)unitUnderTest.Get(
                id);
            var petResult = (PetDto)result.Value;
            // Assert
            Assert.AreEqual(myPet.Id, petResult.Id);
            Assert.AreEqual(myPet.MedicalCondition, petResult.MedicalCondition);
            Assert.AreEqual(myPet.Name, petResult.Name);
            Assert.AreEqual(myPet.Race, petResult.Race);
            Assert.AreEqual(myPet.ShelterId, petResult.ShelterId);
        }
        [TestMethod]
        public void Get_PetsExists_PetNotFound()
        {
            // Arrange
            var unitUnderTest = CreatePetController();
            _dataStore.Pets = new List<PetEntity>();
            var myPet = new PetEntity()
            {
                Id = 342,
                MedicalCondition = "healthy",
                Name = "goofy",
                Race = "german shepard",
                ShelterId = 1
            };
            _dataStore.Pets.Add(myPet);
            var anotherPet = new PetEntity()
            {
                Id = 344,
                MedicalCondition = "healthy",
                Name = "dexter",
                Race = "french bulldog",
                ShelterId = 1
            };
            int id = 500;

            // Act
            var result = unitUnderTest.Get(
                id);

            // Assert
            Assert.IsInstanceOfType(result, typeof(Microsoft.AspNetCore.Mvc.NotFoundObjectResult));

        }

        [TestMethod]
        public void Post_AddPet_200ok()
        {
            // Arrange
            var unitUnderTest = CreatePetController();
            _dataStore.Pets = new List<PetEntity>();
            var value = new Pet()
            {
                Id = 342,
                MedicalCondition = "healthy",
                Name = "goofy",
                Race = "german shepard",
                ShelterId = 1
            };
            // Act
            var result = unitUnderTest.Post(
                value);

            // Assert
            Assert.IsInstanceOfType(result, typeof(Microsoft.AspNetCore.Mvc.OkObjectResult));
        }
        [TestMethod]
        public void Post_AddPet_AddSuccesfull()
        {
            // Arrange
            var unitUnderTest = CreatePetController();
            _dataStore.Pets = new List<PetEntity>();
            var value = new Pet()
            {
                Id = 342,
                MedicalCondition = "healthy",
                Name = "goofy",
                Race = "german shepard",
                ShelterId = 1
            };
            // Act
            var result = unitUnderTest.Post(
                value);

            // Assert
            Assert.IsInstanceOfType(result, typeof(Microsoft.AspNetCore.Mvc.OkObjectResult));
            Assert.IsTrue(_dataStore.Pets.Any(x => x.Id == value.Id));
        }

        [TestMethod]
        public void Delete_RemovePet_removeSuccesfull()
        {
            // Arrange
            var unitUnderTest = CreatePetController();
            _dataStore.Pets = new List<PetEntity>();
            var petTodelete = new PetEntity()
            {
                Id = 342,
                MedicalCondition = "healthy",
                Name = "goofy",
                Race = "german shepard",
                ShelterId = 1
            };
            _dataStore.Pets.Add(petTodelete);
            // Act
            var result = unitUnderTest.Delete(
                petTodelete.Id);

            // Assert
            Assert.IsInstanceOfType(result, typeof(Microsoft.AspNetCore.Mvc.OkObjectResult));
            Assert.IsFalse(_dataStore.Pets.Any(x => x.Id == petTodelete.Id));
        }

        //[TestMethod]
        //public void List_StateUnderTest_ExpectedBehavior()
        //{
        //    // Arrange
        //    var unitUnderTest = CreatePetController();

        //    // Act
        //    var result = unitUnderTest.List();

        //    // Assert
        //    Assert.Fail();
        //}

        //[TestMethod]
        //public void CustomerList_StateUnderTest_ExpectedBehavior()
        //{
        //    // Arrange
        //    var unitUnderTest = CreatePetController();
        //    string shelterName = TODO;
        //    bool petAlreadyPendingAdoption = TODO;

        //    // Act
        //    var result = unitUnderTest.CustomerList(
        //        shelterName,
        //        petAlreadyPendingAdoption);

        //    // Assert
        //    Assert.Fail();
        //}
    }
}
