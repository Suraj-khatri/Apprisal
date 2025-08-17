<%@ Page Title="" Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="IndividualTaxReport.aspx.cs" Inherits="SwiftHrManagement.web.Report.PayRollReport.IndividualTaxReport" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
<table width="100%" height="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td valign="top">
		<table width="80%" height="100%" border="0" cellspacing="0" cellpadding="0">
		  <tr> 
			<td valign="top">
				<table width="100%" border="0" cellspacing="0" cellpadding="0">
					<tr>
						<td valign="bottom" class="wellcome">
						<img src="/images/spacer.gif" width="5" height="1">
						<img src="/images/big_bullit.gif">&nbsp;Tax Report</td>
					</tr>
					<tr>
						<td valign="top" bgcolor="#999999" height="1"><img src="/images/spacer.gif" width="100%" height="1"></td>
					</tr>
				</table>
				<table width="400" border="0" cellspacing="0" cellpadding="0" align="center">
					<tr>
						<td valign="top" align="center"><br>

						<!--		Begin content	-->

<!--################ START FORM STYLE-->
 <table class="container" border="0" cellpadding="0" cellspacing="0" width="100%">
  <tbody><tr>
    <td width="1%" class="container_tl"><div></div></td>
    <td width="91%" class="container_tmid"><div>TAX REPORT</div></td>
    <td width="8%" class="container_tr"><div></div></td>
  </tr>
      <tr>
        <td class="container_l"></td>
        <td class="container_content">
        
<!--################ END FORM STYLE-->

<table border="0" cellspacing="2" cellpadding="2" class="container" >            
    
  <tr>
        <td><div align="right" class="text_form1">Year :</div></td>
        <td>
                <span class="errormsg">
                <asp:DropDownList ID="DdlYear" runat="server" CssClass="FltCMBDesign">
                </asp:DropDownList>
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator2" 
                    runat="server" ControlToValidate="DdlYear" Display="Dynamic" 
                    ErrorMessage="Required!" ValidationGroup="report" SetFocusOnError="True"></asp:RequiredFieldValidator>
                *</span>    
       </td>
    </tr>
    <tr>
        <td><div align="right" class="text_form1">Month :</div></td>
        <td>
                <span class="errormsg">
                <asp:DropDownList ID="DdlMonthName" runat="server" CssClass="FltCMBDesign">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" 
                    runat="server" ControlToValidate="DdlMonthName" Display="Dynamic" 
                    ErrorMessage="Required!" ValidationGroup="report" SetFocusOnError="True"></asp:RequiredFieldValidator>
                *</span>
       </td>
    </tr>
    <tr>
                            <td>&nbsp;</td>
                            <td>
                                <asp:Button ID="ButtonSearch" runat="server" CssClass="button" Text="Search" 
                                    onclick="ButtonSearch_Click" ValidationGroup="report" />
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
            </td>
					</tr>
			  </table>
			  </td>
		  </tr>
	</table>
	</td>
  </tr>
</table>
</asp:Content>
