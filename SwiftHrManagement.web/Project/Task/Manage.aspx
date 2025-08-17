<%@ Page Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="SwiftHrManagement.web.Project.Task.Manage"  %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
  

    <link href="../../Css/style.css" rel="stylesheet" type="text/css" />
  

    <style type="text/css">
        .style5
        {
            text-decoration: underline;
        }
    </style>
  

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
<asp:UpdatePanel ID="updatepanel1" runat="server">
<ContentTemplate>
<table width="100%" height="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td valign="top">
		<table width="100%" height="100%" border="0" cellspacing="0" cellpadding="0">
		  <tr> 
			<td valign="top">
				<table width="100%" border="0" cellspacing="0" cellpadding="0">
					<tr>
						<td valign="bottom" class="wellcome"><img src="/images/spacer.gif" width="5" height="1"><img src="/images/big_bullit.gif">&nbsp;&nbsp;Task 
                            Entry Details </td>
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
    <td width="91%" class="container_tmid"><div>Task Entry Details </div></td>
    <td width="8%" class="container_tr"><div></div></td>
  </tr>
      <tr>
        <td class="container_l"></td>
        <td class="container_content">
        
<!--################ END FORM STYLE-->

<table border="0" cellspacing="2" cellpadding="2" class="container">      
    <tr> 
        <td colspan="2">
            <span class="txtlbl" >Please enter valid data</span><br />
            <span class="required" >(* Required fields)</span><br />
            <asp:Label ID="lblmsg" runat="server"></asp:Label>
        </td>
    </tr>
    <tr> 
        <td colspan="2">
        <asp:HiddenField ID ="hdnprjid" runat="server" />
            &nbsp;</td>
    </tr>
    <tr>
            <td class="txtlbl" valign="top">
                Project Title :   <span class="errormsg">*</span><asp:RequiredFieldValidator ID="RequiredFieldValidator1" 
                    runat="server" Display="None" ErrorMessage="*" ValidationGroup="Task" 
                    ControlToValidate="ddlprojTittle" SetFocusOnError="True"></asp:RequiredFieldValidator>
                <br />
                <asp:DropDownList ID="ddlprojTittle" runat="server" CssClass="CMBDesign">
                </asp:DropDownList>
            </td>
            <td class="txtlbl">
                Task Category :   <span class="errormsg">*</span><asp:RequiredFieldValidator ID="RequiredFieldValidator5" 
                    runat="server" ControlToValidate="TxtCategory" Display="None" ErrorMessage="*" 
                    ValidationGroup="Task" SetFocusOnError="True"></asp:RequiredFieldValidator>
                
                <br />
                <asp:TextBox ID="TxtCategory" runat="server" CssClass="inputTextBoxLP"></asp:TextBox>
        </td>           
        </tr>
        <tr>
             <td class="txtlbl" colspan="2">
                 Task Title :   <span class="errormsg">*</span><asp:RequiredFieldValidator ID="RequiredFieldValidator2" 
                    runat="server" ControlToValidate="Txttitle" Display="None" ErrorMessage="*" 
                    ValidationGroup="Task" SetFocusOnError="True"></asp:RequiredFieldValidator>
                <br />
                <asp:TextBox ID="Txttitle" runat="server" CssClass="inputTextBoxLP" 
                    Height="35px" TextMode="MultiLine" Width="410px"></asp:TextBox>
              </td>
        </tr>
        <tr>
            <td>
               <span class="txtlbl"> Start Date :  </span> <span class="errormsg">*</span><asp:RequiredFieldValidator ID="RequiredFieldValidator3" 
                    runat="server" ControlToValidate="TxtstartDate" Display="None" ErrorMessage="*" 
                    ValidationGroup="Task" SetFocusOnError="True"></asp:RequiredFieldValidator>
                <br />
                <asp:TextBox ID="TxtstartDate" runat="server" CssClass="inputTextBoxLP"></asp:TextBox>
                <cc1:CalendarExtender ID="TxtstartDate_CalendarExtender" runat="server" 
                    Enabled="True" TargetControlID="TxtstartDate">
                </cc1:CalendarExtender>
             </td>
            <td>
                 <span class="txtlbl">End Date :</span><span class="errormsg">*</span><asp:RequiredFieldValidator ID="RequiredFieldValidator4" 
                    runat="server" ControlToValidate="TxtEndDate" Display="None" ErrorMessage="*" 
                    ValidationGroup="Task" SetFocusOnError="True"></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="CompareValidator1" runat="server" 
                    ControlToCompare="TxtstartDate" ControlToValidate="TxtEndDate" 
                    ErrorMessage="Invalid End and Start date!" 
                    Operator="GreaterThanEqual" SetFocusOnError="True" ValidationGroup="Task"></asp:CompareValidator>
                <br />
                <asp:TextBox ID="TxtEndDate" runat="server" CssClass="inputTextBoxLP"></asp:TextBox>
                <cc1:CalendarExtender ID="TxtEndDate_CalendarExtender" runat="server" 
                    Enabled="True" TargetControlID="TxtEndDate">
                </cc1:CalendarExtender>
               </td>
        </tr>
        <tr>
            
            <td class="txtlbl">
                Priroty :   <span class="errormsg">*</span><asp:RequiredFieldValidator ID="RequiredFieldValidator6" 
                    runat="server" ControlToValidate="ddlPriority" Display="None" ErrorMessage="*" 
                    ValidationGroup="Task" SetFocusOnError="True"></asp:RequiredFieldValidator>
                <br />
                <asp:DropDownList ID="ddlPriority" runat="server" CssClass="CMBDesign">              
                    <asp:ListItem>Select Priority</asp:ListItem>
                    <asp:ListItem>Low</asp:ListItem>
                    <asp:ListItem>Normal</asp:ListItem>
                    <asp:ListItem>High</asp:ListItem>            
                </asp:DropDownList>
              </td>
        </tr>
        <tr>
            <td colspan="2"></td>
        </tr>        
        <tr>
            <td colspan="2" class="style5"> Selection For Reported To</td>
        </tr>
        <tr>
            <td>Branch Name : <span class="errormsg">*</span><br />
            <asp:DropDownList ID="DdlBranchName" runat="server" CssClass="CMBDesign" 
                    onselectedindexchanged="DdlBranchName_SelectedIndexChanged" 
                    AutoPostBack="True"></asp:DropDownList>
             </td>
             <td>Department Name : <span class="errormsg">*</span><br />
            <asp:DropDownList ID="DdlDeptName" runat="server" CssClass="CMBDesign" 
                     onselectedindexchanged="DdlDeptName_SelectedIndexChanged" 
                     AutoPostBack="True"></asp:DropDownList>
             </td>
        </tr>
        <tr>
            <td class="txtlbl">
                Report To :  <span class="errormsg">*</span><asp:RequiredFieldValidator ID="RequiredFieldValidator7" 
                    runat="server" ControlToValidate="ddlreportto" Display="None" ErrorMessage="*" 
                    ValidationGroup="Task" SetFocusOnError="True"></asp:RequiredFieldValidator>
                <br />
                <asp:DropDownList ID="ddlreportto" runat="server" CssClass="CMBDesign">
                </asp:DropDownList>
            </td>
            <td class="txtlbl">
                <br />
        </td>
        </tr>
        <tr>
            <td>
                
                <asp:Button ID="BtnSave" runat="server" CssClass="button" Text="Save" 
                    onclick="BtnSave_Click1" ValidationGroup="Task" />
                
                <cc1:ConfirmButtonExtender ID="BtnSave_ConfirmButtonExtender" runat="server" 
                    ConfirmText="Confirm to save??" Enabled="True" TargetControlID="BtnSave">
                </cc1:ConfirmButtonExtender>
                &nbsp;<asp:Button ID="BtnDelete" runat="server" CssClass="button" onclick="BtnDelete_Click" 
                    Text="Delete" Enabled="False" />
                <cc1:ConfirmButtonExtender ID="BtnDelete_ConfirmButtonExtender" runat="server" 
                    ConfirmText="Confirm to Delete ??" Enabled="True" TargetControlID="BtnDelete">
                </cc1:ConfirmButtonExtender>
                <asp:Button ID="BtnCancel" runat="server" CssClass="button" 
                    onclick="BtnCancel_Click" Text="&lt;&lt; Back" />
                &nbsp;</td>
            <td>
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
</ContentTemplate>
</asp:UpdatePanel>
</asp:Content>
