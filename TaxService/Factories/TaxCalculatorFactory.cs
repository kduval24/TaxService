using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace TaxService.Factories
{
    public class TaxCalculatorFactory
    {
       public static ITaxCalcFactory GetProvider(string clientName)
        {
            switch (clientName.ToUpper())
            {
                case "TAXJAR":
                    return new TaxJarProvider();
                default:
                    return null;
                //add new calculators depending on client name passed here.
            }
                
        }
    }
}
