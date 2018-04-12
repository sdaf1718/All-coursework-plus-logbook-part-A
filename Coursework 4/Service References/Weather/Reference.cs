﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace usingwebservices.Weather {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="Weather.WeatherServiceSoap")]
    public interface WeatherServiceSoap {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ConvertCelciusToFahrenheit", ReplyAction="*")]
        double ConvertCelciusToFahrenheit(double degrees);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ConvertCelciusToFahrenheit", ReplyAction="*")]
        System.Threading.Tasks.Task<double> ConvertCelciusToFahrenheitAsync(double degrees);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ConvertFahrenheitToCelcius", ReplyAction="*")]
        double ConvertFahrenheitToCelcius(double degrees);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ConvertFahrenheitToCelcius", ReplyAction="*")]
        System.Threading.Tasks.Task<double> ConvertFahrenheitToCelciusAsync(double degrees);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Degrees", ReplyAction="*")]
        double Degrees(decimal lat, decimal lon);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Degrees", ReplyAction="*")]
        System.Threading.Tasks.Task<double> DegreesAsync(decimal lat, decimal lon);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface WeatherServiceSoapChannel : usingwebservices.Weather.WeatherServiceSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class WeatherServiceSoapClient : System.ServiceModel.ClientBase<usingwebservices.Weather.WeatherServiceSoap>, usingwebservices.Weather.WeatherServiceSoap {
        
        public WeatherServiceSoapClient() {
        }
        
        public WeatherServiceSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public WeatherServiceSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WeatherServiceSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WeatherServiceSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public double ConvertCelciusToFahrenheit(double degrees) {
            return base.Channel.ConvertCelciusToFahrenheit(degrees);
        }
        
        public System.Threading.Tasks.Task<double> ConvertCelciusToFahrenheitAsync(double degrees) {
            return base.Channel.ConvertCelciusToFahrenheitAsync(degrees);
        }
        
        public double ConvertFahrenheitToCelcius(double degrees) {
            return base.Channel.ConvertFahrenheitToCelcius(degrees);
        }
        
        public System.Threading.Tasks.Task<double> ConvertFahrenheitToCelciusAsync(double degrees) {
            return base.Channel.ConvertFahrenheitToCelciusAsync(degrees);
        }
        
        public double Degrees(decimal lat, decimal lon) {
            return base.Channel.Degrees(lat, lon);
        }
        
        public System.Threading.Tasks.Task<double> DegreesAsync(decimal lat, decimal lon) {
            return base.Channel.DegreesAsync(lat, lon);
        }
    }
}