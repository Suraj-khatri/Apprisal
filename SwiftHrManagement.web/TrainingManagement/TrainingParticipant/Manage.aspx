<%@ Page Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="SwiftHrManagement.web.TrainingParticipants.Manage" Title="Swift HRM" %>
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
				<table width="100%" border="0" cellspacing="0" cellpadding="0">
					<tr>
						<td valign="bottom" class="wellcome">
						<img src="/images/spacer.gif" width="5" height="1">
						<img src="/images/big_bullit.gif">&nbsp;&nbsp;Training Participants Entry Details</td>
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
    <td width="91%" class="container_tmid"><div>Training Participants Entry</div></td>
    <td width="8%" class="container_tr"><div></div></td>
  </tr>
      <tr>
        <td class="container_l"></td>
        <td class="container_content">
        
<!--################ END FORM STYLE-->

 <table border="0" cellspacing="5" cellpadding="5" class="container">  

        <tr>          
            <td colspan="2">
                <span class="txtlbl">Please enter valid data!</span><span class="required" > (* Required fields)</span><br /><br />
                <asp:Label ID="LblMsg" runat="server"></asp:Label>         
                <asp:HiddenField ID="hdnMaxCap" runat="server" />
                <asp:HiddenField ID="hdnUsedCap" runat="server" />
            </td>
       
        </tr>
        <tr>
             <td class="txtlbl">
                Training Category :  
                <br />
                <asp:TextBox ID="TxtTrainingCategoryTitle" runat="server" CssClass="inputTextBoxLP" 
                    ReadOnly="True" Width="300px"></asp:TextBox>                                        
           </td>
           <td class="txtlbl">
                Training Program :  
                <br />
                <asp:TextBox ID="TxtTrainProgramTitle" runat="server" CssClass="inputTextBoxLP" 
                    ReadOnly="True" Width="300px"></asp:TextBox>                                        
           </td>
        </tr>
        
        <tr>            
             <td class="txtlbl">
            Branch Name <br />
              <asp:DropDownList ID="DdlReqWithBranch" runat="server" CssClass="CMBDesign" 
                    AutoPostBack="True" 
                    onselectedindexchanged="DdlReqWithBranch_SelectedIndexChanged" 
                     Width="300px">
                </asp:DropDownList>
            </td>
             <td class="txtlbl">
                Department Name <br />
              <asp:DropDownList ID="DdlReqByDept" runat="server" CssClass="CMBDesign" 
                    AutoPostBack="True" 
                    onselectedindexchanged="DdlReqByDept_SelectedIndexChanged" Width="300px">
                </asp:DropDownList>
            </td>         
        </tr> 
        <tr>             
            <td class="txtlbl">
                Employee Name :  <span class="errormsg">*</span>
                
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" 
                    runat="server" ControlToValidate="DdlStaffName" Display="Dynamic" 
                    ErrorMessage="Required!" ValidationGroup="Paticipant">
                </asp:RequiredFieldValidator><br />
                    
                <asp:DropDownList ID="DdlStaffName" runat="server" CssClass="CMBDesign" 
                    Width="300px">
                </asp:DropDownList>
            </td>
            <td>
               IsApproved?  <br /> <asp:CheckBox ID ="ChkApprove" runat="server"/>
            </td>   
        </tr>                                        
        <tr>
            <td colspan="2">
                <asp:Button ID="Btn_Save" runat="server" CssClass="button" 
                    onclick="Btn_Save_Click" Text="Save" ValidationGroup="Paticipant" />
                <cc1:ConfirmButtonExtender ID="Btn_Save_ConfirmButtonExtender" runat="server" 
                    ConfirmText="Confirm to Save?" Enabled="True" TargetControlID="Btn_Save">
                </cc1:ConfirmButtonExtender>
                <%--<asp:Button ID="Btn_Update" runat="server" CssClass="button" 
                    onclick="Btn_Update_Click" Text="Update" ValidationGroup="Paticipant" />--%> 
                    <asp:Button ID = "Btn_Update" Text="Update"  runat = "server" 
                    CssClass="button" onclick="Btn_Update_Click" />                                             
                <cc1:ConfirmButtonExtender ID="Btn_Update_ConfirmButtonExtender" runat="server" 
                    ConfirmText="Confirm to Update?" Enabled="True" TargetControlID="Btn_Update">
                </cc1:ConfirmButtonExtender>
                <asp:Button ID="Btn_Delete" runat="server" Text="Delete" CssClass="button" 
                    onclick="Btn_Delete_Click" />
                <cc1:ConfirmButtonExtender ID="Btn_Delete_ConfirmButtonExtender" runat="server" 
                    ConfirmText="Confirm to Delete?" Enabled="True" TargetControlID="Btn_Delete">
                </cc1:ConfirmButtonExtender>
                <asp:Button ID="BtnBack" runat="server" Text="<< Back" CssClass="button" 
                    onclick="BtnBack_Click"/>
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

