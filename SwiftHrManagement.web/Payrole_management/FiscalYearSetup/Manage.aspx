<%@ Page Title="" Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="SwiftHrManagement.web.Payrole_management.FiscalYearSetup.Manage" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style10 {
        }

        .style11 {
            font-weight: bold;
            color: #333333;
            width: 139px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    <div class="row">
        <div class="col-md-6 col-md-offset-3">
            <section class="panel">
			    <header class="panel-heading">
                    <i class="fa fa-caret-right" aria-hidden="true"></i>  
                    Fiscal Year Setup
                </header>
                <div class="panel-body">
                    <div class="form-group">
                        Please enter valid data!<span class="required"> (* Required fields!)</span>
                        <asp:Label ID="LblMsg" runat="server"></asp:Label>
                    </div>                            
                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-group">
                                <label>Fiscal Year English:<span class="errormsg">*</span></label>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"
                                    ErrorMessage="Required!" ControlToValidate="TxtfyEnglish" AutoComplete="Off"
                                    Display="Dynamic" ValidationGroup="fisyear" BorderColor="#FFFF66" SetFocusOnError="True">
                                </asp:RequiredFieldValidator>
                                <asp:TextBox ID="TxtfyEnglish" runat="server" CssClass="form-control" Width="100%"></asp:TextBox>                                            
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <label>Fiscal Year Nepali:<span class="errormsg">*</span></label>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                    ErrorMessage="Required!" ControlToValidate="TxtFyNepali" AutoComplete="Off"
                                    Display="Dynamic" ValidationGroup="fisyear" BorderColor="#FFFF66" SetFocusOnError="True">
                                </asp:RequiredFieldValidator>
                                <asp:TextBox ID="TxtFyNepali" runat="server" CssClass="form-control" Width="100%"></asp:TextBox>                                           
                            </div>
                        </div>
                    </div>                            
                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-group">
                                <label>English Year Start Date:<span class="errormsg">*</span></label>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                                    ErrorMessage="Required!" ControlToValidate="TxtEngStartDate" AutoComplete="Off"
                                    Display="Dynamic" ValidationGroup="fisyear" BorderColor="#FFFF66" SetFocusOnError="True">
                                </asp:RequiredFieldValidator>
                                    <asp:TextBox ID="TxtEngStartDate" runat="server" CssClass="form-control" Width="100%"></asp:TextBox>                                            
                                <cc1:CalendarExtender ID="TxtEngStartDate_CalendarExtender" runat="server" 
                                        Enabled="True" TargetControlID="TxtEngStartDate">
                                </cc1:CalendarExtender>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <label>English Year End Date:<span class="errormsg">*</span></label>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                                    ErrorMessage="Required!" ControlToValidate="TxtEngyearEndDate" AutoComplete="Off"
                                    Display="Dynamic" ValidationGroup="fisyear" BorderColor="#FFFF66" SetFocusOnError="True">
                                </asp:RequiredFieldValidator>
                                    <asp:TextBox ID="TxtEngyearEndDate" runat="server" CssClass="form-control" Width="100%"></asp:TextBox>                                            
                                <cc1:CalendarExtender ID="TxtEngyearEndDate_CalendarExtender" runat="server" 
                                    Enabled="True" TargetControlID="TxtEngyearEndDate">
                                </cc1:CalendarExtender>
                            </div>
                        </div>
                    </div>                            
                    <div class="form-group">
                        <label>Is Current Year:</label>
                        <asp:CheckBox ID="ChkCurrent" runat="server" />
                    </div>
                    <div class="form-group">
                        <asp:Button ID="BtnSave" runat="server" CssClass="btn btn-primary" Text="Save"
                            OnClick="BtnSave_Click" Font-Strikeout="False" ValidationGroup="fisyear" />
                        <asp:Button ID="BtnBack" runat="server" CssClass="btn btn-primary"
                            OnClick="BtnBack_Click" Text="Back" />
                    </div>
                </div>
            </section>
        </div>
    </div>
</asp:Content>
