<%@ Page Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="SwiftHrManagement.web.TrainingManagement.TrainingFeedback.Manage" Title="Swift HRM" %>
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
						<img src="/images/big_bullit.gif">&nbsp;&nbsp;Training Feedback Entry Details</td>
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
    <td width="91%" class="container_tmid"><div>Training Feedback Entry Details</div></td>
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
                <asp:Label ID="LblMsg" runat="server"></asp:Label>
            </td>      
        </tr>
        <tr>
            <td valign="top" class="txtlbl">
                Select Training Program Title:  <span class="errormsg">*</span>
                
                    <asp:RequiredFieldValidator ID="rfc" runat="server" 
                ControlToValidate="DdlProgramName" Display="Dynamic" ErrorMessage="Required!" 
                SetFocusOnError="True" ValidationGroup="feedback">
                </asp:RequiredFieldValidator>
                <br />
                <asp:DropDownList ID="DdlProgramName" runat="server" CssClass="CMBDesign" Width="325px">
                </asp:DropDownList>
             </td>           
        </tr>     
        <tr>
            <td class="txtlbl">
                Feedback Details :  <span class="errormsg">*</span><asp:RequiredFieldValidator ID="RequiredFieldValidator2" 
                    runat="server" ControlToValidate="TxtFeedback" Display="Dynamic" 
                    ErrorMessage="Required!" ValidationGroup="feedback" 
                    SetFocusOnError="True"></asp:RequiredFieldValidator>
                <br />
                <asp:TextBox ID="TxtFeedback" runat="server" CssClass="inputTextBoxMultiLine" 
                    TextMode="MultiLine" Width="325px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="Btn_Save" runat="server" CssClass="button" 
                    onclick="Btn_Save_Click" Text="Save" ValidationGroup="feedback" />
                <cc1:ConfirmButtonExtender ID="Btn_Save_ConfirmButtonExtender" runat="server" 
                    ConfirmText="Confirm to Save?" Enabled="True" TargetControlID="Btn_Save">
                </cc1:ConfirmButtonExtender>
                <asp:Button ID="BtnBack" runat="server" CssClass="button" 
                    onclick="BtnBack_Click" Text="&lt;&lt; Back" />
                </td>
            <td>
                &nbsp;</td>
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

