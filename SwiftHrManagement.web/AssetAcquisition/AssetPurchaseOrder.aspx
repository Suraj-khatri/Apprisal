<%@ Page Language="C#"  MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="AssetPurchaseOrder.aspx.cs" Inherits="SwiftAssetManagement.AssetAcquisition.AssetPurchaseOrder" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">

    <link href="../Css/style.css" rel="Stylesheet" type="text/css" />


    <input type="hidden" id="ac_type" name="ac_type"><%--<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>--%>   
    <asp:UpdatePanel ID="updp" runat="server"><ContentTemplate>        
    <table width="100%" height="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td valign="top">
		<table width="100%" height="100%" border="0" cellspacing="0" cellpadding="0">
		  <tr> 
			<td valign="top">
				<table width="100%" border="0" cellspacing="0" cellpadding="0">
					<tr>
						<td valign="bottom" class="wellcome">
						<img src="/images/spacer.gif" width="5" height="1"><img src="/images/big_bullit.gif">&nbsp;Asset Purchase 
                            Order Details</td>
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
        <td width="91%" class="container_tmid"><div>Purchase order entry</div></td>
        <td width="8%" class="container_tr"><div></div></td>
    </tr>
    <tr>
        <td class="container_l"></td>
        <td class="container_content">
        
<!--################ END FORM STYLE-->
<asp:UpdatePanel ID="updatepanel1" runat="server">
<ContentTemplate>
<table border="0" cellpadding="5" cellspacing="5" class="container"> 
<tr>
    <td nowrap="nowrap"><asp:Label ID="LblMsg" runat="server"></asp:Label>
        <asp:HiddenField ID="hdnVat" runat="server" />
    </td>
</tr>
<tr>
    <td>  
    <fieldset style="list-style:circle; list-style-type:circle; width:80%;"><legend class="style2">Asset Information:</legend>    
        <div>        
            <table border="0" cellpadding="2" cellspacing="2" width="50%" 
                style="width: 100%">
            <tr>
                <td class="style3"><div id="rpt" runat="server"></div></td>
            </tr>
             <tr>
                <td><div align="right">
                    <asp:Button ID="BtnDelProduct" runat="server" Text="Delete" CssClass="button" 
                        onclick="BtnDelProduct_Click"/></div></td>
            </tr>
        </table>        
        </div>
    </fieldset>
    <fieldset style="list-style:circle; list-style-type:circle; width:80%;" ><legend class="style2">Order information:</legend>
        <div>    
        <table border="0" cellpadding="5" cellspacing="5">
        <tr>
            <td nowrap>Order Date: 
                <asp:RequiredFieldValidator ID="rfc2" runat="server" 
                      ControlToValidate="txtOrderDate" ErrorMessage="Required" SetFocusOnError="True" 
                      ValidationGroup="order"></asp:RequiredFieldValidator><br />
                <asp:TextBox ID="txtOrderDate" runat="server" CssClass="inputTextBox"></asp:TextBox>
                    <cc1:CalendarExtender ID="txtOrderDate_CalendarExtender" runat="server" 
                    Enabled="True" TargetControlID="txtOrderDate">
                </cc1:CalendarExtender>
            </td>
            <td nowrap="nowrap">Vendor:
                    <asp:RequiredFieldValidator ID="rfc3" runat="server" 
                      ControlToValidate="txtVendor" ErrorMessage="Required" SetFocusOnError="True" 
                      ValidationGroup="order"></asp:RequiredFieldValidator><asp:HiddenField ID="hdnVendorId" runat="server" /><br />
                      
                    <cc1:AutoCompleteExtender ID="AutoCompleteExtender3" runat="server"
                        DelimiterCharacters="" Enabled="true" ServicePath="~/Autocomplete.asmx" ServiceMethod="GetVendor"
                        TargetControlID="txtVendor" MinimumPrefixLength="1" CompletionInterval="10"
                        EnableCaching="true" CompletionListCssClass="autocompleteTextBoxLP" OnClientItemSelected="AutocompleteOnSelected">
                   </cc1:AutoCompleteExtender>
                  <asp:TextBox ID="txtVendor" runat="server" Width="300px" 
                      CssClass="inputTextBox" AutoComplete="off"></asp:TextBox>
                      <cc1:TextBoxWatermarkExtender ID="txtVendor_TextBoxWatermarkExtender" 
                      runat="server" Enabled="True" TargetControlID="txtVendor" 
                      WatermarkCssClass="watermark" WatermarkText="Auto Complete">
                </cc1:TextBoxWatermarkExtender>
                      
            </td>
            <td nowrap="nowrap">Deliver Within The Date:
                <asp:RequiredFieldValidator ID="rfc1" runat="server" 
                    ControlToValidate="txtDeliverDate" ErrorMessage="Required" SetFocusOnError="True" 
                    ValidationGroup="order"></asp:RequiredFieldValidator><br />
                <asp:TextBox ID="txtDeliverDate" runat="server" CssClass="inputTextBox" Width="100px"></asp:TextBox>          
                <cc1:CalendarExtender ID="txtDeliverDate_CalendarExtender" runat="server" 
                    Enabled="True" TargetControlID="txtDeliverDate">
                </cc1:CalendarExtender>
            </td>
        </tr>
        <tr>
            <td colspan="3" nowrap="nowrap">Detail Note for vendor (Select One):<br />
                <asp:TextBox id="txtRemarks" runat="server" CssClass="inputTextBox" Width="400px">Payment will be made upon receipt of the goods.
                
                </asp:TextBox><asp:CheckBox ID="ChkNote" runat="server" />
            </td>            
        </tr>
        <tr>
            <td colspan="3" nowrap="nowrap">
                <asp:TextBox id="txtRemarks1" runat="server" CssClass="inputTextBox" Width="500px">Payment will be made upon installation and sucessful operation of the equipments.                
                </asp:TextBox><asp:CheckBox ID="ChkNote1" runat="server" />
            </td>            
        </tr>
      </table>
        </div>
    </fieldset>

    </td> 
</tr>
<tr>
    <td>
        <asp:Button ID="BtnSave" runat="server" Text="Save Order" CssClass="button" 
            Width="85px" onclick="BtnSave_Click" ValidationGroup="order"/>&nbsp;
        <asp:Button ID="BtnDelete" runat="server" Text="Refresh" 
            CssClass="button" Width="100px" onclick="BtnDelete_Click"/></td>
</tr>
    
</table>
</ContentTemplate>
</asp:UpdatePanel>  
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
    </ContentTemplate> </asp:UpdatePanel> 

<script language=javascript>
    function AutocompleteOnSelected(sender, e) {
        var customerValueArray = (e._value).split("|");
        document.getElementById("hdnVendorId").value = customerValueArray[1];
    }
    function searchProduct() {
        childWindow = window.open("../Inventory/Item/ProductSearch.aspx", "mywindow", "menubar=0,resizable=0,width=750,height=350,align=center");
    }
</script>

</asp:Content>

