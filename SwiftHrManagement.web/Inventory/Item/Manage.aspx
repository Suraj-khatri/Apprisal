<%@ Page Language="C#" MasterPageFile="~/ProjectMaster.Master" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="SwiftAssetManagement.Inventory.Item.Manage" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    <link href="../../ui/css/bootstrap.min.css" rel="stylesheet" />
            <section class="panel">
                <header class="panel-heading" style="border-bottom:1px dotted #808080;">
                               Product Group Details
                </header>
            <div class="panel-body">
                <asp:Label ID="LblMsg" runat="server" class="required"></asp:Label>
                <div class="row form-inline">
                <div class=" col-md-4 form-group">
                    <label>Parent Group:</label>
                    <span class="errormsg">*</span>
                        <asp:DropDownList ID="DdlItems" runat="server" CssClass="form-control" Width="100%" >
                        </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="Rfvnewitem" runat="server" ControlToValidate="DdlItems"
                        ErrorMessage="Required" SetFocusOnError="True" ValidationGroup="chart"></asp:RequiredFieldValidator>
                </div>
                <div class="col-md-4 form-group">
                    <label>Group Name:</label>
                    <span class="errormsg">*</span>
                    <asp:TextBox ID="TxtNewItems" runat="server" CssClass="form-control" Width="100%"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="Rfvitem" runat="server" ControlToValidate="TxtNewItems" ErrorMessage="Required"
                        SetFocusOnError="True" ValidationGroup="chart"></asp:RequiredFieldValidator>
                </div>

                <div class="col-md-4 form-group">
                    <label>Description :</label>
                    <span class="errormsg">*</span>
                        <asp:TextBox ID="TxtDecs" runat="server" CssClass="form-control" Width="100%"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RfvDEsc" runat="server" ControlToValidate="TxtDecs"
                        ErrorMessage="Required" SetFocusOnError="True" ValidationGroup="chart"></asp:RequiredFieldValidator>
                </div>
                <div class="col-md-4 form-group">
                    <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary" OnClick="btnSave_Click" Text="Save" ValidationGroup="chart" />
                    &nbsp;
                    <asp:Button ID="BtnDelete" runat="server" CssClass="btn btn-primary" Text="Delete" OnClick="BtnDelete_Click" />
                    &nbsp;<asp:Button ID="BtnCancel" runat="server" CssClass="btn btn-primary" Text="Back" ValidationGroup="chart" OnClick="BtnCancel_Click" />

                    <cc1:ConfirmButtonExtender ID="btnSave_ConfirmButtonExtender" runat="server"
                        ConfirmText="Confirm To Save?" Enabled="True" TargetControlID="btnSave">
                    </cc1:ConfirmButtonExtender>
                    </div>
               </div>
            </div>
            </section>
       

   

</asp:Content>
