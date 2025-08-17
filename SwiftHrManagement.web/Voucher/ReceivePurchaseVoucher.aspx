<%@ Page Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true"
    CodeBehind="ReceivePurchaseVoucher.aspx.cs" Inherits="SwiftAssetManagement.Voucher.ReceivePurchaseVoucher" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script language="javascript" type="text/javascript">
        function editProduct(str) {
            var URL = "/Voucher/EditProductInfo.aspx?Id=" + str;
            GB_show("Edit Prodcut Information ", URL, 300, 400);
        }
        function addOther(str) {
            var URL = "/Voucher/AddOtherInfo.aspx?Id=" + str;
            GB_show("Add Prodcut Information ", URL, 400, 800);
        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    <asp:UpdatePanel ID="up" runat="server">
        <ContentTemplate>
            <div class="row">
                <div class="col-lg-10 col-md-offset-1">
                    <section class="panel">
                    <header class="panel-heading">
                        <i class="fa fa-caret-right"></i>
                          Purchase Voucher Entry
                        </header>
                    <div class="panel-body">
                        <div class="form-group">
                            <span class="txtlbl" nowrap="nowrap" align="left">Please Enter Valid Data!!! </span>
                            <span class="required">( * are required fields)</span><br />
                            <asp:Label ID="LblMsg" runat="server" CssClass="required"></asp:Label>&nbsp;<br />
                            Check For Without VAT Purchase
                            <asp:CheckBox ID="chkVAT" runat="server" />
                        </div>
                        <h4>Product / Account Information:</h4>
                        <div id="rpt" runat="server"></div>
                        <div class="form-group">
                            <asp:Button ID="BtnDelProduct" runat="server" Text="Delete" CssClass="btn btn-primary"
                                OnClick="BtnDelProduct_Click" />
                            <cc1:ConfirmButtonExtender ID="BtnDelProduct_ConfirmButtonExtender"
                                runat="server" ConfirmText="Confirm To Delete ?" Enabled="True"
                                TargetControlID="BtnDelProduct">
                            </cc1:ConfirmButtonExtender>
                        </div>
                        <h4>Payment Method (Account Information):</h4>
                        <div class="row">
                            <div class="col-md-4 form-group autocomplete-form">
                            Account: <span id="spn_available">( 0 )</span>
                            <input type="hidden" id="ac_type" name="ac_type">
                            <asp:RequiredFieldValidator ID="rfc" runat="server"
                                ControlToValidate="TxtAc_Name" ErrorMessage="Required"
                                SetFocusOnError="True" ValidationGroup="addaccount"></asp:RequiredFieldValidator>
                            <cc1:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server"
                                DelimiterCharacters="" Enabled="true" ServicePath="~/Autocomplete.asmx" ServiceMethod="GetAccountList"
                                TargetControlID="TxtAc_Name" MinimumPrefixLength="1" CompletionInterval="10"
                                EnableCaching="true" CompletionListCssClass="autocompleteTextBoxLP">
                            </cc1:AutoCompleteExtender>

                            <asp:TextBox ID="TxtAc_Name" runat="server" CssClass="form-control"
                                AutoComplete="off"></asp:TextBox>

                            <cc1:TextBoxWatermarkExtender ID="TxtAc_Name_TextBoxWatermarkExtender"
                                runat="server" Enabled="True" TargetControlID="TxtAc_Name"
                                WatermarkCssClass="watermark" WatermarkText="Auto Complete">
                            </cc1:TextBoxWatermarkExtender>
                        </div>

                        <div class="col-md-4 form-group">
                            Type:
                      <asp:DropDownList ID="DdlType" runat="server" CssClass="form-control">
                          <asp:ListItem Value="dr">DR</asp:ListItem>
                          <asp:ListItem Value="cr" Selected="True">CR</asp:ListItem>
                      </asp:DropDownList>
                        </div>
                        <div class="col-md-4 form-group">
                            Amount
                     <asp:TextBox ID="ac_amt" value="0" size="15" runat="server"
                         CssClass="form-control"></asp:TextBox>
                        </div>
                            <div class="col-md-12 form-group">
                                
                            <asp:Button ID="BtnAddAcc" Text=" Add " CssClass="btn btn-primary" runat="server"
                                OnClick="BtnAddAcc_Click" ValidationGroup="addaccount"></asp:Button>
                        </div>
                        <div align="center" name="batinf" id="Div1"></div>
                        <div id="rpt1" runat="server"></div>
                        <div class="col-md-12 form-group">
                            <asp:Button ID="BtnDeleteAcc" runat="server" Text="Delete" CssClass="btn btn-primary"
                                OnClick="BtnDeleteAcc_Click" />
                            <cc1:ConfirmButtonExtender ID="BtnDeleteAcc_ConfirmButtonExtender"
                                runat="server" ConfirmText="Confirm To Delete ?" Enabled="True"
                                TargetControlID="BtnDeleteAcc">
                            </cc1:ConfirmButtonExtender>
                        </div>
                        </div>
                        <h4>Bill information:</h4>
                        <div class="row">
                            <div class="col-md-4 form-group">
                            Bill No:  
                      <asp:RequiredFieldValidator ID="rfv3" runat="server" ControlToValidate="billno"
                          ErrorMessage="Required" SetFocusOnError="True" ValidationGroup="purchase"></asp:RequiredFieldValidator>
                            <asp:TextBox name="billno" ID="billno" runat="server" CssClass="form-control"></asp:TextBox>

                        </div>
                        <div class="col-md-4 form-group">
                            Bill Date:
                     <asp:RequiredFieldValidator ID="rfv4" runat="server"
                         ControlToValidate="billDate" ErrorMessage="Required" SetFocusOnError="True"
                         ValidationGroup="purchase"></asp:RequiredFieldValidator>
                            <asp:TextBox ID="billDate" runat="server" CssClass="form-control"></asp:TextBox>
                            <cc1:CalendarExtender ID="billDate_CalendarExtender" runat="server"
                                Enabled="True" TargetControlID="billDate">
                            </cc1:CalendarExtender>
                        </div>
                        <div class="col-md-4 form-group">
                            Remarks:
                    <asp:RequiredFieldValidator
                        ID="rfv6" runat="server" ControlToValidate="remarks" ErrorMessage="Required"
                        SetFocusOnError="True" ValidationGroup="purchase"></asp:RequiredFieldValidator><br />
                            <asp:TextBox ID="remarks"
                                CssClass="form-control" runat="server" Height="45px" 
                                TextMode="MultiLine"></asp:TextBox>
                        </div>
                            <div class="col-md-12 form-group">
                            <asp:Button ID="BtnSave" runat="server" Text="Save Voucher" CssClass="btn btn-primary" OnClick="BtnSave_Click"
                                ValidationGroup="purchase" />
                            <cc1:ConfirmButtonExtender ID="BtnSave_ConfirmButtonExtender" runat="server"
                                ConfirmText="Confirm To Save ?" Enabled="True" TargetControlID="BtnSave">
                            </cc1:ConfirmButtonExtender>
                            &nbsp;
        <asp:Button ID="BtnDelete" runat="server" Text="Refresh"
            CssClass="btn btn-primary" OnClick="BtnDelete_Click" />
                        </div>
                        </div>
                        
                        
                    </div>
                          </section>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
