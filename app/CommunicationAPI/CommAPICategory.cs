using DomainProduct;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace CommunicationAPI
{
    public class CommAPICategory : ICommAPI<Category>
    {
        public HttpClient client = null;

        public CommAPICategory()
        {
            client = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:53469/")
            };
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<int> AddAsync(Category category)
        {
            int response = await client.PostAsAsync<int>(category, "categories");
            return response;
        }

        public async Task UpdateAsync(Category category)
        {
            await client.PutAsAsync(category, "categories");
        }

        public async Task<Category> GetByIdAsync(int id)
        {
            var category = await client.GetAsAsync<Category>($"categories/{id}");
            return category;
        }

        public async Task<List<Category>> GetAllAsync()
        {
            var category = await client.GetAsAsync<List<Category>>("categories");
            return category;
        }

        public async Task DeleteAsync(int id)
        {
            await client.DeleteAsync($"categories/{id}");
        }
    }
}