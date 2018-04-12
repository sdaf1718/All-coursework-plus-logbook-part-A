using System.Collections.Generic;
using System.ComponentModel;
using System.Web.Services;
using System;
using System.Linq;
using usingwebservices.CurrencyConvertor;

namespace usingwebservices
{
    /// <summary>
    ///     Summary description for CurrencyService
    ///guidence from https://www.codeproject.com/Articles/15483/Currency-Conversion-Using-Web-Services
    /// guidence from https://forums.asp.net/t/1297305.aspx?Currency+Conversion+Web+Service
    /// guidence from https://stackoverflow.com/questions/2220158/how-to-get-the-currency-rate-from-the-web-service as this uses vb but can be adpated to c sharp
    /// guidence from https://www.youtube.com/watch?v=ItATfVSz9AI which is created in c sharp but can be adpated 
    /// </summary>
    
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class CurrencyService : WebService
    {
        [WebMethod]
        public double ExchangeRate(string country)
        {
            return CalculateExchangeRate(1, country);
        }

        [WebMethod]
        public double CalculateExchangeRate(double value, string country)
        {
            var client = new CurrencySystemService.CurrencyServerSoapClient();
            var currency = client.CountryToCurrency(null, country, true);
            var rate = double.Parse(client.RateStr("", "GBP", currency, true, "", "", ""));
            return value * rate;
        }
    }
}