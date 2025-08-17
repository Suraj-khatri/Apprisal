<%@ Page Title="" Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="ManageManualAddDed.aspx.cs" Inherits="SwiftHrManagement.web.Payrole_management.ManageManualAddDed" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style10
        {
            font-weight: bold;
            color: #333333;
            height: 35px;
        }
        .style11
        {
            height: 35px;
        }
        .style12
        {
            font-weight: bold;
            color: #333333;
            text-align: right;
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
						<img src="/images/spacer.gif" width="5" height="1"><img src="/images/big_bullit.gif">&nbsp;&nbsp;Manual 
                            Head Addition Deduction</td>
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
    <td width="91%" class="container_tmid"><div>Add New Data Detail</div></td>
    <td width="8%" class="container_tr"><div></div></td>
  </tr>
      <tr>
        <td class="container_l"></td>
        <td class="container_content">
        
<!--################ END FORM STYLE-->

 <table border="0" cellspacing="5" cellpadding="5" class="container">  

        <tr>
            <td colspan="2">
                <span class="txtlbl" >Please enter valid data</span><br />
                <span class="required" >(* Required fields)</span><br />
                <asp:Label ID="LblMsg" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td nowrap="nowrap">Data Type Title :</td>
            <td ><asp:TextBox ID="TxtName" runat="server" CssClass="inputTextBoxLP"></asp:TextBox> <span class="errormsg">*</span><br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="TxtName" Display="None" 
                    ErrorMessage="RequiredFieldValidator" SetFocusOnError="True" 
                    ValidationGroup="add"></asp:RequiredFieldValidator>
                                                                                                                            </td>
        </tr>
        <tr>
            <td >Is Enabled :</td>
            <td><asp:CheckBox ID="ChkEnabled" runat="server" /></td>
        </tr>    
        <tr>
            <td colspan="2">
                <asp:Button ID="BtnSave" runat="server" CssClass="button" 
                    onclick="BtnSave_Click" Text="Save" ValidationGroup="add" />
                <asp:Button ID="BtnDelete" runat="server" CssClass="button" Text="Delete" 
                    onclick="BtnDelete_Click" />
                <asp:Button ID="BtnBack" runat="server" CssClass="button" Text="&lt;&lt; Back" 
                    onclick="BtnBack_Click" />
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
