<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="NuevaMarca.aspx.cs" Inherits="MiCRM.NuevaMarca" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="container">
        <h2>Cargar Nueva Marca</h2>
        <asp:Label ID="lblMensaje" runat="server" CssClass="text-danger" Visible="false"></asp:Label>
        <div class="form-group">
            <asp:Label ID="lblNombre" runat="server" AssociatedControlID="txtNombre" Text="Nombre de la Marca"></asp:Label>
            <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" MaxLength="50" />
            
        </div>
        <asp:Button ID="btnGuardar" runat="server" Text="Guardar Marca" CssClass="btn btn-primary" OnClick="btnGuardar_Click" />
    </div>


</asp:Content>
