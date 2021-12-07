using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using TaxService;

namespace TaxServiceUnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestGETRatebyLocation()
        {            
            TaxService.TaxService tx = new TaxService.TaxService("TaxJar");
            TaxService.Rate tr = tx.GetTaxRatesForLocation("90404").GetAwaiter().GetResult();            
            
            Assert.IsTrue(tr.rate.city.ToUpper() == "SANTA MONICA");
            Assert.IsTrue(tr.rate.city_rate == 0f);
            Assert.IsTrue(tr.rate.combined_district_rate == 0.03f);
            Assert.IsTrue(tr.rate.combined_rate == 0.1025f);
            Assert.IsTrue(tr.rate.country.ToUpper() == "US");            
            Assert.IsTrue(tr.rate.country_rate == 0f);
            Assert.IsTrue(tr.rate.county.ToUpper() == "LOS ANGELES");
            Assert.IsTrue(tr.rate.county_rate == 0.01f);
            Assert.IsTrue(tr.rate.freight_taxable == false);
            Assert.IsTrue(tr.rate.state.ToUpper() == "CA");
            Assert.IsTrue(tr.rate.state_rate == 0.0625f);
            Assert.IsTrue(tr.rate.zip == "90404");

        }

        [TestMethod]
        public void TestGETTaxbyOrder()
        {            
            TaxService.TaxService tx = new TaxService.TaxService("TaxJar");
            TaxService.TaxOrderRequest tor = new TaxService.TaxOrderRequest();
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

            TaxOrder tr = tx.CalculateTaxForOrder(tor).GetAwaiter().GetResult();

            Assert.IsTrue(tr.tax.amount_to_collect == 1.98f);
            Assert.IsTrue(tr.tax.freight_taxable == true);
            Assert.IsTrue(tr.tax.has_nexus == true);
            Assert.IsTrue(tr.tax.order_total_amount == 37.93f);
            Assert.IsTrue(tr.tax.rate == 0.05218f);
            Assert.IsTrue(tr.tax.shipping == 7.99f);
            Assert.IsTrue(tr.tax.tax_source.ToUpper() == "DESTINATION");
            Assert.IsTrue(tr.tax.taxable_amount == 37.93f);
            Assert.IsNull(tr.tax.exemption_type);

        }

    }
}
