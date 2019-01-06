<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Product.aspx.cs" Inherits="Pages_Product" %>

<asp:Content ID="btnADD" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style2 {
            height: 31px;
        }
        .auto-style3 {
            width: 298px;
        }
        .auto-style4 {
            height: 15px;
        }
        .auto-style5 {
            height: 93px;
        }
        .auto-style6 {
            height: 14px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width: 1042px; height: 457px">
        <tr>
            <td rowspan="4" class="auto-style3">
                
                <asp:Image ID="imgProduct" runat="server" CssClass="detailsImage" Width="631px" ImageAlign="Left" Height="428px" /> </td> 
            <td class="auto-style4"><h2>
                    &nbsp;<asp:Label ID="lblTitle" runat="server">Title</asp:Label>
                <hr style="height: 0px"/>
                <asp:Label ID="lblPrice" runat="server" CssClass="detailsPrice">Price</asp:Label> 
                <br />
                <asp:Label ID="Label1" runat="server" CssClass="productPrice"></asp:Label> 
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                &nbsp;</h2></td> 
            

         <tr>
            <td class="auto-style5">  <asp:Label ID="lblDescription" runat="server" CssClass="detailsDescription">Description</asp:Label></td>
            <td class="auto-style5"> 
                </td><br />
             Quantity :
             <asp:DropDownList ID="ddlAmount" runat="server"></asp:DropDownList><br/>
             <asp:Label ID="lblResult" runat="server" Text=""></asp:Label>
        </tr>
         <tr>
            <td class="auto-style6">Product Number:  <asp:Label ID="lblItemNR" runat="server" Text=" "></asp:Label>
                <br />
                <br />
                <br />
                <br />
                <br />
             </td>
            
        </tr>
         <tr>
            <td class="auto-style2"> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                <asp:Button ID="Button1" runat="server" CssClass="button" OnClick="Button1_Click" Text="Add Product" />
                </td>
            
        </tr>
    </table>
</asp:Content>

