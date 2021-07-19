using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;


namespace EventWarezConsoleManager
{
    class Program
    {
        static void Main(string[] args)
        {
        }
        private static async Task<Token> GetToken(HttpClient client)
        {
            string baseAddress = @"https://localhost:44341/api/Token";

            string grant_type = "password";
            string client_id = "rdibz@gmail.com";
            string client_secret = "Dibble1!";

            var form = new Dictionary<string, string>
            {
                {"grant_type", grant_type},
                {"client_id", client_id},
                {"client_secret", client_secret}
            };
            HttpResponseMessage tokenResponse = await client.PostAsync(baseAddress, new FormUrlEncodedContent(form));
            var jsonContent = await tokenResponse.Content.ReadAsStringAsync();
            Token tok = JsonConvert.DeserializeObject<Token>(jsonContent);
            return tok;
        }
        internal class Token
        {
            [JsonProperty("access_token")]
            public string AccessToken { get; set; }

            [JsonProperty("token_type")]
            public string TokenType { get; set; }

            [JsonProperty("expires_in")]
            public int ExpiresIn { get; set; }

            [JsonProperty("refresh_token")]
            public string RefreshToken { get; set; }
        }
    }
}
