<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="googlemaps._default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <style type="text/css">
        .auto-style1 {
            text-align: center;
        }
        .auto-style2 {
            text-align: center;
            text-decoration: underline;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder4" runat="server">


    <script async defer src="http://maps.googleapis.com/maps/api/js?key=AIzaSyDCEf0Q2dwZ4xg8nZWHXmfUtPYYLQWqp1A&callback=initialize"></script>
	
	<script type="text/javascript">


	    // for this google map service I have followed this tutuiral and taken some code from it https://www.codeproject.com/Articles/291499/Google-Maps-API-V-for-ASP-NET
	    // gudience from here https://blog.learningtree.com/combining-google-maps-with-asp-net-web-forms-part-1/ and https://www.youtube.com/watch?v=lRoAjs8RwfE
	    // declaration of lcoal variables
		var mapGcode; // google service will be using geocode
		var GMap; // google service will be used for the map
		var googledirecservice; // google direction service will be used
		var googledirecdis; // google direction display will be used 
		var messagewindalert; // error message to inform the user if cannot find the what has been entered 

		function initialize() {

		    

		    googledirecservice = new google.maps.DirectionsService();
		    googledirecdis = new google.maps.DirectionsRenderer;
		    messagewindalert = new google.maps.InfoWindow;
		    mapGcode = new google.maps.Geocoder();
			var latlng = new google.maps.LatLng(52.569499, -0.24053);
			var options =
				{
					zoom: 8,
					center: new google.maps.LatLng(52.569499, -0.24053), 
					mapTypeId: google.maps.MapTypeId.ROADMAP,
					mapTypeControl: true,
					mapTypeControlOptions:
					{
						// If style is not specified, it defaults to buttons
						style: google.maps.MapTypeControlStyle.DROPDOWN_MENU, // display map types as drop down menu
						poistion: google.maps.ControlPosition.TOP_RIGHT, // poisiton of the buttons
                        // display of map views
						mapTypeIds: [google.maps.MapTypeId.HYBRID, google.maps.MapTypeId.TERRAIN, google.maps.MapTypeId.HYBRID, google.maps.MapTypeId.SATELLITE]
					},
					navigationControl: true,
					navigationControlOptions:
					{
						style: google.maps.NavigationControlStyle.ZOOM_PAN // sytle taken from microsoft 
					},
					scaleControl: true,
					disableDoubleClickZoom: true,
					streetViewControl: true,
					draggableCursor: 'move'
				};
			GMap = new google.maps.Map(document.getElementById("map"), options);
			googledirecdis.setMap(GMap);
		}
        // functions used to ger the adddress for the textboxes
		function doLocation() {
			var houseNo = document.getElementById('ContentPlaceHolder4_TextBox1').value;
			var street = document.getElementById('ContentPlaceHolder4_TextBox2').value;
			var city = document.getElementById('ContentPlaceHolder4_TextBox3').value;
			var postcode = document.getElementById('ContentPlaceHolder4_TextBox4').value;

			mapGcode.geocode({ componentRestrictions: { country: 'GB', postalCode: postcode } }, function (res, status) {
			    if (status == google.maps.GeocoderStatus.OK) {
			        document.getElementById('ContentPlaceHolder4_TextBox2').value = res[0].address_components[1].long_name;
			        document.getElementById('ContentPlaceHolder4_TextBox3').value = res[0].address_components[2].long_name;
			        var address = houseNo + " " + street + " " + city + " " + postcode;
			        mapGcode.geocode({ address: address, componentRestrictions: { country: 'GB', postalCode: postcode } }, function (cres, cstatus) {
			            if (cstatus == google.maps.GeocoderStatus.OK) {
			                GMap.setCenter(cres[0].geometry.location);
			                GMap.setZoom(11);
			                var markerpoint = new google.maps.Marker({ 'map': GMap, 'position': cres[0].geometry.location });
			                messagewindalert.setContent(cres[0].formatted_address);
			                messagewindalert.open(theMap, markerpoint);

			                document.getElementById('ContentPlaceHolder4_TextBox1').value = cres[0].formatted_address;
			            }
			        });
				}
				else {
					alert("Failed or inccorrect details. Status: " + status);
				}
			});
		}
        // function used for the travel directions and markers
		function doTravel() {			
			var cause = document.getElementById("travelfrom").value; // gets value from the textbox
			var journey = document.getElementById("travelto").value; // gets value from textbox
			var request = {
				origin: cause, // start from the source 
				destination: journey,
				travelMode: 'DRIVING' // the travel mode set to driving can be set to walking 
			};

		    // a lot of help and some code has been taken from https://stackoverflow.com/questions/3251609/how-to-get-total-driving-distance-with-google-maps-api-v3

			googledirecservice.route(request, function (response, status) {
			    if (status == google.maps.DirectionsStatus.OK) {
			        var EndJourneyDis = 0; // this is the total distance 
			        var EndJourneydura = 0; // this is the total duration taken
			        var legs = response.routes[0].legs;
			        for (var i = 0; i < legs.length; ++i) {
			            EndJourneyDis += legs[i].distance.value;
			            EndJourneydura += legs[i].duration.value;
			        }
			        alert('Distance: ' + EndJourneyDis + ' meters, Duration: ' + EndJourneydura / 60 + ' minutes');
				    googledirecdis.setDirections(response);
				}
                    // else display a message alerting user cannot find what they have entered
				else {
					alert("Directions have failed please refresh or try again: " + status);  
				}
			});
		}
		//window.onload = initialize;
	</script>



	<h2 class="auto-style2">Welcome to google maps</h2>
    <p>&nbsp;</p>
    <p>&nbsp;</p>
    <p>&nbsp;</p>
    <p>&nbsp;</p>
    <p>&nbsp;</p>
    <p>&nbsp;&nbsp;</p>
    <p>&nbsp;</p>
    <p>&nbsp;</p>
    <p>&nbsp;</p> <hr=2 />
    <p class="auto-style1">
        &nbsp;</p>
    <p class="auto-style1">
        &nbsp;</p>
    <p class="auto-style1">
        <strong>
        <asp:Label ID="Label1" runat="server" Text="Please fill in by number and post code your address will be autofilled by google maps"></asp:Label>
        &nbsp;</strong></p>
    <p class="auto-style2">
        <strong><em>Please Cick Get address after the address has been filled in the textboes to show the location point on the map.</em></strong></p>
    <p class="auto-style1">
         &nbsp;</p> <hr=2 />
    <p class="auto-style1"><strong>&nbsp;&nbsp;&nbsp;&nbsp; House no&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        </strong>
    </p>
    <p class="auto-style1"><strong>&nbsp;&nbsp;&nbsp;&nbsp; Street&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        </strong>
    </p>
    <p class="auto-style1"><strong>&nbsp;&nbsp;&nbsp;&nbsp; City&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
        </strong>
    </p>
    <p class="auto-style1"><strong>&nbsp;&nbsp;&nbsp;&nbsp; Postcode&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
        </strong>
    </p>
    <p>&nbsp;</p>
    <p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
        <input type="button" value="Get address" onclick="doLocation()"/>
    </p> <hr=2 />
    <p>&nbsp;</p>
    <p class="auto-style2"><strong>Please type in places to calculate the route of your trip</strong></p>
    <p class="auto-style2">&nbsp;</p>
    <p class="auto-style1">&nbsp;<strong>
                                Travel From : <input id="travelfrom" type="text" name="name" value="" />
                </strong>

    </p>
    <p class="auto-style1">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <strong>To :&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <input id="travelto" type="text" name="name" value="" /></strong> <strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </strong>

    </p>
    <p class="auto-style1">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <strong>&nbsp;<input type="button" value="Get Route" onclick="doTravel()" /></strong>

    </p>
    <p>&nbsp;</p>
<div id ="map"   style="width: 500px; top: 488px; left: 513px; position: absolute; height: 238px; text-align: center;">
    // above map the sytle and how it will appear on the screen and the size

</div>


  

</asp:Content>