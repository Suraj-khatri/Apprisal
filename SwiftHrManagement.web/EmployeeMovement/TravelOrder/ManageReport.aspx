<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/SwiftHRManager.Master" CodeBehind="ManageReport.aspx.cs" Inherits="SwiftHrManagement.web.EmployeeMovement.TravelOrder.ManageReport" %>
  <%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style10
        {
            width: 153px;
            border-bottom: 2px solid white;
            background: url('/Images/topmiddle_big.gif') repeat-x;
        }
        .style11
        {
            font-style: normal;
            font-variant: normal;
            font-weight: normal;
            font-size: 11px;
            line-height: normal;
            font-family: Arial, Helvetica, sans-serif;
            color: #191919;
            width: 153px;
            padding: 10px;
            background-color: #f3f3f3;
        }
        .style12
        {
            height: 12px;
            width: 153px;
            background: url('/Images/container-bottom.gif') repeat-x 0 0;
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
						<img src="/images/spacer.gif" width="5" height="1"><img src="/images/big_bullit.gif">&nbsp;&nbsp;Travel Order Report</td>
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
 <table class="container" border="0" cellpadding="0" cellspacing="0" width="50%">
  <tbody><tr>
    <td width="1%" class="container_tl"><div></div></td>
    <td width="91%" class="container_tmid"><div>Travel Order Report</div></td>
    <td width="8%" class="container_tr"><div></div></td>
  </tr>
      <tr>
        <td class="container_l"></td>
        <td class="container_content">
        
<!--################ END FORM STYLE-->

 <table border="0" cellspacing="3" cellpadding="3" class="container">  
        <tr>
            <td>
                <asp:Label ID="lblMsg" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td><div align="right" class="text_form2">Branch :</div></td>
            <td nowrap="nowrap">
                <asp:DropDownList ID="ddlBranch" runat="server" CssClass="FltCMBDesign" Width="200px"></asp:DropDownList>&nbsp;<span class="required">*</span>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                    ErrorMessage="Required!" ControlToValidate="ddlBranch" Display="Dynamic" 
                    SetFocusOnError="True" ValidationGroup="bday"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>            
            <td nowrap="nowrap"><div align="right" class="text_form2">Request From Date :</div></td>
            <td nowrap="nowrap">
                <asp:TextBox ID="txtFromDate1" runat="server" CssClass="inputTextBoxLP1"></asp:TextBox>&nbsp;
                            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" 
                    Enabled="True" TargetControlID="txtFromDate1">
                </cc1:CalendarExtender>
            </td>
        </tr>
        <tr>
            <td nowrap="nowrap"><div align="right" class="text_form2">Request To Date :</div></td>
            <td nowrap="nowrap">
            <asp:TextBox ID="txtToDate1" runat="server" CssClass="inputTextBoxLP1" 
                    MaxLength="100"></asp:TextBox>&nbsp;
                    <cc1:CalendarExtender ID="CalendarExtender2" runat="server" 
                    Enabled="True" TargetControlID="txtToDate1">
                </cc1:CalendarExtender>           
            </td>
        </tr>
        <tr>
            <td><div align="right" class="text_form2">Status :</div></td>
            <td>
                <asp:DropDownList ID="ddlStatus" runat="server" CssClass="CMBDesign" Width="150px">
                    <asp:ListItem Value="b">Both</asp:ListItem>
                    <asp:ListItem Value="o">Out Standing</asp:ListItem>
                    <asp:ListItem Value="s">Settled</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:Button ID="BtnSearchBrthday" runat="server" CssClass="button" 
                     Text="View Report" onclick="BtnSearchBrthday_Click" 
                    ValidationGroup="bday" />
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
