
using EventWarez.Data;
using System.Net.Http;
using System.Threading.Tasks;

namespace EventWarezConsoleManager
{
    public class EWService
    {
        private readonly HttpClient _httpClient = new HttpClient();

        public async Task<Show> GetShowAsync(string url)
        {
            var response = await _httpClient.GetAsync(url);
            return response.IsSuccessStatusCode ? await response.Content.ReadAsAsync<Show>() : null;
        }
        public async Task<T> GetAsync<T>(string url) where T : class
        {
            HttpResponseMessage response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                T content = await response.Content.ReadAsAsync<T>();
                return content;
            }

            return default;
            //return null;
        }
    }
}
