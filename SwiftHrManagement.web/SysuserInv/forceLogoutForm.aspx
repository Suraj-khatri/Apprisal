<%@ Page Title="" Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="forceLogoutForm.aspx.cs" Inherits="SwiftHrManagement.web.SysuserInv.forceLogoutForm" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
 <link href="../Css/style.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
<table width="100%" height="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td valign="top">
		<table width="100%" height="100%" border="0" cellspacing="0" cellpadding="0">
		  <tr> 
			<td valign="top">
				
				<table width="80%" border="0" cellspacing="0" cellpadding="0">
					<tr>
						<td valign="top" align="center"><br>

						<!--		Begin content	-->

						
<!--################ START FORM STYLE-->
 <table class="container" border="0" cellpadding="0" cellspacing="0" width="20%">
  <tbody>
    <tr>
        <td width="1%" class="container_tl"><div></div></td>
        <td width="91%" class="container_tmid"><div>Force Logout Form</div></td>
        <td width="8%" class="container_tr"><div></div></td>
    </tr>
    <tr>
        <td class="container_l"></td>
        <td class="container_content">
        
<!--################ END FORM STYLE-->
     <table border="0" cellspacing="2" cellpadding="2" class="container">  
      <tr>
        <td colspan="2" class="txtlbl">
            <span class="errormsg"><asp:Label ID="LblMsg" runat="server"></asp:Label></span>
        </td>
      </tr>
      <tr>
        <td nowrap="nowrap" colspan="2"><div align="left" class="txtlbl">User Name: <asp:Label ID="userName" CssClass="txtlbl" runat="server"></asp:Label> </div></td>
      </tr>
        <tr>
            <td nowrap="nowrap" colspan="2"><div align="left" class="txtlbl">Are You Sure To Force Logout?</div>
            </td>
        </tr>     
        <tr>
        <td>&nbsp;</td>
            <td style="text-align: left">
                <asp:Button ID="Btn_Save" runat="server" CssClass="button" Text="Yes" 
                    onclick="Btn_Save_Click"  Width="75px" />
                <asp:Button ID="btnBack" runat="server" CssClass="button" Text="&lt;&lt; Back" 
                     Width="75px" onclick="btnBack_Click" />
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
