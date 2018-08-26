using AnimalSalvationArmy.Services.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalSalvationArmy.Services.ShelterWorker
{
    public interface IShelterWorkerService
    {
        int CreateShelterWorker(ShelterWorkerDto shelterWorker);
        void RemoveShelterWorker(int shelterWorkerId);
    }
}
