<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BranchAssignProduct.aspx.cs" Inherits="SwiftHrManagement.web.Inventory.Branch_And_Product_Assign.BranchAssignProduct" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<title></title>
        <link href="~/ui/css/style.css" rel="stylesheet" />
    <link href="~/ui/css/style-responsive.css" rel="stylesheet" />
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
    <%--<script type="text/javascript">
        function checksel() {
            var cs = document.form2.ckID.length;
            for (j = 0; j < cs; j++) {
                document.form2.ckID[j].checked = true;
            }
        }
        function checkDsel() {
            var ds = document.form2.ckID.length;
            for (i = 0; i < ds; i++) {
                document.form2.ckID[i].checked = false;
            }
        }
    </script>--%>

</head>
<body>


<form id="form2" runat="server">
 
<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
<asp:HiddenField ID="HdnProduct" runat="server" /> 
    <div class="row">
        <div class="col-md-12">
            <section class="panel">
        <header class="panel-heading">Branch assign in product</header>
        <div class="panel-body">
            <div class="form-group">
                <label>Product Name:</label>
                <strong><asp:Label ID="lblproductName" runat="server" Text="Label"></asp:Label></strong>
            </div>
            <div class="row">
                <div class="col-md-6">
                    <div class="form-group">
                <label>Branch:</label>
                 <asp:DropDownList ID="DdlBranch" runat="server" CssClass="form-control" ></asp:DropDownList>   
            </div>
                </div>
            </div>
            
            <div class="row">
                    <div class="col-sm-6">
                        <div class="form-group">
                            <label>Sales A/C:</label>
                            <asp:TextBox ID="TxtSalesAcNo" runat="server" CssClass="form-control"></asp:TextBox>

                        </div>
                    </div>
                    <div class="col-sm-6">
                        <div class="form-group autocomplete-form">
                            <label>&nbsp;</label>
                           <asp:TextBox ID="TxtSalesAc" runat="server" CssClass="form-control"  AutoComplete="off"></asp:TextBox>                                                                                                                                                                                                                                                                            
                            <cc1:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server"
                            DelimiterCharacters="" Enabled="true" ServicePath="~/Autocomplete.asmx" ServiceMethod="GetAccountList"
                            TargetControlID="TxtSalesAc" MinimumPrefixLength="1" CompletionInterval="10"
                            EnableCaching="true" CompletionListCssClass="autocompleteTextBoxLP" OnClientItemSelected="AutocompleteOnSelected_Sales">
                            </cc1:AutoCompleteExtender>
                            <cc1:TextBoxWatermarkExtender ID="TxtSalesHolder_TextBoxWatermarkExtender" 
                                runat="server" Enabled="True" TargetControlID="TxtSalesAc" 
                                WatermarkCssClass="form-control" WatermarkText="Auto Complete">
                            </cc1:TextBoxWatermarkExtender>     
                        </div>
                    </div>
            </div>
            <div class="row">
                    <div class="col-sm-6">
                        <div class="form-group">
                            <label>Purchase A/C:</label>
                            <asp:TextBox ID="TxtPurchaseAcNo" runat="server" CssClass="form-control"></asp:TextBox>

                        </div>
                    </div>
                    <div class="col-sm-6">
                        <div class="form-group autocomplete-form">
                            <label>&nbsp;</label>
                           <asp:TextBox ID="TxtPurchaseAc" runat="server" CssClass="form-control"  AutoComplete="off"></asp:TextBox>                                                                                                                                                                                                                                                                                                                                                                                                                      
                            <cc1:AutoCompleteExtender ID="AutoCompleteExtender3" runat="server"
                                DelimiterCharacters="" Enabled="true" ServicePath="~/Autocomplete.asmx" ServiceMethod="GetAccountList"
                                TargetControlID="TxtPurchaseAc" MinimumPrefixLength="1" CompletionInterval="10"
                                EnableCaching="true" CompletionListCssClass="autocompleteTextBoxLP" OnClientItemSelected="AutocompleteOnSelected_Depreciation" >
                            </cc1:AutoCompleteExtender>
                            <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" 
                                runat="server" Enabled="True" TargetControlID="TxtPurchaseAc" 
                                WatermarkCssClass="form-control" WatermarkText="Auto Complete">
                            </cc1:TextBoxWatermarkExtender>     
                        </div>
                    </div>
            </div>
            <div class="row">
                    <div class="col-sm-6">
                        <div class="form-group">
                            <label>Inventory A/C:</label>
                            <asp:TextBox ID="TxtInventoryAcNo" runat="server" CssClass="form-control"></asp:TextBox>

                        </div>
                    </div>
                    <div class="col-sm-6">
                        <div class="form-group autocomplete-form">
                            <label>&nbsp;</label>
                           <asp:TextBox ID="TxtInventoryAc" runat="server" CssClass="form-control"  AutoComplete="off"></asp:TextBox>                                                                                                                                                                                                                                                                                                                                                                                                                                                        
                            <cc1:AutoCompleteExtender ID="AutoCompleteExtender4" runat="server"
                                DelimiterCharacters="" Enabled="true" ServicePath="~/Autocomplete.asmx" ServiceMethod="GetAccountList"
                                TargetControlID="TxtInventoryAc" MinimumPrefixLength="1" CompletionInterval="10"
                                EnableCaching="true" CompletionListCssClass="autocompleteTextBoxLP" OnClientItemSelected="AutocompleteOnSelected_Accumulated">
                            </cc1:AutoCompleteExtender>
                            <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender2" 
                                runat="server" Enabled="True" TargetControlID="TxtInventoryAc" 
                                WatermarkCssClass="form-control" WatermarkText="Auto Complete">
                            </cc1:TextBoxWatermarkExtender>     
                        </div>
                    </div>
            </div>
            <div class="row">
                    <div class="col-sm-6">
                        <div class="form-group">
                            <label>CommisionAcNo A/C:</label>
                            <asp:TextBox ID="TxtCommisionAcNo" runat="server" CssClass="form-control"></asp:TextBox>

                        </div>
                    </div>
                    <div class="col-sm-6">
                        <div class="form-group autocomplete-form">
                            <label>&nbsp;</label>
                            <asp:TextBox ID="TxtCommisionAc" runat="server" CssClass="form-control" AutoComplete="off"></asp:TextBox>                                                                                                                                                                                                                                                                                    
                            <cc1:AutoCompleteExtender ID="AutoCompleteExtender5" runat="server"
                                DelimiterCharacters="" Enabled="true" ServicePath="~/Autocomplete.asmx" ServiceMethod="GetAccountList"
                                TargetControlID="TxtCommisionAc" MinimumPrefixLength="1" CompletionInterval="10"
                                EnableCaching="true" CompletionListCssClass="autocompleteTextBoxLP" OnClientItemSelected="AutocompleteOnSelected_Writeoff">
                            </cc1:AutoCompleteExtender>
                            <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender3" 
                                runat="server" Enabled="True" TargetControlID="TxtCommisionAc" 
                                WatermarkCssClass="form-control" WatermarkText="Auto Complete">
                            </cc1:TextBoxWatermarkExtender>       
                        </div>
                    </div>
            </div>
            <div class="row">
                <div class="col-sm-6 form-group">
                    <label>Re-Order Level:</label>
                    <asp:TextBox ID="TxtReorderLevel" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-sm-6 form-group">
                    <label>Re-Order QTY:</label>
                    <asp:TextBox ID="txtReorderQty" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-sm-6 form-group">
                    <label>Max Stock Holding QTY:</label>
                    <asp:TextBox ID="txtMaxStockHoldingQty" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-sm-6 form-group">
                    <label>Is Active:</label>
                    <asp:DropDownList ID="DdlIsActive" runat="server" CssClass="form-control" >
                        <asp:ListItem Value="True">Yes</asp:ListItem>
                        <asp:ListItem Value="False">No</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <div class="form-group">
                <asp:Button ID="BtnAdd" runat="server" CssClass="btn btn-primary" onclick="BtnAdd_Click" 
                    Text="Add" ValidationGroup="Branch" />
                <asp:Button ID="btnUpdate" runat="server" CssClass="btn btn-primary" Text="Update" 
                    onclick="btnUpdate_Click"/>
                <asp:Label ID="LblMsg" runat="server" CssClass="txtlbl"></asp:Label>
            </div>
            <div class="form-group">
                <div id="rpt" runat="server" class="table-responsive" ></div>
            </div>
            <div class="row">
                 <div class="col-sm-3 col-sm-offset-9 ">
                    <div class="form-group">
                        <asp:Panel ID="PnDelete" runat="server">
                            <input type="button" value="Select All" id="select" name="select" class="btn btn-primary" onclick="checkedAll(form2);"  />
                                  
                            <asp:Button ID="BtnDelete" runat="server" CssClass="btn btn-primary" 
                            onclick="BtnDelete_Click" Text="Delete"  />
                                        
                            <cc1:ConfirmButtonExtender ID="BtnDelete_ConfirmButtonExtender" runat="server" 
                            ConfirmText="Confirm To Delete ?" Enabled="True" TargetControlID="BtnDelete">
                            </cc1:ConfirmButtonExtender>       
                        </asp:Panel>
                    </div>
                </div>
            </div>
            
        </div>
        </section>
        </div>
    </div> 
        
