<%@ Page Language="C#" MasterPageFile="~/Apprisal.Master" AutoEventWireup="true"
    CodeBehind="ChangePassword.aspx.cs" Inherits="SwiftHrManagement.web.SysUser.ChangePassword" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    <div class="row">
        <div class="col-md-6 col-md-offset-3">
            <section class="panel">
                <header class="panel-heading">
                    <i class="fa fa-caret-right" aria-hidden="true"></i> 
                    Change Password
                </header>
                <div class="panel-body">
                    <div >
                        <span class="txtlbl">Please enter valid data!</span><span class="errormsg"> (* Required Fields)</span>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="LblMsg" runat="server"></asp:Label>
                        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="TxtNewPass" 
                            ControlToValidate="TxtConfirmPass" ErrorMessage="Password you entered don't match!!" Display="Dynamic"
                            ValidationGroup="pass"></asp:CompareValidator>
                    </div>
                    <div class="form-group">
                        <label>Old Password :<span class="errormsg">*</span></label>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Required!" 
                            ControlToValidate="TxtOldPass" ValidationGroup="pass" SetFocusOnError="True">
                        </asp:RequiredFieldValidator>
                        <asp:TextBox ID="TxtOldPass" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label>New Password :<span class="errormsg">*</span></label>
                        <asp:RequiredFieldValidator
                            ID="RequiredFieldValidator2" runat="server" ControlToValidate="TxtNewPass" 
                            ErrorMessage="Required!" ValidationGroup="pass" SetFocusOnError="True">
                        </asp:RequiredFieldValidator>
                        <asp:TextBox ID="TxtNewPass" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label>Confirm Password : <span class="errormsg">*</span></label>
                         <asp:RequiredFieldValidator
                            ID="RequiredFieldValidator3" runat="server" ControlToValidate="TxtConfirmPass"
                            ErrorMessage="Required!" ValidationGroup="pass" SetFocusOnError="True">
                        </asp:RequiredFieldValidator>
                        <asp:TextBox ID="TxtConfirmPass" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
                    </div>

                        <asp:Button ID="Btn_Save" runat="server" CssClass="btn btn-primary" Text="Update"
                            OnClick="Btn_Save_Click" ValidationGroup="pass" />
                        <cc1:ConfirmButtonExtender ID="Btn_Save_ConfirmButtonExtender" runat="server"
                            ConfirmText="Confirm To Update Your Password?" Enabled="True"
                            TargetControlID="Btn_Save">
                        </cc1:ConfirmButtonExtender>
                </div>
            </section>
        </div>
    </div>



</asp:Content>
