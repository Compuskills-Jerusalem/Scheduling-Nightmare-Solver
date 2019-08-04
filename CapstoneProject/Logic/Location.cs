using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Device.Location;
using System.Net;
using System.IO;
using Newtonsoft.Json.Linq;
using static CapstoneProject.Controllers.LocationController;

namespace CapstoneProject.Logic
{
    public class AddressCoordinates
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }

    public class Location
    {
        private string BuildUrl(string houseNumber, string streetName, string town, string postalCode, string country)
        {
            string urlBeginning = $"https://geocoder.api.here.com/6.2/geocode.json?app_id=LhgMMXSgRrECNyW5g28t&app_code=G8x8pAjhZNjNR_QLWcyyQQ&searchtext=";
            string attributeSwitches = "&locationattributes=none";
            string queryParameters = "";
            string space = "%20";

            List<string> data = new List<string>();
            data.Add(houseNumber);
            data.Add(streetName);
            data.Add(town);
            data.Add(postalCode);
            data.Add(country);

            for (int i = 0; i < data.Count; i++)
            {
                data[i] = data[i].Replace(" ", space);
            }
            foreach (string dataBlob in data)
            {
                if (dataBlob != "")
                {
                    queryParameters += dataBlob;
                    queryParameters += space;
                }
            }
            queryParameters = queryParameters.Remove(queryParameters.Length - 3, 3);
            urlBeginning += queryParameters;
            urlBeginning += attributeSwitches;
            return urlBeginning;
        }

        private void GetTravelTime(double originLat, double originLong, double destinationLat, double destinationLong)
        {
            GeoCoordinate origin = new GeoCoordinate(originLat, originLong);
            GeoCoordinate destination = new GeoCoordinate(destinationLat, destinationLong);

            double distance = origin.GetDistanceTo(destination);
            // travelSpeedConstant is a very approximate calculation
            const int travelSpeedConstant = 145;
            double travelTime = distance / travelSpeedConstant;
        }

        public AddressCoordinates Geocode(string houseNumber, string streetName, string town, string postalCode, string country)
        {
            string url = BuildUrl("6", "Shamgar", "Jerusalem", "", "Israel");
            //string url = BuildUrl(houseNumber, streetName, town, postalCode, country);

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.AutomaticDecompression = DecompressionMethods.GZip;
            AddressCoordinates address = new AddressCoordinates();
            dynamic dataText;
            using (var response = (HttpWebResponse)request.GetResponse())
            {
                using (var reader = new StreamReader(response.GetResponseStream()))
                {
                    dataText = reader.ReadToEnd();
                }
            }

            JObject json = JObject.Parse(dataText);
            JToken latitudeJson = json.SelectToken("$.Response..Location.NavigationPosition..Latitude");
            JToken longitudeJson = json.SelectToken("$.Response..Location.NavigationPosition..Longitude");
            address.Latitude = (double)latitudeJson;
            address.Longitude = (double)longitudeJson;
        }

    }
}