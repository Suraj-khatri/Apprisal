<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/SwiftHRManager.Master" CodeBehind="StockStatement.aspx.cs" Inherits="SwiftHrManagement.web.Report.InventoryReport.StockStatement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    <div class="panel">
            <header class="panel-heading">
                <div id="divCompany"  runat="server" align="center"></div>
                <div id="Div1" class="ReportSubHeader" align="center">Stock Statement<br />
                    Branch Name: <asp:Label ID="LblBranchName" runat="server"></asp:Label>, Product Name: <asp:Label ID="lblProductName" runat="server"></asp:Label>
                    
                    </div>
                    <div class="row">
                        <div class="col-md-6" align="left">
                        Report From <asp:Label ID="lblFromDate" runat="server"></asp:Label> To <asp:Label ID="lblToDate" runat="server"></asp:Label>
                        </div>
                        <div class="col-md-6" align="right" >                    
                           Report Date : <asp:Label ID="lblprintDate" runat="server" Text="Label"  CssClass="txtlbl"></asp:Label>
                        </div>
                    </div>
            </header>
      <div class="panel-body">
          <div id="rptDiv" runat="server"></div>
      </div>
    </div>

</asp:Content>