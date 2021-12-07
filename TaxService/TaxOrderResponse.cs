using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaxService
{
    public class TaxOrderResponse
    {
        public float order_total_amount { get; set; }
        public float shipping { get; set; }
        public float taxable_amount { get; set; }
        public float amount_to_collect { get; set; }
        public float rate { get; set; }
        public bool has_nexus { get; set; }
        public bool freight_taxable { get; set; }
        public string tax_source { get; set; }
        public string exemption_type { get; set; }
        public Jurisdictions jurisdictions { get; set; }
        public Breakdown breakdown { get; set; }
    }

    public class Breakdown
    {
        public float taxable_amount { get; set; }
        public float tax_collectable { get; set; }
        public float combined_tax_rate { get; set; }
        public float state_taxable_amount { get; set; }
        public float state_tax_rate { get; set; }
        public float state_tax_collectable { get; set; }
        public float county_taxable_amount { get; set; }
        public float county_tax_rate { get; set; }
        public float county_tax_collectable { get; set; }
        public float city_taxable_amount { get; set; }
        public float city_tax_rate { get; set; }
        public float city_tax_collectable { get; set; }
        public float special_district_taxable_amount { get; set; }
        public float special_tax_rate { get; set; }
        public float special_district_tax_collectable { get; set; }
        public Shipping shipping { get; set; }
        public LineItemsResponse[] line_items { get; set; }
        public float gst_taxable_amount { get; set; }
        public float gst_tax_rate { get; set; }
        public float gst { get; set; }
        public float pst_taxable_amount { get; set; }
        public float pst_tax_rate { get; set; }
        public float pst { get; set; }
        public float qst_taxable_amount { get; set; }
        public float qst_tax_rate { get; set; }
        public float qst { get; set; }
        public float country_taxable_amount { get; set; }
        public float country_tax_rate { get; set; }
        public float country_tax_collectable { get; set; }


    }

    public class Shipping
    {
        public float city_amount { get; set; }
        public float city_tax_rate { get; set; }
        public float city_taxable_amount { get; set; }
        public float combined_tax_rate { get; set; }
        public float county_amount { get; set; }
        public float county_tax_rate { get; set; }
        public float county_taxable_amount { get; set; }
        public float special_district_amount { get; set; }
        public float special_tax_rate { get; set; }
        public float special_taxable_amount { get; set; }
        public float state_amount { get; set; }
        public float state_sales_tax_rate { get; set; }
        public float state_taxable_amount { get; set; }
        public float tax_collectable { get; set; }
        public float taxable_amount { get; set; }

    }

    public class LineItemsResponse
    {
        public float city_amount { get; set; }
        public float city_tax_rate { get; set; }
        public float city_taxable_amount { get; set; }
        public float combined_tax_rate { get; set; }
        public float county_amount { get; set; }
        public float county_tax_rate { get; set; }
        public float county_taxable_amount { get; set; }
        public string id { get; set; }
        public float special_district_amount { get; set; }
        public float special_district_taxable_amount { get; set; }
        public float special_tax_rate { get; set; }
        public float state_amount { get; set; }
        public float state_sales_tax_rate { get; set; }
        public float state_taxable_amount { get; set; }
        public float tax_collectable { get; set; }
        public float taxable_amount { get; set; }

    }

    public class Jurisdictions
    {
        public string country { get; set; }
        public string state { get; set; }
        public string county { get; set; }
        public string city { get; set; }
    }

    public class TaxOrder
    {
        public TaxOrderResponse tax { get; set; }
    }
}
