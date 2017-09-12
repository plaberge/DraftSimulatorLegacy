using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using Newtonsoft.Json.Linq;
using System.Runtime.Serialization.Json;
using System.Net.Http;

namespace DraftSimulator.ServerLogic
{
    public class DraftRunLocation
    {
        public string Country { get; set; }
        public string City { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }

        public DraftRunLocation()
        {
            return;
        }

        public DraftRunLocation(decimal latitude, decimal longitude)
        {
            this.Latitude = latitude;
            this.Longitude = longitude;

            this.Country = GetCountryFromLatLong(latitude, longitude);
            this.City = GetCityFromLatLong(latitude, longitude);
        }
        
        public string GetCountryFromLatLong(decimal latitude, decimal longitude)
        {
            string bingMapsRESTCall = "http://dev.virtualearth.net/REST/v1/Locations/" + latitude.ToString() + "," + longitude.ToString() + "?&key=" + "AqZ5LjdL8JNmUrZ2oMH8WBG0XVTYA70p3aCe950KMPN-mkroPDuyfKXeQiOW1Qnu";

            var client = new HttpClient();
            var response = client.GetAsync(bingMapsRESTCall).Result;
            var retResp = new HttpResponseMessage();
            var stringResult = response.Content.ReadAsStringAsync().Result;
            var json = JObject.Parse(stringResult);

            return (string)json["resourceSets"][0]["resources"][0]["address"]["countryRegion"];
            
        }

        public string GetCityFromLatLong(decimal latitude, decimal longitude)
        {
            string bingMapsRESTCall = "http://dev.virtualearth.net/REST/v1/Locations/" + latitude.ToString() + "," + longitude.ToString() + "?&key=" + "AqZ5LjdL8JNmUrZ2oMH8WBG0XVTYA70p3aCe950KMPN-mkroPDuyfKXeQiOW1Qnu";
            
            var client = new HttpClient();
            var response = client.GetAsync(bingMapsRESTCall).Result;
            var retResp = new HttpResponseMessage();
            var stringResult = response.Content.ReadAsStringAsync().Result;
            var json = JObject.Parse(stringResult);

            return (string)json["resourceSets"][0]["resources"][0]["address"]["locality"];
        }
        private async Task PopulateLocationInfo(string IPAddress)
        {
             await this.GetJSONResponse(IPAddress);
        }
        public DraftRunLocation(string IPAddress)
        {
            this.GetJSONResponse(IPAddress);

            return;
        }

        
        public async Task<JObject> GetJSONResponse(string IPAddress)
        {

            //FreeGeoIP Service
            string url = "http://freegeoip.net/json/" + IPAddress;

            //Get the location data via the IP address.

            var client = new HttpClient();
            var response = client.GetAsync(url).Result;
            var retResp = new HttpResponseMessage();
            var stringResult = response.Content.ReadAsStringAsync().Result;
            var json = JObject.Parse(stringResult);

            //FreeGeoIP service
            Country = (string)json["country_name"];
            City = (string)json["city"];
            Latitude = (decimal)json["latitude"];
            Longitude = (decimal)json["longitude"];

            

            return json;
            
        }


    }
}
