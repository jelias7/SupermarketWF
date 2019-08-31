<%@ Page Title="Usuarios" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="rUsuarios.aspx.cs" Inherits="SupermarketRosario.Registros.rUsuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
       <div class="panel panel-primary">
        <div class="panel-body">
            <div class="form-horizontal col-md-14" role="form">
                <%--ID--%>
                <div class="form-group row">
                    <label for="ID" class="col-sm-1 col-form-label">ID</label>
                    <div class="col-md-1 col-sm-2 col-xs-4">
                        <asp:TextBox type="number" ID="id" runat="server" min=0 class="form-control input-sm"></asp:TextBox>
                    </div>
                    <div class="col-md-1 col-sm-2 col-xs-4">
                         <asp:LinkButton ID="BuscarButton" CssClass="btn btn-info btn-block btn-sm text-center" runat="server" Text="Search"></asp:LinkButton>
                    </div>               
                </div>
                <%--Nombres--%>
                <div class="form-group row">
                    <label for="Nombres" class="col-sm-1 col-form-label">Nombres</label>
                    <div class="col-md-8">
                        <asp:TextBox ID="nombres" runat="server" Class="form-control input-sm"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RFVNombres" runat="server" MaxLength="50" ControlToValidate="nombres" ErrorMessage="Llena el campo" ForeColor="Black" Display="Dynamic" SetFocusOnError="True" ToolTip="Campo obligatorio">Llena el campo.</asp:RequiredFieldValidator>
                    </div>
                </div>
                <%--Email--%>
                <div class="form-group row">
                    <label for="Email" class="col-sm-1 col-form-label">Email</label>
                    <div class="col-md-8">
                        <asp:TextBox ID="email" runat="server" Class="form-control input-sm" placeholder="ejemplo@email.com"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RFVEmail" runat="server" MaxLength="50" ControlToValidate="email" ErrorMessage="Llena el campo" ForeColor="Black" Display="Dynamic" SetFocusOnError="True" ToolTip="Campo obligatorio">Llena el campo.</asp:RequiredFieldValidator>
                    </div>
                </div>
                <%--Usuario--%>
                <div class="form-group row">
                    <label for="usuario" class="col-sm-1 col-form-label">Usuario</label>
                    <div class="col-md-8">
                        <asp:TextBox ID="usuario" runat="server" Class="form-control input-sm"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RFVUsuario" runat="server" ControlToValidate="usuario" ErrorMessage="Llena el campo" ForeColor="Black" Display="Dynamic" SetFocusOnError="True" ToolTip="Campo obligatorio">Llena el campo.</asp:RequiredFieldValidator>

                    </div>
                </div>
                 <%--Clave--%>
                <div class="form-group row">
                    <label for="clave" class="col-sm-1 col-form-label">Clave</label>
                    <div class="col-md-8">
                        <asp:TextBox type="password" ID="clave" runat="server" Class="form-control input-sm"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RFVClave" runat="server" ControlToValidate="clave" ErrorMessage="Llena el campo" ForeColor="Black" Display="Dynamic" SetFocusOnError="True" ToolTip="Campo obligatorio">Llena el campo.</asp:RequiredFieldValidator>
                    </div>
                </div>
                <%--Confirmar--%>
                <div class="form-group row">
                    <label for="clave" class="col-sm-1 col-form-label">Confirmar</label>
                    <div class="col-md-8">
                        <asp:TextBox type="password" ID="confirmar" runat="server" Class="form-control input-sm"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RFVConfirmar" runat="server" ControlToValidate="confirmar" ErrorMessage="Llena el campo" ForeColor="Black" Display="Dynamic" SetFocusOnError="True" ToolTip="Campo obligatorio">Llena el campo.</asp:RequiredFieldValidator>
                    </div>
                </div>
                <%--Fecha--%>
                <div class="form-group row">
                    <label for="clave" class="col-sm-1 col-form-label">Fecha</label>
                    <div class="col-md-8">
                        <asp:TextBox ID="fecha" type="date" runat="server" Class="form-control input-sm"></asp:TextBox>
                    </div>
                </div>
            </div>

        </div>
        <div class="panel-footer">
            <div class="text-center">
                <div class="form-group" style="display: inline-block">

                    <asp:Button Text="Nuevo" class="btn btn-warning btn-sm" style="color:#fff" runat="server" ID="NuevoButton" />
                    <asp:Button Text="Guardar" class="btn btn-success btn-sm" runat="server" ID="GuadarButton"/>
                    <asp:Button Text="Eliminar" class="btn btn-danger btn-sm" runat="server" ID="EliminarButton" />

                </div>
            </div>

        </div>
    </div>
   
</asp:Content>
