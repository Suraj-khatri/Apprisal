<%@ Page Language="C#"  MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="ManageSalesHistory.aspx.cs" Inherits="SwiftAssetManagement.AssetAcquisition.SalesHistory.ManageSalesHistory" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"> 
<script language=javascript>
    function AutocompleteAssetnumber(sender, e) {
        var customerValueArray = (e._value).split("|");
        document.getElementById("<%=HdnAssetnumber.ClientID %>").value = customerValueArray[1];
    }
    function AutocompleteEmpid(sender, e) {
        var customerValueArray = (e._value).split("|");
        document.getElementById("<%=Hdnempid.ClientID %>").value = customerValueArray[1];
    }
    function AutocompleteLedger(sender, e) {
        var customerValueArray = (e._value).split("|");
        document.getElementById("<%=HdnLedger.ClientID %>").value = customerValueArray[1];
    }
</script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
<asp:UpdatePanel ID ="upnlsales" runat="server">
<ContentTemplate>

<div class="row">
    <div class="col-md-10 col-md-offset-1">
        <section class="panel">
        <header class="panel-heading">
            <i class="fa fa-caret-right"></i>
             Asset Sales Request</header>
        <div class="panel-body">
            <div class="form-group">
                <span class="txtlbl">Please enter valid data!</span><span class="required"> (* Required fields!) </span>
                <br />
                <asp:Label ID="LblMsg" runat="server"></asp:Label>
                <asp:HiddenField ID="HdnAssetnumber" runat="server" />
                <asp:HiddenField ID="Hdnempid" runat="server" />
                <asp:HiddenField ID="HdnLedger" runat="server" />
            </div>
            <div class="row">
            <div class="col-md-6 form-group autocomplete-form">
                <label>Asset Number:</label><span class="errormsg">*</span>
                <asp:TextBox ID="TxtAssetNumber" runat="server" CssClass="form-control" 
                       AutoComplete="off"  AutoPostBack="True" ontextchanged="TxtAssetNumber_TextChanged">
                    </asp:TextBox>
                    <cc1:TextBoxWatermarkExtender ID="TxtAssetNumber_TextBoxWatermarkExtender" 
                        runat="server" Enabled="True" TargetControlID="TxtAssetNumber" 
                        WatermarkCssClass="watermark" WatermarkText="Auto Complete">
                    </cc1:TextBoxWatermarkExtender>
                    <cc1:AutoCompleteExtender 
                        ID="AutoCompleteExtender3" runat="server" 
                        CompletionInterval="10" CompletionListCssClass="autocompleteTextBoxLP" 
                        DelimiterCharacters="" EnableCaching="true" Enabled="true" 
                        MinimumPrefixLength="1" OnClientItemSelected="AutocompleteAssetnumber" 
                        ServiceMethod="GetAssetNumber" ServicePath="~/Autocomplete.asmx" 
                        TargetControlID="TxtAssetNumber">
                    </cc1:AutoCompleteExtender>                                        
                 <asp:RequiredFieldValidator ID="RfvAssetnumber" runat="server" 
                     ControlToValidate="TxtAssetNumber" ErrorMessage="Required" 
                     SetFocusOnError="True" ValidationGroup="sales" Display="Dynamic"></asp:RequiredFieldValidator>
            </div>
                    <div class="col-md-6">
                        <div class="form-group">
                            <label>Book Value:</label>
                           <asp:TextBox ID="TxtBookvalue" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>    
                        </div>
                    </div>
            </div>
            
            <div class="row">
            <div class="col-md-6">
                        <div class="form-group">
                            <label>Purchase Value:</label>
                           <asp:TextBox ID="txtPurchaseValue" runat="server" Enabled="false" CssClass="form-control" ></asp:TextBox>   
                        </div>
                    </div>
            <div class="col-md-6 form-group">
                <label>Asset Narration: </label>
                <asp:TextBox ID="txtAssetNarration" runat="server" CssClass="form-control"  Enabled="False" TextMode="MultiLine"></asp:TextBox>   
            </div>
               </div>
            <div class="row">
                <div class="col-md-3">
                    <div class="form-group">
                        <label>Sold Date:</label><span class="errormsg"> *</span>  
                        <asp:TextBox ID="TxtSolddate" runat="server"  CssClass="form-control" ></asp:TextBox>      
                        <cc1:CalendarExtender ID="TxtSolddate_CalendarExtender" runat="server" 
                            Enabled="True" TargetControlID="TxtSolddate">
                        </cc1:CalendarExtender>                 
                         <asp:RequiredFieldValidator ID="RfvMaintdate" runat="server" 
                             ControlToValidate="TxtSolddate" ErrorMessage="Required" 
                             SetFocusOnError="True" ValidationGroup="sales" Display="Dynamic"></asp:RequiredFieldValidator>     
                    </div>
                </div>
                <div class="col-md-3">
                    <div class="form-group">
                        <label>Sold Amount:</label>
                        <asp:TextBox ID="TxtSoldAmount" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:CompareValidator ID="CvSoldAmt" runat="server" 
                            ControlToValidate="TxtSoldAmount"  ErrorMessage="Invalid Amount" SetFocusOnError="True" Type="Double" 
                            ValidationGroup="sales"></asp:CompareValidator>      
                    </div>
                </div>
            <div class="col-md-3 form-group autocomplete-form">
                <label>Sold By: </label>
                <asp:TextBox ID="txtSoldby" runat="server" CssClass="form-control" AutoComplete="off"></asp:TextBox>
                 <cc1:TextBoxWatermarkExtender ID="txtSoldby_TextBoxWatermarkExtender" 
                     runat="server" Enabled="True" TargetControlID="txtSoldby" 
                     WatermarkCssClass="watermark" WatermarkText="Auto Complete">
                 </cc1:TextBoxWatermarkExtender>
                 <cc1:AutoCompleteExtender 
                     ID="txtSoldby_AutoCompleteExtender" runat="server" 
                     CompletionInterval="10" CompletionListCssClass="autocompleteTextBoxLP" 
                     DelimiterCharacters="" EnableCaching="true" Enabled="true" 
                     MinimumPrefixLength="1" OnClientItemSelected="AutocompleteEmpid" 
                     ServiceMethod="GetEmployeeList" ServicePath="~/Autocomplete.asmx" 
                     TargetControlID="txtSoldby">
                 </cc1:AutoCompleteExtender>                                                                               
            </div>
            
            <div class="col-md-3 form-group autocomplete-form">
                <label>Collection Ledger: </label>
                <asp:TextBox ID="TxtCollectionLedger" runat="server" CssClass="form-control" AutoComplete="off"></asp:TextBox>
                <cc1:TextBoxWatermarkExtender ID="TxtCollectionLedger_TextBoxWatermarkExtender" 
                    runat="server" Enabled="True" TargetControlID="TxtCollectionLedger" 
                    WatermarkCssClass="watermark" WatermarkText="Auto Complete">
                </cc1:TextBoxWatermarkExtender>
                <cc1:AutoCompleteExtender 
                    ID="TxtCollectionLedger_AutoCompleteExtender" runat="server" 
                    CompletionInterval="10" CompletionListCssClass="autocompleteTextBoxLP" 
                    DelimiterCharacters="" EnableCaching="true" Enabled="true" 
                    MinimumPrefixLength="1" OnClientItemSelected="AutocompleteLedger" 
                    ServiceMethod="GetAccountList" ServicePath="~/Autocomplete.asmx" 
                    TargetControlID="TxtCollectionLedger">
                </cc1:AutoCompleteExtender> 
            </div>
                </div>
            <div class="row">
            <div class="col-md-5 form-group">
                <label>Narration: </label>
                <asp:TextBox ID="TxtNarration" runat="server" CssClass="form-control"  Enabled="False" TextMode="MultiLine"></asp:TextBox>   
            </div>
            <div class="col-md-2 form-group">
                <label>Forwarded To: </label><span class="required">*</span>
                <asp:DropDownList id="ddlForwardedTo" runat="server" CssClass="form-control"></asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                 ControlToValidate="ddlForwardedTo" ErrorMessage="Required" 
                 SetFocusOnError="True" ValidationGroup="sales" Display="Dynamic"></asp:RequiredFieldValidator> 
            </div>
            <div class="col-md-5 form-group">
                <label>Rejection Reason: </label>
                <asp:TextBox ID="txtRejectionReason" runat="server" CssClass="form-control" TextMode="MultiLine" Enabled="false"></asp:TextBox> 
            </div>
                </div>
            <div class="form-group">
                <asp:Button ID="Btn_Save" runat="server" CssClass="btn btn-primary" Text="Save" ValidationGroup="sales" onclick="Btn_Save_Click" />
                <asp:Button ID="BtnBack" runat="server" CssClass="btn btn-primary" Text="Back" />
            </div>
        </div>
        </section>
    </div>
</div>

</ContentTemplate>
</asp:UpdatePanel>
</asp:Content>

