<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SalesVoucher.aspx.cs" Inherits="SwiftAssetManagement.Voucher.SalesVoucher" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>IME Automotives</title>    
     <link href="../Css/style.css" rel="Stylesheet" type="text/css" />
     <script language="javascript" type="text/javascript">
         function searchProduct() {
             childWindow = window.open("../Inventory/Item/ProductSearch.aspx", "mywindow", "menubar=0,resizable=0,width=750,height=350,align=center");
         }
    </script>
 <style type="text/css">
    .style2
    {
        color: #008000;
    }
</style>
  <script type="text/javascript">
      var GB_ROOT_DIR = "greybox/";
    </script>

    <script type="text/javascript" src="greybox/AJS.js"></script>
    <script type="text/javascript" src="greybox/AJS_fx.js"></script>
    <script type="text/javascript" src="greybox/gb_scripts.js"></script>
    <link href="greybox/gb_styles.css" rel="stylesheet" type="text/css" media="all" />
    </head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
<asp:UpdatePanel ID="upd" runat="server">
<ContentTemplate>    
<table width="100%" height="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td valign="top">
		<table width="100%" height="100%" border="0" cellspacing="0" cellpadding="0">
		  <tr> 
			<td valign="top">
				<table width="100%" border="0" cellspacing="0" cellpadding="0">
					<tr>
						<td valign="bottom" class="wellcome">
						<img src="/images/spacer.gif" width="5" height="1"><img src="/images/big_bullit.gif">&nbsp;Sales Voucher Entry</td>
					</tr>
					<tr>
						<td valign="top" bgcolor="#999999" height="1"><img src="/images/spacer.gif" width="100%" height="1"></td>
					</tr>
				</table>
				<table width="90%" border="0" cellspacing="0" cellpadding="0">
					<tr>
						<td valign="top" align="center"><br>

						<!--		Begin content	-->

						
<!--################ START FORM STYLE-->
 <table class="container" border="0" cellpadding="0" cellspacing="0" width="20%">
  <tbody>
    <tr>
        <td width="1%" class="container_tl"><div></div></td>
        <td width="91%" class="container_tmid"><div>Sales Voucher Entry</div></td>
        <td width="8%" class="container_tr"><div></div></td>
    </tr>
    <tr>
        <td class="container_l"></td>
        <td class="container_content">
        
<!--################ END FORM STYLE-->
<table border="0" cellpadding="5" cellspacing="5" class="container"> 
<tr>
    <td><span class="txtlbl" nowrap="nowrap">Please Enter Valid Data!!! </span>
        <span class="required">( * are required fields)</span><br />
        <asp:Label ID="LblMsg" runat="server"></asp:Label></td>
</tr>
<tr>
    <td>Check For Without VAT Sales 
        <asp:CheckBox ID="chkVAT" runat="server" />
        </td>
