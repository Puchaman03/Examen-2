<%@ Page Title="" Language="C#" MasterPageFile="~/menu.Master" AutoEventWireup="true" CodeBehind="Encuesta.aspx.cs" Inherits="Examen_2.Encuesta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            margin-bottom: 1;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="w-100">
        <tr>
            <td class="text-center" style="font-family: 'Arial Black'; font-size: large; color: #00FFFF; text-decoration: underline">Bienvenido al Sistema de Encuesta</td>
        </tr>
    </table>

    <div>
        <b>Nombre</b>
        <asp:TextBox ID="TNombre" runat="server" CssClass="auto-style1"></asp:TextBox>

        <br />
        <br />
        <b>Primer Apellido</b>&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="Tapellido1" runat="server"></asp:TextBox>
        <br />
        <br />
        <b>Segundo Apellido</b>
        <asp:TextBox ID="Tapellido2" runat="server"></asp:TextBox>
        <br />
        <br />
        <b>Fecha de Nacimiento</b>
<asp:Calendar ID="Calendar1" runat="server" BackColor="Aqua" VisibleDate="2000-01-01" BorderColor="#9900FF"></asp:Calendar>
    OnDayRender="Calendar1_DayRender">
       <br />
        <br />
        <b>Edad</b>
        <asp:TextBox ID="Tedad" runat="server"></asp:TextBox>
        <br />
        <br />
        <b>Género</b>
        <asp:DropDownList ID="TGenero" runat="server" BackColor="#00FFCC" Height="22px">
            <asp:ListItem Text="M" Value="M"></asp:ListItem>
            <asp:ListItem Text="F" Value="F"></asp:ListItem>
        </asp:DropDownList>
        <br />
        <br />
        <b>Cédula</b>&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TCedula" runat="server" CssClass="auto-style1"></asp:TextBox>
        <br />
        <br />
        <b>Correo</b>&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TCorreo" runat="server"></asp:TextBox>
        <br />
        <br />
        <b>¿Posee un Carro?</b>
        <br />
        <asp:RadioButton ID="CarroSi" runat="server" GroupName="Carro" Text="Si" />
        <asp:RadioButton ID="CarroNo" runat="server" GroupName="Carro" Text="No" />
        <br />
        <b>Identificación</b>
        <asp:TextBox ID="IdCarro" runat="server"></asp:TextBox>
        <br />
        <br />
        <b>¿Posee una Motocicleta?</b>
        <br />
        <asp:RadioButton ID="MotoSi" runat="server" GroupName="Moto" Text="Si" />
        <asp:RadioButton ID="MotoNo" runat="server" GroupName="Moto" Text="No" />
        <br />
        <b>Identificación</b>
        <asp:TextBox ID="IdMoto" runat="server"></asp:TextBox>
        <br />
        <br />
        <br />
        <br />
        <b>¿Posee una Bicicleta?</b>
        <br />
        <asp:RadioButton ID="BiciSi" runat="server" GroupName="Bici" Text="Si" />
        <asp:RadioButton ID="BiciNo" runat="server" GroupName="Bici" Text="No" />
        <br />
        <b>Identificación</b>
        <asp:TextBox ID="IdBici" runat="server"></asp:TextBox>
        <br />
<br />
<br />
        <asp:Button ID="IdEnviar" runat="server" Height="47px" Text="Enviar Encuesta" Width="262px" OnClick="IdEnviar_Click" />

    </div>

</asp:Content>