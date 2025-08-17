<%@ Page Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="SwiftHrManagement.web.AllocationSetup.Manage" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    <div class="row">
        <div class="col-md-6 col-md-offset-3">
            <section class="panel">
                <header class="panel-heading">
                    <i class="fa fa-caret-right" aria-hidden="true"></i> Branch Wise Allocation Setup
                </header>
                <div class="panel-body">
                    <div class="form-group">  
                            <span class="txtlbl" >Please enter valid data!</span><span class="required" > (* Required fields!)</span>    
                            <asp:Label ID="lblmsg" runat="server"></asp:Label>
                    </div>
                    <div class="form-group">
                        <label>Branch:<span class="required">*</span></label>
                        <asp:DropDownList ID="DdlBranchName" runat="server" CssClass="form-control" AutoPostBack="true"
                             onselectedindexchanged="DdlBranchName_SelectedIndexChanged"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                            ControlToValidate="DdlBranchName" Display="Dynamic" ErrorMessage="Required!" 
                            SetFocusOnError="True" ValidationGroup="all"></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group">
                        <label>Department:<span class="required">*</span></label>
                        <asp:DropDownList ID="DdlDeptName" runat="server" CssClass="form-control"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                            ControlToValidate="DdlDeptName" Display="Dynamic" ErrorMessage="Required!" 
                            SetFocusOnError="True" ValidationGroup="all"></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group">
                        <label>Position:<span class="required">*</span></label>
                        <asp:DropDownList ID="DdlPosition" runat="server" CssClass="form-control"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                            ControlToValidate="DdlPosition" Display="Dynamic" ErrorMessage="Required!" 
                            SetFocusOnError="True" ValidationGroup="all"></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group">
                        <label>Allocation Capacity:<span class="required">*</span></label>
                        <asp:TextBox ID="txtAllocation" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtAllocation" Display="Dynamic" ErrorMessage="Required!" 
                        SetFocusOnError="True" ValidationGroup="all"></asp:RequiredFieldValidator>
                    </div>
                    
                    <div class="form-group">
                        <asp:Button ID="BtnSave" runat="server" Text="Save" CssClass="btn btn-primary" ValidationGroup="all"
                            onclick="BtnSave_Click" />
                        <cc1:ConfirmButtonExtender ID="BtnSave_ConfirmButtonExtender" runat="server" 
                            ConfirmText="Confirm To Save?" Enabled="True" TargetControlID="BtnSave">
                        </cc1:ConfirmButtonExtender>
                        <asp:Button ID="BtnDelete" runat="server" CssClass="btn btn-primary" 
                            onclick="BtnDelete_Click" Text="Delete"  /> 
                        <cc1:ConfirmButtonExtender ID="BtnDelete_ConfirmButtonExtender" runat="server" 
                            ConfirmText="Confirm To Delete?" Enabled="True" TargetControlID="BtnDelete">
                        </cc1:ConfirmButtonExtender>
                        <asp:Button ID="BtnBack" runat="server" CssClass="btn btn-primary" onclick="BtnBack_Click" Text="Back"  />   
                    </div>
                </div>
            </section>
        </div>
    </div>
</asp:Content>
