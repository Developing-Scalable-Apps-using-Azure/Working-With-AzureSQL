using StarbucksStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarbucksStore.Interfaces
{
    public interface IQueueService
    {
        void QueueNewStoreCreation(string userAndStoreData);
    }
}
