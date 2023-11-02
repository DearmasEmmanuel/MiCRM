<%@ Page Title="" Language="C#" MasterPageFile="~/Vendedor.Master" AutoEventWireup="true" CodeBehind="Venta.aspx.cs" Inherits="MiCRM.Venta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       <div class="container mt-5">
        <h1>Cargar Venta</h1>
        <div class="form-group">
            <label for="ddlClientes">Cliente:</label>
            <asp:DropDownList ID="ddlClientes" runat="server" CssClass="form-control"></asp:DropDownList>
        </div>
        <div class="form-group">
            <label for="ddlProductos">Producto:</label>
            <asp:DropDownList ID="ddlProductos" runat="server" CssClass="form-control"></asp:DropDownList>
        </div>
        <div class="form-group">
            <label for="txtCantidad">Cantidad:</label>
            <asp:TextBox ID="txtCantidad" runat="server" CssClass="form-control" TextMode="Number" />
        </div>
        <asp:Button ID="btnCargarVenta" runat="server" Text="Cargar Venta" OnClick="btnCargarVenta_Click" CssClass="btn btn-primary" />
    </div>
</asp:Content>
