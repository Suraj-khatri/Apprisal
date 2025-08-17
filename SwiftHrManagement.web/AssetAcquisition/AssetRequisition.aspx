<%@ Page Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true"
    CodeBehind="AssetRequisition.aspx.cs" Inherits="SwiftAssetManagement.AssetMovement.AssetRequisition" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script language="javascript" type="text/javascript">
        function GetEmpID(sender, e) {
            var customerValueArray = (e._value).split("|");
            document.getElementById("<%=hdnEmpId.ClientID %>").value = customerValueArray[1];
        }
        function AutocompleteOnSelected(sender, e) {
            var customerValueArray = (e._value).split("|");
            document.getElementById("<%=hdnAssetId.ClientID %>").value = customerValueArray[1];
        }

    </script>
    <script language="javascript" type="text/javascript">
        function searchProduct() {
            childWindow = window.open("../Item/ProductSearch.aspx", "mywindow", "menubar=0,resizable=0,width=750,height=350,align=center");
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    <div class="row">
        <div class="col-md-10 col-md-offset-1">
             <section class="panel">
            <header class="panel-heading">
                <i class="fa fa-caret-right"></i>
                          Asset Requisition Details
                        </header>
            <div class="panel-body">
                <label>Asset requisition Entry</label>
                <asp:UpdatePanel ID="updatepanel1" runat="server">
                    <ContentTemplate>
                        <div class="form-group">
                            <span>Please enter valid data</span>&nbsp;
            <span class="required">(* Required fields)</span><br />
                            <asp:Label ID="LblMsg" runat="server"></asp:Label>
                            <asp:HiddenField ID="hdnMessageId" runat="server" />
                        </div>
                        <label>Asset Information:</label>
                        <asp:HiddenField ID="hdnAssetId" runat="server" />
                        <div class="row">
                            <div class="col-md-4">
                                <div class="form-group autocomplete-form">
                                    <label>Asset Type:</label>
                                     <cc1:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server"
                                         DelimiterCharacters="" Enabled="true" ServicePath="~/Autocomplete.asmx" ServiceMethod="GetAssetType"
                                         TargetControlID="asset" MinimumPrefixLength="1" CompletionInterval="10"
                                         EnableCaching="true" CompletionListCssClass="autocompleteTextBoxLP" OnClientItemSelected="AutocompleteOnSelected">
                                     </cc1:AutoCompleteExtender>
                                    <asp:TextBox ID="asset" runat="server" AutoComplete="off"
                                        CssClass="form-control"></asp:TextBox>
                                    <cc1:TextBoxWatermarkExtender ID="asset_TextBoxWatermarkExtender"
                                        runat="server" Enabled="True" TargetControlID="asset"
                                        WatermarkCssClass="watermark" WatermarkText="Auto Complete">
                                    </cc1:TextBoxWatermarkExtender>
                                </div>
                            </div>
                            <div class="col-md-3">
                                <div class="form-group">
                                    <label>Qty:</label>
                                    <asp:TextBox ID="qty" name="qty" runat="server"
                                        CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-3">
                                <div class="form-group">
                                    <label>Tentative Price:</label>
                          <asp:TextBox ID="amount" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-2">
                                <div class="form-group" >
                                    <label>&nbsp;</label><br />
                                    <asp:Button ID="BtnAdd" runat="server" CssClass="btn btn-primary " Text="Add"
                                        OnClick="BtnAdd_Click" style="float:right"/>
                                </div>
                            </div>
                            <div class="col-md-12">
                                <div id="rpt" runat="server"></div>
                                <asp:Button ID="BtnDelProduct" runat="server" Text="Delete" CssClass="btn btn-primary"  OnClick="BtnDelProduct_Click" style="float:right"/>
                            </div>
                            <div class="form-group">
                                
                            </div>
                        </div>
                        <label>Order Information:</label>
                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>Forwarded Branch: <span class="errormsg">*</span></label>
                                    <asp:RequiredFieldValidator ID="rfc1" runat="server"
                                        ControlToValidate="branchname"
                                        ErrorMessage="Required" SetFocusOnError="True"
                                        ValidationGroup="req"></asp:RequiredFieldValidator>
                                    <asp:DropDownList ID="branchname" runat="server" CssClass="form-control">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-md-3">
                                <div class="form-group">
                                    <label> Priority: </label><asp:RequiredFieldValidator ID="rfc3" runat="server"
                                        ControlToValidate="Ddlpriority" ErrorMessage="Required" SetFocusOnError="True"
                                        ValidationGroup="req"></asp:RequiredFieldValidator>
                                    <asp:DropDownList ID="Ddlpriority" runat="server" CssClass="form-control">
                                        <asp:ListItem Value="Normal">Normal</asp:ListItem>
                                        <asp:ListItem Value="Low">Low</asp:ListItem>
                                        <asp:ListItem Value="High">High</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-md-3">
                                <div class="form-group autocomplete-form">
                                    <label>Forwarded To:  <span class="errormsg">*</span></label>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                        ErrorMessage="Required" ControlToValidate="forwardedto"
                                        SetFocusOnError="True" ValidationGroup="req"></asp:RequiredFieldValidator>

                                    <cc1:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server"
                                        DelimiterCharacters="" Enabled="true" ServicePath="~/Autocomplete.asmx" ServiceMethod="GetEmployeeList"
                                        TargetControlID="forwardedto" MinimumPrefixLength="1" CompletionInterval="10"
                                        EnableCaching="true" CompletionListCssClass="autocompleteTextBoxLP"
                                        OnClientItemSelected="GetEmpID">
                                    </cc1:AutoCompleteExtender>

                                    <asp:TextBox ID="forwardedto" runat="server"
                                        CssClass="form-control" AutoComplete="off"></asp:TextBox>&nbsp;
                            <cc1:TextBoxWatermarkExtender ID="forwardedto_TextBoxWatermarkExtender"
                                runat="server" Enabled="True" TargetControlID="forwardedto"
                                WatermarkCssClass="watermark" WatermarkText="Auto Complete">
                            </cc1:TextBoxWatermarkExtender>
                                    <asp:HiddenField ID="hdnEmpId" runat="server" />
                                </div>
                            </div>
                            <div class="col-md-12">
                                <div class="form-group">
                                    <label>Message:<span class="required">*</span></label>
                                    <asp:RequiredFieldValidator
                                        ID="rfc4" runat="server" ControlToValidate="narration"
                                        ErrorMessage="Required" SetFocusOnError="True"
                                        ValidationGroup="req"></asp:RequiredFieldValidator>


                                    <asp:TextBox ID="narration"
                                        CssClass="form-control" runat="server" 
                                        TextMode="MultiLine"></asp:TextBox>
                                </div>
                            </div>
                          <br/>
                            <div class="col-md-12">
                                <div class="form-group">
                                    <asp:Button ID="BtnSave" runat="server" Text="Save Requisition" CssClass="btn btn-primary"
                                        OnClick="BtnSave_Click" ValidationGroup="req" />
                                    <asp:Button ID="BtnDelete" runat="server" Text="Refresh"
                                        CssClass="btn btn-primary" OnClick="BtnDelete_Click" />
                                </div>
                            </div>
                    </ContentTemplate>
                </asp:UpdatePanel>

            </div>
            </section>
        </div>
    </div>





</asp:Content>
