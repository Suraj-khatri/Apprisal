<%@ Page Language="C#"  MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="ReceiveOrderQty.aspx.cs" Inherits="SwiftAssetManagement.AssetAcquisition.ReceiveOrderQty" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">

    <title></title>    
    <link href="../Css/style.css" rel="stylesheet" type="text/css" />    
   
    <%--<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>--%> 
        <table width="100%" height="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td valign="top">
		<table width="100%" height="100%" border="0" cellspacing="0" cellpadding="0">
		  <tr> 
			<td valign="top">
				<table width="80%" border="0" cellspacing="0" cellpadding="0">
					<tr>
						<td valign="top" align="center"><br>

						<!--		Begin content	-->

						
<!--################ START FORM STYLE-->
 <table class="container" border="0" cellpadding="0" cellspacing="0" width="20%">
  <tbody>
    <tr>
        <td width="1%" class="container_tl"><div></div></td>
        <td width="91%" class="container_tmid"><div>Modify Asset</div></td>
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
        <td>
            <span class="txtlbl">Please enter valid data!</span>&nbsp;
            <span class="required">(* Required fields)</span><br />
            <b><asp:Label ID="LblMsg" runat="server"></asp:Label></b>
            <asp:HiddenField ID ="hdnOrderMessId" runat="server" />
        </td>
    </tr>
    <tr>
        <td nowrap="nowrap"><div align="left"> Asset Type:
            <asp:Label ID="lblAssetType" runat="server" Text="" CssClass="subheading"></asp:Label></td>
    </tr>
    <tr>
        <td nowrap="nowrap"><div align="left">Remaining Ordered Qty:
            <asp:Label ID="lblQty" runat="server" Text="" CssClass="subheading"></asp:Label></td>
    </tr>
    </table>
<table border="0" cellpadding="5" cellspacing="5" class="container">
              
     <tr>
            <td>
                Received Qty:<asp:RequiredFieldValidator ID="rfv" runat="server" 
                    ControlToValidate="qty" ErrorMessage="Required" SetFocusOnError="True" 
                    ValidationGroup="m"></asp:RequiredFieldValidator><br />
                <asp:TextBox ID="qty" runat="server" AutoPostBack="True" 
                    CssClass="inputTextBox"></asp:TextBox>
            </td>
            <td>
                Rate:<br />
                <asp:TextBox ID="rate" runat="server" CssClass="inputTextBox"></asp:TextBox>
            </td>
            <td>
                Amount:<br />
                <asp:TextBox ID="amount" runat="server" CssClass="inputTextBox"></asp:TextBox>
            </td>
    </tr>    
    <tr>
        <td colspan="3" NOWRAP="NOWRAP"><div align="left">
            <asp:Button ID="BtnSave" runat="server" CssClass="button" 
            Text="Update" ValidationGroup="m" onclick="BtnSave_Click" Width="75px" />
            <cc1:ConfirmButtonExtender ID="BtnSave_ConfirmButtonExtender" runat="server" 
                ConfirmText="Confirm To Update?" Enabled="True" TargetControlID="BtnSave">
            </cc1:ConfirmButtonExtender>
            &nbsp;</DIV>
        </td>

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


	<!--		End  content	-->						
	            </td>
					</tr>
			  </table>			
			  </td>
		  </tr>
	</table>	</td>
  </tr>
</table>    
   
<script language=javascript>
    function CalculateTotal() 
    {

        if (document.getElementById("qty").value != "" && document.getElementById("rate").value != "") 
        {
            var amount = parseFloat(document.getElementById("qty").value) * parseFloat(document.getElementById("rate").value);
            document.getElementById("amount").value = amount.toFixed(2);
            
        }
    }
    
</script>
</asp:Content>