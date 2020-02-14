<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="pedidos.aspx.cs" Inherits="App1.pedidos" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<div class="container">
   <div class="row">
	 <div class="col-xs-12 col-sm-6 col-md-6">
	<center>
		 <asp:Label ID="lblep" runat="server" Text=""></asp:Label>
		<div runat="server" id="divdetalle1">
		<h1>Pedidos</h1>
		 
		<table id="example" class="table table-striped table-bordered" style="font-size: 10px;">
		<thead>
			<tr>
				<th>CÓDIGO</th>
				<th>CLIENTE</th>
				<th>CANTIDAD</th>
				<th>SUBTOTAL</th>
				<th>TOTAL</th>
				<th>ESTADO</th>
				<th></th>
				<th></th>
				<th></th>
			</tr>
		</thead>
		<tbody>
       
		<asp:Repeater ID="rptPedidos" runat="server">
              <ItemTemplate>
				   <tr>
					  <td><%# Eval("IDPED") %></td>
					  <td><%# Eval("CLIENTE") %></td>
					  <td><%# Eval("CANTIDAD") %></td>
					  <td><%# Eval("SUBTOTAL") %></td>
					  <td><%# Eval("TOTAL") %></td>
					   <td><%# Eval("ESTADO") %></td>
					   <td>
                      <asp:ImageButton ID="btnver" runat="server" CommandArgument='<%#Eval("IDPED")%>' OnClick="btnver_Click" ImageUrl="~/imgs/ver.png" Width="20" Height="20"></asp:ImageButton>
					   </td>
					   <td>
						   <asp:ImageButton ID="btneli" runat="server" CommandArgument='<%#Eval("IDPED")%>' OnClick="btneli_Click" ImageUrl="~/imgs/eli.png" Width="20" Height="20" OnClientClick="return confirm('¿Esta seguro de querer eliminar el pedido seleccionado?');"></asp:ImageButton>
					   </td>
					   <td>
						    <asp:ImageButton ID="btncon" runat="server" CommandArgument='<%#Eval("IDPED")%>' OnClick="btncon_Click" ImageUrl="~/imgs/cheque.png" Width="20" Height="20"></asp:ImageButton>
					   </td>
				   </tr>
            </ItemTemplate>   
         </asp:Repeater> 
		</tbody>
		</table>
    </div>
	</center>
  </div>
  <div class="col-xs-6 col-md-4">
	  <div runat="server" id="divdetalle">
		  <h1>Detalle  Pedido Aprobados</h1>

		  <table id="example" class="table table-striped table-bordered" style="font-size: 10px;">
		<thead>
			<tr>
				<th>CÓDIGO</th>
				<th>PRODUCTO</th>
				<th>DESCRIPCIÓN</th>
				<th>P. UNITARIO</th>
				<th>CANTIDAD</th>
				<th>SUBTOTAL</th>
				<th>TOTAL</th>
				<th></th>
			</tr>
		</thead>
		<tbody>
		  <asp:Repeater ID="rptPedidosDetalle" runat="server">
              <ItemTemplate>
				   <tr>
					  <td><%# Eval("IDPRO") %></td>
					  <td> 
						  <asp:Image ID="Imagen" runat="server" ImageUrl='<%# Eval("IMG") %>'
                                                Width="35px" Height="35px" /> 
					  </td>
					   <td><%# Eval("DESPRO") %></td>
					  <td><%# Eval("PUDET") %></td>
					  <td><%# Eval("CANDET") %></td>
					  <td><%# Eval("SUBTOTAL") %></td>
					   <td><%# Eval("TOTAL") %></td>					  
					   <td>
						   <asp:ImageButton ID="btnelid" runat="server" CommandArgument='<%#Eval("IDDET")%>' OnClick="btnelipro_Click" ImageUrl="~/imgs/eli.png" Width="20" Height="20"></asp:ImageButton>
					   </td>
				   </tr>
            </ItemTemplate>   
         </asp:Repeater> 
       </tbody>
	  </table>
	
  </div>
	  <div runat="server" id="idv3">
		  <div class="form-group">
		     Código:  
	 
		 <label runat="server" id="txtidpd" runat="server"></label>
		  </div>
		  <div class="form-group">
		    Cliente: <label id="txtclid" runat="server"></label>
		  </div>
		  <div class="form-group">
		    Cantidad: <label id="txtcand" runat="server"></label>
		  </div>
		   <div class="form-group">
		    Subtotal: <label id="txtsubd" runat="server"></label>
		  </div>
		   <div class="form-group">
		    Total a pagar: <label id="txttotal" runat="server"></label>
		  </div>

		  <div class="form-group">
		    Dirección de entrega:  <input type="text" runat="server" class="input" id="txtde"/> 
			  <asp:Label ID="lbled" runat="server" Text="" BackColor="Red"></asp:Label>
			  <a href="javascript:gps();" ><img src="imgs/gps.png" style="width:40px; height:40px;"/></a>
		  </div>
			 <div class="form-group">

		       Latitud: <input type="text" runat="server" class="input" id="lbllat"  /> 
				 
			   Longitud:<input type="text" runat="server" class="input" id="lbllog" /> 
		 
		  </div>
		  <div class="form-group">
								<asp:DropDownList ID="conbpago" runat="server" CssClass="input">
									<asp:ListItem Value="1">Escoja su forma de pago</asp:ListItem>
									<asp:ListItem Value="2">Contra entrega</asp:ListItem>
									<asp:ListItem Value="3">Deposito Bancario</asp:ListItem>
								</asp:DropDownList>
							</div>
		   <div class="form-group">
		 <div class="form-group">
								<asp:DropDownList ID="conbentrega" runat="server" CssClass="input">
									<asp:ListItem Value="1">Escoja su forma de entrega</asp:ListItem>
									<asp:ListItem Value="2">Domicilio</asp:ListItem>
									<asp:ListItem Value="3">Agencia de la Feria</asp:ListItem>
								</asp:DropDownList>
							</div>
		   <div class="form-group">
		     <asp:Button ID="btnguardar" runat="server" Text="Guardar"  OnClientClick="return confirm('¿Esta seguro de querer confirmar el pedido seleccionado?');" OnClick="btnguardardireccion_Click" CssClass="btn btn-primary" />
			  
		  </div>
	  </div>

  </div>
 </div>
	 <asp:Label ID="lblerror" runat="server" Text="" BackColor="Red"></asp:Label>
</div>
 	
 
 
<script type="text/javascript">
	function dir(id, cli ,can,sub,total) {
		$('#desp').modal({ backdrop: 'static', keyboard: false })
	 
 
		document.getElementById("txtclid").innerHTML = cli;
		document.getElementById("txtcand").innerHTML = can;
		document.getElementById("txtsubd").innerHTML = sub;
		document.getElementById("txttotal").innerHTML =total;
	}
	function gps() {
		if (navigator.geolocation) {
			///alert("Tu navegador soporta Geolocalizacion");
		} else {
			//output.innerHTML = "<p>Tu navegador no soporta Geolocalizacion</p>";
			alert("Tu navegador no soporta Geolocalizacion");
		}

		//Obtenemos latitud y longitud
		function localizacion(posicion) {

			var lat = posicion.coords.latitude;
			var lon = posicion.coords.longitude;
			document.getElementById('<%=lbllat.ClientID %>').value = lat;
			document.getElementById('<%=lbllog.ClientID %>').value = lon;
 
		}

		function error() {
			output.innerHTML = "<p>No se pudo obtener tu ubicación</p>";

		}

		navigator.geolocation.getCurrentPosition(localizacion, error);
	}
</script>
</asp:Content>
