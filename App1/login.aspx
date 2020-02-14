<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="App1.login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


<div class="section">
			<!-- container -->
			<div class="container">
				<!-- row -->
				<div class="row">

					<div class="col-md-4">
						<!-- Billing Details -->
						<div class="billing-details">
							<div class="section-title">
								<h3 class="title">Inicio de Sesión</h3>
							</div>
							<div class="form-group">
								  <asp:TextBox runat="server" ID="user" CssClass="input" TextMode="Email" />

                            <asp:RequiredFieldValidator runat="server" ControlToValidate="user"
                                CssClass="text-danger" ErrorMessage="Ingrese su usuario." />
                        
							
							
							</div>
							<div class="form-group">
								 
								 <asp:TextBox runat="server" ID="pass" TextMode="Password" CssClass="input" />
								<asp:RequiredFieldValidator runat="server" ControlToValidate="pass"
                                CssClass="text-danger" ErrorMessage="Ingrese su contraseña." />
                    
							</div>
							 <div class="form-group">
								 <asp:Button ID="btnlogin" runat="server" Text="Entrar" CssClass="btn btn-default" OnClick="btnlogin_Click"/>
							 </div>
							 
						</div>
						<!-- /Billing Details -->

						<!-- Shiping Details -->
						 
						<!-- /Shiping Details -->

						<!-- Order notes -->
						 
						<!-- /Order notes -->
					</div>

					<!-- Order Details -->
				 
					<!-- /Order Details -->
				</div>
				<!-- /row -->
			</div>
			<!-- /container -->
		</div>

</asp:Content>
