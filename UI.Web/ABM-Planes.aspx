﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ABM-Planes.aspx.cs" Inherits="UI.Web.Planes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div >
<asp:Panel ID="gridPanelPlanes" runat="server" >
        <asp:GridView ID="gridViewPlanes" runat="server" AutoGenerateColumns ="False" class="tablas"
                    onselectedindexchanged="gridViewPlanes_SelectedIndexChanged" DataKeyNames="ID" 
                    EmptyDataText="No hay planes registrados"
                    SelectedRowStyle-BackColor="Green"
                    SelectedRowStyle-ForeColor="White" CssClass="tablas">
                    <Columns>
                        <asp:BoundField DataField="ID" HeaderText="ID Plan"></asp:BoundField>
                        <asp:BoundField DataField="Especialidad" HeaderText="Especialidad"></asp:BoundField>
                        <asp:BoundField DataField="Plan" HeaderText="Plan" />
                        <asp:CommandField ShowSelectButton="True" />
                    </Columns>
                </asp:GridView>
</asp:Panel>

    <br />
<asp:Panel ID="gridActionsPanelPlanes" runat="server" >
    <asp:LinkButton ID="editarLinkButton" runat="server" OnClick="editarLinkButton_Click">Editar</asp:LinkButton>
    <asp:LinkButton ID="eliminarLinkButton" runat="server" OnClick="eliminarLinkButton_Click">Eliminar</asp:LinkButton>
    <asp:LinkButton ID="nuevoLinkButton" runat="server" OnClick="nuevoLinkButton_Click">Nuevo</asp:LinkButton>
</asp:Panel>
    <br />
<asp:Panel ID="formPanel" Visible="false" runat="server" >
    <asp:Label ID="etiqIdPlan" runat="server" Text="ID Plan: "></asp:Label>
    <asp:TextBox ID="idTextBox" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="etiqDescripcion" runat="server" Text="Descripción "></asp:Label>
    <asp:TextBox ID="descripcionTextBox" runat="server" Width="114px"></asp:TextBox>
    <asp:RequiredFieldValidator ID="validadorDescripcion" runat="server" ControlToValidate="descripcionTextBox" ErrorMessage="Debe completar la descripción." ForeColor="Red" ValidationGroup="validaciones">*</asp:RequiredFieldValidator>
    <br />
    <asp:Label ID="etiqEspecialidad" runat="server" Text="Especialidad:"></asp:Label>
    <asp:DropDownList ID="ddlEspecialidad" runat="server">
    </asp:DropDownList>
    <br />
    <asp:Panel ID="formActionsPanel" runat="server">    
    <asp:LinkButton ID="aceptarLinkButton" ValidationGroup="validaciones" runat="server" OnClick="aceptarLinkButton_Click">Aceptar</asp:LinkButton>
    <asp:LinkButton ID="cancelarLinkButton" runat="server" OnClick="cancelarLinkButton_Click">Cancelar</asp:LinkButton>
    <br />
    </asp:Panel>
</asp:Panel>
    
    
    <br />
    <asp:ValidationSummary ID="sumarioValidacione" runat="server" BorderStyle="Dotted" ForeColor="Red" ValidationGroup="validaciones" />
</div>
</asp:Content>