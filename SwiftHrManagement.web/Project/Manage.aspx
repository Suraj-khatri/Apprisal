<%@ Page Title="" Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="SwiftHrManagement.web.Project.Manage" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Css/style.css" rel="stylesheet" type="text/css" />
    <link href="../Css/style.css" rel="stylesheet" type="text/css" /> 
    <style type="text/css">
        .style4
        {
            font-weight: bold;
            color: #333333;
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
						<td valign="bottom" class="wellcome"><img src="/images/spacer.gif" width="5" height="1"><img src="/images/big_bullit.gif">&nbsp;&nbsp;Project 
                            Entry Details</td>
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
    <td width="91%" class="container_tmid"><div>Project Entry Details</div></td>
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
            <asp:Label ID="lblmsg" runat="server" Text=""></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="txtlbl" colspan="2">
            Project Title <span class="errormsg">*</span> 
            <asp:RequiredFieldValidator ID="rfvstartdate0" runat="server" 
                ControlToValidate="txtProjectTitle" ErrorMessage="*" Display="None" 
                ValidationGroup="Project" SetFocusOnError="True"></asp:RequiredFieldValidator>
            <br />
            <asp:TextBox ID="txtProjectTitle" runat="server" CssClass="inputTextBoxLP" 
                Width="410px"></asp:TextBox>
           </td>
    </tr>
    <tr>
        <td>
           <span class="txtlbl">Project Start Date</span><span class="errormsg">*</span> 
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                ControlToValidate="txtstartDate" Display="None" ErrorMessage="*" 
                ValidationGroup="Project" SetFocusOnError="True"></asp:RequiredFieldValidator>
            <br />
            <asp:TextBox ID="txtstartDate" runat="server" CssClass="inputTextBoxLP"></asp:TextBox>
            <cc1:CalendarExtender ID="txtstartDate_CalendarExtender" runat="server" 
                Enabled="True" TargetControlID="txtstartDate">
            </cc1:CalendarExtender>
           
        </td>
        <td>
            <span class="txtlbl">Project End Date</span>
                <span class="errormsg">*</span> 
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" 
                runat="server" ControlToValidate="txtEndDate" Display="None" ErrorMessage="*" 
                ValidationGroup="Project" SetFocusOnError="True"></asp:RequiredFieldValidator>
            <asp:CompareValidator ID="CVStartDate" runat="server" 
                ControlToCompare="txtstartDate" ControlToValidate="txtEndDate" 
                ErrorMessage="Invalid Date" Operator="GreaterThanEqual" SetFocusOnError="True" 
                ValidationGroup="Project"></asp:CompareValidator>
            <br />
            <asp:TextBox ID="txtEndDate" runat="server" CssClass="inputTextBoxLP"></asp:TextBox>
            <cc1:CalendarExtender ID="txtEndDate_CalendarExtender" runat="server" 
                Enabled="True" TargetControlID="txtEndDate">
            </cc1:CalendarExtender>
  
        </td>
    </tr>
    <tr>
        <td class="txtlbl">
            Category <span class="errormsg">*</span> 
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                ControlToValidate="TxtCategory" Display="None" ErrorMessage="*" 
                ValidationGroup="Project" SetFocusOnError="True"></asp:RequiredFieldValidator>
            <br />
            <asp:TextBox ID="TxtCategory" runat="server" CssClass="inputTextBoxLP">
               </asp:TextBox>
       </td>
        <td class="txtlbl">
            Priority <span class="errormsg">*</span> 
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                ControlToValidate="ddlPriority" Display="None" ErrorMessage="*" 
                ValidationGroup="Project" SetFocusOnError="True"></asp:RequiredFieldValidator>
            <br />
            <asp:DropDownList ID="ddlPriority" runat="server" CssClass="CMBDesign">                
            </asp:DropDownList>
        </td>
    </tr>

   <tr>
        <td class="style4">Selection For Project Owner</td>
        <td class="style4">Selection For Project Manager</td>
    </tr>
    <tr>
        <td colspan="2">&nbsp;</td>
       
    </tr>
    <tr>
        <td class="txtlbl">
            Owner Branch Name <span class="errormsg">*</span>
            <br />
            <asp:DropDownList ID="DdlBranchForOwner" runat="server" CssClass="CMBDesign" 
                AutoPostBack="True" 
                onselectedindexchanged="DdlBranchForOwner_SelectedIndexChanged">
            </asp:DropDownList>

        </td>
        <td class="txtlbl">
            Manager Branch Name <span class="errormsg">*</span> 
            <br />
            <asp:DropDownList ID="DdlBranchForManager" runat="server" CssClass="CMBDesign" 
                AutoPostBack="True" 
                onselectedindexchanged="DdlBranchForManager_SelectedIndexChanged">
            </asp:DropDownList>
        </td>
    </tr>
      <tr>
        <td class="txtlbl">
            Owner Department Name <span class="errormsg">*</span>
            <br />
            <asp:DropDownList ID="DdlDeptForOwner" runat="server" CssClass="CMBDesign" 
                AutoPostBack="True" 
                onselectedindexchanged="DdlDeptForOwner_SelectedIndexChanged">
            </asp:DropDownList>

        </td>
        <td class="txtlbl">
            Manager Department Name <span class="errormsg">*</span> 
            <br />
            <asp:DropDownList ID="DdlDeptForManager" runat="server" CssClass="CMBDesign" 
                AutoPostBack="True" 
                onselectedindexchanged="DdlDeptForManager_SelectedIndexChanged">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td class="txtlbl">
            Project Owner <span class="errormsg">*</span> 
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" 
                runat="server" ControlToValidate="ddlprojectOwner" Display="None" 
                ErrorMessage="*" ValidationGroup="Project" SetFocusOnError="True"></asp:RequiredFieldValidator>
            <br />
            <asp:DropDownList ID="ddlprojectOwner" runat="server" CssClass="CMBDesign">
            </asp:DropDownList>

        </td>
        <td class="txtlbl">
            Project Manager <span class="errormsg">*</span> 
            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" 
                runat="server" ControlToValidate="ddlProjectManager" Display="None" 
                ErrorMessage="*" ValidationGroup="Project" SetFocusOnError="True"></asp:RequiredFieldValidator>
            <br />
            <asp:DropDownList ID="ddlProjectManager" runat="server" CssClass="CMBDesign">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td class="txtlbl" colspan="2">
            Is completed?<br />
            <asp:CheckBox ID="ChkIsCompleted" runat="server" />
        </td>

    </tr>
    <tr>
        <td>
            &nbsp;<asp:Button ID="BtnSave" runat="server" CssClass="button" 
                onclick="BtnSave_Click" Text="Save " ValidationGroup="Project" />
            <asp:Button ID="BtnDelete" runat="server" Text="Delete" CssClass="button" 
                onclick="BtnDelete_Click" Enabled="False" />
            <asp:Button ID="BtnBack" runat="server" Text="&lt;&lt; Back" CssClass="button" 
                onclick="BtnBack_Click" />
        </td>
        <td>&nbsp;</td>
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
</ContentTemplate></asp:UpdatePanel>
</asp:Content>
