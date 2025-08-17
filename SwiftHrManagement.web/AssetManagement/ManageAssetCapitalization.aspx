<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/SwiftHRManager.Master" CodeBehind="ManageAssetCapitalization.aspx.cs" Inherits="SwiftAssetManagement.AssetManagement.ManageAssetCapitalization" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"> 
    <script type="text/javascript">
        function AutocompleteOnSelected1(sender, e) {
            var customerValueArray = (e._value).split("|");
            document.getElementById("<%=HdnAssetnumber.ClientID %>").value = customerValueArray[1];
        }
//        function AutocompleteOnSelected(sender, e) {
//            var customerValueArray = (e._value).split("|");
//            document.getElementById("<%//=Hdnempid.ClientID %>").value = customerValueArray[1];
//        }
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
 

        
<!--################ END FORM STYLE-->
    <asp:UpdatePanel ID="updatepanel1" runat="server">
    <ContentTemplate>  
           <div class="col-md-10 col-md-offset-1">
            <div class="panel">
                <div class="panel-heading">
                    <i class="fa fa-caret-right"></i>
                    Asset Capitalization Details
                </div>
                <div class="panel-body">
                     <span class="txtlbl" nowrap="nowrap">Please Enter Valid Data!!! </span>
                     <span class="required" >( * are required fields)</span>
                     <asp:Label ID="LblMsg" runat="server"></asp:Label>
                     <asp:HiddenField ID="HdnAssetnumber" runat="server" />
                     <asp:HiddenField ID="Hdnempid" runat="server" />
                    <div>&nbsp;</div>
                    <div class="row">
                    <div class="col-md-6 form-group">
                        <label>Asset Number :   <span class="errormsg"> * </span></label>
                            <asp:TextBox ID="TxtAssetNumber" runat="server" CssClass="form-control" 
                                                     AutoComplete="off" 
                                  ontextchanged="TxtAssetNumber_TextChanged" AutoPostBack="True"></asp:TextBox>
                            <cc1:TextBoxWatermarkExtender ID="TxtAssetNumber_TextBoxWatermarkExtender" 
                                 runat="server" Enabled="True" TargetControlID="TxtAssetNumber" 
                                 WatermarkText="Auto Complete" WatermarkCssClass="form-control">
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
                        <label>Purchase Value :</label>
                        <asp:TextBox ID="txtPurchaseValue" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                    </div>
                        </div>
                    <div class="row">
                    
                    <div class="col-md-4 form-group">
                        <label>Book Value :</label>
                        <asp:TextBox ID="TxtBookValue" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox> 
                    </div>
                    <div class="col-md-4 form-group">
                        <label>Acc. Depreciation :</label>
                          <asp:TextBox ID="txtAccDep" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                    </div>
                        <div class="col-md-4 form-group">
                        <label>Asset Narration :</label>
                         <asp:TextBox ID="txtAssetNarration" runat="server"
                                CssClass="form-control" Enabled="False" TextMode="MultiLine"></asp:TextBox>
                    </div>
                    </div>
                    <div class="row">
                    <div class="col-md-4 form-group">
                        <label>Capitalized Amount :</label>
                        <asp:TextBox ID="TxtCapitalizedAmount" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="col-md-4 form-group">
                        <label>Capitalization Date :   <span class="errormsg">*</span></label>
                           <asp:TextBox ID="TxtCapitalizationDate" runat="server"
                                CssClass="form-control"></asp:TextBox>      
                           <cc1:CalendarExtender ID="TxtCapitalizationDate_CalendarExtender" runat="server" 
                                Enabled="True" TargetControlID="TxtCapitalizationDate">
                           </cc1:CalendarExtender>
                           <asp:RequiredFieldValidator ID="RfvMaintdate" runat="server" 
                                 ControlToValidate="TxtCapitalizationDate" Display="Dynamic" ErrorMessage="Required!" 
                                 SetFocusOnError="True" ValidationGroup="assethist">
                           </asp:RequiredFieldValidator>
                    </div>
                    <div class="col-md-4 form-group">
                        <label>Forwarded To :</label><span class="required">*</span> 
                           <asp:DropDownList ID="ddlForwardedTo" runat="server" CssClass="form-control"></asp:DropDownList>  
                           <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                 ControlToValidate="ddlForwardedTo" Display="Dynamic" ErrorMessage="Required!" 
                                 SetFocusOnError="True" ValidationGroup="assethist"></asp:RequiredFieldValidator>
                    </div>
                        </div>
                    <div class="row">
                    <div class="col-md-6 form-group">
                        <label>Capitalized Narration :</label>
                        <asp:TextBox ID="TxtNarration" runat="server" CssClass="form-control" Width="100%" TextMode="MultiLine"></asp:TextBox>
                    </div>
                    <div class="col-md-6 form-group">
                        <label>Rejection Reason :</label>
                        <asp:TextBox ID="txtRejectedReason" runat="server" CssClass="form-control" Width="100%" TextMode="MultiLine" Enabled="false"></asp:TextBox>
                    </div>
                        </div>
                    <div class="form-group">
                                    <asp:Button ID="Btn_Save" runat="server" CssClass="btn btn-primary" 
                                onclick="Btn_Save_Click" Text="Save" ValidationGroup="assethist"/>
                            <cc1:ConfirmButtonExtender ID="Btn_Save_ConfirmButtonExtender" runat="server" 
                                ConfirmText="Confirm To Save?" Enabled="True" TargetControlID="Btn_Save">
                            </cc1:ConfirmButtonExtender>           
                            <asp:Button ID="btnDelete" runat="server" CssClass="btn btn-primary" 
                                Text="Delete" onclick="btnDelete_Click"/>
                           <asp:Button ID="BtnBack" runat="server" CssClass="btn btn-primary" 
                                Text="Back"/>
                    </div>
                </div>
            </div>
        </div>
    
</ContentTemplate>
</asp:UpdatePanel> 
</asp:Content>

