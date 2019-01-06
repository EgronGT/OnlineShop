<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Pages_Account_Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style2 {
            -moz-border-radius: 5px;
            -webkit-border-radius: 5px;
            background-color: #EAEAEA;
            border: 1px solid #CACACA;
            color: #444;
            margin: 0 0 25px;
            padding: 5px 9px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Literal ID="litStatus" runat="server"></asp:Literal>
    <br />
    <br />
    UserName<br />
    <br />
    <asp:TextBox ID="txtUserName" runat="server" CssClass="inputs"></asp:TextBox>
    <br />
    <br />
    Password:<br />
    <asp:TextBox ID="txtPassword" runat="server" CssClass="inputs" TextMode="Password"></asp:TextBox>
    <br />
    <br />
    ConfirmPassword:<br />
    <asp:TextBox ID="txtConfirmPassword" runat="server" CssClass="inputs" TextMode="Password"></asp:TextBox>
    <br />
    <br />
    <asp:Label ID="Label2" runat="server" Text="FirstName"></asp:Label>
    <br />
    <asp:TextBox ID="txtFirstName" runat="server" CssClass="auto-style2" Height="19px" Width="267px"></asp:TextBox>
    <br />
    <br />
    <asp:Label ID="Label3" runat="server" Text="LastName"></asp:Label>
    <br />
    <asp:TextBox ID="txtLastName" runat="server" CssClass="auto-style2" Height="17px" Width="269px"></asp:TextBox>
    <br />
    <br />
    <asp:Label ID="Label4" runat="server" Text="Address"></asp:Label>
    <br />
    <asp:TextBox ID="txtAddress" runat="server" CssClass="auto-style2" Height="18px" Width="269px"></asp:TextBox>
    <br />
    <br />
    <asp:Label ID="Label1" runat="server" Text="Postal Code"></asp:Label>
    <br />
    <asp:TextBox ID="txtPostalCode" runat="server" CssClass="auto-style2" Height="16px" Width="270px"></asp:TextBox>
    <br />
    <br />
    <br />
    <asp:Button ID="Button1" runat="server" CssClass="button" OnClick="Button1_Click" Text="Button" />
    <br />
    <br />
</asp:Content>

