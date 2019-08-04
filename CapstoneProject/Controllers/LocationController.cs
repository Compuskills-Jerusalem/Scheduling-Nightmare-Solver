using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Net;
using System.IO;
using Newtonsoft.Json.Linq;
using System.Device.Location;

namespace CapstoneProject.Controllers
{
    public class LocationController : Controller
    {
        public class AddressLocation
        {
            public string Latitude { get; set; }
            public string Longitude { get; set; }
        }

        public void GetTravelTime(double originLat, double originLong, double destinationLat, double destinationLong)
        {
            GeoCoordinate origin = new GeoCoordinate(originLat, originLong);
            GeoCoordinate destination = new GeoCoordinate(destinationLat, destinationLong);

            double distance = origin.GetDistanceTo(destination);
            // travelSpeedConstant is a very approximate calculation
            const int travelSpeedConstant = 145;
            double travelTime = distance / travelSpeedConstant;
        }

        // GET: Location
        public ActionResult Index()
        {
            string BuildUrl(string houseNumber, string streetName, string town, string postalCode, string country)
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

            string url = BuildUrl("6", "Shamgar", "Jerusalem", "", "Israel");

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.AutomaticDecompression = DecompressionMethods.GZip;
            AddressLocation address = new AddressLocation();
            dynamic dataText;
            using (var response = (HttpWebResponse)request.GetResponse())
            {
                using (var reader = new StreamReader(response.GetResponseStream()))
                {
                    //JavaScriptSerializer serializer = new JavaScriptSerializer();
                    dataText = reader.ReadToEnd();
                    //address = serializer.Deserialize<AddressLocation>(dataText);
                }
            }

            JObject json = JObject.Parse(dataText);
            JToken latitudeJson = json.SelectToken("$.Response..Location.NavigationPosition..Latitude");
            JToken longitudeJson = json.SelectToken("$.Response..Location.NavigationPosition..Longitude");
            address.Latitude = latitudeJson.ToString();
            address.Longitude = longitudeJson.ToString();
            
            return Content(address.Latitude);
        }            
    }
}
    
