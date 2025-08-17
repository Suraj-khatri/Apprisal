<%@ Page Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true"
    CodeBehind="PurchaseOrder.aspx.cs" Inherits="SwiftAssetManagement.Voucher.PurchaseOrder" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script language="javascript">
        function AutocompleteOnSelected(sender, e) {

            var EmpIdArray = (e._value).split("|");
            document.getElementById("<%=hdnProductId.ClientID%>").Value = EmpIdArray[1];

        }
        function GetEmpID(sender, e) {

            var EmpIdArray = (e._value).split("|");
            document.getElementById("<%=hdnEmpId.ClientID%>").Value = EmpIdArray[1];
        }
        function searchProduct() {

            childWindow = window.open("../Inventory/Item/ProductSearch.aspx", "mywindow", "menubar=0,resizable=0,width=750,height=350,align=center");
        }

        function VendorOnSelected(sender, e) {

            var EmpIdArray = (e._value).split("|");
            document.getElementById("<%=hdnVendorId.ClientID%>").Value = EmpIdArray[1];

        }

        function CalculateTotal() {

            if (document.getElementById("<%=txtQty.ClientID %>").value != "" && document.getElementById("<%= txtRate.ClientID%>").value != "") {
                var amount = parseFloat(document.getElementById("<%=txtQty.ClientID %>").value) * parseFloat(document.getElementById("<%= txtRate.ClientID%>").value);
                document.getElementById("<%=txtAmount.ClientID %>").value = amount.toFixed(2);

            }
        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    <input type="hidden" id="ac_type" name="ac_type" class="form-control">
    <asp:UpdatePanel ID="updp" runat="server">
        <ContentTemplate>
            <div class="row">
                <div class="col-md-10 col-md-offset-1">
                    <section class="panel">
                    <header class="panel-heading">
                        <i class="fa fa-caret-right"></i>
                          Request Purchase Order
                        </header>
                    <div class="panel-body">
                        <div class="form-group">
                            Purchase order entry
                            <asp:Label ID="LblMsg" runat="server"></asp:Label>
                            <asp:HiddenField ID="hdnProductId" runat="server" />
                            <asp:HiddenField ID="hdnVendorId" runat="server" />
                            <asp:HiddenField ID="hdnVat" runat="server" />
                            <asp:HiddenField ID="hdnEmpId" runat="server" />
                            <label>Check For Without VAT  PO</label>
                            <asp:CheckBox ID="chkVAT" runat="server" />
                        </div>
                        <label>Product Information:</label>
                         <div class="row">
                            <div class=" col-md-6 form-group autocomplete-form">
                                <label>Vendor Name:</label>
                                <cc1:AutoCompleteExtender ID="AutoCompleteExtender3" runat="server"
                                    DelimiterCharacters="" Enabled="true" ServicePath="~/Autocomplete.asmx" ServiceMethod="GetVendor"
                                    TargetControlID="txtVendor" MinimumPrefixLength="1" CompletionInterval="10"
                                    EnableCaching="true" CompletionListCssClass="autocompleteTextBoxLP" OnClientItemSelected="VendorOnSelected">
                                </cc1:AutoCompleteExtender>

                                <asp:TextBox ID="txtVendor" runat="server" 
                                    AutoPostBack="True" AutoComplete="off"
                                    OnTextChanged="txtVendor_TextChanged" CssClass="form-control"></asp:TextBox>
                                <cc1:TextBoxWatermarkExtender ID="txtVendor_TextBoxWatermarkExtender"
                                 runat="server" Enabled="True" TargetControlID="txtVendor"
                                    WatermarkCssClass="watermark" WatermarkText="Auto Complete">
                                </cc1:TextBoxWatermarkExtender>
                            </div>
                        </div>
                        <div class="row">
                            <div class=" col-md-3 form-group autocomplete-form">
                                <label>Product Name:</label>
                                <asp:TextBox ID="txtProduct" runat="server"  AutoComplete="off"
                                    CssClass="form-control" AutoPostBack="True"
                                    OnTextChanged="txtProduct_TextChanged"></asp:TextBox>
                                <cc1:AutoCompleteExtender ID="txtProduct_AutoCompleteExtender" runat="server"
                                    DelimiterCharacters="" Enabled="true" ServicePath="~/Autocomplete.asmx" ServiceMethod="GetVendorProductList"
                                    TargetControlID="txtProduct" MinimumPrefixLength="1" CompletionInterval="10"
                                    EnableCaching="true" CompletionListCssClass="autocompleteTextBoxLP"
                                    OnClientItemSelected="AutocompleteOnSelected">
                                </cc1:AutoCompleteExtender>

                                <cc1:TextBoxWatermarkExtender ID="txtProduct_TextBoxWatermarkExtender"
                                    runat="server" Enabled="True" TargetControlID="txtProduct"
                                    WatermarkCssClass="watermark" WatermarkText="Auto Complete">
                                </cc1:TextBoxWatermarkExtender>
                            </div>
                            <div class="col-md-2 form-group">
                                <label>Unit:</label>
                                <asp:TextBox ID="txtUnit" name="qty"  runat="server"
                                    CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="col-md-2 form-group">
                                <label>Qty:</label>
                                <asp:TextBox ID="txtQty" name="qty"  runat="server"
                                    CssClass="form-control" AutoPostBack="True"></asp:TextBox>
                            </div>
                            <div class="col-md-2 form-group">
                                <label>Rate:</label>
                                <asp:TextBox ID="txtRate" name="txtRate"  runat="server" AutoPostBack="True" CssClass="form-control" > </asp:TextBox>
                            </div>
                            <div class=" col-md-2 form-group">
                                <label>Amount:</label>
                                <asp:TextBox ID="txtAmount" runat="server" CssClass="form-control"
                                    OnTextChanged="txtAmount_TextChanged"></asp:TextBox>
                            </div>
                            <div class="form-group col-md-1">
                                <label>&nbsp;</label>
                                <asp:Button ID="BtnAdd" runat="server" CssClass="btn btn-primary" Text="Add"
                                    OnClick="BtnAdd_Click" />
                            </div>
                        </div>
                        <div id="rpt" runat="server"></div>
               
                        <div class="form-group">
                        <asp:Button ID="BtnDelProduct" runat="server" Text="Delete" CssClass="btn btn-primary"
                            OnClick="BtnDelProduct_Click" />
                            </div>

                            <label>Order Information:</label>
                        <div class="row">
                            <div class="col-md-4 form-group autocomplete-form">
                                <label>Order Date: </label>
                                <asp:RequiredFieldValidator ID="rfc2" runat="server"
                                    ControlToValidate="txtOrderDate" Display="Dynamic"
                                    ErrorMessage="Required!" SetFocusOnError="True"
                                    ValidationGroup="order"></asp:RequiredFieldValidator><br />
                                <asp:TextBox ID="txtOrderDate" runat="server" CssClass="form-control"></asp:TextBox>
                                <cc1:CalendarExtender ID="txtOrderDate_CalendarExtender" runat="server"
                                    Enabled="True" TargetControlID="txtOrderDate">
                                </cc1:CalendarExtender>
                            </div>
                            <div class=" col-md-4 form-group autocomplete-form">
                                <label>Forwarded For Approval To:<span class="errormsg">*</span></label>
                                <asp:RequiredFieldValidator ID="rfc1"
                                    runat="server" ControlToValidate="forwardedto" Display="Dynamic"
                                    ErrorMessage="Required!" SetFocusOnError="True" ValidationGroup="order"></asp:RequiredFieldValidator>

                                <cc1:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server"
                                    DelimiterCharacters="" Enabled="true" ServicePath="~/Autocomplete.asmx" ServiceMethod="GetEmployeeList"
                                    TargetControlID="forwardedto" MinimumPrefixLength="1" CompletionInterval="10"
                                    EnableCaching="true" CompletionListCssClass="autocompleteTextBoxLP"
                                    OnClientItemSelected="GetEmpID">
                                </cc1:AutoCompleteExtender>

                                <asp:TextBox ID="forwardedto" runat="server" 
                                    CssClass="form-control" AutoComplete="off"></asp:TextBox>

                                <cc1:TextBoxWatermarkExtender ID="forwardedto_TextBoxWatermarkExtender"
                                    runat="server" Enabled="True" TargetControlID="forwardedto"
                                    WatermarkCssClass="watermark" WatermarkText="Auto Complete">
                                </cc1:TextBoxWatermarkExtender>
                            </div>
                            <div class=" col-md-4 form-group">
                                <label>Last Date of Delivery:</label>
                                <asp:TextBox ID="txtDeliveryDate" runat="server" CssClass="form-control"></asp:TextBox>
                                <cc1:CalendarExtender ID="CalendarExtender2" runat="server"
                                    TargetControlID="txtDeliveryDate">
                                </cc1:CalendarExtender>
                            </div>
                            </div>
                        <label>PO Notes:</label>
                        <div class="form-group">
                            <asp:TextBox ID="txtNotes" CssClass="form-control" runat="server" 
                                 TextMode="MultiLine" Text="Please state P.O. No. in your delivery challan and invoice.~
                                          The Bank reserves the right to reject the items delivered beyond the delivery period mentioned above.~
                                          The Bank reserves the right to reject the items delivered that do not match the sample provided with Bid or 
                                          do not match the quality standard."></asp:TextBox>

                        </div>
                        <div class="form-group">
                            <label>PO Specification:</label>
                            <asp:TextBox ID="txtSpecification" CssClass="form-control" runat="server" 
                                 TextMode="MultiLine"></asp:TextBox>

                        </div>
                        <div class="form-group">

                            <asp:Button ID="BtnSave" runat="server" Text="Save Order" CssClass="btn btn-primary"
                                OnClick="BtnSave_Click" ValidationGroup="order" />

        <cc1:ConfirmButtonExtender ID="btnSave_ConfirmButtonExtender" runat="server"
            ConfirmText="Confirm To Save?" Enabled="True" TargetControlID="BtnSave">
        </cc1:ConfirmButtonExtender>

                            <asp:Button ID="BtnDelete" runat="server" Text="Refresh"
                                CssClass="btn btn-primary" OnClick="BtnDelete_Click" />
                        </div>
                </div>
            </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>


