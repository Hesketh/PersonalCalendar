<%@ Page Title="Login" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication._Default" Async="true" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <br />
    <asp:Label ID="lblError" runat="server" Width="300px"></asp:Label>
    <br />
<asp:Label ID="lblUsername" runat="server" Text="Username" Width="100px"></asp:Label>

    <asp:TextBox ID="txtUsername" runat="server" Width="200px"></asp:TextBox>
    <br />
<asp:Label ID="lblPassword" runat="server" Text="Password" Width="100px"></asp:Label>
    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Width="200px"></asp:TextBox>
<br />
    <asp:Button ID="btnLogin" runat="server" OnClick="btnLogin_Click" Text="Login" Width="200px" />

    <br />
    <asp:Button ID="btnCrate" runat="server" OnClick="Button1_Click" Text="Create New User" Width="200px" />
    
</asp:Content>
