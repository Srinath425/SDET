using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;

namespace FindCapitalByState
{
    /// <summary>
    /// The Find By State Business Logic
    /// </summary>
    public class FindByStateBusinessLogic : IFindByStateBusinessLogic
    {
        /// <summary>
        /// The Url
        /// </summary>
        private const string Url = "http://services.groupkt.com/state/get/USA/all";

        /// <summary>
        /// The Find City By State
        /// </summary>
        /// <param name="stateName">The stateName</param>
        /// <returns>returns state model as result</returns>
        public StateModel FindCityByState(string stateName)
        {
            if (string.IsNullOrWhiteSpace(stateName))
            {
                return new StateModel { ErrorMessage = "Please enter state name\n" };
            }

            string responseString = HttpGetResponse();

            if (string.IsNullOrWhiteSpace(responseString))
            {
                return new StateModel { ErrorMessage = "No result returned from API\n" };
            }

            var jObject = JObject.Parse(responseString);

            var statesList = JsonConvert.DeserializeObject<List<StateModel>>(jObject?["RestResponse"]?["result"]?.ToString());

            if (!statesList.Any())
            {
                return new StateModel { ErrorMessage = "No result found in API response\n" };
            }

            var resultItem = statesList.Where(state => state.Name.Equals(stateName, StringComparison.OrdinalIgnoreCase) || state.Abbr.Equals(stateName, StringComparison.OrdinalIgnoreCase)).ToList();
            if (resultItem.Any())
            {
                return resultItem.FirstOrDefault();
            }
            else
            {
                return new StateModel { ErrorMessage = "No result found : Invalid input\n" };
            }
        }

        /// <summary>
        /// The HttpGetResponse
        /// </summary>
        /// <returns>returns http response string</returns>
        public string HttpGetResponse()
        {
            string responseString;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                responseString = reader.ReadToEnd();
            }

            return responseString;
        }
    }
}
