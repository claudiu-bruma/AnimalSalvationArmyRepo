using AnimalSalvationArmy.DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalSalvationArmy.DataAccessLayer.DataHelpers
{
    public interface IUniqueIdentityGenerator
    {
        int GetIdentityForList(ICollection<BaseEntity> entities);
    }
}
