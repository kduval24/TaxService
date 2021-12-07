using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaxService.Factories
{
    public interface ITaxCalcFactory
    {
        Task<Rate> GetTaxRatesForLocation(string zipCode, string Country, string City, string Street);
        Task<TaxOrder> CalculateTaxForOrder(TaxOrderRequest tor);
    }
}
