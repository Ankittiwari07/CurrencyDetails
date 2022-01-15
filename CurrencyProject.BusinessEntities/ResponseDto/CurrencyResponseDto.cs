using System;
using System.Collections.Generic;
using System.Text;

namespace CurrencyProject.BusinessEntities.ResponseDto
{
    public class CurrencyResponseDto
    {

    }

    // CurrencyMaster myDeserializedClass = JsonConvert.DeserializeObject<CurrencyMaster>(myJsonResponse);
    public class CurrencyMaster
    {
        public string Country { get; set; }
        public string CurrencyName { get; set; }
        public string eur { get; set; }
        public string btc { get; set; }
    }


}
