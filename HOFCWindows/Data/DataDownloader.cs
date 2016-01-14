using HOFCWindows.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Web.Http;

namespace HOFCWindows.Data
{
    class DataDownloader
    {
        public static async Task<List<T>> download<T>(string URL, List<string> param) where T : IModel
        {
            HttpClient client = new HttpClient();
            string result = await client.GetStringAsync(new Uri(URL));
            List<T> results = JsonConvert.DeserializeObject<List<T>>(result);

            return results;
        }
    }
}
