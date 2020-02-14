<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="contactos.aspx.cs" Inherits="App1.contactos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
	<div class="section">
			<div class="container">
				<!-- row -->
				<div class="row">

					<div class="col-md-7">
						<div class="billing-details">
							<div class="section-title">
								<h3 class="title">Mensajes y Sugerencias </h3>
							</div>
							<div class="form-group">
								<input class="input" type="text" name="first-name" id="txtnom" placeholder="Nombres y Apellidos" runat="server">
							    <asp:RequiredFieldValidator runat="server" ControlToValidate="txtnom"
                                CssClass="text-danger" ErrorMessage="Ingrese su nombre y apellido." />
							</div>
							<div class="form-group">
								<input class="input" type="text" name="first-name" id="txttel" placeholder="Número de Telefono" runat="server">
							   <asp:RequiredFieldValidator runat="server" ControlToValidate="txttel"
                                CssClass="text-danger" ErrorMessage="Ingrese su número de telefono." />
							</div>
							<div class="form-group">
							  <asp:TextBox runat="server" ID="txtema" CssClass="input" TextMode="Email" placeholder="Correo electronico" />

                            <asp:RequiredFieldValidator runat="server" ControlToValidate="txtema"
                                CssClass="text-danger" ErrorMessage="Ingrese su direccion de correo." />
							</div>
							<div class="form-group">
								 <textarea id="txtmen" runat="server" style="width:100%; height:160px;"></textarea>
							     <asp:RequiredFieldValidator runat="server" ControlToValidate="txtmen"
                                CssClass="text-danger" ErrorMessage="Ingrese un Mensaje." />
							</div>
						 
							<div class="form-group">
								<asp:Button ID="btnguardar" runat="server" Text="Enviar" CssClass="btn btn-default"   />
								 
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
