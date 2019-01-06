 <%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ShoppingCart.aspx.cs" Inherits="Pages_ShoppingCart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Panel ID="pnlShoppingCart" runat="server">

    </asp:Panel>
    <table>
        <tr>
            <td><b>Total: </b></td>
            <td><asp:Literal ID="litTotal" runat="server" Text="" /></td>
          </tr>
        <tr>
            <td><b>Type: </b></td>
            <td><asp:Literal ID="litType" runat="server" Text="" /></td>
          </tr>
        <tr>
            <td><b>Shiping: </b></td>
            <td> $ 30</td>
          </tr>
        <tr>
            <td><b>Total Amount: </b></td>
            <td><asp:Literal ID="litTotalAmount" runat="server" Text="" /></td>
          </tr>
        <tr>
            <td>
                <asp:LinkButton ID="linkCOntinue" runat="server" PostBackUrl="~/Index.aspx"
                    Text="Continue shopping" ></asp:LinkButton>
                OR
                <asp:Button  ID="btnCHeckOut" runat="server" PostBackUrl="~/Pages/Success.aspx"
                    CssClass="button" Width="250px" Text="Continue Checkout" />

            </td>
          </tr>
    </table>
</asp:Content>

