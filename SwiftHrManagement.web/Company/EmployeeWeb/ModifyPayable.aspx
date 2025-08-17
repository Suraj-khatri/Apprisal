<%@ Page Title="" Language="C#" MasterPageFile="~/ProjectMaster.Master" AutoEventWireup="true" CodeBehind="ModifyPayable.aspx.cs" Inherits="SwiftHrManagement.web.Company.EmployeeWeb.ModifyPayable" %>
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
			<!-- BREAD CRUMBS START !-->
				<table width="100%" border="0" cellspacing="0" cellpadding="0">
					<tr>
						<td valign="bottom" class="wellcome">
						<img src="/images/spacer.gif" width="5" height="1">
						
						<img src="/images/big_bullit.gif"> 
						<a href="ListPayable.aspx?Id=<%=GetEmpId().ToString()%>">List Payable  </a> &raquo; Manage Payable 
						 
                            <asp:Label ID="LblEmpName" runat="server"></asp:Label>
                        </td>
					</tr>
					<tr>
						<td valign="top" bgcolor="#999999" height="1"><img src="/images/spacer.gif" width="100%" height="1"></td>
					</tr>
				</table>
				<!-- BREAD CRUMBS END !-->
				<%--<table width="100%" height="30" border="0" cellspacing="0" cellpadding="0">
					<tr>
						<td valign="bottom" class="wellcome">
						<img src="/images/spacer.gif" width="5" height="1"><img src="/images/big_bullit.gif">&nbsp;&nbsp;Employee Payable Details :
                         <span class="subheading"><asp:Label ID="LblEmpName" runat="server"></asp:Label></span>   
                        </td>
					</tr>
					<tr>
						<td valign="top" bgcolor="#999999" height="1"><img src="/images/spacer.gif" width="100%" height="1"></td>
					</tr>
				</table>--%>
				<table width="80%" border="0" cellspacing="0" cellpadding="0">
					<tr>
						<td valign="top" align="center">

						<!--		Begin content	-->

<!--################ START FORM STYLE-->
 <table class="container" border="0" cellpadding="0" cellspacing="0" width="20%">
  <tbody><tr>
    <td width="1%" class="container_tl"><div></div></td>
    <td width="91%" class="container_tmid"><div>Manage Payable </div></td>
    <td width="8%" class="container_tr"><div></div></td>
  </tr>
      <tr>
        <td class="container_l"></td>
        <td class="container_content">
<!--################ END FORM STYLE-->

 <table border="0" cellspacing="2" cellpadding="2" class="container">  

    <tr>
        <td>&nbsp;</td>       
        <td>   Please enter valid data!   
            <br /><span class="required" >(* Required fields)</span><br />
             <asp:HiddenField ID="hdnEmployeeId" runat="server" />             
                <asp:Label ID="lblTransactionMessage" runat="server" Text=""></asp:Label>
        </td>
    </tr>
     <tr>
        <td>&nbsp;</td>       
        <td>&nbsp;</td>
    </tr>
        <tr>
            <td class="style4">
                &nbsp;</td>
            <td class="style3">
                Benefit Name <span class="errormsg">*</span><asp:RequiredFieldValidator ID="RequiredFieldValidator1" 
                    runat="server" ControlToValidate="ddlBenefitName" Display="None" 
                    ErrorMessage="RequiredFieldValidator" ValidationGroup="Payable" 
                    SetFocusOnError="True"></asp:RequiredFieldValidator><br />
                <asp:DropDownList ID="ddlBenefitName" runat="server" CssClass="CMBDesign">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="style4">
                &nbsp;</td>
            <td class="style3">
                Payable Amount <span class="errormsg">*</span><asp:RequiredFieldValidator ID="RequiredFieldValidator2" 
                    runat="server" ControlToValidate="TxtAmount" Display="None" 
                    ErrorMessage="RequiredFieldValidator" ValidationGroup="Payable" 
                    SetFocusOnError="True"></asp:RequiredFieldValidator><asp:CompareValidator ID="CompareValidator1" runat="server" 
                    ControlToValidate="TxtAmount" Display="Dynamic" ErrorMessage="Invalid Amount!" 
                    SetFocusOnError="True" Type="Double" ValidationGroup="Payable"></asp:CompareValidator><br />
                <asp:TextBox ID="TxtAmount" runat="server" CssClass="inputTextBoxLP"></asp:TextBox>
            </td>
        </tr>
             <tr>
        <td>&nbsp;</td>       
        <td>&nbsp;</td>
    </tr>
        <tr>
            <td class="style4">
                &nbsp;</td>
            <td class="style3">
                <asp:Button ID="BtnSave" runat="server" CssClass="button" Text="Save" 
                    onclick="BtnSave_Click" ValidationGroup="Payable" />
                <cc1:ConfirmButtonExtender ID="BtnSave_ConfirmButtonExtender" runat="server" 
                    ConfirmText="Confirm To Save?" Enabled="True" TargetControlID="BtnSave">
                </cc1:ConfirmButtonExtender>
       <%--         &nbsp;<asp:Button ID="BtnDelete" runat="server" CssClass="button" 
                    onclick="BtnDelete_Click" Text="Delete" />
                <cc1:ConfirmButtonExtender ID="BtnDelete_ConfirmButtonExtender" runat="server" 
                    ConfirmText="Confirm To Delete?" Enabled="True" TargetControlID="BtnDelete">--%>
                </cc1:ConfirmButtonExtender>
&nbsp;<asp:Button ID="BtnCancel" runat="server" CssClass="button" Text="&lt;&lt;Back" />
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
