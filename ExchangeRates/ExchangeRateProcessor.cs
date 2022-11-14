using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeRates
{
  public class ExchangeRateProcessor
    {
        public static async Task<string> LoadData(string code)
        {
            string url = $"http://api.nbp.pl/api/exchangerates/rates/a/{code}/?format=json";
            Root data;

            using (HttpResponseMessage response = await ApiHelper.apiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {


                    var json = await ApiHelper.apiClient.GetStringAsync(url);
                    data = JsonConvert.DeserializeObject<Root>(json);
                    return data.rates[0].mid.ToString();
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
            
        }
    }
}
