<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="WebApplication1.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
    </h3>
    <h3>&nbsp;</h3>
    <h3>
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    </h3>
    <h3>
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    </h3>
    <h3>&nbsp;</h3>
    <h3>Your application description page.</h3>
    <p>Use this area to provide additional information.</p>
</asp:Content>
