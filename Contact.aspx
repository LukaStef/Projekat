<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="Projekat.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main aria-labelledby="title">
        <h1 id="title"><%: Title %></h1>
        <h3>Feel free to contact us</h3>
        <address>
            <strong>Support:</strong>   <a href="mailto:Support@example.com">support@metalpedia.com</a><br />
            <strong>Marketing:</strong> <a href="mailto:Marketing@example.com">marketing@metalpedia.com</a>
        </address>
    </main>
</asp:Content>
