<%@ Page Title="" Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="DeleteAssetBooking.aspx.cs" Inherits="SwiftHrManagement.web.AssetManagement.DeleteAssetBooking" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script language="javascript" type="text/javascript">
    function AutocompleteOnSelected(sender, e) {
        var assetValueArray = (e._value).split("|");
        document.getElementById("<%=hdnAssetId.ClientID %>").value = assetValueArray[1];
    }
    function AutocompleteEmployee(sender, e) {
        var assetValueArray = (e._value).split("|");
        document.getElementById("<%=hdnHolderId.ClientID %>").value = assetValueArray[1];
    }
    function AutoCompleteInsurance(sender, e) {
        var assetValueArray = (e._value).split("|");
        document.getElementById("<%=hdnInsuredId.ClientID %>").value = assetValueArray[1];
    }
    function AutoCompleteBill(sender, e) {
        var assetValueArray = (e._value).split("|");
        document.getElementById("<%=hdnBillId.ClientID %>").value = assetValueArray[1];
    }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
<table width="100%" height="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td valign="top">
		<table width="100%" height="100%" border="0" cellspacing="0" cellpadding="0">
		  <tr> 
			<td valign="top">
				<table width="100%" border="0" cellspacing="0" cellpadding="0">
					<tr>
						<td valign="bottom" class="wellcome">
						<img src="/images/spacer.gif" width="5" height="1"><img src="/images/big_bullit.gif">&nbsp;Assets 
                            Booking Entry Details</td>
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
        <td width="91%" class="container_tmid"><div>Asset Booking Entry</div></td>
        <td width="8%" class="container_tr"><div></div></td>
    </tr>
    <tr>
        <td class="container_l"></td>
        <td class="container_content">
        
<!--################ END FORM STYLE-->
<table border="0" cellpadding="5" cellspacing="5" class="container"> 
<tr>
    <td>&nbsp;</td>
    <td colspan="3">Please enter valid data!( <span class="errormsg">*</span> are required fields)<br />
        <asp:Label ID="lblmsg" runat="server" CssClass="errormsg"></asp:Label>
    </td>  
</tr>
<tr>
    <td nowrap="nowrap"><div align="right">Branch Name:</div></td>
    <td nowrap="nowrap">
        <asp:DropDownList ID="branchname" runat="server" 
            CssClass="inputTextBox" Width="300px" AutoPostBack="True" 
            >
        </asp:DropDownList>
       </td>
    <td nowrap="nowrap"><div align="right">Department Name:</div></td>
    <td nowrap="nowrap">
        <asp:DropDownList ID="deptname" runat="server" 
            CssClass="inputTextBox" Width="200px">
        </asp:DropDownList></td>
</tr>
<tr>
    <td nowrap="nowrap"><div align="right">Asset Type:</div></td>
    <td nowrap="nowrap">
        <asp:HiddenField ID="hdnAssetId" runat="server" />
        <asp:TextBox ID="assettype" runat="server" 
            CssClass="inputTextBox" Width="400px" AutoComplete="off" 
            AutoPostBack="True"></asp:TextBox>
       </td>            
    <td nowrap="nowrap"><div align="right">Booking Date:</div></td>
    <td nowrap="nowrap">
        <asp:TextBox ID="bookingdate" runat="server" 
            CssClass="inputTextBox" AutoPostBack="True"  ></asp:TextBox>
        </td>
</tr>
<tr>

        <td nowrap="nowrap"><div align="right">Number of Asset Qty:</div></td>
        <td nowrap="nowrap">
            <asp:TextBox ID="txtAssetQty" runat="server" 
            CssClass="inputTextBox"></asp:TextBox>&nbsp;
        </td>
        
    <td nowrap="nowrap"><div align="right">Purchase Value:</div></td>
    <td nowrap="nowrap">
        <asp:TextBox ID="purchasevalue" runat="server" 
            CssClass="inputTextBox"></asp:TextBox>
        </td>

</tr>
<tr>
    <td nowrap="nowrap"><div align="right">Accumulated Depreciation:</div></td>
    <td nowrap="nowrap">
        <asp:TextBox ID="accdep" runat="server" 
            CssClass="inputTextBox">0</asp:TextBox>
    </td>
    <td nowrap="nowrap"><div align="right">Dep. Start Date:</div></td>
    <td nowrap="nowrap">
        <asp:TextBox ID="depstartdate" runat="server" 
            CssClass="inputTextBox"></asp:TextBox>
        </td>
</tr>
<tr>
    <td nowrap="nowrap"><div align="right">Purchase Date:</div></td>
    <td nowrap="nowrap">
        <asp:TextBox ID="txtPurchaseDate" runat="server" 
            CssClass="inputTextBox"></asp:TextBox>
        </td>

    <td nowrap="nowrap"><div align="right">Asset Status:</div></td>
    <td nowrap="nowrap">
        <asp:DropDownList ID="assetstatus" runat="server" CssClass="inputTextBox">         
        <asp:ListItem>Active</asp:ListItem>
        <asp:ListItem>Inactive</asp:ListItem>
        <asp:ListItem>Sold</asp:ListItem>
        <asp:ListItem>Disposed</asp:ListItem>
        <asp:ListItem>Write-Off</asp:ListItem>
        </asp:DropDownList>
    </td>   
