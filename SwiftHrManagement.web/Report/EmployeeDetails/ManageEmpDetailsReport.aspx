<%@ Page Title="" Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="ManageEmpDetailsReport.aspx.cs" Inherits="SwiftHrManagement.web.Report.EmployeeDetails.ManageEmpDetailsReport" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    <div class="row">
        <div class="col-md-8 col-md-offset-2">
            <div class="panel">
                <header class="panel-heading">
                    <i class="fa fa-caret-right"></i>
                    Employee Detail Report
                </header>
            </div>
            <div class="panel panel-default">
                    <header class="panel-heading">
                        Employee profile records
                    </header>
                    <div class="panel-body">
                        <div class="form-group">
                            <strong></strong>
                        </div>
                        <div class="form-group">
                            <label>Employee Name:</label>
                        </div>
                        <div class="form-group">
                            <asp:DropDownList ID="DdlEmpName" runat="server" CssClass="form-control" Width="300px">
                            </asp:DropDownList>         
                        </div>
                        <div class="form-group">
                            <asp:Button ID="BtnViewEmpHisRpt" runat="server" CssClass="btn btn-primary" 
                                onclick="BtnViewEmpHisRpt_Click" Text="View Report" />&nbsp;
                            <asp:Button ID="btnEmpSummaryRpt" runat="server" 
                                Text="Employee Profile With Education Rpt" CssClass="btn btn-primary" 
                                onclick="btnEmpSummaryRpt_Click" />
                        </div>
                    </div>
                </div>
            <div class="panel panel-default">
                <header class="panel-heading">
                    Employee Birthday List
                </header>
                    <div class="panel-body">
                        <div class="form-group">
                            <strong></strong>
                        </div>
                        <div class="form-group">
                            <label>Form Date:<span class="required">*</span></label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                ErrorMessage="Required!" ControlToValidate="txtFromDate1" Display="Dynamic" 
                                SetFocusOnError="True" ValidationGroup="bday"></asp:RequiredFieldValidator>
                            <asp:TextBox ID="txtFromDate1" runat="server" CssClass="form-control"></asp:TextBox>&nbsp;
                        
                        
                            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" 
                                Enabled="True" TargetControlID="txtFromDate1">
                            </cc1:CalendarExtender>
                        </div>
                        <div class="form-group">
                            <label>To Date:</label>
                            <asp:RequiredFieldValidator 
                                ID="RequiredFieldValidator2" runat="server" ErrorMessage="Required!" 
                                ControlToValidate="txtToDate1" Display="Dynamic" SetFocusOnError="True" 
                                ValidationGroup="bday">
                            </asp:RequiredFieldValidator>
                            <asp:TextBox ID="txtToDate1" runat="server" CssClass="form-control" 
                                MaxLength="100"></asp:TextBox>&nbsp;
                        
                            <cc1:CalendarExtender ID="CalendarExtender2" runat="server" 
                                Enabled="True" TargetControlID="txtToDate1">
                            </cc1:CalendarExtender> 
                        </div>
                        <div class="form-group">
                            <asp:Button ID="BtnSearchBrthday" runat="server" CssClass="btn btn-primary" 
                                Text="View Report" onclick="BtnSearchBrthday_Click" 
                                ValidationGroup="bday" />
                        </div>
                    </div>
                </div>
            <div class="panel panel-default">
                <header class="panel-heading">
                    Employee Supervisor Report
                </header>
                    <div class="panel-body">
                    <div class="form-group">
                        <label>Branch:</label>
                        <asp:DropDownList ID="ddlBranch" runat="server" 
                            CssClass="form-control" AutoPostBack="True" 
                            onselectedindexchanged="ddlBranch_SelectedIndexChanged"></asp:DropDownList>
                    </div>
                    <div class="form-group">
                        <label>Department Name:</label>
                        <asp:DropDownList ID="ddlDept" runat="server" CssClass="form-control"></asp:DropDownList>
                    </div>
                    <div class="form-group">
                        <asp:Button ID="btnSupRpt" runat="server" CssClass="btn btn-primary" 
                             Text="View Report" onclick="btnSupRpt_Click" />&nbsp;
                        <asp:Button ID="btnSuperRpt_new" runat="server" CssClass="btn btn-primary" 
                             Text="View Supervisor Rpt" onclick="btnSuperRpt_new_Click" />&nbsp;
                        <asp:Button ID="btnExportToExcel" runat="server" CssClass="btn btn-primary" 
                             Text="Export To Excel" onclick="btnExportToExcel_Click" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

