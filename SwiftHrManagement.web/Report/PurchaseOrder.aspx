<%@ Page Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true"
    CodeBehind="PurchaseOrder.aspx.cs" Inherits="SwiftHrManagement.web.Report.PurchaseOrder" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">

    <div class="row">
        <div class="col-lg-10 col-md-offset-1">
              <section class="panel">
            <header class="panel-heading">
                                    <asp:Label ID="Label1" Text="Purchase Order" CssClass="panel-heading" runat="server"></asp:Label>
                        </header>
            <div class="panel-body">
                <div class="form-group">
                    <div class="row">
                    <div class="col-md-12" align="center">
                        <img src="../img1/laxmi_logo.png" />
                        </div>
                    </div>
                    </div>

                    <div width="500px" align="center">
                    </div>
                    <asp:Table ID="tblMain" runat="server" CellPadding="0" CellSpacing="0">
                    </asp:Table>
                    <div id="rptDiv1" runat="server">
                    </div>
                    <div id="rptDiv" runat="server">
                    </div>
                    <div>
                        <asp:Label ID="lblDeliverDate" runat="server"></asp:Label>
                    </div>
                    <div>
                        Note: 
                    </div>
                    <div id="divNotes" runat="server"></div>
                    <div>
                        Specification:  
                    </div>
                    <div id="divSpecification" runat="server"></div>
                    <div align="left">------------------------------------------------</div>
                    <div align="left">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Authorized Signature</div>
                    <hr />
                    <b>CC: STORES/ACCOUNTS/VENDOR</b>
                </div>
        </div>
                  </section>
    </div>
    </div>
</asp:Content>
