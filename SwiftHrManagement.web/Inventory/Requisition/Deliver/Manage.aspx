<%@ Page Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="SwiftAssetManagement.Inventory.Requisition.Deliver.Manage" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    <div class="row">
        <div class="col-md-10 col-md-offset-1">
            <section class="panel">
                <header class="panel-heading">
                    <i class="fa fa-caret-right"></i>
                    Modify Approved Requisition
                </header>
                <div class="panel-body">
                    <strong>Modify Requition Product</strong>
                    <div class="form-group">
                        <span class="txtlbl">Please enter valid data!</span><span class="required"> (* Required fields!) </span>
                        <asp:Label ID="LblMsg" runat="server"></asp:Label>
                        <asp:HiddenField ID ="hdnfldAppid" runat="server" />
                    </div>
                    <div class="form-group">
                        <label>Product Name :</label>
                        <asp:Label ID="Product" runat="server"></asp:Label>
                    </div>
                    <div class="row">
                          <div class="col-md-4 form-group">
                        <label>Total Remain QTY :</label>
                        <asp:TextBox ID="txtDQty" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                    
                        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="TxtDeliveredQuantity" 
                            Display="Dynamic"  ErrorMessage="Dispatched Quantity Cannot Be Greater Than Max Dispatched Qty!" 
                            Operator="LessThanEqual" Type="Integer" ValidationGroup="req" SetFocusOnError="True" 
                            ControlToCompare="txtDQty">
                        </asp:CompareValidator>
                        <asp:RequiredFieldValidator ID="rv" runat="server" 
                            ControlToValidate="TxtDeliveredQuantity" Display="None" ErrorMessage="*" 
                            SetFocusOnError="True" ValidationGroup="req">
                        </asp:RequiredFieldValidator>
                    </div>
                    <div class="col-md-4 form-group">
                        <label>Approved QTY :</label>
                            <asp:TextBox ID="TxtAppQuantity" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
                            <cc1:FilteredTextBoxExtender ID="TxtAppQuantity_FilteredTextBoxExtender" runat="server" Enabled="True" 
                                FilterType="Numbers" TargetControlID="TxtAppQuantity">
                            </cc1:FilteredTextBoxExtender>
                    </div>
                    <div class="col-md-4  form-group">
                        <label>Dispatch QTY :<span class="required">*</span></label>
                        <asp:TextBox ID="TxtDeliveredQuantity" runat="server" CssClass="form-control"></asp:TextBox>
                        <cc1:FilteredTextBoxExtender ID="TxtDeliveredQuantity_FilteredTextBoxExtender" runat="server" 
                            Enabled="True" FilterType="Numbers" TargetControlID="TxtDeliveredQuantity">
                        </cc1:FilteredTextBoxExtender>
                    </div>
                    </div>
                  
                    <div class="form-group">
                        <asp:Button ID="BtnSave" runat="server" CssClass="btn btn-primary" Text="Save" ValidationGroup="req" 
                            onclick="BtnSave_Click" />
                        <cc1:ConfirmButtonExtender ID="BtnSave_ConfirmButtonExtender" runat="server" 
                            ConfirmText="Confirm To Save?" Enabled="True" TargetControlID="BtnSave">
                        </cc1:ConfirmButtonExtender>&nbsp; 
                        <asp:Button ID="BtnCancel" runat="server" CssClass="btn btn-primary" Text="Back" 
                            ValidationGroup="chart"/>
                    </div>
                </div>
            </section>
        </div>
    </div>
</asp:Content>