</tr>
<tr>
    <td>  
    <fieldset style="list-style:circle; list-style-type:circle; width:98%;"><legend class="style2">Product / Account Information:</legend>    
        <div>        
            <table border="0" cellpadding="2" cellspacing="2">
            <asp:HiddenField ID="hdnProductId" runat="server" />           
            <tr>
                <td nowrap valign="middle" width="40">
                    Product Code:<asp:RequiredFieldValidator ID="rfv" runat="server" 
                        ControlToValidate="txtProduct" Display="None" ErrorMessage="*" 
                        SetFocusOnError="True" ValidationGroup="add"></asp:RequiredFieldValidator></td>
                <td nowrap valign="middle" width="1">
                    &nbsp;</td>
                <td nowrap valign="middle" width="27">
                    Qty:</td>
                <td nowrap valign="middle" width="32">
                    Rate:</td>
                <td nowrap valign="middle" width="52">
                    Amount:</td>
                <td nowrap width="70">
                    &nbsp;</td>
            </tr>
            <tr>    
                <td nowrap="nowrap" valign="top">          
                 <cc1:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server"
                    DelimiterCharacters="" Enabled="true" ServicePath="~/Autocomplete.asmx" ServiceMethod="GetProductList"
                    TargetControlID="txtProduct" MinimumPrefixLength="1" CompletionInterval="10"
                    EnableCaching="true" CompletionListCssClass="autocompleteTextBoxLP" OnClientItemSelected="AutocompleteOnSelected" >
               </cc1:AutoCompleteExtender>                
                <asp:TextBox ID="txtProduct" runat="server" CssClass="inputTextBox" 
                     Width="250px" AutoComplete="off" ></asp:TextBox>  
                                                          
				    <cc1:TextBoxWatermarkExtender ID="txtProduct_TextBoxWatermarkExtender" 
                        runat="server" Enabled="True" TargetControlID="txtProduct" 
                        WatermarkCssClass="Watermark" WatermarkText="Auto Complete">
                    </cc1:TextBoxWatermarkExtender>
				</td>
                <td nowrap="nowrap"><img src="../Images/icon_search2.png" height="18px" align="bottom" style="cursor:pointer;" onClick="searchProduct();"/>
                </td>                
                <td nowrap="nowrap">
                    <asp:TextBox id="qty" name="qty" size="7" runat="server" 
                        CssClass="inputTextBox"></asp:TextBox></td>
                <td nowrap="nowrap">
                    <asp:TextBox id="unitprice" name="unitprice" size="7" runat="server" 
                        ontextchanged="unitprice_TextChanged" AutoPostBack="True" 
                        CssClass="inputTextBox"></asp:TextBox></td>
                <td nowrap="nowrap">
                    <asp:TextBox ID="amount" runat="server" size="10" CssClass="inputTextBox"></asp:TextBox></td>
                <td nowrap="nowrap">
                    <label>
                    <asp:Button ID="BtnAdd" runat="server" CssClass="button" Text="Add" 
                        onclick="BtnAdd_Click"/>
                       
                    </label>
                </td>
           
            </tr>
            <tr>
                <td colspan="6"><div id="rpt" runat="server"></div></td>
            </tr>
             <tr>
                <td colspan="6"><div align="right">
                    <asp:Button ID="BtnDelProduct" runat="server" Text="Delete" CssClass="button" 
                        onclick="BtnDelProduct_Click"/>
                    <cc1:ConfirmButtonExtender ID="BtnDelProduct_ConfirmButtonExtender" 
                        runat="server" ConfirmText="Confirm To Delete ?" Enabled="True" 
                        TargetControlID="BtnDelProduct">
                    </cc1:ConfirmButtonExtender>
                    </div></td>
            </tr>
        </table>        
        </div>
    </fieldset>
    <fieldset style="list-style:circle; list-style-type:circle; width:98%;"><legend class="style2">Payment Method (Account Information):</legend>
        <div>
            <table border="0" cellspacing="2" cellpadding="2">
            <tr>
              <td valign="middle" nowrap>Account: <span id="spn_available">( 0 )</span> <input type="hidden" id="ac_type" name="ac_type">
                  <asp:RequiredFieldValidator ID="rfc" runat="server" 
                      ControlToValidate="TxtAc_Name" Display="None" ErrorMessage="*" 
                      SetFocusOnError="True" ValidationGroup="addaccount"></asp:RequiredFieldValidator>
                </td>
              <td valign="middle" nowrap>&nbsp;</td>
              <td valign="middle" nowrap >Type:</td>
              <td valign="middle" nowrap >Amount:<asp:RequiredFieldValidator ID="rfc1" 
                      runat="server" ControlToValidate="ac_amt" Display="None" ErrorMessage="*" 
                      SetFocusOnError="True" ValidationGroup="addaccount" InitialValue="0"></asp:RequiredFieldValidator></td>
              <td nowrap>&nbsp;</td>
            </tr>
            <tr>
              <td>
              
                 <cc1:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server"
                    DelimiterCharacters="" Enabled="true" ServicePath="~/Autocomplete.asmx" ServiceMethod="GetAccountList"
                    TargetControlID="TxtAc_Name" MinimumPrefixLength="1" CompletionInterval="10"
                    EnableCaching="true" CompletionListCssClass="autocompleteTextBoxLP" >
               </cc1:AutoCompleteExtender>
               
                <asp:TextBox ID="TxtAc_Name" runat="server" CssClass="inputTextBox" 
                     Width="421px" AutoComplete="off" ></asp:TextBox> 
              
         		
					<cc1:TextBoxWatermarkExtender ID="TxtAc_Name_TextBoxWatermarkExtender" 
                      runat="server" Enabled="True" TargetControlID="TxtAc_Name" 
                      WatermarkCssClass="Watermark" WatermarkText="Auto Complete">
                  </cc1:TextBoxWatermarkExtender>
              
         		
					</td>
			
              <td><div align="center" name="batinf" id="Div1"></div></td>
              <td>
                  <asp:DropDownList ID="DdlType" runat="server" CssClass="inputTextBox" 
                      Width="50px">
                  <asp:ListItem Value="dr">DR</asp:ListItem>
                  <asp:ListItem Value="cr" Selected=True>CR</asp:ListItem>
                  </asp:DropDownList>
              </td>
              <td><asp:TextBox id="ac_amt"  value="0" size="15" runat="server" 
                      CssClass="inputTextBox"></asp:TextBox></td>
              <td><label>
              <asp:Button ID="BtnAddAcc" Text=" Add "  CssClass="button" runat="server" 
                      onclick="BtnAddAcc_Click" ValidationGroup="addaccount"></asp:Button>
              </label></td>
            </tr>
        
        <tr>
                <td colspan="5"><div id="rpt1" runat="server"></div></td>
            </tr>
             <tr>
                <td colspan="5"><div align="right">
                    <asp:Button ID="BtnDeleteAcc" runat="server" Text="Delete" CssClass="button" 
                        onclick="BtnDeleteAcc_Click"/>
                    <cc1:ConfirmButtonExtender ID="BtnDeleteAcc_ConfirmButtonExtender" 
                        runat="server" ConfirmText="Confirm To Delete ?" Enabled="True" 
                        TargetControlID="BtnDeleteAcc">
                    </cc1:ConfirmButtonExtender>
                    </div></td>
            </tr>
        
          </table>
        </div>
    </fieldset>

    <fieldset style="list-style:circle; list-style-type:circle; width:98%;" ><legend class="style2">Bill information:</legend>
        <div>    
            <table border="0" cellpadding="2" cellspacing="2">
        <tr>
          <td width="105" nowrap>Bill No: 
              <asp:RequiredFieldValidator ID="rfv3" runat="server" ControlToValidate="billno" 
                  Display="None" SetFocusOnError="True" ValidationGroup="purchase"></asp:RequiredFieldValidator>
            </td>
          <td width="4" nowrap></td>
          <td width="55" nowrap>Bill Date: 
              <asp:RequiredFieldValidator ID="rfv4" runat="server" 
                  ControlToValidate="billDate" Display="None" SetFocusOnError="True" 
                  ValidationGroup="purchase"></asp:RequiredFieldValidator>
            </td>
          <td width="338" nowrap>Vendor:<asp:RequiredFieldValidator ID="rfv5" 
                  runat="server" ControlToValidate="vendor" Display="None" SetFocusOnError="True" 
                  ValidationGroup="purchase"></asp:RequiredFieldValidator></td>
          <td width="102" nowrap></td>
        </tr>
        <tr>
          <td height="24" nowrap><label>
          <asp:TextBox name="billno" id="billno" runat="server" CssClass="inputTextBox"></asp:TextBox>
          </label></td>
          <td nowrap>&nbsp;</td>
          <td nowrap><asp:TextBox ID="billDate" runat="server" CssClass="inputTextBox"></asp:TextBox>
              <cc1:CalendarExtender ID="billDate_CalendarExtender" runat="server" 
                  Enabled="True" TargetControlID="billDate">
              </cc1:CalendarExtender></td>
          <td nowrap="nowrap">
            <cc1:AutoCompleteExtender ID="AutoCompleteExtender3" runat="server"
                    DelimiterCharacters="" Enabled="true" ServicePath="~/Autocomplete.asmx" ServiceMethod="GetVendor"
                    TargetControlID="vendor" MinimumPrefixLength="1" CompletionInterval="10"
                    EnableCaching="true" CompletionListCssClass="autocompleteTextBoxLP" >
               </cc1:AutoCompleteExtender>
               
              <asp:TextBox ID="vendor" runat="server" Width="300px" CssClass="inputTextBox"></asp:TextBox>
              
              <cc1:TextBoxWatermarkExtender ID="vendor_TextBoxWatermarkExtender" 
                  runat="server" Enabled="True" TargetControlID="vendor" 
                  WatermarkCssClass="Watermark" WatermarkText="Auto Complete">
              </cc1:TextBoxWatermarkExtender>
            </td>
          <td>&nbsp;</td>
        </tr>
        <tr>
          <td height="24" colspan="5" nowrap="nowrap">Remarks:<asp:RequiredFieldValidator 
                  ID="rfv6" runat="server" ControlToValidate="remarks" Display="None" 
                  SetFocusOnError="True" ValidationGroup="purchase"></asp:RequiredFieldValidator><br />
          <asp:TextBox id="remarks" 
                  CssClass="inputTextBox" runat="server" Height="45px" Width="460px" 
                  TextMode="MultiLine"></asp:TextBox>
              </td>
          </tr>
      </table>
        </div>
    </fieldset>
    </td> 
