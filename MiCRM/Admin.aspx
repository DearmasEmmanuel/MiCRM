<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="MiCRM.Admin1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <!-- Contenido principal -->
 <div class="content">
     <h1>Bienvenido
         <asp:Label ID="lblUsuario" runat="server" Text=""></asp:Label></h1>
     <p>Este es el panel de Administracion de MiCRM.</p>
 </div>



</asp:Content>
