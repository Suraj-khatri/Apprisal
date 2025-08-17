<%@ Page Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="DisposalVoucher.aspx.cs" Inherits="SwiftHrManagement.web.Voucher.DisposalVoucher" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        var GB_ROOT_DIR = "./greybox/";
    </script>
    <style type="text/css">
        .form-inline .form-control {
            margin-bottom: 5px !important;
        }
    </style>
    <script type="text/javascript" src="greybox/AJS.js"></script>
    <script type="text/javascript" src="greybox/AJS_fx.js"></script>
    <script type="text/javascript" src="greybox/gb_scripts.js"></script>
    <link href="greybox/gb_styles.css" rel="stylesheet" type="text/css" media="all" />
    <script language="javascript" type="text/javascript">

        function AutocompleteOnSelected(sender, e) {
            var customerValueArray = (e._value).split("|");
            document.getElementById("<%=hdnProductId.ClientID %>").value = customerValueArray[1];
        }
        function searchProduct() {

            childWindow = window.open("../Inventory/Item/ProductSearch.aspx", "mywindow", "menubar=0,resizable=0,width=750,height=400,align=center");
        }
        function addOther(str) {

            var URL = "/Voucher/AddOtherDisposalInfo.aspx?Id=" + str;
            GB_show("Disposal Other nformation ", URL, 400, 800);
        }
        function SearchRate() {

            if (document.getElementById("<%=qty.ClientID %>").value != "" && document.getElementById("<%=hdnProductId.ClientID %>").value != "") {
                data = window.showModalDialog("/Voucher/ViewRate.aspx?prod_code=" + document.getElementById("<%=hdnProductId.ClientID %>").value + "&qty=" + document.getElementById("<%=qty.ClientID %>").value, window.self, "");
                var dataList = data.split("|");
                document.getElementById("<%=unitprice.ClientID %>").value = dataList[1];
                document.getElementById("<%=hdnPurId.ClientID %>").value = dataList[0];
            }
        }
        function CalculateTotal() {

            if (document.getElementById("<%=qty.ClientID%>").value != "" && document.getElementById("<%=unitprice.ClientID%>").value != "") {
                var amount = parseFloat(document.getElementById("<%=qty.ClientID%>").value) * parseFloat(document.getElementById("<%=unitprice.ClientID %>").value);
                document.getElementById("<%=amount.ClientID %>").value = amount.toFixed(4);
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">

    <asp:UpdatePanel ID="upd" runat="server">
        <ContentTemplate>
            <asp:HiddenField ID="hdnPurId" runat="server"></asp:HiddenField>
            <div class="panel">
                <header class="panel-heading">
                    <i class="fa fa-caret-right"></i>
                    Disposal Voucher Entry
                </header>
                <div class="panel panel-default">
                    <div class="panel-body">
                        <div class="form-group">
                            Please Enter Valid Data!!<span class="required">( * are required fields)</span>
                            <asp:Label ID="LblMsg" runat="server"></asp:Label>
                            <asp:HiddenField ID="hdnProductId" runat="server" />
                        </div>
                        <div class="row">
                            <div class="col-md-5 form-group autocomplete-form">
                                <label>Product Code:</label>
                                <div class="input-group">
                                    <asp:RequiredFieldValidator ID="rfv" runat="server"
                                        ControlToValidate="txtProduct" Display="None" ErrorMessage="*"
                                        SetFocusOnError="True" ValidationGroup="add"></asp:RequiredFieldValidator>
                                    <asp:TextBox ID="txtProduct" runat="server" CssClass="form-control" Width="100%"></asp:TextBox>
                                    <cc1:AutoCompleteExtender ID="AutoCompleteExtender4" runat="server"
                                        DelimiterCharacters="" Enabled="true" ServicePath="~/Autocomplete.asmx" ServiceMethod="GetProductList"
                                        TargetControlID="txtProduct" MinimumPrefixLength="1" CompletionInterval="10"
                                        EnableCaching="true" CompletionListCssClass="autocompleteTextBoxLP"
                                        OnClientItemSelected="AutocompleteOnSelected">
                                    </cc1:AutoCompleteExtender>
                                    <cc1:TextBoxWatermarkExtender ID="txtProduct_TextBoxWatermarkExtender0"
                                        runat="server" Enabled="True" TargetControlID="txtProduct"
                                        WatermarkCssClass="form-control" WatermarkText="Auto Complete">
                                    </cc1:TextBoxWatermarkExtender>
                                    <div class="input-group-addon"><i class="fa fa-search" aria-hidden="true" style="cursor: pointer;" onclick="searchProduct();"></i></div>
                                </div>
                            </div>
                            <div class="col-md-2 form-group">
                                <label>Qty:</label>
                                <asp:TextBox ID="qty" name="qty" runat="server" CssClass="form-control" OnTextChanged="qty_TextChanged" Width="100%"></asp:TextBox>
                            </div>
                            <div class="col-md-2 form-group">
                                <label>Rate:</label>
                                <div class="input-group">
                                    <asp:TextBox ID="unitprice" name="unitprice" runat="server" CssClass="form-control" Width="100%"></asp:TextBox>
                                    <div class="input-group-addon"><i class="fa fa-search" aria-hidden="true" style="cursor: pointer;" onclick="SearchRate()"></i></div>
                                </div>
                            </div>
                            <div class="col-md-2 form-group">
                                <label>Amount:</label>
                                <asp:TextBox ID="amount" runat="server" size="10" CssClass="form-control" Width="100%"></asp:TextBox>
                            </div>

                            <div class="col-md-1 form-group">
                                <label>&nbsp;</label><br />
                                <asp:Button ID="BtnAdd" runat="server" CssClass="btn btn-primary" Text="Add" OnClick="BtnAdd_Click" />
                                <cc1:ConfirmButtonExtender ID="BtnDelProduct_ConfirmButtonExtender0"
                                    runat="server" ConfirmText="Confirm To Delete ?" Enabled="True"
                                    TargetControlID="BtnDelProduct">
                                </cc1:ConfirmButtonExtender>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-12">
                                <div id="rpt" runat="server"></div>
                                <div class="col-md-12" align="right">
                                    <asp:Button ID="BtnDelProduct" runat="server" Text="Delete" CssClass="btn btn-primary" align="right" />
                                </div>
                            </div>
                        </div>

                    </div>

                    <div class="panel panel-default">
                        <header class="panel-heading">
                       Expense Method (Account Information):
                         </header>
                        <div class="panel-body">
                            <div class="row">
                                <div class="col-md-5 autocomplete-form form-group">
                                    <label>
                                        Account: <span id="spn_available">( 0 )</span>
                                        <input type="hidden" id="ac_type" name="ac_type"></label>
                                    <asp:RequiredFieldValidator ID="rfc" runat="server"
                                        ControlToValidate="TxtAc_Name" Display="None" ErrorMessage="*"
                                        SetFocusOnError="True" ValidationGroup="addaccount">
                                    </asp:RequiredFieldValidator>
                                    <cc1:AutoCompleteExtender ID="AutoCompleteExtender5" runat="server"
                                        DelimiterCharacters="" Enabled="true" ServicePath="~/Autocomplete.asmx" ServiceMethod="GetAccountList"
                                        TargetControlID="TxtAc_Name" MinimumPrefixLength="1" CompletionInterval="10"
                                        EnableCaching="true" CompletionListCssClass="autocompleteTextBoxLP">
                                    </cc1:AutoCompleteExtender>
                                    <cc1:TextBoxWatermarkExtender ID="TxtAc_Name_TextBoxWatermarkExtender0"
                                        runat="server" Enabled="True" TargetControlID="TxtAc_Name"
                                        WatermarkCssClass="form-control" WatermarkText="Auto Complete">
                                    </cc1:TextBoxWatermarkExtender>
                                    <asp:TextBox ID="TxtAc_Name" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="col-md-3 form-group">
                                    <label>Type:</label>
                                    <asp:DropDownList ID="DdlType" runat="server" CssClass="form-control">
                                        <asp:ListItem Value="dr" Selected="True">DR</asp:ListItem>
                                        <asp:ListItem Value="cr">CR</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="col-md-3 form-group">
                                    <label>Amount:</label>
                                    <asp:TextBox ID="ac_amt" value="0" size="15" runat="server" CssClass="form-control">
                                    </asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfc1" runat="server" ControlToValidate="ac_amt" Display="None" ErrorMessage="*"
                                        SetFocusOnError="True" ValidationGroup="addaccount" InitialValue="0">
                                    </asp:RequiredFieldValidator>
                                </div>
                                <div class="col-md-1 form-group">
                                    <label>&nbsp;</label><br />
                                    <asp:Button ID="BtnAddAcc" Text=" Add " CssClass="btn btn-primary" runat="server"
                                        OnClick="BtnAddAcc_Click" ValidationGroup="addaccount"></asp:Button>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-12">
                                    <div id="rpt1" runat="server"></div>
                                    <div class="col-md-12" align="right">
                                        <asp:Button ID="BtnDeleteAcc" runat="server" Text="Delete" CssClass="btn btn-primary" align="right"
                                            OnClick="BtnDeleteAcc_Click" />
                                        <cc1:ConfirmButtonExtender ID="BtnDeleteAcc_ConfirmButtonExtender0"
                                            runat="server" ConfirmText="Confirm To Delete ?" Enabled="True"
                                            TargetControlID="BtnDeleteAcc">
                                        </cc1:ConfirmButtonExtender>
                                    </div>
                                </div>
                            </div>

                        </div>
                    </div>
                </div>

                <div class="panel panel-default">
                    <header class="panel-heading">
                           Disposal information:
                          </header>
                    <div class="panel-body">
                        <div class="row">
                            <div class="col-md-4 form-group">
                                <label>Approval No:</label>
                                <asp:TextBox name="billno" ID="billno" runat="server" CssClass="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfv3" runat="server" ControlToValidate="billno" Display="None" SetFocusOnError="True"
                                    ValidationGroup="purchase">
                                </asp:RequiredFieldValidator>
                            </div>
                            <div class="col-md-4 form-group">
                                <label>Disposal Date:</label>
                                <asp:TextBox ID="billDate" runat="server" CssClass="form-control">
                                </asp:TextBox>
                                <cc1:CalendarExtender ID="billDate_CalendarExtender0" runat="server"
                                    Enabled="True" TargetControlID="billDate">
                                </cc1:CalendarExtender>
                                <asp:RequiredFieldValidator ID="rfv4" runat="server"
                                    ControlToValidate="billDate" Display="None" SetFocusOnError="True"
                                    ValidationGroup="purchase">
                                </asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-12 form-group">
                                <label>Remarks:</label>
                                <asp:RequiredFieldValidator ID="rfv6" runat="server"
                                    ControlToValidate="remarks" Display="None" SetFocusOnError="True"
                                    ValidationGroup="purchase"></asp:RequiredFieldValidator>
                                <asp:TextBox ID="remarks" runat="server" CssClass="form-control"
                                    TextMode="MultiLine" Width="48%"></asp:TextBox>
                            </div>
                        </div>
               
                        <asp:Button ID="BtnSave" runat="server" Text="Save Voucher" CssClass="btn btn-primary"
                            OnClick="BtnSave_Click" ValidationGroup="purchase" />
                        <cc1:ConfirmButtonExtender ID="BtnSave_ConfirmButtonExtender0" runat="server"
                            ConfirmText="Confirm To Save ?" Enabled="True" TargetControlID="BtnSave">
                        </cc1:ConfirmButtonExtender>
                        <asp:Button ID="BtnDelete" runat="server" Text="Refresh" CssClass="btn btn-primary" OnClick="BtnDelete_Click" />

                    </div>
                </div>
            </div>
            </div>
            </div>
        </ContentTemplate>

    </asp:UpdatePanel>

</asp:Content>


