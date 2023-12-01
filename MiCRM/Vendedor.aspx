<%@ Page Title="" Language="C#" MasterPageFile="~/Vendedor.Master" AutoEventWireup="true" CodeBehind="Vendedor.aspx.cs" Inherits="MiCRM.WebForm2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-5">
        <h1 class="mb-4">Bienvenido
            <asp:Label ID="lblUsuario" runat="server" Text="Label"></asp:Label></h1>




        <hr>
        <
        <div class="mb-3">
            <label for="txtCliente">Buscar Producto:</label>
            <asp:TextBox ID="txtCliente" runat="server" CssClass="form-control" placeholder="Ingrese nombre del Producto"></asp:TextBox>
            <asp:Button ID="btnBuscarProducto1" runat="server" Text="Buscar Producto" CssClass="btn btn-outline-primary" OnClick="btnBuscarProducto_Click1" />
        </div>

        <asp:TextBox ID="txtProducto" runat="server" CssClass="form-control" placeholder="Ingrese el nombre del Producto"></asp:TextBox>
        <!-- <asp:Button ID="btnBuscarProducto" runat="server" Text="Buscar Producto" CssClass="btn btn-outline-primary" OnClick="btnBuscarProducto_Click" />-->

        <asp:DropDownList ID="ddlMarca" runat="server" class="form-control" OnSelectedIndexChanged="ddlMarca_SelectedIndexChanged"></asp:DropDownList>



        <asp:DropDownList ID="ddlCategoria" runat="server" class="form-control" OnSelectedIndexChanged="ddlCategoria_SelectedIndexChanged"></asp:DropDownList>
        <asp:Button ID="btnFiltroProducto" class="btn btn-primary mt-2" runat="server" Text="Aplicar Filtros" OnClick="btnFiltroProducto_Click" />




        <div class="container mt-5">
            <h1>Listado de Productos</h1>
            <div id="productosContainer">


                <asp:GridView ID="gvStock" runat="server" CssClass="table table-bordered" AutoGenerateColumns="false">

                    <Columns>
                        <asp:BoundField DataField="Nombre" HeaderText="Nombre del Producto" />
                        <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" />
                        <asp:BoundField DataField="StockActual" HeaderText="Stock Actual" />
                        <asp:BoundField DataField="StockMinimo" HeaderText="Stock Mínimo" />
                    </Columns>

                </asp:GridView>
            </div>
        </div>

    </div>

</asp:Content>
