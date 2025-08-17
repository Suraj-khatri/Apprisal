<%@ Page Title="" Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="ExternalTransferParameterised.aspx.cs" Inherits="SwiftHrManagement.web.Report.EmployeeMovements.ExternalTransfer.ExternalTransferParameterised" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    <table border="0" cellspacing="0" cellpadding="0" width="100%">
        <tr>
            <td valign="top">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td valign="top">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td valign="bottom" class="wellcome">
                                        <img src="/images/spacer.gif" width="5" height="1">
                                        <img src="/images/big_bullit.gif">&nbsp;&nbsp;Employee Extenal Transfer Plan (Parameterised)</td>
                                </tr>
                                <tr>
                                    <td valign="top" bgcolor="#999999" height="1">
                                        <img src="/images/spacer.gif" width="100%" height="1"></td>
                                </tr>
                            </table>
                            <table width="60%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td valign="top" align="center"><br />
                                    <!--		Begin content	-->
                                    
<!--################ START FORM STYLE-->
 <table class="container" border="0" cellpadding="0" cellspacing="0" width="30%">
  <tbody><tr>
    <td width="1%" class="container_tl"><div></div></td>
    <td width="91%" class="container_tmid"><div>Extenal Transfer Plan (Parameterised)</div></td>
    <td width="8%" class="container_tr"><div></div></td>
  </tr>
      <tr>
        <td class="container_l"></td>
        <td class="container_content">
        
<!--################ END FORM STYLE-->  

    <table border="0" cellspacing="5" cellpadding="5" class="container">
         <tr>
            <td><div align="right" class="text_form1">Report Type :</div></td>
            <td>
                <asp:RadioButtonList ID="RdbListRptType" runat="server" 
                    RepeatDirection="Horizontal">
                    <asp:ListItem>Planned</asp:ListItem>
                    <asp:ListItem>Approved</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td><div align="right" class="text_form1">To Branch :</div></td>
            <td>
                <asp:DropDownList ID="DdlBranchName" runat="server" CssClass="FltCMBDesign">
                </asp:DropDownList>
            </td>
        </tr>       
        <tr>
            <td><div align="right" class="text_form1">From Date :</div></td>
            <td>
                <asp:TextBox ID="TxtfromDate" runat="server" CssClass="inputTextBoxLP1"></asp:TextBox>
                <cc1:CalendarExtender ID="TxtfromDate_CalendarExtender" runat="server" 
                    Enabled="True" TargetControlID="TxtfromDate">
                </cc1:CalendarExtender>
            </td>
        </tr>
        <tr>
            <td><div align="right" class="text_form1">To Date :</div></td>
            <td>
                <asp:TextBox ID="TxtToDate" runat="server" CssClass="inputTextBoxLP1"></asp:TextBox>
                <cc1:CalendarExtender ID="TxtfromDate0_CalendarExtender" runat="server" 
                    Enabled="True" TargetControlID="TxtToDate">
                </cc1:CalendarExtender>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:Button ID="BtnViewRpt" runat="server" CssClass="button" 
                onclick="BtnViewRpt_Click" Text="Show Report" Width="73px" />
            </td>
        </tr>
    </table>
  
<!--START FORM STYLE-->

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

<!--END FORM STYLE-->


	<!--		End  content	-->						</td>
					</tr>
			  </table>			</td>
		  </tr>
	</table>	</td>
  </tr>
</table>
</asp:Content>
