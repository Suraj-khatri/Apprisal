<%@ Page Title="" Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="SwiftHrManagement.web.Project.TaskList.Manage" %>
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
						<img src="/images/spacer.gif" width="5" height="1"><img src="/images/big_bullit.gif">&nbsp;&nbsp;Update Task</td>
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
 <table class="container" border="0" cellpadding="0" cellspacing="0" width="20%">
  <tbody>
    <tr>
        <td width="1%" class="container_tl"><div></div></td>
        <td width="91%" class="container_tmid"><div>Update Task</div></td>
        <td width="8%" class="container_tr"><div></div></td>
    </tr>
    <tr>
        <td class="container_l"></td>
        <td class="container_content">
        
<!--################ END FORM STYLE-->

 <table border="0" cellspacing="2" cellpadding="2" class="container">  
        <tr>
            <td colspan="3">
            <asp:Label ID="lblMsg" runat="server" ForeColor="#FF3300"></asp:Label>
                <asp:HiddenField ID="hdnfldtskid" runat="server" />
            </td>
        </tr>        
        <tr>
            <td class="txtlbl" width="230px">
                Active Tasks <span class="errormsg">*</span><asp:RequiredFieldValidator ID="RequiredFieldValidator3" 
                    runat="server" ControlToValidate="LblTaskTitle" Display="None" 
                    ErrorMessage="RequiredFieldValidator" ValidationGroup="TaskUpdte" 
                    InitialValue="0"></asp:RequiredFieldValidator>
                <br />
                <asp:TextBox ID="LblTaskTitle" runat="server" CssClass="inputTextBoxLP1"></asp:TextBox>
               
            </td>
            <td class="txtlbl" width="100px">
                (%) Completed <span class="errormsg">*</span><asp:RequiredFieldValidator ID="RequiredFieldValidator2" 
                    runat="server" ControlToValidate="TxtPctcomplete" ErrorMessage="*" 
                    Display="None" ValidationGroup="TaskUpdte"></asp:RequiredFieldValidator>
                <br />
                <asp:TextBox ID="TxtPctcomplete" runat="server" Height="16px" Width="193px" ontextchanged="TxtPctcomplete_TextChanged"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="TxtPctcomplete_FilteredTextBoxExtender" 
                    runat="server" Enabled="True" FilterType="Numbers" 
                    TargetControlID="TxtPctcomplete">
                </cc1:FilteredTextBoxExtender>
                <cc1:NumericUpDownExtender ID="TxtPctcomplete_NumericUpDownExtender" 
                    runat="server" Enabled="True" Maximum="100" Minimum="0" RefValues="" 
                    ServiceDownMethod="" ServiceDownPath="" ServiceUpMethod="" Tag="" 
                    TargetButtonDownID="" TargetButtonUpID="" TargetControlID="TxtPctcomplete" width="50">
                </cc1:NumericUpDownExtender>
            </td>
           <td><asp:CheckBox ID="Chkstatus" runat="server" CssClass="" Text="Is Completed" /></td>
        </tr>
        <tr>
            <td class="txtlbl" colspan="3">
                Progress Description  <span class="errormsg">*</span><asp:RequiredFieldValidator ID="RequiredFieldValidator1" 
                    runat="server" ControlToValidate="TxtDescription" ErrorMessage="*" 
                    Display="None" ValidationGroup="TaskUpdte"></asp:RequiredFieldValidator>
                <br />
                <asp:TextBox ID="TxtDescription" runat="server" 
                    TextMode="MultiLine" width="415px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:Button ID="BtnSave" runat="server" CssClass="button" 
                    onclick="BtnSave_Click" Text="Save" ValidationGroup="TaskUpdte" />
                <asp:Button ID="BtnDelete" runat="server" CssClass="button" 
                    onclick="BtnDelete_Click" Text="Delete" />
                <cc1:ConfirmButtonExtender ID="BtnDelete_ConfirmButtonExtender" runat="server" 
                    ConfirmText="Confirm To Delete ??" Enabled="True" TargetControlID="BtnDelete">
                </cc1:ConfirmButtonExtender>
                
                <asp:Button ID="BtnBack" runat="server" CssClass="button" 
                    onclick="BtnBack_Click" Text="&lt;&lt; Back" />
                
            </td>
        </tr>
        </table>    
    
<!--################ END FORM STYLE-->	    
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
    

