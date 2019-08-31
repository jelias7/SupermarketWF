<%@ Page Title="Consulta de Usuarios" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="cUsuarios.aspx.cs" Inherits="SupermarketRosario.Consultas.cUsuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="panel panel-primary">
        <div class="panel-body">
            <div class="form-group row">
            <div class="col-md-2">
                <asp:Label ID="Labels" runat="server" Text="FILTRO"></asp:Label>
                    <asp:DropDownList ID="filtro" runat="server" CssClass="form-control input-sm" >
                        <asp:ListItem>ID</asp:ListItem>
                        <asp:ListItem>Usuario</asp:ListItem>
                        <asp:ListItem>Nombres</asp:ListItem>
                        <asp:ListItem>Email</asp:ListItem>
                        <asp:ListItem>Todo</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>

            <div class="form-group row">
                <div class="col-md-6">
                    <asp:Label ID="Label" runat="server" Text="CRITERIO"></asp:Label>
                    <asp:TextBox ID="criterio" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                </div>
            </div>

            <div class="form-group row">
                <div class="col-md-4">
                    <asp:Button ID="BuscarButton" runat="server" Class="btn btn-success input-sm" Text="Buscar" OnClick="BuscarButton_Click"/>
                </div>
            </div>

           </div>
                    <asp:GridView ID="Grid" runat="server" class="table table-condensed table-responsive" AutoGenerateColumns="true" ShowHeaderWhenEmpty="True" DataKeyNames="UsuarioId" CellPadding="4" ForeColor="Black" GridLines="None">
                    <EmptyDataTemplate><div style="text-align:center">No hay datos.</div></EmptyDataTemplate>
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:HyperLinkField ControlStyle-ForeColor="#6699ff" DataNavigateUrlFields="UsuarioId" DataNavigateUrlFormatString="~/Registros/rUsuarios.aspx?Id={0}" Text="Editar"></asp:HyperLinkField>
                    </Columns>
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <RowStyle BackColor="#EFF3FB" />
                </asp:GridView>
        </div>
</asp:Content>
