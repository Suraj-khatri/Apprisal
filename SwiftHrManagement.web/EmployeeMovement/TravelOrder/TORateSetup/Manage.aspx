<%@ Page Title="" Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="SwiftHrManagement.web.EmployeeMovement.TravelOrder.TORateSetup.Manage" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    <div class="row">
        <div class="col-md-6 col-md-offset-3">
            <section class="panel">
                <header class="panel-heading">
                    <i class="fa fa-caret-right" aria-hidden="true"></i>  
                    Add Travel Order Rate
                </header>
                <div class="panel-body">
                    <div class="form-group">
                        <asp:Label ID="LblEmpName" runat="server" Text=""></asp:Label>
                    </div>
                    <div class="form-group">
                        <span class="txtlbl">Please enter valid data!</span><span class="required"> (* Required fields!) </span>
                        <asp:Label ID="LblMsg" runat="server"></asp:Label>
                    </div>
                    <div class="form-group">
                        <label>Position:<span class="errormsg">*</span></label>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="ddlPost"
                                        Display="Dynamic" ErrorMessage="Required!" ValidationGroup="Data"
                                        SetFocusOnError="True"></asp:RequiredFieldValidator>
                        <asp:DropDownList ID="ddlPost" runat="server" CssClass="form-control"></asp:DropDownList>
                    </div>
                    <div class="form-group">
                        <label>Place:<span class="errormsg">*</span></label>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlPlace"
                                        Display="Dynamic" ErrorMessage="Required!" ValidationGroup="Data"
                                        SetFocusOnError="True"></asp:RequiredFieldValidator>
                        <asp:DropDownList ID="ddlPlace" runat="server" CssClass="form-control"></asp:DropDownList>
                    </div>
                    <div class="form-group">
                        <label>Currency:<span class="errormsg">*</span></label>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlCurrency"
                                        Display="Dynamic" ErrorMessage="Required!" ValidationGroup="Data"
                                        SetFocusOnError="True"></asp:RequiredFieldValidator>
                        <asp:DropDownList ID="ddlCurrency" runat="server" CssClass="form-control"></asp:DropDownList>
                    </div>
                    <div class="form-group">
                        <label>Allowance Type:<span class="errormsg">*</span></label>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlAllowance"
                                        Display="Dynamic" ErrorMessage="Required!" ValidationGroup="Data"
                                        SetFocusOnError="True"></asp:RequiredFieldValidator>
                        <asp:DropDownList ID="ddlAllowance" runat="server" CssClass="form-control"></asp:DropDownList>
                    </div>
                    <div class="form-group">
                        <label>Rate:<span class="errormsg">*</span></label>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtRate"
                                        Display="Dynamic" ErrorMessage="Required!" ValidationGroup="Data"
                                        SetFocusOnError="True"></asp:RequiredFieldValidator>
                        <asp:TextBox ID="txtRate" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <asp:Button ID="BtnSave" runat="server" CssClass="btn btn-primary" 
                            Text="Save" ValidationGroup="Data" onclick="BtnSave_Click" />
                        <cc1:ConfirmButtonExtender ID="BtnSave_ConfirmButtonExtender" runat="server" 
                            ConfirmText="Confirm To Save?" Enabled="True" TargetControlID="BtnSave">
                        </cc1:ConfirmButtonExtender>
                        <asp:Button ID="BtnDelete" runat="server" CssClass="btn btn-primary" 
                            Text="Delete" onclick="BtnDelete_Click" Visible="false" />
                        <cc1:ConfirmButtonExtender ID="BtnDelete_ConfirmButtonExtender" runat="server" 
                            ConfirmText="Confirm To Delete?" Enabled="True" TargetControlID="BtnDelete">
                        </cc1:ConfirmButtonExtender>
                        <asp:Button ID="BtnBack" runat="server" CssClass="btn btn-primary" 
                            Text="Back" onclick="BtnBack_Click" />
                    </div>
                </div>
            </section>
        </div>
    </div>
</asp:Content>
