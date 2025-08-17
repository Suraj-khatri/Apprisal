<%@ Page Language="C#" MasterPageFile="~/SwiftHRManager.Master"  AutoEventWireup="true" CodeBehind="ModifyAssetRequisition.aspx.cs" Inherits="SwiftAssetManagement.AssetAcquisition.ModifyAssetRequisition" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">

        <title></title>
        
        <script language="javascript" type="text/javascript">
            function searchProduct(){
                childWindow = window.open("../Item/ProductSearch.aspx", "mywindow", "menubar=0,resizable=0,width=750,height=350,align=center"); 
            }
        </script>
        <style type="text/css">
        .style2
            {
                color: #008000;
            }
            .style3
            {
                width: 154px;
            }
        </style>
        <link href="../Css/style.css" rel="stylesheet" type="text/css" />
    
    <%--<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>--%>   
    <table width="100%" height="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td valign="top">
		<table width="100%" height="100%" border="0" cellspacing="0" cellpadding="0">
		  <tr> 
			<td valign="top">
				<table width="100%" border="0" cellspacing="0" cellpadding="0">
					<tr>
						<td valign="bottom" class="wellcome">
						<img src="/images/spacer.gif" width="5" height="1"><img src="/images/big_bullit.gif">&nbsp;Asset Requisition Details</td>
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
        <td width="91%" class="container_tmid"><div>Asset requisition Entry</div></td>
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
     <td colspan="2">
            <span>Please enter valid data</span>&nbsp;
            <span class="required">(* Required fields)</span><br />
            <asp:Label ID="LblMsg" runat="server"></asp:Label>
            <asp:HiddenField ID ="hdnMessageId" runat="server" />
     </td>
