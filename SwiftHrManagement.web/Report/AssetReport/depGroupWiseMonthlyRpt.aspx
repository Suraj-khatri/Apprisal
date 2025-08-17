<%@ Page Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="depGroupWiseMonthlyRpt.aspx.cs" Inherits="SwiftHrManagement.web.Report.AssetReport.depGroupWiseMonthlyRpt" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    <div class="row">
        <div class="col-md-12">
            <section class="panel">
                    <header class="panel-heading">
                        User Add Details
                    </header>
                    <div class="panel-body">
                        <div class="form-group">
                            <div class="ReportSubHeader">
                                <div id="divCompany" class="ReportHeader" runat="server"></div>                        
                                <asp:Label id="rptDes" runat="server" CssClass="txtlbl"></asp:Label><br />
                                Branch Name : <asp:Label ID="BRANCH_NAME" runat="server" CssClass="txtlbl"></asp:Label>
                            </div>                
                            <div style="text-align: right" class="ReportSubHeader">
                                Report Date : <asp:Label ID="lblprintDate" runat="server" Text="Label"  CssClass="txtlbl"></asp:Label>
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
