<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Producto.aspx.cs" Inherits="MiCRM.Producto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:GridView ID="dgvProductos" CssClass="table table-striped" DataKeyNames="ProductoID" runat="server" AutoGenerateColumns="false">

        <Columns>
            <asp:BoundField HeaderText="ProductoID" DataField="ProductoID" HeaderStyle-CssClass="oculto" ItemStyle-CssClass="oculto" />
            <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
            <asp:BoundField HeaderText="Descripcion" DataField="Descripcion" />
            <asp:BoundField HeaderText="Marca" DataField="Marca.Nombre" />
            <asp:BoundField HeaderText="Categoria" DataField="Categoria.Nombre" />
            <asp:CommandField ShowSelectButton="true" SelectText="Seleccionar" HeaderText="Modificar/Eliminar" />

        </Columns>

    </asp:GridView>

</asp:Content>
