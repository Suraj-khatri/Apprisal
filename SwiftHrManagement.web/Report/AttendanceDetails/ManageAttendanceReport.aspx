<%@ Page Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="ManageAttendanceReport.aspx.cs" Inherits="SwiftHrManagement.web.Report.AttendanceDetails.ManageAttendanceReport" Title="Swift HRM" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
<asp:UpdatePanel ID="udtpanel" runat="server">
    <ContentTemplate>
        <div class="row">
            <div class="col-md-8 col-md-offset-2">
            <div class="panel">     
                <header class="panel-heading">
                    <i class="fa fa-caret-right"></i>
                    Employee Attendance Reports
                </header>
            </div>
            <div class="panel panel-default">
                <header class="panel-heading">
                    Employee Wise Reports
                </header>
                <div class="panel-body">
                    <div class="form-group">
                        <asp:Label ID="lblmsg" runat="server" style="font-weight: 700" Visible="False"></asp:Label>
                    </div>    
                    <div class="form-group autocomplete-form">
                        <label>Employee Name :<span class="required">*</span></label>
                        <asp:RequiredFieldValidator ID="Rffd4" runat="server" ControlToValidate="txtEmpId" Display="None" 
                            ErrorMessage="*" SetFocusOnError="True" ValidationGroup="emp"></asp:RequiredFieldValidator>
                        <asp:TextBox ID="txtEmpId" runat="server" AutoComplete="Off" CssClass="form-control"></asp:TextBox>
                        <cc1:TextBoxWatermarkExtender ID="txtEmpId_TextBoxWatermarkExtender" runat="server" Enabled="True" 
                            TargetControlID="txtEmpId" WatermarkCssClass="form-control" WatermarkText="Autocomplete">
                        </cc1:TextBoxWatermarkExtender>
                        <cc1:AutoCompleteExtender ID="AutoCompleteExtender3" runat="server" CompletionInterval="10" 
                            CompletionListCssClass="autocompleteTextBoxLP" DelimiterCharacters="" EnableCaching="true" 
                            Enabled="true" MinimumPrefixLength="1" ServiceMethod="GetEmployeeList" 
                            ServicePath="~/Autocomplete.asmx" TargetControlID="txtEmpId"></cc1:AutoCompleteExtender>
                    </div>
                    <div class="form-group">
                        <label>From Date :<span class="required">*</span></label>
                        <asp:TextBox ID="txtfromDate" runat="server" CssClass="form-control"></asp:TextBox>
                        <cc1:CalendarExtender ID="txtfromDate_CalendarExtender" runat="server" Enabled="True" 
                            TargetControlID="txtfromDate"></cc1:CalendarExtender>
                        <asp:RequiredFieldValidator ID="Rffd1" runat="server" ControlToValidate="txtfromDate" 
                            Display="None" ErrorMessage="*" SetFocusOnError="True" ValidationGroup="emp">
                        </asp:RequiredFieldValidator></td>
                    </div>
                    <div class="form-group">
                        <label>To Date :<span class="required">*</span></label>
                        <asp:TextBox ID="txttoDate" runat="server" CssClass="form-control"></asp:TextBox>
                        <cc1:CalendarExtender ID="txttoDate_CalendarExtender" runat="server" Enabled="True" 
                            TargetControlID="txttoDate"></cc1:CalendarExtender>
                        <asp:RequiredFieldValidator ID="Rftd1" runat="server" 
                            ControlToValidate="txttoDate" Display="None" ErrorMessage="*" 
                            SetFocusOnError="True" ValidationGroup="emp"></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group">
                        <asp:Button ID="Btn_Search" runat="server" CssClass="btn btn-primary" Text="Search" 
                            onclick="Btn_Search_Click" ValidationGroup="emp"/>
                    </div>
                </div>
            </div>
            <div class="panel panel-default">
                <header class="panel-heading">
                    Datewise Summary Reports
                </header>
                <div class="panel-body">
                    <div class="form-group">
                        <label>From Date :<span class="required">*</span></label>
                        <asp:TextBox ID="FromDate" runat="server" CssClass="form-control"></asp:TextBox>
                        <cc1:CalendarExtender ID="FromDate_CalendarExtender" runat="server" Enabled="True" 
                            TargetControlID="FromDate"></cc1:CalendarExtender>
                        <asp:RequiredFieldValidator ID="Rffd2" runat="server"
                            ControlToValidate="FromDate" Display="None" ErrorMessage="*" SetFocusOnError="True"
                            ValidationGroup="dsr"></asp:RequiredFieldValidator></td>
                    </div>
                    <div class="form-group">
                        <label>To Date :<span class="required">*</span></label>
                        <asp:TextBox ID="ToDate" runat="server" CssClass="form-control"></asp:TextBox>
                        <cc1:CalendarExtender ID="ToDate_CalendarExtender" runat="server" Enabled="True" 
                            TargetControlID="ToDate"></cc1:CalendarExtender>
                        <asp:RequiredFieldValidator ID="Rftd2" runat="server"
                            ControlToValidate="ToDate" Display="None" ErrorMessage="*" SetFocusOnError="True" 
                            ValidationGroup="dsr"></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group">
                        <label>Branch :</label>
                        <asp:DropDownList ID="DdlBranchName1" runat="server" AutoPostBack="True" CssClass="form-control" 
                            onselectedindexchanged="DdlBranchName1_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>
                    <div class="form-group">
                        <label>Department :</label>
                        <asp:DropDownList ID="DdlDeptName1" runat="server" CssClass="form-control"></asp:DropDownList>
                    </div>
                     <div class="form-group">
                        <asp:Button ID="ButtonSearch" runat="server" CssClass="btn btn-primary" Text="Search" 
                            onclick="ButtonSearch_Click" ValidationGroup="dsr"/>
                    </div>
                </div>
            </div>
            <div class="panel panel-default">
                <header class="panel-heading">
                    Daily Reports
                </header>
                <div class="panel-body">
                    <div class="form-group">
                        <label>Report Date From:<span class="required">*</span></label>
                        <asp:TextBox ID="Report_Date" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="Rftd3" runat="server" ControlToValidate="Report_Date" 
                            Display="None" ErrorMessage="*" SetFocusOnError="True" ValidationGroup="dr"></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group">
                        <label>Report Date To :<span class="required">*</span></label>
                        <asp:TextBox ID="ReportDate_To" runat="server" CssClass="form-control"></asp:TextBox>
                        <cc1:CalendarExtender ID="ReportDate_To_CalendarExtender" runat="server" Enabled="True" 
                            TargetControlID="ReportDate_To"></cc1:CalendarExtender>
                        <asp:RequiredFieldValidator ID="Rfv1" runat="server" ControlToValidate="Report_Date" Display="None"
                            ErrorMessage="*" SetFocusOnError="True" ValidationGroup="dr"></asp:RequiredFieldValidator>
                        </div>
                    <div class="form-group">
                        <label>Report Type :</label>
                        <cc1:CalendarExtender ID="Report_Date_CalendarExtender" runat="server" Enabled="True" 
                            TargetControlID="Report_Date"></cc1:CalendarExtender>
                        <asp:DropDownList ID="DdlReportType" runat="server" CssClass="form-control">
                            <asp:ListItem>Summary Report</asp:ListItem>
                            <asp:ListItem>Detail Report</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="form-group">
                        <label>Branch :</label>
                        <asp:DropDownList ID="DdlBranchName2" runat="server" AutoPostBack="True" CssClass="form-control" 
                            onselectedindexchanged="DdlBranchName2_SelectedIndexChanged"></asp:DropDownList>
                    </div>
                    <div class="form-group">
                        <label>Department :</label>
                         <asp:DropDownList ID="DdlDeptName2" runat="server" CssClass="form-control" 
                             onselectedindexchanged="DdlDeptName2_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                    </div>
                    <div class="form-group">
                        <label>Employee :</label>
                        <asp:DropDownList ID="DdlEmloyeeName" runat="server" CssClass="form-control"></asp:DropDownList>
                    </div>
                     <div class="form-group">
                        <asp:Button ID="Button1" runat="server" CssClass="btn btn-primary" Text="Search" onclick="Button1_Click" 
                            ValidationGroup="dr"/>
                        <asp:Button ID="BtnExport" runat="server" CssClass="btn btn-primary" Text="Export To Excel"  
                            ValidationGroup="dr" onclick="BtnExport_Click"/>
                    </div>
                </div>
            </div>
            <div class="panel panel-default">
                <header class="panel-heading">
                    Attendance Reports
                </header>
                <div class="panel-body">
                    <div class="form-group">
                        <label>Report For:<label>
                        <asp:DropDownList ID="DdlRptNature" runat="server" CssClass="form-control" Width="100%">            
                            <asp:ListItem Value="Absent">Absent</asp:ListItem>           
                            <asp:ListItem Value="LateIn">Late In Only</asp:ListItem>
                            <asp:ListItem Value="EarlyOut">Early Out Only</asp:ListItem>
                            <asp:ListItem Value="Late_Early">Late In & Early Out Only</asp:ListItem>
                            <asp:ListItem Value="OnTime">On Time</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="form-group">
                        <label>Report Date From:<span class="required">*</span></label>
                        <asp:TextBox ID="from_date" runat="server" CssClass="form-control"></asp:TextBox>
                        <cc1:CalendarExtender ID="from_date_CalendarExtender" runat="server" Enabled="True" 
                            TargetControlID="from_date"></cc1:CalendarExtender>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                            ControlToValidate="from_date" Display="None" ErrorMessage="*" SetFocusOnError="True" 
                            ValidationGroup="rpt"></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group">
                        <label>Report Date To :<span class="required">*</span></label>
                        <asp:TextBox ID="to_date" runat="server" CssClass="form-control"></asp:TextBox>
                        <cc1:CalendarExtender ID="to_date_CalendarExtender" runat="server" Enabled="True" 
                            TargetControlID="to_date"></cc1:CalendarExtender>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="to_date" 
                            Display="None" ErrorMessage="*" SetFocusOnError="True" ValidationGroup="rpt"></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group">
                        <label>Branch Name:</label>
                        <asp:DropDownList ID="ddlBranchRpt" runat="server" AutoPostBack="True" CssClass="form-control" 
                            onselectedindexchanged="ddlBranchRpt_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>
                    <div class="form-group">
                        <label>Department Name:</label>
                        <asp:DropDownList ID="ddlDeptRpt" runat="server" CssClass="form-control" AutoPostBack="True"></asp:DropDownList>
                    </div>
                     <div class="form-group">
                        <asp:Button ID="BtnSearchRpt" runat="server" CssClass="btn btn-primary" Text="Search" 
                            ValidationGroup="rpt" onclick="BtnSearchRpt_Click"/>
                        <asp:Button ID="btnExportExcel" runat="server" CssClass="btn btn-primary" Text="Export To Excel"
                            ValidationGroup="rpt" onclick="btnExportExcel_Click"/>
                    </div>
                </div>
            </div>
        </div>
    </div>
</ContentTemplate>
</asp:UpdatePanel>
</asp:Content>
