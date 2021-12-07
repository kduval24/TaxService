using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaxService
{
    public class TaxOrderRequest
    {
        public string from_country { get; set; }
        public string from_zip { get; set; }
        public string from_state { get; set; }
        public string from_city { get; set; }
        public string from_street { get; set; }
        public string to_country { get; set; }
        public string to_zip { get; set; }
        public string to_state { get; set; }
        public string to_city { get; set; }
        public string to_street { get; set; }
        public float amount { get; set; }
        public float shipping { get; set; }
        public LineItems[] line_items { get; set; }
        public NexusAddresses[] nexus_addresses { get; set; }
    }
    public class LineItems
    {
        public int quantity { get; set; }
        public float unit_price { get; set; }
        public string product_tax_code { get; set; }
        public float discount { get; set; }
        public string id { get; set; }
    }

    public class NexusAddresses
    {
        public string id { get; set; }
        public string country { get; set; }
        public string city { get; set; }
        public string zip { get; set; }
        public string state { get; set; }
        public string street { get; set; }
    }
}
