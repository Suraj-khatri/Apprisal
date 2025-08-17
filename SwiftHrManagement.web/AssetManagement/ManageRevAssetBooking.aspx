<%@ Page Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="ManageRevAssetBooking.aspx.cs" Inherits="SwiftHrManagement.web.AssetManagement.ManageRevAssetBooking" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"> 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    <asp:UpdatePanel ID ="upnlsales" runat="server">
        <ContentTemplate>
            <div class="row">
                <div class="col-md-10 col-md-offset-1">
                    <section class="panel">
                        <header class="panel-heading">
                            <i class="fa fa-caret-right"></i>
                           Revenue Assets Booking 
                        </header>
                        <div class="panel-body">
                            <h4>Revenue Asset Booking</h4>
                            <div class="form-group">
                                <span>Please enter valid data</span>&nbsp;<span class="required">(* Required fields)</span>
                                 <asp:Label ID="lblmsg" runat="server" CssClass="txtlbl" Width="100%"></asp:Label>
                            </div>
                            <div class="row form-inline">
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label>Branch Name :<span class="required"></span></label>
                                     <asp:DropDownList ID="branchname" runat="server" CssClass="form-control" AutoPostBack="True" 
                                         onselectedindexchanged="branchname_SelectedIndexChanged" Width="100%">
                                     </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="rfv1" runat="server" ControlToValidate="branchname" Display="Dynamic" 
                                        ErrorMessage="Required!" SetFocusOnError="True" ValidationGroup="book" Width="100%"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label>Department Name :<span class="required">*</span></label>
                                    <asp:DropDownList ID="deptname" runat="server" CssClass="form-control" Width="100%"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label>Asset Type :<span class="required"></span></label>
                                    <asp:HiddenField ID="hdnAssetId" runat="server" />
                                    <cc1:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" DelimiterCharacters="" Enabled="true" 
                                        ServicePath="~/Autocomplete.asmx" ServiceMethod="GetAssetTypeBranchWise" TargetControlID="assettype" 
                                        MinimumPrefixLength="1" CompletionInterval="10" EnableCaching="true" CompletionListCssClass="autocompleteTextBoxLP" 
                                        OnClientItemSelected="AutocompleteOnSelected" >
                                    </cc1:AutoCompleteExtender>        
                                    <asp:TextBox ID="assettype" runat="server" CssClass="form-control" AutoComplete="off" AutoPostBack="True" Width="100%"></asp:TextBox>
                                    <cc1:TextBoxWatermarkExtender ID="assettype_TextBoxWatermarkExtender" runat="server" Enabled="True" 
                                        TargetControlID="assettype" WatermarkCssClass="form-control" WatermarkText="Auto Complete">
                                    </cc1:TextBoxWatermarkExtender>
                                    <asp:RequiredFieldValidator ID="rfv6" runat="server" ControlToValidate="assettype" Display="Dynamic" 
                                        ErrorMessage="Required!" SetFocusOnError="True" ValidationGroup="book" Width="100%">
                                    </asp:RequiredFieldValidator>          
                                </div>
                            </div>
                                </div>

                            <div class="row form-inline">
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label>Booking Date :<span class="required"></span></label>
                                    <asp:TextBox ID="bookingdate" runat="server" CssClass="form-control" AutoPostBack="True" Width="100%"></asp:TextBox>
                                    <cc1:CalendarExtender ID="bookingdate_CalendarExtender" runat="server" Enabled="True" TargetControlID="bookingdate">
                                    </cc1:CalendarExtender>
                                    <asp:RequiredFieldValidator ID="rfv3" runat="server" ControlToValidate="bookingdate" Display="Dynamic"
                                         ErrorMessage="Required!" SetFocusOnError="True" ValidationGroup="book"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label>Number of Asset Qty :<span class="required"></span></label>
                                    <asp:TextBox ID="txtAssetQty" runat="server" CssClass="form-control" Width="100%"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfv7" runat="server" ControlToValidate="txtAssetQty" Display="Dynamic" 
                                        ErrorMessage="Required!" SetFocusOnError="True" ValidationGroup="book"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label>Purchase Value :<span class="required"></span></label>
                                    <asp:TextBox ID="purchasevalue" runat="server" CssClass="form-control" Width="100%"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfv4" runat="server" ControlToValidate="purchasevalue" Display="Dynamic" 
                                        ErrorMessage="Required!" SetFocusOnError="True" ValidationGroup="book"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                                </div>

                            <div class="row form-inline">
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label>Purchase Date :<span class="required"></span></label>
                                    <asp:TextBox ID="txtPurchaseDate" runat="server" CssClass="form-control" Width="100%"></asp:TextBox>
                                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True" TargetControlID="txtPurchaseDate">
                                    </cc1:CalendarExtender>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label>Asset Status :<span class="required"></span></label>
                                    <asp:DropDownList ID="assetstatus" runat="server" CssClass="form-control" Width="100%">         
                                        <asp:ListItem>Active</asp:ListItem>
                                        <asp:ListItem>Inactive</asp:ListItem>
                                        <asp:ListItem>Sold</asp:ListItem>
                                        <asp:ListItem>Disposed</asp:ListItem>
                                        <asp:ListItem>Write-Off</asp:ListItem>
                                     </asp:DropDownList>
                                </div>
                            </div>
                                
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label>Bill Info :</label>
                                     <cc1:AutoCompleteExtender ID="AutoCompleteExtender4" runat="server" DelimiterCharacters="" Enabled="true" 
                                         ServicePath="~/Autocomplete.asmx" ServiceMethod="GetBillLinkage" TargetControlID="billid" 
                                         MinimumPrefixLength="1" CompletionInterval="10" EnableCaching="true" CompletionListCssClass="autocompleteTextBoxLP" 
                                         OnClientItemSelected="AutoCompleteBill" >
                                    </cc1:AutoCompleteExtender>
                                    <asp:TextBox ID="billid" runat="server" CssClass="form-control" AutoComplete="off" Width="100%"></asp:TextBox>
                                    <cc1:TextBoxWatermarkExtender ID="billid_TextBoxWatermarkExtender" runat="server" Enabled="True"
                                        TargetControlID="billid" WatermarkCssClass="form-control" WatermarkText="Auto Complete">
                                    </cc1:TextBoxWatermarkExtender>
                                    <asp:HiddenField ID="hdnBillId" runat="server" />
                                </div>
                            </div>
                                </div>

                                <div class="row form-inline">
                                    <div class="col-md-4">
                                     <div class="form-group">
                                    <label>Insurance Info :</label>
                                     <cc1:AutoCompleteExtender ID="AutoCompleteExtender3" runat="server" DelimiterCharacters="" Enabled="true" 
                                         ServicePath="~/Autocomplete.asmx" ServiceMethod="GetInsuranceLinkage" TargetControlID="insuranceid" 
                                         MinimumPrefixLength="1" CompletionInterval="10" EnableCaching="true" CompletionListCssClass="autocompleteTextBoxLP" 
                                         OnClientItemSelected="AutoCompleteInsurance" >
                                    </cc1:AutoCompleteExtender>    
                                    <asp:TextBox ID="insuranceid" runat="server" CssClass="form-control" AutoComplete="off" Width="100%"></asp:TextBox>
                                    <cc1:TextBoxWatermarkExtender ID="insuranceid_TextBoxWatermarkExtender" runat="server" Enabled="True" 
                                        TargetControlID="insuranceid" WatermarkCssClass="form-control" WatermarkText="Auto Complete">
                                    </cc1:TextBoxWatermarkExtender>
                                    <asp:HiddenField ID="hdnInsuredId" runat="server" />
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label>Asset Holder :</label>
                                     <cc1:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" DelimiterCharacters="" Enabled="true" 
                                         ServicePath="~/Autocomplete.asmx" ServiceMethod="GetEmployeeList" TargetControlID="assetholder" 
                                         MinimumPrefixLength="1" CompletionInterval="10" EnableCaching="true" CompletionListCssClass="autocompleteTextBoxLP" 
                                         OnClientItemSelected="AutocompleteEmployee" >
                                    </cc1:AutoCompleteExtender>
                                    <asp:TextBox ID="assetholder" runat="server" CssClass="form-control" AutoComplete="off" Width="100%"></asp:TextBox>
                                    <cc1:TextBoxWatermarkExtender ID="assetholder_TextBoxWatermarkExtender" runat="server" Enabled="True" 
                                        TargetControlID="assetholder" WatermarkCssClass="form-control" WatermarkText="Auto Complete">
                                    </cc1:TextBoxWatermarkExtender>
                                    <asp:HiddenField ID="hdnHolderId" runat="server" />
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label>Next Maintenance Date :</label>
                                    <asp:TextBox ID="nextmaindate" runat="server" CssClass="form-control" Width="100%"></asp:TextBox>
                                    <cc1:CalendarExtender ID="nextmaindate_CalendarExtender" runat="server" Enabled="True" TargetControlID="nextmaindate">
                                    </cc1:CalendarExtender>
                                </div>
                            </div>
                            </div>

                                <div class="row form-inline">
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label>Asset Serial No :</label>
                                    <asp:TextBox ID="assetserial" runat="server" CssClass="form-control" Width="100%"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label>Warranty Expiry Date :</label>
                                    <asp:TextBox ID="warrexpirydate" runat="server" CssClass="form-control" Width="100%"></asp:TextBox>
                                    <cc1:CalendarExtender ID="warrexpirydate_CalendarExtender" runat="server" 
                                        Enabled="True" TargetControlID="warrexpirydate">
                                    </cc1:CalendarExtender>
                                    <%--    <td nowrap="nowrap" valign="top"><div align="right">Is Amortised Asset:</div></td>    
                                    <td nowrap="nowrap" valign="top"><asp:CheckBox ID="chkAmortised" runat="server" 
                                            AutoPostBack="True" oncheckedchanged="chkAmortised_CheckedChanged"/>
                                        <asp:TextBox ID="txtLifeInMonth" runat="server" CssClass="form-control" Width="100px" Visible="false"></asp:TextBox>
                                         <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" 
                                                runat="server" Enabled="True" TargetControlID="txtLifeInMonth" 
                                                WatermarkCssClass="watermark" WatermarkText="Asset Life In Month">
                                        </cc1:TextBoxWatermarkExtender>
                                    </td>--%>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label>Narration :</label>
                                     <asp:TextBox ID="narration" runat="server" CssClass="form-control" TextMode="MultiLine" Width="100%"></asp:TextBox>
                                </div>
                            </div>
                          </div>
                                     <asp:Button ID="BtnSave" runat="server" Text="Save" CssClass="btn btn-primary" onclick="BtnSave_Click" ValidationGroup="book"/>
                                    <cc1:ConfirmButtonExtender ID="BtnSave_ConfirmButtonExtender" runat="server" ConfirmText="Are you sure to save?" 
                                        Enabled="True" TargetControlID="BtnSave">
                                    </cc1:ConfirmButtonExtender>&nbsp;
                                    <asp:Button ID="BtnDelete" runat="server" Text="Delete" CssClass="btn btn-primary" onclick="BtnDelete_Click"/>
                                    <cc1:ConfirmButtonExtender ID="BtnDelete_ConfirmButtonExtender" runat="server" ConfirmText="Are you sure to delete?" 
                                        Enabled="True" TargetControlID="BtnDelete">
                                    </cc1:ConfirmButtonExtender>&nbsp;
                                    <asp:Button ID="BtnBack" runat="server" Text="Back" CssClass="btn btn-primary" onclick="BtnBack_Click" />
                               
                        </div>
                    </section>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

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
