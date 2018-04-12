﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace usingwebservices.ConvertArea {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://www.webserviceX.NET/", ConfigurationName="ConvertArea.AreaUnitSoap")]
    public interface AreaUnitSoap {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.webserviceX.NET/ChangeAreaUnit", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        double ChangeAreaUnit(double AreaValue, usingwebservices.ConvertArea.Areas fromAreaUnit, usingwebservices.ConvertArea.Areas toAreaUnit);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.webserviceX.NET/ChangeAreaUnit", ReplyAction="*")]
        System.Threading.Tasks.Task<double> ChangeAreaUnitAsync(double AreaValue, usingwebservices.ConvertArea.Areas fromAreaUnit, usingwebservices.ConvertArea.Areas toAreaUnit);
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2612.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.webserviceX.NET/")]
    public enum Areas {
        
        /// <remarks/>
        acre,
        
        /// <remarks/>
        acrecommercial,
        
        /// <remarks/>
        acreIreland,
        
        /// <remarks/>
        acresurvey,
        
        /// <remarks/>
        are,
        
        /// <remarks/>
        baseboxtinplatedsteel,
        
        /// <remarks/>
        binTaiwan,
        
        /// <remarks/>
        buJapan,
        
        /// <remarks/>
        canteroEcuador,
        
        /// <remarks/>
        caoVietnam,
        
        /// <remarks/>
        centaire,
        
        /// <remarks/>
        circularfootinternational,
        
        /// <remarks/>
        circularfootUSsurvey,
        
        /// <remarks/>
        circularinchinternational,
        
        /// <remarks/>
        circularinchUSsurvey,
        
        /// <remarks/>
        hectare,
        
        /// <remarks/>
        laborCanada,
        
        /// <remarks/>
        laborUSsurvey,
        
        /// <remarks/>
        manzanaCostaRican,
        
        /// <remarks/>
        manzanaArgentina,
        
        /// <remarks/>
        rood,
        
        /// <remarks/>
        saoVietnam,
        
        /// <remarks/>
        scrupleancientRome,
        
        /// <remarks/>
        sectionUSsurvey,
        
        /// <remarks/>
        square,
        
        /// <remarks/>
        squareSriLanka,
        
        /// <remarks/>
        squareangstrom,
        
        /// <remarks/>
        squareastronomicalunit,
        
        /// <remarks/>
        squarecablelengthUSsurvey,
        
        /// <remarks/>
        squarecaliber,
        
        /// <remarks/>
        squarecentimeter,
        
        /// <remarks/>
        squarechainGunterUSsurvey,
        
        /// <remarks/>
        squarechainRamdenEngineer,
        
        /// <remarks/>
        squarecubit,
        
        /// <remarks/>
        squarecubitancientEgypt,
        
        /// <remarks/>
        squaredigit,
        
        /// <remarks/>
        squarefathom,
        
        /// <remarks/>
        squarefootinternational,
        
        /// <remarks/>
        squarefootUSsurvey,
        
        /// <remarks/>
        squarefurlongUSsurvey,
        
        /// <remarks/>
        squaregigameter,
        
        /// <remarks/>
        squarehectometer,
        
        /// <remarks/>
        squareinchinternational,
        
        /// <remarks/>
        squareinchUSsurvey,
        
        /// <remarks/>
        squarekilometer,
        
        /// <remarks/>
        squareleaguenautical,
        
        /// <remarks/>
        squareleagueUSstatute,
        
        /// <remarks/>
        squarelightyear,
        
        /// <remarks/>
        squarelinkGunterUSsurvey,
        
        /// <remarks/>
        squarelinkRamdenEngineer,
        
        /// <remarks/>
        squaremegameter,
        
        /// <remarks/>
        squaremeter,
        
        /// <remarks/>
        squaremicroinch,
        
        /// <remarks/>
        squaremicrometer,
        
        /// <remarks/>
        squaremicromicron,
        
        /// <remarks/>
        squaremicron,
        
        /// <remarks/>
        squaremil,
        
        /// <remarks/>
        squaremileinternational,
        
        /// <remarks/>
        squaremileintnautical,
        
        /// <remarks/>
        squaremileUSnautical,
        
        /// <remarks/>
        squaremileUSstatute,
        
        /// <remarks/>
        squaremileUSsurvey,
        
        /// <remarks/>
        squaremillimeter,
        
        /// <remarks/>
        squaremillimicron,
        
        /// <remarks/>
        squarenanometer,
        
        /// <remarks/>
        squareParisfootCanada,
        
        /// <remarks/>
        squareparsec,
        
        /// <remarks/>
        squareperchIreland,
        
        /// <remarks/>
        squareperchUSsurvey,
        
        /// <remarks/>
        squarepetameter,
        
        /// <remarks/>
        squarepicometer,
        
        /// <remarks/>
        squarerodNetherlands,
        
        /// <remarks/>
        squaretenthmeter,
        
        /// <remarks/>
        squareyardUSsurvey,
        
        /// <remarks/>
        squareyardinternational,
        
        /// <remarks/>
        squareyoctometer,
        
        /// <remarks/>
        squareyottameter,
        
        /// <remarks/>
        squarezeptometer,
        
        /// <remarks/>
        squarezettameter,
        
        /// <remarks/>
        townshipUSsurvey,
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface AreaUnitSoapChannel : usingwebservices.ConvertArea.AreaUnitSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class AreaUnitSoapClient : System.ServiceModel.ClientBase<usingwebservices.ConvertArea.AreaUnitSoap>, usingwebservices.ConvertArea.AreaUnitSoap {
        
        public AreaUnitSoapClient() {
        }
        
        public AreaUnitSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public AreaUnitSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public AreaUnitSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public AreaUnitSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public double ChangeAreaUnit(double AreaValue, usingwebservices.ConvertArea.Areas fromAreaUnit, usingwebservices.ConvertArea.Areas toAreaUnit) {
            return base.Channel.ChangeAreaUnit(AreaValue, fromAreaUnit, toAreaUnit);
        }
        
        public System.Threading.Tasks.Task<double> ChangeAreaUnitAsync(double AreaValue, usingwebservices.ConvertArea.Areas fromAreaUnit, usingwebservices.ConvertArea.Areas toAreaUnit) {
            return base.Channel.ChangeAreaUnitAsync(AreaValue, fromAreaUnit, toAreaUnit);
        }
    }
}