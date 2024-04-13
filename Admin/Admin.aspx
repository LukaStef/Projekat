<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="Projekat.Admin.Admin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Database</h1>
    <br />
    <h5>View, edit, delete or add a new entry into the database</h5>
    <br />
    Load data for: <asp:DropDownList ID="ddlSearch" runat="server" OnSelectedIndexChanged="ddlSearch_SelectedIndexChanged" AutoPostBack="true" CssClass="dropdown">
        <asp:ListItem Value="b">Band</asp:ListItem>
        <asp:ListItem Value="a">Album</asp:ListItem>
        <asp:ListItem Value="s">Song</asp:ListItem>
    </asp:DropDownList><br />
    <asp:Panel ID="panelBand" runat="server">
        <asp:Label ID="lblIdB" runat="server" Text="ID:"></asp:Label> <asp:TextBox ID="tbId" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
        <asp:Label ID="lblNameB" runat="server" Text="Name:"></asp:Label> <asp:TextBox ID="tbName" runat="server" CssClass="form-control"></asp:TextBox>
        <asp:Label ID="lblLogoB" runat="server" Text="Logo (file path):"></asp:Label> <asp:TextBox ID="tbLogo" runat="server" CssClass="form-control"></asp:TextBox>
        <asp:Label ID="lblDateB" runat="server" Text="Date:" ></asp:Label> <asp:TextBox ID="tbDate" runat="server" CssClass="form-control"></asp:TextBox>
        <asp:Label ID="lblSiteB" runat="server" Text="Site:" ></asp:Label> <asp:TextBox ID="tbSite" runat="server" CssClass="form-control"></asp:TextBox>


    </asp:Panel>
    <asp:Panel ID="panelAlbum" runat="server" Visible="false">
        <asp:Label ID="lblIdA" runat="server" Text="ID:"></asp:Label> <asp:TextBox ID="tbIdA" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
        <asp:Label ID="lblNameA" runat="server" Text="Name:"></asp:Label> <asp:TextBox ID="tbnameA" runat="server" CssClass="form-control"></asp:TextBox>
        <asp:Label ID="lblCover" runat="server" Text="Album cover (file path):"></asp:Label> <asp:TextBox ID="tbCover" runat="server" CssClass="form-control"></asp:TextBox>
        <asp:Label ID="lblDateA" runat="server" Text="Date:" ></asp:Label> <asp:TextBox ID="tbDateA" runat="server" CssClass="form-control"></asp:TextBox>
        <asp:Label ID="lblBand" runat="server" Text="Band (ID):" ></asp:Label> <asp:TextBox ID="tbBand" runat="server" CssClass="form-control"></asp:TextBox>
    </asp:Panel>
    <asp:Panel ID="panelSong" runat="server" Visible="false">
        <asp:Label ID="lblIdS" runat="server" Text="ID:"></asp:Label> <asp:TextBox ID="tbIdS" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
        <asp:Label ID="lblNameS" runat="server" Text="Name:"></asp:Label> <asp:TextBox ID="tbNameS" runat="server" CssClass="form-control"></asp:TextBox>
        <asp:Label ID="lblAlbum" runat="server" Text="Album (ID):"></asp:Label> <asp:TextBox ID="tbAlbum" runat="server" CssClass="form-control"></asp:TextBox>
        <asp:Label ID="lblLink" runat="server" Text="Youtube link:" ></asp:Label> <asp:TextBox ID="tblink" runat="server" CssClass="form-control"></asp:TextBox>
        
    </asp:Panel>
    <br />
    <asp:Label ID="lblError" runat="server" Text="Label"></asp:Label>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateSelectButton="true" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" CssClass="table" SelectedRowStyle-BackColor="LightGray" SelectedRowStyle-Font-Underline="true"></asp:GridView>
</asp:Content>
