<%@ Page Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="BranchProdSetup.aspx.cs" Inherits="SwiftSalesManagement.Inventory.Item.BranchProdSetup" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">


    <div class="row">
        <div class="col-md-10 col-md-offset-1">
            <section class="panel panel-default">
                <asp:UpdatePanel ID="updatepanel1" runat="server">
                    <ContentTemplate>
                        <header class="panel-heading"> 
                            Branch Product Setup
                        </header>
                        <div class="panel-body">                            
                            <span class="txtlbl">Please enter valid data!</span><span class="required"> (* Required fields!) </span>
                            <asp:Label ID="LblMsg" runat="server" Width="100%"></asp:Label>
                            <asp:HiddenField ID="hdnitem" runat="server" />                           
                            <div class="form-group">
                                <label>Product Name:</label>
                               <asp:Label ID="Product" runat="server" Width="100%"></asp:Label>
                            </div>                            
                            <div class="row">
                                <div class="col-md-3 form-group">
                                    <label>Branch:</label><span class="errormsg">*</span>
                                </div>
                                <div class="col-md-4 form-group">
                                    <asp:DropDownList ID="DdlBranch" runat="server" CssClass="form-control"></asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="Rfvitem" runat="server"
                                        ControlToValidate="DdlBranch" Display="Dynamic" ErrorMessage="Requried!"
                                        SetFocusOnError="True" ValidationGroup="product">
                                    </asp:RequiredFieldValidator>
                                </div>
                            </div>                 
                            <div class="row">
                                <div class="col-md-3 form-group">
                                    <label>Sales A/C:</label>
                                </div>
                                <div class="col-md-4 form-group">
                                    <asp:TextBox ID="TxtSalesAcNo" runat="server" CssClass="form-control"></asp:TextBox> 
                                </div>   
                                <div class="col-md-5 form-group autocomplete-form">
                                    <asp:TextBox ID="TxtSalesAc" runat="server" CssClass="form-control" AutoComplete="off"></asp:TextBox>
                                    <cc1:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" DelimiterCharacters="" Enabled="true" ServicePath="~/Autocomplete.asmx" ServiceMethod="GetAccountList"
                                        TargetControlID="TxtSalesAc" MinimumPrefixLength="1" CompletionInterval="10"
                                        EnableCaching="true" CompletionListCssClass="autocompleteTextBoxLP" OnClientItemSelected="AutocompleteOnSelected_Sales">
                                    </cc1:AutoCompleteExtender>
                                    <cc1:TextBoxWatermarkExtender ID="TxtSalesHolder_TextBoxWatermarkExtender"
                                        runat="server" Enabled="True" TargetControlID="TxtSalesAc"
                                        WatermarkCssClass="form-control" WatermarkText="Auto Complete">
                                    </cc1:TextBoxWatermarkExtender>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-3 form-group">
                                    <label>Expenses A/C:</label>
                                </div>
                                <div class="col-md-4 form-group">
                                    <asp:TextBox ID="TxtPurchaseAcNo" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="col-md-5 form-group autocomplete-form">
                                    <asp:TextBox ID="TxtPurchaseAc" runat="server" CssClass="form-control" 
                                        AutoComplete="off" Width="100%"></asp:TextBox>
                                    <cc1:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" DelimiterCharacters="" 
                                        Enabled="true" ServicePath="~/Autocomplete.asmx" ServiceMethod="GetAccountList"
                                        TargetControlID="TxtPurchaseAc" MinimumPrefixLength="1" CompletionInterval="10"
                                        EnableCaching="true" CompletionListCssClass="autocompleteTextBoxLP" 
                                        OnClientItemSelected="AutocompleteOnSelected_Depreciation">
                                    </cc1:AutoCompleteExtender>
                                    <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" runat="server" Enabled="True" 
                                        TargetControlID="TxtPurchaseAc" WatermarkCssClass="form-control" WatermarkText="Auto Complete">
                                    </cc1:TextBoxWatermarkExtender>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-3 form-group">
                                     <label>Stock A/C:</label>
                                </div>
                                <div class="col-md-4 form-group">                                      
                                    <asp:TextBox ID="TxtInventoryAcNo" runat="server" CssClass="form-control" Width="100%"></asp:TextBox>
                                </div>                            
                                <div class="col-md-5 form-group autocomplete-form">
                                    <asp:TextBox ID="TxtInventoryAc" runat="server" CssClass="form-control" AutoComplete="off"></asp:TextBox>
                                    <cc1:AutoCompleteExtender ID="AutoCompleteExtender3" runat="server" DelimiterCharacters=""
                                        Enabled="true" ServicePath="~/Autocomplete.asmx" ServiceMethod="GetAccountList"
                                        TargetControlID="TxtInventoryAc" MinimumPrefixLength="1" CompletionInterval="10"
                                        EnableCaching="true" CompletionListCssClass="autocompleteTextBoxLP" 
                                        OnClientItemSelected="AutocompleteOnSelected_Accumulated">
                                    </cc1:AutoCompleteExtender>
                                    <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender2" runat="server" Enabled="True" 
                                        TargetControlID="TxtInventoryAc" WatermarkCssClass="form-control" 
                                        WatermarkText="Auto Complete">
                                    </cc1:TextBoxWatermarkExtender>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-3 form-group">
                                    <label>Commission A/C:</label>
                                </div>                                    
                                <div class="col-md-4 form-group">                                        
                                    <asp:TextBox ID="TxtCommisionAcNo" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="col-md-5 form-group autocomplete-form">
                                    <asp:TextBox ID="TxtCommisionAc" runat="server" CssClass="form-control" 
                                        AutoComplete="off"></asp:TextBox>
                                    <cc1:AutoCompleteExtender ID="AutoCompleteExtender4" runat="server" DelimiterCharacters=""
                                        Enabled="true" ServicePath="~/Autocomplete.asmx" ServiceMethod="GetAccountList"
                                        TargetControlID="TxtCommisionAc" MinimumPrefixLength="1" CompletionInterval="10"
                                        EnableCaching="true" CompletionListCssClass="autocompleteTextBoxLP" 
                                        OnClientItemSelected="AutocompleteOnSelected_Writeoff">
                                    </cc1:AutoCompleteExtender>
                                    <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender3" runat="server" 
                                        Enabled="True" TargetControlID="TxtCommisionAc" WatermarkCssClass="form-control" 
                                        WatermarkText="Auto Complete">
                                    </cc1:TextBoxWatermarkExtender>
                                 </div>
                            </div>
                            <div class="row">
                                <div class="col-md-3 form-group">
                                    <label>Re-Order Level:</label>
                                </div>
                                <div class="col-md-4 form-group">
                                    <asp:TextBox ID="TxtReorderLevel" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-3 form-group">
                                    <label>Re-Order Qty:</label>
                                </div>
                                <div class="col-md-4 form-group">
                                    <asp:TextBox ID="txtReorderQty" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-3 form-group">
                                    <label>Max Holding Qty:</label>
                                </div>
                                <div class="col-md-4 form-group">
                                    <asp:TextBox ID="txtMaxHoldingQty" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-3 form-group">
                                    <label>Is Active:</label>
                                </div>
                                <div class="col-md-2 form-group">
                                    <asp:DropDownList ID="DdlIsActive" runat="server" CssClass="form-control" >
                                        <asp:ListItem Value="True">Yes</asp:ListItem>
                                        <asp:ListItem Value="False">No</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-4 form-group">
                                    <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary" OnClick="btnSave_Click" 
                                        Text="Save" ValidationGroup="product" />
                                    <cc1:ConfirmButtonExtender ID="btnSave_ConfirmButtonExtender" runat="server"
                                        ConfirmText="Confirm To Save?" Enabled="True" TargetControlID="btnSave">
                                    </cc1:ConfirmButtonExtender>&nbsp;
                                    <asp:Button ID="BtnBack" runat="server" CssClass="btn btn-primary" Text="Back" />
                                </div>
                            </div>
                       </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </section>
        </div>
    </div>

    <script language="javascript" type="text/javascript">

        function AutocompleteOnSelected_Sales(sender, e) {
            var customerValueArray = (e._value).split("|");
            document.getElementById("TxtSalesAcNo").value = customerValueArray[1];
        }

        function AutocompleteOnSelected_Depreciation(sender, e) {
            var customerValueArray = (e._value).split("|");
            document.getElementById("TxtPurchaseAcNo").value = customerValueArray[1];
        }

        function AutocompleteOnSelected_Accumulated(sender, e) {
            var customerValueArray = (e._value).split("|");
            document.getElementById("TxtInventoryAcNo").value = customerValueArray[1];
        }

        function AutocompleteOnSelected_Writeoff(sender, e) {
            var customerValueArray = (e._value).split("|");
            document.getElementById("TxtCommisionAcNo").value = customerValueArray[1];
        }


    </script>
</asp:Content>
