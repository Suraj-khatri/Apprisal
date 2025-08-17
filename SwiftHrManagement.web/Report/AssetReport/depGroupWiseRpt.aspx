<%@ Page Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="depGroupWiseRpt.aspx.cs" Inherits="SwiftHrManagement.web.Report.AssetReport.depGroupWiseRpt" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    <div class="row">
        <div class="col-md-10 col-md-offset-1">
            <section class="panel">
                <div class="panel-body">
                    <div class="form-group">
                        <div class="ReportSubHeader" align="center">
                            <div id="divCompany" class="ReportHeader" runat="server"></div>
                            <b>Asset Group Wise Depreciation Report</b><br />
                    <asp:Label id="rptDes" runat="server" CssClass="txtlbl"></asp:Label><br />
                    Branch Name : <asp:Label ID="BRANCH_NAME" runat="server" CssClass="txtlbl"></asp:Label>
                        </div>                
                        <div style="text-align: right" class="ReportSubHeader">
                            Report Date :
                            <asp:Label ID="lblprintDate" runat="server" Text="Label" CssClass="txtlbl"></asp:Label>
                        </div>
                    </div>
                    <div class="form-group">
                        <div id="rpt" runat="server"></div>
                    </div>
                </div>
            </section>
        </div>
    </div>
</asp:Content>
