<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="ModificarMarca.aspx.cs" Inherits="MiCRM.ModificarMarca" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="container">
        <h2>Modificar / Eliminar Marca</h2>
        <asp:Label ID="lblMensaje" runat="server" CssClass="text-danger" Visible="false"></asp:Label>
        <div class="form-group">
            <asp:Label ID="lblSeleccionarMarca" runat="server" Text="Selecciona una Marca"></asp:Label>
            <asp:DropDownList ID="ddlMarcas" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlMarcas_SelectedIndexChanged"></asp:DropDownList>
        </div>
        <div class="form-group">
            <asp:Label ID="lblNombre" runat="server" AssociatedControlID="txtNombre" Text="Nombre de la Marca"></asp:Label>
            <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" MaxLength="50" />
        </div>
        <asp:Button ID="btnModificar" runat="server" Text="Modificar Marca" CssClass="btn btn-primary" OnClick="btnModificar_Click" />
        <asp:Button ID="btnEliminar" runat="server" Text="Eliminar Marca" CssClass="btn btn-danger" OnClick="btnEliminar_Click" />
    </div>
</asp:Content>
