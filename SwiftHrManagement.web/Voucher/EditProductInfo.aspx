<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditProductInfo.aspx.cs" Inherits="SwiftAssetManagement.Voucher.EditProductInfo" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <link href="../Css/style.css" rel="Stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript">
        function CalculateTotal() {
            var amount = "";
            if (document.getElementById("qty").value != "" && document.getElementById("unitprice").value != "") {
                var qty = parseFloat(document.getElementById("hdnQty").value);
                var qty1 = parseFloat(document.getElementById("qty").value);
                if (qty1 > qty) {
                    amount = parseFloat(document.getElementById("amount").value);
                    document.getElementById("unitprice").value = amount / qty1.toFixed(2);
                }
                else {

                    amount = parseFloat(document.getElementById("qty").value) * parseFloat(document.getElementById("unitprice").value);
                    document.getElementById("amount").value = amount.toFixed(2);
                }
                }
                
            }
    </script>
</head>
<body>
<form id="form1" runat="server">
<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
<table width="100%" height="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td valign="top">
		<table width="100%" height="100%" border="0" cellspacing="0" cellpadding="0">
		  <tr> 
			<td valign="top">

				<table width="99%" border="0" cellspacing="0" cellpadding="0">
					<tr>
						<td valign="top" align="center"><br>

						<!--		Begin content	-->

						
<!--################ START FORM STYLE-->
 <table class="container" border="0" cellpadding="0" cellspacing="0" width="60%">
  <tbody>
    <tr>
        <td width="1%" class="container_tl"><div></div></td>
        <td width="91%" class="container_tmid"><div>Edit Product Information</div></td>
        <td width="8%" class="container_tr"><div></div></td>
    </tr>
    <tr>
        <td class="container_l"></td>
        <td class="container_content">
        
<!--################ START FORM STYLE-->
    <asp:HiddenField ID="hdnQty" runat="server" />

<asp:UpdatePanel ID="updatepanel1" runat="server">
<ContentTemplate>
<table border="0" cellpadding="2" cellspacing="2" class="container"> 
                <tr>
                    <td colspan="2"><b><asp:Label ID="LblMsg" runat="server"></asp:Label></b></td>
                </tr>
                <tr>    
                    <td nowrap="nowrap"><div align="right">Product Code:</div></td>
                    <td nowrap="nowrap">         
                        <asp:Label ID="lblProductCode" runat="server" CssClass="txtlbl"></asp:Label>                                       
				    </td>
                </tr>
                <tr> 
                    <td nowrap="nowrap"><div align="right">Product Name:</div></td>
                    <td nowrap="nowrap">         
                        <asp:Label ID="txtProduct" runat="server" CssClass="txtlbl"></asp:Label>                                       
				    </td> 
                </tr>
                <tr>            
                     <td nowrap="nowrap"><div align="right">QTY:</div></td>
                     <td nowrap="nowrap">
                     
                        <asp:TextBox id="qty" name="qty" size="10" runat="server" 
                            CssClass="inputTextBox" AutoPostBack="True" ontextchanged="qty_TextChanged"></asp:TextBox>
                         
                         FOC Qty:   
                        <asp:TextBox ID="txtFOC" runat="server" CssClass="inputTextBox" Width="90px" Visible="false"></asp:TextBox>  
                                        
                        <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender2" 
                            runat="server" Enabled="True" TargetControlID="txtFOC" 
                            WatermarkCssClass="watermark" WatermarkText="FOC Qty   ">
                        </cc1:TextBoxWatermarkExtender> 
                                                 
                        <cc1:FilteredTextBoxExtender ID="TxtNoOfDays_FilteredTextBoxExtender" 
                            runat="server" Enabled="True" FilterType="Numbers" TargetControlID="qty">
                        </cc1:FilteredTextBoxExtender>

                         <asp:RequiredFieldValidator ID="v" runat="server" ControlToValidate="qty" 
                            Display="Dynamic" ErrorMessage="Required!" SetFocusOnError="True" ValidationGroup="save">
                        </asp:RequiredFieldValidator>
                        
                    </td>
                    
                </tr>
                <tr>
                    <td nowrap="nowrap"><div align="right">Rate:</div></td>
                    <td nowrap="nowrap">
                        <asp:TextBox id="unitprice" name="unitprice" size="10" runat="server" AutoPostBack="True" 
                            CssClass="inputTextBox"></asp:TextBox>
                        <asp:CompareValidator ID="cv1" runat="server" 
                                ControlToValidate="unitprice" 
                                SetFocusOnError="True" Type="Double" 
                                ValidationGroup="save">
                        </asp:CompareValidator>
                        <asp:RequiredFieldValidator ID="f" runat="server" 
                            ControlToValidate="unitprice" Display="Dynamic" ErrorMessage="Required!" 
                            SetFocusOnError="True" ValidationGroup="save">
                        </asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td nowrap="nowrap"><div align="right">Amount:</div></td>
                    <td nowrap="nowrap">
                        <asp:TextBox ID="amount" runat="server" size="10" CssClass="inputTextBox"></asp:TextBox>
                        <asp:CompareValidator ID="c" runat="server" 
                            ControlToValidate="amount" Display="None" 
                            SetFocusOnError="True" Type="Double" 
                            ValidationGroup="save">
                        </asp:CompareValidator>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="amount" 
                            Display="Dynamic" SetFocusOnError="True" ValidationGroup="save" ErrorMessage="Required!">
                        </asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td nowrap="nowrap">                        
                        <asp:Button ID="BtnAdd" runat="server" CssClass="button" Text="Update" 
                            onclick="BtnAdd_Click" ValidationGroup="save"/>
                    </td>
                </tr>
</table>
</ContentTemplate>
</asp:UpdatePanel>
<!--################ END FORM STYLE-->
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
</form>
</body>
</html>
