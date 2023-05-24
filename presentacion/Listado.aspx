<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Listado.aspx.cs" Inherits="presentacion.Listado" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView runat="server" ID="dgvTurnos" CssClass="table" AutoGenerateColumns="false" DataKeyNames="Id">
        <Columns>
            <asp:BoundField HeaderText="Fecha" DataField="Fecha" />
            <asp:BoundField HeaderText="Cliente" DataField="Cliente" />
            <asp:BoundField HeaderText="Servicio" DataField="Servicio" />
            <asp:BoundField HeaderText="Autor" DataField="Autor" />
            <asp:BoundField HeaderText="Importe" DataField="Importe" />
        </Columns>
    </asp:GridView>
</asp:Content>
