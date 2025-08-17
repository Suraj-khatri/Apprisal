<%@ Page Title="" Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="SwiftHrManagement.web.LeaveManagementModule.Calender.Events.Manage" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
     <div class="row">
        <div class="col-md-8 col-md-offset-2">
            <section class="panel">
                <header class="panel-heading">
                    <i class="fa fa-caret-right"></i>
                    Event Calendar Entry
                </header>
                <div class="panel-body">
                    <div class="form-group">
                        <span>Please enter valid data!</span><span class="errormsg"> (* Required Fields)</span>
                        <asp:Label ID="LblMsg" runat="server"></asp:Label>    
                    </div>
                    <div class="form-group">
                        <label>Branch Name:</label>
                        <asp:DropDownList ID="DdlBranch" runat="server" CssClass="form-control"></asp:DropDownList>
                    </div>
                    <div class="row">
                        <div class="col-md-6 form-group">
                            <label>Event Title:<span class="errormsg">*</span></label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TxtLeaveTitle" 
                                Display="None" ErrorMessage="*" ValidationGroup="Leave"></asp:RequiredFieldValidator>
                            <asp:TextBox ID="TxtLeaveTitle" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="col-md-6 form-group">
                            <label>Date:<span class="errormsg">*</span></label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TxtDate" 
                                Display="None" ErrorMessage="*" ValidationGroup="Leave"></asp:RequiredFieldValidator>
                            <asp:TextBox ID="TxtDate" runat="server" CssClass="form-control"></asp:TextBox>
                            <cc1:CalendarExtender ID="TxtDate_CalendarExtender" runat="server" Enabled="True" TargetControlID="TxtDate">
                            </cc1:CalendarExtender>
                        </div>
                    </div>
                    <div class="form-group">
                        <label>Venue:</label>
                        <asp:TextBox ID="TxtVenue" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label>Description:</label>
                        <asp:TextBox ID="TxtDescription" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <asp:Button ID="BtnSave" runat="server" CssClass="btn btn-primary" Text="Save" onclick="BtnSave_Click" 
                            ValidationGroup="Leave" />
                        <cc1:ConfirmButtonExtender ID="BtnSave_ConfirmButtonExtender" runat="server" 
                            ConfirmText="Confirm To Save?" Enabled="True" TargetControlID="BtnSave">
                        </cc1:ConfirmButtonExtender>
                        <asp:Button ID="BtnDelete" runat="server" CssClass="btn btn-primary" onclick="BtnDelete_Click" Text="Delete" />
                        <cc1:ConfirmButtonExtender ID="BtnDelete_ConfirmButtonExtender" runat="server" 
                            ConfirmText="Confirm To Delete?" Enabled="True" TargetControlID="BtnDelete">
                        </cc1:ConfirmButtonExtender>
                        <asp:Button ID="BtnBack" runat="server" CssClass="btn btn-primary" onclick="BtnBack_Click" Text="Back" />
                    </div>
                </div>
            </section>
        </div>
    </div>
</asp:Content>
