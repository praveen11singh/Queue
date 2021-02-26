using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            // Retrieve storage account from connection string.
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(@"DefaultEndpointsProtocol=https;AccountName=arena11storage;AccountKey=jV1YbiOkX06nmDyNkyJvl5raNMeGa+URoQc+g7BaY5CAMv4gRWer5hwhgvjrI/8VhuSgCtZvRiTekjqFZWxv1Q==;EndpointSuffix=core.windows.net");

            // Create the queue client.
            CloudQueueClient queueClient = storageAccount.CreateCloudQueueClient();

            // Retrieve a reference to a container.
            CloudQueue queue = queueClient.GetQueueReference("arenaqueue");


            var msg = queue.GetMessage(new TimeSpan(0, 1, 0));
            var messagenew = new CloudQueueMessage(msg.Id,
                                msg.PopReceipt);
            messagenew.SetMessageContent("updatedddd by popreceiptid and id");

            //msg.SetMessageContent("this is changed");

            queue.UpdateMessage(messagenew, new TimeSpan(0, 1, 0)
                    , MessageUpdateFields.Content
                    | MessageUpdateFields.Visibility);

            //var msg = queue.PeekMessage();
            //Console.WriteLine(msg.AsString);
            //Console.Read();

            //var msg = queue.GetMessage(new TimeSpan(0, 1, 0));
            //Console.WriteLine(msg.AsString);
            //Console.Read();


            //foreach (var msg1 in queue.GetMessages(10))
            //{
            //    queue.DeleteMessage(msg1);
            //}
            //Console.WriteLine(msg.AsString);
            //queue.DeleteMessage(msg);

            //// Create the queue if it doesn't already exist
            //queue.CreateIfNotExists();

            //// Create a message and add it to the queue.
            //CloudQueueMessage message = new CloudQueueMessage("Hello, World");
            //queue.AddMessage(message);

            //message = new CloudQueueMessage("Hello, World1");
            //queue.AddMessage(message);
        }
    }
}
