 <%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="usingwebservices._default" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
   
     <script src="https://www.amcharts.com/lib/3/ammap.js" type="text/javascript"></script>
    <script src="https://www.amcharts.com/lib/3/maps/js/worldHigh.js" type="text/javascript"></script>
    <script src="https://www.amcharts.com/lib/3/themes/dark.js" type="text/javascript"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script>
       

        //binding the map to the div for the weather location
        var weatherMap = AmCharts.makeChart("weatherMap", {
            type: "map",
            theme: "dark",
            projection: "equirectangular",
            panEventsEnabled: true,
            backgroundColor: "#535364",
            backgroundAlpha: 1,
            zoomControl: {
                zoomControlEnabled: false
            },
            dataProvider: {
                map: "worldHigh",
                getAreasFromMap: true,
                areas:
                []
            },
            // css colours used for the layout and hover over when clicked 
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
     
        //add a list for when a country is clicked, to go to the service and get the weather
        weatherMap.addListener("clickMapObject", function (event) {
            $.ajax({
                type: "POST",
                url: "WeatherService.asmx/Degrees",
                data: { lat: event.chart.clickLatitude, lon: event.chart.clickLongitude },
                dataType: "xml",
                success: function (data) {
                    $('#weatherOutput').text('Weather at clicked location is: ' + $(data).text() + ' Celcius');
                }
            });
        });
        
    </script>
    
     <style type="text/css">
         .auto-style1 {
             text-align: center;
         }
     </style>
    
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolder4" runat="server">
   <hr ="2"/>
     <h1 class="auto-style1">Home Page for Web Service Usage Page 1</h1>
    <p>
        <hr ="2"/>
        <h2 class="auto-style1">Area Conversion </h2>
        <hr ="2"/>
    <p class="auto-style1">Please enter a number and then choose from the drop down lists and press convert for an anwser.</p>
        <div class="auto-style1">
            <asp:TextBox runat="server" Width="60" ID="txtArea"></asp:TextBox> <asp:DropDownList runat="server" ID="ddlFromArea"/> To <asp:DropDownList runat="server" ID="ddlToArea"/>
            &nbsp;&nbsp;
            <asp:Button runat="server" Text="Convert" ID="btnConvertArea" OnClick="btnConvertArea_OnClick"/> 
            &nbsp;&nbsp;&nbsp; 
            <asp:Label runat="server" ID="lblAreaAnwser"></asp:Label> 
        </div>
    </p>
    <hr ="2"/>
    <p>
        <h2 class="auto-style1">Computer Conversion&#39;s</h2>
        <hr ="2"/>
    <p class="auto-style1">Please enter a number and then select from the drop down menus for example 1024 megabytes to gigabytes should = 1 when pressed on the button.</p>
    <p class="auto-style1">&nbsp;</p>
        <div class="auto-style1">
            <asp:TextBox runat="server" Width="60" ID="txtComp"></asp:TextBox> <asp:DropDownList runat="server" ID="ddlFromComp"/> To <asp:DropDownList runat="server" ID="ddlToComp"/>
            &nbsp;
            <asp:Button runat="server" Text="Convert" ID="btnConvertComputer" OnClick="btnConvertComputer_OnClick"/> 
            &nbsp;&nbsp;&nbsp; 
            <asp:Label runat="server" ID="lblCompAnwser"></asp:Label> 
        </div>
    </p>
    <hr ="2"/>
    <p>
        <h2 class="auto-style1">Degrees Conversion made easy</h2>
        <hr ="2"/>
    <p class="auto-style1">Please enter a number and then press convert for example, 25 to F should = 77.</p>
        <div class="auto-style1">
            <asp:TextBox runat="server" Width="154px" Placeholder="&#176;C" ID="txtC"></asp:TextBox> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; To&nbsp;&nbsp;&#176;F&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
            <asp:Button runat="server" Text="Convert" ID="btnConvertCToF" OnClick="btnConvertCToF_OnClick"/> 
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
            <asp:Label runat="server" ID="lblFAnwser"></asp:Label> 
        </div>
        <div class="auto-style1">
            <asp:TextBox runat="server" Width="154px" Placeholder="&#176;F" ID="txtF"></asp:TextBox> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; To&nbsp;&nbsp;&nbsp;&nbsp; °C&nbsp; 
            <asp:Button runat="server" Text="Convert" ID="btnConvertFToC" OnClick="btnConvertFToC_OnClick"/> 
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
            <asp:Label runat="server" ID="lblCAnwser"></asp:Label>  
        &nbsp;&nbsp;&nbsp;  
        </div>
    </p>
    <hr ="2"/>
    <p>
        <h2 class="auto-style1">Currency converter please select from drop down list</h2>
        <hr ="2"/>
        <div class="auto-style1">
            <asp:DropDownList runat="server" ID="ddlCountryForExRate" AutoPostBack="True" OnSelectedIndexChanged="ddlCountryForExchangeRate_OnSelectedIndexChanged"/> 
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
            <asp:Label runat="server" ID="lblExRateAnwser"></asp:Label> 
            <br />
            <br />
            Please enter a number for example, 200 and then choose from the drop down list and press convert to reveal the anwser.<br />
            <br />
        </div>
        <div class="auto-style1">
            <asp:TextBox runat="server" Width="100px" ID="txtGBP" Placeholder="£"></asp:TextBox> &nbsp;To&nbsp;&nbsp;&nbsp; <asp:DropDownList runat="server" ID="ddlCountryForExRateCalculation"/>
            &nbsp;
            <asp:Button runat="server" Text="Convert" ID="btnCalcExValue" OnClick="btnCalculateExchangedValue_OnClick"/> 
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
            <asp:Label runat="server" ID="lblExcRateCalcanwser"></asp:Label> 
        </div>
    </p>
   <hr ="2"/>
    <p>
  
    
      <h2 class="auto-style1">Weather open map service Please click on the map to show resullts as text</h2> &nbsp;
        <hr ="2"/>
        <div id="weatherOutput"/>
    </p>
    
    <p>
        <div id="weatherMap" style="width: 1000px; height: 450px; text-align: center;"></div>
    </p>
    <hr ="2"/>

    
    <p>


    </p>
    <br/>
 </asp:Content>