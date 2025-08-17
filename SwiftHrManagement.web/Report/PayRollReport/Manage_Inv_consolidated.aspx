<%@ Page Title="" Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true"
    CodeBehind="Manage_Inv_consolidated.aspx.cs" Inherits="SwiftHrManagement.web.Report.PayRollReport.Manage_Inv_consolidated" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    <div class="row">
        <div class="col-lg-6 col-md-offset-3">
             <section class="panel">
            <header class="panel-heading">
                 <i class="fa fa-caret-right" aria-hidden="true"></i> 
                       Individual Consolidated Salary Report
                        </header>
            <div class="panel-body">
                <label>Yearly Salary Sheet report</label>
                <div class="form-group">
                    <label>Year:<span class="errormsg"></span> </label>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1"
                        runat="server" ControlToValidate="DdlYear" Display="Dynamic"
                        ErrorMessage="Required!" ValidationGroup="payroll" SetFocusOnError="True">
                    </asp:RequiredFieldValidator>
                    <asp:DropDownList ID="DdlYear" runat="server" CssClass="form-control">
                    </asp:DropDownList>
                    
                </div>
                <div class="form-group">
                    <asp:Button ID="BtnSalary" runat="server" CssClass="btn btn-primary" Text="Consolidated Salary Report"
                        ValidationGroup="payroll" OnClick="BtnSalary_Click" />
                </div>
            </div>
            </section>
        </div>
    </div>



</asp:Content>
