<%@ Page Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="ApproveTransfer.aspx.cs" Inherits="SwiftHrManagement.web.AssetManagement.ApproveTransfer" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
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
						<img src="/images/spacer.gif" width="5" height="1"><img src="/images/big_bullit.gif">&nbsp;
						Approve Asset Transfer Details</td>
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
        <td width="91%" class="container_tmid"><div>Approve Asset Transfer Details</div></td>
        <td width="8%" class="container_tr"><div></div></td>
    </tr>
    <tr>
        <td class="container_l"></td>
        <td class="container_content">
        
<!--################ END FORM STYLE-->
 <asp:UpdatePanel ID="updatepanel1" runat="server">
 <ContentTemplate>                                                       
         <table border="0" cellpadding="3" cellspacing="3" class="container" width="700">
            <tr>
              <td colspan="4">
                <span class="txtlbl">Please enter valid data</span>
                <span class="required">(* Required fields)</span><br />
                <asp:Label ID="LblMsg" runat="server"></asp:Label>                                                                    
                
               <asp:HiddenField ID="hdnAssetID" runat="server" />
               <asp:HiddenField ID="hdnAccuDep" runat="server" />
               <asp:HiddenField ID="hdnFromBranchID" runat="server" />
               <asp:HiddenField ID="hdnFromDeptID" runat="server" />
               <asp:HiddenField ID="hdnFromHolderID" runat="server" />               
              </td>                                                                
            </tr> 
            <tr>
                    <td nowrap="nowrap"><div align="right">Asset Number :</div></td>
                   <td nowrap="nowrap" align="left" colspan="3">
                      <span class="errormsg">  
                      <asp:TextBox ID="TxtAssetNumber" runat="server" CssClass="inputTextBox" 
                       AutoComplete="off" Width="550px" AutoPostBack="true" 
                       ontextchanged="TxtAssetNumber_TextChanged"></asp:TextBox>&nbsp;*</span>
                      <cc1:TextBoxWatermarkExtender ID="TxtAssetNumber_TextBoxWatermarkExtender" 
                          runat="server" Enabled="True" TargetControlID="TxtAssetNumber" 
                          WatermarkCssClass="watermark" WatermarkText="Auto Complete">
                      </cc1:TextBoxWatermarkExtender>                          
                      <cc1:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server"
                      DelimiterCharacters="" Enabled="true" ServicePath="~/Autocomplete.asmx" ServiceMethod="GetAssetInventoryDetailyAssetNo"
                      TargetControlID="TxtAssetNumber" MinimumPrefixLength="1" CompletionInterval="10"
                      EnableCaching="true" CompletionListCssClass="autocompleteTextBoxLP" OnClientItemSelected="AutocompleteOnSelected">
                      </cc1:AutoCompleteExtender>
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator2" 
                      runat="server" ControlToValidate="TxtAssetNumber" 
                      ErrorMessage="Required" ValidationGroup="Transfer">
                      </asp:RequiredFieldValidator>                                                                               
                     </td>
                     
                </TR>
               <tr>
                    <td nowrap="nowrap"><div align="right">Purchase Value :</div></td>  
                    <td>
                    <asp:TextBox ID="txtPurchaseValue" runat="server" CssClass="inputTextBox" ReadOnly="true"></asp:TextBox></td> 
                    
                    <td><div align="right">Book Value :</div></td>
                    <td align="left" class="style1">
                    <asp:TextBox ID="TxtBookValue" runat="server" CssClass="inputTextBox" ReadOnly="true"></asp:TextBox></td>  
                </tr>
                <tr>
                    
                    <td nowrap="nowrap"><div align="right">Transfer Date :</div></td>                    
                    <td align="left">
                        <asp:TextBox ID="TxtTransferDate" runat="server" CssClass="inputTextBox"></asp:TextBox>&nbsp;<span class="errormsg">*</span>
                        <cc1:CalendarExtender ID="TxtTransferDate_CalendarExtender" runat="server" 
                           Enabled="True" TargetControlID="TxtTransferDate">
                        </cc1:CalendarExtender>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" 
                         runat="server" ControlToValidate="TxtTransferDate" ErrorMessage="Required" ValidationGroup="Transfer">
                        </asp:RequiredFieldValidator>
                    </td>
                    <td nowrap="nowrap"><div align="right">Acc Dep. :</div></td> 
                    <td align="left">
                        <asp:TextBox ID="txtAccDep" runat="server" CssClass="inputTextBox" ReadOnly="true"></asp:TextBox></td>                
                   </tr>
                <tr>
                    <td><div align="right">Asset Narration :</div></td>
                    <td colspan="3" align="left">                         
                             <asp:TextBox ID="txtAssetNarration" runat="server" 
                                 CssClass="inputTextBox" TextMode="MultiLine" Width="550px" Height="44px" 
                                 ReadOnly="true"></asp:TextBox>  </td> 
                </tr>

               <tr>
                    <td align="left" valign="top"><div align="right">Narration :</div></td>
                    <td colspan="3" align="left">                         
                         <asp:TextBox ID="TxtNaration" runat="server" 
                             CssClass="inputTextBox" TextMode="MultiLine" Width="550px" Height="44px" 
                             ReadOnly="true"></asp:TextBox>  </td>                       
               </tr> 
