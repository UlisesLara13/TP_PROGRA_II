using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CarpinteriaFront.Servicios
{
    public class ClienteSingleton
    {
        private static ClienteSingleton instance;
        private HttpClient client;
        private ClienteSingleton()
        {
            client = new HttpClient();
        }

        public static ClienteSingleton GetInstance()
        { 
            if (instance == null)
            {
                instance = new ClienteSingleton();

            }
            return instance;
        }

        public async Task<string> GetAsync(string urlGet)
        {
            var result = await client.GetAsync(urlGet);
            var content = "";
            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                content = await result.Content.ReadAsStringAsync();
            }
            return content;
        }
        public async Task<string> PostAsync(string urlPost, string dataJson)
        {
            StringContent content = new StringContent(dataJson,Encoding.UTF8,"application/json");
            var result = await client.PostAsync(urlPost, content);
            var response = "";
            if(result.IsSuccessStatusCode)
            {
                response = await result.Content.ReadAsStringAsync();
            }
            return response;
        }

        public async Task<string> PutAsync(string urlPut, string dataJson)
        {
            StringContent content = new StringContent(dataJson, Encoding.UTF8, "application/json");
            var result = await client.PutAsync(urlPut, content);
            var response = "";
            if (result.IsSuccessStatusCode)
            {
                response = await result.Content.ReadAsStringAsync();
            }
            return response;
        }

        public async Task<string> DeleteAsync(string urlDelete)
        {
            var result = await client.DeleteAsync(urlDelete);
            var response = "";
            if (result.IsSuccessStatusCode)
            {
                response = await result.Content.ReadAsStringAsync();
            }
            return response;
        }

    }
}
