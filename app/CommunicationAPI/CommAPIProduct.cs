using DomainProduct;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace CommunicationAPI
{
    public class CommAPIProduct : ICommAPI<Product>
    {
        public HttpClient client = null;

        public CommAPIProduct()
        {
            client = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:53469/")
            };
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<int> AddAsync(Product product)
        {
            int response = await client.PostAsAsync<int>(product, "products");
            return response;
        }

        public async Task UpdateAsync(Product product)
        {
            await client.PutAsAsync(product, "products");
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            var produto = await client.GetAsAsync<Product>($"products/{id}");
            return produto;
        }

        public async Task<List<Product>> GetAllAsync()
        {
            var produto = await client.GetAsAsync<List<Product>>("products");
            return produto;
        }

        public async Task DeleteAsync(int id)
        {
            await client.DeleteAsync($"products/{id}");
        }

        public async Task<List<Product>> FindByNameAsync(string name)
        {
            var produto = await client.PostAsAsync<List<Product>>(name, "products/find");
            return produto;
        }
    }
}
