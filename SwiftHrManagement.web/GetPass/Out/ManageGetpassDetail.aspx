<%@ Page Language="C#"  MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="ManageGetpassDetail.aspx.cs" Inherits="SwiftAssetManagement.GetPass.Out.ManageGetpassDetail" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .form-group {
            margin-bottom: 3px !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    <asp:UpdatePanel ID ="upnlsales" runat="server">
        <ContentTemplate>
            <div class="row">
                <div class="col-md-12">
                     <section class="panel">
                        <header class="panel-heading">
                            <i class="fa fa-caret-right"></i>
                            Gate Pass Details
                        </header>
                        <div class="panel-body">
                            <label>Gate Pass Details</label>
                            <div class="form-group">
                                <span>Please enter valid data</span>&nbsp;<span class="required">(* Required fields)</span>
                                <asp:Label ID="LblMsg" runat="server"></asp:Label>
                                <asp:HiddenField ID="HdnAssetnumber" runat="server" />
                                <asp:HiddenField ID="Hdnempid" runat="server" />
                                <asp:HiddenField ID="HdnLedger" runat="server" />
                            </div>
                             <div class="form-group">
                                <label>Asset History :<span class="required"></span></label>
                            </div>
                            <div class="row form-inline">
                            <div class="col-md-10 form-group">
                                <label>Asset Number :<span class="required">*</span></label>
                                <asp:TextBox ID="TxtAssetNumber" runat="server" CssClass="form-control" AutoComplete="off" Width="100%"
                                    AutoPostBack="True" ontextchanged="TxtAssetNumber_TextChanged" />
                                <cc1:TextBoxWatermarkExtender ID="TxtAssetNumber_TextBoxWatermarkExtender" runat="server" 
                                    Enabled="True" TargetControlID="TxtAssetNumber" WatermarkCssClass="form-control" 
                                    WatermarkText="Auto Complete">
                                </cc1:TextBoxWatermarkExtender>
                                <cc1:AutoCompleteExtender 
                                    ID="TxtAssetNumber_AutoCompleteExtender" runat="server" CompletionInterval="10" 
                                    CompletionListCssClass="autocompleteTextBoxLP" DelimiterCharacters="" EnableCaching="true" 
                                    Enabled="true" MinimumPrefixLength="1" OnClientItemSelected="AutocompleteOnSelected1" 
                                    ServiceMethod="GetAssetNumber" ServicePath="~/Autocomplete.asmx" TargetControlID="TxtAssetNumber" />
                                <asp:RequiredFieldValidator ID="RfvAssetnumber" runat="server" ControlToValidate="TxtAssetNumber" 
                                    Display="None" ErrorMessage="*" SetFocusOnError="True" ValidationGroup="gatepasstemp" Width="100%">
                                </asp:RequiredFieldValidator>
                            </div>
                            <div class="col-md-2 form-group">
                                <label>&nbsp;</label><br />
                                <asp:Button ID="Add" runat="server" CssClass="btn btn-primary" onclick="Add_Click" Text="Add" 
                                        ValidationGroup="gatepasstemp" float="right"/>
                            </div>
                                </div>
                            <div class="row form-inline">
                            <div class="col-md-3 form-group">
                                <label>Book Value :</label>
                                    <asp:TextBox ID="TxtBookvalue" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox> 
                            </div>
                            <div class="col-md-3 form-group">
                                <label>Branch :</label>
                                    <asp:TextBox ID="TxtBranch" runat="server" AutoCompleteType="Disabled" CssClass="form-control" 
                                        Enabled="False"></asp:TextBox>
                                <cc1:AutoCompleteExtender ID="TxtBranch_AutoCompleteExtender" runat="server" CompletionInterval="10"
                                    CompletionListCssClass="autocompleteTextBoxLP" DelimiterCharacters="" EnableCaching="true" 
                                    Enabled="true" MinimumPrefixLength="1" OnClientItemSelected="AutocompleteEmpid" 
                                    ServiceMethod="GetEmployeeList" ServicePath="~/Autocomplete.asmx" TargetControlID="TxtBranch">
                                </cc1:AutoCompleteExtender>
                            </div>
                            <div class="col-md-3 form-group">
                                <label>Department :</label>
                                <asp:TextBox ID="TxtDepartment" runat="server" AutoCompleteType="Disabled" CssClass="form-control" 
                                    Enabled="False"></asp:TextBox>
                                <cc1:AutoCompleteExtender ID="TxtDepartment_AutoCompleteExtender" runat="server" CompletionInterval="10" 
                                    CompletionListCssClass="autocompleteTextBoxLP" DelimiterCharacters="" EnableCaching="true" 
                                    Enabled="true" MinimumPrefixLength="1" OnClientItemSelected="AutocompleteEmpid" 
                                    ServiceMethod="GetEmployeeList" ServicePath="~/Autocomplete.asmx" TargetControlID="TxtDepartment">
                                </cc1:AutoCompleteExtender>
                            </div>
                            <div class="col-md-3 form-group">
                                <label>Asset Holder :</label>
                                 <asp:TextBox ID="TxtAssetHolder" runat="server" CssClass="form-control" AutoCompleteType="Disabled" 
                                     Enabled="False" />
                                <cc1:TextBoxWatermarkExtender ID="TxtAssetHolder_TextBoxWatermarkExtender" runat="server" 
                                    Enabled="True" TargetControlID="TxtAssetHolder" WatermarkCssClass="form-control" 
                                    WatermarkText="Auto Complete">
                                </cc1:TextBoxWatermarkExtender>
                                <cc1:AutoCompleteExtender 
                                    ID="TxtAssetHolder_AutoCompleteExtender" runat="server" CompletionInterval="10" 
                                    CompletionListCssClass="autocompleteTextBoxLP" DelimiterCharacters="" EnableCaching="true" 
                                    Enabled="true"  MinimumPrefixLength="1" OnClientItemSelected="AutocompleteEmpid" 
                                    ServiceMethod="GetEmployeeList" ServicePath="~/Autocomplete.asmx" 
                                    TargetControlID="TxtAssetHolder">
                                </cc1:AutoCompleteExtender>
                            </div>
                                </div>
                            <div class="row">
                            <div class="col-md-10 form-group">
                                <div ID="rpt" runat="server"></div>
                            </div>
                              
                        <div class="col-md-2">
                            <label>&nbsp;</label><br />
                                 <asp:Button ID="Delete" runat="server" CssClass="btn btn-primary" onclick="Delete_Click" Text="Delete"  float="right"/>
                                <cc1:ConfirmButtonExtender ID="Delete_ConfirmButtonExtender" runat="server" 
                                    ConfirmText="Confirm To  Delete ?" Enabled="True" TargetControlID="Delete">
                                </cc1:ConfirmButtonExtender>
                              </div>
                                </div>
                            <label>Gate Pass out Detail :</label>
                                <div class="row form-inline">
                            <div class="col-md-4 form-group">
                                <label>Gate Pass Date :<span class="required">*</span></label>
                                 <asp:TextBox ID="TxtGatepassDate" runat="server" CssClass="form-control" Width="100%"></asp:TextBox>
                                <cc1:CalendarExtender ID="TxtGatepassDate_CalendarExtender" runat="server" 
                                    Enabled="True" TargetControlID="TxtGatepassDate">
                                </cc1:CalendarExtender>
                                <asp:RequiredFieldValidator ID="RfvMaintdate" runat="server" ControlToValidate="TxtGatepassDate" 
                                    Display="None" ErrorMessage="*" SetFocusOnError="True" ValidationGroup="gatepass">
                                </asp:RequiredFieldValidator>
                            </div>
                            <div class="col-md-4 form-group">
                                <label>Is Returnable :</label>
                                <asp:DropDownList ID="DdlReturnable" runat="server" CssClass="form-control" Width="100%">
                                    <asp:ListItem Value="Y">Yes</asp:ListItem>
                                    <asp:ListItem Value="N">No</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="col-md-4 form-group">
                                <label>Delivered To :</label>
                                <asp:TextBox ID="Txtdeliveredto" runat="server" AutoCompleteType="Disabled" CssClass="form-control" Width="100%"
                                     MaxLength="500"></asp:TextBox>
                            </div>
                                    </div>
                            <div class="form-group">
                                <label> Message :</label>
                                <asp:TextBox ID="TxtMessage" runat="server" AutoCompleteType="Disabled" CssClass="form-control" Width="100%"
                                    TextMode="MultiLine">
                                </asp:TextBox>
                                <cc1:AutoCompleteExtender ID="TxtMessage_AutoCompleteExtender" runat="server" CompletionInterval="10"
                                     CompletionListCssClass="autocompleteTextBoxLP" DelimiterCharacters="" EnableCaching="true" 
                                    Enabled="true" MinimumPrefixLength="1" OnClientItemSelected="AutocompleteEmpid" 
                                    ServiceMethod="GetEmployeeList" ServicePath="~/Autocomplete.asmx" TargetControlID="TxtMessage">
                                </cc1:AutoCompleteExtender>
                            </div>
                            <div class="form-group">
                                <asp:Button ID="Btn_Save" runat="server" CssClass="btn btn-primary" Text="Save" ValidationGroup="gatepass" 
                                    onclick="Btn_Save_Click" />
                                <cc1:ConfirmButtonExtender ID="Btn_Save_ConfirmButtonExtender" runat="server" 
                                    ConfirmText="Confirm to save?" Enabled="True" TargetControlID="Btn_Save">
                                </cc1:ConfirmButtonExtender>&nbsp;
                                <asp:Button ID="BtnBack" runat="server" CssClass="btn btn-primary" Text="Back" />
                            </div>
                        </div>
                    </div>
                </section>
            </div>
        </div>

</ContentTemplate>
</asp:UpdatePanel>

    <script type="text/javascript">
        function AutocompleteOnSelected1(sender, e) {
            var customerValueArray = (e._value).split("|");
            document.getElementById("<%=HdnAssetnumber.ClientID%>").value = customerValueArray[1];
        }
</script>
</asp:Content>
