<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AssetBranchAssignProduct.aspx.cs" Inherits="SwiftHrManagement.web.AssetParameters.AssetCreationV2.AssetBranchAssignProduct" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<title></title>
    <link href="../../ui/css/bootstrap.min.css" rel="stylesheet" />

    <script type="text/javascript">
        checked = false;
        function checkedAll(sss) {
            var aa = document.getElementById('form2');
            var b = document.getElementById('select');
            if (checked == false) {
                checked = true
                b.value = "Diselect All";
            }
            else {
                checked = false
                b.value = "select All";
            }
            for (var i = 0; i < aa.elements.length; i++) {
                aa.elements[i].checked = checked;
            }
        }
</script>

   <%-- <script type="text/javascript">
//        function CheckAll(obj) {
//            var a = document.form2.getElementById("ckID");
//            alert(a.length);
//            for (i = 0; i < a.length; i++) {
//                alert('asda');
//                a[i].checked = true;
//                }

//            //alert(obj); 
//           // document.getElementById("ckID").attributes("checked", true);
        //        }
        function CheckDAll() {
            var d = document.form2.ckID.length;
            for (k = 0; k < d; k++) {
                document.form2.ckID[k].checked = false;
            }
            return;
        }
        function CheckAll() {

            var i = document.form2.ckID.length;
            //alert(i);
            for (j = 0; j < i; j++) {
                document.form2.ckID[j].checked = true;
            }
            return;
        }
    </script>--%>

</head>
<body>


<form id="form2" runat="server"> 
    <asp:ScriptManager 
            ID="ScriptManager1" runat="server">
        </asp:ScriptManager>

   
<div class="panel">
    <header class="panel-heading">
         Asset Branch Assign in Product
    </header>