</tr>
<tr>
    <td>
        <asp:Button ID="BtnSave" runat="server" Text="Save Voucher" CssClass="button" 
            Width="85px" onclick="BtnSave_Click" ValidationGroup="purchase"/>
        <cc1:ConfirmButtonExtender ID="BtnSave_ConfirmButtonExtender" runat="server" 
            ConfirmText="Confirm To Save ?" Enabled="True" TargetControlID="BtnSave">
        </cc1:ConfirmButtonExtender>
        &nbsp;
        <asp:Button ID="BtnDelete" runat="server" Text="Refresh" 
            CssClass="button" Width="100px" onclick="BtnDelete_Click"/>
</tr>
    
</table>   
<!--################ START FORM STYLE-->
	    </td>
        <td class="container_r"></td>
  </tr>
  <tr>
    <td class="container_bl"></td>
    <td class="container_bmid"></td>
    <td class="container_br"></td>
  </tr>
	</tbody>
  </table>

<!--################ END FORM STYLE-->


	<!--		End  content	-->						</td>
					</tr>
			  </table>			</td>
		  </tr>
	</table>	</td>
  </tr>
</table>
</ContentTemplate></asp:UpdatePanel>  
</form>
</body>
<script language="javascript" type="text/javascript">
    function AutocompleteOnSelected(sender, e) {
        var customerValueArray = (e._value).split("|");
        document.getElementById("hdnProductId").value = customerValueArray[1];
    }
    function searchProduct() {

        childWindow = window.open("../Inventory/Item/ProductSearch.aspx", "mywindow", "menubar=0,resizable=0,width=750,height=400,align=center");
    }
    function addOther(str) {

        var URL = "/Voucher/AddOtherSalesInfo.aspx?Id=" + str;
        GB_show("Add Prodcut Information ", URL, 400, 800);
    }
</script>
</html>





