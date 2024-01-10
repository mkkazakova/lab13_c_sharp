using System;
using System.Collections.Generic;
using System.Text;

namespace AppForMobile
{
    public class PriceOfTariff
    {
        public int Id { get; set; }
        public uint TariffId { get; set; }
        public bool IPaddress { get; set; }
        public int Price { get; set; }
    }
}
