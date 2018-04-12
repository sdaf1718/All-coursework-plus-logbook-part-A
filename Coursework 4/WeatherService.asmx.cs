using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using Newtonsoft.Json.Linq;

namespace usingwebservices
{
    /// <summary>
    
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [ScriptService]
    public class WeatherService : System.Web.Services.WebService
    {
        [WebMethod]
        public double ConvertCelciusToFahrenheit(double degrees)
        {

         

            return 1.8 * degrees + 32.0; ;
        }

        [WebMethod]
        public double ConvertFahrenheitToCelcius(double degrees)
        {
       
            return 5.0 / 9.0 * (degrees - 32);
        }
        [WebMethod]
        public double Degrees(decimal lat, decimal lon)
        {
            
            using (WebClient wc = new WebClient())
            {

              
             

                // json is a notaion of javascript which I used in Internet Databases with Ajax, Jquery and Bootstrap frameworks that can be used alongside HTML.
                var json = wc.DownloadString($"http://api.openweathermap.org/data/2.5/weather?lat={lat}&lon={lon}&appid=33ef3abc06e3dd8ae6d1db538d053618");
                dynamic response = JObject.Parse(json);
                return response.main.temp - 273.15;
            }
        }
    }
}
