<%@ Page Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="ViewGroupWiseSummaryRpt.aspx.cs" Inherits="SwiftHrManagement.web.Report.InventoryReport.ViewGroupWiseSummaryRpt" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    <div class="panel">
        <header class="panel-heading">
            <div id="divCompany" class="ReportHeader" runat="server" align="center"></div>
                <div id="Div1" class="ReportSubHeader" align="center">Inventory Summary Report-Group Wise<br />
                Branch Name: <asp:Label ID="LblBranchName" runat="server"></asp:Label>, Product Group Name: <asp:Label ID="LblProductGroupWise" runat="server"></asp:Label>
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
