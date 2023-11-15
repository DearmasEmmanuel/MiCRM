<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="UsuariosAdmin.aspx.cs" Inherits="MiCRM.UsuariosAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container mt-5">
        <h1>Crear Usuario</h1>
        <div class="form-group">
            <label for="txtNombreUsuario">Nombre de Usuario:</label>
            <asp:TextBox ID="txtNombreUsuario" runat="server" CssClass="form-control" />
        </div>
        <div class="form-group">
            <label for="txtContraseña">Contraseña:</label>
            <asp:TextBox ID="txtContraseña" runat="server" TextMode="Password" CssClass="form-control" />
        </div>
        <div class="form-group">
            <label for="ddlRol">Rol:</label>
            <asp:DropDownList ID="ddlRol" runat="server" CssClass="form-control">
                <asp:ListItem Text="Seleccionar Rol" Value="" />
                <asp:ListItem Text="Administrador" Value="Administrador" />
                <asp:ListItem Text="Vendedor" Value="Vendedor" />
            </asp:DropDownList>
        </div>
        <asp:Button ID="btnCrearUsuario" runat="server" Text="Crear Usuario" OnClick="btnCrearUsuario_Click" CssClass="btn btn-primary" />
        <div class="container mt-5">
            <h1>Listado de Usuario</h1>
            <div id="UsuarioContainer">
                <asp:GridView ID="gvUser" runat="server" CssClass="table table-bordered" AutoGenerateColumns="false">

                    <Columns>
                        <asp:BoundField DataField="Usuario" HeaderText="UsuarioId" />
                        <asp:BoundField DataField="Nombre" HeaderText="NombreUsuario" />
                        <asp:BoundField DataField="Contraseña" HeaderText="Contraseña" />
                        <asp:BoundField DataField="Rol" HeaderText="Rol" />
                    </Columns>

                </asp:GridView>
            </div>
        </div>
    </div>

</asp:Content>
