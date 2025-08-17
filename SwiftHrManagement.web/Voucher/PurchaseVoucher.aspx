<%@ Page Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true"
    CodeBehind="PurchaseVoucher.aspx.cs" Inherits="SwiftAssetManagement.Voucher.PurchaseVoucher" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%--<link href="../Css/style.css" rel="Stylesheet" type="text/css" />--%>

    <script language="javascript" type="text/javascript">
        function searchProduct() {
            childWindow = window.open("../Inventory/Item/ProductSearch.aspx", "mywindow", "menubar=0,resizable=0,width=750,height=350,align=center");
        }
    </script>
    <script type="text/javascript">
        var GB_ROOT_DIR = "greybox/";
    </script>
    <script type="text/javascript" src="greybox/AJS.js"></script>
    <script type="text/javascript" src="greybox/AJS_fx.js"></script>
    <script type="text/javascript" src="greybox/gb_scripts.js"></script>
    <%--<link href="greybox/gb_styles.css" rel="stylesheet" type="text/css" media="all" />--%>

    <%--<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    <asp:UpdatePanel ID="upd" runat="server">
        <ContentTemplate>
            <div class="row">
                <div class="col-md-12">
                      <section class="panel">
                    <header class="panel-heading">
                        <i class="fa fa-caret-right"></i>
                    Purchase Voucher Entry
                    </header>
                    <div class="panel-body">

                        <div class="form-group">
                            Check For Without VAT Purchase
                            <asp:CheckBox ID="chkVAT" runat="server" />
                        </div>
                        <div class="form-group">
                            <span class="txtlbl" nowrap="nowrap">Please Enter Valid Data!!! </span>
                            <span class="required">( * are required fields)</span>
                            <asp:Label ID="LblMsg" runat="server"></asp:Label>
                            <asp:HiddenField ID="hdnVendorId" runat="server" />
                            <asp:TextBox ID="hdnProductId" runat="server" Visible="false"></asp:TextBox>
                        </div>
                        <div class="row">
                            <div class="col-md-4">
                                <div class="form-group autocomplete-form">
                                    <label>Vendor Name:</label>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" Width="100%"
                                        runat="server" ControlToValidate="vendor"
                                        Display="Dynamic"
                                        ErrorMessage="Required!"
                                        SetFocusOnError="True" ValidationGroup="purchase"></asp:RequiredFieldValidator>
                                    <cc1:AutoCompleteExtender ID="AutoCompleteExtender3" runat="server"
                                        CompletionInterval="10" CompletionListCssClass="autocompleteTextBoxLP" DelimiterCharacters=""
                                        EnableCaching="true" Enabled="true" MinimumPrefixLength="1"
                                        ServiceMethod="GetVendor" ServicePath="~/Autocomplete.asmx"
                                        TargetControlID="vendor">
                                    </cc1:AutoCompleteExtender>
                                    <asp:TextBox ID="vendor" runat="server" AutoPostBack="True"
                                        CssClass="form-control"
                                        AutoComplete="off"
                                        OnTextChanged="vendor_TextChanged"></asp:TextBox>
                                    <cc1:TextBoxWatermarkExtender ID="vendor_TextBoxWatermarkExtender"
                                        runat="server" Enabled="True"
                                        TargetControlID="vendor" WatermarkCssClass="watermark"
                                        WatermarkText="Auto Complete">
                                    </cc1:TextBoxWatermarkExtender>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-3">
                                <div class="form-group autocomplete-form">
                                    <label>Product Code:</label>
                                    <asp:RequiredFieldValidator ID="rfv" runat="server" Width="100%"
                                        ControlToValidate="txtProduct"
                                        Display="None" ErrorMessage="*"
                                        SetFocusOnError="True"
                                        ValidationGroup="add"></asp:RequiredFieldValidator>
                                    <cc1:AutoCompleteExtender
                                        ID="ACproduct" runat="server" CompletionInterval="10"
                                        CompletionListCssClass="autocompleteTextBoxLP"
                                        DelimiterCharacters=""
                                        EnableCaching="true"
                                        Enabled="true" MinimumPrefixLength="1"
                                        ServiceMethod="GetVendorProductList"
                                        ServicePath="~/Autocomplete.asmx"
                                        TargetControlID="txtProduct">
                                    </cc1:AutoCompleteExtender>
                                    <asp:TextBox ID="txtProduct"
                                        runat="server" AutoComplete="off"
                                        CssClass="form-control"
                                        AutoPostBack="true"
                                        OnTextChanged="txtProduct_TextChanged"></asp:TextBox>
                                    <cc1:TextBoxWatermarkExtender ID="txtProduct_TextBoxWatermarkExtender0"
                                        runat="server" Enabled="True"
                                        TargetControlID="txtProduct"
                                        WatermarkCssClass="watermark"
                                        WatermarkText="Auto Complete">
                                    </cc1:TextBoxWatermarkExtender>
                                </div>
                            </div>

                            <div class="col-md-2">
                                <div class="form-group">
                                    <label>Pck Unit:</label>
                                    <asp:TextBox ID="txtUnit" runat="server" CssClass="form-control" name="unit" Width="100%"
                                        Enabled="false"></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-2">

                                <div class="form-group">
                                    <label>Qty:</label>
                                    <asp:TextBox ID="qty" runat="server" CssClass="form-control" name="qty" Width="100%"></asp:TextBox>
                                </div>
                            </div>


                            <div class="col-md-2">

                                <div class="form-group">
                                    <label>Rate:</label>
                                    <asp:TextBox ID="unitprice" runat="server" CssClass="form-control" Width="100%"
                                        name="unitprice" size="7" OnTextChanged="unitprice_TextChanged"></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-2">

                                <div class="form-group">
                                    <label>Amount:</label>
                                    <asp:TextBox ID="amount" runat="server" CssClass="form-control" size="10" Width="100%"
                                        AutoPostBack="True" OnTextChanged="amount_TextChanged"></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-1" align="right">
                                <label>&nbsp;</label>
                                <div class="form-group">
                                    <asp:Button ID="BtnAdd" runat="server" CssClass="btn btn-primary" OnClick="BtnAdd_Click" 
                                        Text="Add" />
                                </div>

                            </div>
                        </div>
                        <div class="form-group">
                            <div id="rpt" runat="server">
                            </div>
                        </div>
                            <div class="form-group">

                                <asp:Button ID="BtnDelProduct" runat="server" CssClass="btn btn-primary"
                                    OnClick="BtnDelProduct_Click"
                                    Text="Delete" />
                                <cc1:ConfirmButtonExtender
                                    ID="BtnDelProduct_ConfirmButtonExtender"
                                    runat="server" ConfirmText="Confirm To Delete ?"
                                    Enabled="True"
                                    TargetControlID="BtnDelProduct">
                                </cc1:ConfirmButtonExtender>
                            </div>
                           <br />
                            <label>Payment Method (Account Information):</label>
                            <div class="row">
                                <div class="col-md-5">
                                    <div class="form-group  autocomplete-form">
                                        <label>Account: <span id="spn_available">( 0 )</span></label>
                                        <input id="ac_type" name="ac_type"
                                            type="hidden">
                                            <asp:RequiredFieldValidator ID="rfc" runat="server" Width="100%"
                                                ControlToValidate="TxtAc_Name" Display="None" ErrorMessage="*"
                                                SetFocusOnError="True" ValidationGroup="addaccount"></asp:RequiredFieldValidator>
                                        </input>
                                        <cc1:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server"
                                            CompletionInterval="10" CompletionListCssClass="autocompleteTextBoxLP"
                                            DelimiterCharacters="" EnableCaching="true" Enabled="true" MinimumPrefixLength="1"
                                            ServiceMethod="GetAccountList" ServicePath="~/Autocomplete.asmx"
                                            TargetControlID="TxtAc_Name">
                                        </cc1:AutoCompleteExtender>
                                        <asp:TextBox ID="TxtAc_Name" runat="server" AutoComplete="off" CssClass="form-control"></asp:TextBox>
                                        <cc1:TextBoxWatermarkExtender ID="TxtAc_Name_TextBoxWatermarkExtender" runat="server"
                                            Enabled="True" TargetControlID="TxtAc_Name"
                                            WatermarkCssClass="watermark" WatermarkText="Auto Complete">
                                        </cc1:TextBoxWatermarkExtender>
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="form-group">
                                       <label> Type:</label>
                                        <asp:RequiredFieldValidator ID="rfc1" runat="server"
                                            ControlToValidate="ac_amt"
                                            Display="None" ErrorMessage="*" InitialValue="0"
                                            SetFocusOnError="True"
                                            ValidationGroup="addaccount"></asp:RequiredFieldValidator>
                                        <div id="Div1" align="center" name="batinf">
                                        </div>
                                        <div class="form-group">
                                            <asp:DropDownList ID="DdlType" runat="server" CssClass="form-control" Width="100%">
                                                <asp:ListItem Selected="True" Value="cr">CR</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label>Amount:</label>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                                            ControlToValidate="ac_amt" Display="None" ErrorMessage="*" InitialValue="0"
                                            SetFocusOnError="True"
                                            ValidationGroup="addaccount"></asp:RequiredFieldValidator>
                                        <asp:TextBox ID="ac_amt" runat="server" CssClass="form-control" size="15" Width="100%"
                                            value="0"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="col-md-1" align="right"">
                                    <div class="form-group">
                                        <label>&nbsp;</label><br />
                                        <asp:Button ID="BtnAddAcc"
                                            runat="server" CssClass="btn btn-primary" OnClick="BtnAddAcc_Click"
                                            Text=" Add " ValidationGroup="addaccount" />
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="form-group">
                                        <div id="rpt1" runat="server">
                                        </div>
                                    </div>
                                </div>
                            </div>
                           <div class="row">
                               <div class="col-md-12">
                                   <asp:Button ID="BtnDeleteAcc" runat="server" CssClass="btn btn-primary" 
                                            OnClick="BtnDeleteAcc_Click" Text="Delete" />
                                        <cc1:ConfirmButtonExtender
                                            ID="BtnDeleteAcc_ConfirmButtonExtender"
                                            runat="server" ConfirmText="Confirm To Delete ?"
                                            Enabled="True"
                                            TargetControlID="BtnDeleteAcc">
                                        </cc1:ConfirmButtonExtender>
                           </div>
                               </div>
                                        
                           <br />
                                   

                            <div class="row">
                                <div class="col-md-12">
                                     <label>Bill information:</label>
                            </div>
                                </div>
                            <div class="row">
                                <div class="col-md-4">
                                   
                                    <div class="form-group">
                                        <label>Bill No. : <span class="required">*</span></label>
                                        <asp:TextBox ID="billno"
                                            runat="server" CssClass="form-control" name="billno" Width="100%"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfv3" runat="server" ControlToValidate="billno"
                                            Display="Dynamic" SetFocusOnError="True" ValidationGroup="purchase"
                                            ErrorMessage="Required!"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <label>Bill Date : <span class="required">*</span></label>
                                        <asp:TextBox ID="billDate"
                                            runat="server" CssClass="form-control" Width="100%"></asp:TextBox>

                                        <cc1:CalendarExtender ID="billDate_CalendarExtender" runat="server"
                                            Enabled="True" TargetControlID="billDate">
                                        </cc1:CalendarExtender>
                                        <asp:RequiredFieldValidator
                                            ID="rfv4" runat="server"
                                            ControlToValidate="billDate"
                                            Display="Dynamic" SetFocusOnError="True"
                                            ValidationGroup="purchase"
                                            ErrorMessage="Required!"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="form-group">
                                        <label>Remarks:<span class="required">*</span></label>
                                        <asp:RequiredFieldValidator
                                            ID="rfv6" runat="server"
                                            ControlToValidate="remarks"
                                            Display="Dynamic" SetFocusOnError="True"
                                            ValidationGroup="purchase"
                                            ErrorMessage="Required!"></asp:RequiredFieldValidator>
                                        <asp:TextBox ID="remarks"
                                            runat="server" CssClass="form-control" Width="100%"
                                            TextMode="MultiLine"></asp:TextBox>
                                    </div>
                                </div>
                                  </div>

                                        <asp:Button ID="BtnSave" runat="server" CssClass="btn btn-primary"
                                            OnClick="BtnSave_Click" Text="Save Voucher" ValidationGroup="purchase" />
                                        <cc1:ConfirmButtonExtender ID="BtnSave_ConfirmButtonExtender"
                                            runat="server"
                                            ConfirmText="Confirm To Save ?" Enabled="True"
                                            TargetControlID="BtnSave">
                                        </cc1:ConfirmButtonExtender>
                                        <asp:Button ID="BtnDelete" runat="server" CssClass="btn btn-primary" OnClick="BtnDelete_Click"
                                            Text="Refresh" />
                                   
                          
                        </div>
                    </div>
                    </section>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

    <script language="javascript" type="text/javascript">

        function searchProduct() {

            childWindow = window.open("../Inventory/Item/ProductSearch.aspx", "mywindow", "menubar=0,resizable=0,width=750,height=400,align=center");
        }
        function addOther(str) {

            var URL = "/Voucher/AddOtherInfo.aspx?Id=" + str;
            GB_show("Add Prodcut Information ", URL, 400, 800);
        }

        function CalculateTotal() {

            if (document.getElementById("<%=qty.ClientID%>").value != "" && document.getElementById("<%=unitprice.ClientID%>").value != "") {
                var amount = parseFloat(document.getElementById("<%=qty.ClientID%>").value) * parseFloat(document.getElementById("<%=unitprice.ClientID %>").value);
                document.getElementById("<%=amount.ClientID %>").value = amount.toFixed(2);
            }
        }
    </script>

</asp:Content>
