<%@ Page Title="" Language="C#" MasterPageFile="~/menu.Master" AutoEventWireup="true" CodeBehind="Reportes.aspx.cs" Inherits="Examen_2.Reportes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     div>
            <h1>Reporte de Personas y Vehículos</h1>
            <h2>Carros:</h2>
            <p>Personas con carro: <% Response.Write(personasConCarro); %></p>
            <p>Personas sin carro: <% Response.Write(personasSinCarro); %></p>

            <h2>Motocicletas:</h2>
            <p>Personas con motocicleta: <% Response.Write(personasConMoto); %></p>
            <p>Personas sin motocicleta: <% Response.Write(personasSinMoto); %></p>

            <h2>Bicicletas:</h2>
            <p>Personas con bicicleta: <% Response.Write(personasConBici); %></p>
            <p>Personas sin bicicleta: <% Response.Write(personasSinBici); %></p>
        </div>
    
</asp:Content>
