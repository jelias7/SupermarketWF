<%@ Page Title="Registro de Usuarios" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="rUsuarios.aspx.cs" Inherits="SupermarketRosario.Registros.rUsuarios" %>
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
                         <asp:LinkButton ID="BuscarButton" CssClass="btn btn-info btn-block btn-sm text-center" runat="server" Text="Search" OnClick="BuscarButton_Click"></asp:LinkButton>
                    </div>               
                </div>
                <%--Nombres--%>
                <div class="form-group row">
                    <label for="Nombres" class="col-sm-1 col-form-label">Nombres</label>
                    <div class="col-md-8">
                        <asp:TextBox ID="nombres" runat="server" Class="form-control input-sm"></asp:TextBox>
                    </div>
                </div>
                <%--Email--%>
                <div class="form-group row">
                    <label for="Email" class="col-sm-1 col-form-label">Email</label>
                    <div class="col-md-8">
                        <asp:TextBox ID="email" runat="server" Class="form-control input-sm" placeholder="ejemplo@email.com"></asp:TextBox>
                    </div>
                </div>
                <%--Usuario--%>
                <div class="form-group row">
                    <label for="usuario" class="col-sm-1 col-form-label">Usuario</label>
                    <div class="col-md-8">
                        <asp:TextBox ID="usuario" runat="server" Class="form-control input-sm"></asp:TextBox>
                    </div>
                </div>
                 <%--Clave--%>
                <div class="form-group row">
                    <label for="clave" class="col-sm-1 col-form-label">Clave</label>
                    <div class="col-md-8">
                        <asp:TextBox type="password" ID="clave" runat="server" Class="form-control input-sm"></asp:TextBox>                    </div>
                </div>
                <%--Confirmar--%>
                <div class="form-group row">
                    <label for="clave" class="col-sm-1 col-form-label">Confirmar</label>
                    <div class="col-md-8">
                        <asp:TextBox type="password" ID="confirmar" runat="server" Class="form-control input-sm"></asp:TextBox>                    </div>
                </div>
                <%--Fecha--%>
                <div class="form-group row">
                    <label for="clave" class="col-sm-1 col-form-label">Fecha</label>
                    <div class="col-md-8">
                        <asp:TextBox ID="fecha" type="date" runat="server" Class="form-control input-sm"></asp:TextBox>
                    </div>
                </div>
            </div>
            <asp:Label ID="Error" runat="server" Text=""></asp:Label>
        </div>
        <div class="panel-footer">
            <div class="text-center">
                <div class="form-group" style="display: inline-block">

                    <asp:Button Text="Nuevo" class="btn btn-warning btn-sm" style="color:#fff" runat="server" ID="NuevoButton" OnClick="NuevoButton_Click" />
                    <asp:Button Text="Guardar" class="btn btn-success btn-sm" runat="server" ID="GuadarButton" OnClick="GuadarButton_Click"/>
                    <asp:Button Text="Eliminar" class="btn btn-danger btn-sm" runat="server" ID="EliminarButton" OnClick="EliminarButton_Click" />

                </div>
            </div>

        </div>
    </div>
   
</asp:Content>
