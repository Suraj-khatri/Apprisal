<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/SwiftHRManager.Master" CodeBehind="ManageJobGroup.aspx.cs" Inherits="SwiftHrManagement.web.OnTheJobTraining.JobSetting.ManageJobGroup" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style10
        {
            height: 35px;
        }
    </style>
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
						<img src="/images/big_bullit.gif">&nbsp;Job Group Entry</td>
					</tr>
					<tr>
						<td valign="top" bgcolor="#999999" height="1"></td>
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
    <td width="91%" class="container_tmid"><div>Job Group form</div></td>
    <td width="8%" class="container_tr"><div></div></td>
  </tr>
      <tr>
        <td class="container_l"></td>
        <td class="container_content">
        
<!--################ END FORM STYLE-->
<asp:UpdatePanel ID="updatepanel1" runat="server">
<ContentTemplate>
<table border="0" cellspacing="3" cellpadding="3" class="container"> 
    <tr>
        <%--<td></td>--%>
        <td colspan="2" ><span class="txtlbl"> Plese enter valid data! </span>
                   <span class="required"> (* Required Fields)</span><br />  
                  <asp:Label ID="lblmsg" runat="server" style="font-weight: 700"></asp:Label>
        </td>
    </tr>
    <tr>

      <td  nowrap="nowrap" ><div align="right"><span class="txtlbl" > Group Name:</span></div></td>
      <td>  <asp:TextBox ID="txtGroupName" runat="server" CssClass="inputTextBoxLP" Width="98%"></asp:TextBox></td>
    </tr>
    
    <tr>
        <td  nowrap="nowrap" ><div align="right"><span class="txtlbl" > Department:</span></div></td>
        <td nowrap>
           <asp:DropDownList ID="DdlDepartment" runat="server" CssClass="CMBDesign" >
                </asp:DropDownList>
       
           <asp:RequiredFieldValidator ID="rfc" runat="server" 
                ControlToValidate="DdlDepartment" Display="Dynamic" ErrorMessage="Required!" 
                SetFocusOnError="True" ValidationGroup="back"></asp:RequiredFieldValidator>
        </td>
    </tr>
    
        <tr>
        <td  nowrap="nowrap" ><div align="right"><span class="txtlbl" > Position:</span></div></td>
        <td nowrap>
           <asp:DropDownList ID="DdlPostition" runat="server" CssClass="CMBDesign">
                </asp:DropDownList>
         
           <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                ControlToValidate="DdlPostition" Display="Dynamic" ErrorMessage="Required!" 
                SetFocusOnError="True" ValidationGroup="back"></asp:RequiredFieldValidator>
        </td>
    </tr>

  
     

      <tr>
         <td></td>
         <td align="right"  >
            <asp:Button ID="btnSave" runat="server" CssClass="button" 
                 Text="Save" ValidationGroup="back" onclick="btnSave0_Click" />
            <asp:Button ID="BtnDelete" runat="server" CssClass="button" 
                 Text="Delete" onclick="BtnDelete_Click" />
            <cc1:ConfirmButtonExtender ID="BtnDelete_ConfirmButtonExtender" runat="server" 
                ConfirmText="Are you sure to delete?" Enabled="True" 
                TargetControlID="BtnDelete">
            </cc1:ConfirmButtonExtender>
            <asp:Button ID="BtnBack" runat="server" CssClass="button" 
                Text="&lt;&lt; Back" onclick="BtnBack_Click" />
          </td>
      </tr>
</table>
</ContentTemplate>
</asp:UpdatePanel>

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
