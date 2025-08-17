<%@ Page Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="ListDispatched.aspx.cs" Inherits="SwiftAssetManagement.Report.Inventory.RequisitionHisory.ListDispatched" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    <div class="panel">
        <header class="panel-heading">
            <i class="fa fa-caret-right"></i>
            Dispatch History
            <asp:HiddenField ID="hdnapid" runat="server" />
        </header>
        <div class="panel-body">
            <div class="row">
                <div class="col-md-12 col-sm-12">
                    <section class="panel">
                        <div class="panel-body">
                            <div id="rpt" runat="server"></div>
                            <asp:Button ID="btnHidden" runat="server" OnClick="btnHidden_Click" Style="display: none" />
                            <label>Dispatched Message :</label>
                            <asp:Panel ID="PnApprove" runat="server" BorderStyle="None" CssClass="txtlbl">
                                <asp:TextBox ID="TxtAppMessage" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                            </asp:Panel>
                        </div>
                    </section>
                </div>
            </div>
        </div>
    </div>
</asp:Content>