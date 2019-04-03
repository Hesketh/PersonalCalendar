<%@ Page Title="Dashboard" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="WebApplication.Dashboard" Async="true" MaintainScrollPositionOnPostback="true"%>
<asp:Content ID="Content1" runat="server" contentplaceholderid="MainContent">
    <br />
    <asp:Label ID="lblCalendars" runat="server" Text="Calendars"></asp:Label>
    <br />
    <asp:DropDownList ID="ddCalendars" runat="server" OnSelectedIndexChanged="ddCalendars_SelectedIndexChanged" Width="300px" AutoPostBack="True">
    </asp:DropDownList>
    <br />
    <asp:Button ID="btnOpen" runat="server" OnClick="btnOpen_Click" Text="Open" Width="300px" />
    <br />
    <asp:Button ID="btnDelete" runat="server" OnClick="btnDelete_Click" Text="Delete" Width="75px" />
    <asp:Button ID="btnCreate" runat="server" OnClick="btnCreate_Click" Text="Create" Width="200px" />
    <br />
    <br />
    <asp:Label ID="lblPassword" runat="server" Text="Password"></asp:Label>
    <br />
    <asp:TextBox ID="txtPassword" runat="server" Width="200px"></asp:TextBox>
    <br />
    <asp:Button ID="txtChangePassword" runat="server" OnClick="txtChangePassword_Click" Text="Change Password" Width="200px" />
</asp:Content>