<%--               <tr>
                    <td align="left" valign="top" nowrap="nowrap"><div align="right">Change Asset Number :</div></td>
                    <td colspan="3" align="left">                         
                         <asp:CheckBox ID="chkAssetNumber" runat="server"></asp:CheckBox></td>
               </tr> --%>
               <tr>
                  <td colspan="2">
                     <asp:Panel ID="PanelFrom" runat="server" GroupingText="Transfer From">
                     <table cellpadding="5" cellspacing="5" class="container">
                      <tr>
                       <td align="left"><div align="right">Branch :</div></td>
                       <td align="left"><asp:TextBox ID="TxtBranchFrom" runat="server" CssClass="CMBDesign" ReadOnly="true"></asp:TextBox></td>
                      </tr>
                     <tr>
                       <td><div align="right">Department :</div></td>
                       <td align="left"><asp:TextBox ID="TxtDepartmentFrom" runat="server" CssClass="CMBDesign" ReadOnly="true"></asp:TextBox></td>
                     </tr>
                     <tr>
                      <td class="style1">
                     <div align="right">Holder :</div>  
                     </td>
                     <td align="left"><asp:TextBox ID="TxtHolderFrom" runat="server" CssClass="CMBDesign" ReadOnly="true"></asp:TextBox></td>
                     </tr>
                    </table>    
                     </asp:Panel>
                     </td>
                     <td colspan="2">
                     <asp:Panel ID="Panel2" runat="server" GroupingText="Transfer To">
                     <table cellpadding="5" cellspacing="5" class="container">
                     <tr>
                     <td><div align="right">Branch :</div></td>
                     <td nowrap="nowrap"><span class="errormsg"><asp:DropDownList ID="CmbBranchTo" runat="server" CssClass="CMBDesign"
                     onselectedindexchanged="CmbBranchTo_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>&nbsp;*</span>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator3" 
                     runat="server" ControlToValidate="CmbBranchTo"
                     ErrorMessage="Required" ValidationGroup="Transfer">
                     </asp:RequiredFieldValidator>
                     </td>                     
                     </tr>
                     <tr>
                     <td><div align="right">Department :</div></td>
                     <td nowrap="nowrap">
                     
                         <asp:DropDownList ID="CmbDepartmentTo" runat="server" CssClass="CMBDesign" onselectedindexchanged="CmbDepartmentTo_SelectedIndexChanged" 
                            AutoPostBack="true"></asp:DropDownList>
                         
                    </td>              
                    </tr>
                    <tr>
                    <td>
                    <div align="right">Holder :</div>  
                    </td>
                    <td nowrap="nowrap"><asp:DropDownList ID="CmbHolderTo" runat="server" 
                    CssClass="CMBDesign"></asp:DropDownList>
                    </td>
                    </tr>
                    </table>    
                    </asp:Panel>
                    </td>           
                    </tr>
                    <tr>                                                                
                    <td class="style5" colspan="3">
                    <asp:Button ID="btnSave" runat="server" CssClass="button" 
                    onclick="btnSave_Click" Text="Reject" ValidationGroup="Transfer" />
                        <cc1:ConfirmButtonExtender ID="btnSave_ConfirmButtonExtender" runat="server" 
                            ConfirmText="Confirm To Reject?" Enabled="True" TargetControlID="btnSave">
                        </cc1:ConfirmButtonExtender>
                    &nbsp;<asp:Button ID="BtnApprove" runat="server" CssClass="button" 
                            onclick="BtnApprove_Click" Text="Approve" />
                        <cc1:ConfirmButtonExtender ID="BtnApprove_ConfirmButtonExtender" runat="server" 
                            ConfirmText="Confirm To Approve?" Enabled="True" TargetControlID="BtnApprove">
                        </cc1:ConfirmButtonExtender>
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
    </table>			</td>
    </tr>
    </table>	</td>
    </tr>
    </table>
</asp:Content>

<script language="javascript" type="text/javascript">
    function AutocompleteOnSelected(sender, e) {
        var customerValueArray = (e._value).split("|");
        document.getElementById("<%=hdnAssetID.ClientID %>").value = customerValueArray[1];
    }
    function GetEmpID(sender, e) {
        var customerValueArray = (e._value).split("|");
        document.getElementById("<%=hdnEmpId.ClientID %>").value = customerValueArray[1];
    }          
</script>