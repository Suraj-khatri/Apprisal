<%@ Page Title="" Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true"
    CodeBehind="ManageItemMasterRpt.aspx.cs" Inherits="SwiftHrManagement.web.Report.InventoryReport.ManageItemMasterRpt" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript" src="../../js/functions.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    <style type="text/css">
        .form-inline .form-control {
            margin-bottom: 3px !important;
        }
    </style>
      <div class="col-md-10 col-md-offset-1">
    <div class="panel">
        <header class="panel-heading">
            <i class="fa fa-caret-right"></i>
                Inventory Master Report
            </header>
    </div>

    <div class="panel panel-default">
        <header class="panel-heading">
                Inventory Master Report
            </header>
        <div class="panel-body">
           <div class="row">
                <div class="col-md-4 form-group">
                        <asp:HiddenField ID="hdnProductId" runat="server" />
                        <label>Branch Name: <span class="required">*</span></label>
                        <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control" Width="100%">
                        </asp:DropDownList>
                    </div>
                    <div class="col-md-4 form-group">
                        <label>&nbsp;</label>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="branchName"
                            Display="Dynamic" ErrorMessage="Required!" SetFocusOnError="True" ValidationGroup="re"></asp:RequiredFieldValidator>
                        <asp:DropDownList ID="branchName" runat="server" CssClass="form-control" width="100%">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="branchName"
                            Display="Dynamic" ErrorMessage="Required!" SetFocusOnError="True" ValidationGroup="re"></asp:RequiredFieldValidator>
                    </div>
               
                <div class="col-md-4 form-group">
                        <label>Product Name:</label>
                        <asp:TextBox ID="txtProduct" runat="server" CssClass="form-control" Width="100%"
                            AutoComplete="off"></asp:TextBox>
                        <cc1:AutoCompleteExtender ID="ACproduct" runat="server" DelimiterCharacters="" Enabled="true"
                            ServicePath="~/Autocomplete.asmx" ServiceMethod="GetProductList" TargetControlID="txtProduct"
                            MinimumPrefixLength="1" CompletionInterval="10" EnableCaching="true" CompletionListCssClass="autocompleteTextBoxLP"
                            OnClientItemSelected="AutocompleteOnSelected">
                        </cc1:AutoCompleteExtender>
                        <cc1:TextBoxWatermarkExtender ID="txtProduct_TextBoxWatermarkExtender0" runat="server"
                            Enabled="True" TargetControlID="txtProduct" WatermarkCssClass="form-control" WatermarkText="Auto Complete">
                        </cc1:TextBoxWatermarkExtender>
                    </div>
                </div>
            <br />
            <asp:Button ID="Btn_Search" runat="server" CssClass="btn btn-primary" Text="Search" ValidationGroup="re"
                OnClientClick="return showReport();" />
        </div>
    </div>

    <div class="panel panel-default">
        <header class="panel-heading">
                Inventory MDS Report
            </header>
        <div class="panel-body">
           <div class="row">
                <div class="col-md-4 form-group">
                        <label>From Date</label><span
                            class="required">*</span>
                        <asp:TextBox ID="txtFromDate" runat="server" CssClass="form-control" ValidationGroup="mds" Width="100%"></asp:TextBox>
                        <cc1:CalendarExtender ID="txtFromDate_CalendarExtender" runat="server" Enabled="True"
                            TargetControlID="txtFromDate">
                        </cc1:CalendarExtender>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtFromDate"
                            Display="Dynamic" ErrorMessage="Required!" SetFocusOnError="True" ValidationGroup="mds"></asp:RequiredFieldValidator>
                    </div>
                <div class="col-md-4 form-group">
                        <label>To Date:</label><span class="required">*</span>
                        <asp:TextBox ID="txtToDate" runat="server" CssClass="form-control" ValidationGroup="mds" Width="100%"></asp:TextBox>
                        <cc1:CalendarExtender ID="txtToDate_CalendarExtender" runat="server" Enabled="True"
                            TargetControlID="txtToDate">
                        </cc1:CalendarExtender>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtToDate"
                            Display="Dynamic" ErrorMessage="Required!" SetFocusOnError="True" ValidationGroup="mds"></asp:RequiredFieldValidator>
                    </div>
                <div class="col-md-4 form-group">
                        <label>From Branch:</label>
                        <asp:DropDownList ID="fromBranch" runat="server" CssClass="form-control" Width="100%">
                        </asp:DropDownList>
                    </div>
               </div>
            <div class="row">
                <div class="col-md-4 form-group">
                        <label>To Branch:</label>
                        <asp:DropDownList ID="toBranch" runat="server" CssClass="form-control" Width="100%">
                        </asp:DropDownList>
                    </div>
                </div>
          <br />
            <asp:Button ID="btnMdsRpt" runat="server" CssClass="btn btn-primary" Text="Search" ValidationGroup="mds"
                OnClientClick="return showMDSReport();" />
        </div>
        </div>
        <script>
            function AutocompleteOnSelected(sender, e) {
                var customerValueArray = (e._value).split("|");
                document.getElementById("hdnProductId").value = customerValueArray[1];
            }
            function showReport() {
                if (!Page_ClientValidate('re'))
                    return false;
                var branch = GetValue("<% =branchName.ClientID %>");
            var product = GetValue("<% =hdnProductId.ClientID%>");
            var url = "/Report/InventoryReport/ViewInvMaster.aspx?branchId=" + branch + "&productId=" + product;

            OpenInNewWindow(url);
            return false;
        }
        function showMDSReport() {
            if (!Page_ClientValidate('mds'))
                return false;
            var fromDate = GetValue("<% =txtFromDate.ClientID%>");
            var toDate = GetValue("<% =txtToDate.ClientID %>");
            var fromBranch = GetValue("<% =fromBranch.ClientID%>");
            var toBranch = GetValue("<% =toBranch.ClientID %>");

            var url = "/Report/Report.aspx?reportName=mds_detail" +
            "&fromdate=" + fromDate +
            "&toDate=" + toDate +
            "&fromBranch=" + fromBranch +
            "&toBranch= " + toBranch;

            OpenInNewWindow(url);
            return false;
        }

        </script>
    </div>
</asp:Content>
