<%@ Page Title="" Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="SwiftHrManagement.web.LeaveManagementModule.Deduction.Manage" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    <div class="form-group autocomplete-form">
        <div class="col-md-10 col-md-offset-1">
            <div class="panel">
                <header class="panel-heading">
                    <i class="fa fa-caret-right"></i>
                    Unpaid Leave & Absent History
                 </header>
                <div class="panel-body">
                    Please enter valid data!<span class="required"> (* Required fields!)</span>
                    <div class="row">
                        <div class="col-md-6 form-group">
                            <label>From Date:<span class="required">*</span></label>
                            <asp:TextBox ID="TxtFromDate" runat="server" CssClass="form-control">
                               </asp:TextBox>
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                ControlToValidate="TxtFromDate" Display="Dynamic" ErrorMessage="Required!"
                                SetFocusOnError="True" ValidationGroup="rpt">
                            </asp:RequiredFieldValidator>
                            <cc1:CalendarExtender ID="TxtFromDate_CalendarExtender" runat="server"
                                Enabled="True" TargetControlID="TxtFromDate">
                            </cc1:CalendarExtender>
                        </div>
                        <div class="col-md-6 form-group">
                            <label>To Date:<span class="required">*</span></label>
                            <asp:TextBox ID="TxtToDate" runat="server" CssClass="form-control"
                                 MaxLength="100"></asp:TextBox>
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                                 ControlToValidate="TxtToDate" Display="Dynamic" ErrorMessage="Required!"
                                 SetFocusOnError="True" ValidationGroup="rpt">
                             </asp:RequiredFieldValidator>
                             <cc1:CalendarExtender ID="TxtToDate_CalendarExtender" runat="server"
                                 Enabled="True" TargetControlID="TxtToDate">
                             </cc1:CalendarExtender>
                        </div>
                        <div class="col-md-6 form-group">
                             <asp:Button ID="BtnViewRpt" runat="server" CssClass="btn btn-primary" ValidationGroup="rpt"
                             OnClick="BtnViewRpt_Click" Text="Show Report" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
