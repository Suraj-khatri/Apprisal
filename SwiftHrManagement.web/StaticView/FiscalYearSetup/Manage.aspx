<%@ Page Title="" Language="C#" MasterPageFile="~/Apprisal.Master" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="SwiftHrManagement.web.StaticView.FiscalYearSetup.Manage" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style10
        {
        }
        .style11
        {
            font-weight: bold;
            color: #333333;
            width: 139px;
        }
    </style>
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
						<img src="/images/spacer.gif" width="5" height="1"><img src="/images/big_bullit.gif">&nbsp;&nbsp;Fiscal 
                            Year Setup</td>
					</tr>
					<tr>
						<td valign="top" bgcolor="#999999" height="1"><img src="/images/spacer.gif" width="100%" height="1"></td>
					</tr>
				</table>
				<table width="60%" border="0" cellspacing="0" cellpadding="0">
					<tr>
						<td valign="top" align="center"><br>

						<!--		Begin content	-->

						
<!--################ START FORM STYLE-->
 <table class="container" border="0" cellpadding="0" cellspacing="0" width="30%">
  <tbody><tr>
    <td width="1%" class="container_tl"><div></div></td>
    <td width="91%" class="container_tmid"><div>Fiscal Year Setup</div></td>
    <td width="8%" class="container_tr"><div></div></td>
  </tr>
      <tr>
        <td class="container_l"></td>
        <td class="container_content">
        
<!--################ END FORM STYLE-->

 <table border="0" cellspacing="5" cellpadding="5" class="container">

        <tr>
            <td class="style10">
                <span class="txtlbl" >Please enter valid  data</span><br />
                <span class="required" >(* Required fields)</span><br />             
                <asp:Label ID="LblMsg" runat="server"></asp:Label>          
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style11">
                <asp:RequiredFieldValidator ID="Rfvfye" runat="server" 
                    ControlToValidate="TxtfyEnglish" Display="None" ErrorMessage="*" 
                    SetFocusOnError="True" ValidationGroup="fisyear"></asp:RequiredFieldValidator>
                <br />
                Fiscal Year English<span class ="errormsg">*</span><br />
                <asp:TextBox ID="TxtfyEnglish" runat="server" CssClass="inputTextBoxLP" 
                    Width="100px"></asp:TextBox>
            </td>
            <td class="txtlbl">
                <asp:RequiredFieldValidator ID="Rfvyn" runat="server" 
                    ControlToValidate="TxtFyNepali" Display="None" ErrorMessage="*" 
                    SetFocusOnError="True" ValidationGroup="fisyear"></asp:RequiredFieldValidator>
                <br />
                FiscalYearNepali<span class ="errormsg">*</span><br />
                <asp:TextBox ID="TxtFyNepali" runat="server" CssClass="inputTextBoxLP" 
                    Height="19px" Width="106px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style11">
                <asp:RequiredFieldValidator ID="Rfvesd" runat="server" 
                    ControlToValidate="TxtEngStartDate" Display="None" ErrorMessage="*" 
                    SetFocusOnError="True" ValidationGroup="fisyear"></asp:RequiredFieldValidator>
                <br />
                English Year Start Date<samp class="errormsg">*</samp><br />
                <asp:TextBox ID="TxtEngStartDate" runat="server" CssClass="inputTextBoxLP" 
                    Width="99px"></asp:TextBox>
                <cc1:CalendarExtender ID="TxtEngStartDate_CalendarExtender" runat="server" 
                    Enabled="True" TargetControlID="TxtEngStartDate">
                </cc1:CalendarExtender>
            </td>
            <td class="txtlbl">
                <asp:RequiredFieldValidator ID="Rfved" runat="server" 
                    ControlToValidate="TxtEngyearEndDate" Display="None" ErrorMessage="*" 
                    SetFocusOnError="True" ValidationGroup="fisyear"></asp:RequiredFieldValidator>
                <br />
                English Year End Date<span class="errormsg">*</span><br />
                <asp:TextBox ID="TxtEngyearEndDate" runat="server" CssClass="inputTextBoxLP" 
                    Width="106px"></asp:TextBox>
                <cc1:CalendarExtender ID="TxtEngyearEndDate_CalendarExtender" runat="server" 
                    Enabled="True" TargetControlID="TxtEngyearEndDate">
                </cc1:CalendarExtender>
            </td>
        </tr>
        <tr>
            <td class="style11">
                Is Current Year<br />
                <asp:CheckBox ID="ChkCurrent" runat="server" />
            </td>
            <td class="txtlbl">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style10" colspan="2">
                <asp:Button ID="BtnSave" runat="server" CssClass="button" 
                    onclick="BtnSave_Click" Text="Save" ValidationGroup="fisyear" />
                &nbsp;<asp:Button ID="BtnBack" runat="server" CssClass="button" 
                    onclick="BtnBack_Click" Text="&lt;&lt; Back" ValidationGroup="fisyear" />
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
</asp:Content>
