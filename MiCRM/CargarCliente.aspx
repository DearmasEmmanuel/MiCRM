<%@ Page Title="" Language="C#" MasterPageFile="~/Vendedor.Master" AutoEventWireup="true" CodeBehind="CargarCliente.aspx.cs" Inherits="MiCRM.CargarCliente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="container mt-5">

    <h1>Cargar Cliente</h1>
    <div class="form-group">
        <label for="txtNombre">Nombre:</label>
        <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" />
    </div>
    <div class="form-group">
        <label for="txtDireccion">Dirección:</label>
        <asp:TextBox ID="txtDireccion" runat="server" CssClass="form-control" />
    </div>
    <div class="form-group">
        <label for="txtContacto">Contacto:</label>
        <asp:TextBox ID="txtContacto" runat="server" CssClass="form-control" />
    </div>
    <asp:Button ID="btnCargarCliente" runat="server" Text="Cargar Cliente" OnClick="btnCargarCliente_Click" CssClass="btn btn-primary" />
</div>

</asp:Content>
