using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using LoggingSim;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BookProgram
{
    internal class GoogleBooksAPIService
    {
        public string ApiKey { get; set; }

        public GoogleBooksAPIService(string api)
        {
            ApiKey = api;
        }

        public async Task<ApiBookResponse> GetBookByName(string bookName, ILogger logger)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage message = await client.GetAsync($"https://www.googleapis.com/books/v1/volumes?q={bookName}+intitle:keyes&key={ApiKey}");

                message.EnsureSuccessStatusCode();
                logger.LogInformation("Request has been recived successfully");

                return await message.Content.ReadFromJsonAsync<ApiBookResponse>();
            }
        }

        public async Task<ApiBookResponse> GetBookById(string bookId, ILogger logger)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage message = await client.GetAsync($"https://www.googleapis.com/books/v1/volumes/{bookId}?key={ApiKey}");

                message.EnsureSuccessStatusCode();
                logger.LogInformation("Request has been recived successfully");

                return await message.Content.ReadFromJsonAsync<ApiBookResponse>();
            }
        }
    }
}
