<%@ Page Title="Swift HRM" Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="ManageLeaveReport.aspx.cs" Inherits="SwiftHrManagement.web.Report.Leave.ManageLeaveReport" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" >
        <ContentTemplate> 
             <div class="row">
                <div class="col-md-8 col-md-offset-2">
                    <div class="panel">
                        <header class="panel-heading">
                            <i class="fa fa-caret-right"></i>
                           Leave Summary Report
                        </header>
                    </div>
                        <div class="panel panel-default">
                            <header class="panel-heading">  
                                <strong>Leave Summary Report</strong>
                            </header>
                            <div class="panel-body">
                                <div class="form-group">
                                    <label>Fiscal Year:</label>
                                    <asp:DropDownList ID="DDL_YEAR" runat="server" CssClass="form-control"></asp:DropDownList>
                                </div>
                                <div class="form-group autocomplete-form">
                                    <label>Employee Name:</label>    
                                    <asp:Label ID="lblEmpName" runat="server"></asp:Label>           
                                     <asp:TextBox ID="txtEmpName" runat="server" AutoComplete="Off" 
                                        AutoPostBack="true"  CssClass="form-control" 
                                         ontextchanged="txtEmpName_TextChanged"></asp:TextBox>
                                    <cc1:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" 
                                        CompletionInterval="10" CompletionListCssClass="autocompleteTextBoxLP" 
                                        DelimiterCharacters="" EnableCaching="true" Enabled="true" 
                                        MinimumPrefixLength="1" ServiceMethod="GetEmployeeList" 
                                        ServicePath="~/Autocomplete.asmx" TargetControlID="txtEmpName">
                                    </cc1:AutoCompleteExtender>                        
                                    <cc1:TextBoxWatermarkExtender ID="vendor_TextBoxWatermarkExtender" 
                                        runat="server" Enabled="True" TargetControlID="txtEmpName" 
                                        WatermarkCssClass="form-control" WatermarkText="All Employee">
                                    </cc1:TextBoxWatermarkExtender>      
                                </div>
                                <div class="form-group">
                                    <asp:Button ID="BTN_VIEW" runat="server" CssClass="btn btn-primary" 
                                        onclick="BTN_VIEW_Click" Text="View Summary" />&nbsp;
                
                                    <asp:Button ID="btnLSumm" runat="server" CssClass="btn btn-primary" 
                                        Text="View Leave Summary" onclick="btnLSumm_Click" />&nbsp;
                
                                    <asp:Button ID="btnLDetail" runat="server" CssClass="btn btn-primary" 
                                        Text="View Leave Detail" onclick="btnLDetail_Click" />
                                </div>
                            </div>
                        </div>
                        <div class="panel panel-default">
                            <header class="panel-heading">  
                                <strong>Holiday & Leave Type Report</strong>
                            </header>
                            <div class="panel-body">
                                <div class="form-group">
                                    <label>From Date:</label>
                                    <asp:TextBox ID="TxtFromDate" runat="server" CssClass="form-control"></asp:TextBox>
                                    <cc1:CalendarExtender ID="TxtFromDate_CalendarExtender" runat="server" 
                                        Enabled="True" TargetControlID="TxtFromDate">
                                    </cc1:CalendarExtender>
                                </div>
                                <div class="form-group">
                                    <label>To Date:</label>
                                    <asp:TextBox ID="TxtToDate" runat="server" CssClass="form-control"></asp:TextBox>
                                    <cc1:CalendarExtender ID="TxtToDate_CalendarExtender" runat="server" 
                                        Enabled="True" TargetControlID="TxtToDate">
                                    </cc1:CalendarExtender>
                                </div>
                                <div class="form-group autocomplete-form">
                                    <label>Employee Name:</label>
                                    <asp:Label ID="lblEmployee" runat="server"></asp:Label>               
                                    <asp:TextBox ID="txtEmployeeName" runat="server" AutoComplete="Off" 
                                        AutoPostBack="true"  CssClass="form-control" 
                                        ontextchanged="txtEmployeeName_TextChanged"></asp:TextBox>
                                    <cc1:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" 
                                        CompletionInterval="10" CompletionListCssClass="autocompleteTextBoxLP" 
                                        DelimiterCharacters="" EnableCaching="true" Enabled="true" 
                                        MinimumPrefixLength="1" ServiceMethod="GetEmployeeList" 
                                        ServicePath="~/Autocomplete.asmx" TargetControlID="txtEmployeeName">
                                    </cc1:AutoCompleteExtender>                        
                                    <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" 
                                        runat="server" Enabled="True" TargetControlID="txtEmployeeName" 
                                        WatermarkCssClass="form-control" WatermarkText="All Employee">
                                    </cc1:TextBoxWatermarkExtender> 
                                </div>
                                <div class="form-group">
                                    <asp:Button ID="Btnrpt" runat="server" CssClass="btn btn-primary" 
                                        onclick="Btnrpt_Click" Text="Leave Detailed" />&nbsp;
                                    <asp:Button ID="BtnReport" runat="server" onclick="BtnReport_Click" Text="LeaveType Detail Report" CssClass="btn btn-primary" />
                                </div>
                                <div class="form-group">
                                    <asp:Label ID="Label1" runat="server" CssClass="errormsg" Text=""></asp:Label>
                                </div>
                            </div>
                        </div>
                            
                        <div class="panel panel-default">
                            <header class="panel-heading">  
                                <strong>Leave Summary Report</strong>
                            </header>
                            <div class="panel-body">
                                <div class="form-group">
                                    <label>Branch:</label>
                                    <asp:DropDownList ID="DdlBranchType" runat="server" CssClass="form-control" 
                                        AutoPostBack="True" onselectedindexchanged="DdlBranchType_SelectedIndexChanged"></asp:DropDownList>       
                                </div>
                                <div class="form-group">
                                    <label>Department:</label>
                                    <asp:DropDownList ID="DdlDepartmentType" runat="server" CssClass="form-control" 
                                          AutoPostBack="True" onselectedindexchanged="DdlDepartmentType_SelectedIndexChanged"></asp:DropDownList>              
                                </div>
                                <div class="form-group">
                                    <label>Employee:</label>
                                    <asp:DropDownList ID="DdlEmployeeType" runat="server" CssClass="form-control" onselectedindexchanged="DdlEmployeeType_SelectedIndexChanged" ></asp:DropDownList>      
                                </div>
                                <div class="form-group">
                                    <label>From Date:<span class="errormsg">*</span></label>
                                    <asp:TextBox ID="txtReqDateFrom" runat="server" CssClass="form-control"></asp:TextBox>   
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                        ControlToValidate="txtReqDateFrom" Display="Dynamic" ErrorMessage="Required!" 
                                        ValidationGroup="leavereport"  SetFocusOnError="True">
                                    </asp:RequiredFieldValidator>
                                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" 
                                        Enabled="True" TargetControlID="txtReqDateFrom">
                                    </cc1:CalendarExtender>
                                </div>
                                <div class="form-group">
                                    <label>To Date:<span class="errormsg">*</span></label>
                                    <asp:TextBox ID="ReqDateTo" runat="server" CssClass="form-control"></asp:TextBox> 
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ReqDateTo" 
                                        Display="Dynamic" ErrorMessage="Required!" ValidationGroup="leavereport" 
                                        SetFocusOnError="True"></asp:RequiredFieldValidator><cc1:CalendarExtender ID="CalendarExtender2" runat="server" 
                                        Enabled="True" TargetControlID="ReqDateTo">
                                    </cc1:CalendarExtender>
                                </div>
                                <div class="form-group">
                                    <asp:Button ID="BtnShowReportType" runat="server" CssClass="btn btn-primary" 
                                        onclick="BtnShowReportType_Click" Text="Summary Report" 
                                        ValidationGroup="leavereport" />&nbsp;
                                    <asp:Button ID="BtnDetailReport" runat="server" CssClass="btn btn-primary" 
                                        onclick="BtnDetailReport_Click" Text="Detail Report" />&nbsp;&nbsp;
                                    <asp:Button ID="BtnIndividualReport" runat="server" CssClass="btn btn-primary" 
                                        onclick="BtnIndividualReport_Click" Text="Individual Report" />&nbsp;
                                    <asp:Button ID="BtnLeaveStatus" runat="server" Text="Leave Status" 
                                        CssClass="btn btn-primary" onclick="BtnLeaveStatus_Click"/>
                                </div>
                                <div class="form-group">
                                    <asp:Label ID="LblMsg" runat="server" CssClass="errormsg" Text=""></asp:Label>
                                </div>
                            </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

