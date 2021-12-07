using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace TaxService.Factories
{
    public class TaxJarProvider : ITaxCalcFactory
    {
        string calcURL = "https://api.taxjar.com/v2/";
        public async Task<Rate> GetTaxRatesForLocation(string zipCode, string Country = "", string City = "", string Street = "")
        {
            if (zipCode == "")
            {
                throw new Exception("ZipCode is required");
            }
            
            HttpClient client = new HttpClient();
            //HttpRequestMessage request = new HttpRequestMessage();
            client.BaseAddress = new Uri(calcURL);
            client.DefaultRequestHeaders.Add("Authorization", "Token token=\"5da2f821eee4035db4771edab942a4cc\"");
            //request.Headers.Add("Authorization", "Token token=\"5da2f821eee4035db4771edab942a4cc\"");

            //move path generation to caller?  probably move path generation to tax calc factory            
            Uri RequestUri = new Uri(client.BaseAddress + $"rates/{zipCode}");
            if (Country != "")
            {
                RequestUri = new Uri(RequestUri + $"?country={Country}");
                if (City != "")
                {
                    RequestUri = new Uri(RequestUri + $"&city={City}");
                }
                if (Street != "")
                {
                    RequestUri = new Uri(RequestUri + $"&street={Street}");
                }
            }

            Rate tr = null;
            
            HttpResponseMessage response = await client.GetAsync(RequestUri);
            if (response.IsSuccessStatusCode)
            {
                tr = await response.Content.ReadAsAsync<Rate>();
            }

            return tr;
        }

        public async Task<TaxOrder> CalculateTaxForOrder(TaxOrderRequest tor)
        {
            HttpClient client = new HttpClient();
            string requestURI = calcURL + "taxes";
            client.DefaultRequestHeaders.Add("Authorization", "Token token=\"5da2f821eee4035db4771edab942a4cc\"");

            TaxOrder taxOrderResponse = null;
            
            HttpResponseMessage response = await client.PostAsJsonAsync(requestURI, tor);
            if (response.IsSuccessStatusCode)
            {
                taxOrderResponse = await response.Content.ReadAsAsync<TaxOrder>();                
            }

            return taxOrderResponse;

        }
    }
}
