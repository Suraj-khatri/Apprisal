<%@ Page Language="C#" MasterPageFile="~/ProjectMaster.Master"  AutoEventWireup="true" CodeBehind="VendorAssignProduct.aspx.cs" Inherits="SwiftHrManagement.web.Inventory.ItemVersion2.Vendor_Assign_Product.VendorAssignProduct" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
<asp:UpdatePanel ID="updatepanel1" runat="server">
    <ContentTemplate> 
        <div class="row">
            <div class="col-md-12">
                <section class="panel">
                    <header class="panel-heading">
                         &nbsp;Vendor Assign In Product
                    </header>
                    <div class="panel-body">
                        <div class="form-group">
                            <asp:Label ID="LblMsg" runat="server"></asp:Label>
                            <asp:HiddenField ID="HdnProduct" runat="server" />
                        </div>
                        <div class="form-group">
                            <label>Product Name :</label>
                            <strong><asp:Label ID="lblproductName" runat="server" Text="" align="left"></asp:Label></strong>
                        </div>
                        <div class="row">
                            <div class="col-md-4 form-group">
                            <label>Vendor Name :</label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Required!" 
                                ControlToValidate="DdlVendorName" Display="Dynamic" SetFocusOnError="True" 
                                ValidationGroup="add">
                            </asp:RequiredFieldValidator>
                            <asp:DropDownList ID="DdlVendorName" runat="server" CssClass="form-control">
                            </asp:DropDownList>
                        </div>                            
                        <div class="col-md-4 form-group">
                            <label>Amount :<span class="required">*</span></label>
                            <asp:RequiredFieldValidator ID="RfvQuantity" runat="server" ControlToValidate="txtAmt" 
                                ErrorMessage="Required"  ValidationGroup="add"></asp:RequiredFieldValidator>                       
                            <asp:TextBox ID="txtAmt" runat="server" CssClass="form-control"></asp:TextBox> 
                        </div>
                        </div>
                        
                        <div class="form-group">
                            <label>Is Active</label>
                            <asp:CheckBox ID="ChkIsActive" runat="server" />
                        </div>
                        <div class="form-group">
                            <asp:Button ID="BtnAdd" runat="server" CssClass="btn btn-primary" Text="Add" ValidationGroup="add" 
                                onclick="BtnAdd_Click"/>
                        </div>
                        <div class="form-group">
                            <div id="rpt" runat="server">
                                <asp:Table ID="Table1" runat="server" Width="100%"></asp:Table>
                            </div>
                        </div>
                    
                            <asp:Panel ID="PnDelete" runat="server">
                                <asp:Button ID="BtnDelete" runat="server" CssClass="btn btn-primary" onclick="BtnDelete_Click" 
                                    Text="Delete" />    
                                <cc1:ConfirmButtonExtender ID="BtnDelete_ConfirmButtonExtender" runat="server" 
                                    ConfirmText="Confirm To Delete ?" Enabled="True" TargetControlID="BtnDelete">
                                </cc1:ConfirmButtonExtender>
                            </asp:Panel>
                       
                    </div>
                </section>
            </div>
        </div>
</ContentTemplate>
</asp:UpdatePanel>
</asp:Content>