</tr>
<tr>
    <td>  
    <fieldset style="list-style:circle; list-style-type:circle; width:80%;"><legend class="style2">Asset Information:
                </legend>    
        <div>        
            <table border="0" cellpadding="2" cellspacing="2">     
            <asp:HiddenField ID="hdnAssetId" runat="server" />      
            <tr>
                <td nowrap="nowrap" valign="middle" width="40">
                    Asset Type:
                    </td>
                <td nowrap="nowrap" valign="middle" width="27">
                    Qty:</td>
                <td nowrap="nowrap" valign="middle">
                 Tentative Price:</td>
                <td nowrap="nowrap" width="70">
                    &nbsp;</td>
            </tr>
            <tr>    
                <td nowrap="nowrap" valign="top">          
                 <cc1:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server"
                    DelimiterCharacters="" Enabled="true" ServicePath="~/Autocomplete.asmx" ServiceMethod="GetAssetType"
                    TargetControlID="asset" MinimumPrefixLength="1" CompletionInterval="10"
                    EnableCaching="true" CompletionListCssClass="autocompleteTextBoxLP" OnClientItemSelected="AutocompleteOnSelected">
               </cc1:AutoCompleteExtender>
               
                <asp:TextBox ID="asset" runat="server" Width="300px" AutoComplete="off" 
                        CssClass="inputTextBox" ></asp:TextBox>                                         
						
                    <cc1:TextBoxWatermarkExtender ID="asset_TextBoxWatermarkExtender" 
                        runat="server" Enabled="True" TargetControlID="asset" 
                        WatermarkCssClass="watermark" WatermarkText="Auto Complete">
                    </cc1:TextBoxWatermarkExtender>
						
                </td>
                <td nowrap="nowrap" valign="top">
                    <asp:TextBox id="qty" name="qty" size="15" runat="server" 
                        CssClass="inputTextBox" Width="75px"></asp:TextBox></td>
                <td nowrap="nowrap" valign="top">
                    <asp:TextBox ID="amount" runat="server" size="15" CssClass="inputTextBox" 
                        Width="150px"></asp:TextBox></td>
                <td nowrap="nowrap">
                    <label>
                    <asp:Button ID="BtnAdd" runat="server" CssClass="button" Text="Add" 
                        onclick="BtnAdd_Click"/>                       
                    </label>
                </td>
            </tr>
            <tr>
                <td colspan="4"><div id="rpt" runat="server"></div></td>
            </tr>
             <tr>
                <td colspan="4"><div align="right">
                    <asp:Button ID="BtnDelProduct" runat="server" Text="Delete" CssClass="button" 
                        onclick="BtnDelProduct_Click"/></div></td>
            </tr>
        </table>        
        </div>
    </fieldset>
    <fieldset style="list-style-type:circle; width:-2147483648%;" ><legend>Order Information:</legend>
        <div>    
        <table border="0" cellpadding="1" cellspacing="1">
        <tr>
          <td nowrap="nowrap" align="left">Forwarded Branch: 
              <asp:RequiredFieldValidator ID="rfc1" runat="server" 
                  ControlToValidate="branchname"  
                  ErrorMessage="Required" SetFocusOnError="True" 
                  ValidationGroup="req"></asp:RequiredFieldValidator>
            </td>
          <td nowrap="nowrap" align="left">Priority:<asp:RequiredFieldValidator ID="rfc3" runat="server" 
                  ControlToValidate="Ddlpriority" ErrorMessage="Required" SetFocusOnError="True" 
                  ValidationGroup="req"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
          <td nowrap="nowrap" align="left">
              <span class="errormsg"><asp:DropDownList ID="branchname" runat="server" CssClass="CMBDesign" 
                  Width="425px"></asp:DropDownList>&nbsp;*</span>
          </td>
          <td nowrap="nowrap" align="left">                         
                <asp:DropDownList ID="Ddlpriority" runat="server" CssClass="CMBDesign" Width="150px">
                    <asp:ListItem Value="Normal">Normal</asp:ListItem>
                    <asp:ListItem Value="Low">Low</asp:ListItem>
                    <asp:ListItem Value="High">High</asp:ListItem>
                </asp:DropDownList>&nbsp;&nbsp;
            </td>
        </tr>
        <tr><td>&nbsp;</td></tr>
        <tr>
            <td colspan="2" align="left">Forwarded To:
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ErrorMessage="Required" ControlToValidate="forwardedto" 
                     SetFocusOnError="True" ValidationGroup="req"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <cc1:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server"
                    DelimiterCharacters="" Enabled="true" ServicePath="~/Autocomplete.asmx" ServiceMethod="GetEmployeeList"
                    TargetControlID="forwardedto" MinimumPrefixLength="1" CompletionInterval="10"
                    EnableCaching="true" CompletionListCssClass="autocompleteTextBoxLP" 
                    OnClientItemSelected="GetEmpID">
               </cc1:AutoCompleteExtender>
                <span class="errormsg"><asp:TextBox ID="forwardedto" runat="server" Width="585px" 
                    CssClass="inputTextBox" AutoComplete="off"></asp:TextBox>&nbsp;*</span>
                    <cc1:TextBoxWatermarkExtender ID="forwardedto_TextBoxWatermarkExtender" 
                    runat="server" Enabled="True" TargetControlID="forwardedto" 
                    WatermarkCssClass="Watermark" WatermarkText="Auto Complete">
                </cc1:TextBoxWatermarkExtender>
                    <asp:HiddenField ID="hdnEmpId" runat="server" />
            </td>
        </tr>
        <tr>
          <td height="24" colspan="2" nowrap="nowrap" align="left"  valign="top">Message:
              <asp:RequiredFieldValidator 
                  ID="rfc4" runat="server" ControlToValidate="narration"  
                  ErrorMessage="Required" SetFocusOnError="True" 
                  ValidationGroup="req"></asp:RequiredFieldValidator>
              <br />
          <span class="required"><asp:TextBox id="narration" 
                  CssClass="inputTextBox" runat="server" Height="45px" 
                  Width="585" TextMode="MultiLine"></asp:TextBox>&nbsp;*</span></td>
          </tr>
      </table>
        </div>
    </fieldset>

    </td> 
</tr>
<tr>
    <td>
        &nbsp;<asp:Button 
            ID="BtnUpdate" runat="server" CssClass="button" onclick="BtnUpdate_Click" 
            Text="Update Requisition" />
&nbsp;<asp:Button ID="BtnDelete" runat="server" Text="Refresh" 
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

<script language="javascript" type="text/javascript">
    function GetEmpID(sender, e) {
        var customerValueArray = (e._value).split("|");
        document.getElementById("hdnEmpId").value = customerValueArray[1];
    }
    function AutocompleteOnSelected(sender, e) {
        var customerValueArray = (e._value).split("|");
        document.getElementById("hdnAssetId").value = customerValueArray[1];
    }
    
</script>

</asp:Content>
