<%@ Page Title="" Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="ManageFeedback.aspx.cs" Inherits="SwiftHrManagement.web.TrainingModule.NORMAL.ManageFeedback" %>
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
				<table width="100%" border="0" cellspacing="0" cellpadding="0">
					<tr>
						<td valign="top" align="center"><br>

						<!--		Begin content	-->

						
<!--################ START FORM STYLE-->
 <table class="container" border="0" cellpadding="0" cellspacing="0" width="100%">
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
            <td><asp:Label ID="lblMsg" runat="server" CssClass="txtlbl"></asp:Label> </td>
        </tr>
        <tr>
            <td>
                <table border="0" cellpadding="2" cellspacing="2">
                        <tr>
                            <td align="left"><div align="right" class="txtlbl"><strong>Employee Name :</strong></div>
                            </td>
                            <td>
                                <asp:Label ID="lblName" runat="server" CssClass="txtlbl"></asp:Label>
                            </td>
                            <td align="left"><div align="right" class="txtlbl"><strong>Department :</strong></div>
                            </td>
                            <td>
                                <asp:Label ID="lblDept" runat="server" CssClass="txtlbl"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="left"><div align="right" class="txtlbl"><strong>Branch :</strong></div>
                            </td>
                            <td>
                                <asp:Label ID="lblBranch" runat="server" CssClass="txtlbl"></asp:Label>
                            </td>
                            <td align="left"><div align="right" class="txtlbl"><strong>Feedback Date :</strong></div>
                            </td>
                            <td>
                                <asp:Label ID="lblDate" runat="server" CssClass="txtlbl"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="left"><div align="right" class="txtlbl"><strong>Training Program Name :</strong></div></td>
                            <td><asp:Label ID="lblProgramName" runat="server" CssClass="txtlbl"></asp:Label></td>
                        </tr>
                    </table>               
            </td>
        </tr>
   
        <tr>
            <td>
                <div id="rptFeedback" runat="server"></div>
            </td>
        </tr>
        <tr>
            <td>
                <div id="rptSubjectiveFeedback" runat="server"></div>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btnSave" runat="server" CssClass="button" 
                    Text=" Save " onclick="btnSave_Click"  ValidationGroup="feedback" />

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


