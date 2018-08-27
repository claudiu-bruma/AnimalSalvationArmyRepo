using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AnimalSalvationArmy.DataAccessLayer.Entities;

namespace AnimalSalvationArmy.DataAccessLayer.DataHelpers
{
    public class UniqueIdentityGenerator : IUniqueIdentityGenerator
    {
        public int GetIdentityForList(ICollection<BaseEntity> entities)
        {
            int identity = 1; 
            if (!entities.Any() )
            {
                return identity;//first id would always be 1
            }
            identity = entities.Max(x => x.Id) + 1;//this would top out at 2147483647 
                                                   // but at that point there would probably be a database of some kind:)

            return identity;
        }
    }
}
