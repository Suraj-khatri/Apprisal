<%@ Page Title="" Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true"
    CodeBehind="SocialSecurityTaxForm.aspx.cs" Inherits="SwiftHrManagement.web.Report.PayRollReport.TaxReport.SocialSecurityTaxForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style10 {
            height: 26px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    <asp:UpdatePanel ID="up" runat="server">
        <ContentTemplate>
            <div class="row">
                <div class="col-lg-6 col-md-offset-3">
                    <section class="panel">
            <header class="panel-heading">
                 <i class="fa fa-caret-right" aria-hidden="true"></i> 
                    Payroll Summary Report
                        </header>
            <div class="panel-body">
                <div class="form-group">

                    <label>Report Type: <span class="errormsg">*</span> </label>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3"
                        runat="server" ControlToValidate="DdlReportType" Display="Dynamic"
                        ErrorMessage="Required!" ValidationGroup="rpt_payroll" SetFocusOnError="True"></asp:RequiredFieldValidator>
                    <asp:DropDownList ID="DdlReportType" runat="server" CssClass="form-control">
                    </asp:DropDownList>
                    
                </div>
                <div class="form-group">
                    <label>Fiscal Year:<span class="errormsg">*</span> </label>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1"
                        runat="server" ControlToValidate="DdlFiscalYear" Display="Dynamic"
                        ErrorMessage="Required!" ValidationGroup="rpt_payroll" SetFocusOnError="True"></asp:RequiredFieldValidator>
                    <asp:DropDownList ID="DdlFiscalYear" runat="server" CssClass="form-control">
                    </asp:DropDownList>
                    
                </div>
                <div class="form-group">
                    <label>Branch Name:</label>
                    <asp:DropDownList ID="DdlBranchName" runat="server" CssClass="form-control"
                        AutoPostBack="True">
                    </asp:DropDownList>
                </div>
                <div class="form-group">
                    <asp:Button ID="BtnSearchSummaryRpt" runat="server" Text="Search Report"
                        CssClass="btn btn-primary" OnClick="BtnSearchSummaryRpt_Click"
                        ValidationGroup="rpt_payroll" />
                </div>
                <br/>
                <label>Social Security Tax Report</label>
                <div class="form-group">
                    <label>Fiscal Year:<span class="errormsg">*</span> </label>
                    <asp:RequiredFieldValidator
                        ID="RequiredFieldValidator2" runat="server" ControlToValidate="DdlYear"
                        Display="Dynamic" ErrorMessage="Required!" ValidationGroup="Tax"
                        SetFocusOnError="True"></asp:RequiredFieldValidator>
                    <asp:DropDownList ID="DdlYear" runat="server" CssClass="form-control">
                    </asp:DropDownList>
                   
                </div>
                <div class="form-group">
                    <label>Month: </label>
                    <asp:DropDownList ID="DdlMonth" runat="server" CssClass="form-control">
                    </asp:DropDownList>
                </div>
                <div class="form-group">
                    <asp:Label ID="LblMassge" runat="server" Text=""></asp:Label>
                    <asp:Button ID="BtnShowReport" runat="server" Text="Show Report"
                        CssClass="btn btn-primary" ValidationGroup="Tax" OnClick="BtnShowReport_Click" />
                </div>
            </div>
            </section>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
