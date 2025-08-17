<%@ Page Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="BranchProdSetup.aspx.cs"
    Inherits="SwiftAssetManagement.AssetParameters.Item.BranchProdSetup" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    <asp:UpdatePanel ID="updatepanel1" runat="server">
        <%-- <asp:UpdatePanel ID="upd" runat="server">--%>
        <ContentTemplate>

            <section class="panel">
                    <header class="panel-heading">
                        <i class="fa fa-caret-right"></i>
                        Branch Product Setup
                    </header>
                        <div class="panel-body">
                            <div class="row">
                                <div class="col-md-12 form-group">
                                    <label>Branch Product Setup</label>
                                    <span class="txtlbl">Please enter valid data</span><br />
                                    <span class="required">(* Required fields)</span><br />
                                    <asp:Label ID="LblMsg" runat="server"></asp:Label>
                                    <asp:HiddenField ID = "hdnitem" runat="server" />
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-3 form-group">
                                    <label>Product Name:</label>
                                </div>
                                <div class="col-md-4 form-group">
                                    <asp:Label ID="Product" runat="server"></asp:Label>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-3 form-group">
                                    <label>Branch:</label><span class="errormsg">*</span>
                                </div>
                                <div class="col-md-9 form-group">
                                    <asp:DropDownList ID="DdlBranch" runat="server" CssClass="form-control">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-3 form-group">
                                    <label>Asset A/C:</label>
                                </div>
                                <div class="col-md-4 form-group">
                                    <asp:TextBox ID="TxtAssetAcNo" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="col-md-5 form-group">
                                    <asp:TextBox ID="TxtAssetAc" runat="server" CssClass="form-control" AutoComplete="off"></asp:TextBox>                                                                                                                                                                                                                                                                            
                                    <cc1:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" DelimiterCharacters="" Enabled="true" 
                                        ServicePath="~/Autocomplete.asmx" ServiceMethod="GetAccountList" TargetControlID="TxtAssetAc" 
                                        MinimumPrefixLength="1" CompletionInterval="10" EnableCaching="true" 
                                        CompletionListCssClass="autocompleteTextBoxLP" OnClientItemSelected="AutocompleteOnSelected_Asset">
                                    </cc1:AutoCompleteExtender>
                                    <cc1:TextBoxWatermarkExtender ID="TxtAssetHolder_TextBoxWatermarkExtender" runat="server" Enabled="True" 
                                        TargetControlID="TxtAssetAc" WatermarkCssClass="form-control" WatermarkText="Auto Complete">
                                    </cc1:TextBoxWatermarkExtender>   
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-3 form-group">
                                    <label>Depreciation Expence A/C:</label>
                                </div>
                                <div class="col-md-4 form-group">
                                    <asp:TextBox ID="TxtDepExpAcNo" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="col-md-5 form-group">
                                    <asp:TextBox ID="TxtDepExpAc" runat="server" CssClass="form-control" AutoComplete="off"></asp:TextBox>                                                                                                                                                                                                                                                                                                                                                                                                                      
                                    <cc1:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" DelimiterCharacters="" Enabled="true" 
                                        ServicePath="~/Autocomplete.asmx" ServiceMethod="GetAccountList" TargetControlID="TxtDepExpAc"
                                         MinimumPrefixLength="1" CompletionInterval="10" EnableCaching="true" 
                                        CompletionListCssClass="autocompleteTextBoxLP" OnClientItemSelected="AutocompleteOnSelected_Depreciation" >
                                    </cc1:AutoCompleteExtender>
                                    <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" runat="server" Enabled="True" 
                                        TargetControlID="TxtDepExpAc" WatermarkCssClass="form-control" WatermarkText="Auto Complete">
                                    </cc1:TextBoxWatermarkExtender>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-3 form-group">
                                    <label>Accumulated Depreciation A/C:</label>
                                </div>
                                <div class="col-md-4 form-group">
                                    <asp:TextBox ID="TxtAccuDepAcNo" runat="server" CssClass="form-control"></asp:TextBox>
                                    
                                </div>
                                <div class="col-md-5 form-group">
                                    <asp:TextBox ID="TxtAccuDepAc" runat="server" CssClass="form-control" AutoComplete="off"></asp:TextBox>                                                                                                                                                                                                                                                                                                                                                                                                                                                        
                                    <cc1:AutoCompleteExtender ID="AutoCompleteExtender3" runat="server" DelimiterCharacters="" Enabled="true" 
                                        ServicePath="~/Autocomplete.asmx" ServiceMethod="GetAccountList" TargetControlID="TxtAccuDepAc" 
                                        MinimumPrefixLength="1" CompletionInterval="10" EnableCaching="true" 
                                        CompletionListCssClass="autocompleteTextBoxLP" OnClientItemSelected="AutocompleteOnSelected_Accumulated">
                                    </cc1:AutoCompleteExtender>
                                    <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender2" runat="server" Enabled="True" 
                                        TargetControlID="TxtAccuDepAc" WatermarkCssClass="form-control" WatermarkText="Auto Complete">
                                    </cc1:TextBoxWatermarkExtender>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-3 form-group">
                                    <label>Write-off A/C :</label>
                                </div>
                                <div class="col-md-4 form-group">
                                    <asp:TextBox ID="TxtWriteOffAcNo" runat="server" CssClass="form-control"></asp:TextBox>
                                    
                                </div>
                                <div class="col-md-5 form-group">
                                    <asp:TextBox ID="TxtWriteOffAc" runat="server" CssClass="form-control" AutoComplete="off"></asp:TextBox>                                                                                                                                                                                                                                                                                    
                                    <cc1:AutoCompleteExtender ID="AutoCompleteExtender4" runat="server" DelimiterCharacters="" Enabled="true" 
                                        ServicePath="~/Autocomplete.asmx" ServiceMethod="GetAccountList" TargetControlID="TxtWriteOffAc" 
                                        MinimumPrefixLength="1" CompletionInterval="10" EnableCaching="true" 
                                        CompletionListCssClass="autocompleteTextBoxLP" OnClientItemSelected="AutocompleteOnSelected_Writeoff">
                                    </cc1:AutoCompleteExtender>
                                    <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender3" runat="server" Enabled="True" 
                                        TargetControlID="TxtWriteOffAc" WatermarkCssClass="form-control" WatermarkText="Auto Complete">
                                    </cc1:TextBoxWatermarkExtender> 
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-3 form-group">
                                    <label>Sales Profit/Loss A/C :</label>
                                </div>
                                <div class="col-md-4 form-group">
                                    <asp:TextBox ID="TxtSalesPLAcNo" runat="server"  CssClass="form-control"></asp:TextBox>
                                    
                                </div>
                                <div class="col-md-5 form-group">
                                    <asp:TextBox ID="TxtSalesPLAc" runat="server" CssClass="form-control" AutoComplete="off"></asp:TextBox>                                                                                                                                                                                                                                                                                     
                                    <cc1:AutoCompleteExtender ID="AutoCompleteExtender5" runat="server" DelimiterCharacters="" Enabled="true" 
                                        ServicePath="~/Autocomplete.asmx" ServiceMethod="GetAccountList" TargetControlID="TxtSalesPLAc" 
                                        MinimumPrefixLength="1" CompletionInterval="10" EnableCaching="true" 
                                        CompletionListCssClass="autocompleteTextBoxLP" OnClientItemSelected="AutocompleteOnSelected_ProfitLoss">
                                    </cc1:AutoCompleteExtender>
                                    <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender4" runat="server" Enabled="True" 
                                        TargetControlID="TxtSalesPLAc" WatermarkCssClass="form-control" WatermarkText="Auto Complete">
                                    </cc1:TextBoxWatermarkExtender> 
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-3 form-group">
                                    <label>Maintainance Expence A/C :</label>
                                </div>
                                <div class="col-md-4 form-group">
                                    <asp:TextBox ID="TxtMaintainExpAcNo" runat="server"  CssClass="form-control"></asp:TextBox>
                                    
                                </div>
                                <div class="col-md-5 form-group">
                                    <asp:TextBox ID="TxtMaintainExpAc" runat="server" CssClass="form-control" AutoComplete="off"></asp:TextBox>                                                                                                                                                                                                                                                                                   
                                    <cc1:AutoCompleteExtender ID="AutoCompleteExtender6" runat="server" DelimiterCharacters="" Enabled="true" 
                                        ServicePath="~/Autocomplete.asmx" ServiceMethod="GetAccountList" TargetControlID="TxtMaintainExpAc" 
                                        MinimumPrefixLength="1" CompletionInterval="10" EnableCaching="true"  
                                        CompletionListCssClass="autocompleteTextBoxLP" OnClientItemSelected="AutocompleteOnSelected_Maintain">
                                    </cc1:AutoCompleteExtender>
                                    <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender5" runat="server" Enabled="True" 
                                        TargetControlID="TxtMaintainExpAc" WatermarkCssClass="form-control" WatermarkText="Auto Complete">
                                    </cc1:TextBoxWatermarkExtender>
                                </div>
                            </div>
                             <div class="row">
                                <div class="col-md-3 form-group">
                                    <label>Is Active :</label>
                                </div>
                                <div class="col-md-4 form-group">
                                    <asp:DropDownList ID="DdlIsActive" runat="server" CssClass="form-control" >
                                        <asp:ListItem Value="True">Yes</asp:ListItem>
                                        <asp:ListItem Value="False">No</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="col-md-5 form-group">
                                    
                                </div>
                            </div>
                             <div class="row">
                                <div class="col-md-2 form-group">
                                    <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary" onclick="btnSave_Click" Text="Save" 
                                            ValidationGroup="product" />
                                    <cc1:ConfirmButtonExtender ID="btnSave_ConfirmButtonExtender" runat="server" ConfirmText="Confirm To Save?" 
                                        Enabled="True" TargetControlID="btnSave">
                                    </cc1:ConfirmButtonExtender>    
                                    <asp:Button ID="BtnBack" runat="server" CssClass="btn btn-primary" Text="Back" onclick="BtnBack_Click" />  
                                </div>
                            </div>
                            </div>
                    
                    </section>

        </ContentTemplate>
    </asp:UpdatePanel>

    <script language="javascript" type="text/javascript">

        function AutocompleteOnSelected_Asset(sender, e) {
            var customerValueArray = (e._value).split("|");
            //        document.getElementById("<%=TxtAssetAcNo.ClientID%>").Value = EmpIdArray[1];
            document.getElementById("<%=TxtAssetAcNo.ClientID%>").value = customerValueArray[1];
        }

        function AutocompleteOnSelected_Depreciation(sender, e) {
            var customerValueArray = (e._value).split("|");
            //        document.getElementById("<%=TxtDepExpAcNo.ClientID%>").Value = EmpIdArray[1];
            document.getElementById("<%=TxtDepExpAcNo.ClientID%>").value = customerValueArray[1];
        }

        function AutocompleteOnSelected_Accumulated(sender, e) {
            var customerValueArray = (e._value).split("|");
            document.getElementById("<%=TxtAccuDepAcNo.ClientID%>").value = customerValueArray[1];
        }

        function AutocompleteOnSelected_Writeoff(sender, e) {
            var customerValueArray = (e._value).split("|");
            document.getElementById("<%=TxtWriteOffAcNo.ClientID%>").value = customerValueArray[1];
        }

        function AutocompleteOnSelected_ProfitLoss(sender, e) {
            var customerValueArray = (e._value).split("|");
            document.getElementById("<%=TxtSalesPLAcNo.ClientID%>").value = customerValueArray[1];
    }

    function AutocompleteOnSelected_Maintain(sender, e) {
        var customerValueArray = (e._value).split("|");
        document.getElementById("<%=TxtMaintainExpAcNo.ClientID%>").value = customerValueArray[1];
    }

    </script>
</asp:Content>
