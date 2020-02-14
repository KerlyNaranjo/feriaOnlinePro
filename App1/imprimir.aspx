<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="imprimir.aspx.cs" Inherits="App1.imprimir" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Imprimir</title>
		<meta charset="utf-8">
		<meta http-equiv="X-UA-Compatible" content="IE=edge">
		<meta name="viewport" content="width=device-width, initial-scale=1">
		 <!-- The above 3 meta tags *must* come first in the head; any other head content must come *after* these tags -->
 

		<!-- Google font -->
		<link href="https://fonts.googleapis.com/css?family=Montserrat:400,500,700" rel="stylesheet">

		<!-- Bootstrap -->
		<link type="text/css" rel="stylesheet" href="Content/css/bootstrap.min.css"/>
		<link href="Content/css/dataTables.bootstrap.min.css" rel="stylesheet">
		  <link href="Content/css/buttons.bootstrap.min.css" rel="stylesheet">
		<!-- Slick -->
		<link type="text/css" rel="stylesheet" href="Content/css/slick.css"/>
		<link type="text/css" rel="stylesheet" href="Content/css/slick-theme.css"/>

		<!-- nouislider -->
		<link type="text/css" rel="stylesheet" href="Content/css/nouislider.min.css"/>

		<!-- Font Awesome Icon -->
		<link rel="stylesheet" href="Content/css/font-awesome.min.css">

		<!-- Custom stlylesheet -->
		<link type="text/css" rel="stylesheet" href="Content/css/style.css"/>

		<!-- HTML5 shim and Respond.js for IE8 support of HTML5 elements and media queries -->
		<!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
		<!--[if lt IE 9]>
		  <script src="https://oss.maxcdn.com/html5shiv/3.7.3/html5shiv.min.js"></script>
		  <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
		<![endif]-->
</head>
<body>
    <form id="form1" runat="server">
		<br />
       <div class="container">
		   <div class="panel panel-default">
		   <table>
			   <tr>
				   <td>
					   <img src="imgs/logo4.jpg"  width="200" height="120"/>
				   </td>
				    <td>
					   <h1>NATUR TIENDA EN LINEA</h1>
				   </td>
				     <td>
					   
				   	  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
					   
				   </td>
				     <td>
					   <h3>PEDIDO #  <asp:Label ID="lblnp" runat="server" Text="" ForeColor="Red"></asp:Label></h3>
				   </td>
			   </tr>
		   </table>
				</div>
		    <div class="panel panel-default">
			  <div class="panel-body">
				 
				 <div class="form-group">
					Cliente :  <asp:Label ID="lblcli" runat="server" Text="Label"></asp:Label>
				</div>
                  <div class="form-group">
					Télefono:  <asp:Label ID="lbltel" runat="server" Text="Label"></asp:Label>
				</div>
				  <div class="form-group">
					Email:  <asp:Label ID="lblema" runat="server" Text="Label"></asp:Label>
				</div>
                   <div class="form-group">
					Dirección:  <asp:Label ID="lbldir" runat="server" Text="Label"></asp:Label>
				</div>
				   <div class="form-group">
					Repartidor:  <asp:Label ID="lblre" runat="server" Text="Label"></asp:Label>
				</div>
				  </div>
                  
			  </div>
			

		  <div class="panel panel-default">
			  <div class="panel-body">

    	 <h3>Detalle  Pedido</h3>
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
					 
				   </tr>
            </ItemTemplate>   
         </asp:Repeater> 
       </tbody>
			<tr>
				<td colspan="6"> Subtotal</td>
				<td>  <asp:Label ID="lblsub" runat="server" Text=""></asp:Label> </td>
			</tr>
			<tr>
				<td colspan="6">Total</td>
				<td>  <asp:Label ID="lbltotal" runat="server" Text=""></asp:Label> </td>
			</tr>
		</table>
        </div>
		</div>
 </div>
		</div>
    </form>
	
		<script src="Content/js/jquery.min.js"></script>
		<script src="Content/js/jquery.dataTables.min.js"></script>
		<script src="Content/js/bootstrap.min.js"></script>		 
		 <script src="Content/js/dataTables.bootstrap.min.js"></script>
		<script src="Content/js/slick.min.js"></script>
		<script src="Content/js/nouislider.min.js"></script>
		<script src="Content/js/jquery.zoom.min.js"></script>
	 
	<asp:Label ID="lblerror" runat="server" Text=""></asp:Label>
</body>
</html>
