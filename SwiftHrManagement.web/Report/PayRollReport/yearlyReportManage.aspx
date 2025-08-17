<%@ Page Title="" Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true"
    CodeBehind="yearlyReportManage.aspx.cs" Inherits="SwiftHrManagement.web.Report.PayRollReport.yearlyReport" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">

    <div class="row">
        <div class="col-lg-6 col-md-offset-3">
            <section class="panel">
            <header class="panel-heading">
                <i class="fa fa-caret-right" aria-hidden="true"></i> 
                      	Yearly Salary Sheet report
                        </header>
            <div class="panel-body">
                <div class="form-group">
                    <label>Year: <span class="errormsg">*</span></label>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1"
                        runat="server" ControlToValidate="DdlYear" Display="Dynamic"
                        ErrorMessage="Required!" ValidationGroup="payroll" SetFocusOnError="True">
                    </asp:RequiredFieldValidator>
                    <asp:DropDownList ID="DdlYear" runat="server" CssClass="form-control">
                    </asp:DropDownList>
                    
                </div>
                <div class="form-group">
                    <label>Branch: </label>
                    <asp:DropDownList ID="DdlBranchName" runat="server" CssClass="form-control"
                        AutoPostBack="True"
                        OnSelectedIndexChanged="DdlBranchName_SelectedIndexChanged" >
                    </asp:DropDownList>
                </div>
                <div class="form-group">
                    <label>Department: </label>
                    <asp:DropDownList ID="DdlDeptName" runat="server" CssClass="form-control"
                        AutoPostBack="True"
                        OnSelectedIndexChanged="DdlDeptName_SelectedIndexChanged" >
                    </asp:DropDownList>
                </div>
                <div class="form-group">
                    <label> Employee Name: </label>
                    <asp:DropDownList ID="DdlEmpName" runat="server" CssClass="form-control">
                    </asp:DropDownList>
                </div>
                <div class="form-group">
                    <asp:Button ID="BtnSalary" runat="server" CssClass="btn btn-primary" Text="Yearly Consolidated Report"
                        ValidationGroup="payroll"  OnClick="BtnSalary_Click" />

                    <asp:Button ID="BtnIndReport" runat="server" CssClass="btn btn-primary" Text="Individual Consolidated Report"
                        ValidationGroup="payroll" OnClick="BtnIndReport_Click" />

                </div>
            </div>
            </section>
        </div>
    </div>

</asp:Content>
