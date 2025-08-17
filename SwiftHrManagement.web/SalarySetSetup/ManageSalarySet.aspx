<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/SwiftHRManager.Master" CodeBehind="ManageSalarySet.aspx.cs" Inherits="SwiftHrManagement.web.SalarySetSetup.ManageSalarySet" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
       
     
    <link href="../Css/style.css" rel="stylesheet" type="text/css" />
 
        
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">

<form name="form1" id="form1" method="post">
<table width="100%" border="0" cellspacing="0" cellpadding="0">

                           
  <tr>
    <td valign="top">
	<table width="100%" border="0" cellspacing="0" cellpadding="0">
		  <tr> 
			<td valign="top">
				<table width="100%" border="0" cellspacing="0" cellpadding="0">
					<tr>
						<td valign="bottom" class="wellcome"><img src="/images/spacer.gif" width="5" height="1">
						<img src="/images/big_bullit.gif">&nbsp;Salary Set Setup</td>
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
    <td width="91%" class="container_tmid" colspan="2"><div>Add Salary Set </div></td>
    <td width="8%" class="container_tr"><div></div></td>
  </tr>
      <tr>
        <td class="container_l"></td>
        <td class="container_content">
<!--################ END FORM STYLE-->


<table border="0" cellspacing="5" cellpadding="5" class="container">
        <tr>
            <td></td>
            <td >
                <span class="txtlbl">Please enter valid data!</span>&nbsp;               
                <span class="errormsg">(* Required Fields)</span><br /><br />
               <div id="DivMsg" runat="server"></div>
            </td>
            <td></td>
        </tr> 
        <tr>
            <td nowrap="nowrap"><div align="right"> Position :</div></td>
           
            <td nowrap>
                <asp:DropDownList ID="ddlPosition" runat="server" CssClass="CMBDesign">
                </asp:DropDownList>
            <span class="errormsg">*</span>
            <asp:RequiredFieldValidator 
                    ID="RFVposition" runat="server" 
                    ControlToValidate="ddlPosition" ErrorMessage="Required!!" SetFocusOnError="True" 
                    Display="dynamic" ValidationGroup="salaryset"> </asp:RequiredFieldValidator>
            </td>
            
        </tr> 
          <tr>
            <td nowrap="nowrap"><div align="right"> Set Title :</div></td>
            <td nowrap>
                <asp:TextBox ID="txtSetTitle" runat="server" CssClass="inputTextBoxLP" Width="215px"></asp:TextBox>
                  <span class="errormsg">*</span>
            <asp:RequiredFieldValidator 
                    ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="txtSetTitle" ErrorMessage="Required!!" SetFocusOnError="True" 
                    Display="dynamic" ValidationGroup="salaryset"></asp:RequiredFieldValidator>
            </td>
            
        </tr> 
 
          <tr>
            <td nowrap="nowrap"><div align="right"> Set Remarks :</div></td>
            <td nowrap>
                <asp:TextBox ID="txtSetRemarks" runat="server" CssClass="inputTextBoxLP" 
                    TextMode="MultiLine" Width="215px"></asp:TextBox>
                <span class="errormsg">*</span>
                <asp:RequiredFieldValidator 
                    ID="RequiredFieldValidator6" runat="server" 
                    ControlToValidate="txtSetRemarks" ErrorMessage="Required!!" SetFocusOnError="True" 
                    Display="dynamic" ValidationGroup="salaryset">
                </asp:RequiredFieldValidator>
            </td>
            
        </tr> 
 
          <tr>
            <td nowrap="nowrap"><div align="right"> No. of Grades :</div></td>
            <td nowrap>
                 <asp:TextBox ID="txtGradeNo" runat="server" CssClass="inputTextBoxSmall"></asp:TextBox>
                 <span class="errormsg">*</span>
                <asp:RequiredFieldValidator 
                    ID="RequiredFieldValidator3" runat="server" 
                    ControlToValidate="txtGradeNo" ErrorMessage="Required!!" SetFocusOnError="True" 
                    Display="dynamic" ValidationGroup="salaryset">
                </asp:RequiredFieldValidator>
                  </td>
            
        </tr> 
 
          <tr>
            <td nowrap="nowrap"><div align="right"> Start Basic Salary :</div></td>
            <td nowrap>
                <asp:TextBox ID="txtStartBasicSalary" runat="server" CssClass="inputTextBoxLP" Width="215px"></asp:TextBox>
                  <span class="errormsg">*</span>
                  <asp:RequiredFieldValidator 
                    ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="txtStartbasicSalary" ErrorMessage="Required!!" SetFocusOnError="True" 
                    Display="dynamic" ValidationGroup="salaryset"> 
                  </asp:RequiredFieldValidator>    
            </td>
            
        </tr>
 
          <tr>
            <td nowrap="nowrap"><div align="right"> Is Active? :</div></td>
            <td nowrap>
                <asp:DropDownList ID="ddlIsActive" runat="server" CssClass="CMBDesign" Width="100">
                    <asp:ListItem Value="yes">YES</asp:ListItem>
                    <asp:ListItem Value="no">NO</asp:ListItem>
                </asp:DropDownList>
            </td>
            
        </tr>
        <tr>
        <td></td>
            
            <td>
                <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="button" 
                        ValidationGroup="salaryset" Width="75px" onclick="btnSave_Click"/>
                     
                     <cc1:confirmbuttonextender ID="Button1_ConfirmButtonExtender" runat="server" 
                            ConfirmText="Confirm To Save?" Enabled="True" TargetControlID="btnSave">
                        </cc1:confirmbuttonextender>
                <asp:Button ID="btnBack" runat="server" CssClass="button" 
                    Text="&lt;&lt; Back" Width="75px" onclick="btnBack_Click"/>
            </td>
        </tr>
</table>



<!--################ START FORM STYLE-->
	</td>
        <td class="container_content">
            &nbsp;</td>
    <td class="container_r"></td>
  </tr>
  <tr>
    <td class="container_bl"></td>
    <td class="container_bmid" colspan="2"></td>
    <td class="container_br"></td>
  </tr>
  
	</tbody>
  </table>

<!--################ END FORM STYLE-->


	<!--		End  content	-->						</td>
					</tr>
			  </table>
			</td>
		  </tr>
	</table>
	</td>
  </tr>
</table>
</form>

</asp:Content>
