<%@ Page Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="RoleAssign.aspx.cs" Inherits="SwiftHrManagement.web.SysuserInv.RoleAssign" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">

    <%--<asp:ScriptManager ID="sm" runat="server"></asp:ScriptManager>--%>
    <div class="row">
        <div class="col-md-6 col-md-offset-3">
            <section class="panel">
                        <header class="panel-heading">
                            <i class="fa fa-caret-right" aria-hidden="true"></i>
                           Assign Role
                        </header>
                        <div class="panel-body">
                            <div class="form-group">  
                                <span class="txtlbl" >Please enter valid data!</span><span class="required" > (* Required fields!) </span><br /> 
                                <div align="left">
                                    <asp:Label ID="LblMsg" runat="server"></asp:Label>
                                </div>
                            </div>
                            <div class="form-group">  
                                <label>Current Role:</label>
                                <asp:Label ID="LblRole" runat="server" Font-Bold="True"></asp:Label>
                            </div>
                            <div class="row">
                            <div class="col-md-12 form-group">
                                <label>Role:<span class="errormsg">*</span></label>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                    ControlToValidate="DdlRoleList" Display="None"
                                    ErrorMessage="RequiredFieldValidator" SetFocusOnError="True"
                                    ValidationGroup="role"></asp:RequiredFieldValidator>
                                <asp:DropDownList ID="DdlRoleList" runat="server" CssClass="form-control">
                                </asp:DropDownList>
                                
                            </div>
                            </div>
                                <asp:Button ID="Btn_Save" runat="server" CssClass="btn btn-primary" Text="Save"
                                    OnClick="Btn_Save_Click" ValidationGroup="role" Width="75px" />
                                <cc1:ConfirmButtonExtender ID="Btn_Save_ConfirmButtonExtender" runat="server"
                                    ConfirmText="Confirm To Save?" Enabled="True" TargetControlID="Btn_Save">
                                </cc1:ConfirmButtonExtender>
                            </div>
             </section>
        </div>
    </div>
</asp:Content>
