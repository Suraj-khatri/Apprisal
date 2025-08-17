<%@ Page Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="SearchStockReport.aspx.cs" Inherits="SwiftHrManagement.web.Inventory.SearchStockReport" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../js/functions.js" type="text/javascript"> </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">

    <style type="text/css">
        .form-group {
            margin-bottom: 3px !important;
        }
    </style>
    <script type="text/javascript" src="../js/functions.js"></script>

    <asp:UpdatePanel ID="abc" runat="server">
        <ContentTemplate>
              <div class="col-md-10 col-md-offset-1">
            <asp:HiddenField ID="hdnProduct" runat="server" />
            <div class="panel">
                <header class="panel-heading">
                    <i class="fa fa-caret-right"></i>
                    Inventory Summary Report
                </header>
            </div>

            <div class="panel panel-default">
                <header class="panel-heading">
                   Inventory Summary Report - Date Wise
                </header>

                <div class="panel-body">
                    <asp:HiddenField ID="product" runat="server" />
                     <div class="row">
                        <div class="col-md-4 form-group">
                                <label>From Date:<span class="required">*</span> </label>
                          
                                <asp:TextBox ID="txtFromDate" runat="server" CssClass="form-control" Width="100%"></asp:TextBox>
                                <cc1:CalendarExtender ID="txtFromDate_CalendarExtender" runat="server"
                                    Enabled="True" TargetControlID="txtFromDate">
                                </cc1:CalendarExtender>
                                <asp:RequiredFieldValidator ID="rfv1" runat="server"
                                    ControlToValidate="txtFromDate" Display="Dynamic" ErrorMessage="Required!"
                                    SetFocusOnError="True" ValidationGroup="date"></asp:RequiredFieldValidator>
                            </div>
                       
                        <div class="col-md-4 form-group">
                                <label>To Date:<span class="required">*</span> </label>
                                <asp:TextBox ID="txtToDate" runat="server" CssClass="form-control" Width="100%"></asp:TextBox>
                                <cc1:CalendarExtender ID="DropDownList2_CalendarExtender" runat="server"
                                    Enabled="True" TargetControlID="txtToDate">
                                </cc1:CalendarExtender>
                                <asp:RequiredFieldValidator ID="rfv2" runat="server"
                                    ControlToValidate="txtToDate" Display="Dynamic" ErrorMessage="Required!"
                                    SetFocusOnError="True" ValidationGroup="date"></asp:RequiredFieldValidator>
                            </div>
                       
                        <div class="col-md-4 form-group">
                                <label>Branch Name:<span class="required">*</span></label>
                                <asp:DropDownList ID="ddlBranch" runat="server" CssClass="form-control" Width="100%"></asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                    ControlToValidate="ddlBranch" Display="Dynamic" ErrorMessage="Required!"
                                    SetFocusOnError="True" ValidationGroup="date"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                     <div class="row">
                        <div class="col-md-4 form-group">
                                <label>Product Name:<span class="errormsg"> *</span></label>
                                <asp:TextBox ID="txtProductName" runat="server" CssClass="form-control" Width="100%"
                                    AutoComplete="off"></asp:TextBox>

                                <cc1:TextBoxWatermarkExtender ID="txtProductName_TextBoxWatermarkExtender"
                                    runat="server" Enabled="True" TargetControlID="txtProductName" WatermarkCssClass="form-control" WatermarkText="Auto Complete">
                                </cc1:TextBoxWatermarkExtender>
                                <cc1:AutoCompleteExtender ID="txtProductName_AutoCompleteExtender"
                                    runat="server" CompletionInterval="10"
                                    CompletionListCssClass="autocompleteTextBoxLP" DelimiterCharacters=""
                                    Enabled="True" MinimumPrefixLength="1" OnClientItemSelected="GetProductId"
                                    ServiceMethod="GetProductList" ServicePath="~/Autocomplete.asmx"
                                    TargetControlID="txtProductName">
                                </cc1:AutoCompleteExtender>
                            </div>
                        </div>
                   <br />
                <asp:Button ID="BtnSearch" runat="server" CssClass="btn btn-primary"
                    OnClientClick="return showReport();" Text="Search" ValidationGroup="date" />
              <asp:Button ID="BtnExportExcel" runat="server" CssClass="btn btn-primary"
                    Text="Export To Excel" ValidationGroup="date"
                    OnClick="BtnExportExcel_Click" />
                </div>
            </div>

            <div class="panel panel-default">
                <header class="panel-heading">
                  Stock in hand Report
                </header>
                <div class="panel-body">
                    <asp:HiddenField ID="hdnProductId" runat="server" />
                     <div class="row">
                        <div class="col-md-4 form-group">
                                <label>Branch Name:</label>
                                <asp:DropDownList ID="DdlBranchName" runat="server" CssClass="form-control" Width="100%"></asp:DropDownList>
                            </div>
                        
                        <div class="col-md-4 autocomplete-form from-group">
                                <label>Product Name:</label>
                                <asp:TextBox ID="txtProduct" runat="server" CssClass="form-control" Width="100%"
                                    AutoComplete="off"></asp:TextBox>
                                <cc1:AutoCompleteExtender ID="ACproduct" runat="server" DelimiterCharacters="" Enabled="true" ServicePath="~/Autocomplete.asmx"
                                    ServiceMethod="GetProductList" TargetControlID="txtProduct" MinimumPrefixLength="1" CompletionInterval="10"
                                    EnableCaching="true" CompletionListCssClass="autocompleteTextBoxLP" OnClientItemSelected="AutocompleteOnSelected">
                                </cc1:AutoCompleteExtender>

                                <cc1:TextBoxWatermarkExtender ID="txtProduct_TextBoxWatermarkExtender0"
                                    runat="server" Enabled="True" TargetControlID="txtProduct"
                                    WatermarkCssClass="form-control" WatermarkText="Auto Complete">
                                </cc1:TextBoxWatermarkExtender>
                       </div>
                        </div><br />
                    <asp:Button ID="Btn_Search" runat="server" CssClass="btn btn-primary" Text="Search" OnClientClick="return showReport_ONE();" />
                </div>
            </div>

            <div class="panel panel-default">
                <header class="panel-heading">
                    Inventory Transfer & Stock Date Wise
                </header>
                <div class="panel-body">
                     <div class="row">
                        <div class="col-md-4 form-group">
                                <label>From Date:<span class="required">*</span></label>
                                <asp:TextBox ID="txtFromDate1" runat="server" CssClass="form-control" Width="100%"></asp:TextBox>
                                <cc1:CalendarExtender ID="CalendarExtender1" runat="server"
                                    Enabled="True" TargetControlID="txtFromDate1">
                                </cc1:CalendarExtender>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                                    ControlToValidate="txtFromDate1" Display="Dynamic" ErrorMessage="Required!"
                                    SetFocusOnError="True" ValidationGroup="bssr"></asp:RequiredFieldValidator>
                            </div>
                        
                        <div class="col-md-4 form-group">
                                <label>To Date:<span class="required">*</span> </label>
                                <asp:TextBox ID="txtToDate1" runat="server" CssClass="form-control" Width="100%"></asp:TextBox>
                                <cc1:CalendarExtender ID="CalendarExtender2" runat="server"
                                    Enabled="True" TargetControlID="txtToDate1">
                                </cc1:CalendarExtender>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                                    ControlToValidate="txtToDate1" Display="Dynamic" ErrorMessage="Required!"
                                    SetFocusOnError="True" ValidationGroup="bssr"></asp:RequiredFieldValidator>
                            </div>
                       
                        <div class="col-md-4 form-group">
                                <label>Transfer To Branch:</label>
                                <asp:DropDownList ID="ddlBranchName1" runat="server" CssClass="form-control" Width="100%">
                                </asp:DropDownList>
                        </div>
                    </div><br />
                    <asp:Button ID="BtnBranchWiseStockRpt" runat="server" CssClass="btn btn-primary" Text="Summary Rpt" ValidationGroup="bssr" OnClientClick="return showReport_TWO();" />&nbsp;
               <asp:Button ID="Button1" runat="server" CssClass="btn btn-primary" Text="Summary Rpt" ValidationGroup="bssr" OnClientClick="return showReport_TWO();" />&nbsp;
                <asp:Button ID="BtnDetailRpt" runat="server" CssClass="btn btn-primary" Text="Detail Rpt" ValidationGroup="bssr" OnClientClick="return showReport_THREE();" />
                </div>
                </div>
           

            <div class="panel panel-default">
                <header class="panel-heading">
                  UNIT PRICE(RATE) WISE INVENTORY in 
        stock REPORT
                </header>

                <div class="panel-body">
                     <div class="row">
                        <div class="col-md-4 form-group">
                                <label>Branch Name:<span class="errormsg">*</span></label>
                                <asp:DropDownList ID="branch" runat="server" CssClass="form-control" Width="100%">
                                </asp:DropDownList>
                            </div>
                        
                        <div class="col-md-4 autocomplete-form form-group">
                                <label>Product Name:<span class="errormsg">*</span></label>
                           
                                <asp:TextBox ID="txtProduct1" runat="server" CssClass="form-control" Width="100%"
                                    AutoComplete="off"></asp:TextBox>
                                <cc1:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" DelimiterCharacters="" Enabled="true" ServicePath="~/Autocomplete.asmx"
                                    ServiceMethod="GetProductList" TargetControlID="txtProduct1" MinimumPrefixLength="1" CompletionInterval="10"
                                    EnableCaching="true" CompletionListCssClass="autocompleteTextBoxLP" OnClientItemSelected="getProduct">
                                </cc1:AutoCompleteExtender>

                                <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1"
                                    runat="server" Enabled="True" TargetControlID="txtProduct1"
                                    WatermarkCssClass="form-control" WatermarkText="Auto Complete">
                                </cc1:TextBoxWatermarkExtender>
                            </div>
                        </div><br />
                    <asp:Button ID="Btn_SeacrhUnit" runat="server" CssClass="btn btn-primary" Text="Search" OnClientClick="return showReport_FOUR();" />
                </div>
            </div>

            <div class="panel panel-default">
                <header class="panel-heading">
                   Vendor Wise Report
                </header>
                <div class="panel-body">
                    <asp:HiddenField ID="hdnVendorId" runat="server" />
                    <asp:HiddenField ID="hdnProductId1" runat="server" />
                     <div class="row">
                        <div class="col-md-4 form-group">
                                <label>Vendor Name:</label>
                                <cc1:AutoCompleteExtender ID="AutoCompleteExtender3" runat="server"
                                    DelimiterCharacters="" Enabled="true" ServicePath="~/Autocomplete.asmx" ServiceMethod="GetVendor"
                                    TargetControlID="txtVendor" MinimumPrefixLength="1" CompletionInterval="10"
                                    EnableCaching="true" CompletionListCssClass="autocompleteTextBoxLP" OnClientItemSelected="VendorOnSelected">
                                </cc1:AutoCompleteExtender>

                                <asp:TextBox ID="txtVendor" runat="server" CssClass="form-control" AutoPostBack="True" AutoComplete="Off" Width="100%"></asp:TextBox>
                                <cc1:TextBoxWatermarkExtender ID="txtVendor_TextBoxWatermarkExtender"
                                    runat="server" Enabled="True" TargetControlID="txtVendor" WatermarkCssClass="form-control" WatermarkText="Auto Complete">
                                </cc1:TextBoxWatermarkExtender>
                           
                        </div>
                        <div class="col-md-4 form-group">
                                <label>Branch Name:</label>
                                <asp:DropDownList ID="DdlBranchNameVen" runat="server" CssClass="form-control" Width="100%">
                                </asp:DropDownList>
                        </div>
                        <div class="col-md-4 autocomplete-form form-group">
                                <label>Product Name:</label>
                                <asp:TextBox ID="txtProductNameV" runat="server" CssClass="form-control" Width="100%"
                                    AutoComplete="off"></asp:TextBox>
                                <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender2"
                                    runat="server" Enabled="True" TargetControlID="txtProductNameV" WatermarkCssClass="form-control" WatermarkText="Auto Complete">
                                </cc1:TextBoxWatermarkExtender>

                                <cc1:AutoCompleteExtender ID="AutoCompleteExtender2"
                                    runat="server" CompletionInterval="10" CompletionListCssClass="autocompleteTextBoxLP" DelimiterCharacters=""
                                    Enabled="True" MinimumPrefixLength="1" OnClientItemSelected="ProductOnSelected" ServiceMethod="GetProductList"
                                    ServicePath="~/Autocomplete.asmx" TargetControlID="txtProductNameV">
                                </cc1:AutoCompleteExtender>
                        </div>
                    </div><br />
                    <asp:Button ID="BtnVendorWiseReport" runat="server" CssClass="btn btn-primary"
                        OnClick="BtnVendorWiseReport_Click" Text="Search" />
                </div>
            </div>
            </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <!--################ START FORM STYLE-->
    <script>
        function AutocompleteOnSelected(sender, e) {
            var customerValueArray = (e._value).split("|");
            document.getElementById("<%=hdnProductId.ClientID%>").value = customerValueArray[1];
        }
        function GetProductId(sender, e) {
            var customerValueArray = (e._value).split("|");
            document.getElementById("<%=product.ClientID %>").value = customerValueArray[1];
      }
      function getProduct(sender, e) {
          var customerValueArray = (e._value).split("|");
          document.getElementById("<%=hdnProduct.ClientID %>").value = customerValueArray[1];
      }
      function searchProduct() {

          childWindow = window.open("/Inventory/Item/ProductSearch.aspx", "mywindow", "menubar=0,resizable=0,width=750,height=400,align=center");
      }
      function VendorOnSelected(sender, e) {
          var customerValueArray = (e._value).split("|");
          document.getElementById("<%=hdnVendorId.ClientID %>").value = customerValueArray[1];
      }
      function ProductOnSelected(sender, e) {
          var customerValueArray = (e._value).split("|");
          document.getElementById("<%=hdnProductId1.ClientID%>").value = customerValueArray[1];

      }
      function showReport() {

          if (!Page_ClientValidate('date'))
              return false;
          var fromDate = GetDateValue("<% =txtFromDate.ClientID%>");
          var toDate = GetDateValue("<% =txtToDate.ClientID%>");

          var branch = GetValue("<% =ddlBranch.ClientID %>");
          var product = GetValue("<% =product.ClientID%>");


          var url = "/Inventory/StockDateWiseReport.aspx?From=" + fromDate +
                "&To=" + toDate +
                "&Branch=" + branch +
                "&Product=" + product;

          OpenInNewWindow(url);
          return false;

      }
      function showReport_ONE() {

          var branch = GetValue("<% =DdlBranchName.ClientID %>");
          var product = GetValue("<% =hdnProductId.ClientID%>");
          var url = "/Inventory/StockReport.aspx?Branch=" + branch +
                "&Product=" + product;

          OpenInNewWindow(url);
          return false;

      }

      function showReport_TWO() {

          if (!Page_ClientValidate('bssr'))
              return false;
          var fromDate = GetDateValue("<% =txtFromDate1.ClientID%>");
          var toDate = GetDateValue("<% =txtToDate1.ClientID%>");

          var branch = GetValue("<% =ddlBranchName1.ClientID %>");

          var url = "/Inventory/BranchWiseStockReport.aspx?from_date=" + fromDate +
                "&to_date=" + toDate +
                "&branch_id=" + branch;

          OpenInNewWindow(url);
          return false;

      }
      function showReport_THREE() {

          if (!Page_ClientValidate('bssr'))
              return false;
          var fromDate = GetDateValue("<% =txtFromDate1.ClientID%>");
          var toDate = GetDateValue("<% =txtToDate1.ClientID%>");

          var branch = GetValue("<% =ddlBranchName1.ClientID %>");

          var url = "/Inventory/transferDetailRpt.aspx?from_date=" + fromDate +
                "&to_date=" + toDate +
                "&branch_id=" + branch;

          OpenInNewWindow(url);
          return false;
      }
      function showReport_FOUR() {

          var branch = GetValue("<% =branch.ClientID %>");
          var product1 = GetValue("<%=txtProduct1.ClientID%>");
          if (product1 == "") {
              var product = "";
          }
          else {
              var product = GetValue("<% =hdnProduct.ClientID%>");
          }
          var url = "/Inventory/StockReportRateWise.aspx?Branch=" + branch +
                "&Product=" + product;

          OpenInNewWindow(url);
          return false;

      }
    </script>
</asp:Content>

