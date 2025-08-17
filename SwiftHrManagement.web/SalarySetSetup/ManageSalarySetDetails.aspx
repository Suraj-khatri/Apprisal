<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/SwiftHRManager.Master" CodeBehind="ManageSalarySetDetails.aspx.cs" Inherits="SwiftHrManagement.web.SalarySetSetup.ManageSalarySetDetails" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
       
    <script src="../Jsfunc.js" type="text/javascript"></script>
    <link href="../Css/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        function DeleteNotification(RowID) {
            if (confirm("Are you sure to delete this message?")) {
                document.getElementById("<% =hdnDeleteId.ClientID %>").value = RowID;
                document.getElementById("<% =BtnDelete.ClientID %>").click();
            }
        }
    
        
  </script>
 
        
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
						<img src="/images/big_bullit.gif">&nbsp;Salary Set Details</td>
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
    <td width="91%" class="container_tmid" colspan="2"><div>Add Salary Set Details</div></td>
    <td width="8%" class="container_tr"><div></div></td>
  </tr>
      <tr>
        <td class="container_l"></td>
        <td class="container_content">
<!--################ END FORM STYLE-->


<table border="0" cellspacing="5" cellpadding="5" class="container">
        <tr>
            
            <td colspan="4" >
                <span class="txtlbl">Please enter valid data!</span>&nbsp;               
                <span class="errormsg">(* Required Fields)</span><br /><br />
               <div id="DivMsg" runat="server"></div>
               <asp:HiddenField ID="hdnDeleteId" runat="server" />
            </td>
           
        </tr> 
        <tr>
            
            <td >
                <div align="right"> Position :</div>
            </td>
           
            <td colspan="3" >
                <asp:Label ID="lblPosition" runat="server"></asp:Label>
            </td>
           
        </tr> 
        <tr>
            
            <td >
                <div align="right"> Set Title :</div>
            </td>
           
            <td colspan="3" >
                <asp:Label ID="lblSetTitle" runat="server"></asp:Label>
            </td>
           
        </tr> 
        <tr>
            
            <td nowrap="nowrap">
                <div align="right"> Start Basic Salary:</div>
            </td>
           
            <td colspan="3" >
            <asp:Label ID="lblStartBasic" runat="server"></asp:Label> 
            </td>
           
        </tr> 
        <tr>
            
            <td >
                <div align="right"> Grade From :</div>
            </td>
           
            <td nowrap="nowrap">
                <asp:TextBox ID="txtGradeFrom" runat="server" CssClass="inputTextBoxSmall"></asp:TextBox>
                <span class="errormsg">*</span>
                <asp:RequiredFieldValidator 
                    ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="txtGradeFrom" ErrorMessage="Required" SetFocusOnError="True" 
                    Display="dynamic" ValidationGroup="salarysetDetails">
                </asp:RequiredFieldValidator>
            </td>
           
            <td nowrap="nowrap">
                <div align="right"> Grade To:</div>
            </td>
           
            <td nowrap="nowrap">
                <asp:TextBox ID="txtGradeTo" runat="server" CssClass="inputTextBoxSmall"></asp:TextBox>
                <span class="errormsg">*</span>
                <asp:RequiredFieldValidator 
                    ID="RequiredFieldValidator3" runat="server" 
                    ControlToValidate="txtGradeTo" ErrorMessage="Required" SetFocusOnError="True" 
                    Display="dynamic" ValidationGroup="salarysetDetails">
                </asp:RequiredFieldValidator>
            </td>
           
        </tr> 
          <tr>
            <td nowrap="nowrap"><div align="right"> Grade Amount :</div></td>
            <td nowrap colspan="3">
                <asp:TextBox ID="txtGradeAmount" runat="server" CssClass="inputTextBoxLP" Width="215px"></asp:TextBox>
                  <span class="errormsg">*</span>
            <asp:RequiredFieldValidator 
                    ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="txtGradeAmount" ErrorMessage="Required" SetFocusOnError="True" 
                    Display="dynamic" ValidationGroup="salarysetDetails"> </asp:RequiredFieldValidator>
            </td>
            
        </tr> 
 
        <tr>
        <td></td>
            
            <td colspan="3"><asp:Button ID="btnSave" runat="server" Text="Save" CssClass="button" 
                        ValidationGroup="salarysetDetails" Width="75px" 
                    onclick="btnSave_Click"/>
                     
                     <cc1:confirmbuttonextender ID="Button1_ConfirmButtonExtender" runat="server" 
                            ConfirmText="Confirm To Save?" Enabled="True" TargetControlID="btnSave">
                        </cc1:confirmbuttonextender>
                <asp:Button ID="btnBack" runat="server" CssClass="button" 
                    Text="&lt;&lt; Back" Width="75px" onclick="btnBack_Click"/>
            </td>
        </tr>
        <tr>
            <td colspan="4">
              <div id="rpt" runat="server"></div>
        
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