</div>
    <div class="panel">
        <div class="panel-body">
          <span class="txtlbl">Please enter valid data</span>
          <span class="required">(* Required fields)</span><br />
          <asp:Label ID="LblMsg" runat="server"></asp:Label> 
           <asp:HiddenField ID="HdnProduct" runat="server" />
        </div>
        <div class="panel-body">
            <div class="row ">
                <div class="col-md-4 form-group">
                    <label>
                        Product Name:
                    </label>
                        <asp:Label ID="lblproductName" runat="server" Text="Label"></asp:Label>
                </div>
                <div class="col-md-6 form-group">
                    <label>
                        Branch:  <span class="required">*</span>
                    </label>
                    <span class="errormsg">
                        <asp:DropDownList ID="DdlBranch" runat="server" CssClass="form-control"  >
                          </asp:DropDownList>
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                 ErrorMessage="Required!" ControlToValidate="DdlBranch" Display="Dynamic" 
                                 SetFocusOnError="True" ValidationGroup="Branch"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="row form-inline">
                <div class="col-md-4">
                    <label>
                        Asset A/C :
                    </label>
                </div>
                <div class="col-md-8">
                    <asp:TextBox ID="TxtAssetAcNo" runat="server" CssClass="form-control"></asp:TextBox>       
    <asp:TextBox ID="TxtAssetAc" runat="server" CssClass="form-control" 
     AutoComplete="off"></asp:TextBox>                                                                                                                                                                                                                                                                            
    <cc1:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server"
    DelimiterCharacters="" Enabled="true" ServicePath="~/Autocomplete.asmx" ServiceMethod="GetAccountList"
    TargetControlID="TxtAssetAc" MinimumPrefixLength="1" CompletionInterval="10"
    EnableCaching="true" CompletionListCssClass="autocompleteTextBoxLP" OnClientItemSelected="AutocompleteOnSelected_Asset">
    </cc1:AutoCompleteExtender>
    <cc1:TextBoxWatermarkExtender ID="TxtAssetHolder_TextBoxWatermarkExtender" 
    runat="server" Enabled="True" TargetControlID="TxtAssetAc" 
    WatermarkCssClass="form-control" WatermarkText="Auto Complete">
    </cc1:TextBoxWatermarkExtender>
                </div>
                <div class="col-md-4">
                    <label>
                        Depreciation Expence A/C :
                    </label>
                </div>
                <div class="col-md-8">
                     <asp:TextBox ID="TxtDepExpAcNo" runat="server" CssClass="form-control"></asp:TextBox>
    <asp:TextBox ID="TxtDepExpAc" runat="server" CssClass="form-control" 
    AutoComplete="off"></asp:TextBox>                                                                                                                                                                                                                                                                                                                                                                                                                      
    <cc1:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server"
    DelimiterCharacters="" Enabled="true" ServicePath="~/Autocomplete.asmx" ServiceMethod="GetAccountList"
    TargetControlID="TxtDepExpAc" MinimumPrefixLength="1" CompletionInterval="10"
    EnableCaching="true" CompletionListCssClass="autocompleteTextBoxLP" OnClientItemSelected="AutocompleteOnSelected_Depreciation" >
    </cc1:AutoCompleteExtender>
    <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" 
    runat="server" Enabled="True" TargetControlID="TxtDepExpAc" 
    WatermarkCssClass="form-control" WatermarkText="Auto Complete">
    </cc1:TextBoxWatermarkExtender>
                </div>
                <div class="col-md-4">
                    <label>
                        Accumulated Depreciation A/C : 
                    </label>
                </div>
                <div class="col-md-8">
                    <asp:TextBox ID="TxtAccuDepAcNo" runat="server" CssClass="form-control"></asp:TextBox>
    <asp:TextBox ID="TxtAccuDepAc" runat="server" CssClass="form-control" 
    AutoComplete="off"></asp:TextBox>                                                                                                                                                                                                                                                                                                                                                                                                                                                        
    <cc1:AutoCompleteExtender ID="AutoCompleteExtender3" runat="server"
    DelimiterCharacters="" Enabled="true" ServicePath="~/Autocomplete.asmx" ServiceMethod="GetAccountList"
    TargetControlID="TxtAccuDepAc" MinimumPrefixLength="1" CompletionInterval="10"
    EnableCaching="true" CompletionListCssClass="autocompleteTextBoxLP" OnClientItemSelected="AutocompleteOnSelected_Accumulated">
    </cc1:AutoCompleteExtender>
    <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender2" 
    runat="server" Enabled="True" TargetControlID="TxtAccuDepAc" 
    WatermarkCssClass="form-control" WatermarkText="Auto Complete">
    </cc1:TextBoxWatermarkExtender>
                </div>
                <div class="col-md-4">
                    <label>
                        Write-off A/C :
                    </label>
                </div>
                <div class="col-md-8">
                    <asp:TextBox ID="TxtWriteOffAcNo" runat="server" CssClass="form-control"></asp:TextBox>
    <asp:TextBox ID="TxtWriteOffAc" runat="server" CssClass="form-control" 
     AutoComplete="off"></asp:TextBox>                                                                                                                                                                                                                                                                                    
    <cc1:AutoCompleteExtender ID="AutoCompleteExtender4" runat="server"
    DelimiterCharacters="" Enabled="true" ServicePath="~/Autocomplete.asmx" ServiceMethod="GetAccountList"
    TargetControlID="TxtWriteOffAc" MinimumPrefixLength="1" CompletionInterval="10"
    EnableCaching="true" CompletionListCssClass="autocompleteTextBoxLP" OnClientItemSelected="AutocompleteOnSelected_Writeoff">
    </cc1:AutoCompleteExtender>
    <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender3" 
    runat="server" Enabled="True" TargetControlID="TxtWriteOffAc" 
    WatermarkCssClass="form-control" WatermarkText="Auto Complete">
    </cc1:TextBoxWatermarkExtender>  
                </div>
                <div class="col-md-4">
                    <label>
                        Sales Profit/Loss A/C :
                    </label>
                </div>
                <div class="col-md-8">
                    <asp:TextBox ID="TxtSalesPLAcNo" runat="server"  CssClass="form-control"></asp:TextBox>
    <asp:TextBox ID="TxtSalesPLAc" runat="server" CssClass="form-control" 
    AutoComplete="off"></asp:TextBox>                                                                                                                                                                                                                                                                                     
    <cc1:AutoCompleteExtender ID="AutoCompleteExtender5" runat="server"
    DelimiterCharacters="" Enabled="true" ServicePath="~/Autocomplete.asmx" ServiceMethod="GetAccountList"
    TargetControlID="TxtSalesPLAc" MinimumPrefixLength="1" CompletionInterval="10"
    EnableCaching="true" CompletionListCssClass="autocompleteTextBoxLP" OnClientItemSelected="AutocompleteOnSelected_ProfitLoss">
    </cc1:AutoCompleteExtender>
    <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender4" 
    runat="server" Enabled="True" TargetControlID="TxtSalesPLAc" 
    WatermarkCssClass="form-control" WatermarkText="Auto Complete">
    </cc1:TextBoxWatermarkExtender>  
                </div>
                <div class="col-md-4">
                    <label>
                        Maintainance Expence A/C : 
                    </label>
                </div>
                <div class="col-md-8">
                    <asp:TextBox ID="TxtMaintainExpAcNo" runat="server"  CssClass="form-control"></asp:TextBox>
    <asp:TextBox ID="TxtMaintainExpAc" runat="server" CssClass="form-control" 
   AutoComplete="off"></asp:TextBox>                                                                                                                                                                                                                                                                                   
    <cc1:AutoCompleteExtender ID="AutoCompleteExtender6" runat="server"
    DelimiterCharacters="" Enabled="true" ServicePath="~/Autocomplete.asmx" ServiceMethod="GetAccountList"
    TargetControlID="TxtMaintainExpAc" MinimumPrefixLength="1" CompletionInterval="10"
    EnableCaching="true" CompletionListCssClass="autocompleteTextBoxLP" OnClientItemSelected="AutocompleteOnSelected_Maintain">
    </cc1:AutoCompleteExtender>
    <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender5" 
    runat="server" Enabled="True" TargetControlID="TxtMaintainExpAc" 
    WatermarkCssClass="form-control" WatermarkText="Auto Complete">
    </cc1:TextBoxWatermarkExtender>   
                </div>
                <div class="col-md-12">
                    <label>
                        Is Active :<asp:DropDownList ID="DdlIsActive" runat="server" CssClass="form-control" 
    >
                             
    <asp:ListItem Value="True">Yes</asp:ListItem>
    <asp:ListItem Value="False">No</asp:ListItem>
    </asp:DropDownList>
                    </label>
                </div>
            </div>
             <asp:Button ID="BtnAdd" runat="server" CssClass="btn btn-primary" onclick="BtnAdd_Click" 
                                                        Text="Add" ValidationGroup="Branch"/>
            <br />
            <div class="row">
                <div class="col-md-12">
                <div id="rpt" runat="server" nowrap>
               <asp:Table ID="Table1" runat="server" Width="100%">
               </asp:Table>
                </div>
            </div>
           
                            </div>
             <asp:Panel ID="PnDelete" runat="server">
                                <div>
                                    <input type="button" name="select" id="select" value="Select All"  onclick="checkedAll(form2);" class="btn btn-primary"/>
                                    
                                    <asp:Button ID="BtnDelete" runat="server" CssClass="btn btn-primary" 
                                        onclick="BtnDelete_Click" Text="Delete"  />
                                        
                                    <cc1:ConfirmButtonExtender ID="BtnDelete_ConfirmButtonExtender" runat="server" 
                                        ConfirmText="Confirm To Delete ?" Enabled="True" TargetControlID="BtnDelete">
                                    </cc1:ConfirmButtonExtender>
                                   
                                </div>
                            </asp:Panel>
        </div>
    </div>
                                
    
