<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="WorldCurrency.aspx.cs" Inherits="usingwebservices.WorldCurrency" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
   
     <script src="https://www.amcharts.com/lib/3/ammap.js" type="text/javascript"></script>
    <script src="https://www.amcharts.com/lib/3/maps/js/worldHigh.js" type="text/javascript"></script>
    <script src="https://www.amcharts.com/lib/3/themes/dark.js" type="text/javascript"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script>
        //binding the map to the div for the currency from arm charts commented this code as copied and pasted from armcharts https://www.amcharts.com/
        var currencyMap = AmCharts.makeChart("currencyMap", {
            type: "map",
            theme: "dark",
            projection: "mercator",
            panEventsEnabled: true,
            backgroundColor: "#535364",
            backgroundAlpha: 1,
            zoomControl: {
                zoomControlEnabled: true // allow zoom
            },
            dataProvider: {
                map: "worldHigh",
                getAreasFromMap: true,
                areas:
                []
            },
            // settings of the colours used for the map when clicked on and how it appears 
            areasSettings: {
                autoZoom: true,
                color: "#B4B4B7",
                colorSolid: "#84ADE9",
                selectedColor: "#84ADE9",
                outlineColor: "#666666",
                rollOverColor: "#9EC2F7",
                rollOverOutlineColor: "#000000"
            }
        });

        
        currencyMap.addListener("clickMapObject", function (event) {
            $.ajax({
                type: "POST",
                url: "CurrencyService.asmx/CalculateExchangeRate",
                data: { value: 1, country: event.mapObject.title },
                dataType: "xml",
                success: function (data) { $('#countryCurrency').text('The exchange rate for ' + event.mapObject.title + ' is ' + $(data).text()); }
            });
        });
    </script>
    
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder4" runat="server">
    <div id="countryCurrency"></div>
    <div id="currencyMap" style="width: 900px; height: 450px;"></div>
    <p>Please click on the map to show the exchange rate.
    </p>
</asp:Content>
