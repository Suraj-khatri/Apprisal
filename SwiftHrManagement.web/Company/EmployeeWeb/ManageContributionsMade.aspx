<%@ Page Title="" Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="ManageContributionsMade.aspx.cs" Inherits="SwiftHrManagement.web.Company.EmployeeWeb.ManageContributionsMade" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
<table width="100%" height="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td valign="top">
		<table width="60%" height="100%" border="0" cellspacing="0" cellpadding="0">
		  <tr> 
			<td valign="top">
				<table width="100%" height="30" border="0" cellspacing="0" cellpadding="0">
					<tr>
						<td valign="bottom" class="wellcome">
						<img src="/images/spacer.gif" width="5" height="1"><img src="/images/big_bullit.gif">&nbsp;&nbsp;Contribution Selection</td>
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
     <asp:UpdatePanel ID="UpdatePanel1" runat="server">
     <ContentTemplate>
 <table class="container" border="0" cellpadding="0" cellspacing="0" width="40%">
  <tbody><tr>
    <td width="1%" class="container_tl"><div></div></td>
    <td width="91%" class="container_tmid"><div>Contribution Made</div></td>
    <td width="8%" class="container_tr"><div></div></td>
  </tr>
      <tr>
        <td class="container_l"></td>
        <td class="container_content">
        
<!--################ END FORM STYLE-->
 <table border="0" cellspacing="5" cellpadding="5" class="container"> 
        <tr>         
            <td>
                <span class="errormsg">*Required Fields</span><br />
                <asp:Label ID="lblTransactionMessage" runat="server" ></asp:Label>            
                <asp:HiddenField ID="hdnContributionId" runat="server" />
            </td>          
        </tr>     
        <tr>            
            <td>
                Contributor:<br />
                <asp:DropDownList ID="cmbContributor" runat="server" Height="22px" 
                    Width="202px" AutoPostBack="True" CssClass="CMBDesign" 
                    onselectedindexchanged="cmbContributor_SelectedIndexChanged">
                    <asp:ListItem>Employee</asp:ListItem>
                    <asp:ListItem>Employer</asp:ListItem>
                </asp:DropDownList>  
            </td>          
        </tr>
        <tr>        
            <td>
                Contribution Amount<span class="errormsg">*</span><asp:RequiredFieldValidator ID="RequiredFieldValidator1" 
                    runat="server" ControlToValidate="TxtContributionAmount" Display="None" 
                    ErrorMessage="RequiredFieldValidator" ValidationGroup="contbmade"></asp:RequiredFieldValidator>
                <br />
                <asp:TextBox ID="TxtContributionAmount" runat="server" 
                    CssClass="inputTextBoxLP"></asp:TextBox>         
                <cc1:FilteredTextBoxExtender ID="TxtContributionAmount_FilteredTextBoxExtender" 
                    runat="server" Enabled="True" FilterType="Numbers" 
                    TargetControlID="TxtContributionAmount">
                </cc1:FilteredTextBoxExtender>
            </td>        
        </tr>
        <tr>
            <td>
                Contribution Date<span class="errormsg">*</span><asp:RequiredFieldValidator 
                    ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="TxtContributionDate" Display="None" 
                    ErrorMessage="RequiredFieldValidator" ValidationGroup="contbmade"></asp:RequiredFieldValidator>
                <br />
                <asp:TextBox ID="TxtContributionDate" runat="server" CssClass="inputTextBoxLP"></asp:TextBox>
                <cc1:CalendarExtender ID="TxtContributionDate_CalendarExtender" runat="server" 
                    Enabled="True" TargetControlID="TxtContributionDate">
                </cc1:CalendarExtender>         
            </td>      
        </tr>
        <tr>         
            <td>
                Receipt Number<span class="errormsg">*<br />
                </span>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                    ControlToValidate="TxtReceiptNumber" Display="None" 
                    ErrorMessage="RequiredFieldValidator" ValidationGroup="contbmade"></asp:RequiredFieldValidator>
                <br />
                <asp:TextBox ID="TxtReceiptNumber" runat="server" CssClass="inputTextBoxLP"></asp:TextBox>           
            </td>       
        </tr>  
        <caption>
            &nbsp;<tr>
                <td>
                    <asp:Button ID="BtnSave" runat="server" CssClass="button" 
                        onclick="BtnSave_Click" Text="Save" ValidationGroup="contbmade" />
                </td>
            </tr>
        </caption>
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
    </ContentTemplate>
    </asp:UpdatePanel>
<!--################ END FORM STYLE-->


	<!--		End  content	-->						</td>
					</tr>
			  </table>			</td>
		  </tr>
	</table>	</td>
  </tr>
</table>
</asp:Content>