using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaxService
{
    public class Program
    {
        static void Main(string[] args)
        {
            //CreateHostBuilder(args).Build().Run();                        

            TaxService tx = new TaxService("blG");
            Rate tr = tx.GetTaxRatesForLocation("90404").GetAwaiter().GetResult();          
            TaxOrderRequest tor = new TaxOrderRequest();
            tor.amount = 29.94f;
            tor.from_country = "US";
            tor.from_state = "NY";
            tor.from_zip = "12054";
            tor.from_city = "Delmar";
            tor.to_country = "US";
            tor.to_state = "NY";
            tor.to_zip = "10541";
            tor.to_city = "Mahopac";
            tor.shipping = 7.99f;


            LineItems[] li = new LineItems[] { new LineItems { quantity = 1, unit_price = 19.99f, product_tax_code = "20010" }, 
                new LineItems {quantity = 1, unit_price = 9.95f, product_tax_code = "20010" } };


            tor.line_items = li;


            TaxOrder r = tx.CalculateTaxForOrder(tor).GetAwaiter().GetResult();
          
        }

        //public static IHostBuilder CreateHostBuilder(string[] args) =>
        //    Host.CreateDefaultBuilder(args)
        //        .ConfigureWebHostDefaults(webBuilder =>
        //        {
        //            webBuilder.UseStartup<Startup>();
        //        });
    }
}
