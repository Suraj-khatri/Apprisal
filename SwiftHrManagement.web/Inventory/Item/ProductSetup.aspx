<%@ Page Language="C#" MasterPageFile="~/ProjectMaster.Master" AutoEventWireup="true" CodeBehind="ProductSetup.aspx.cs" Inherits="SwiftAssetManagement.Inventory.Item.ProductSetup" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
 <asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
      <link href="../../ui/css/bootstrap.min.css" rel="stylesheet" />
     <link href="../../ui/css/style.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    <div class="row">
        <div class="col-md-12">
            <section class="panel">
                <header class="panel-heading">
                    <i class="fa fa-caret-right" aria-hidden="true"></i>  
                    Product Entry Setup
                </header>
                <div class="panel-body">
                    <div class="row">
                        <div class="col-md-12 form-group">
                            <label>Please enter valid data!<span class="required">(* Required fields)</span></label>
                            <asp:Label ID="LblMsg" runat="server" class="required"></asp:Label>
                            <asp:HiddenField ID = "hdnitem" runat="server" /><asp:HiddenField ID="ParentID" runat="server" />
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-4 form-group">
                            <label>Product Group:</label>
                            <asp:Label ID="LblProduct" runat="server" CssClass="form-control" Width="100%"></asp:Label>
                        </div>
                        <div class="col-md-4 form-group" id="rptCode" runat="server" visible="false">
                            <label>Product Code:</label>
                            <asp:Label ID="lblProdCode" runat="server" CssClass="form-control" Width="100%"></asp:Label>
                        </div>
                        <div class="col-md-4 form-group">
                            <label>
                                Product Name:<span class="errormsg">*</span>
                            </label>
                            <asp:RequiredFieldValidator ID="Rfvnewitem" runat="server" ControlToValidate="TxtProductCode" Display="Dynamic" 
                                ErrorMessage="Required!" SetFocusOnError="True" ValidationGroup="product"></asp:RequiredFieldValidator>
                            <asp:TextBox ID="TxtProductCode" runat="server" CssClass="form-control" Width="100%"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-4 form-group">
                            <label>Description:<span class="errormsg">*</span></label>
                             <asp:RequiredFieldValidator ID="Rfvitem" runat="server" 
                                    ControlToValidate="TxtProductDesc" Display="Dynamic" ErrorMessage="Required!" 
                                    SetFocusOnError="True" ValidationGroup="product"></asp:RequiredFieldValidator>
                            <asp:TextBox ID="TxtProductDesc" runat="server" CssClass="form-control" Width="100%"></asp:TextBox>
                            </div>
                               <div class="col-md-4 form-group">
                            <label>Is Taxable</label>
                                <asp:DropDownList ID="DdlTangible" runat="server" CssClass="form-control" Width="100%">
                                <asp:ListItem Value="True">Yes</asp:ListItem>
                                <asp:ListItem Value="False">No</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="col-md-4 form-group">
                            <label>
                                Is Serialed 
                            </label>
                            <asp:DropDownList ID="DdlIsSerialed" runat="server" CssClass="form-control" Width="100%">
                                <asp:ListItem Value="True">Yes</asp:ListItem>
                                <asp:ListItem Value="False">No</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-4 form-group">
                            <label>
                        Batch Condition :
                    </label>
                    <asp:DropDownList ID="DdlBatchCondtn" runat="server" CssClass="form-control" Width="100%">
                       <asp:ListItem Value="True">Yes</asp:ListItem>
                         <asp:ListItem Value="False">No</asp:ListItem>
                     </asp:DropDownList>
                        </div>
                        <div class="col-md-4 form-group">
                            <label>
                                Is Active :
                            </label>
                            <asp:DropDownList ID="DdlIsActive" runat="server" CssClass="form-control" Width="100%">
                                <asp:ListItem Value="True">Yes</asp:ListItem>
                                <asp:ListItem Value="False">No</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="col-md-4 form-group">
                            <label>Sales Tolerance (+) :</label>
                        <asp:TextBox ID="TxtSalesTolPlus" runat="server" CssClass="form-control"  Width="100%"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-4 form-group">
                            <label>Purchase Tolerance (+) :</label>
                            <asp:TextBox ID="TxtPurTolPlus" runat="server" CssClass="form-control"  Width="100%"></asp:TextBox>
                        </div>
                    
                    <div class="col-md-4 form-group">
                            <label> 
                            Sales Tolerance (-) :
                        </label>
                        <asp:TextBox ID="TxtSalesTolmin" runat="server" CssClass="form-control"  Width="100%"></asp:TextBox>
                        </div>
                        <div class="col-md-4 form-group">
                            <label>
                             Purchase Tolerance(-) :
                        </label>
                            <asp:TextBox ID="TxtPurTolmin" runat="server" CssClass="form-control" Width="100%"></asp:TextBox>
                        </div>
                        </div>
                    <div class="row">
                        <div class="col-md-4 form-group">
                            <label>
                            Sales Base Price :
                        </label>
                        <asp:TextBox ID="TxtSalesBasePrice" runat="server" CssClass="form-control" Width="100%"></asp:TextBox>
                        </div>
                        <div class="col-md-4 form-group">
                            <label>
                                 Purchase Base Price :
                            </label>
                            <asp:TextBox ID="TxtPurchaseBasePrice" runat="server" CssClass="form-control" Width="100%"></asp:TextBox>
                        </div>
                        <div class="col-md-4 form-group">
                            <label>
                             Package Unit :<span class="errormsg">*</span>
                        </label><asp:TextBox ID="TxtPackageUnit" runat="server" CssClass="form-control" Width="100%"></asp:TextBox>
                            
                            <asp:RequiredFieldValidator ID="Rfvunit" runat="server" Display="None" 
                                ErrorMessage="*" SetFocusOnError="True" ValidationGroup="product" 
                                ControlToValidate="TxtPackageUnit"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-4 form-group">
                            <label>Single Unit :</label>
                    <asp:TextBox ID="TxtSingleUnit" runat="server" CssClass="form-control" Width="100%"></asp:TextBox>
                        </div>
                        <div class="col-md-4 form-group">
                            <label>
                            Conversion Rate : 
                            </label>
                            <asp:TextBox ID="TxtConversionRate" runat="server" CssClass="form-control" Width="100%"></asp:TextBox>
                        </div>
                        <div class="col-md-4 form-group">
                             <label>
                             Unit Discount :
                        </label>
                        <asp:TextBox ID="TxtUnitDiscount" runat="server" CssClass="form-control" 
                               Width="100%"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-4 form-group">
                            <label>
                             Bulk Discount :
                        </label>
                        <asp:TextBox ID="TxtBulkDiscount" runat="server" CssClass="form-control" Width="100%"></asp:TextBox>
                        </div>
                        <div class="col-md-4 form-group">
                            <label>
                            Make:
                        </label>
                        <asp:TextBox ID="TxtMake" runat="server" CssClass="form-control" Width="100%"></asp:TextBox>
                        </div>
                    <div class="col-md-4 form-group">
                            <label>
                               Model 
                            </label><asp:TextBox ID="TxtModel" runat="server" CssClass="form-control" Width="100%"></asp:TextBox>
                        </div>
                        </div>

                    <div class="row">
                        <div class="col-md-4 form-group">
                            <label>
                            Extra Field 1:
                            </label>
                            <asp:TextBox ID="TxtExtFld1" runat="server" CssClass="form-control" Width="100%"></asp:TextBox>
                        </div>
                    
                        <div class="col-md-4 form-group">
                            <label>
                            Extra Field 2:
                        </label>
                        <asp:TextBox ID="TxtExtFld2" runat="server" CssClass="form-control" Width="100%"></asp:TextBox>
                        </div>
                    </div>
                    
                            <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary" 
                            onclick="btnSave_Click" Text="Save" ValidationGroup="product"/>
                            <cc1:ConfirmButtonExtender ID="btnSave_ConfirmButtonExtender" runat="server" 
                                ConfirmText="Confirm To Save?" Enabled="True" TargetControlID="btnSave">
                            </cc1:ConfirmButtonExtender>
                        &nbsp;<asp:Button ID="BtnDelete" runat="server" CssClass="btn btn-primary" 
                            onclick="BtnDelete_Click" Text="Delete" ValidationGroup="chart"/>
                        <cc1:ConfirmButtonExtender ID="BtnDelete_ConfirmButtonExtender" runat="server" 
                            ConfirmText="Confirm To Delete?" Enabled="True" TargetControlID="BtnDelete">
                        </cc1:ConfirmButtonExtender>
                        </div>
            </section>
        </div>
    </div>
 </asp:Content>