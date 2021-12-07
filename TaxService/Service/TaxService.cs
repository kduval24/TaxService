using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;

namespace TaxService
{         

    public class TaxService : Factories.ITaxCalcFactory
    {       
        Factories.ITaxCalcFactory factory = null;

        public TaxService(string clientName)
        {
            if (string.IsNullOrEmpty(clientName))
            { 
                throw new Exception("Please provide a valid client name or Tax Calculator");
            }
            factory = Factories.TaxCalculatorFactory.GetProvider(clientName);
            if (factory == null)
            {
                throw new Exception("Error getting calculator.  Please double check provided client name");
            }
        }
        public async Task<Rate> GetTaxRatesForLocation(string zipCode, string Country = "", string City = "", string Street = "")
        {
            if (zipCode == "")
            {
                throw new Exception("ZipCode is required");
            }

            try
            {
                Rate r = await factory.GetTaxRatesForLocation(zipCode, Country, City, Street);
                return r;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<TaxOrder> CalculateTaxForOrder(TaxOrderRequest tor)
        {       
            if (tor == null)
            {
                throw new Exception("A request must be provided");
            }
            
            try
            {
                TaxOrder taxOrderResponse = await factory.CalculateTaxForOrder(tor);
                return taxOrderResponse;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
    }
}
