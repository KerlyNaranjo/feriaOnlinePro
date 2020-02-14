<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="registro.aspx.cs" Inherits="App1.registro" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
	<script type="text/javascript">
		function Numeros(string) {//solo letras y numeros
			var out = '';
			//Se añaden solo numeros
			var filtro = '1234567890';//Caracteres validos

			for (var i = 0; i < string.length; i++)
				if (filtro.indexOf(string.charAt(i)) != -1)
					out += string.charAt(i);
			return out;
			// return tx.toUpperCase();
		}
	</script>
	<div class="section">
			<!-- container -->
			<div class="container">
				<!-- row -->
				<div class="row">

					<div class="col-md-7">
						<div class="billing-details">
							<div class="section-title">
								<h3 class="title">Registro Clientes</h3>
							</div>
							<div class="form-group">
								<input class="input" type="text" name="first-name" id="txtced" placeholder="Cédula" runat="server" onkeyup="this.value=Numeros(this.value)">
							    <asp:RequiredFieldValidator runat="server" ControlToValidate="txtced"
                                CssClass="text-danger" ErrorMessage="Ingrese su numero de cédula." />
							</div>
							<div class="form-group">
								<input class="input" type="text" name="first-name" id="txtnom" placeholder="Nombres" runat="server">
							   <asp:RequiredFieldValidator runat="server" ControlToValidate="txtnom"
                                CssClass="text-danger" ErrorMessage="Ingrese su nombre." />
							</div>
							<div class="form-group">
								<input class="input" type="text" name="first-name" id="txtape" placeholder="Apellidos" runat="server">
							     <asp:RequiredFieldValidator runat="server" ControlToValidate="txtape"
                                CssClass="text-danger" ErrorMessage="Ingrese su apellido." />
							</div>
							<div class="form-group">
								<input class="input" type="text" name="first-name" id="txtdir" placeholder="Dirección" runat="server">
							     <asp:RequiredFieldValidator runat="server" ControlToValidate="txtdir"
                                CssClass="text-danger" ErrorMessage="Ingrese su dirección." />
							</div>
							<div class="form-group">
								<input class="input" type="text" name="first-name" id="txttel" placeholder="Teléfono" runat="server">
							     <asp:RequiredFieldValidator runat="server" ControlToValidate="txttel"
                                CssClass="text-danger" ErrorMessage="Ingrese su número de teléfono." />
							</div>
							<div class="form-group">
								 <asp:TextBox runat="server" ID="txtema" CssClass="input" TextMode="Email" placeholder="Su usuario sera su email"/>
							      <asp:RequiredFieldValidator runat="server" ControlToValidate="txtema"
                                CssClass="text-danger" ErrorMessage="Ingrese su correo." />
							</div>
							<div class="form-group">
								  <asp:TextBox runat="server" ID="txtpass" TextMode="Password" CssClass="input" />
							       <asp:RequiredFieldValidator runat="server" ControlToValidate="txtpass"
                                CssClass="text-danger" ErrorMessage="Ingrese su clave." />
							</div>
							<div class="form-group">
								  <asp:TextBox runat="server" ID="txtpass2" TextMode="Password" CssClass="input" />
							      <asp:RequiredFieldValidator runat="server" ControlToValidate="txtpass2"
                                CssClass="text-danger" ErrorMessage="Ingrese su clave nuevamente" />
								<asp:Label ID="valpass" runat="server" Text="" ForeColor="Red"></asp:Label>
							</div>
							<div class="form-group">
								<asp:DropDownList ID="conbuser" runat="server" CssClass="input">
									<asp:ListItem Value="2">Artesano</asp:ListItem>
									<asp:ListItem Value="1">Consumidor</asp:ListItem>
								</asp:DropDownList>
							</div>
							<div class="form-group">
								<asp:Button ID="btnguardar" runat="server" Text="Guardar" CssClass="btn btn-default" OnClick="btnguardar_Click" />
								 
							</div>
							<div class="form-group">
							<asp:Label ID="lblerror" runat="server" Text=""></asp:Label>
							</div>
					</div>
				 </div>
               </div>
			</div>
	 </div>
</asp:Content>
