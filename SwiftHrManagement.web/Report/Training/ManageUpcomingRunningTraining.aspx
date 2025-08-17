<%@ Page Title="" Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="ManageUpcomingRunningTraining.aspx.cs" Inherits="SwiftHrManagement.web.Report.Training.ManageUpcomingRunningTraining" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat = "server">
    <ContentTemplate> 
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
						<img src="/images/big_bullit.gif">&nbsp;&nbsp;Employee Running and Upcoming Training</td>
					</tr>
					<tr>
						<td valign="top" bgcolor="#999999" height="1"><img src="/images/spacer.gif" width="100%" height="1"></td>
					</tr>
				</table>
				<table width="60%" border="0" cellspacing="0" cellpadding="0">
					<tr>
						<td valign="top" align="center"><br>

						<!--		Begin content	-->
 <table class="container" border="0" cellpadding="0" cellspacing="0" width="30%">
  <tbody><tr>
    <td width="1%" class="container_tl"><div></div></td>
    <td width="91%" class="container_tmid"><div>&nbsp;Running and upcoming training</div></td>
    <td width="8%" class="container_tr"><div></div></td>
  </tr>
      <tr>
        <td class="container_l"></td>
        <td class="container_content">
        
<!--################ END FORM STYLE-->      
    <table class="container" border="0" cellpadding="5" cellspacing="5">
            <tr>
                <td>
                    <asp:RadioButtonList ID="RdbplannedRunning" runat="server" AutoPostBack="True"                                                         
                        RepeatDirection="Horizontal"
                        onselectedindexchanged="RdbplannedRunning_SelectedIndexChanged">
                        <asp:ListItem>Running</asp:ListItem>
                        <asp:ListItem>Planned</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:DropDownList ID="DdlProgramName" runat="server" CssClass="CMBDesign" 
                        AutoPostBack="True" onselectedindexchanged="DdlProgramName_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="BtnReport" runat="server" CssClass="button" 
                        onclick="BtnReport_Click" Text="Show Report" />
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
   
    </ContentTemplate>
</asp:UpdatePanel>
</asp:Content>
