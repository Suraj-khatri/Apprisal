<%@ Page Title="" Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="ManageMonthEndReport.aspx.cs" Inherits="SwiftHrManagement.web.Report.InventoryReport.ManageMonthEndReport" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../../js/functions.js" type="text/javascript"> </script>

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
            Inventory Month End Report
        </header>
    </div>
    <asp:HiddenField ID="hdnProductId" runat="server" />
    <div class="panel panel-default">
        <header class="panel-heading">
            
            Inventory Month End Report
        </header>
        <div class="panel-body">
              <div class="row">
                <div class="col-md-4 form-group">
                        <label>From Date:<span class="required">*</span></label>
                        <asp:TextBox ID="txtFromDate" runat="server" CssClass="form-control" Width="100%"
                            ValidationGroup="summary"></asp:TextBox>
                        <cc1:CalendarExtender ID="txtFromDate_CalendarExtender" runat="server"
                            Enabled="True" TargetControlID="txtFromDate">
                        </cc1:CalendarExtender>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                            ControlToValidate="txtFromDate" Display="Dynamic" ErrorMessage="Required!"
                            SetFocusOnError="True" ValidationGroup="summary"></asp:RequiredFieldValidator>
                </div>
                <div class="col-md-4 form-group">
                        <label>To Date:</label><span class="required">*</span>
                        <asp:TextBox ID="txtToDate" runat="server" CssClass="form-control" Width="100%"
                            ValidationGroup="summary"></asp:TextBox>
                        <cc1:CalendarExtender ID="txtToDate_CalendarExtender" runat="server"
                            Enabled="True" TargetControlID="txtToDate">
                        </cc1:CalendarExtender>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"
                            ControlToValidate="txtToDate" Display="Dynamic" ErrorMessage="Required!"
                            SetFocusOnError="True" ValidationGroup="summary"></asp:RequiredFieldValidator>
                    </div>
                <div class="col-md-4 form-group">
                        <label>Branch Name:<span class="errormsg">*</span></label>
                        <asp:DropDownList ID="DdlBranchName" runat="server" CssClass="form-control" Width="100%">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server"
                            ControlToValidate="DdlBranchName" ErrorMessage="Required!"
                            SetFocusOnError="True" ValidationGroup="summary"> </asp:RequiredFieldValidator>
                </div>
            </div>
            <asp:Button ID="btnShow" runat="server" CssClass="btn btn-primary" Text=" Search " ValidationGroup="summary" OnClientClick="return showReport_1();" />

        </div>
    </div>

    <div class="panel panel-default">
        <header class="panel-heading">
            BRANCH WISE STOCK IN TRANSIT (NOT ACKNOWLEDGE)
        </header>
        <div class="panel-body">
              <div class="row">
                <div class="col-md-4 form-group">
                        <label>From Date:</label><span class="required">*</span>
                        <asp:TextBox ID="FROM_DATE" runat="server" CssClass="form-control" Width="100%"
                            ValidationGroup="summary"></asp:TextBox>
                        <cc1:CalendarExtender ID="CalendarExtender1" runat="server"
                            Enabled="True" TargetControlID="FROM_DATE">
                        </cc1:CalendarExtender>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                            ControlToValidate="FROM_DATE" Display="Dynamic" ErrorMessage="Required!"
                            SetFocusOnError="True" ValidationGroup="NA"></asp:RequiredFieldValidator>
                    </div>
               
                <div class="col-md-4 form-group">
                        <label>To Date:</label><span class="required">*</span>
                        <asp:TextBox ID="TO_DATE" runat="server" CssClass="form-control" Width="100%"
                            ValidationGroup="summary"></asp:TextBox>
                        <cc1:CalendarExtender ID="CalendarExtender2" runat="server"
                            Enabled="True" TargetControlID="TO_DATE">
                        </cc1:CalendarExtender>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                            ControlToValidate="TO_DATE" Display="Dynamic" ErrorMessage="Required!"
                            SetFocusOnError="True" ValidationGroup="NA"></asp:RequiredFieldValidator>
                    </div>
               
                <div class="col-md-4 form-group">
                        <label>Branch Name:</label>
                        <asp:DropDownList ID="BRANCH_NAME" runat="server" CssClass="form-control" Width="100%">
                        </asp:DropDownList>
                    </div>
                </div>
            <br />
            <asp:Button ID="BTNNA" runat="server" CssClass="btn btn-primary" Text=" Search "
                ValidationGroup="NA" OnClientClick="return showReport_2();" />

        </div>
    </div>
    <div class="panel panel-default">
        <header class="panel-heading">
