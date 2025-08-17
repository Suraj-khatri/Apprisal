<%@ Page Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="ManageAppraisalReportAll.aspx.cs" Inherits="SwiftHrManagement.web.Report.AppraisalSummary.ManageAppraisalReportAll" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
     <div class="row">
                <div class="col-md-8 col-md-offset-2">
                    <section class="panel">     
                        <header class="panel-heading">
                            <i class="fa fa-caret-right"></i>
                            Employee Appraisal Reports 
                        </header>
                        <div class="panel-body">
                            <div class="form-group">
                                <label>Branch :</label>
                                <asp:DropDownList ID="DdlBranchName" runat="server" CssClass="form-control" AutoPostBack="True" 
                                    onselectedindexchanged="DdlBranchName_SelectedIndexChanged">
                                </asp:DropDownList> 
                            </div>
                            <div class="form-group">
                                <label>Department :</label>
                                <asp:DropDownList ID="DdlDeptName" runat="server" CssClass="form-control" AutoPostBack="True" 
                                    onselectedindexchanged="DdlDeptName_SelectedIndexChanged"></asp:DropDownList> 
                            </div>
                            <div class="form-group">
                                 <label>Employee Name :</label>
                                 <asp:DropDownList ID="ddlEmpName" runat="server" CssClass="form-control"></asp:DropDownList>
                            </div>
                            <div class="form-group">
                                <label>From Date :<span class="errormsg">*</span></label>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Enabled="true"
                                     ControlToValidate="txtFromDate" ErrorMessage="Required" SetFocusOnError="true" ValidationGroup="appraisal">
                                </asp:RequiredFieldValidator>
                                <asp:TextBox ID="txtFromDate" runat="server" CssClass="form-control"></asp:TextBox>                                
                                <cc1:CalendarExtender ID="txtfromDate_CalendarExtender" runat="server" Enabled="True" TargetControlID="txtfromDate">
                            </cc1:CalendarExtender>
                            </div>
                            <div class="form-group">
                                <label>To Date :<span class="errormsg">*</span></label>
                                <asp:RequiredFieldValidator ID="rfv1" runat="server" Enabled="true"  ValidationGroup="appraisal"
                                        ControlToValidate="txtToDate" ErrorMessage="Required" SetFocusOnError="true"></asp:RequiredFieldValidator>                                    
                                <asp:TextBox ID="txtToDate" runat="server" CssClass="form-control"></asp:TextBox>                                   
                                <cc1:CalendarExtender ID="txttoDate_CalendarExtender" runat="server" Enabled="True" TargetControlID="txttoDate">
                                </cc1:CalendarExtender>
                            </div>
                            <div class="form-group">
                                 <asp:Button ID="Btn_Search" runat="server" CssClass="btn btn-primary" Text="Search" 
                                     ValidationGroup="appraisal" onclick="Btn_Search_Click"/>
                            </div>
                        </div>
                    </section>
                </div>
         </div>
</ContentTemplate>
</asp:UpdatePanel>
</asp:Content>