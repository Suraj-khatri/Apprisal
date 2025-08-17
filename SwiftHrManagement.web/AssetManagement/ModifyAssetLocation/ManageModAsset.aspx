<%@ Page Title="" Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true"
    CodeBehind="ManageModAsset.aspx.cs" Inherits="SwiftHrManagement.web.AssetManagement.ModifyAssetLocation.ManageModAsset" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script language="javascript" type="text/javascript">
        function AutocompleteOnSelected(sender, e) {
            var assetValueArray = (e._value).split("|");
            document.getElementById("<%=hdnAssetId.ClientID %>").value = assetValueArray[1];
        }
        function AutocompleteEmployee(sender, e) {
            var assetValueArray = (e._value).split("|");
            document.getElementById("<%=hdnHolderId.ClientID %>").value = assetValueArray[1];
        }
        function AutoCompleteInsurance(sender, e) {
            var assetValueArray = (e._value).split("|");
            document.getElementById("<%=hdnInsuredId.ClientID %>").value = assetValueArray[1];
        }
        function AutoCompleteBill(sender, e) {
            var assetValueArray = (e._value).split("|");
            document.getElementById("<%=hdnBillId.ClientID %>").value = assetValueArray[1];
        }
    </script>
    <style type="text/css">
        .form-inline{
           margin-top:5px !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    <div class="row">
        <div class="col-md-10 col-md-offset-1">
            <section class="panel">
            <header class="panel-heading">
                <i class="fa fa-caret-right"></i>
                  Assets Booking Entry Details
                    </header>
            <div class="panel-body">
                <h4>Asset Booking Entry</h4>
                <div class="form-group">
                    Please enter valid data!( <span class="errormsg">*</span> are required fields)<br />
                    <asp:Label ID="lblmsg" runat="server" CssClass="errormsg"></asp:Label>
                </div>
                <div class="row form-inline">
                <div class="col-md-4">
                    <div class="form-group">
                       <label> Branch Name:  <span class="errormsg">*</span></label>
                                     <asp:DropDownList ID="branchname" runat="server" width="100%"
                                         CssClass="form-control" AutoPostBack="True"
                                         OnSelectedIndexChanged="branchname_SelectedIndexChanged">
                                     </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfv1" runat="server"
                            ControlToValidate="branchname" Display="Dynamic"
                            ErrorMessage="Required!" SetFocusOnError="True"
                            ValidationGroup="book"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-group">
                      <label> Department Name:</label> 
                                     <asp:DropDownList ID="deptname" runat="server" width="100%"
                                         CssClass="form-control">
                                     </asp:DropDownList>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-group">
                        <label> Vendor Name:</label>
                                      <asp:DropDownList ID="vendorName" runat="server" width="100%"
                                          CssClass="form-control"  AutoPostBack="True">
                                      </asp:DropDownList>
                    </div>
                </div>
                    </div>
                <div class="row form-inline">
                <div class="col-md-4">
                    <div class="form-group">
                       <label> Asset Type: <span class="errormsg">*</span></label>
                                     <asp:HiddenField ID="hdnAssetId" runat="server" />
                        <cc1:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server"
                            DelimiterCharacters="" Enabled="true" ServicePath="~/Autocomplete.asmx" ServiceMethod="GetAssetTypeBranchWise"
                            TargetControlID="assettype" MinimumPrefixLength="1" CompletionInterval="10"
                            EnableCaching="true" CompletionListCssClass="autocompleteTextBoxLP" OnClientItemSelected="AutocompleteOnSelected">
                        </cc1:AutoCompleteExtender>
                        <asp:TextBox ID="assettype" runat="server" width="100%"
                            CssClass="form-control"  AutoComplete="off"
                            AutoPostBack="True" OnTextChanged="assettype_TextChanged"></asp:TextBox>
                        <cc1:TextBoxWatermarkExtender ID="assettype_TextBoxWatermarkExtender"
                            runat="server" Enabled="True" TargetControlID="assettype"
                            WatermarkCssClass="watermark" WatermarkText="Auto Complete">
                        </cc1:TextBoxWatermarkExtender>
                        <asp:RequiredFieldValidator ID="rfv6" runat="server"
                            ControlToValidate="assettype" Display="Dynamic"
                            ErrorMessage="Required!" SetFocusOnError="True"
                            ValidationGroup="book"></asp:RequiredFieldValidator>
                        
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-group">
                         <label>Booking Date:   <span class="errormsg">*</span></label>
                                     <asp:TextBox ID="bookingdate" runat="server" width="100%"
                                         CssClass="form-control" AutoPostBack="True"
                                         OnTextChanged="bookingdate_TextChanged"></asp:TextBox>
                        <cc1:CalendarExtender ID="bookingdate_CalendarExtender" runat="server"
                            Enabled="True" TargetControlID="bookingdate">
                        </cc1:CalendarExtender>
                        <asp:RequiredFieldValidator ID="rfv3" runat="server"
                            ControlToValidate="bookingdate" Display="Dynamic"
                            ErrorMessage="Required!" SetFocusOnError="True"
                            ValidationGroup="book"></asp:RequiredFieldValidator>
                      
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-group">
                         <label>Number of Asset Qty: <span class="errormsg">*</span></label>
                                      <asp:TextBox ID="txtAssetQty" runat="server" width="100%"
                                          CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfv7" runat="server"
                ControlToValidate="txtAssetQty" Display="Dynamic"
                ErrorMessage="Required!" SetFocusOnError="True"
                ValidationGroup="book"></asp:RequiredFieldValidator>
                    </div>
                </div>
                    </div>
                <div class="row form-inline">
                <div class="col-md-4">
                    <div class="form-group">
                        <label> Purchase Value:<span class="errormsg">*</span> </label>
                                      <asp:TextBox ID="purchasevalue" runat="server" width="100%"
                                          CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfv4" runat="server"
                            ControlToValidate="purchasevalue" Display="Dynamic"
                            ErrorMessage="Required!" SetFocusOnError="True"
                            ValidationGroup="book"></asp:RequiredFieldValidator>
                        
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-group">
                         <label>Accumulated Depreciation:</label>
                                     <asp:TextBox ID="accdep" runat="server" width="100%"
                                         CssClass="form-control">0</asp:TextBox>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-group">
                       <label> Dep. Start Date: <span class="errormsg">*</span> </label>
                                     <asp:TextBox ID="depstartdate" runat="server" width="100%"
                                         CssClass="form-control"></asp:TextBox>
                        <cc1:CalendarExtender ID="depstartdate_CalendarExtender" runat="server"
                            Enabled="True" TargetControlID="depstartdate">
                        </cc1:CalendarExtender>
                        <asp:RequiredFieldValidator ID="rfv5" runat="server"
                            ControlToValidate="depstartdate" Display="Dynamic"
                            ErrorMessage="Required!" SetFocusOnError="True"
                            ValidationGroup="book"></asp:RequiredFieldValidator>
                    </div>
                </div>
                    </div>

                <div class="row form-inline">
                <div class="col-md-4">
                    <div class="form-group">
                         <label>Purchase Date:</label>
                                     <asp:TextBox ID="txtPurchaseDate" runat="server" width="100%"
                                         CssClass="form-control"></asp:TextBox>
                        <cc1:CalendarExtender ID="CalendarExtender1" runat="server"
                            Enabled="True" TargetControlID="txtPurchaseDate">
                        </cc1:CalendarExtender>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-group">
                        <label> Asset Status:</label>
                                      <asp:DropDownList ID="assetstatus" runat="server" CssClass="form-control" width="100%">
                                          <asp:ListItem>Active</asp:ListItem>
                                          <asp:ListItem>Inactive</asp:ListItem>
                                          <asp:ListItem>Sold</asp:ListItem>
                                          <asp:ListItem>Disposed</asp:ListItem>
                                          <asp:ListItem>Write-Off</asp:ListItem>
                                      </asp:DropDownList>
                    </div>
                </div>
               
                    <div class="col-md-4 form-group autocomplete-form">
                         <label>Bill Info:</label>
                                     <cc1:AutoCompleteExtender ID="AutoCompleteExtender4" runat="server"
                                         DelimiterCharacters="" Enabled="true" ServicePath="~/Autocomplete.asmx" ServiceMethod="GetBillLinkage"
                                         TargetControlID="billid" MinimumPrefixLength="1" CompletionInterval="10"
                                         EnableCaching="true" CompletionListCssClass="autocompleteTextBoxLP" OnClientItemSelected="AutoCompleteBill">
                                     </cc1:AutoCompleteExtender>
                        <asp:TextBox ID="billid" runat="server" width="100%"
                            CssClass="form-control" AutoComplete="off"></asp:TextBox>
                        <cc1:TextBoxWatermarkExtender ID="billid_TextBoxWatermarkExtender"
                            runat="server" Enabled="True" TargetControlID="billid"
                            WatermarkCssClass="form-control" WatermarkText="Auto Complete">
                        </cc1:TextBoxWatermarkExtender>
                        <asp:HiddenField ID="hdnBillId" runat="server" />
                    </div>
              
            </div>
                <div class="row form-inline">
                <div class="col-md-4">
                    <div class="form-group autocomplete-form">
                        <label> Insurance Info:</label>
                                      <cc1:AutoCompleteExtender ID="AutoCompleteExtender3" runat="server"
                                          DelimiterCharacters="" Enabled="true" ServicePath="~/Autocomplete.asmx" ServiceMethod="GetInsuranceLinkage"
                                          TargetControlID="insuranceid" MinimumPrefixLength="1" CompletionInterval="10"
                                          EnableCaching="true" CompletionListCssClass="autocompleteTextBoxLP" OnClientItemSelected="AutoCompleteInsurance">
                                      </cc1:AutoCompleteExtender>
                        <asp:TextBox ID="insuranceid" runat="server" width="100%"
                            CssClass="form-control" AutoComplete="off"></asp:TextBox>
                        <cc1:TextBoxWatermarkExtender ID="insuranceid_TextBoxWatermarkExtender"
                            runat="server" Enabled="True" TargetControlID="insuranceid"
                            WatermarkCssClass="form-control" WatermarkText="Auto Complete">
                        </cc1:TextBoxWatermarkExtender>
                        <asp:HiddenField ID="hdnInsuredId" runat="server" />
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-group autocomplete-form">
                         <label>Asset Holder:</label>
                                    <cc1:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server"
                                        DelimiterCharacters="" Enabled="true" ServicePath="~/Autocomplete.asmx" ServiceMethod="GetEmployeeList"
                                        TargetControlID="assetholder" MinimumPrefixLength="1" CompletionInterval="10"
                                        EnableCaching="true" CompletionListCssClass="autocompleteTextBoxLP" OnClientItemSelected="AutocompleteEmployee">
                                    </cc1:AutoCompleteExtender>

                        <asp:TextBox ID="assetholder" runat="server"  width="100%"
                            CssClass="form-control"  AutoComplete="off"></asp:TextBox>
                        <cc1:TextBoxWatermarkExtender ID="assetholder_TextBoxWatermarkExtender"
                            runat="server" Enabled="True" TargetControlID="assetholder"
                            WatermarkCssClass="watermark" WatermarkText="Auto Complete">
                        </cc1:TextBoxWatermarkExtender>
                        <asp:HiddenField ID="hdnHolderId" runat="server" />
                    </div>
                </div>
                   
                <div class="col-md-4">
                    <div class="form-group">
                        <label> Next Maintenance Date:</label>
                                      <asp:TextBox ID="nextmaindate" runat="server"
                                          CssClass="form-control" width="100%"></asp:TextBox>
                        <cc1:CalendarExtender ID="nextmaindate_CalendarExtender" runat="server"
                            Enabled="True" TargetControlID="nextmaindate">
                        </cc1:CalendarExtender>
                    </div>
                </div>
                    </div>
                <div class="row form-inline">
                <div class="col-md-4">
                    <div class="form-group">
                        <label> Old Asset Code:</label>
      <asp:TextBox ID="OldAssetCode" runat="server" CssClass="form-control" width="100%"></asp:TextBox>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-group">
                         <label>Old Asset Number:</label>
    <asp:TextBox ID="OldAssetNo" runat="server" CssClass="form-control" width="100%"></asp:TextBox>
                    </div>
                </div>
                    
                <div class="col-md-4">
                    <div class="form-group">
                       <label> Model No: </label>
      <asp:TextBox ID="ModelNo" runat="server" CssClass="form-control" width="100%"></asp:TextBox>
                    </div>
                </div>
                    </div>

                <div class="row form-inline">
                <div class="col-md-4">
                    <div class="form-group">
                         <label>Brand:</label>
    <asp:TextBox ID="Brand" runat="server" CssClass="form-control" width="100%"></asp:TextBox>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-group">
                         <label>Asset Serial No:</label>
        <asp:TextBox ID="assetserial" runat="server" CssClass="form-control" width="100%"></asp:TextBox>
                    </div>
                </div>
                   
                <div class="col-md-4">
                    <div class="form-group">
                        <label>Depreciation Pct.: </label>
                                      <asp:TextBox ID="TxtDepPct" runat="server" CssClass="form-control"
                                          AutoPostBack="True"  width="100%"></asp:TextBox>
                        <asp:RangeValidator ID="RvPct" runat="server" ControlToValidate="TxtDepPct"
                            Display="Dynamic" ErrorMessage="Invalid Range" MaximumValue="100"
                            MinimumValue="0" SetFocusOnError="True" Type="Double"></asp:RangeValidator>

                    </div>
                </div>
                     </div>
                <div class="row form-inline">
                <div class="col-md-4">
                    <div class="form-group">
                        <label> Warranty Expiry Date:</label>
                                     <asp:TextBox ID="warrexpirydate" runat="server"
                                         CssClass="form-control"  width="100%"></asp:TextBox>
                        <cc1:CalendarExtender ID="warrexpirydate_CalendarExtender" runat="server"
                            Enabled="True" TargetControlID="warrexpirydate">
                        </cc1:CalendarExtender>
                    </div>
                </div>
                <div class="col-md-2">
                    <div class="form-group">
                        <label> Is Amortised Asset:</label>
                                    <asp:CheckBox ID="chkAmortised" runat="server"
                                        AutoPostBack="True" OnCheckedChanged="chkAmortised_CheckedChanged" />
                        <asp:TextBox ID="txtLifeInMonth" runat="server" CssClass="form-control"
                            Visible="false"  width="100%"></asp:TextBox>
                        <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1"
                            runat="server" Enabled="True" TargetControlID="txtLifeInMonth"
                            WatermarkCssClass="watermark" WatermarkText="Asset Life In Month">
                        </cc1:TextBoxWatermarkExtender>
                    </div>
                </div>
                    
                <div class="col-md-6">
                    <div class="form-group">
                        <label> Narration:</label>
                                      <asp:TextBox ID="narration" runat="server" CssClass="form-control"
                                          width="100%" TextMode="MultiLine"></asp:TextBox>
                    </div>
                </div>
                    </div>
               
                        <asp:Button ID="BtnSave" runat="server" Text="Save" CssClass="btn btn-primary"
                             OnClick="BtnSave_Click" ValidationGroup="book" />
                        <cc1:ConfirmButtonExtender ID="BtnSave_ConfirmButtonExtender" runat="server"
                            ConfirmText="Are you sure to save?" Enabled="True" TargetControlID="BtnSave">
                        </cc1:ConfirmButtonExtender>
                     
        <asp:Button ID="BtnBack" runat="server" Text="Back" CssClass="btn btn-primary"
            OnClick="BtnBack_Click" />
        </div>
        </section>
    </div>
    </div>
</asp:Content>
