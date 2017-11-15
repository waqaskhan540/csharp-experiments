using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hasty.ApiGenerator.Extensions
{
    public static class StringExtensions
    {
        public static object  AsJsonString(this string data)
        {
            if (string.IsNullOrWhiteSpace(data))
                return null;

            var paramDictionary = new Dictionary<string, string>();

            if (!data.Contains("&"))
            {
                var paramValues = data.Split("=");
                if(paramValues.Length > 0)
                {
                    paramDictionary.Add(paramValues[0], paramValues[1]);
                    return paramDictionary;
                }
                return null;
            }
            

            var parameters = data.Split("&");

            if (parameters.Length < 1)
                return null;

            foreach (var param in parameters)
            {
                var paramValues = data.Split("=");
                if(paramValues.Length > 0)
                {
                    paramDictionary.Add(paramValues[0], paramValues[1]);
                }
            }

            if (paramDictionary.Count > 0)
            {
                var jsonString = JsonConvert.SerializeObject(paramDictionary);
                return jsonString;
            }

            return null;
        }
    }
}
