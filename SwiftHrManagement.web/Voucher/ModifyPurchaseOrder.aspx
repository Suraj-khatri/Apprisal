<%@ Page Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true"
    CodeBehind="ModifyPurchaseOrder.aspx.cs" Inherits="SwiftAssetManagement.Voucher.ModifyPurchaseOrder" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script language="javascript">

        function AutocompleteOnSelected(sender, e) {
            var customerValueArray = (e._value).split("|");
            document.getElementById("hdnProductId").value = customerValueArray[1];

        }
        function searchProduct() {

            childWindow = window.open("../Inventory/Item/ProductSearch.aspx", "mywindow", "menubar=0,resizable=0,width=750,height=350,align=center");
        }

        function CalculateTotal() {

            if (document.getElementById("<%=txtQty.ClientID %>").value != "" && document.getElementById("<%= txtRate.ClientID%>").value != "") {
            var amount = parseFloat(document.getElementById("<%=txtQty.ClientID %>").value) * parseFloat(document.getElementById("<%= txtRate.ClientID%>").value);
            document.getElementById("<%=txtAmount.ClientID %>").value = amount.toFixed(2);

        }

        function GetEmpID(sender, e) {

            var EmpIdArray = (e._value).split("|");
            document.getElementById("<%=hdnEmpId.ClientID%>").Value = EmpIdArray[1];
        }
    }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    <asp:UpdatePanel ID="updp" runat="server">
        <ContentTemplate>
            <div class="row">
                <div class="col-md-10 col-lg-offset-1">
                    <section class="panel">
                    <header class="panel-heading">
                        <i class="fa fa-caret-right"></i>
                         Modify Purchase Order
                        </header>
                    <div class="panel-body">
                    <div class="row">
                        <div class="col-md-12">
                            <div class="form-group">
                                Modify Purchase order
                        <asp:Label ID="LblMsg" runat="server"></asp:Label>
                                <asp:HiddenField ID="hdnProductId" runat="server" />
                                <asp:HiddenField ID="hdnVendorId" runat="server" />
                                <asp:HiddenField ID="hdnVat" runat="server" />
                                <asp:HiddenField ID="hdnEmpId" runat="server" />
                                <label>Check For Without VAT  PO</label>
                                <asp:CheckBox ID="chkVAT" runat="server" />
                            </div>
                        </div>
                    </div>
                        
                        <label>Product Information:</label>
                         <div class="row">
                            <div class="col-md-6">
                        <div class="  form-group autocomplete-form">
                            <label>Vendor Name:</label>
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtVendor" 
                                 Display="Dynamic" ErrorMessage="Required!" SetFocusOnError="True" ValidationGroup="order">
                             </asp:RequiredFieldValidator>                            
                            <cc1:AutoCompleteExtender ID="AutoCompleteExtender3" runat="server" 
                                CompletionInterval="10" CompletionListCssClass="autocompleteTextBoxLP" 
                                DelimiterCharacters="" EnableCaching="true" Enabled="true" 
                                MinimumPrefixLength="1" ServiceMethod="GetVendor" 
                                ServicePath="~/Autocomplete.asmx" TargetControlID="txtVendor">
                            </cc1:AutoCompleteExtender>
                            <asp:TextBox ID="txtVendor" runat="server" AutoPostBack="True" 
                                CssClass="form-control" AutoComplete="off" 
                                ontextchanged="txtVendor_TextChanged"></asp:TextBox>
                            <cc1:TextBoxWatermarkExtender ID="txtVendor_TextBoxWatermarkExtender" 
                                runat="server" Enabled="True" TargetControlID="txtVendor" 
                                WatermarkCssClass="form-control" WatermarkText="Auto Complete">
                            </cc1:TextBoxWatermarkExtender>
                             </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class=" col-md-5 form-group autocomplete-form">
                            <label>Product Name:</label>
                              <asp:TextBox ID="txtProduct" runat="server" AutoComplete="off" CssClass="form-control" AutoPostBack="True" 
                                  ontextchanged="txtProduct_TextChanged"></asp:TextBox> 
                            <cc1:AutoCompleteExtender ID="txtProduct_AutoCompleteExtender" runat="server"
                                DelimiterCharacters="" Enabled="true" ServicePath="~/Autocomplete.asmx" ServiceMethod="GetVendorProductList"
                                TargetControlID="txtProduct" MinimumPrefixLength="1" CompletionInterval="10"
                                EnableCaching="true" CompletionListCssClass="autocompleteTextBoxLP">
                            </cc1:AutoCompleteExtender>               
                            <cc1:TextBoxWatermarkExtender ID="txtProduct_TextBoxWatermarkExtender" 
                                runat="server" Enabled="True" TargetControlID="txtProduct" 
                                WatermarkCssClass="form-control" WatermarkText="Auto Complete">
                            </cc1:TextBoxWatermarkExtender>                                   
						  </div>
                        <div class="col-md-2 form-group">
                            <label>Qty:</label>
                             <asp:TextBox id="txtQty" name="qty" size="10" runat="server" 
                        CssClass="form-control" AutoPostBack="True"></asp:TextBox>
                              </div>
                        <div class="col-md-2 form-group">
                            <label>Rate:</label>
                              <asp:TextBox id="txtRate" name="txtRate" size="12" runat="server" 
                        AutoPostBack="True"
                        CssClass="form-control"></asp:TextBox>
                             </div>
                        <div class=" col-md-2 form-group">
                            <label>Amount:</label>
                             <asp:TextBox ID="txtAmount" runat="server" size="15" CssClass="form-control"></asp:TextBox>
                            </div>
                        <div class="form-group col-md-1" align="right" style="margin-left:-2px;">
                            <label>&nbsp;</label>
                             <asp:Button ID="BtnAdd" runat="server" CssClass="btn btn-primary" Text="Add"
                        onclick="BtnAdd_Click"/>
                        </div>
                        </div>
                        <div class="row">
                            <div class="col-md-12 form-group">
                          <div id="rpt" runat="server"></div>

                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-12">
                                <div class="form-group">
                                <asp:Button ID="BtnDelProduct" runat="server" Text="Delete" CssClass="btn btn-primary"
                                    OnClick="BtnDelProduct_Click" />
                                </div>
                            </div>
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
                        ErrorMessage="Required!" SetFocusOnError="True" ValidationGroup="order"></asp:RequiredFieldValidator><br />  
                     
                    <cc1:AutoCompleteExtender ID="AC" runat="server"
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
                                   <asp:TextBox id="txtDeliveryDate" runat="server"  CssClass="form-control"></asp:TextBox>
                    <cc1:CalendarExtender ID="CalendarExtender2" runat="server" 
                        TargetControlID="txtDeliveryDate" Enabled="true">
                        </cc1:CalendarExtender> 
                                </div>
                            </div>
                        <h4>PO Notes:</h4>
                        <div class="form-group">
                             <asp:TextBox id="txtNotes" CssClass="form-control" runat="server" Height="80px" 
                   TextMode="MultiLine"></asp:TextBox>
                              </div>
                        <div class="form-group">
                            <label>PO Specification:</label>
                             <asp:TextBox id="txtSpecification" CssClass="form-control" runat="server" Height="80px" 
                       TextMode="MultiLine"></asp:TextBox>
                              </div>
                        <div class="form-group">
                             <asp:Button ID="BtnSave" runat="server" Text="Save Order" CssClass="btn btn-primary" 
            onclick="BtnSave_Click" ValidationGroup="order"/>&nbsp;
        <asp:Button ID="BtnDelete" runat="server" Text="Refresh" 
            CssClass="btn btn-primary"  onclick="BtnDelete_Click"/>
  </div>
                    </section>
                </div>
            </div>

        </ContentTemplate>
    </asp:UpdatePanel>


</asp:Content>
