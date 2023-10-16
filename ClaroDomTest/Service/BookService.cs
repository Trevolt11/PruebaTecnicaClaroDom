using System;
using ClaroDomTest.Models;

namespace ClaroDomTest.Service
{
	public class BookService : IBookService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BookService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IEnumerable<Book>> GetBooksAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://fakerestapi.azurewebsites.net/api/v1/Books");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadFromJsonAsync<IEnumerable<Book>>();
                return content;
            }
            return null;
        }

        public async Task<Book> GetBookAsync(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"https://fakerestapi.azurewebsites.net/api/v1/Books/{id}");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadFromJsonAsync<Book>();
                return content;
            }
            return null;
        }

        public async Task<Book> CreateBookAsync(Book book)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.PostAsJsonAsync("https://fakerestapi.azurewebsites.net/api/v1/Books", book);

            if (response.IsSuccessStatusCode)
            {
                var createdBook = await response.Content.ReadFromJsonAsync<Book>();
                return createdBook;
            }
            return null;
        }

        public async Task<bool> UpdateBookAsync(int id, Book book)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.PutAsJsonAsync($"https://fakerestapi.azurewebsites.net/api/v1/Books/{id}", book);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteBookAsync(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.DeleteAsync($"https://fakerestapi.azurewebsites.net/api/v1/Books/{id}");

            return response.IsSuccessStatusCode;
        }
    }
}

