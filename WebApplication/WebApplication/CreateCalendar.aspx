<%@ Page Title="New Calendar" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreateCalendar.aspx.cs" Inherits="WebApplication.CreateCalendar" Async="true"%>

<asp:Content ID="Content1" runat="server" contentplaceholderid="MainContent">
    <br />
    <asp:Label ID="lblError" runat="server" Text="Calendar"></asp:Label>
    <br />
    <asp:Label ID="lblName" runat="server" Text="Name:" Width="100px"></asp:Label>
    <asp:TextBox ID="txtName" runat="server" Width="200px"></asp:TextBox>
    <br />
    <asp:Button ID="btnCreate" runat="server" OnClick="btnCreate_Click" Text="Create Calendar" Width="300px" />
</asp:Content>