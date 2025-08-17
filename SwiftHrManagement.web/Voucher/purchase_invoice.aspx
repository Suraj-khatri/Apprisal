<%@ Page Title="" Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="purchase_invoice.aspx.cs" Inherits="SwiftHrManagement.web.Voucher.purchase_invoice" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    <div class="col-md-10 col-md-offset-1">
        <div class="panel">
            <header class="panel-heading">
                 <img class="img-responsive" src="../img1/laxmi_logo.png" align="center" />
                <%-- <asp:Label ID="lblHeading" Text= "Heading" runat="server"></asp:Label><br />--%>
                <asp:Label ID="lbldesc"  Text="Description" runat="server"></asp:Label>
            </header>
            <div class="panel-body">
                  <asp:Label ID="lbldesc0"  Text="Purchase Invoice" runat="server"></asp:Label>
                <div class="form-group">
                     <div id="rptDiv1" runat="server">
                </div>
                 <div class="form-group">
                      <div id="rptDiv" runat="server">
                </div>
                     </div>
                 <div class="form-group">
                     <asp:Label ID="billNotes" runat="server"></asp:Label>
                </div>
                    <div class="form-group">
                       <div align="left" class="txtlbl">------------------------------------------------</div>   
                    <div align="left" class="txtlbl"><asp:Label ID="lblReceivedBy" runat="server" CssClass="txtlbl"></asp:Label></div>
                        <div align="left" class="txtlbl"><asp:Label ID="lblReceivedDate" runat="server"  CssClass="txtlbl"></asp:Label></div>
                    </div>
        </div>
    </div>
            </div>
        </div>
</asp:Content>
