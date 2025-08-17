<%@ Page Language="C#" AutoEventWireup="true"   MasterPageFile="~/SwiftHRManager.Master"  CodeBehind="MangeInsuranceForCreditDept.aspx.cs" Inherits="SwiftHrManagement.web.Company.EmployeeWeb.MangeInsuranceForCreditDept" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
<asp:UpdatePanel ID="updatep" runat=server>
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
						<img src="/images/spacer.gif" width="5" height="1">
						<img src="/images/big_bullit.gif">&nbsp;&nbsp;Job Entry Details</td>
					</tr>
					<tr>
						<td valign="top" bgcolor="#999999" height="1"><img src="/images/spacer.gif" width="100%" height="1"></td>
					</tr>
				</table>
				<table width="80%" border="0" cellspacing="0" cellpadding="0">
					<tr>
						<td valign="top" align="center"><br>

						<!--		Begin content	-->

						
<!--################ START FORM STYLE-->
 <table class="container" border="0" cellpadding="0" cellspacing="0" width="40%">
  <tbody><tr>
    <td width="1%" class="container_tl"><div></div></td>
    <td width="91%" class="container_tmid"><div>Insurance for creddit department</div></td>
    <td width="8%" class="container_tr"><div></div></td>
  </tr>
      <tr>
        <td class="container_l"></td>
        <td class="container_content">
        
