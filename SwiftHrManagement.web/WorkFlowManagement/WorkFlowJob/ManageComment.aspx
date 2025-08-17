<%@ Page Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="ManageComment.aspx.cs" Inherits="SwiftHrManagement.web.WorkFlowManagement.WorkFlowJob.ManageComment" Title="Swift HR Management System 1.0" %>
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
						<img src="/images/big_bullit.gif">&nbsp;Vew Comment List:- <span class="subheading">
						<asp:Label ID ="lblJobDetails" runat="server"></asp:Label></span></td>
					</tr>
					<tr>
						<td valign="top" bgcolor="#999999" height="1"><img src="/images/spacer.gif" width="100%" height="1"></td>
					</tr>
				</table>
				<table width="80%" border="0" cellspacing="0" cellpadding="0">
					<tr>
						<td valign="top" align="center"><br>

						<!--		Begin content	-->

						
<!--################ START FORM STYLE-->
 <table class="container" border="0" cellpadding="0" cellspacing="0" width="40%">
  <tbody><tr>
    <td width="1%" class="container_tl"><div></div></td>
    <td width="91%" class="container_tmid"><div>Comment List</div></td>
    <td width="8%" class="container_tr"><div></div></td>
  </tr>
      <tr>
        <td class="container_l"></td>
        <td class="container_content">
        
<!--################ END FORM STYLE-->

 <table border="0" cellspacing="5" cellpadding="5" class="container">  
        <tr>
            <td><div id="CommentList" runat="server"></div></td>
        </tr>
        <tr>
        
          <td nowrap="nowrap" valign="top" style="padding:3px 15px;" ><span class="txtlbl">Comments </span><span class="required">*</span><asp:RequiredFieldValidator 
                  ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtComment" 
                  Display="Dynamic" ErrorMessage="Required!" SetFocusOnError="True" 
                  ValidationGroup="post"></asp:RequiredFieldValidator><br />
                <asp:TextBox ID="txtComment" runat="server" CssClass="inputTextBoxLP" 
                     Width="421px" Height="40px" TextMode="MultiLine"></asp:TextBox> 
                                            
         </td>
         </tr>
         <tr>
            <td style="padding:3px 15px;" ><asp:Button ID="BtnPost" runat="server" Text="Post Comment" CssClass="button" 
                    onclick="BtnPost_Click" ValidationGroup="post"></asp:Button></td>
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
