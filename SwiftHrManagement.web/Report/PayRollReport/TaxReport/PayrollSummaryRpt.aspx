<%@ Page Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="PayrollSummaryRpt.aspx.cs" Inherits="SwiftHrManagement.web.Report.PayRollReport.TaxReport.PayrollSummaryRpt"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    <asp:UpdatePanel ID="up" runat="server">
        <ContentTemplate>
            <div class="row">
                <div class="col-md-12">
                    <section class="panel">
                        <div class="panel-body">
                            <div class="text-center">
                                <strong><font size="+1"><asp:Label ID="lblHeading" Text="myHeading" runat="server"></asp:Label></font></strong>  
                                <br />
                                 <strong> <asp:Label ID="lbldesc"  Text="" runat="server" ></asp:Label></strong>   
                                <br/>                          
                                <strong>                                
                                        <span>Payroll Summary Report</span> 
                                         <br />
                                         <asp:Label ID="lblReportType" runat="server" CssClass="txtlbl"></asp:Label>                                     
                                         <br />
                                        Report For the Year: <asp:Label ID="lblYearName" runat="server" CssClass="txtlbl"></asp:Label>
                                        <br />
                                        Branch Name: <asp:Label ID="lblBranchName" runat="server" CssClass="txtlbl"></asp:Label>
                                </strong> 
                            </div>
                             <div id="rptDiv" runat="server"></div>    
                        </div>
                    </section>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
