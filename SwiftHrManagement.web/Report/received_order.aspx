<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/SwiftHRManager.Master"
    CodeBehind="received_order.aspx.cs" Inherits="SwiftHrManagement.web.Report.received_order" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">


    <div class="row">
        <div class="col-md-10 col-md-offset-1">
            <section class="panel">
            <header class="panel-heading" >
                    <asp:Label ID="lblHeading" Text= "Heading" runat="server"></asp:Label>
                    <asp:Label ID="lbldesc"  Text="Description" runat="server"></asp:Label>
                    <asp:Label ID="lbldesc0"  Text="Goods Receive Notes (GRN)" runat="server"></asp:Label>
                        </header>
            <div class="panel-body">
                <asp:Table ID="tblMain" runat="server" CellPadding="0" CellSpacing="0">
                </asp:Table>
                <div class="form-group">
                    <div id="rptDiv1" runat="server">
                    </div>
                </div>
                <div class="form-group">
                    <div id="rptDiv" runat="server">
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label ID="lblReceivedMsg" runat="server" CssClass="txtlbl"></asp:Label>
                </div>
                <div align="left" class="txtlbl">
                    ------------------------------------------------
                </div>
                <div align="right" class="txtlbl">
                    -----------------------------------------------
                </div>
                <div align="left" class="txtlbl">
                    <asp:Label runat="server" ID="lblReceivedBy" CssClass="txtlbl"></asp:Label>
                </div>
                <div align="right" class="txtlbl">
                    Delivered By
                </div>
                <div align="left" class="txtlbl">
                    <asp:Label ID="lblReceivedDate" runat="server" CssClass="txtlbl"></asp:Label>
                </div>
                <div align="right" class="txtlbl">
                    <asp:Label ID="lblDeliveredDate" runat="server" CssClass="txtlbl"></asp:Label>
                 
                </div>

            </div>
            </section>
        </div>
    </div>
</asp:Content>
