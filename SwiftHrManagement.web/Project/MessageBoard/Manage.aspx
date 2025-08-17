<%--<%@ Page Title="" Language="C#"  AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="SwiftHrManagement.web.Project.MessageBoard.Manage" %>--%>
<%@ Page Title="Swift HRM" Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="SwiftHrManagement.web.Project.MessageBoard.Manage" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../Css/style.css" rel="stylesheet" type="text/css" />
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
						<img src="/images/big_bullit.gif">&nbsp;&nbsp;Reply For Post</td>
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
 <table class="container" border="0" cellpadding="0" cellspacing="0" width="40%">
  <tbody><tr>
    <td width="1%" class="container_tl"><div></div></td>
    <td width="91%" class="container_tmid"><div>Reply for the Post</div></td>
    <td width="8%" class="container_tr"><div></div></td>
  </tr>
      <tr>
        <td class="container_l"></td>
        <td class="container_content">
        
<!--################ END FORM STYLE-->
 
 
 <table border="0" cellspacing="5" cellpadding="5" class="container">  
    <tr>
        <td>
            <asp:Label ID="LblMsg" runat="server" Text=""></asp:Label>
        </td>
    </tr>

    <tr>
        <td class="txtlbl">
            Message Subject <span class="errormsg">*</span><asp:RequiredFieldValidator ID="RequiredFieldValidator1" 
                runat="server" ErrorMessage="*" ControlToValidate="DdlSubject" 
                Display="None" ValidationGroup="MessageBoard" SetFocusOnError="True"></asp:RequiredFieldValidator>
            <br />
            <asp:DropDownList ID="DdlSubject" runat="server" CssClass="CMBDesign">
            </asp:DropDownList>
                         </td>
    </tr>
    <tr>
        <td class="txtlbl">
            Message Head<br />
            <asp:TextBox ID="TxtMessageHead" runat="server" CssClass="inputTextBoxLP" 
                Height="20px" Width="259px"></asp:TextBox>
                         </td>
    </tr>
    <tr>
        <td class="txtlbl">
            Message Description <span class="errormsg">*</span><asp:RequiredFieldValidator ID="RequiredFieldValidator2" 
                runat="server" ControlToValidate="TxtDescription" Display="None" 
                ErrorMessage="*" ValidationGroup="MessageBoard"></asp:RequiredFieldValidator>
            <br />
                         <asp:TextBox ID="TxtDescription" runat="server" Height="120px" 
                TextMode="MultiLine" Width="409px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="">
            <asp:Button ID="BtnSave" runat="server" CssClass="button" 
                onclick="BtnSave_Click" Text="Save" ValidationGroup="MessageBoard" />       
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
	</table>
	</td>
	</tr>
</table>
</asp:Content>



   

 
 
	


