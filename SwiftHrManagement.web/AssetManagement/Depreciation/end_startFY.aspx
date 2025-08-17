<%@ Page Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true"
    CodeBehind="end_startFY.aspx.cs" Inherits="SwiftHrManagement.web.AssetManagement.Depreciation.end_startFY" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    <div class="row">
        <div class="col-md-10 col-md-offset-1">
            <section class="panel">
            <header class="panel-heading">
                <i class="fa fa-caret-right"></i>
                   Start New Fiscal Year for depreciation cost
                    </header>
            <div class="panel-body">
                <label>End and Start Fiscal Year</label>
                <div class="form-group">
                    <asp:Label ID="lblMes" runat="server" Style="font-family: Verdana; text-align: right;"></asp:Label>
                </div>
                <div class="row form-inline">
                <div class="col-md-6 form-group">
                   <label> End Fiscal Year :</label>
                            <asp:RequiredFieldValidator ID="rfv1" runat="server"
                                ControlToValidate="endFY" Display="None" ErrorMessage="*"
                                SetFocusOnError="True" ValidationGroup="dep"></asp:RequiredFieldValidator>
                    <asp:DropDownList ID="endFY" runat="server" CssClass="form-control" Width="100%">
                    </asp:DropDownList>
                </div>
                    <div class="col-md-6 form-group">
                    <label>&nbsp;</label><br />
                    <asp:Button ID="btnGenerate" runat="server" Text="End Fiscal Year"
                        OnClick="btnGenerate_Click" CssClass="btn btn-primary" ValidationGroup="dep" />
                        </div>
             </div>
            </div>
              </section>
        </div>
    </div>
</asp:Content>
