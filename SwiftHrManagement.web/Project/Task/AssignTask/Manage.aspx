<%@ Page Title="" Language="C#" MasterPageFile="~/ProjectMasterPage.Master"  AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="SwiftHrManagement.web.Project.Task.AssignTask.Manage" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">    
<script language="javascript">
        function checkAll(me) {
            var checkBoxes = document.forms[0].chkTran;
            var boolChecked = me.checked;            

            for (i = 0; i < checkBoxes.length; i++){             
                checkBoxes[i].checked = boolChecked ;               
            }
        }    
    </script>
<link href="../../../Css/style.css" rel="stylesheet" type="text/css" /> 
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
						<td valign="bottom" class="wellcome">
						<img src="/images/spacer.gif" width="5" height="1"><img src="/images/big_bullit.gif">&nbsp;&nbsp;Assign Task</td>
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
    <td width="91%" class="container_tmid" colspan="2"><div>Assign Task</div></td>
    <td width="8%" class="container_tr"><div></div></td>
  </tr>
      <tr>
        <td class="container_l"></td>
        <td class="container_content">
        
<!--################ END FORM STYLE-->

 <table border="0" cellspacing="5" cellpadding="5" class="container">  
    <tr>
        <td style="text-align: left" colspan="2">
                <asp:Label ID="lblmsg" runat="server"></asp:Label>
        </td>                           
    </tr> 
     <tr>
         <td colspan="2">Task Category : <asp:Label ID="LblCategory" runat="server" CssClass="wellcome"></asp:Label></td>
     </tr>    
     <tr>
         <td colspan="2">Task Title : <asp:Label ID="LblTaskName" runat="server" CssClass="wellcome"></asp:Label></td>
     </tr>
    
     <tr>
         <td>Start Date : <asp:Label ID="LblStartdate" runat="server" CssClass="wellcome"></asp:Label></td>
         <td nowrap="nowrap">End Date : <asp:Label ID="LblEndDate" runat="server" CssClass="wellcome"></asp:Label></td>
     </tr>
      <tr>
         <td colspan="2">Report To : <asp:Label ID="LblReportTo" runat="server" CssClass="wellcome"></asp:Label></td>
     </tr>
     <tr><td colspan="2"> Find Employee to Assign This Task </td></tr>
     <tr>
        <td>Branch Name <span class="errormsg">*</span>
        <br />
        <asp:DropDownList ID="ddlBranchName" runat="server" CssClass="CMBDesign" 
                AutoPostBack="True" onselectedindexchanged="ddlBranchName_SelectedIndexChanged"></asp:DropDownList>
        </td>
        <td>&nbsp;</td>
     </tr>
     <tr>
        <td>Department Name <span class="errormsg">*</span>
        <br />
        <asp:DropDownList ID="DdlDeptName" runat="server" CssClass="CMBDesign" 
                AutoPostBack="True" onselectedindexchanged="DdlDeptName_SelectedIndexChanged"></asp:DropDownList>
        </td>
        <td>&nbsp;</td>
     </tr>
     <tr>
        <td><span class="txtlbl">Assign To</span>
                    <span class="errormsg">*</span>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                ControlToValidate="ddlassignedto" Display="None" 
                ErrorMessage="RequiredFieldValidator" SetFocusOnError="True" 
                ValidationGroup="taskassign"></asp:RequiredFieldValidator>
                    <br />
            <asp:DropDownList ID="ddlassignedto" runat="server" AutoPostBack="True" 
                CssClass="CMBDesign" 
                onselectedindexchanged="ddlassignedto_SelectedIndexChanged">
            </asp:DropDownList>
        </td>
        <td><br />
        <asp:Button ID="Btn_AssignTask" runat="server" class="button" 
                onclick="Btn_AssignTask_Click" Text="Add" ValidationGroup="taskassign" />
        </td>
    </tr>
    <tr>
        <td>        
            <div style="border: thin solid #C0C0C0; text-align:left; width: 185px;">
                <asp:Table ID="tblResult" runat="server" Width="100%"></asp:Table>
            </div>
        </td>
    </tr>  
    <tr>
        <td align="right">
            
            <asp:Button ID= "btnDelete" Text="Delete" runat="server" 
                onclick="btnDelete_Click" CssClass="button" />
            &nbsp;&nbsp;
            <asp:Button ID="BtnCancel" runat="server" CssClass="button" 
                onclick="BtnCancel_Click" Text="&lt;&lt; Back" />
            <cc1:ConfirmButtonExtender ID="btnDelete_ConfirmButtonExtender" runat="server" 
                ConfirmText="Confirm to delete?" Enabled="True" TargetControlID="btnDelete">
            </cc1:ConfirmButtonExtender>
            
            &nbsp;</td>          
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
			  </table>			</td>
		  </tr>
	</table>	</td>
  </tr>
</table>

</ContentTemplate>
</asp:UpdatePanel>
</asp:Content>
 
