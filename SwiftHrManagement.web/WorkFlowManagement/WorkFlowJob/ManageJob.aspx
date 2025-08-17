<%@ Page Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="ManageJob.aspx.cs" Inherits="SwiftHrManagement.web.WorkFlowManagement.WorkFlowJob.ManageJob" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">  

</asp:Content>
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
    <td width="91%" class="container_tmid"><div>Lodging of Job</div></td>
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
            <td class="txtlbl" colspan="2">
                  Customer Name <span class="errormsg">*</span>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" 
                    runat="server" ControlToValidate="TxtCustomerCode" Display="Dynamic" ErrorMessage="Required!" 
                   ValidationGroup="Paticipant" SetFocusOnError="True"></asp:RequiredFieldValidator>
                    <br />
                   <cc1:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server"
                    DelimiterCharacters="" Enabled="true" ServicePath="~/Autocomplete.asmx" ServiceMethod="GetCustomerListForWorkflow"
                    TargetControlID="TxtCustomerCode" MinimumPrefixLength="1" CompletionInterval="10" 
                    EnableCaching="true" CompletionListCssClass="autocompleteTextBoxLP" >
               </cc1:AutoCompleteExtender>
               
                <asp:TextBox ID="TxtCustomerCode" runat="server" CssClass="inputTextBoxLP" 
                     Width="600px" AutoComplete="off" ></asp:TextBox>  
                           
               <cc1:TextBoxWatermarkExtender ID="TxtCustomerCode_TextBoxWatermarkExtender" 
                   runat="server" Enabled="True" TargetControlID="TxtCustomerCode" 
                   WatermarkCssClass="watermark" WatermarkText="Auto complete">
               </cc1:TextBoxWatermarkExtender>
           </td>       
        </tr>
        <tr>
            <td class="txtlbl"> Department<span class="errormsg">*</span>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" 
                        runat="server" ControlToValidate="DdlDeptName" Display="Dynamic" ErrorMessage="Required!" 
                       ValidationGroup="Paticipant" SetFocusOnError="True">
                </asp:RequiredFieldValidator><br />
                 <asp:DropDownList ID="DdlDeptName" runat="server" CssClass="CMBDesign" 
                        AutoPostBack="True" Width="295px" 
                    onselectedindexchanged="DdlDeptName_SelectedIndexChanged">
                    <asp:ListItem Value="">Select</asp:ListItem>
                    <asp:ListItem Value="Corporate">Corporate</asp:ListItem>
                    <asp:ListItem Value="SME">SME</asp:ListItem>
                    <asp:ListItem Value="Micro">Micro</asp:ListItem>   
                </asp:DropDownList>
            </td>
            <td>           
            Job Category <span class="errormsg">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" 
                    runat="server" ControlToValidate="DdlJobCategory" Display="Dynamic" 
                    ErrorMessage="Required!" ValidationGroup="Paticipant" 
                    SetFocusOnError="True"></asp:RequiredFieldValidator>
                 </span><br />
                <asp:DropDownList ID="DdlJobCategory" runat="server" CssClass="CMBDesign" 
                        AutoPostBack="True" onselectedindexchanged="DdlJobCategory_SelectedIndexChanged" Width="295px">
                </asp:DropDownList>
            </td>
        </tr>    
        <tr> 
            <td>Job Code (Ref. No.) <span class="errormsg">*</span>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" 
                    runat="server" ControlToValidate="txtJobCode" Display="Dynamic" 
                    ErrorMessage="Required!" ValidationGroup="Paticipant" 
                    SetFocusOnError="True"></asp:RequiredFieldValidator>
                <asp:TextBox ID="txtJobCode" runat="server" CssClass="inputTextBoxLP" Width="295px"></asp:TextBox> 
            </td>
            <td class="txtlbl">
                Forward To   <span class="errormsg">*</span>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" 
                    runat="server" ControlToValidate="DdlStaffName" Display="Dynamic" 
                    ErrorMessage="Required!" ValidationGroup="Paticipant" 
                    SetFocusOnError="True"></asp:RequiredFieldValidator><br />
                <asp:DropDownList ID="DdlStaffName" runat="server" CssClass="CMBDesign" Width="295px">
                </asp:DropDownList>
            </td>  
        </tr>
        
        <tr>
         <td valign="top" class="txtlbl" colspan="2">        
                Job Details <span class="errormsg">*</span><asp:RequiredFieldValidator ID="RequiredFieldValidator1" 
                    runat="server" ControlToValidate="TxtJobDescription" Display="Dynamic" ErrorMessage="Required!" 
                    ValidationGroup="Paticipant" SetFocusOnError="True"></asp:RequiredFieldValidator><br />
                <asp:TextBox ID="TxtJobDescription" runat="server" CssClass="inputTextBoxLP" 
                    TextMode="MultiLine" Width="600px" Height="35px"></asp:TextBox>        
         </td>             
       </tr>                                               
        <tr>
            <td colspan="2">
                <asp:Button ID="Btn_Save" runat="server" CssClass="button" 
                    onclick="Btn_Save_Click" Text="Save" ValidationGroup="Paticipant" width="75px"/>
                <cc1:ConfirmButtonExtender ID="Btn_Save_ConfirmButtonExtender" runat="server" 
                    ConfirmText="Confirm To Save ?" Enabled="True" TargetControlID="Btn_Save">
                </cc1:ConfirmButtonExtender>
                    <asp:Button ID = "Btn_Update" Text="Save"  runat = "server" 
                    CssClass="button" onclick="Btn_Update_Click" width="75px"/>                                             
                <cc1:ConfirmButtonExtender ID="Btn_Update_ConfirmButtonExtender" runat="server" 
                    ConfirmText="Confirm To Save ?" Enabled="True" TargetControlID="Btn_Update">
                </cc1:ConfirmButtonExtender>
                <asp:Button ID="Btn_Delete" runat="server" Text="Delete" CssClass="button" 
                    onclick="Btn_Delete_Click" width="75px"/>
                <cc1:ConfirmButtonExtender ID="Btn_Delete_ConfirmButtonExtender" runat="server" 
                    ConfirmText="Confirm ToDelete ?" Enabled="True" TargetControlID="Btn_Delete">
                </cc1:ConfirmButtonExtender>
                <asp:Button ID="Btn_Back" runat="server" CssClass="button" Text="&lt;&lt; Back" width="75px"/>  
            </td>                                        
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
</ContentTemplate>
</asp:UpdatePanel>
</asp:Content>