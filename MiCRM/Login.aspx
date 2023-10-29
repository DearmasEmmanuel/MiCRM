<%@ Page Title="" Language="C#" MasterPageFile="~/Login.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="MiCRM.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

   <div class="container mt-5 mb-5">
    <div class="row">
        <div class="col"></div>
        <div class="col">
            <div class="card">
                <div class="card-header bg-dark text-white">
                    <h3 class="text-center">MiCRM</h3>
                </div>
                <div class="card-body">
                    <div class="mb-3">
                        <label for="txtUsuario" class="form-label">Usuario</label>
                        <asp:TextBox ID="txtUsuario" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="mb-3">
                        <label for="TxtContraseña" class="form-label">Contraseña</label>
                        <asp:TextBox ID="TxtContraseña" CssClass="form-control" TextMode="Password" runat="server"></asp:TextBox>
                    </div>
                    <div class="mb-3 form-check">
                        <input type="checkbox" class="form-check-input" id="exampleCheck1">
                        <label class="form-check-label" for="exampleCheck1">Validación de Persona</label>
                        <p>-----------------------</p>
                        <p>Administrador: admin</p>
                        <p>Contraseña: contraseñaAdmin</p>
                        <p>-----------------------</p>
                        <p>Vendedor: vendedor</p>
                        <p>Contraseña: contraseñaVendedor</p>
                    </div>
                    <asp:Label ID="lblMensajeError" runat="server" Text="" CssClass="text-danger"></asp:Label>
                    <asp:Button ID="Button1" OnClick="Button1_Click" CssClass="btn btn-primary" runat="server" Text="Iniciar Sesión" />
                </div>
            </div>
        </div>
        <div class="col"></div>
    </div>
</div>






</asp:Content>