</form>


</body>
<script language=javascript>
    function AutocompleteOnSelected_Asset(sender, e) {
        var customerValueArray = (e._value).split("|");
        //document.getElementById("lblAssetAc").value = customerValueArray[1];
        // document.getElementById("lblAssetAc").innerHTML = customerValueArray[1];
        //TxtAssetAcNo
        document.getElementById("TxtAssetAcNo").value = customerValueArray[1];
    }

    function AutocompleteOnSelected_Depreciation(sender, e) {
        var customerValueArray = (e._value).split("|");
        document.getElementById("TxtDepExpAcNo").value = customerValueArray[1];
    }

    function AutocompleteOnSelected_Accumulated(sender, e) {
        var customerValueArray = (e._value).split("|");
        document.getElementById("TxtAccuDepAcNo").value = customerValueArray[1];
    }

    function AutocompleteOnSelected_Writeoff(sender, e) {
        var customerValueArray = (e._value).split("|");
        document.getElementById("TxtWriteOffAcNo").value = customerValueArray[1];
    }

    function AutocompleteOnSelected_ProfitLoss(sender, e) {
        var customerValueArray = (e._value).split("|");
        document.getElementById("TxtSalesPLAcNo").value = customerValueArray[1];
    }

    function AutocompleteOnSelected_Maintain(sender, e) {
        var customerValueArray = (e._value).split("|");
        document.getElementById("TxtMaintainExpAcNo").value = customerValueArray[1];
    }
</script>
</html>