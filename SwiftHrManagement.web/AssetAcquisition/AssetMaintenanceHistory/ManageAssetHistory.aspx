<%@ Page Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true"
    CodeBehind="ManageAssetHistory.aspx.cs" Inherits="SwiftAssetManagement.AssetAcquisition.AssetMaintenanceHistory.ManageAssetHistory" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script language="javascript">
        function AutocompleteOnSelected1(sender, e) {
            var customerValueArray = (e._value).split("|");
            document.getElementById("<%=HdnAssetnumber.ClientID %>").value = customerValueArray[1];
        }
        function AutocompleteOnSelected(sender, e) {
            var customerValueArray = (e._value).split("|");
            document.getElementById("<%=Hdnempid.ClientID %>").value = customerValueArray[1];
        }
        function AutocompleteLedger(sender, e) {
            var customerValueArray = (e._value).split("|");
            document.getElementById("<%=HdnLedger.ClientID %>").value = customerValueArray[1];
        }
    </script>
    <style type="text/css">
        .form-inline{
            margin-bottom:5px!important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    <asp:UpdatePanel ID="upnlwriteoff" runat="server">
        <ContentTemplate>
            <div class="row">
                <div class="col-md-10 col-md-offset-1">
                    <section class="panel">
                    <header class="panel-heading">
                        <i class="fa fa-caret-right"></i>
                    Asset Maintenance Details 
                    </header>
                    <div class="panel-body">
                        <label>Asset Maintenance Details</label>
                        <div class="form-group">
                            <span class="txtlbl" nowrap="nowrap">Please Enter Valid Data!!! </span>
                            <span class="required">( * are required fields)</span><br />
                            <asp:Label ID="LblMsg" runat="server"></asp:Label>
                            <asp:HiddenField ID="HdnAssetnumber" runat="server" />
                            <asp:HiddenField ID="Hdnempid" runat="server" />
                            <asp:HiddenField ID="HdnLedger" runat="server" />
                        </div>
                        <label>Asset Maintenance Plan:</label>
                        <div class="row">
                        <div class="col-md-4 form-group autocomplete-form ">
                           <label> Asset Number:  <span class="errormsg"> *</span></label>
                                 <asp:TextBox ID="TxtAssetNumber" runat="server" CssClass="form-control"
                                      AutoComplete="off" Width="100%"
                                     AutoPostBack="True" OnTextChanged="TxtAssetNumber_TextChanged"></asp:TextBox>
                                 <cc1:TextBoxWatermarkExtender ID="TxtAssetNumber_TextBoxWatermarkExtender"
                                     runat="server" Enabled="True" TargetControlID="TxtAssetNumber"
                                     WatermarkCssClass="watermark" WatermarkText="Auto Complete">
                                 </cc1:TextBoxWatermarkExtender>
                                 <cc1:AutoCompleteExtender
                                     ID="AutoCompleteExtender3" runat="server"
                                     CompletionInterval="10" CompletionListCssClass="autocompleteTextBoxLP"
                                     DelimiterCharacters="" EnableCaching="true" Enabled="true"
                                     MinimumPrefixLength="1" OnClientItemSelected="AutocompleteOnSelected1"
                                     ServiceMethod="GetAssetNumber" ServicePath="~/Autocomplete.asmx"
                                     TargetControlID="TxtAssetNumber">
                                 </cc1:AutoCompleteExtender>
                                

                            <asp:RequiredFieldValidator ID="RfvAssetnumber" runat="server"
                                ControlToValidate="TxtAssetNumber" Display="Dynamic" ErrorMessage="Required!"
                                SetFocusOnError="True" ValidationGroup="assethist"></asp:RequiredFieldValidator>
                        </div>
                        <div class="col-md-4 form-group">
                            <label>Book Value :</label>
                             <asp:TextBox ID="TxtBookValue" runat="server"
                                 CssClass="form-control" Enabled="False" Width="100%"></asp:TextBox>
                        </div>
                        <div class="col-md-4 form-group ">
                            <label>Purchase Value :</label>
                            <asp:TextBox ID="txtPurchaseValue" runat="server"
                                CssClass="form-control" Enabled="False"  Width="100%"></asp:TextBox>
                        </div>
                            </div>
                        <div class="row">
                        <div class=" col-md-4 form-group">
                            <label>Asset Narration :</label>
                             <asp:TextBox ID="txtAssetNarration" runat="server"
                                 CssClass="form-control"  Width="100%" TextMode="MultiLine" Enabled="false"></asp:TextBox>
                        </div>
                        <div class=" col-md-4 form-group">
                            <label>Acc. Dep. :</label>
                             <asp:TextBox ID="txtAccDep" runat="server"
                                 CssClass="form-control" Enabled="False"  Width="100%"></asp:TextBox>
                        </div>
                        <div class=" col-md-4 form-group">
                            <label>Expense Amount:  <span class="errormsg">*</label>
                             <asp:TextBox ID="TxtExpenseAmount" runat="server"  Width="100%"
                                 CssClass="form-control" ></asp:TextBox>
                          
                                <asp:RequiredFieldValidator ID="RfvExpAmt" runat="server"
                                    ControlToValidate="TxtExpenseAmount" Display="Dynamic" ErrorMessage="Required!"
                                    SetFocusOnError="True" ValidationGroup="assethist"></asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="CvSoldAmt" runat="server"
                                    ControlToValidate="TxtExpenseAmount" Display="Dynamic"
                                    ErrorMessage="Invalid Amount" SetFocusOnError="True" Type="Double"
                                    ValidationGroup="assethist"></asp:CompareValidator>
                            </span>
                        </div>
                            </div>
                        <div class="row">
                        <div class=" col-md-4 form-group">
                           <label> Maintenance Date :  <span class="errormsg">*</span></label>
                              <asp:TextBox ID="TxtMaintainedDate" runat="server"
                                  CssClass="form-control"  Width="100%"></asp:TextBox>
                            <cc1:CalendarExtender ID="TxtMaintainedDate_CalendarExtender" runat="server"
                                Enabled="True" TargetControlID="TxtMaintainedDate">
                            </cc1:CalendarExtender>
                            <asp:RequiredFieldValidator ID="RfvMaintdate" runat="server"
                                ControlToValidate="TxtMaintainedDate" Display="Dynamic" ErrorMessage="Required!"
                                SetFocusOnError="True" ValidationGroup="assethist"></asp:RequiredFieldValidator>
                        </div>
                        <div class=" col-md-4 form-group">
                            <label>Next Maintenance Date:</label>
                               <asp:TextBox ID="TxtNextMaintainedDate" runat="server"
                                   CssClass="form-control" Width="100%" ></asp:TextBox>
                            <cc1:CalendarExtender ID="TxtNextMaintainedDate_CalendarExtender" runat="server"
                                Enabled="True" TargetControlID="TxtNextMaintainedDate">
                            </cc1:CalendarExtender>
                        </div>
                        <div class="form-group autocomplete-form col-md-4">
                            <label>Payment Ledger:</label>
                               <asp:TextBox ID="TxtpaymentLedger" runat="server"  Width="100%"
                                   AutoCompleteType="Disabled" CssClass="form-control" AutoComplete="Off"></asp:TextBox>
                            <cc1:TextBoxWatermarkExtender ID="TxtpaymentLedger_TextBoxWatermarkExtender"
                                runat="server" Enabled="True" TargetControlID="TxtpaymentLedger"
                                WatermarkCssClass="watermark" WatermarkText="Auto Complete">
                            </cc1:TextBoxWatermarkExtender>
                            <cc1:AutoCompleteExtender ID="TxtpaymentLedger_AutoCompleteExtender"
                                runat="server" CompletionInterval="10"
                                CompletionListCssClass="autocompleteTextBoxLP" DelimiterCharacters=""
                                EnableCaching="true" Enabled="true" MinimumPrefixLength="1"
                                OnClientItemSelected="AutocompleteLedger" ServiceMethod="GetAccountList"
                                ServicePath="~/Autocomplete.asmx" TargetControlID="TxtpaymentLedger">
                            </cc1:AutoCompleteExtender>
                        </div>
                            </div>
                        <div class="row">
                        <div class="form-group autocomplete-form col-md-4">
                           <label> Maintained By :</label>
                               <asp:TextBox ID="txtmaintainedby" runat="server" CssClass="form-control"  Width="100%"
                                    AutoCompleteType="Disabled" AutoComplete="Off"></asp:TextBox>
                            <cc1:TextBoxWatermarkExtender ID="txtmaintainedby_TextBoxWatermarkExtender"
                                runat="server" Enabled="True" TargetControlID="txtmaintainedby"
                                WatermarkCssClass="watermark" WatermarkText="Auto Complete">
                            </cc1:TextBoxWatermarkExtender>
                            <cc1:AutoCompleteExtender
                                ID="txtmaintainedby_AutoCompleteExtender" runat="server"
                                CompletionInterval="10" CompletionListCssClass="autocompleteTextBoxLP"
                                DelimiterCharacters="" EnableCaching="true" Enabled="true"
                                MinimumPrefixLength="1" OnClientItemSelected="AutocompleteOnSelected"
                                ServiceMethod="GetEmployeeList" ServicePath="~/Autocomplete.asmx"
                                TargetControlID="txtmaintainedby">
                            </cc1:AutoCompleteExtender>
                        </div>
                        <div class=" col-md-4 form-group">
                            <label>Narration :</label>
                              <asp:TextBox ID="TxtNarration" runat="server"  Width="100%"
                                  CssClass="form-control"  TextMode="MultiLine"></asp:TextBox>
                        </div>
                        <div class=" col-md-4 form-group">
                            <label>Forwarded To :  <span class="required">*</span></label>
                              <asp:DropDownList ID="ddlForwardedTo" runat="server" CssClass="form-control"  Width="100%"></asp:DropDownList>
                          
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                ControlToValidate="ddlForwardedTo" ErrorMessage="Required"
                                SetFocusOnError="True" ValidationGroup="assethist" Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                            </div>
                        <div class="row">
                        <div class=" col-md-4 form-group">
                           <label> Rejection Reason :</label>
                                <asp:TextBox ID="txtRejectionReason" runat="server"  Width="100%"
                                    CssClass="form-control"  TextMode="MultiLine" Enabled="false"></asp:TextBox>
                        </div>
                      </div>
                            <asp:Button ID="Btn_Save" runat="server" CssClass="btn btn-primary"
                                OnClick="Btn_Save_Click" Text="Save" ValidationGroup="assethist" />
                            <cc1:ConfirmButtonExtender ID="Btn_Save_ConfirmButtonExtender" runat="server"
                                ConfirmText="Are You Confirm To Save?" Enabled="True"
                                TargetControlID="Btn_Save">
                            </cc1:ConfirmButtonExtender>
                            <asp:Button ID="btnDelete" runat="server" CssClass="btn btn-primary"
                                Text="Delete" OnClick="btnDelete_Click" />
                           <asp:Button ID="BtnBack" runat="server" CssClass="btn btn-primary"
                                Text="Back" />
                     
                    </div>
                    </section>
                </div>
            </div>




        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>


