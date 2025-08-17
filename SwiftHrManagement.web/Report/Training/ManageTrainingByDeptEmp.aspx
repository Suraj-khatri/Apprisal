<%@ Page Title="" Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="ManageTrainingByDeptEmp.aspx.cs" Inherits="SwiftHrManagement.web.Report.Training.ManageTrainingByDeptEmp" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
<asp:UpdatePanel runat = "server">
    <ContentTemplate> 
     <table width="100%" height="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td valign="top">
		<table width="60%" height="100%" border="0" cellspacing="0" cellpadding="0">
		  <tr> 
			<td valign="top">
				<table width="100%" height="30" border="0" cellspacing="0" cellpadding="0">
					<tr>
						<td valign="bottom" class="wellcome">
						<img src="/images/spacer.gif" width="5" height="1">
						<img src="/images/big_bullit.gif">&nbsp;&nbsp;Employee Training by Department Wise</td>
					</tr>
					<tr>
						<td valign="top" bgcolor="#999999" height="1"><img src="/images/spacer.gif" width="100%" height="1"></td>
					</tr>
				</table>
				<table width="99%" border="0" cellspacing="0" cellpadding="0">
					<tr>
						<td valign="top" align="center"><br>

						<!--		Begin content	-->

						
<!--################ START FORM STYLE-->
 <table class="container" border="0" cellpadding="0" cellspacing="0" width="40%">
  <tbody><tr>
    <td width="1%" class="container_tl"><div></div></td>
    <td width="91%" class="container_tmid"><div>&nbsp;Training Report Department Wise </div></td>
    <td width="8%" class="container_tr"><div></div></td>
  </tr>
      <tr>
        <td class="container_l"></td>
        <td class="container_content">
        
<!--################ END FORM STYLE-->      

    <table border="0" cellpadding="5" cellspacing="5" class="container">
                                            <tr>
                                                <td>
                                                    <asp:RadioButtonList ID="RdbEmpDept" runat="server" AutoPostBack="True"                                                         
                                                        RepeatDirection="Horizontal" Width="218px" 
                                                        onselectedindexchanged="RdbEmpDept_SelectedIndexChanged">
                                                        <asp:ListItem>Department Wise</asp:ListItem>
                                                        <asp:ListItem>Employee Wise</asp:ListItem>
                                                    </asp:RadioButtonList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:DropDownList ID="DdlEmpDept" runat="server" CssClass="CMBDesign" 
                                                        AutoPostBack="True" onselectedindexchanged="DdlEmpDept_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:HiddenField ID="HddnDept" runat="server" />
                                                    <asp:HiddenField ID="HddnEmp" runat="server" />
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
