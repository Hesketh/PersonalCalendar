<%@ Page Title="Event" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditEvent.aspx.cs" Inherits="WebApplication.EditEvent" Async="true" EnableEventValidation="false"%>
<asp:Content ID="Content1" runat="server" contentplaceholderid="MainContent">
    <p>
        &nbsp;</p>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:Label ID="lblName" runat="server" Text="Name" Width="100px"></asp:Label>
            <asp:TextBox ID="txtName" runat="server" Width="200px"></asp:TextBox>
            <br />
            <asp:Label ID="lblDescription" runat="server" Text="Description" Width="100px"></asp:Label>
            <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" Width="200px"></asp:TextBox>
            <br />
            <asp:Label ID="lblStart" runat="server" Text="Start Time" Width="100px"></asp:Label>
            <asp:TextBox ID="txtStart" runat="server" TextMode="Date" Width="150px"></asp:TextBox>
            <asp:TextBox ID="txtStartTime" runat="server" TextMode="Time" Width="75px"></asp:TextBox>
            <br />
            <asp:Label ID="lblEnd" runat="server" Text="End Time" Width="100px"></asp:Label>
            <asp:TextBox ID="txtEnd" runat="server" TextMode="Date" Width="150px"></asp:TextBox>
            <asp:TextBox ID="txtTimeEnd" runat="server" TextMode="Time" Width="75px"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="btnEdit" runat="server" Text="Update Event" Width="300px" OnClick="btnEdit_Click" />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>