BUDGETED REPORT
        </header>
        <div class="panel-body">
              <div class="row">
                <div class="col-md-4 form-group">
                        <label>Fiscal Year:</label><span class="errormsg">*</span>
                        <asp:DropDownList ID="FY_Year" runat="server" CssClass="form-control" Width="100%">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server"
                            ControlToValidate="FY_Year" ErrorMessage="Required!"
                            SetFocusOnError="True" ValidationGroup="BUD"> </asp:RequiredFieldValidator>
                    </div>
            
                <div class="col-md-4 form-group">
                        <label>Branch Name:<span class="errormsg">*</span></label>
                        <asp:DropDownList ID="BRANCH_NAME1" runat="server" CssClass="form-control" Width="100%">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server"
                            ControlToValidate="BRANCH_NAME1" ErrorMessage="Required!"
                            SetFocusOnError="True" ValidationGroup="BUD"> </asp:RequiredFieldValidator>
                    </div>
               
                <div class="col-md-4 form-group">
                        <label>Product Name:</label>
                        <asp:TextBox ID="txtProduct" runat="server" CssClass="inputTextBox"
                            Width="100%" AutoComplete="off"></asp:TextBox>

                        <cc1:TextBoxWatermarkExtender ID="txtProduct_TextBoxWatermarkExtender"
                            runat="server" Enabled="True" TargetControlID="txtProduct"
                            WatermarkText="Auto Complete" WatermarkCssClass="form-control">
                        </cc1:TextBoxWatermarkExtender>

                        <cc1:AutoCompleteExtender ID="ACproduct" runat="server" DelimiterCharacters="" Enabled="true" ServicePath="~/Autocomplete.asmx"
                            ServiceMethod="GetProductList" TargetControlID="txtProduct" MinimumPrefixLength="1" CompletionInterval="10"
                            EnableCaching="true" CompletionListCssClass="autocompleteTextBoxLP" OnClientItemSelected="AutocompleteOnSelected">
                        </cc1:AutoCompleteExtender>
                    </div>
                </div>
            <asp:Button ID="BTNBUDGETED_RPT" runat="server" CssClass="btn btn-primary" Text=" Search "
                ValidationGroup="BUD" OnClientClick="return showReport_3();" />
        </div>
    </div>
    </div>
      
    <script>
        function AutocompleteOnSelected(sender, e) {

            var customerValueArray = (e._value).split("|");
            document.getElementById("<%=hdnProductId.ClientID %>").value = customerValueArray[1];
        }
        function showReport_1() {

            if (!Page_ClientValidate('summary'))
                return false;
            var fromDate = GetDateValue("<% =txtFromDate.ClientID%>");
            var toDate = GetDateValue("<% =txtToDate.ClientID%>");
            var branch = GetValue("<% =DdlBranchName.ClientID %>");
            var url = "/Report/InventoryReport/ShowMonthEndRpt.aspx?fromdate=" + fromDate +
                "&todate=" + toDate +
                "&branchname=" + branch;

            OpenInNewWindow(url);
            return false;
        }
        function showReport_2() {

            if (!Page_ClientValidate('NA'))
                return false;
            var fromDate = GetDateValue("<% =FROM_DATE.ClientID%>");
            var toDate = GetDateValue("<% =TO_DATE.ClientID%>");
            var branch = GetValue("<% =BRANCH_NAME.ClientID %>");
            var url = "/Report/InventoryReport/NotAcknowledge.aspx?fromdate=" + fromDate +
                "&todate=" + toDate +
                "&branchname=" + branch;

            OpenInNewWindow(url);
            return false;
        }

        function showReport_3() {

            if (!Page_ClientValidate('BUD'))
                return false;
            var branch = GetValue("<% =BRANCH_NAME1.ClientID %>");
            var fy = GetValue("<% =FY_Year.ClientID %>");
            var productId = GetValue("<% =hdnProductId.ClientID %>");
            var url = "/Report/InventoryReport/budgetedRpt.aspx?branchname=" + branch +
                "&fy=" + fy +
                "&product=" + productId;

            OpenInNewWindow(url);
            return false;
        }
    </script>
</asp:Content>
