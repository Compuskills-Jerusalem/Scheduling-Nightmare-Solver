using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.IO;
using System.Web.Script.Serialization;
using Newtonsoft.Json.Linq;

namespace CapstoneProject.Controllers
{

    public class LocationController : Controller
    {
        public class RequestedData
        {
            public string Latitude { get; set; }
            public string Longitude { get; set; }
        }
        // GET: Location
        public ActionResult Index()
        {
            string BuildUrl(string houseNumber, string streetName, string town, string postalCode, string country)
            {
                string urlBeginning = $"https://geocoder.api.here.com/6.2/geocode.json?app_id=LhgMMXSgRrECNyW5g28t&app_code=G8x8pAjhZNjNR_QLWcyyQQ&searchtext=";
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

                return urlBeginning;
            }

            string url = BuildUrl("27", "Hamagid Mimezeritch", "Beitar", "90500", "Israel");

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.AutomaticDecompression = DecompressionMethods.GZip;

            RequestedData requestedData = new RequestedData();
            dynamic dataText;
            using (var response = (HttpWebResponse)request.GetResponse())
            {
                using (var reader = new StreamReader(response.GetResponseStream()))
                {
                    JavaScriptSerializer serializer = new JavaScriptSerializer();
                    dataText = reader.ReadToEnd();
                    requestedData = serializer.Deserialize<RequestedData>(dataText);
                }
            }

            JObject json = JObject.Parse(dataText);
            JObject latitude = JObject.Parse(json["Response"]["View"][0]["Result"][0]["Location"]["NavigationPosition"][0].ToString());
            //JSON.Parse(json);



            //check kosbie github capstone mens to see how to store logic externally




            string stringLat = latitude.ToString();
            return Content(stringLat);
        }
    }
}