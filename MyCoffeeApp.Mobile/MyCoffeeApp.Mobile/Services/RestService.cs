using MyCoffeeApp.Mobile.Models;
using MyCoffeeApp.Mobile.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MyCoffeeApp.Mobile.Service
{
    public class RestService : IRestService
    {
        private readonly HttpClient _client;
        private readonly string _url = "https://10.0.2.2:7023/";
        public RestService()
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            _client = new HttpClient(clientHandler);
            _client.BaseAddress = new Uri(_url);
        }

        public async Task<Coffee> CreateAsync(string name, string roaster)
        {
            try
            {
                var coffee = new Coffee
                {
                    CoffeeId = new Guid(),
                    CoffeeName = name,
                    CoffeeRoaster = roaster,
                    ImagePath = "https://www.yesplz.coffee/app/uploads/2020/11/emptybag-min.png"
                };
                var jsonRequest = JsonConvert.SerializeObject(coffee);
                var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");
                var response = await _client.PostAsync("api/Coffee", content);
                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    return null;
                }
                var result = await response.Content.ReadAsStringAsync();
                var jsonResponse = JsonConvert.DeserializeObject<Coffee>(result);
                return jsonResponse;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            try
            {
                var response = await _client.DeleteAsync($"api/Coffee/{id}");
                if(response.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    return false; 
                }
                var result = await response.Content.ReadAsStringAsync(); 
                var json = JsonConvert.SerializeObject(result);
                return true;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public async Task<IEnumerable<Coffee>> GetAllAsync()
        {
            try
            {
                var response = await _client.GetAsync("api/Coffee");
                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    return null;
                }
                var result = await response.Content.ReadAsStringAsync();
                var json = JsonConvert.DeserializeObject<List<Coffee>>(result);
                return json;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public async Task<Coffee> GetByIdAsync(Guid Id)
        {
            throw new NotImplementedException();
        }

        public async Task<Coffee> UpdateAsync(Coffee entity)
        {
            throw new NotImplementedException();
        }
    }
}
