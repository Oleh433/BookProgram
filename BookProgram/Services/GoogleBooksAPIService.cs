using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using BookProgram.Models;
using LoggingSim;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BookProgram.Services
{
    public class GoogleBooksAPIService
    {
        private readonly string ApiKey;
        private ILogger _logger;

        public GoogleBooksAPIService(string apiKey, ILogger logger)
        {
            ApiKey = apiKey;
            _logger = logger;
        }

        public async Task<ApiBookResponse> GetBookByName(string bookName)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage message = await client.GetAsync($"https://www.googleapis.com/books/v1/volumes?q={bookName}+intitle:keyes&key={ApiKey}");

                message.EnsureSuccessStatusCode();
                _logger.LogInformation("Request has been recived successfully");

                return await message.Content.ReadFromJsonAsync<ApiBookResponse>();
            }
        }

        public async Task<ApiBookResponse> GetBookById(string bookId)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage message = await client.GetAsync($"https://www.googleapis.com/books/v1/volumes/{bookId}?key={ApiKey}");

                message.EnsureSuccessStatusCode();
                _logger.LogInformation("Request has been recived successfully");

                return await message.Content.ReadFromJsonAsync<ApiBookResponse>();
            }
        }
    }
}