</form>

<script type="text/javascript" src="<%=ResolveUrl("ui/js/jquery-1.10.2.min.js") %>"></script>
<script type="text/javascript" src="<%=ResolveUrl("ui/js/jquery-ui-1.9.2.custom.min.js") %>"></script>
<script type="text/javascript" src="<%=ResolveUrl("ui/js/jquery-migrate-1.2.1.min.js") %>"></script>
<script type="text/javascript" src="<%=ResolveUrl("ui/js/bootstrap.min.js") %>"></script>
<script type="text/javascript" src="<%=ResolveUrl("ui/js/modernizr.min.js") %>"></script>
<script type="text/javascript" src="<%=ResolveUrl("ui/js/jquery.nicescroll.js") %>"></script>
<script type="text/javascript" src="<%=ResolveUrl("ui/js/scripts.js") %>"></script>

<script language="javascript">
    function AutocompleteOnSelected(sender, e) {
        var customerValueArray = (e._value).split("|");
        document.getElementById("HdnProduct").value = customerValueArray[1];
        document.getElementById("HdnFlag").value = customerValueArray[2];
    }
    function AutocompleteOnSelected_Sales(sender, e) {
        var customerValueArray = (e._value).split("|");
//        document.getElementById("TxtSalesAcNo").value = customerValueArray[1];
        document.getElementById("<%=TxtSalesAcNo.ClientID%>").Value = customerValueArray[1]; 
    }

    function AutocompleteOnSelected_Depreciation(sender, e) {
        var customerValueArray = (e._value).split("|");
//        document.getElementById("TxtPurchaseAcNo").value = customerValueArray[1];
        document.getElementById("<%=TxtPurchaseAcNo.ClientID%>").Value = customerValueArray[1]; 
    }

    function AutocompleteOnSelected_Accumulated(sender, e) {
        var customerValueArray = (e._value).split("|");
//        document.getElementById("TxtInventoryAcNo").value = customerValueArray[1];
        document.getElementById("<%=TxtInventoryAcNo.ClientID%>").Value = customerValueArray[1];
    }

    function AutocompleteOnSelected_Writeoff(sender, e) {
        var customerValueArray = (e._value).split("|");
//        document.getElementById("TxtCommisionAcNo").value = customerValueArray[1];
        document.getElementById("<%=TxtCommisionAcNo.ClientID%>").Value = customerValueArray[1];
    }
</script>
    </body>
</html>






