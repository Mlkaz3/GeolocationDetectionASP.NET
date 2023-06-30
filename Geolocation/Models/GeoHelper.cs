using Geolocation.Models;
using System.Text.Json.Nodes;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Net.Http.Json;

namespace Geolocation.Models
{
    public class GeoHelper
    {
        private readonly HttpClient _httpClient;
        private string apikey = "6e7bffd429766e92c13212450828c6a8";
        
        public GeoHelper()
        {
            _httpClient = new HttpClient()
            {
                Timeout = TimeSpan.FromSeconds(5)
            };

        }

        public async Task<string> GetIPAddress()
        {
            var ipAddress = await _httpClient.GetAsync($"http://ipinfo.io/ip");
            if (ipAddress.IsSuccessStatusCode)
            {
                var json = await ipAddress.Content.ReadAsStringAsync();
                return json.ToString();
            }

            return "";
        }

        public async Task<string> GetGeoInfo()
        {
            var ipAddress = await GetIPAddress();

            var response = await _httpClient.GetAsync($"http://api.ipstack.com/" + ipAddress + "?access_key=" + apikey);
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return json;
            }

            return "";
        }

        public async Task<string> GetGeoInfoWithIP(string IP)
        {

            var response = await _httpClient.GetAsync($"http://api.ipstack.com/" + IP + "?access_key=" + apikey);
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return json;
            }

            return "";
        }

    }

}
