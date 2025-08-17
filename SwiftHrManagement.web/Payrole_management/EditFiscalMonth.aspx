<%@ Page Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="EditFiscalMonth.aspx.cs" Inherits="SwiftHrManagement.web.Payrole_management.EditFiscalMonth" Title="Swift HRM" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
<table width="100%" height="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td valign="top">
		<table width="60%" height="100%" border="0" cellspacing="0" cellpadding="0">
		  <tr> 
			<td valign="top">
				<table width="100%" height="30" border="0" cellspacing="0" cellpadding="0">
					<tr>
						<td valign="bottom" class="wellcome">
						<img src="/images/spacer.gif" width="5" height="1"><img src="/images/big_bullit.gif">&nbsp;Fiscal 
                            Month Setup</td>
					</tr>
					<tr>
						<td valign="top" bgcolor="#999999" height="1"><img src="/images/spacer.gif" width="100%" height="1"></td>
					</tr>
				</table>
				<table width="99%" border="0" cellspacing="0" cellpadding="0">
					<tr>
						<td valign="top" align="center"><br>

						<!--		Begin content	-->

						<!--		Begin content	-->
<!--################ START FORM STYLE-->
 <table class="container" border="0" cellpadding="0" cellspacing="0" width="40%">
  <tbody><tr>
    <td width="1%" class="container_tl"><div></div></td>
    <td width="91%" class="container_tmid"><div>Fiscal Month Setup</div></td>
    <td width="8%" class="container_tr"><div></div></td>
  </tr>
      <tr>
        <td class="container_l"></td>
        <td class="container_content">
        
<!--################ END FORM STYLE-->
    <table>    
<!--################ END FORM STYLE-->
    
        <tr>
            <td>&nbsp;</td>        
            <td><span class="errormsg">*Required field</span></td>        
        </tr>
    
        <tr>
            <td>&nbsp;</td>        
            <td><asp:Label ID="lblmessage" runat="server"></asp:Label></td>        
        </tr>
    
        <tr>
            <td><b>Fical Year</b></td>        
            <td><asp:Label ID="lblFiscalYear" Text="" runat="server"></asp:Label></td>        
        </tr>
        <tr>
            <td><b>Month</b></td>        
            <td><asp:Label ID="lblMonth" Text="" runat="server"></asp:Label></td>        
        </tr>
        <tr>
            <td><b>From [English]</b></td>        
            <td>
                <asp:RequiredFieldValidator ID="ReqFromengdate" runat="server" 
                    ControlToValidate="txtEngFrom" Display="None" 
                    ErrorMessage="*" SetFocusOnError="True" ValidationGroup="fiscalmonthedit"></asp:RequiredFieldValidator>
                <span class="errormsg">*</span><br />
                <asp:TextBox ID="txtEngFrom" runat="server" Text="" CssClass="inputTextBoxLP" 
                    Width="159px"></asp:TextBox> 
                <cc1:CalendarExtender ID="txtEngFrom_CalendarExtender" runat="server" 
                    Enabled="True" TargetControlID="txtEngFrom">
                </cc1:CalendarExtender>
            </td>
        </tr>
        <tr>
            <td><b>To [English]</b></td>        
            <td>
                <asp:RequiredFieldValidator ID="ReqToeng" runat="server" 
                    ControlToValidate="txtEngTo" Display="None" ErrorMessage="*" 
                    SetFocusOnError="True" ValidationGroup="fiscalmonthedit"></asp:RequiredFieldValidator>
                <span class="errormsg">*</span><br />
                <asp:TextBox ID="txtEngTo" runat="server" Text="" CssClass="inputTextBoxLP" 
                    Width="159px"></asp:TextBox> 
                <cc1:CalendarExtender ID="txtEngTo_CalendarExtender" runat="server" 
                    Enabled="True" TargetControlID="txtEngTo">
                </cc1:CalendarExtender>
            </td>
        </tr>        
        <tr>
            <td><b>From [Nepali]</b></td>        
            <td>
                <asp:RequiredFieldValidator ID="ReqNepFrom" runat="server" 
                    ControlToValidate="txtNepFrom" Display="None" ErrorMessage="*" 
                    SetFocusOnError="True" ValidationGroup="fiscalmonthedit"></asp:RequiredFieldValidator>
                <span class="errormsg">*</span><br />
                <asp:TextBox ID="txtNepFrom" runat="server" Text="" CssClass="inputTextBoxLP" 
                    Width="159px"></asp:TextBox> </td>
        </tr>
        <tr>
            <td><b>To [Nepali]</b></td>        
            <td>
                <asp:RequiredFieldValidator ID="ReqNepTo" runat="server" 
                    ControlToValidate="txtNepTo" Display="None" ErrorMessage="*" 
                    SetFocusOnError="True" ValidationGroup="fiscalmonthedit"></asp:RequiredFieldValidator>
                <span class="errormsg">*</span><br />
                <asp:TextBox ID="txtNepTo" runat="server" Text="" CssClass="inputTextBoxLP" 
                    Width="159px"></asp:TextBox> </td>
        </tr>
        <tr>
            <td></td>        
            <td><asp:Button ID="btnSave" runat="server" Text="Save" onclick="btnSave_Click" 
                    CssClass="button" ValidationGroup="fiscalmonthedit" /> </td>
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
