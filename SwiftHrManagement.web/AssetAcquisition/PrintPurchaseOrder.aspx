<%@ Page Language="C#" MasterPageFile="~/SwiftHRManager.Master"  AutoEventWireup="true" CodeBehind="PrintPurchaseOrder.aspx.cs" Inherits="SwiftHrManagement.web.AssetAcquisition.PrintPurchaseOrder" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">

   <div class="panel">
       <header class="panel-heading" style="text-align:center;">
          <img class="img-responsive" src="../img1/laxmi_logo.png"/>
             <%--<asp:Label ID="lblHeading" Text= "Heading" runat="server" align="center"></asp:Label><br />--%>
               <%--<asp:Label ID="lbldesc"  Text="Description" runat="server" align="center"></asp:Label>--%>
          <asp:Label ID="lbldesc0"  Text="Purchase Order" runat="server" align="center"></asp:Label>
       </header>
       <div class="panel-body">
            <asp:Table ID="tblMain" runat="server" CellPadding="0" CellSpacing="0">
                </asp:Table>
             <div id="rptDiv1" runat="server">
                </div>
            <div id="rptDiv" runat="server">
                </div>
           <asp:Label ID="lblReceivedMsg" runat="server"></asp:Label>
           <div class="txtlbl">Authorised Signature</div>
           <div align="right" class="txtlbl"><asp:Label runat="server" ID="lblOrderBy" CssClass="txtlbl"></asp:Label></div>
           <div  class="txtlbl"><asp:Label ID="lblAuthorisedDate" runat="server" CssClass="txtlbl"></asp:Label></div>
           <div align="right" class="txtlbl"><asp:Label ID="lblOrderedDate" runat="server"  CssClass="txtlbl"></asp:Label></div>
       </div>
   </div>
</asp:Content>