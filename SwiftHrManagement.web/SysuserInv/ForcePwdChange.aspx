<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ForcePwdChange.aspx.cs" Inherits="SwiftHrManagement.web.SysuserInv.ForcePwdChange" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="/Css/style.css" rel="Stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <table width="100%" height="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td valign="top">
		<table width="100%" height="100%" border="0" cellspacing="0" cellpadding="0">
		  <tr> 
			<td valign="top">
				<table width="100%" border="0" cellspacing="0" cellpadding="0">
					<tr>
						<td valign="bottom" class="wellcome"><img src="/images/spacer.gif" width="5" height="1"><img src="/images/big_bullit.gif">&nbsp;&nbsp;Chanage Password</td>
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
 <table class="container" border="0" cellpadding="0" cellspacing="0" width="20%">
  <tbody><tr>
    <td width="1%" class="container_tl"><div></div></td>
    <td width="91%" class="container_tmid"><div>Change Password</div></td>
    <td width="8%" class="container_tr"><div></div></td>
  </tr>
      <tr>
        <td class="container_l"></td>
        <td class="container_content">
<!--################ END FORM STYLE-->


     <table border="0" cellspacing="2" cellpadding="2" class="container"> 
        <tr>
            <td colspan="2">
                <span class="txtlbl">Please enter valid data!</span><span class="errormsg"> (* Required Fields)</span>
            </td>
        </tr>     
        <tr>       
            <td>&nbsp;         
            </td>
            <td> <asp:Label ID="LblMsg" runat="server"></asp:Label>
                <asp:CompareValidator ID="CompareValidator1" runat="server" 
                    ControlToCompare="TxtNewPass" ControlToValidate="TxtConfirmPass" 
                    ErrorMessage="Password Not matched!!" Display="Dynamic" 
                    ValidationGroup="pass"></asp:CompareValidator>
            </td>
        </tr>
        <tr>
       
          <td class="txtlbl"><div align="right" class="">Old Password :</div></td>              
          <td align="left" nowrap="nowrap">                
                <asp:TextBox ID="TxtOldPass" runat="server" CssClass="inputTextBoxLP" TextMode="Password"></asp:TextBox>
                <span class="errormsg">*</span>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ErrorMessage="RequiredFieldValidator" ControlToValidate="TxtOldPass" 
                    Display="None" ValidationGroup="pass" SetFocusOnError="True"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
   
            <td class="txtlbl"><div align="right" class="">
                New Password :</div></td>
           <td align="left" nowrap="nowrap">
                <asp:TextBox ID="TxtNewPass" runat="server" CssClass="inputTextBoxLP" TextMode="Password"></asp:TextBox>
                <span class="errormsg">*</span><asp:RequiredFieldValidator 
                    ID="RequiredFieldValidator2" runat="server" ControlToValidate="TxtNewPass" 
                    Display="None" ErrorMessage="RequiredFieldValidator" 
                    ValidationGroup="pass" SetFocusOnError="True"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>

            <td class="txtlbl" nowrap="nowrap"><div align="right" class="">Confirm Password :</div>
                </td>
            <td align="left" nowrap="nowrap">
                <asp:TextBox ID="TxtConfirmPass" runat="server" CssClass="inputTextBoxLP" TextMode="Password"></asp:TextBox>
                <span class="errormsg">*</span><asp:RequiredFieldValidator 
                    ID="RequiredFieldValidator3" runat="server" ControlToValidate="TxtConfirmPass" 
                    Display="None" ErrorMessage="RequiredFieldValidator" 
                    ValidationGroup="pass" SetFocusOnError="True"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
        <td></td><td></td>
        </tr>
          <tr>

            <td>
                </td>
            <td align="left">
                <asp:Button ID="Btn_Save" runat="server" CssClass="button" Text="Update" 
                    onclick="Btn_Save_Click" ValidationGroup="pass" Width="75px" />
                <cc1:ConfirmButtonExtender ID="Btn_Save_ConfirmButtonExtender" runat="server" 
                    ConfirmText="Confirm To Update Your Password?" Enabled="True" 
                    TargetControlID="Btn_Save">
                </cc1:ConfirmButtonExtender>
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
    </form>
</body>
</html>
