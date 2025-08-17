<%@ Page Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="MemberManage.aspx.cs" Inherits="SwiftHrManagement.web.WorkFlowManagement.WorkFlowMember.MemberManage" Title="Swift HRM" %>
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
						<img src="/images/big_bullit.gif">&nbsp;&nbsp;Work Flow Mamber Entry Details</td>
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
    <td width="91%" class="container_tmid"><div>Work Flow Member Entry for Depeartment Name: 
        <asp:Label ID="lblDeptname" runat="server" Text="Label" CssClass="subheading"></asp:Label>
    </div></td>
    <td width="8%" class="container_tr"><div></div></td>
  </tr>
      <tr>
        <td class="container_l"></td>
        <td class="container_content">
        
<!--################ END FORM STYLE-->
<asp:UpdatePanel ID="updatepanel1" runat="server">
<ContentTemplate>
 <table border="0" cellspacing="5" cellpadding="5" class="container">  

        <tr>
          
            <td>
                <span class="txtlbl">Please enter valid data! </span>
                <span class="required" >(* Required fields)</span><br />
                <asp:Label ID="LblMsg" runat="server"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TxtTProgramID" runat="server" Height="22px" Visible="False" 
                    Width="64px"></asp:TextBox>
            </td>
       
        </tr>
        <tr>
             <td class="txtlbl">
                Work Flow Category :  <span class="errormsg">*</span><asp:RequiredFieldValidator ID="RequiredFieldValidator5" 
                    runat="server" ControlToValidate="TxtWFCategory" Display="None" 
                    ErrorMessage="RequiredFieldValidator" ValidationGroup="Paticipant"></asp:RequiredFieldValidator>
                <br />
                <asp:TextBox ID="TxtWFCategory" runat="server" CssClass="inputTextBoxLP" 
                    ReadOnly="True" width="300px"></asp:TextBox>                                        
             </td>
           <td class="txtlbl">
            Branch Name <span class="errormsg">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" 
                    runat="server" ControlToValidate="DdlReqByDept" Display="None" 
                    ErrorMessage="RequiredFieldValidator" ValidationGroup="Paticipant"></asp:RequiredFieldValidator>
                 </span><br />
              <asp:DropDownList ID="DdlReqWithBranch" runat="server" CssClass="CMBDesign" 
                    AutoPostBack="True" 
                    onselectedindexchanged="DdlReqWithBranch_SelectedIndexChanged"  width="300px">
                </asp:DropDownList>
            </td>
        </tr>
        
        <tr>                         
             <td class="txtlbl">
                Department Name <span class="errormsg">
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator3" 
                    runat="server" ControlToValidate="DdlReqByDept" Display="None" 
                    ErrorMessage="RequiredFieldValidator" ValidationGroup="Paticipant"></asp:RequiredFieldValidator>
                 </span><br />
              <asp:DropDownList ID="DdlReqByDept" runat="server" CssClass="CMBDesign" 
                    AutoPostBack="True" 
                    onselectedindexchanged="DdlReqByDept_SelectedIndexChanged"  width="300px">
                </asp:DropDownList>
            </td>
            <td class="txtlbl">
                Employee Name :  <span class="errormsg">*</span><asp:RequiredFieldValidator ID="RequiredFieldValidator2" 
                    runat="server" ControlToValidate="DdlStaffName" Display="None" 
                    ErrorMessage="RequiredFieldValidator" ValidationGroup="Paticipant"></asp:RequiredFieldValidator>
                <br />
                <asp:DropDownList ID="DdlStaffName" runat="server" CssClass="CMBDesign"  width="300px">
                </asp:DropDownList>
            </td>         
        </tr>                                                 
        <tr>
            <td>
                <asp:Button ID="Btn_Save" runat="server" CssClass="button" 
                    onclick="Btn_Save_Click" Text="Save" ValidationGroup="Paticipant" width="75px"/>
                <cc1:ConfirmButtonExtender ID="Btn_Save_ConfirmButtonExtender" runat="server" 
                    ConfirmText="Confirm to Save ?" Enabled="True" TargetControlID="Btn_Save">
                </cc1:ConfirmButtonExtender>
                    <asp:Button ID = "Btn_Update" Text="Save"  runat = "server" 
                    CssClass="button" onclick="Btn_Update_Click" width="75px"/>                                             
                <cc1:ConfirmButtonExtender ID="Btn_Update_ConfirmButtonExtender" runat="server" 
                    ConfirmText="Confirm to Save ?" Enabled="True" TargetControlID="Btn_Update">
                </cc1:ConfirmButtonExtender>
                &nbsp;<asp:Button ID="Btn_Delete" runat="server" Text="Delete" CssClass="button" 
                    onclick="Btn_Delete_Click" width="75px"/>
                <cc1:ConfirmButtonExtender ID="Btn_Delete_ConfirmButtonExtender" runat="server" 
                    ConfirmText="Confirm to Delete ?" Enabled="True" TargetControlID="Btn_Delete">
                </cc1:ConfirmButtonExtender>
                <asp:Button ID="Btn_Back" runat="server" CssClass="button" 
                 OnClick="Btn_Back_Click" Text="&lt;&lt; Back" width="75px"/>
                  
            </td>                                        
        </tr>
        </table>
</ContentTemplate>
</asp:UpdatePanel>     
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