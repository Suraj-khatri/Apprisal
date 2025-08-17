<%@ Page Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="SwiftHrManagement.web.WorkFlowManagement.WorkFlowCategory.Manage" Title="Swift HR Management System 1.0" %>
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
						<img src="/images/big_bullit.gif">&nbsp;Work Flow Category Entry Details</td>
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
    <td width="91%" class="container_tmid"><div>Work Flow Category Entry Details</div></td>
    <td width="8%" class="container_tr"><div></div></td>
  </tr>
      <tr>
        <td class="container_l"></td>
        <td class="container_content">
        
<!--################ END FORM STYLE-->
<asp:UpdatePanel ID="updatepanel1" runat="server">
<ContentTemplate>
 <table border="0" cellspacing="5" cellpadding="5" class="container">  
    <tr>
        <td colspan="2">
            <span class="txtlbl">Please enter valid data!</span>
            <span class="required" >(* Required fields)</span><br />
            <asp:Label ID="LblMsg" runat="server"></asp:Label><br />
         </td> 
    </tr>
    <tr>
        <td valign="top" class="txtlbl" colspan="2">
                Department Name <span class="errormsg">*</span><asp:RequiredFieldValidator ID="RequiredFieldValidator3" 
                    runat="server" ControlToValidate="DdlDeptName" Display="Dynamic" ErrorMessage="Required!" 
                    ValidationGroup="List" SetFocusOnError="True"></asp:RequiredFieldValidator><br />
                <asp:DropDownList ID="DdlDeptName" runat="server" CssClass="CMBDesign" Width="414px">
                    <asp:ListItem Value="">Select</asp:ListItem>
                    <asp:ListItem Value="Corporate">Corporate</asp:ListItem>
                    <asp:ListItem Value="SME">SME</asp:ListItem>
                    <asp:ListItem Value="Micro">Micro</asp:ListItem>                
                </asp:DropDownList>
        </td>                   
    </tr>
    <tr>
        <td valign="top" class="txtlbl" colspan="2">
                Category Name <span class="errormsg">*</span><asp:RequiredFieldValidator ID="RequiredFieldValidator1" 
                    runat="server" ControlToValidate="TxtCatName" Display="Dynamic" ErrorMessage="Required!" 
                    ValidationGroup="List" SetFocusOnError="True"></asp:RequiredFieldValidator><br />
                <asp:TextBox ID="TxtCatName" runat="server" CssClass="inputTextBoxLP" 
                    Width="414px"></asp:TextBox>
        </td>                   
    </tr>
    <tr>
         <td valign="top" class="txtlbl" colspan="2">        
                Category Details <span class="errormsg">*</span><asp:RequiredFieldValidator ID="RequiredFieldValidator2" 
                    runat="server" ControlToValidate="TxtCatDetails" Display="Dynamic" ErrorMessage="Required!" 
                    ValidationGroup="List" SetFocusOnError="True"></asp:RequiredFieldValidator><br />
                <asp:TextBox ID="TxtCatDetails" runat="server" CssClass="inputTextBoxLP" 
                    TextMode="MultiLine" Width="417px" Height="47px"></asp:TextBox>        
        </td>             
    </tr>
    <tr>
        <td>  
            <asp:Button ID="Btn_Save" runat="server" CssClass="button" 
                onclick="Btn_Save_Click" Text="Save" ValidationGroup="List" Width="75px" />
            <cc1:ConfirmButtonExtender ID="Btn_Save_ConfirmButtonExtender" runat="server" 
                ConfirmText="Confirm to Save ?" Enabled="True" TargetControlID="Btn_Save">
            </cc1:ConfirmButtonExtender>
            &nbsp;<asp:Button ID="Btn_Delete" runat="server" CssClass="button" 
                onclick="Btn_Delete_Click" Text="Delete" Width="75px" />
            <cc1:ConfirmButtonExtender ID="Btn_Delete_ConfirmButtonExtender" runat="server" 
                ConfirmText="Confirm to Delete ?" Enabled="True" TargetControlID="Btn_Delete">
            </cc1:ConfirmButtonExtender>
            &nbsp;<asp:Button ID="Btn_Back" runat="server" CssClass="button" 
                 OnClick="Btn_Back_Click" Text="&lt;&lt; Back" Width="75px" />
            </td>
        <td>&nbsp;</td>  
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
</asp:Content>
