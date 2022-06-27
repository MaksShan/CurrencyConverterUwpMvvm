using System.Net.Http;
using Newtonsoft.Json;
using ConverterApp.Models;

namespace ConverterApp.Services
{
    class DataService
    {
        private const string URL = "https://www.cbr-xml-daily.ru/daily_json.js";

        public static CurrencyModel.Root GetCurrencyData()
        {
            using (var client = new HttpClient())
            {
                var response = client.GetAsync(URL, HttpCompletionOption.ResponseContentRead).GetAwaiter().GetResult();

                var dataString = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();

                var data = JsonConvert.DeserializeObject<CurrencyModel.Root>(dataString);
                
                data.Valute.Add("RUR", new CurrencyModel.Currency("RUR", "Российский рубль", 1));

                return data;
            }
        }
    }
}