</tr>
<tr>   
    <td nowrap="nowrap"><div align="right">Bill Info:</div></td>
    <td nowrap="nowrap">
    
        <asp:TextBox ID="billid" runat="server" 
            CssClass="inputTextBox" Width="300px" AutoComplete="off"></asp:TextBox>
        <asp:HiddenField ID="hdnBillId" runat="server" />
    </td>     
    <td nowrap="nowrap"><div align="right">Insurance Info:</div></td>
    <td nowrap="nowrap">
        <asp:TextBox ID="insuranceid" runat="server" 
            CssClass="inputTextBox" Width="300px" AutoComplete="off"></asp:TextBox>
        <asp:HiddenField ID="hdnInsuredId" runat="server" />
    </td>       
      

</tr>
<tr>
    <td nowrap="nowrap"><div align="right">Asset Holder:</div></td>
    <td nowrap="nowrap">
    
        <asp:TextBox ID="assetholder" runat="server" 
            CssClass="inputTextBox" Width="350px" AutoComplete="off"></asp:TextBox>
        <asp:HiddenField ID="hdnHolderId" runat="server" />
    </td>
    <td nowrap="nowrap"><div align="right">Next Maintenance Date:</div></td>
    <td nowrap="nowrap">
        <asp:TextBox ID="nextmaindate" runat="server" 
            CssClass="inputTextBox"></asp:TextBox>
    </td>

</tr>
<tr>
    <td nowrap="nowrap"><div align="right">Old Asset Code:</div></td>
    <td nowrap="nowrap">
      <asp:TextBox ID="OldAssetCode" runat="server" CssClass="inputTextBox"></asp:TextBox>
    </td>
    <td nowrap="nowrap"><div align="right">Old Asset Number:</div></td>
    <td nowrap="nowrap">
    <asp:TextBox ID="OldAssetNo" runat="server" CssClass="inputTextBox"></asp:TextBox>
    </td>
</tr>
<tr>
    <td nowrap="nowrap"><div align="right">Model No:</div></td>
    <td nowrap="nowrap">
      <asp:TextBox ID="ModelNo" runat="server" CssClass="inputTextBox"></asp:TextBox>
    </td>
    <td nowrap="nowrap"><div align="right">Brand:</div></td>
    <td nowrap="nowrap">
    <asp:TextBox ID="Brand" runat="server" CssClass="inputTextBox"></asp:TextBox>
    </td>
</tr>
<tr>  
    <td nowrap="nowrap"><div align="right">Asset Serial No:</div></td>
    <td nowrap="nowrap">
        <asp:TextBox ID="assetserial" runat="server" CssClass="inputTextBox"></asp:TextBox>
    </td>
    <td nowrap="nowrap"><div align="right">Depreciation Pct.:</div></td>
    <td nowrap="nowrap">
        <asp:TextBox ID="TxtDepPct" runat="server" CssClass="inputTextBox" 
            AutoPostBack="True"></asp:TextBox>
    </td>

    
</tr>
<tr>
    <td nowrap="nowrap"><div align="right">Warranty Expiry Date:</div></td>
    <td nowrap="nowrap">
        <asp:TextBox ID="warrexpirydate" runat="server" 
            CssClass="inputTextBox"></asp:TextBox>
    </td> 
    <td nowrap="nowrap" valign="top"><div align="right">Is Amortised Asset:</div></td>    
    <td nowrap="nowrap" valign="top"><asp:CheckBox ID="chkAmortised" runat="server" 
            AutoPostBack="True"/>
        <asp:TextBox ID="txtLifeInMonth" runat="server" CssClass="inputTextBox" Width="100px" Visible="false"></asp:TextBox>
         <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" 
                runat="server" Enabled="True" TargetControlID="txtLifeInMonth" 
                WatermarkCssClass="watermark" WatermarkText="Asset Life In Month">
        </cc1:TextBoxWatermarkExtender>
    </td>
</tr>
<tr>  
    <td nowrap="nowrap">
        <div align="right">
            Narration:</div>
    </td>
    <td nowrap="nowrap" colspan="3">
        <asp:TextBox ID="narration" runat="server" CssClass="inputTextBox" 
            Height="50px" TextMode="MultiLine" Width="800px"></asp:TextBox>
    </td>    
</tr>
<tr>
    <td>&nbsp;</td>
    <td colspan="3" nowrap="nowrap" class="style1">
        <asp:Button ID="btnApprove" runat="server" Text="Approve" CssClass="button" 
            Width="60px" ValidationGroup="book" onclick="btnApprove_Click"/>
        <cc1:ConfirmButtonExtender ID="BtnSave_ConfirmButtonExtender" runat="server" 
            ConfirmText="Are you sure want to Approve Deletion?" Enabled="True" TargetControlID="btnApprove">
        </cc1:ConfirmButtonExtender>
        &nbsp;
        <asp:Button ID="btnReject" runat="server" Text="Reject" 
            CssClass="button" Width="60px" onclick="btnReject_Click"/>
        <cc1:ConfirmButtonExtender ID="BtnDelete_ConfirmButtonExtender" runat="server" 
            ConfirmText="Are you sure to Reject Deletion?" Enabled="True" 
            TargetControlID="btnReject">
        </cc1:ConfirmButtonExtender>
        &nbsp;
        <asp:Button ID="BtnBack" runat="server" Text="&lt;&lt; Back" CssClass="button" onclick="BtnBack_Click" 
            />
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
</asp:Content>
