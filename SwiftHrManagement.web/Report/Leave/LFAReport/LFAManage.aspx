<%@ Page Title="" Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true"
    CodeBehind="LFAManage.aspx.cs" Inherits="SwiftHrManagement.web.Report.Leave.LFAReport.LFAManage" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    <div class="row">
                <div class="col-md-8 col-md-offset-2">
                    <section class="panel">     
                        <header class="panel-heading">
                            <i class="fa fa-caret-right"></i>
                            LFA Report
                        </header>
                        <div class="panel-body">
                            <div class="form-group">
                                <label>From Date :<span class="errormsg">*</span></label>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="lfaReport"
                                    ControlToValidate="txtFrmDate" ErrorMessage="Required Field!!"> </asp:RequiredFieldValidator>
                                <asp:TextBox ID="txtFrmDate" runat="server" CssClass="form-control"></asp:TextBox>
                                <cc1:CalendarExtender ID="txtFromDate1_CalendarExtender" runat="server" Enabled="True"
                                    TargetControlID="txtFrmDate"></cc1:CalendarExtender>
                                
                            </div>
                            <div class="form-group">
                                <label class="text_form1">To Date :<span class="errormsg">*</span></label>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ValidationGroup="lfaReport"
                                    ControlToValidate="txtToDate" ErrorMessage="Required Field!!"> </asp:RequiredFieldValidator>
                                <asp:TextBox ID="txtToDate" runat="server" CssClass="form-control"></asp:TextBox>
                                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True" 
                                    TargetControlID="txtToDate"></cc1:CalendarExtender>
                                
                            </div>
                            <div class="form-group">
                                <label>Branch :</label>
                                <asp:DropDownList ID="ddlBranch" runat="server" CssClass="form-control"></asp:DropDownList>
                            </div>
                            <div class="form-group">
                                <asp:Button ID="btnReport" runat="server" CssClass="btn btn-primary" ValidationGroup="lfaReport"
                                    Text="View Report" onclick="btnReport_Click" />
                            </div>
                        </div>
                    </section>
                </div>
        </div>
</asp:Content>
