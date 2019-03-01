using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CommunicationAPI
{
    public static class HttpContentExtensions
    {
        public static async Task<T> ReadAsJsonAsync<T>(this HttpContent content)
        {
            string json = await content.ReadAsStringAsync();
            T value = JsonConvert.DeserializeObject<T>(json);
            return value;
        }
        public static async Task<T> PostAsAsync<T>(this HttpClient content, object body, string route)
        {
            try
            {
                HttpResponseMessage response = await content.PostAsync(
                    route, new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json"));

                if (response.IsSuccessStatusCode)
                {
                    T obj = await response.Content.ReadAsJsonAsync<T>();
                    return obj;
                }
                else
                    throw new Exception(await response.Content.ReadAsStringAsync());
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static async Task<T> PutAsAsync<T>(this HttpClient content, object body, string route)
        {
            HttpResponseMessage response = await content.PutAsync(
                route, new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json"));

            if (response.IsSuccessStatusCode)
            {
                T obj = await response.Content.ReadAsJsonAsync<T>();
                return obj;
            }
            else
                throw new Exception(await response.Content.ReadAsStringAsync());
        }
        public static async Task PutAsAsync(this HttpClient content, object body, string route)
        {
            HttpResponseMessage response = await content.PutAsync(
                route, new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json"));
            if (!response.IsSuccessStatusCode)
                throw new Exception(await response.Content.ReadAsStringAsync());
        }
        public static async Task DeleteAsAsync(this HttpClient content, string route)
        {
            HttpResponseMessage response = await content.DeleteAsync(route);
            if (!response.IsSuccessStatusCode)
                throw new Exception(await response.Content.ReadAsStringAsync());
        }
        public static async Task<T> GetAsAsync<T>(this HttpClient content, string route)
        {
            HttpResponseMessage response = await content.GetAsync(route);
            T obj = await response.Content.ReadAsJsonAsync<T>();
            if (response.IsSuccessStatusCode)
                return obj;
            else
                throw new Exception(await response.Content.ReadAsStringAsync());
        }
    }
}
