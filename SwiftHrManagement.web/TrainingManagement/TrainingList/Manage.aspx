<%@ Page Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="SwiftHrManagement.web.TrainingList.Manage" Title="Swift HRM" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
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
						<img src="/images/spacer.gif" width="5" height="1">
						<img src="/images/big_bullit.gif">&nbsp;&nbsp;Training Category Entry Details</td>
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
    <td width="91%" class="container_tmid"><div>Training Category Entry Details</div></td>
    <td width="8%" class="container_tr"><div></div></td>
  </tr>
      <tr>
        <td class="container_l"></td>
        <td class="container_content">
        
<!--################ END FORM STYLE-->

 <table border="0" cellspacing="5" cellpadding="5" class="container">  
    <tr>
        <td colspan="2">
            <span class="txtlbl">Please enter valid data</span><br />
            <span class="required" >(* Required fields)</span><br />
            <asp:Label ID="LblMsg" runat="server"></asp:Label><br />
         </td> 
    </tr>
    <tr>
        <td valign="top" class="txtlbl" colspan="2">
                Category Title <span class="errormsg">*</span><asp:RequiredFieldValidator ID="RequiredFieldValidator1" 
                    runat="server" ControlToValidate="TxtTrnName" Display="None" ErrorMessage="*" 
                    ValidationGroup="List"></asp:RequiredFieldValidator>
                <br />
                <asp:TextBox ID="TxtTrnName" runat="server" CssClass="inputTextBoxLP" 
                    Width="414px"></asp:TextBox>
        </td>
       
            
    </tr>
    <tr>
         <td class="txtlbl">        
                Category Content <span class="errormsg">*</span><asp:RequiredFieldValidator ID="RequiredFieldValidator2" 
                    runat="server" ControlToValidate="TxtTranCnt" Display="None" ErrorMessage="*" 
                    ValidationGroup="List"></asp:RequiredFieldValidator>
                <br />
                <asp:TextBox ID="TxtTranCnt" runat="server" CssClass="inputTextBoxLP" 
                    TextMode="MultiLine"></asp:TextBox>
        
        </td>
         <td class="txtlbl"> Description
            <span class="errormsg">*</span><asp:RequiredFieldValidator ID="RequiredFieldValidator3" 
                    runat="server" ControlToValidate="TxtDsgFor" Display="None" ErrorMessage="*" 
                    ValidationGroup="List"></asp:RequiredFieldValidator>
                <br />
                <asp:TextBox ID="TxtDsgFor" runat="server" TextMode="MultiLine" 
                 CssClass="inputTextBoxLP"></asp:TextBox>
        
         </td>        
    </tr>
    <tr>
        <td>  
            <asp:Button ID="Btn_Save" runat="server" CssClass="button" 
                onclick="Btn_Save_Click" Text="Save" ValidationGroup="List" />
            <cc1:ConfirmButtonExtender ID="Btn_Save_ConfirmButtonExtender" runat="server" 
                ConfirmText="Confirm to save?" Enabled="True" TargetControlID="Btn_Save">
            </cc1:ConfirmButtonExtender>
            <asp:Button ID="BtnDelete" runat="server" CssClass="button" 
                onclick="BtnDelete_Click" Text="Delete" />
            <cc1:ConfirmButtonExtender ID="BtnDelete_ConfirmButtonExtender" runat="server" 
                ConfirmText="Are you sure to delete?" Enabled="True" 
                TargetControlID="BtnDelete">
            </cc1:ConfirmButtonExtender>
            <asp:Button ID="BtnBack" runat="server" CssClass="button" 
                onclick="BtnBack_Click" Text="&lt;&lt; Back" />
            </td>
        <td>&nbsp;</td>  
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
