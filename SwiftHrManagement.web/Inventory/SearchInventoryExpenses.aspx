<%@ Page Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="SearchInventoryExpenses.aspx.cs" Inherits="SwiftHrManagement.web.Inventory.SearchInventoryExpenses" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../js/functions.js" type="text/javascript"> </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    <asp:UpdatePanel ID="up" runat="server">
        <ContentTemplate>
            <style type="text/css">
                .form-inline .form-control {
                    margin-bottom: 3px !important;
                }
            </style>
              <div class="col-md-10 col-md-offset-1">
            <div class="panel">
                <header class="panel-heading">
                    <i class="fa fa-caret-right"></i>
            Inventory Expenses Report
        </header>
            </div>
            <asp:HiddenField ID="hdnProductId" runat="server" />

            <div class="panel panel-default">
                <header class="panel-heading">
            Inventory Expenses Date Wise
        </header>
                <div class="panel-body">
                    <div class="row">
                         <div class="col-md-4 form-group">
                                <label>
                                    From :<span class="required">*</span>
                                </label>
                                <asp:TextBox ID="txtFromDate" runat="server" CssClass="form-control" Width="100%">  </asp:TextBox>
                                <cc1:CalendarExtender ID="txtFromDate_CalendarExtender" runat="server"
                                    Enabled="True" TargetControlID="txtFromDate">
                                </cc1:CalendarExtender>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                    ControlToValidate="txtFromDate" Display="Dynamic" ErrorMessage="Required!"
                                    SetFocusOnError="True" ValidationGroup="date"></asp:RequiredFieldValidator>
                            </div>
                         <div class="col-md-4 form-group">
                                <label>
                                    To Date:<span class="required">*</span>
                                </label>
                                <asp:TextBox ID="txtToDate" runat="server" CssClass="form-control" Width="100%"></asp:TextBox>
                                <cc1:CalendarExtender ID="txtToDate_CalendarExtender" runat="server"
                                    Enabled="True" TargetControlID="txtToDate">
                                </cc1:CalendarExtender>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                                    ControlToValidate="txtToDate" Display="Dynamic" ErrorMessage="Required!"
                                    SetFocusOnError="True" ValidationGroup="date"></asp:RequiredFieldValidator>
                            </div>
                         <div class="col-md-4 form-group">
                                <label>
                                    Branch Name:
                                </label>
                                <asp:DropDownList ID="DdlBranchName3" runat="server" CssClass="form-control" Width="100%"></asp:DropDownList>
                            </div>
                        </div>
                   <br />
                    <asp:Button ID="BtnSearch123" runat="server" CssClass="btn btn-primary" Text="Product Wise Detail Rpt" ValidationGroup="date" OnClientClick="return showReport1();" />
                    <asp:Button ID="BtnSummaryRpt" runat="server" CssClass="btn btn-primary" Text="Branch Wise Summary Rpt" ValidationGroup="date" OnClientClick="return showReport2();" />
                    <asp:Button ID="BtnGroupWiseRpt" runat="server" Text="Branch & Group Wise Summary Rpt" CssClass="btn btn-primary" OnClientClick="return showReport3();" />
                </div>
            </div>

            <div class="panel panel-default">
                <header class="panel-heading">
                 Inventory Expenses Summary report
                </header>
                <div class="panel-body">
                    <div class="row">
                         <div class="col-md-4 form-group">
                                <label>
                                    From Date:<span class="required">*</span>
                                </label>
                                <asp:TextBox ID="txtFrom" runat="server" CssClass="form-control" Width="100%">
                                </asp:TextBox>
                                <cc1:CalendarExtender ID="CalendarExtender1" runat="server"
                                    Enabled="True" TargetControlID="txtFrom">
                                </cc1:CalendarExtender>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                                    ControlToValidate="txtFrom" Display="Dynamic" ErrorMessage="Required!"
                                    SetFocusOnError="True" ValidationGroup="d1">
                                </asp:RequiredFieldValidator>
                            </div>
                        
                         <div class="col-md-4 form-group">
                                <label>
                                    To Date:<span class="required">*</span>
                                </label>
                                <asp:TextBox ID="txtTo" runat="server" CssClass="form-control" Width="100%">
                                </asp:TextBox>

                                <cc1:CalendarExtender ID="CalendarExtender2" runat="server"
                                    Enabled="True" TargetControlID="txtTo">
                                </cc1:CalendarExtender>

                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"
                                    ControlToValidate="txtTo" Display="Dynamic" ErrorMessage="Required!"
                                    SetFocusOnError="True" ValidationGroup="d1">
                                </asp:RequiredFieldValidator>
                            </div>
                       
                         <div class="col-md-4 form-group">
                                <label>
                                    Branch Name:
                                </label>
                                <asp:DropDownList ID="DdlBranchName" runat="server" CssClass="form-control"
                                    Width="100%" AutoPostBack="True"
                                    OnSelectedIndexChanged="DdlBranchName_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                        </div>
                  
                    <div class="row">
                         <div class="col-md-4 form-group">
                                <label>
                                    Department Name:
                                </label>
                                <asp:DropDownList ID="DdlDeptName" runat="server" CssClass="form-control"
                                    Width="100%" AutoPostBack="True">
                                </asp:DropDownList>
                            </div>
                      
                        <div class="col-md-4 autocomplete-form form-group">
                                <label>
                                    Product Name:
                                </label>
                                <asp:TextBox ID="txtProduct" runat="server" CssClass="form-control"
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
                    <br />
                    <asp:Button ID="Btn_Search" runat="server" CssClass="btn btn-primary" Text="Branch Wise" OnClientClick="return showReport4();" ValidationGroup="d1" />
                    <asp:Button ID="Button2" runat="server" CssClass="btn btn-primary" Text=" Detail Report " OnClientClick="return showReport7();" ValidationGroup="d1" />
                </div>
            <div class="panel panel-default">
                <header class="panel-heading">
            Inventory Transfer Out
        </header>
                <div class="panel-body">
                    <div class="row">
                         <div class="col-md-4 form-group">
                                <label>
                                    From Date:<span class="required">*</span>
                                </label>
                                <asp:TextBox ID="txtFromDate1" runat="server" CssClass="form-control"
                                    Width="100%"> </asp:TextBox>
                                <cc1:CalendarExtender ID="txtFromDate1_CalendarExtender" runat="server"
                                    Enabled="True" TargetControlID="txtFromDate1">
                                </cc1:CalendarExtender>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator112" runat="server"
                                    ControlToValidate="txtFromDate1" Display="Dynamic" ErrorMessage="Required!"
                                    SetFocusOnError="True" ValidationGroup="out"></asp:RequiredFieldValidator>
                        </div>
                         <div class="col-md-4 form-group">
                                <label>
                                    To Date:<span class="required">*</span>
                                </label>
                                <asp:TextBox ID="txtToDate1" runat="server" CssClass="form-control"
                                    Width="100%"> </asp:TextBox>
                                <cc1:CalendarExtender ID="txtToDate1_CalendarExtender" runat="server"
                                    Enabled="True" TargetControlID="txtToDate1">
                                </cc1:CalendarExtender>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator11112" runat="server"
                                    ControlToValidate="txtToDate1" Display="Dynamic" ErrorMessage="Required!"
                                    SetFocusOnError="True" ValidationGroup="out"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                   <br />
                    <asp:Button ID="BtnViewRpt" runat="server" CssClass="btn btn-primary" Text="View Report" ValidationGroup="out" OnClientClick="return showReport5();" />
                </div>
            </div>

            <div class="panel panel-default">
                <header class="panel-heading">

                 </header>
                <div class="panel-body">
                    <div class="row">
                         <div class="col-md-4 form-group">
                                <label>
                                    From Date:<span class="required">*</span>
                                </label>
                                <asp:TextBox ID="fromDate" runat="server" CssClass="form-control"
                                    Width="100%">      </asp:TextBox>
                                <cc1:CalendarExtender ID="CalendarExtender3" runat="server"
                                    Enabled="True" TargetControlID="fromDate">
                                </cc1:CalendarExtender>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server"
                                    ControlToValidate="fromDate" Display="Dynamic" ErrorMessage="Required!"
                                    SetFocusOnError="True" ValidationGroup="disposal"></asp:RequiredFieldValidator>
                         </div>
                         <div class="col-md-4 form-group">
                                <label>
                                    To Date:<span class="required">*</span>
                                </label>
                                <asp:TextBox ID="toDate" runat="server" CssClass="form-control"
                                    Width="100%"></asp:TextBox>
                                <cc1:CalendarExtender ID="CalendarExtender4" runat="server"
                                    Enabled="True" TargetControlID="toDate">
                                </cc1:CalendarExtender>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server"
                                    ControlToValidate="toDate" Display="Dynamic" ErrorMessage="Required!"
                                    SetFocusOnError="True" ValidationGroup="disposal"></asp:RequiredFieldValidator>
                            </div>
                        <div class="col-md-4 autocomplete-form form-group">
                                <label>
                                    Product Name:
                                </label>
                                <asp:TextBox ID="productId" runat="server" CssClass="form-control"
                                    Width="100%" AutoComplete="off"></asp:TextBox>

                                <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1"
                                    runat="server" Enabled="True" TargetControlID="productId"
                                    WatermarkText="Auto Complete" WatermarkCssClass="form-control">
                                </cc1:TextBoxWatermarkExtender>

                                <cc1:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" DelimiterCharacters="" Enabled="true" ServicePath="~/Autocomplete.asmx"
                                    ServiceMethod="GetProductList" TargetControlID="productId" MinimumPrefixLength="1" CompletionInterval="10"
                                    EnableCaching="true" CompletionListCssClass="autocompleteTextBoxLP" OnClientItemSelected="AutocompleteOnSelected">
                                </cc1:AutoCompleteExtender>
                            </div>
                        </div>
                    <br />
                    <asp:Button ID="Button1" runat="server" CssClass="btn btn-primary" Text="View Report" ValidationGroup="disposal" OnClientClick="return showReport6();" />
                </div>
            </div>
