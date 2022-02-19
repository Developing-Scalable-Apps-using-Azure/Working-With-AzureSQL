using StarbucksStore.Interfaces;
using StarbucksStore.Models;
using Microsoft.Extensions.Options;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;

namespace StarbucksStore.Services
{
    public class QueueService : IQueueService
    {
        private CloudStorageAccount _storageAccount;


        public QueueService()
        {
            
        }

        public async void QueueNewStoreCreation(string userAndStoreData)
        {
            // Create the CloudQueueClient object for the storage account.
            CloudQueueClient queueClient = _storageAccount.CreateCloudQueueClient();

            // Get a reference to the CloudQueue named "NewStoreQueue"
            CloudQueue newStoreQueue = queueClient.GetQueueReference("newstorequeue");

            // Create the CloudQueue if it does not exist.
            await newStoreQueue.CreateIfNotExistsAsync();

            // Create a message and add it to the queue.
            CloudQueueMessage message = new CloudQueueMessage(userAndStoreData);
            await newStoreQueue.AddMessageAsync(message);
        }
    }
}
