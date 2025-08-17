<%@ Page Title="" Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="SwiftHrManagement.web.Company.DepartmentWeb.Manage" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    <div class="row">
        <div class="col-md-6 col-md-offset-3">
            <section class="panel">
                <header class="panel-heading">
                    <i class="fa fa-caret-right"></i>
                    Department Entry Details
                </header>
                <div class="panel-body">
                    <div>  
                        <span class="txtlbl" >Please enter valid data!</span><span class="required" > (* Required fields!) </span><br />     
                        <asp:Label ID="lblmsg" runat="server"></asp:Label>
                    </div>
                    <div class="form-group">
                        <label>Branch Name:<span class="errormsg">*</span></label>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" 
                            ControlToValidate="ddlbranchname" Display="None" ValidationGroup="Dept" InitialValue="0" 
                            SetFocusOnError="True"></asp:RequiredFieldValidator><br />
                        <asp:DropDownList ID="ddlbranchname" runat="server" CssClass="form-control">
                        </asp:DropDownList>
                    </div>
                    <div class="form-group">
                        <label>Department Name:<span class="errormsg">*</span></label>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" 
                            ControlToValidate="DdlDeptName" Display="None" ValidationGroup="Dept" InitialValue="0" 
                            SetFocusOnError="True"></asp:RequiredFieldValidator>
                        <asp:DropDownList ID="DdlDeptName" runat="server" CssClass="form-control">
                        </asp:DropDownList>
                    </div>
                    <div class="form-group">
                        <label>Department Short Name:</label>
                        <asp:TextBox ID="txtDeptShortname" runat="server" CssClass="form-control"></asp:TextBox>       
                    </div>
                    <br/>
                    <div class="form-group">
                        <asp:Button ID="BtnSave" runat="server" CssClass="btn btn-primary" 
                            onclick="BtnSave_Click" Text="Save" ValidationGroup="Dept" />
                        <cc1:ConfirmButtonExtender ID="BtnSave_ConfirmButtonExtender" runat="server" 
                            ConfirmText="Confirm To Save?" Enabled="True" TargetControlID="BtnSave">
                        </cc1:ConfirmButtonExtender>
                        <asp:Button ID="BtnBack" runat="server" CssClass="btn btn-primary" 
                            Text="Back" onclick="BtnBack_Click" />
                    </div>
                </div>
            </section>
        </div>
    </div>
</asp:Content>
