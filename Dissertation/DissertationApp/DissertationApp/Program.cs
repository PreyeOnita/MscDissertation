using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.IO;
using System.Text;
using Microsoft.Azure.EventHubs;
using Newtonsoft.Json;
using System.Linq;
using StackExchange.Redis;
using System.Configuration;


namespace DissertationApp
{
    class Program
    {
        private static EventHubClient eventHubClient;
        private const string EhConnectionString = "Endpoint=sb://dissertationhub.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=URTnx0SjiA9B+jkJ61UXaBCnMXvFcbEiw+Anoztcs+o=";
        private const string EhEntityPath = "disso";

        static void Main(string[] args)
        {
            MainAsync(args).GetAwaiter().GetResult();
        }

        private static async Task MainAsync(string[] args)
        {
            var connectionStringBuilder = new EventHubsConnectionStringBuilder(EhConnectionString)
            {
                EntityPath = EhEntityPath
            };

            eventHubClient = EventHubClient.CreateFromConnectionString(connectionStringBuilder.ToString());

            await SendMessagesToEventHub(100);

            await eventHubClient.CloseAsync();

            Console.WriteLine("Press ENTER to exit.");
            Console.ReadLine();

        }
        private static async Task SendMessagesToEventHub(int numMessagesToSend)
        {
            for (var i = 0; i < numMessagesToSend; i++)
            {
                try
                {
                    Console.WriteLine("JSON File Path:");
                    string fpath = "C:\\Users\\admin\\Documents"; //Console.ReadLine();
                    Console.WriteLine("Filename: ");
                    string fname = "test4.json";//Console.ReadLine();

                    string fullpath = fpath + "\\" + fname;
                    string readfile = File.ReadAllText(fullpath);
                    List<Statistic> properties = JsonConvert.DeserializeObject<List<Statistic>>(readfile);
                   
                    foreach (Statistic feature in properties)
                    {
                        /*Sending*/
                        Console.WriteLine($"Sending message: {feature}");

                        string jsonMessage = JsonConvert.SerializeObject(feature);

                        await eventHubClient.SendAsync(new EventData(Encoding.UTF8.GetBytes(jsonMessage)));
                        System.Threading.Thread.Sleep(2500);

                    }

                    Console.ReadKey();

                }
                catch (Exception exception)
                {
                    Console.WriteLine($"{DateTime.Now} > Exception: {exception.Message}");
                }

                await Task.Delay(10);
            }

            Console.WriteLine($"messages sent.");

        }
        //Connect to Azure Redis Cache
        /*
        private static Lazy<ConnectionMultiplexer> lazyConnection = new Lazy<ConnectionMultiplexer>(() =>
        {
            string cacheConnection = ConfigurationManager.AppSettings["CacheConnection"].ToString();
            return ConnectionMultiplexer.Connect(cacheConnection);
        });

        public static ConnectionMultiplexer Connection
        {
            get
            {
                return lazyConnection.Value;
            }
        }*/
    }

}
