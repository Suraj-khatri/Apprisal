<%@ Page Title="" Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="SwiftHrManagement.web.AddUpload.Manage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">

<table width="100%" border="0" cellspacing="0" cellpadding="0">
					<tr>
						<td valign="top" align="center">
                        <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                <tr>
                                    <td class="wellcome" valign="bottom">
                                        <img height="1" src="../../Images/spacer.gif" width="5" /><img src="../../Images/big_bullit.gif" />
                                        &nbsp;Tax Upload CSV File
                                    </td>
                                </tr>
                                <tr>
                                    <td bgcolor="#999999" height="1" valign="top">
                                        <img height="1" src="../../Images/spacer.gif" width="100%" /></td>
                                </tr>
                        </table><br />
						<!--		Begin content	-->

						
<!--################ START FORM STYLE-->
 <table class="container" border="0" cellpadding="0" cellspacing="0" width="40%">
  <tbody><tr>
    <td width="1%" class="container_tl"><div></div></td>
    <td width="91%" class="container_tmid"><div>Upload TAX</div></td>
    <td width="8%" class="container_tr"><div></div></td>
  </tr>
      <tr>
        <td class="container_l"></td>
        <td class="container_content">
        
<!--################ END FORM STYLE-->

 <table border="0" cellspacing="5" cellpadding="5" class="container" width="40%">  

        <tr>
            <td valign="top" nowrap="nowrap">
                &nbsp;</td>
            <td><br />
                <asp:Button ID="BtnUpload" runat="server" Text="Upload" 
                    CssClass="button" onclick="BtnUpload_Click" ValidationGroup="taxupload"/>
            </td>
        </tr>
        <tr>
            <td><div id="rpt" runat="server"></div> </td>
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
			  </table>	
			  <br />
                <asp:Label ID="lblMessage" runat="server" CssClass="errormsg"></asp:Label><br />	
</asp:Content>
