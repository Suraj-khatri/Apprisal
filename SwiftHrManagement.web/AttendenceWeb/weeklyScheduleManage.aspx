<%@ Page Title="" Language="C#" MasterPageFile="~/ProjectMaster.Master" AutoEventWireup="true" CodeBehind="weeklyScheduleManage.aspx.cs" Inherits="SwiftHrManagement.web.AttendenceWeb.weeklyScheduleManage" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    <div class="row">
        <div class="col-md-8 col-md-offset-2">
            <section class="panel">
                <header class="panel-heading">
                    <i class="fa fa-caret-right"></i>
                     Manage Weekly Schedule
                </header>
                <div class="panel-body">
                    <div class="form-group">
                        <asp:Label ID="lblMsg" runat="server"></asp:Label>
                        <label>Weekly Schedule Name:<span class="errormsg">*</span></label>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                            ControlToValidate="ddlSchName" ErrorMessage="Required!" SetFocusOnError="True" ValidationGroup="sch"> 
                        </asp:RequiredFieldValidator> 
                        <asp:DropDownList ID="ddlSchName" runat="server" CssClass="form-control"></asp:DropDownList>                          
                    </div>
                    <div class="form-group">
                        <label>Description:<span class="errormsg">*</span></label>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtDesc" 
                            ErrorMessage="Required!" SetFocusOnError="True" ValidationGroup="sch"> 
                        </asp:RequiredFieldValidator>
                        <asp:TextBox ID="txtDesc" runat="server" CssClass="form-control" TextMode="MultiLine" ></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label>Status:</label>
                        <asp:DropDownList ID="ddlIsActive" runat="server" CssClass="form-control">
                            <asp:ListItem Value="Active">Active</asp:ListItem>
                            <asp:ListItem Value="Inactive">Inactive</asp:ListItem>
                        </asp:DropDownList> 
                    </div>
                    <div class="form-group">
                        <asp:Button ID="btnSave" ValidationGroup="sch"  runat="server" CssClass="btn btn-primary" Text=" Save " 
                             onclick="btnSave_Click"  />
                        <cc1:ConfirmButtonExtender ID="Btn_Save_ConfirmButtonExtender" runat="server" 
                            ConfirmText="Confirm to Save?" Enabled="True" TargetControlID="btnSave">
                        </cc1:ConfirmButtonExtender>
                        <asp:Button ID="btnDelete" runat="server" CssClass="btn btn-primary" Text=" Delete " onclick="btnDelete_Click" />
                        <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" 
                            ConfirmText="Confirm to Delete?" Enabled="True" TargetControlID="btnDelete">
                        </cc1:ConfirmButtonExtender>
                        <asp:Button ID="btnBack" runat="server" CssClass="btn btn-primary" Text="Back" />
                    </div>
                </div>
            </section>
        </div>
    </div>
</asp:Content>