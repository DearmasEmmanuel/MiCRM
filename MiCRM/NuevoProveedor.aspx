<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="NuevoProveedor.aspx.cs" Inherits="MiCRM.NuevoProveedor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
        <div class="container mt-5">
            <h1>Agregar Proveedor</h1>
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
            <asp:Button ID="btnAgregarProveedor" runat="server" Text="Agregar Proveedor" OnClick="btnAgregarProveedor_Click" CssClass="btn btn-primary" />
        </div>
    
</asp:Content>
