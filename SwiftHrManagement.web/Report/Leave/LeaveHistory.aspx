<%@ Page Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="LeaveHistory.aspx.cs" Inherits="SwiftHrManagement.web.Report.Leave.LeaveHistory" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" >
        <ContentTemplate> 
            <div class="row">
                <div class="col-md-8 col-md-offset-2">
                    <section class="panel">     
                        <header class="panel-heading">
                            <i class="fa fa-caret-right"></i>
                            Leave History Report
                        </header>
                            <div class="panel-body">
                                <div class="form-group">
                                    <label>Branch :</label>
                                    <asp:DropDownList ID="DdlBranchType" runat="server" CssClass="form-control" AutoPostBack="True"
                                            onselectedindexchanged="DdlBranchType_SelectedIndexChanged"></asp:DropDownList> 
                                </div>
                                <div class="form-group">
                                    <label>Department :</label>
                                    <asp:DropDownList ID="DdlDepartmentType" runat="server" CssClass="form-control" AutoPostBack="True" 
                                        onselectedindexchanged="DdlDepartmentType_SelectedIndexChanged"></asp:DropDownList> 
                                </div>
                                <div class="form-group">
                                    <label>Employee :</label>
                                    <asp:DropDownList ID="DdlEmployeeType" runat="server" CssClass="form-control"></asp:DropDownList>
                                </div>
                                <div class="form-group">
                                    <label>Year :</label>
                                    <asp:DropDownList ID="DdlYear" runat="server" CssClass="form-control"
                                        onselectedindexchanged="DdlYear_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                        <span class="errormsg"><asp:Label ID="lblyear" runat="server" Text=""></asp:Label></span> 
                                </div>
                                <div class="form-group">
                                    <label>Requested From Date :<span class="errormsg">*</span></label>
                                    <asp:TextBox ID="txtReqDateFrom" runat="server" CssClass="form-control" 
                                        ontextchanged="txtReqDateFrom_TextChanged" AutoPostBack="true"></asp:TextBox> 
                                    <cc1:CalendarExtender ID="txtReqDateFrom_CalendarExtender" runat="server" Enabled="True" 
                                        TargetControlID="txtReqDateFrom"></cc1:CalendarExtender>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" 
                                        runat="server" ControlToValidate="txtReqDateFrom" Display="Dynamic" ErrorMessage="Required!" 
                                        ValidationGroup="leavereport" SetFocusOnError="True"></asp:RequiredFieldValidator></td>
                                </div>
                                <div class="form-group">
                                    <label>To Date :<span class="errormsg">*</span></label>
                                        <asp:TextBox ID="txtReqDateTo" runat="server" CssClass="form-control" 
                                            ontextchanged="txtReqDateTo_TextChanged" AutoPostBack="true"></asp:TextBox> 
                                    <cc1:CalendarExtender ID="ReqDateTo_CalendarExtender" runat="server" Enabled="True" 
                                        TargetControlID="txtReqDateTo"></cc1:CalendarExtender>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtReqDateTo" 
                                    Display="Dynamic" ErrorMessage="Required!" ValidationGroup="leavereport" SetFocusOnError="True">
                                    </asp:RequiredFieldValidator></td>
                                </div>
                                <div class="form-group">
                                    <asp:Button ID="BtnShowReportType" runat="server" Text="Summary Report" CssClass="btn btn-primary" 
                                        ValidationGroup="leavereport" onclick="BtnShowReportType_Click" />
                                    <asp:Button ID="BtnDetailReport" runat="server" Text="Detail Report" CssClass="btn btn-primary" 
                                        onclick="BtnDetailReport_Click" /> &nbsp;&nbsp;
                                    <asp:Button ID="BtnIndividualReport" runat="server" Text="Individual Report" CssClass="btn btn-primary"
                                        onclick="BtnIndividualReport_Click" />&nbsp;
                                    <asp:Button ID="BtnLeaveStatus" runat="server" Text="LeaveStatus" CssClass="btn btn-primary" 
                                        onclick="BtnLeaveStatus_Click"/>
                                </div>
                                <div class="form-group">
                                    <asp:Label ID="LblMsg" runat="server" CssClass="errormsg" Text=""></asp:Label>
                                </div>
                            </div>
                        </section>
                    </div>
                </div>
         </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

