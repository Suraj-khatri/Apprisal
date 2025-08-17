<%@ Page Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true"
    CodeBehind="depreciationUpdate.aspx.cs" Inherits="SwiftAssetManagement.AssetManagement.Depreciation.depreciationUpdate" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    <div class="row">
        <div class="col-md-10 col-md-offset-1">
            <section class="panel">
            <header class="panel-heading">
                <i class="fa fa-caret-right"></i>
                    Booking Depreciation Accroding to Fiscal Year and Current Run Month 
                    </header>
            <div class="panel-body">
                <label>Booking depreciation for the month</label>
                <div class="form-group">
                    <asp:Label ID="lblMes" runat="server" Style="font-family: Verdana; text-align: right;"></asp:Label>
                </div>
                <div class="row">
                <div class="col-md-3 form-group">
                    <label>Fiscal Year:<span class="required">*</span></label>
                             <asp:DropDownList ID="RunFiscalYear" runat="server" CssClass="form-control" Width="100%">
                             </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rfv1" runat="server"
                        ControlToValidate="RunFiscalYear" Display="Dynamic" ErrorMessage="Required!"
                        SetFocusOnError="True" ValidationGroup="dep"></asp:RequiredFieldValidator>
                </div>
                <div class="col-md-3 form-group">
                     <label>Run Month: <span class="required">*</span> </label>
                            <asp:DropDownList ID="RunMonth" runat="server" CssClass="form-control" Width="100%"></asp:DropDownList>
                   
                    <asp:RequiredFieldValidator ID="rfv2" runat="server"
                        ControlToValidate="RunMonth" Display="Dynamic" ErrorMessage="Required!"
                        SetFocusOnError="True" ValidationGroup="dep"></asp:RequiredFieldValidator>
                </div>
                <div class="col-md-3 form-group">
                     <label>Branch Name: </label>
                             <asp:DropDownList ID="DdlBranchName" runat="server" CssClass="form-control" Width="100%">
                             </asp:DropDownList>
                </div>
                <div class="col-md-3 form-group">
                    <label> Forwarded To:<span class="required">*</span> </label>
                             <asp:DropDownList ID="ddlForwardedTo" runat="server" CssClass="form-control" Width="100%">
                             </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                        ControlToValidate="ddlForwardedTo" Display="Dynamic" ErrorMessage="Required!"
                        SetFocusOnError="True" ValidationGroup="dep"></asp:RequiredFieldValidator>
                </div>
                    </div>
                <div class="row">
                <div class="col-md-6 form-group">
                     <label>Rejection Reason: </label>
                               <asp:TextBox ID="txtRejectionReason" runat="server" CssClass="form-control"
                                    TextMode="MultiLine" Enabled="false" Width="100%">
                               </asp:TextBox>
                </div>
                    </div>
                <br/>
                    <asp:Button ID="btnGenerate" runat="server" Text="Booking Request"
                        OnClick="btnGenerate_Click" CssClass="btn btn-primary" ValidationGroup="dep" />
                   
                        <asp:Button ID="btnDelete" runat="server" Text="Delete"
                            OnClick="btnDelete_Click" CssClass="btn btn-primary" />
                   
                        <input id="Button1" type="button" value="Back" class="btn btn-primary" onclick="javascript: history.back(1); return false;" />
               
            </div>
            </section>
        </div>
    </div>





</asp:Content>
