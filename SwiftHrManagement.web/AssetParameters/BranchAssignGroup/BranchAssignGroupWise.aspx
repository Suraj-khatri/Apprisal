<%@ Page Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="BranchAssignGroupWise.aspx.cs" Inherits="SwiftHrManagement.web.AssetParameters.BranchAssignGroup.BranchAssignGroupWise" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .form-inline .form-control {
    
    margin-top: 5px !important;
    </style>
   <script language="javascript" type="text/javascript">
       function AutocompleteOnSelected_Asset(sender, e) {
           var customerValueArray = (e._value).split("|");
           document.getElementById("<%=TxtAssetAcNo.ClientID%>").value = customerValueArray[1];
       }

       function AutocompleteOnSelected_Depreciation(sender, e) {
           var customerValueArray = (e._value).split("|");
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
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    <div class="row">
        <div class="col-md-10 col-md-offset-1">
            <div class="panel panel-default">
                 <asp:UpdatePanel ID="updatepanel1" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="LblMsg" runat="server"></asp:Label> 
                        <header class="panel-heading">
                            Group Wise Product Assign With Branch
                        </header>
                        <div class="panel-body"> 
                             <span class="txtlbl">Please enter valid data!</span><span class="required"> (* Required fields!) </span>
                            <label>&nbsp;</label>
                            <div class="row">         
                                <div class="col-md-4 form-group">
                                    <label>Group Name:<span class="required">*</span></label>
                                </div>
                                <div class="col-md-4 form-group">
                                    <asp:DropDownList ID="DdlGroup" runat="server" CssClass="form-control" AutoPostBack="True" 
                                         onselectedindexchanged="DdlGroup_SelectedIndexChanged"></asp:DropDownList>                                      
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Required!" 
                                        ControlToValidate="DdlGroup" Display="Dynamic" SetFocusOnError="True" ValidationGroup="Branch">
                                    </asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="row">         
                                <div class="col-md-4 form-group">
                                    <label>Asset Type: <span class="required">*</span></label>
                                </div>
                                <div class="col-md-4 form-group">
                                    <asp:DropDownList ID="assetType" runat="server" CssClass="form-control"></asp:DropDownList>                  
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Required!" 
                                        ControlToValidate="assetType" Display="Dynamic" SetFocusOnError="True" ValidationGroup="Branch">
                                    </asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="row"> 
                                <div class="col-md-4 form-group">
                                    <label>Branch Name: </label>
                                </div>
                                <div class="col-md-4 form-group">
                                    <asp:DropDownList ID="DdlBranch" runat="server" CssClass="form-control"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-4 form-group">
                                   <label>Asset A/C:</label>
                                </div>
                                <div class="col-md-4 form-group">
                                     <asp:TextBox ID="TxtAssetAcNo" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="col-md-4 form-group autocomplete-form">                         
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
                                <div class="col-md-4 form-group">
                                    <label>Depreciation Expence A/C:</label>
                                </div>
                               <div class="col-md-4 form-group">
                                   <asp:TextBox ID="TxtDepExpAcNo" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="col-md-4 form-group autocomplete-form">                    
                                    <asp:TextBox ID="TxtDepExpAc" runat="server" CssClass="form-control" AutoComplete="off"></asp:TextBox>                                                                                                                                                                                                                                                                                                                                                                                                                                         
                                    <cc1:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" DelimiterCharacters="" Enabled="true" 
                                        ServicePath="~/Autocomplete.asmx" ServiceMethod="GetAccountList" TargetControlID="TxtDepExpAc" 
                                        MinimumPrefixLength="1" CompletionInterval="10" EnableCaching="true" 
                                        CompletionListCssClass="autocompleteTextBoxLP" OnClientItemSelected="AutocompleteOnSelected_Depreciation">
                                    </cc1:AutoCompleteExtender>
                                    <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" runat="server" Enabled="True" 
                                        TargetControlID="TxtDepExpAc" WatermarkCssClass="form-control" WatermarkText="Auto Complete">
                                    </cc1:TextBoxWatermarkExtender>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-4 form-group">
                                    <label>Accumulated Depreciation A/C:</label>
                                </div>
                                <div class="col-md-4 form-group">
                                    <asp:TextBox ID="TxtAccuDepAcNo" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="col-md-4 form-group autocomplete-form">                    
                                    <asp:TextBox ID="TxtAccuDepAc" runat="server" CssClass="form-control"
                                       AutoComplete="off"></asp:TextBox>                                                                                                                                                                                                                                                                                                                                                                                                                                                                            
                                    <cc1:AutoCompleteExtender ID="AutoCompleteExtender3" runat="server"
                                        DelimiterCharacters="" Enabled="true" ServicePath="~/Autocomplete.asmx" ServiceMethod="GetAccountList"
                                        TargetControlID="TxtAccuDepAc" MinimumPrefixLength="1" CompletionInterval="10" EnableCaching="true" 
                                        CompletionListCssClass="autocompleteTextBoxLP" OnClientItemSelected="AutocompleteOnSelected_Accumulated">
                                     </cc1:AutoCompleteExtender>
                                     <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender2" runat="server" Enabled="True" 
                                         TargetControlID="TxtAccuDepAc" WatermarkCssClass="form-control" WatermarkText="Auto Complete">
                                     </cc1:TextBoxWatermarkExtender>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-4 form-group">
                                        <label>Write-off A/C :</label>
                                    </div>
                                    <div class="col-md-4 form-group">
                                        <asp:TextBox ID="TxtWriteOffAcNo" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                    <div class="col-md-4 form-group autocomplete-form">                        
                                        <asp:TextBox ID="TxtWriteOffAc" runat="server" CssClass="form-control" 
                                            AutoComplete="off"></asp:TextBox>                                                                                                                                                                                                                                                                                                    
                                         <cc1:AutoCompleteExtender ID="AutoCompleteExtender4" runat="server"
                                            DelimiterCharacters="" Enabled="true" ServicePath="~/Autocomplete.asmx" ServiceMethod="GetAccountList"
                                            TargetControlID="TxtWriteOffAc" MinimumPrefixLength="1" CompletionInterval="10"
                                            EnableCaching="true" CompletionListCssClass="autocompleteTextBoxLP" 
                                             OnClientItemSelected="AutocompleteOnSelected_Writeoff">
                                         </cc1:AutoCompleteExtender>
                                         <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender3" runat="server" Enabled="True" 
                                             TargetControlID="TxtWriteOffAc" WatermarkCssClass="form-control" WatermarkText="Auto Complete">
                                         </cc1:TextBoxWatermarkExtender>  
                                    </div>
                                </div>
                                <div class="row">
                                   <div class="col-md-4 form-group">
                                        <label>Sales Profit/Loss A/C:</label>
                                    </div>
                                    <div class="col-md-4 form-group">
                                        <asp:TextBox ID="TxtSalesPLAcNo" runat="server"  CssClass="form-control"></asp:TextBox>
                                    </div>
                                    <div class="col-md-4 form-group autocomplete-form">                        
                                        <asp:TextBox ID="TxtSalesPLAc" runat="server" CssClass="form-control" AutoComplete="off"></asp:TextBox>                                                                                                                                                                                                                                                                                                   
                                         <cc1:AutoCompleteExtender ID="AutoCompleteExtender5" runat="server" DelimiterCharacters="" 
                                             Enabled="true" ServicePath="~/Autocomplete.asmx" ServiceMethod="GetAccountList" 
                                             TargetControlID="TxtSalesPLAc" MinimumPrefixLength="1" CompletionInterval="10" EnableCaching="true" 
                                             CompletionListCssClass="autocompleteTextBoxLP" 
                                             OnClientItemSelected="AutocompleteOnSelected_ProfitLoss">
                                         </cc1:AutoCompleteExtender>
                                          <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender4" runat="server" Enabled="True" 
                                              TargetControlID="TxtSalesPLAc" WatermarkCssClass="form-control" WatermarkText="Auto Complete">
                                         </cc1:TextBoxWatermarkExtender>  
                                    </div>
                                </div>        
                               <div class="row">
                                   <div class="col-md-4 form-group">
                                        <label> Maintainance Expence A/C:</label>
                                    </div>
                                   <div class="col-md-4 form-group">
                                       <asp:TextBox ID="TxtMaintainExpAcNo" runat="server"  CssClass="form-control"></asp:TextBox>
                                    </div>
                                    <div class="col-md-4 form-group autocomplete-form">                        
                                        <asp:TextBox ID="TxtMaintainExpAc" runat="server" CssClass="form-control" 
                                            AutoComplete="off"></asp:TextBox>                                                                                                                                                                                                                                                                                                      
                                         <cc1:AutoCompleteExtender ID="AutoCompleteExtender6" runat="server"
                                            DelimiterCharacters="" Enabled="true" ServicePath="~/Autocomplete.asmx" ServiceMethod="GetAccountList"
                                            TargetControlID="TxtMaintainExpAc" MinimumPrefixLength="1" CompletionInterval="10"
                                            EnableCaching="true" CompletionListCssClass="autocompleteTextBoxLP" 
                                             OnClientItemSelected="AutocompleteOnSelected_Maintain">
                                         </cc1:AutoCompleteExtender>
                                         <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender5" 
                                                runat="server" Enabled="True" TargetControlID="TxtMaintainExpAc" 
                                                WatermarkCssClass="form-control" WatermarkText="Auto Complete">
                                         </cc1:TextBoxWatermarkExtender>  
                                    </div>
                                </div>  
                                <div class="row">                      
                                    <div class="col-md-4 form-group">
                                        <label> Is Active : <span class="required">*</span></label>
                                    </div>
                                    <div class="col-md-2 form-group">
                                        <asp:DropDownList ID="DdlIsActive" runat="server" CssClass="form-control">
                                            <asp:ListItem Value="True">Yes</asp:ListItem>
                                            <asp:ListItem Value="False">No</asp:ListItem>
                                        </asp:DropDownList>                    
                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                              ErrorMessage="Required!" ControlToValidate="DdlIsActive" Display="Dynamic" 
                                              SetFocusOnError="True" ValidationGroup="Branch"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary" Text="Save" ValidationGroup="Branch"  
                                    onclick="btnSave_Click" />
                            </div>
                        </ContentTemplate>
                     </asp:UpdatePanel>
                </div>
            </div>
        </div>
</asp:Content>

