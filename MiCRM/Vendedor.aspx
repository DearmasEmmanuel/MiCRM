<%@ Page Title="" Language="C#" MasterPageFile="~/Vendedor.Master" AutoEventWireup="true" CodeBehind="Vendedor.aspx.cs" Inherits="MiCRM.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-5">
        <h1 class="mb-4">Perfil de Vendedor</h1>
        <div class="row">
            <div class="col-md-6">
                <div class="card">
                    <div class="card-header bg-primary text-white">
                        Datos del Vendedor
                    </div>
                    <div class="card-body">
                        <!-- Contenido del perfil del vendedor aquí -->
                    </div>
                </div>
            </div>
            <div class="col-md-6">
                <div class="card">
                    <div class="card-header bg-success text-white">
                        Estadísticas de Venta
                    </div>
                    <div class="card-body">
                        <!-- Estadísticas de venta aquí -->
                    </div>
                </div>
            </div>
        </div>
    </div>



</asp:Content>
