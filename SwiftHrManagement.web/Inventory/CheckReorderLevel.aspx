<%@ Page Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="CheckReorderLevel.aspx.cs" Inherits="SwiftHrManagement.web.Inventory.CheckReorderLevel" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../js/functions.js" type="text/javascript"> </script>
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
                 Inventory MIS Report
            </header>
    </div>
    <asp:HiddenField ID="hdnProductId" runat="server" />
    <div class="panel panel-default">
        <header class="panel-heading">
                Check Re-Order Level
            </header>
        <div class="panel-body">
            <div class="row">
              <div class="col-md-4 form-group">
                        <label>Branch Name:</label>
                        <span class="required">*</span>
                        <asp:DropDownList ID="DdlBranchName" runat="server" CssClass="form-control" Width="100%"></asp:DropDownList>

                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                            ControlToValidate="DdlBranchName" Display="Dynamic" ErrorMessage="Required!"
                            SetFocusOnError="True" ValidationGroup="re"></asp:RequiredFieldValidator>
                    </div>
              
              <div class="col-md-4 form-group">
                        <label>Product Name:</label>
                        <asp:TextBox ID="txtProduct" runat="server" CssClass="form-control"
                            Width="100%" AutoComplete="off"></asp:TextBox>

                        <cc1:AutoCompleteExtender ID="ACproduct" runat="server" DelimiterCharacters="" Enabled="true" ServicePath="~/Autocomplete.asmx"
                            ServiceMethod="GetProductList" TargetControlID="txtProduct" MinimumPrefixLength="1" CompletionInterval="10"
                            EnableCaching="true" CompletionListCssClass="autocompleteTextBoxLP" OnClientItemSelected="AutocompleteOnSelected">
                        </cc1:AutoCompleteExtender>

                        <cc1:TextBoxWatermarkExtender ID="txtProduct_TextBoxWatermarkExtender0"
                            runat="server" Enabled="True" TargetControlID="txtProduct"
                            WatermarkCssClass="form-control" WatermarkText="Auto Complete">
                        </cc1:TextBoxWatermarkExtender>
                    </div>
                </div>
          <br />
            <asp:Button ID="Btn_Search" runat="server" CssClass="btn btn-primary" Text="Search" ValidationGroup="re" OnClientClick="return showReport_1();" />
        </div>
    </div>

    <div class="panel panel-default">
        <header class="panel-heading">
                Total Inventory purchased report
         </header>
        <div class="panel-body">
            <div class="row">
              <div class="col-md-4 form-group">
                        <label>From Date:</label><span class="required">*</span>
                        <asp:TextBox ID="fromDate" runat="server" CssClass="form-control" Width="100%"></asp:TextBox>
                        <cc1:CalendarExtender ID="DropDownList2_CalendarExtender" runat="server"
                            Enabled="True" TargetControlID="fromDate">
                        </cc1:CalendarExtender>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                            ControlToValidate="fromDate" Display="Dynamic" ErrorMessage="Required!"
                            SetFocusOnError="True" ValidationGroup="pur"></asp:RequiredFieldValidator>
                    </div>
               
              <div class="col-md-4 form-group">
                        <label>To Date:</label><span class="required">*</span>
                        <asp:TextBox ID="toDate" runat="server" CssClass="form-control" Width="100%"></asp:TextBox>
                        <cc1:CalendarExtender ID="CalendarExtender1" runat="server"
                            Enabled="True" TargetControlID="toDate">
                        </cc1:CalendarExtender>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"
                            ControlToValidate="toDate" Display="Dynamic" ErrorMessage="Required!"
                            SetFocusOnError="True" ValidationGroup="pur"></asp:RequiredFieldValidator>
                    </div>
              <div class="col-md-4 form-group">
                        <label>Branch Name:</label>
                        <asp:DropDownList ID="DdlBranchName1" runat="server" CssClass="form-control"
                            Width="100%">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server"
                            ControlToValidate="DdlBranchName1" Display="Dynamic" ErrorMessage="Required!"
                            SetFocusOnError="True" ValidationGroup="pur"></asp:RequiredFieldValidator>
                    </div>
                </div>
          

            <div class="row">
              <div class="col-md-4 form-group">
                        <label>Vendor Name:</label>
                        <asp:DropDownList ID="ddlVendorName" runat="server" CssClass="form-control"
                            Width="100%">
                        </asp:DropDownList>
                    </div>
             
              <div class="col-md-4 form-group">
                        <label>Product Group Name:</label>
                        <asp:DropDownList ID="ddlproductGroup" runat="server" CssClass="form-control"
                            Width="100%" AutoPostBack="true"
                            OnSelectedIndexChanged="ddlproductGroup_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>
              <div class="col-md-4 form-group">
                        <label>Product Name</label>
                        <asp:DropDownList ID="DdlProductName" runat="server" CssClass="form-control" Width="100%">
                        </asp:DropDownList>
                    </div>
                </div>
           <br />
            <asp:Button ID="BtnSearch" runat="server" CssClass="btn btn-primary"
                ValidationGroup="pur" OnClientClick="return showReport_3();" Text="Search" />
        </div>
    </div>

    <div class="panel panel-default">
        <header class="panel-heading">
                User Access Report
            </header>
        <div class="panel-body">
            <div class="row">
              <div class="col-md-4 form-group">
                        <label>User Access Type:</label>
                        <asp:DropDownList ID="userAccess" runat="server" CssClass="form-control" Width="100%">
                            <asp:ListItem Value="">ALL</asp:ListItem>
                            <asp:ListItem Value="All Branch Access">All Branch Access</asp:ListItem>
                            <asp:ListItem Value="HO & Self Branch Access">HO & Self Branch Access</asp:ListItem>
                            <asp:ListItem Value="Self Branch Only">Self Branch Only</asp:ListItem>
                        </asp:DropDownList>
                    </div>
               
              <div class="col-md-4 form-group">
                        <label>
                            User Name
                        </label>
                        <asp:TextBox ID="userName" runat="server" CssClass="form-control" Width="100%"></asp:TextBox>
                    </div>
                </div>
           <br />
            <asp:Button ID="btnUserAccessRpt" runat="server" CssClass="btn btn-primary" OnClientClick="return showReport_4();" Text="Search" />
        </div>
    </div>

    <div class="panel panel-default">
        <header class="panel-heading">
                Purchase Payment Wise report
            </header>
        <div class="panel-body">
            <div class="row">
              <div class="col-md-4 form-group">
                        <label>From Date:</label><span class="required">*</span>
                        <asp:TextBox ID="txtFromDate" runat="server" CssClass="form-control" Width="100%"></asp:TextBox>
                        <cc1:CalendarExtender ID="txtFromDate_CalendarExtender" runat="server"
                            Enabled="True" TargetControlID="txtFromDate">
                        </cc1:CalendarExtender>

                        <asp:RequiredFieldValidator ID="rfv2" runat="server"
                            ControlToValidate="txtFromDate" Display="Dynamic" ErrorMessage="Required!"
                            SetFocusOnError="True" ValidationGroup="pay"></asp:RequiredFieldValidator>
                    </div>
              
              <div class="col-md-4 form-group">
                        <label>To Date:</label><span class="required">*</span>
                        <asp:TextBox ID="txtToDate" runat="server" CssClass="form-control" Width="100%"></asp:TextBox>
                        <cc1:CalendarExtender ID="txtToDate_qw" runat="server"
                            Enabled="True" TargetControlID="txtToDate">
                        </cc1:CalendarExtender>

                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                            ControlToValidate="txtToDate" Display="Dynamic" ErrorMessage="Required!"
                            SetFocusOnError="True" ValidationGroup="pay"></asp:RequiredFieldValidator>
                    </div>
              
              <div class="col-md-4 form-group">
                        <label>Branch Name:</label>
                        <asp:DropDownList ID="branchName" runat="server" CssClass="form-control" Width="100%"></asp:DropDownList>
                    </div>
                </div>
          
            <div class="row">
              <div class="col-md-4 form-group">
                        <label>Vendor Name:</label>
                        <asp:DropDownList ID="vendorName" runat="server" CssClass="form-control" Width="100%"></asp:DropDownList>
                    </div>
               
              <div class="col-md-4 form-group">
                        <label>Payment Status:</label>
                        <asp:DropDownList ID="paymentStatus" runat="server" CssClass="form-control" Width="100%">
                            <asp:ListItem Value="All">All</asp:ListItem>
                            <asp:ListItem Value="Unpaid">Unpaid</asp:ListItem>
                            <asp:ListItem Value="Paid">Paid</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
            <br />
            <asp:Button ID="btnPaymentReport" runat="server" CssClass="btn btn-primary" Text="Search" OnClientClick="return showReport_2();" ValidationGroup="pay" />
        </div>
    </div>
    </div>

   
    <script>
        function AutocompleteOnSelected(sender, e) {
            var customerValueArray = (e._value).split("|");
            document.getElementById("hdnProductId").value = customerValueArray[1];
        }
        function ProductOnSelected(sender, e) {
            var customerValueArray = (e._value).split("|");
            document.getElementById("hdnProduct1").value = customerValueArray[1];
        }
        function showReport_1() {

            if (!Page_ClientValidate('re'))
                return false;
            var branch = GetValue("<% =DdlBranchName.ClientID %>");
            var product = GetValue("<% =hdnProductId.ClientID%>");
            var url = "/Inventory/ListReOrderLevel.aspx?Branch=" + branch + "&Product=" + product;

            OpenInNewWindow(url);
            return false;
        }
        function showReport_2() {

            if (!Page_ClientValidate('pay'))
                return false;
            var fromDate = GetDateValue("<% =txtFromDate.ClientID%>");
        var toDate = GetDateValue("<% =txtToDate.ClientID%>");
        var branch = GetValue("<% =branchName.ClientID %>");
        var vendor = GetValue("<% =vendorName.ClientID%>");
        var status = GetValue("<% =paymentStatus.ClientID%>");

        var url = "/Inventory/paymentWisePurchaseReport.aspx?from_date=" + fromDate +
        "&to_date=" + toDate +
        "&branch_id=" + branch +
        "&vendor_id=" + vendor +
        "&status=" + status;

        OpenInNewWindow(url);
        return false;
    }
    function showReport_3() {
        if (!Page_ClientValidate('pur'))
            return false;
        var fromDate = GetDateValue("<% =fromDate.ClientID %>");
        var toDate = GetDateValue("<% =toDate.ClientID %>");
        var vendorId = GetValue("<% =ddlVendorName.ClientID %>");
        var branch = GetValue("<% =DdlBranchName1.ClientID %>");
        var group = GetValue("<% =ddlproductGroup.ClientID %>");
        var product = GetValue("<% =DdlProductName.ClientID %>");

        var url = "/Inventory/ListTotalPurchased.aspx?fromDate=" + fromDate +
        "&toDate=" + toDate +
        "&vendorId=" + vendorId +
        "&Branch=" + branch +
        "&group=" + group +
        "&Product=" + product;

        OpenInNewWindow(url);
        return false;
    }

    function showReport_4() {
        var userType = GetValue("<% =userAccess.ClientID %>");
        var userName = GetValue("<% =userName.ClientID%>");

        var url = "/Inventory/userAccessRpt.aspx?userType=" + userType +
        "&userName=" + userName;

        OpenInNewWindow(url);
        return false;
    }
    </script>

</asp:Content>
