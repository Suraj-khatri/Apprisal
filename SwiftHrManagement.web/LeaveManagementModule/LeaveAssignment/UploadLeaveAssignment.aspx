<%@ Page Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="UploadLeaveAssignment.aspx.cs" Inherits="SwiftHrManagement.web.LeaveManagement.LeaveAssign.UploadLeaveAssignment"%>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style10
        {
            width: 12%;
            background-image: url('/Images/container-tr_big.gif');
        }
        .style11
        {
            width: 12%;
            background: url('/Images/container-right.gif') repeat-y;
        }
        .style12
        {
            width: 12%;
            background-image: url('/Images/container-br_8.gif');
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
 <table width="100%" border="0" cellspacing="0" cellpadding="0">
					<tr>
						<td valign="top" align="center">
                        <br />

						<!--		Begin content	-->

						
<!--################ START FORM STYLE-->
 <table class="container" border="0" cellpadding="0" cellspacing="0">
  <tbody><tr>
    <td width="1%" class="container_tl"><div></div></td>
    <td width="91%" class="container_tmid"><div>Upload CSV file for Leave Assignment</div></td>
    <td class="style10"><div></div></td>
  </tr>
      <tr>
        <td class="container_l"></td>
        <td class="container_content">
        
<!--################ END FORM STYLE-->

 <table border="0" cellspacing="5" cellpadding="5" class="container" width="50%">  

        <tr>
            <td colspan="2" nowrap="nowrap">
              
                <a target='_blank' href="../../doc/Leave/leaveAssign.csv" alt="Sample File">Get Sample Upload File</a>
                <br />
                <asp:Label ID="lblMessage" runat="server" CssClass="errormsg"></asp:Label><br />
            </td>
          
        </tr>        
        <tr>
            
            <td nowrap="nowrap" valign="top"><div class="txtlbl" align="right">Select File: <span class="errormsg">*</span> </div> </td>
            
            <td nowrap="nowrap">
            <input id="fileUpload" runat="server" name="fileUpload" type="file" size="40" class="inputTextBoxLP"/> 
                        <br />
                        <asp:RequiredFieldValidator ID="rfv1" runat="server" ErrorMessage="Required File Path!"
                ValidationGroup="adhoc" ControlToValidate="fileUpload" Display="Dynamic" 
                    SetFocusOnError="True"></asp:RequiredFieldValidator>
                        
                      
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:Button ID="BtnUpload" runat="server" Text="Upload To Server" CssClass="button" 
                    onclick="BtnUpload_Click" ValidationGroup="adhoc"/>
                <cc1:ConfirmButtonExtender ID="BtnUpload_ConfirmButtonExtender" runat="server" 
                    ConfirmText="Confirm To Upload?" Enabled="True" TargetControlID="BtnUpload">
                </cc1:ConfirmButtonExtender>
            </td>
        </tr>
        </table>
  
<!--################ START FORM STYLE-->

	</td>
    <td class="style11"></td>
  </tr>
  <tr>
    <td class="container_bl"></td>
    <td class="container_bmid"></td>
    <td class="style12"></td>
  </tr>
	</tbody>
  </table>

<!--################ END FORM STYLE-->


	<!--		End  content	-->						</td>
					</tr>
			  </table>	
</asp:Content>
