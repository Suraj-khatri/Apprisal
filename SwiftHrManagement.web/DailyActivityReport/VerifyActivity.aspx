<%@ Page Title="" Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="VerifyActivity.aspx.cs" Inherits="SwiftHrManagement.web.DailyActivityReport.VerifyActivity" %>
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
						<img src="/images/spacer.gif" width="5" height="1"><img src="/images/big_bullit.gif">&nbsp;&nbsp;Activity Report</td>
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
    <td width="91%" class="container_tmid"><div>Activity Report</div></td>
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
            <td><div align="right" class="text_form">Branch :</div></td>
            <td nowrap="nowrap">
                <asp:DropDownList ID="ddlBranch" runat="server" CssClass="FltCMBDesign" AutoPostBack="true" 
                    Width="200px" onselectedindexchanged="ddlBranch_SelectedIndexChanged"></asp:DropDownList>&nbsp;<span class="required">*</span>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                    ErrorMessage="Required!" ControlToValidate="ddlBranch" Display="Dynamic" 
                    SetFocusOnError="True" ValidationGroup="bday"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td><div align="right" class="text_form">Department :</div></td>
            <td nowrap="nowrap">
                <asp:DropDownList ID="ddlDepartment" runat="server" CssClass="FltCMBDesign" AutoPostBack="true" 
                    Width="200px" onselectedindexchanged="ddlDepartment_SelectedIndexChanged"></asp:DropDownList>&nbsp;<span class="required">*</span>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ErrorMessage="Required!" ControlToValidate="ddlBranch" Display="Dynamic" 
                    SetFocusOnError="True" ValidationGroup="bday"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td><div align="right" class="text_form">Employee :</div></td>
            <td nowrap="nowrap">
                <asp:DropDownList ID="ddlEmployee" runat="server" CssClass="FltCMBDesign" Width="200px"></asp:DropDownList>&nbsp;<span class="required">*</span>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ErrorMessage="Required!" ControlToValidate="ddlBranch" Display="Dynamic" 
                    SetFocusOnError="True" ValidationGroup="bday"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>            
            <td nowrap="nowrap"><div align="right" class="text_form">From Date :</div></td>
            <td nowrap="nowrap">
                <asp:TextBox ID="txtFromDate" runat="server" CssClass="inputTextBoxLP1"></asp:TextBox>&nbsp;
                            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" 
                    Enabled="True" TargetControlID="txtFromDate">
                </cc1:CalendarExtender>
            </td>
        </tr>
        <tr>
            <td nowrap="nowrap"><div align="right" class="text_form">To Date :</div></td>
            <td nowrap="nowrap">
            <asp:TextBox ID="txtToDate" runat="server" CssClass="inputTextBoxLP1" 
                    MaxLength="100"></asp:TextBox>&nbsp;
                    <cc1:CalendarExtender ID="CalendarExtender2" runat="server" 
                    Enabled="True" TargetControlID="txtToDate">
                </cc1:CalendarExtender>           
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:Button ID="btnSearch" runat="server" CssClass="button" 
                     Text="Search" onclick="btnSearch_Click" />
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
