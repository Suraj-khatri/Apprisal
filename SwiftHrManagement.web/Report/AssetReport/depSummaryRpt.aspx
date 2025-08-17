<%@ Page Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="depSummaryRpt.aspx.cs" Inherits="SwiftHrManagement.web.Report.AssetReport.depSummaryRpt" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    <div class="panel">
        <header class="panel-heading" >
            <div id="divCompany" class="ReportHeader" runat="server" align="center"></div>
                    <div class="ReportSubHeader" align="center">                        
                        <asp:Label id="rptDes" runat="server" CssClass="txtlbl"></asp:Label><br />
                        Branch Name : <asp:Label ID="BRANCH_NAME" runat="server" CssClass="txtlbl"></asp:Label>
                    </div>                
                    <div style="text-align: center" class="ReportSubHeader">
                        Report Date : <asp:Label ID="lblprintDate" runat="server" Text="Label"  CssClass="txtlbl"></asp:Label>
                    </div>
        </header>
        <div class="panel-body">
            <span class="ReportSubHeader">Asset Group Wise Summary Report</span>
            <div class="form-group">
                <div id="rpt" runat="server"></div>
            </div>
            <span class="ReportSubHeader">Depreciation Group Wise Summary Report</span>
            <div class="form-group">
                <div id="rpt1" runat="server"></div>
            </div>
        </div>
    </div>

</asp:Content>