<!--################ END FORM STYLE-->

 <table border="0" cellspacing="5" cellpadding="5" class="container">
        <tr>          
            <td nowrap="nowrap">
                <span class="txtlbl">Please enter valid data!</span>
                <span class="required" >(* Required fields)</span><br />
                <asp:Label ID="LblMsg" runat="server"></asp:Label>
                <asp:TextBox ID="TxtTProgramID" runat="server" Height="22px" Visible="False" 
                    Width="64px"></asp:TextBox>
                    
            </td>
            <td>
                
            </td>       
        </tr>
        
        <tr>
        <asp:HiddenField ID="hdnCustomerId" runat="server" />
            <td class="txtlbl" colspan="2">
                  Customer Name <span class="errormsg">*</span>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" 
                    runat="server" ControlToValidate="TxtCustomerId" Display="Dynamic" ErrorMessage="Required!" 
                   ValidationGroup="Paticipant" SetFocusOnError="True"></asp:RequiredFieldValidator>
                    <br />
                   <cc1:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server"
                    DelimiterCharacters="" Enabled="true" ServicePath="~/Autocomplete.asmx" ServiceMethod="GetCustomerListForWorkflow"
                    TargetControlID="TxtCustomerId" MinimumPrefixLength="1" CompletionInterval="10" 
                    EnableCaching="true" CompletionListCssClass="autocompleteTextBoxLP" OnClientItemSelected="OnCustomerSelection">
               </cc1:AutoCompleteExtender>
               
                <asp:TextBox ID="TxtCustomerId" runat="server" CssClass="inputTextBoxLP" 
                     Width="300px" AutoComplete="off" ontextchanged="TxtCustomerId_TextChanged" ></asp:TextBox>  
                           
               <cc1:TextBoxWatermarkExtender ID="TxtCustomerCode_TextBoxWatermarkExtender" 
                   runat="server" Enabled="True" TargetControlID="TxtCustomerId" 
                   WatermarkCssClass="watermark" WatermarkText="Auto complete">
               </cc1:TextBoxWatermarkExtender>
           </td>       
        </tr>
        <tr>
            <td class="txtlbl"> Insurer Name<span class="errormsg">*</span>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" 
                        runat="server" ControlToValidate="DdlInsurerName" Display="Dynamic" ErrorMessage="Required!" 
                       ValidationGroup="Paticipant" SetFocusOnError="True">
                </asp:RequiredFieldValidator><br />
            
                <asp:DropDownList ID="DdlInsurerName" runat="server" CssClass="CMBDesign" >
                </asp:DropDownList>
                   <td class="txtlbl">
                Insured Amount <span class="errormsg">*</span>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" 
                    ControlToValidate="txtInsuredAmount" Display="Dynamic" ErrorMessage="Required!" 
                    SetFocusOnError="True" ValidationGroup="Paticipant"></asp:RequiredFieldValidator>
                <asp:TextBox ID="txtInsuredAmount" runat="server" CssClass="inputTextBoxLP" 
                    Width="295px"></asp:TextBox>
            </td>
                
                
   </tr>
            
            
            <tr>
                <td>
                Insured Date <span class="errormsg">*</span>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                    ControlToValidate="txtInuredDate" Display="Dynamic" ErrorMessage="Required!" 
                    SetFocusOnError="True" ValidationGroup="Paticipant"></asp:RequiredFieldValidator>
                <asp:TextBox ID="txtInuredDate" runat="server" CssClass="inputTextBoxLP" 
                    Width="295px"></asp:TextBox>
                    
                     
                    
                       <cc1:CalendarExtender ID="txtInuredDate_CalendarExtender" runat="server" 
                        Enabled="True" TargetControlID="txtInuredDate">
                    </cc1:CalendarExtender>
                    
                     
                    
                       <td class="txtlbl">
                Expiry Date<span class="errormsg">*</span>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" 
                    ControlToValidate="txtExpiredDate" Display="Dynamic" ErrorMessage="Required!" 
                    SetFocusOnError="True" ValidationGroup="Paticipant"></asp:RequiredFieldValidator>
                <asp:TextBox ID="txtExpiredDate" runat="server" CssClass="inputTextBoxLP" 
                    Width="295px"></asp:TextBox>
                           <cc1:CalendarExtender ID="txtExpiredDate_CalendarExtender" runat="server" 
                               Enabled="True" TargetControlID="txtExpiredDate">
                           </cc1:CalendarExtender>
            </td>
            </td>
        </tr>
        
        
        
        <tr>
             <td class="txtlbl">
                Insurance Policy  <span class="errormsg">*</span>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                    ControlToValidate="txtInsPolicy" Display="Dynamic" ErrorMessage="Required!" 
                    SetFocusOnError="True" ValidationGroup="Paticipant"></asp:RequiredFieldValidator>
                <asp:TextBox ID="txtInsPolicy" runat="server" CssClass="inputTextBoxLP" 
                    Width="295px"></asp:TextBox>
            </td>
            <td class="txtlbl">
                Insurance Property  <span class="errormsg">*</span>
               
                <asp:TextBox ID="txtInsPropery" runat="server" CssClass="inputTextBoxLP" 
                    Width="295px"></asp:TextBox>
            </td>
        </tr>
        
        
        
        <tr>
         <td class="txtlbl">
                Risk Coverage  <br />
                    
                <asp:TextBox ID="txtRiskCoverage" runat="server" CssClass="inputTextBoxLP" 
                    Width="295px"></asp:TextBox>
        </td>
         <td valign="top" class="txtlbl"> 
                
              Narration<br />
                <asp:TextBox ID="txtNarration" runat="server" CssClass="inputTextBoxLP" 
                    TextMode="MultiLine" Width="200px" Height="35px"></asp:TextBox>        
         </td>  
         
     
       <tr>
            <td colspan="2">
                <asp:Button ID="Btn_Save" runat="server" CssClass="button" 
                    onclick="Btn_Save_Click" Text="Save" ValidationGroup="Paticipant" 
                    width="75px" />
            <cc1:ConfirmButtonExtender ID="Btn_Save_ConfirmButtonExtender" runat="server" 
                    ConfirmText="Confirm To Save ?" Enabled="True" TargetControlID="Btn_Save">
                </cc1:ConfirmButtonExtender>  
                
             
                <asp:Button ID="Btn_Delete" runat="server" CssClass="button" 
                    onclick="Btn_Delete_Click" Text="Delete" width="75px" />
               <cc1:ConfirmButtonExtender ID="Btn_Delete_ConfirmButtonExtender" runat="server" 
                    ConfirmText="Confirm ToDelete ?" Enabled="True" TargetControlID="Btn_Delete">
                </cc1:ConfirmButtonExtender>
                <asp:Button ID="Btn_Back" runat="server" CssClass="button" Text="&lt;&lt; Back" 
                    width="75px" onclick="Btn_Back_Click" />
            </td>
        </tr>
            <!--################ START FORM STYLE-->
            <tr>
                <td class="container_r">
                </td>
            </tr>
            <tr>
                <td class="container_bl">
                </td>
                <td class="container_bmid">
                </td>
                <td class="container_br">
                </td>
            </tr>
        </tr> 
        
   
<script  language=javascript>
    function OnCustomerSelection(sender, e) {
        var customerValueArray = (e._value).split("|");
        document.getElementById("hdnCustomerId").Value = customerValueArray[1];
    }    
</script>     
        
        
        
           
        </table>
    
<!--################ START FORM STYLE-->

	                        <!--		End  content	-->

	</td>
  </tr>
	</tbody>
  </table>

              </td>
					</tr>
			  </table>			</td>
		  </tr>
	</table>	</td>
  </tr>
</table>

</ContentTemplate>
</asp:UpdatePanel>
</asp:Content>
