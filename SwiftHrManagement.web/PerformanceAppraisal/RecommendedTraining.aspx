<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/SwiftHRManager.Master" CodeBehind="RecommendedTraining.aspx.cs" Inherits="SwiftHrManagement.web.PerformanceAppraisal.RecommendedTraining" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    <asp:UpdatePanel ID="updatePanel" runat="server">
<ContentTemplate>
        <div class="row">
                <div class="col-md-8 col-md-offset-2">
                    <section class="panel">     
                        <header class="panel-heading">
                            <i class="fa fa-caret-right"></i>
                            Recommended Training Report
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
                                <label>From Date:<span class="errormsg">*</span></label>
                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ValidationGroup="datewiserpt" 
                                     ControlToValidate ="txtFromDate" ErrorMessage="Required Field!!"> </asp:RequiredFieldValidator>
                                <asp:TextBox ID="txtFromDate" runat="server"  CssClass="form-control"></asp:TextBox>                                
                                <cc1:CalendarExtender ID="CalendarExtender6" runat="server" Enabled="True" TargetControlID="txtFromDate">
                                </cc1:CalendarExtender>                               
                            </div>
                            <div class="form-group">
                                <label>To Date:<span class="errormsg">*</span></label>
                                <asp:TextBox ID="txtToDate" runat="server" CssClass="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtToDate" 
                                    ErrorMessage="Required Field!!" ValidationGroup="datewiserpt"> </asp:RequiredFieldValidator>
                                <cc1:CalendarExtender ID="CalendarExtender7" runat="server" Enabled="True" TargetControlID="txtToDate">
                                </cc1:CalendarExtender>                                    
                            </div>
                            <div class="form-group">
                                <asp:Button ID="btnSummary" runat="server" CssClass="btn btn-primary" Text="Summary Rpt" 
                                    ValidationGroup="datewiserpt" onclick="btnSummary_Click"  />
                                <asp:Button ID="btnExport" runat="server" CssClass="btn btn-primary" Text="Export Summary Rpt" 
                                    ValidationGroup="datewiserpt" onclick="btnExport_Click" />
                            </div>
                        </div>
                    </section>
                </div>
            </div>
</ContentTemplate>
</asp:UpdatePanel>
</asp:Content>
