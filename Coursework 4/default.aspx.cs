using System;
using System.Web.UI;
using usingwebservices.ConvertArea;
using usingwebservices.ConvertComputer;
using usingwebservices.Currency;
using usingwebservices.Weather;

namespace usingwebservices
{
    public partial class _default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if this form has not been submitted itself, fill the  drop downs from the services
            if (!IsPostBack)
            {
                foreach (string area in Enum.GetNames(typeof (Areas))) //enumerate the values in the enum
                {
                    ddlFromArea.Items.Add(area); //add each to drop down as the drop down name is DDLFromArea
                    ddlToArea.Items.Add(area);
                }

                foreach (string comp in Enum.GetNames(typeof (Computers)))
                {
                    ddlFromComp.Items.Add(comp);
                    ddlToComp.Items.Add(comp);
                }

                ddlCountryForExRate.Items.Add(" Select Country "); //adds default value
                foreach (var country in Enum.GetNames(typeof(Country)))
                {
                    ddlCountryForExRate.Items.Add(country);
                    ddlCountryForExRateCalculation.Items.Add(country);
                }
            }
        }

        protected void btnConvertCToF_OnClick(object sender, EventArgs e)
        {
            //finds the service 
            var weatherServiceSoapClient = new WeatherServiceSoapClient();

            //calls calculations and set it to the text of the label
            lblFAnwser.Text = "= " + weatherServiceSoapClient.ConvertCelciusToFahrenheit(Convert.ToDouble(txtC.Text));
        }

        protected void btnConvertFToC_OnClick(object sender, EventArgs e)
        {
            //finds the service 
            var weatherServiceSoapClient = new WeatherServiceSoapClient();

            //call calculation and set it to the text of the label
            lblCAnwser.Text = "= " + weatherServiceSoapClient.ConvertFahrenheitToCelcius(Convert.ToDouble(txtF.Text));
        }

        protected void btnConvertArea_OnClick(object sender, EventArgs e)
        {
            var areaUnitSoapClient = new AreaUnitSoapClient();

            lblAreaAnwser.Text = "= " + areaUnitSoapClient.ChangeAreaUnit(Convert.ToDouble(txtArea.Text),
                (Areas) Enum.Parse(typeof (Areas), ddlFromArea.SelectedValue), //convert value in drop down to the matching suitable value
                (Areas) Enum.Parse(typeof (Areas), ddlToArea.SelectedValue));
        }

        protected void btnConvertComputer_OnClick(object sender, EventArgs e)
        {
            var computerUnitSoapClient = new ComputerUnitSoapClient();

            // enum can be float, interger or double etc and is a type that can be used also to create numerica values in .NET frameworks


            lblCompAnwser.Text = "= " + computerUnitSoapClient.ChangeComputerUnit(Convert.ToDouble(txtComp.Text),
                (Computers) Enum.Parse(typeof (Computers), ddlFromComp.SelectedValue), 
                (Computers) Enum.Parse(typeof (Computers), ddlToComp.SelectedValue));
        }

        protected void ddlCountryForExchangeRate_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlCountryForExRate.SelectedValue == " Select Country ")
            {
                lblExRateAnwser.Text = "";
                return;
            }

            var currencyServiceSoapClient = new CurrencyServiceSoapClient();

            lblExRateAnwser.Text = " Exchange rate is: " +
                                   currencyServiceSoapClient.ExchangeRate(ddlCountryForExRate.SelectedValue);
        }

        protected void btnCalculateExchangedValue_OnClick(object sender, EventArgs e)
        {
            var currencyServiceSoapClient = new CurrencyServiceSoapClient();

            lblExcRateCalcanwser.Text = " = " + currencyServiceSoapClient.CalculateExchangeRate(Convert.ToDouble(txtGBP.Text), ddlCountryForExRateCalculation.SelectedValue);
        }
    }
}