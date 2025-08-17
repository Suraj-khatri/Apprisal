<%@ Page Title="" Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="SwiftHrManagement.web.Report.BranchReport.Manage" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    <div class="row">
        <div class="col-md-8 col-md-offset-2">
            <div class="panel">     
                <header class="panel-heading">
                    <i class="fa fa-caret-right"></i>
                    Branch Summary Report
                </header>
            </div>
            <div class="panel panel-default">
                <header class="panel-heading">
                    Branch Employee Report
                </header>
                <div class="panel-body">
                    <div class="form-group">
                        <label>From Date :<span class="errormsg">*</span></label>
                        <asp:TextBox ID="txtFromDate" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Required!" 
                            ControlToValidate="txtFromDate" Display="Dynamic" SetFocusOnError="True" 
                            ValidationGroup="sup"></asp:RequiredFieldValidator>
                        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True" 
                            TargetControlID="txtFromDate"></cc1:CalendarExtender>
                    </div>
                    <div class="form-group">
                        <label>To Date :<span class="errormsg">*</span></label>
                        <asp:TextBox ID="txtToDate" runat="server" CssClass="form-control" MaxLength="100"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Required!" 
                            ControlToValidate="txtToDate" Display="Dynamic" SetFocusOnError="True" 
                            ValidationGroup="sup"></asp:RequiredFieldValidator>   
                        <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Enabled="True" 
                            TargetControlID="txtToDate"></cc1:CalendarExtender>           
                    </div>
                    <div class="form-group">
                        <label>Employee Name :</label>
                        <asp:DropDownList ID="ddlEmployeeName" runat="server" CssClass="form-control"></asp:DropDownList>
                    </div>
                    <div class="form-group">
                        <asp:Button ID="BtnLeaveRpt" runat="server" CssClass="btn btn-primary" Text="Leave Summary Rpt" 
                            onclick="BtnLeaveRpt_Click" ValidationGroup="sup"/>
                        <asp:Button ID="btnLeaveDetail" runat="server" CssClass="btn btn-primary" Text="Leave Detail Rpt" 
                            onclick="btnLeaveDetail_Click"  ValidationGroup="sup"/>
                        <asp:Button ID="BtnAttendanceRpt" runat="server" CssClass="btn btn-primary" Text="Attendance Rpt" 
                            onclick="BtnAttendanceRpt_Click"  ValidationGroup="sup"/>
                        <asp:Button ID="BtnTrainingRpt" runat="server" CssClass="btn btn-primary" Text="Training Rpt" 
                            onclick="BtnTrainingRpt_Click"  ValidationGroup="sup"/> 
                     </div> 
                </div>
            </div>
            <div class="panel panel-default">
                <header class="panel-heading">
                    Payroll Report
                </header>
                <div class="panel-body">
                    <div class="form-group">
                        <label>Fiscal Year :<span class="errormsg">*</span></label>
                        <asp:DropDownList ID="ddlFiscalYear" runat="server" CssClass="form-control"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Required!" 
                            ControlToValidate="ddlFiscalYear" Display="Dynamic" SetFocusOnError="True" 
                            ValidationGroup="payroll"></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group">
                        <label>Month :</label>
                         <asp:DropDownList ID="ddlMonth" runat="server" CssClass="form-control"></asp:DropDownList>        
                    </div>
                    <div class="form-group">
                        <label>Employee Name :</label>
                         <asp:DropDownList ID="DdlEmpName" runat="server" CssClass="form-control"></asp:DropDownList>
                    </div>
                    <div class="form-group">
                        <asp:Button ID="BtnPayrollRpt" runat="server" CssClass="btn btn-primary" Text="Payroll Rpt" 
                            ValidationGroup="payroll" onclick="BtnPayrollRpt_Click" />       
                        <asp:Button ID="BtnExExcel" runat="server" CssClass="btn btn-primary" Text="Export To Excel" 
                            ValidationGroup="payroll" onclick="BtnExExcel_Click"/>  
                    </div>
                </div>
            </div>
        </div>
    </div>   
</asp:Content>
