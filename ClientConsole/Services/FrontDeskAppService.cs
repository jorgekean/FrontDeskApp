using API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientConsole.Services
{
    public static class FrontDeskAppService
    {
        public static string ApiUrl { get; set; } = "https://localhost:7296/";// change port based on your local run

        private static readonly HttpClient _httpClient = new();
        
        public static async Task<Customer> CreateCustomer()
        {
            Console.Write("Enter customer first name: ");
            string firstName = Console.ReadLine();

            Console.Write("Enter customer last name: ");
            string lastName = Console.ReadLine();

            Console.Write("Enter customer phone number: ");
            string phoneNumber = Console.ReadLine();

            var customer = new Customer { FirstName = firstName, LastName = lastName, PhoneNumber = phoneNumber };

            var response = await _httpClient.PostAsJsonAsync($"{ApiUrl}Customer", customer);

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Customer created successfully.");
                return await response.Content.ReadAsAsync<Customer>();
            }
            else
            {
                Console.WriteLine($"Failed to create customer. Status code: {response.StatusCode}");
                return null;
            }
        }

        public static async Task CheckStorageAreaAvailability()
        {
            Console.Write("Enter box size ((1 - Small, 2 - Medium, or 3 - Large): ");
            string boxSize = Console.ReadLine();

            var response = await _httpClient.GetAsync(ApiUrl + $"StorageArea?boxSize={boxSize}");

            if (response.IsSuccessStatusCode)
            {
                var storageAreas = await response.Content.ReadAsAsync<List<StorageArea>>();

                if (storageAreas.Any())
                {
                    Console.WriteLine("Available storage areas:");
                    foreach (var area in storageAreas)
                    {
                        Console.WriteLine($"{area.Name} ({area.Available} available)");
                    }
                }
                else
                {
                    Console.WriteLine("No storage areas available for the requested box size.");
                }
            }
            else
            {
                Console.WriteLine($"Failed to check storage area availability. Status code: {response.StatusCode}");
            }
        }

        public static async Task RecordBoxStorageStatus()
        {
            Console.Write("Enter customer ID: ");
            int customerId = int.Parse(Console.ReadLine());          

            Console.Write("Enter box size (1 - Small, 2 - Medium, or 3 - Large): ");
            string boxSize = Console.ReadLine();

            Console.Write("Enter status (Stored or Retrieved): ");
            string status = Console.ReadLine();

            var boxStorageStatus = new BoxStorageStatus { CustomerId = customerId, BoxSize = boxSize, Status = status, TransactionDate = DateTime.Now };

            var response = await _httpClient.PostAsJsonAsync(ApiUrl + "BoxStorageStatus", boxStorageStatus);

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Box storage status recorded successfully.");
            }
            else
            {
                Console.WriteLine($"Failed to record box storage status. Status code: {response.StatusCode}");
            }
        }

    }
}
