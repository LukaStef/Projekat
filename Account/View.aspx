<%@ Page Title="View data" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="View.aspx.cs" Inherits="Projekat.Account.View" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h1>View available data</h1>
    <br />
    <h5>Search parameters</h5>
    <br />
    Searching for: <asp:DropDownList ID="ddlSearch" runat="server" OnSelectedIndexChanged="ddlSearch_SelectedIndexChanged" AutoPostBack="true" CssClass="dropdown">
        <asp:ListItem Value="b">Band</asp:ListItem>
        <asp:ListItem Value="a">Album</asp:ListItem>
        <asp:ListItem Value="s">Song</asp:ListItem>
    </asp:DropDownList><br />
    <asp:Label ID="lblName" runat="server" Text="Name:"></asp:Label> <asp:TextBox ID="tbName" runat="server" CssClass="form-control"></asp:TextBox>
    <asp:Label ID="lblAlbum" runat="server" Text="Album:" Visible="false"></asp:Label> <asp:TextBox ID="tbAlbum" runat="server" Visible="false" CssClass="form-control"></asp:TextBox>
    <asp:Label ID="lblBand" runat="server" Text="Band:" Visible="false"></asp:Label> <asp:TextBox ID="tbBand" runat="server" Visible="false" CssClass="form-control"></asp:TextBox>
    <br />
    <asp:Button ID="Button1" runat="server" Text="Search" CssClass="btn btn-primary bold" OnClick="Button1_Click" /><br />
    <br />
    <asp:Button ID="Button2" runat="server" Text="Clear parameters" CssClass="btn btn-danger" OnClick="Button2_Click"/><br />
    <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
    <br />
    <br />
    <div class="centriraj">
        <asp:GridView ID="gvAlbum" runat="server" CssClass="table" EmptyDataText="No items found" AutoGenerateColumns="false">
        <Columns>
            <asp:BoundField DataField="name" HeaderText="Name"></asp:BoundField>
            <asp:BoundField DataField="date" HeaderText="Release date"></asp:BoundField>
            <asp:BoundField DataField="band" HeaderText="Band"></asp:BoundField>
            <asp:ImageField DataImageUrlField="cover" HeaderText="Cover">
                <ControlStyle Height="160px" Width="160px"  BorderWidth="1" BorderColor="White" />
            </asp:ImageField>
        </Columns>
    </asp:GridView>
    <asp:GridView ID="gvBand" runat="server" CssClass="table" EmptyDataText="No items found" AutoGenerateColumns="false">
        <Columns>
            <asp:BoundField DataField="name" HeaderText="Name"></asp:BoundField>
            <asp:BoundField DataField="date" HeaderText="Date of formation"></asp:BoundField>
            <asp:ImageField DataImageUrlField="logo" HeaderText="Logo">
                <ControlStyle Height="110px" Width="160px"  />
            </asp:ImageField>
            <asp:HyperLinkField DataNavigateUrlFields="link" DataTextField="linkText" HeaderText="Official site">
                
            </asp:HyperLinkField>
        </Columns>
    </asp:GridView>
    <asp:GridView ID="gvSong" runat="server" CssClass="table"  EmptyDataText="No items found" AutoGenerateColumns="false">
        <Columns>
            <asp:BoundField DataField="name" HeaderText="Name"></asp:BoundField>
            <asp:BoundField DataField="album" HeaderText="Album"></asp:BoundField>
            <asp:ImageField DataImageUrlField="cover" HeaderText="Album cover">
                <ControlStyle Height="160px" Width="160px"   BorderWidth="1" BorderColor="White" />
            </asp:ImageField>
            <asp:BoundField DataField="band" HeaderText="Band"></asp:BoundField>
            <asp:HyperLinkField DataNavigateUrlFields="link" DataTextField="linkText" HeaderText="YouTube link"></asp:HyperLinkField>
        </Columns>
    </asp:GridView>
    </div>
    

</asp:Content>
