<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/SwiftHRManager.Master"
    CodeBehind="ManageAssetBooking.aspx.cs" Inherits="SwiftAssetManagement.AssetManagement.ManageAssetBooking" %>

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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
   
            <section class="panel">
            <header class="panel-heading">
                <i class="fa fa-caret-right"></i>
                    Assets Booking Entry Details
            </header>
                <div class="panel-body">
                    <div class="form-group">
                        Asset Booking Entry
                    </div>
                    <div class="form-group">
                        <span class="txtlbl">Please enter valid data!</span><span class="required" Width="100%"> (* Required fields!) </span>
                        <asp:Label ID="lblmsg" runat="server" CssClass="errormsg"></asp:Label>
                    </div>
                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-group">
                        <div class="col-md-6">
                            <label>Branch Name:<span class="errormsg">*</span></label>
                            <asp:DropDownList ID="branchname" runat="server" CssClass="form-control" Width="100%" AutoPostBack="True" 
                                OnSelectedIndexChanged="branchname_SelectedIndexChanged"></asp:DropDownList>
                            <asp:RequiredFieldValidator ID="rfv1" runat="server" ControlToValidate="branchname"
                                Display="Dynamic" ErrorMessage="Required!" SetFocusOnError="True" ValidationGroup="book">
                            </asp:RequiredFieldValidator>
                        </div>
                        <div class="col-md-6">
                            <label>Department Name :</label>
                            <asp:DropDownList ID="deptname" runat="server" CssClass="form-control" Width="100%"></asp:DropDownList>
                        </div>
                    </div>
                        </div>
                        <div class="col-md-6">

                            <div class="form-group">
                        <div class="col-md-6">
                            <label>Vendor Name :</label>
                            <asp:DropDownList ID="vendorName" runat="server" CssClass="form-control" AutoPostBack="true" Width="100%">
                            </asp:DropDownList>
                            <div id="assetNumDiv" runat="server" visible="false"></div>
                        </div>
                        <div class="col-md-6">
                            <label>Asset Number :</label>
                            <asp:TextBox ID="assetNum" runat="server" CssClass="form-control" Width="100%"></asp:TextBox>
                        </div>
                    </div>
                        </div>
                    </div>

                    
                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-group">
                        <div class="col-md-6">
                            <label>Asset Type:<span class="errormsg">*</span></label>
                            <asp:HiddenField ID="hdnAssetId" runat="server" />
                            <cc1:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" DelimiterCharacters=""
                                Enabled="true" ServicePath="~/Autocomplete.asmx" ServiceMethod="GetAssetTypeBranchWise"
                                TargetControlID="assettype" MinimumPrefixLength="1" CompletionInterval="10" EnableCaching="true"
                                CompletionListCssClass="autocompleteTextBoxLP" OnClientItemSelected="AutocompleteOnSelected">
                            </cc1:AutoCompleteExtender>
                            <asp:TextBox ID="assettype" runat="server" CssClass="form-control" Width="100%" AutoComplete="off" 
                                AutoPostBack="True" OnTextChanged="assettype_TextChanged"></asp:TextBox>
                            <cc1:TextBoxWatermarkExtender ID="assettype_TextBoxWatermarkExtender" runat="server"
                                Enabled="True" TargetControlID="assettype" WatermarkCssClass="watermark" WatermarkText="Auto Complete">
                            </cc1:TextBoxWatermarkExtender>
                            <asp:RequiredFieldValidator ID="rfv6" runat="server" ControlToValidate="assettype"
                                Display="Dynamic" ErrorMessage="Required!" SetFocusOnError="True" ValidationGroup="book"></asp:RequiredFieldValidator>
                        </div>
                        <div class="col-md-6">
                            <label>Booking Date:<span class="errormsg">*</span></label>
                            <asp:TextBox ID="bookingdate" runat="server" CssClass="form-control" Width="100%" AutoPostBack="True"
                            OnTextChanged="bookingdate_TextChanged"></asp:TextBox>
                            <cc1:CalendarExtender ID="bookingdate_CalendarExtender" runat="server" Enabled="True"
                            TargetControlID="bookingdate">
                            </cc1:CalendarExtender>
                            <asp:RequiredFieldValidator ID="rfv3" runat="server" ControlToValidate="bookingdate"
                            Display="Dynamic" ErrorMessage="Required!" SetFocusOnError="True" ValidationGroup="book">
                            </asp:RequiredFieldValidator>
                        </div>
                    </div>
                        </div>
                        <div class="col-md-6">

                            <div class="form-group">
                        <div class="col-md-6">
                            <label>Number Of Asset Qty:<span class="errormsg">*</span></label>
                            <asp:TextBox ID="txtAssetQty" runat="server" CssClass="form-control" Width="100%"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfv7" runat="server" ControlToValidate="txtAssetQty" Display="Dynamic" 
                                ErrorMessage="Required!" SetFocusOnError="True" ValidationGroup="book"></asp:RequiredFieldValidator>
                        </div>                    
                        <div class="col-md-6">
                            <label>Purchase Value:<span class="errormsg">*</span></label>
                            <asp:TextBox ID="purchasevalue" runat="server" CssClass="form-control" Width="100%"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfv4" runat="server" ControlToValidate="purchasevalue" Display="Dynamic"
                                ErrorMessage="Required!" SetFocusOnError="True" ValidationGroup="book"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                        </div>
                    </div>
                    

                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-group">
                        <div class="col-md-6">
                            <label>Accumulated Depreciation:</label>
                            <asp:TextBox ID="accdep" runat="server" CssClass="form-control" Width="100%">0</asp:TextBox>
                        </div>
                        <div class="col-md-6">
                            <label>Dep. Start Date:<span class="errormsg">*</span></label>
                            <asp:TextBox ID="depstartdate" runat="server" CssClass="form-control" Width="100%"></asp:TextBox>
                            <cc1:CalendarExtender ID="depstartdate_CalendarExtender" runat="server" Enabled="True"
                                TargetControlID="depstartdate">
                            </cc1:CalendarExtender>
                            <asp:RequiredFieldValidator ID="rfv5" runat="server" ControlToValidate="depstartdate"
                                Display="Dynamic" ErrorMessage="Required!" SetFocusOnError="True" ValidationGroup="book">
                            </asp:RequiredFieldValidator>
                        </div>
                     </div>
                        </div>
                        <div class="col-md-6">

                            <div class="form-group">
                        <div class="col-md-6">
                            <label>Purchase Date:</label>
                            <asp:TextBox ID="txtPurchaseDate" runat="server" CssClass="form-control" Width="100%"></asp:TextBox>
                            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True" 
                                TargetControlID="txtPurchaseDate"></cc1:CalendarExtender>
                        </div>
                        <div class="col-md-6">
                            <label>Asset Status:</label>
                            <asp:DropDownList ID="assetstatus" runat="server" CssClass="form-control" Width="100%">
                                <asp:ListItem>Active</asp:ListItem>
                                <asp:ListItem>Inactive</asp:ListItem>
                                <asp:ListItem>Sold</asp:ListItem>
                                <asp:ListItem>Disposed</asp:ListItem>
                                <asp:ListItem>Write-Off</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                        </div>
                    </div>

                    
                     <div class="row">
                        <div class="col-md-6">
                            <div class="form-group">
                        <div class="col-md-6">
                            <label>Bill Info:</label>
                            <cc1:AutoCompleteExtender ID="AutoCompleteExtender4" runat="server" DelimiterCharacters=""
                            Enabled="true" ServicePath="~/Autocomplete.asmx" ServiceMethod="GetBillLinkage"
                            TargetControlID="billid" MinimumPrefixLength="1" CompletionInterval="10" EnableCaching="true"
                            CompletionListCssClass="autocompleteTextBoxLP" OnClientItemSelected="AutoCompleteBill">
                            </cc1:AutoCompleteExtender>
                            <asp:TextBox ID="billid" runat="server" CssClass="form-control" AutoComplete="off" Width="100%"></asp:TextBox>
                            <cc1:TextBoxWatermarkExtender ID="billid_TextBoxWatermarkExtender" runat="server"
                                Enabled="True" TargetControlID="billid" WatermarkCssClass="form-control" WatermarkText="Auto Complete">
                            </cc1:TextBoxWatermarkExtender>
                            <asp:HiddenField ID="hdnBillId" runat="server" />
                        </div>
                        <div class="col-md-6">
                            <label>Insurance Info:</label>
                            <cc1:AutoCompleteExtender ID="AutoCompleteExtender3" runat="server" DelimiterCharacters=""
                            Enabled="true" ServicePath="~/Autocomplete.asmx" ServiceMethod="GetInsuranceLinkage"
                            TargetControlID="insuranceid" MinimumPrefixLength="1" CompletionInterval="10"
                            EnableCaching="true" CompletionListCssClass="autocompleteTextBoxLP" OnClientItemSelected="AutoCompleteInsurance">
                            </cc1:AutoCompleteExtender>
                            <asp:TextBox ID="insuranceid" runat="server" CssClass="form-control" AutoComplete="off" Width="100%"></asp:TextBox>
                            <cc1:TextBoxWatermarkExtender ID="insuranceid_TextBoxWatermarkExtender" runat="server"
                                Enabled="True" TargetControlID="insuranceid" WatermarkCssClass="form-control" WatermarkText="Auto Complete">
                            </cc1:TextBoxWatermarkExtender>
                            <asp:HiddenField ID="hdnInsuredId" runat="server" />
                        </div>
                    </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                        <div class="col-md-6">
                            <label>Asset Holder:</label>
                            <cc1:AutoCompleteExtender ID="AutoCompleteExtender5" runat="server" DelimiterCharacters=""
                                Enabled="true" ServicePath="~/Autocomplete.asmx" ServiceMethod="GetEmployeeList"
                                TargetControlID="assetholder" MinimumPrefixLength="1" CompletionInterval="10"
                                EnableCaching="true" CompletionListCssClass="autocompleteTextBoxLP" OnClientItemSelected="AutocompleteEmployee">
                            </cc1:AutoCompleteExtender>
                            <asp:TextBox ID="assetholder" runat="server" CssClass="form-control" AutoComplete="off" Width="100%"></asp:TextBox>
                            <cc1:TextBoxWatermarkExtender ID="assetholder_TextBoxWatermarkExtender" runat="server"
                                Enabled="True" TargetControlID="assetholder" WatermarkCssClass="form-control" WatermarkText="Auto Complete">
                            </cc1:TextBoxWatermarkExtender>
                            <asp:HiddenField ID="hdnHolderId" runat="server" />
                        </div>
                        <div class="col-md-6">
                            <label>Next Maintainance Date:</label>
                                <asp:TextBox ID="nextmaindate" runat="server" CssClass="form-control" Width="100%"></asp:TextBox>
                                <cc1:CalendarExtender ID="nextmaindate_CalendarExtender" runat="server" Enabled="True"
                                    TargetControlID="nextmaindate">
                                </cc1:CalendarExtender>
                        </div>
                    </div>

                        </div>
                    </div>
                    

                     <div class="row">
                        <div class="col-md-6">
                            <div class="form-group">
                        <div class="col-md-6">
                            <label>Old Asset Code:</label>
                            <asp:TextBox ID="OldAssetCode" runat="server" CssClass="form-control" Width="100%"></asp:TextBox>
                        </div>
                        <div class="col-md-6">
                            <label>Old Asset Number:</label>
                            <asp:TextBox ID="OldAssetNo" runat="server" CssClass="form-control" Width="100%"></asp:TextBox>
                        </div>
                    </div>
                        </div>
                        <div class="col-md-6">

                            <div class="form-group">
                        <div class="col-md-6">
                            <label>Modal Number:</label>
                            <asp:TextBox ID="ModelNo" runat="server" CssClass="form-control" Width="100%"></asp:TextBox>
                        </div>
                        <div class="col-md-6">
                            <label>Brand:</label>
                            <asp:TextBox ID="Brand" runat="server" CssClass="form-control" Width="100%"></asp:TextBox>
                        </div>
                    </div>
                        </div>
                    </div>
                    
                    
                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-group">
                        <div class="col-md-6">
                            <label>Asset Serial Number:</label>
                            <asp:TextBox ID="assetserial" runat="server" CssClass="form-control" Width="100%"></asp:TextBox>
                        </div>
                        <div class="col-md-6">
                            <label>Depreciation Pct.:</label>
                            <asp:TextBox ID="TxtDepPct" runat="server" CssClass="form-control" AutoPostBack="True" Width="100%"></asp:TextBox>
                            <asp:RangeValidator ID="RvPct" runat="server" ControlToValidate="TxtDepPct" Display="Dynamic"
                            ErrorMessage="Invalid Range" MaximumValue="100" MinimumValue="0" SetFocusOnError="True"
                            Type="Double"></asp:RangeValidator>
                        </div>
                    </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                        <div class="col-md-6">
                            <label>Warrenty Expiry Date:</label>
                            <asp:TextBox ID="warrexpirydate" runat="server" CssClass="form-control" Width="100%"></asp:TextBox>
                            <cc1:CalendarExtender ID="warrexpirydate_CalendarExtender" runat="server" Enabled="True"
                                    TargetControlID="warrexpirydate">
                            </cc1:CalendarExtender>
                        </div>
                        <div class="col-md-6">
                            <label>&nbsp;</label><br />
                            <label>Is Amortised Asset:</label>
                            <asp:CheckBox ID="chkAmortised" runat="server" AutoPostBack="True" OnCheckedChanged="chkAmortised_CheckedChanged" />
                            <asp:TextBox ID="txtLifeInMonth" runat="server" CssClass="form-control" Visible="false"></asp:TextBox>
                            <asp:TextBox ID="txtReminLife" runat="server" CssClass="form-control" Visible="false"></asp:TextBox>
                            <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender2" runat="server" Enabled="True"
                                TargetControlID="txtLifeInMonth" WatermarkCssClass="form-control" WatermarkText="Asset Life In Month">
                            </cc1:TextBoxWatermarkExtender>
                        </div>
                    </div>

                        </div>
                    </div>
                    

                    <div class="row">
                        <div class="col-md-12">
                            <div class="form-group">
                        <div class="col-md-12">
                            <label>Narration:</label>
                            <asp:TextBox ID="narration" runat="server" CssClass="form-control"  TextMode="MultiLine">
                            </asp:TextBox>
                        </div>
                    </div>
                        </div>
                        <div class="col-md-12">

                            <div class="form-group">
                        <div class="col-md-12" style="margin-top:8px;">
                            <asp:Button ID="BtnSave" runat="server" Text="Save" CssClass="btn btn-primary" OnClick="BtnSave_Click" 
                                ValidationGroup="book" />
                            <cc1:ConfirmButtonExtender ID="BtnSave_ConfirmButtonExtender" runat="server" 
                                ConfirmText="Are you sure to save?" Enabled="True" TargetControlID="BtnSave">
                            </cc1:ConfirmButtonExtender>
                            <asp:Button ID="BtnDelete" runat="server" Text="Delete" CssClass="btn btn-primary" OnClick="BtnDelete_Click" />
                            <cc1:ConfirmButtonExtender ID="BtnDelete_ConfirmButtonExtender" runat="server" 
                                ConfirmText="Are you sure to delete?" Enabled="True" TargetControlID="BtnDelete">
                            </cc1:ConfirmButtonExtender>&nbsp;
                            <asp:Button ID="BtnBack" runat="server" Text="Back" CssClass="btn btn-primary" OnClick="BtnBack_Click" />
                        </div>
                    </div>
                        </div>
                    </div>

                    

                    
                    
                    
                    
                    
                    
                    
                    
                    
                    
                    
                    
                    
                    
                </div>
            </section>
        
</asp:Content>