</div>

        </ContentTemplate>
    </asp:UpdatePanel>

    <script>
        function AutocompleteOnSelected(sender, e) {

            var customerValueArray = (e._value).split("|");
            document.getElementById("<%=hdnProductId.ClientID %>").value = customerValueArray[1];
        }

        function showReport1() {
            if (!Page_ClientValidate('date'))
                return false;
            var fromDate = GetDateValue("<% =txtFromDate.ClientID%>");
        var toDate = GetDateValue("<% =txtToDate.ClientID%>");
        var branch = GetValue("<% =DdlBranchName3.ClientID %>");

        var url = "/Inventory/InventoryExpensesDateWise.aspx?fromDate=" + fromDate +
                "&toDate=" + toDate +
                "&branch=" + branch;

        OpenInNewWindow(url);
        return false;
    }
    function showReport2() {
        if (!Page_ClientValidate('date'))
            return false;
        var fromDate = GetDateValue("<% =txtFromDate.ClientID%>");
        var toDate = GetDateValue("<% =txtToDate.ClientID%>");
        var branch = GetValue("<% =DdlBranchName3.ClientID %>");

        var url = "/Inventory/InvenotrySummaryExpensesBranchWise.aspx?fromDate=" + fromDate +
                "&toDate=" + toDate +
                "&branch=" + branch;

        OpenInNewWindow(url);
        return false;
    }
    function showReport3() {
        if (!Page_ClientValidate('date'))
            return false;
        var fromDate = GetDateValue("<% =txtFromDate.ClientID%>");
        var toDate = GetDateValue("<% =txtToDate.ClientID%>");
        var url = "/Inventory/branch_group_summary_rpt.aspx?fromDate=" + fromDate +
                "&toDate=" + toDate;

        OpenInNewWindow(url);
        return false;
    }
    function showReport4() {
        if (!Page_ClientValidate('d1'))
            return false;
        var fromDate = GetDateValue("<% =txtFrom.ClientID%>");
        var toDate = GetDateValue("<% =txtTo.ClientID%>");
        var branch = GetValue("<% =DdlBranchName.ClientID %>");
        var dept = GetValue("<% =DdlDeptName.ClientID %>");
        var productName = GetValue("<% =txtProduct.ClientID %>");
        var productId = GetValue("<% =hdnProductId.ClientID %>");
        if (productName == "Auto Complete")
            productId = "";

        var url = "/Inventory/InventoryStockExpenses.aspx?fromDate=" + fromDate +
                  "&toDate=" + toDate +
                  "&branch=" + branch +
                  "&Dept=" + dept +
                  "&Product=" + productId;

        OpenInNewWindow(url);
        return false;
    }
    function showReport5() {
        if (!Page_ClientValidate('out'))
            return false;
        var fromDate = GetDateValue("<% =txtFromDate1.ClientID%>");
        var toDate = GetDateValue("<% =txtToDate1.ClientID%>");

        var url = "/Inventory/ViewTransferOutRpt.aspx?fromDate=" + fromDate +
                  "&toDate=" + toDate;

        OpenInNewWindow(url);
        return false;
    }
    function showReport6() {
        if (!Page_ClientValidate('disposal'))
            return false;
        var fromDate = GetDateValue("<% =fromDate.ClientID%>");
        var toDate = GetDateValue("<% =toDate.ClientID%>");
        var productId = GetValue("<% =hdnProductId.ClientID %>");
        var productName = GetValue("<% =productId.ClientID %>");
        if (productName == "Auto Complete")
            productId = "";
        var url = "/Inventory/disposalRpt.aspx?fromDate=" + fromDate +
                    "&toDate=" + toDate +
                    "&productId=" + productId;

        OpenInNewWindow(url);
        return false;
    }
    function showReport7() {
        if (!Page_ClientValidate('d1'))
            return false;
        var fromDate = GetDateValue("<% =txtFrom.ClientID%>");
        var toDate = GetDateValue("<% =txtTo.ClientID%>");
        var branch = GetValue("<% =DdlBranchName.ClientID %>");
        var dept = GetValue("<% =DdlDeptName.ClientID %>");
        var productName = GetValue("<% =txtProduct.ClientID %>");
        var productId = GetValue("<% =hdnProductId.ClientID %>");
        if (productName == "Auto Complete")
            productId = "";
        var url = "/Inventory/InventoryExpensesDetailRpt.aspx?fromDate=" + fromDate +
                  "&toDate=" + toDate +
                  "&branch=" + branch +
                  "&Dept=" + dept +
                  "&Product=" + productId;

        OpenInNewWindow(url);
        return false;
    }
    </script>
</asp:Content>
