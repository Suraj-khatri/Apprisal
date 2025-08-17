<%@ Page Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="SwiftAssetManagement.Inventory.Requisition.Approve.Manage" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    <div class="row">
        <div class="col-md-10 col-md-offset-1">
            <section class="panel">
                <header class="panel-heading">
                   Requisition Approve :
                    <asp:Label ID="LblBranchDept" runat="server"></asp:Label>
                </header>
                <div class="panel-body">
                    <h4>Requisition Detail</h4>
                <div class="form-group">
                    <span class="txtlbl">Please enter valid data!</span>
                    <span class="required"> (* Required fields!) </span>
                    <asp:Label ID="LblMsg" runat="server"></asp:Label>
                </div>
                <div class="form-group">
                    <level>Product Name :</level>
                    <asp:Label ID="Product" runat="server" ></asp:Label>
                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="TxtReqQuantity" 
                        ControlToValidate="TxtAppQuantity" Display="Dynamic" 
                        ErrorMessage="Approved Quantity Cannot Be Greater Than Requested Quantity" Operator="LessThanEqual" 
                        Type="Integer" ValidationGroup="req"></asp:CompareValidator>
                    <asp:RequiredFieldValidator ID="rv" runat="server" ControlToValidate="TxtAppQuantity" Display="None" 
                        ErrorMessage="*" SetFocusOnError="True" ValidationGroup="req"></asp:RequiredFieldValidator>
                </div>
                <div class="row">
                    <div class="col-md-6">
                        <div class="form-group">
                            <label>Requested Quantity :</label>
                             <asp:TextBox ID="TxtReqQuantity" runat="server" CssClass="form-control" width="100%" Enabled="False"></asp:TextBox>
                            <cc1:FilteredTextBoxExtender ID="TxtReqQuantity_FilteredTextBoxExtender" runat="server" Enabled="True" 
                                FilterType="Numbers" TargetControlID="TxtReqQuantity">
                            </cc1:FilteredTextBoxExtender>
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="form-group">
                            <label> Approved Quantity :<span class="required">*</span></label>
                             <asp:TextBox ID="TxtAppQuantity" runat="server" CssClass="form-control"  width="100%"></asp:TextBox>
                            <cc1:FilteredTextBoxExtender ID="TxtAppQuantity_FilteredTextBoxExtender" runat="server" Enabled="True" 
                                FilterType="Numbers" TargetControlID="TxtAppQuantity">
                            </cc1:FilteredTextBoxExtender>
                        </div>
                    </div>
            </div>
                    <div class="form-group">
                    `<asp:Button ID="BtnSave" runat="server" CssClass="btn btn-primary" Text="Save" ValidationGroup="req" 
                        onclick="BtnSave_Click" />
                    <cc1:ConfirmButtonExtender ID="BtnSave_ConfirmButtonExtender" runat="server" ConfirmText="Confirm To Save?" 
                        Enabled="True" TargetControlID="BtnSave">
                    </cc1:ConfirmButtonExtender>
                    <asp:Button ID="BtnCancel" runat="server" CssClass="btn btn-primary" Text="Back" ValidationGroup="chart" 
                        onclick="BtnCancel_Click"/>
                </div>
                    </div>
        </section>
        </div>
    </div>
</asp:Content>
