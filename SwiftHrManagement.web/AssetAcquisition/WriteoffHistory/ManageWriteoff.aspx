<%@ Page Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true"
    CodeBehind="ManageWriteoff.aspx.cs" Inherits="SwiftAssetManagement.AssetAcquisition.WriteoffHistory.ManageWriteoff" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script language="javascript">
        function AutocompleteOnSelected1(sender, e) {
            var customerValueArray = (e._value).split("|");
            document.getElementById("<%=HdnAssetnumber.ClientID %>").value = customerValueArray[1];
        }
        //        function AutocompleteOnSelected(sender, e) {
        //            var customerValueArray = (e._value).split("|");
        //            document.getElementById("").value = customerValueArray[1];
        //        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
<asp:UpdatePanel ID="upnlwriteoff" runat="server">
    <ContentTemplate>
        <div class="row">
            <div class="col-md-10 col-md-offset-1">
                <section class="panel">
                    <header class="panel-heading">
                        <i class="fa fa-caret-right"></i>
                            Write Off History
                    </header>
                    <div class="panel-body">
                        <div class="form-group">
                            <span class="txtlbl">Please enter valid data!</span><span class="required"> (* Required fields!) </span>
                            <br />
                            <asp:Label ID="LblMsg" runat="server"></asp:Label>
                            <asp:HiddenField ID="HdnAssetnumber" runat="server" />
                        </div>
                        <div class="row">
                        <div class="form-group col-md-4">
                            <label>Asset Number:<span class="errormsg">*</span></label>
                            <asp:TextBox ID="TxtAssetNumber" runat="server" CssClass="form-control" AutoComplete="off" AutoPostBack="True" OnTextChanged="TxtAssetNumber_TextChanged" />
                            <cc1:TextBoxWatermarkExtender ID="TxtAssetNumber_TextBoxWatermarkExtender" runat="server"
                                Enabled="True" TargetControlID="TxtAssetNumber" WatermarkCssClass="form-control"
                                WatermarkText="Auto Complete" />
                            <cc1:AutoCompleteExtender ID="AutoCompleteExtender3" runat="server" CompletionInterval="10"
                                CompletionListCssClass="autocompleteTextBoxLP" DelimiterCharacters="" EnableCaching="true"
                                Enabled="true" MinimumPrefixLength="1" OnClientItemSelected="AutocompleteOnSelected1"
                                ServiceMethod="GetAssetNumber" ServicePath="~/Autocomplete.asmx" TargetControlID="TxtAssetNumber" />
                            <asp:RequiredFieldValidator ID="RfvAssetnumber" runat="server" ControlToValidate="TxtAssetNumber"
                                Display="Dynamic" ErrorMessage="Required!" SetFocusOnError="True" ValidationGroup="assethist" />
                        </div>
                        <div class="col-md-4 form-group">
                            <label>Purchase Value:</label>
                            <asp:TextBox ID="txtPurchaseValue" runat="server" Enabled="false" CssClass="form-control" />
                                                                      
                        </div>
                        <div class="col-md-4 form-group">
                            <label>Book Value:</label>
                                  <asp:TextBox ID="TxtBookvalue" runat="server" CssClass="form-control" Enabled="False"/>
                        </div>
                            </div>
                        <div class="row">
                        <div class="col-md-4 form-group">
                            <label>Accumulated Depreciation:</label>
                            <asp:TextBox ID="txtAccDepn" runat="server" Enabled="false" CssClass="form-control" />
                        </div>
                        <div class="col-md-4 form-group">
                            <label>Location:</label>
                            <asp:TextBox ID="txtLocation" runat="server" CssClass="form-control" Enabled="False" />
                        </div>
                        <div class="col-md-4 form-group">
                            <label>Scarp Value:<span class="errormsg">*</span></label>
                            <asp:TextBox ID="txtScrapValue" runat="server" AutoPostBack="true" CssClass="form-control"
                                OnTextChanged="txtScrapValue_TextChanged" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtScrapValue"
                                Display="Dynamic" ErrorMessage="Required!" SetFocusOnError="True" ValidationGroup="assethist" />
                        </div>
                            </div>
                        <div class="row">
                        <div class="col-md-4 form-group">
                            <label>Net Profit/Loss:</label>
                            <asp:TextBox ID="txtNetProfitLoss" runat="server" CssClass="form-control" Enabled="False" />
                        </div>

                        <div class="col-md-8 form-group">
                            <label>Asset Narration:</label>
                            <asp:TextBox ID="txtAssetNarration" runat="server" CssClass="form-control" Enabled="False" TextMode="MultiLine" />
                        </div>
                            </div>
                        <div class="row">
                        <div class="col-md-4 form-group">
                            <label>Write-Off Date:<span class="errormsg">*</span></label>
                            <asp:TextBox ID="TxtwriteoffDate" runat="server" CssClass="form-control"/>
                            <cc1:CalendarExtender ID="TxtwriteoffDate_CalendarExtender" runat="server" Enabled="True"
                                TargetControlID="TxtwriteoffDate">
                            </cc1:CalendarExtender>
                            <asp:RequiredFieldValidator ID="RfvMaintdate" runat="server" ControlToValidate="TxtwriteoffDate"
                                Display="Dynamic" ErrorMessage="Required!" SetFocusOnError="True" ValidationGroup="assethist" />
                        </div>
                        <div class="col-md-4 form-group">
                            <label>Forwarded To:<span class="errormsg">*</span></label>
                            <asp:DropDownList ID="ddlForwarded_to" runat="server" CssClass="form-control" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlForwarded_to"
                                Display="Dynamic" ErrorMessage="Required!" SetFocusOnError="True" ValidationGroup="assethist" />
                        </div>
                            </div>
                        <div class="row">
                        <div class="col-md-6 form-group">
                            <label>Narration:</label>
                            <asp:TextBox ID="TxtNarration" runat="server" CssClass="form-control" TextMode="MultiLine" />
                        </div>
                        <div class="col-md-6 form-group">
                            <label>Reject Reason:</label>
                            <asp:TextBox ID="txtRejectionReason" runat="server" CssClass="form-control" TextMode="MultiLine" />
                        </div>
                            </div>
                       <br />
                            <asp:Button ID="Btn_Save" runat="server" CssClass="btn btn-primary" OnClick="Btn_Save_Click"
                                Text="Save" ValidationGroup="assethist" />
                            <asp:Button ID="btnDelete" runat="server" CssClass="btn btn-primary" OnClick="btnDelete_Click"
                                Text="Delete" />
                            <cc1:ConfirmButtonExtender ID="BtnDelete_ConfirmButtonExtender" runat="server" ConfirmText="Confirm To Delete ?"
                                Enabled="True" TargetControlID="btnDelete">
                            </cc1:ConfirmButtonExtender>
                            <asp:Button ID="BtnBack" runat="server" CssClass="btn btn-primary" Text="Back" />
                      
                    </div>
                </section>
            </div>
        </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
