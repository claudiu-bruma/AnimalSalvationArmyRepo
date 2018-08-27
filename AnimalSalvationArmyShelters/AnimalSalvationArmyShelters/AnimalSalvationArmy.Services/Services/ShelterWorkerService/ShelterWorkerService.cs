using AnimalSalvationArmy.DataAccessLayer;
using AnimalSalvationArmy.Services.DataTransferObjects;
using AnimalSalvationArmy.Services.ShelterWorker;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalSalvationArmy.Services.ShelterWorkerService
{
    public class ShelterWorkerService : IShelterWorkerService
    {
        private AnimalShelterApplicationDataStore _dataStore;
        public ShelterWorkerService(AnimalShelterApplicationDataStore dataStore)
        {
            _dataStore = dataStore;
        }
        public int CreateShelterWorker(ShelterWorkerDto shelterWorker)
        {
            

            throw new NotImplementedException();
        }

        public void RemoveShelterWorker(int shelterWorkerId)
        {
            throw new NotImplementedException();
        }
    }
}
