<%@ Page Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="onSiteDutyReportSearch.aspx.cs" Inherits="SwiftHrManagement.web.Report.OnSiteDuty.onSiteDutyReportSearch" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" src="../../Jsfunc.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">

    <div class="row">
        <div class="col-md-6 col-md-offset-3">
            <section class="panel">
                        <header class="panel-heading">
                       <i class="fa fa-caret-right"></i>       OnSite Duty Report
                        </header>
                        <div class="panel-body">
                            <div class=" form-group">
                                <label>From Date :<span class="required">*</span></label>
        <asp:TextBox ID="txtDateFrom" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                ControlToValidate="txtDateFrom" ErrorMessage="Required!"  ValidationGroup="onsiteduty">
            </asp:RequiredFieldValidator>
            <cc1:CalendarExtender ID="txtDateFrom_CalendarExtender" runat="server" 
                Enabled="True" TargetControlID="txtDateFrom">
            </cc1:CalendarExtender>
                                </div>
                            <div class="form-group">
                                <label>To Date :<span class="errormsg">*</span></label>
                                 <asp:TextBox ID="txtDateTo" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtDateTo"
                ErrorMessage="Required!" ValidationGroup="onsiteduty"></asp:RequiredFieldValidator>
            <cc1:CalendarExtender ID="txtDateTo_CalendarExtender" runat="server" 
                Enabled="True" TargetControlID="txtDateTo">
            </cc1:CalendarExtender>
                            </div>
                            <div class="form-group">
                                <label>Branch Name :</label>
                                 <asp:DropDownList ID="DdlFromBranch" runat="server" AutoPostBack="True" 
                CssClass="form-control" onselectedindexchanged="DdlFromBranch_SelectedIndexChanged" >
            </asp:DropDownList> 
                            </div>
                             <div class=" form-group">
                                <label>Department Name :</label>
                                 <asp:DropDownList ID="DdlFromDept" runat="server" AutoPostBack="True" 
                 CssClass="form-control" onselectedindexchanged="DdlFromDept_SelectedIndexChanged">
            </asp:DropDownList>
                                 </div>
                             <div class=" form-group">
                                <label>Employee Name :</label>
                                  <asp:DropDownList ID="ddlEmpName" runat="server" AutoPostBack="True" 
                 CssClass="form-control" onselectedindexchanged="DdlFromDept_SelectedIndexChanged">
            </asp:DropDownList> 
                                 </div>
                            <div class="form-group">
                                <asp:Button ID="Btn_Search" runat="server" CssClass="btn btn-primary" 
                    Text="Search"  ValidationGroup="onsiteduty" onclick="Btn_Search_Click" /> 
                            </div>
                            </div>
                          
                </section>
        </div>
    </div>

</asp:Content>
