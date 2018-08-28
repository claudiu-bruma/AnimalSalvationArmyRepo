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
            _dataStore.Pets.Add(GetGoofyPetEntity());
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
            var myPet = GetGoofyPetEntity();
            _dataStore.Pets.Add(myPet);
            var anotherPet = GetDexterPetEntity();
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
            var myPet = GetGoofyPetEntity();
            _dataStore.Pets.Add(myPet);
            var anotherPet = GetDexterPetEntity();
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
            var value = GetGoofyPet();
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
            var value = GetGoofyPet();
            // Act
            var result = unitUnderTest.Post(
                value);

            // Assert
            Assert.IsInstanceOfType(result, typeof(Microsoft.AspNetCore.Mvc.OkObjectResult));
            Assert.IsTrue(_dataStore.Pets.Any(x => x.Name == value.Name));
        }
   

        [TestMethod]
        public void Post_AddPet_ShelterMissing()
        {
            // Arrange
            var unitUnderTest = CreatePetController();
            _dataStore.Pets = new List<PetEntity>();
            var value = GetGoofyWithNoShelter();
            // Act
            var result = unitUnderTest.Post(
                value);

            // Assert
            Assert.IsInstanceOfType(result, typeof(Microsoft.AspNetCore.Mvc.NotFoundObjectResult));
            Assert.IsFalse(_dataStore.Pets.Any(x => x.Name == value.Name));
        }


        [TestMethod]
        public void Post_AddPet_NameMissing()
        {
            // Arrange
            var unitUnderTest = CreatePetController();
            _dataStore.Pets = new List<PetEntity>();
            var value = GetNamelessPet();
            // Act
            var result = unitUnderTest.Post(
                value);

            // Assert
            Assert.IsInstanceOfType(result, typeof(Microsoft.AspNetCore.Mvc.NotFoundObjectResult));
            Assert.IsFalse(_dataStore.Pets.Any(x => x.Race == value.Race));
        }



        [TestMethod]
        public void Delete_RemovePet_removeSuccesfull()
        {
            // Arrange
            var unitUnderTest = CreatePetController();
            _dataStore.Pets = new List<PetEntity>();
            var petTodelete = GetGoofyPetEntity(); ;
            _dataStore.Pets.Add(petTodelete);
            // Act
            var result = unitUnderTest.Delete(
                petTodelete.Id);

            // Assert
            Assert.IsInstanceOfType(result, typeof(Microsoft.AspNetCore.Mvc.OkObjectResult));
            Assert.IsFalse(_dataStore.Pets.Any(x => x.Id == petTodelete.Id));
        }
        [TestMethod]
        public void Delete_RemovePet_DeletePetNotInList()
        {
            // Arrange
            var unitUnderTest = CreatePetController();
            _dataStore.Pets = new List<PetEntity>();
            var petTodelete = GetGoofyPetEntity(); ;
            _dataStore.Pets.Add(petTodelete);
            // Act
            var result = unitUnderTest.Delete(
                351);

            // Assert
            Assert.IsInstanceOfType(result, typeof(Microsoft.AspNetCore.Mvc.NotFoundObjectResult));
          
        }

        [TestMethod]
        public void List_ListContainsPets_Returns200ok()
        {
            // Arrange
            var unitUnderTest = CreatePetController();
            _dataStore.Pets = new List<PetEntity>();
            _dataStore.Pets.Add(GetGoofyPetEntity());
            // Act
            var result = unitUnderTest.List();

            // Assert
            Assert.IsInstanceOfType(result, typeof(Microsoft.AspNetCore.Mvc.OkObjectResult));
            
           
        }
        [TestMethod]
        public void List_ListContainsPet_ResultContainsPet()
        {
            // Arrange
            var unitUnderTest = CreatePetController();
            _dataStore.Pets = new List<PetEntity>();
            var existingPet = GetGoofyPetEntity();
            _dataStore.Pets.Add(existingPet);
            // Act
            var result = (Microsoft.AspNetCore.Mvc.OkObjectResult)unitUnderTest.List();
            var returnedPetList = (List<Pet>)result.Value;

            // Assert 
            Assert.IsNotNull(returnedPetList);
            Assert.AreEqual(1, returnedPetList.Count());
            Assert.IsTrue(returnedPetList.Any(x => x.Id == existingPet.Id
                       && x.MedicalCondition == existingPet.MedicalCondition
                       && x.Name == existingPet.Name
                       && x.Race == existingPet.Race
                        ));

        }
        private static Pet GetNamelessPet()
        {
            return new Pet()
            {
                MedicalCondition = "healthy",
                Race = "german shepard",
                ShelterId = 1
            };
        }
        private static PetEntity GetDexterPetEntity()
        {
            return new PetEntity()
            {
                Id = 344,
                MedicalCondition = "healthy",
                Name = "dexter",
                Race = "french bulldog",
                ShelterId = 1
            };
        }

        private static Pet GetGoofyPet()
        {
            return new Pet()
            {

                MedicalCondition = "healthy",
                Name = "goofy",
                Race = "german shepard",
                ShelterId = 1
            };
        }
        private static Pet GetGoofyWithNoShelter()
        {
            return new Pet()
            {
                MedicalCondition = "healthy",
                Name = "goofy",
                Race = "german shepard"
            };
        }
        private static PetEntity GetGoofyPetEntity()
        {
            return new PetEntity()
            {
                Id = 1,
                MedicalCondition = "healthy",
                Name = "goofy",
                Race = "german shepard",
                ShelterId = 1
            };
        }
    }
}
