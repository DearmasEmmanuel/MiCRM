<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="ModificarProveedor.aspx.cs" Inherits="MiCRM.ModificarProveedor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
        <div class="container mt-5">
            <h1>Modificar Proveedor</h1>
            <div class="form-group">
                <label for="ddlProveedores">Selecciona un Proveedor:</label>
                <asp:DropDownList ID="ddlProveedores" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlProveedores_SelectedIndexChanged"></asp:DropDownList>
            </div>
            <div class="form-group">
                <label for="txtNombre">Nombre:</label>
                <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" />
            </div>
            <div class="form-group">
                <label for="txtDireccion">Dirección:</label>
                <asp:TextBox ID="txtDireccion" runat="server" CssClass="form-control" />
            </div>
            <div class="form-group">
                <label for="txtContacto">Telefono:</label>
                <asp:TextBox ID="txtContacto" runat="server" CssClass="form-control" />
            </div>
                        <div class="form-group">
                <label for="txtDNI">DNI:</label>
                <asp:TextBox ID="txtDNI" runat="server" CssClass="form-control" />
            </div>
                        <div class="form-group">
                <label for="txtEmail">Email:</label>
                <asp:TextBox ID="TxtEmail" runat="server" CssClass="form-control" />
            </div>
            <asp:Button ID="btnModificarProveedor" runat="server" Text="Modificar Proveedor" OnClick="btnModificarProveedor_Click" CssClass="btn btn-primary" />
            <asp:Button ID="btnEliminarProveedor" runat="server" Text="Eliminar Proveedor" OnClick="btnEliminarProveedor_Click" CssClass="btn btn-danger" />
        </div>
    
</asp:Content>
