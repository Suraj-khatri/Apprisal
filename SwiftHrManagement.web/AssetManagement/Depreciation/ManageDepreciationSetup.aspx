<%@ Page Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="ManageDepreciationSetup.aspx.cs" Inherits="SwiftHrManagement.web.AssetManagement.Depreciation.ManageDepreciationSetup" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"> 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    <div class="panel">
        <header class="panel-heading">
            <i class="fa fa-caret-right"></i>
            Branch Add Details
        </header>
        <div class="panel-body">
           Update depreciation value
            <span class="txtlbl">Plese enter valid data! </span><br />
            <asp:Label ID="lblmsg" runat="server" Text=""></asp:Label>
            <br />
            <div class="row">
                <div class="col-md-3">
                    <label>
                Asset Type
                    </label>
                     <asp:Label ID="lblAssetType" runat="server" Text="Label" CssClass="form-control"></asp:Label>
                </div>
                <div class="col-md-3">
                    <label>
                        Asset Number
                    </label>
                      <asp:Label ID="lblAssetNumber" runat="server" Text="Label" CssClass="form-control"></asp:Label>
                </div>
                <div class="col-md-3">
                    <label>
                Fiscal Year
                    </label>
                     <asp:Label ID="lblFiscalYear" runat="server" Text="Label" CssClass="form-control"></asp:Label>
                </div>
                <div class="col-md-3">
                    <label>
                        Base Price
                    </label>
                     <asp:Label ID="lblbasePrice" runat="server" Text="Label" CssClass="form-control"></asp:Label>
                </div>
                </div>
            <div class="row">
                <div class="col-md-3">
                    <label>
                    Depreciation (%)
                    </label>
                    <asp:Label ID="lblDepPer" runat="server" Text="Label" CssClass="form-control"></asp:Label>
                </div>
                <div class="col-md-3">
                    <label>
                        Accumulated Depreciation
                    </label>
                    <asp:Label ID="lblAccDep" runat="server" Text="Label" CssClass="form-control"></asp:Label>
                </div>
            </div>
            <br />
            <div class="row">
                <div class="col-md-3">
                    <label>
Baishak:
                    </label>
                    <asp:TextBox ID="txtBaishak" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-md-3">
                    <label>
Jeshta:
                    </label>
                    <asp:TextBox ID="txtJeshta" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-md-3">
                    <label>
                        Ashad:
                    </label>
                    <asp:TextBox ID="txtAshad" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-md-3">
                    <label>
Shawan:
                    </label>
                    <asp:TextBox ID="txtShawan" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
             <div class="row">
                <div class="col-md-3">
                    <label>
Bhadra:
                    </label>
                    <asp:TextBox ID="txtBhadra" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-md-3">
                    <label>
                        Ashoj:
                    </label>
                    <asp:TextBox ID="txtAshoj" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-md-3">
                    <label>
Kartik:
                    </label>
                    <asp:TextBox ID="txtKartik" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-md-3">
                    <label>
Mangshir:
                    </label>
                    <asp:TextBox ID="txtMangshir" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
             <div class="row">
                <div class="col-md-3">
                    <label>
Poush:
                    </label>
                    <asp:TextBox ID="txtPoush" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-md-3">
                    <label>
Magh:
                    </label>
                    <asp:TextBox ID="txtMagh" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-md-3">
                    <label>
Falgun:
                    </label>
                    <asp:TextBox ID="txtFalgun" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-md-3">
                    <label>
Chaitra:
                    </label>
                    <asp:TextBox ID="txtChaitra" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <br />
            <asp:Button ID="BtnUpdate" runat="server" Text="Update" CssClass="btn btn-primary" 
                onclick="BtnUpdate_Click" />
            <cc1:ConfirmButtonExtender ID="BtnUpdate_ConfirmButtonExtender" runat="server" 
                ConfirmText="Are you sure to Update?" Enabled="True" 
                TargetControlID="BtnUpdate">
            </cc1:ConfirmButtonExtender>
        </div>
    </div>
</asp:Content>