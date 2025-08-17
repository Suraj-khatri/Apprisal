<%@ Page Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="ManageProcessingJob.aspx.cs" Inherits="SwiftHrManagement.web.WorkFlowManagement.WorkFlowJob.ManageProcessingJob" %>
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
						<img src="/images/big_bullit.gif">&nbsp;Job Details :- <span class="subheading">
						<asp:Label ID ="lblJobDetails" runat="server"></asp:Label></span></td>
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
    <td width="91%" class="container_tmid"><div>Job Processing </div></td>
    <td width="8%" class="container_tr"><div></div></td>
  </tr>
      <tr>
        <td class="container_l"></td>
        <td class="container_content">
        
<!--################ END FORM STYLE-->

 <table border="0" cellspacing="5" cellpadding="5" class="container">
        <tr>          
            <td colspan="2">
                <span class="txtlbl">Please enter valid data!</span>
                <span class="required" >(* Required fields)</span><br /><br />
                <asp:Label ID="LblMsg" runat="server"></asp:Label>
            </td>    
        </tr>        
        <tr>
            <td class="style10" nowrap="nowrap">        
                   Forwarded By :                                           
                <%--<asp:TextBox ID="TxtFrom" runat="server" CssClass="inputTextBoxLP" 
                    ReadOnly="true" Width="200px" Height="18px"></asp:TextBox> --%> 
                    <asp:Label ID="lblForwardedFrom" runat="server"></asp:Label>      
            </td>             
           <td class="txtlbl" nowrap="nowrap">        
                   Forwarded Date :
                <%--<asp:TextBox ID="TxtRecievedDate" runat="server" CssClass="inputTextBoxLP" 
                     ReadOnly="true" Width="200px" Height="18px"></asp:TextBox> --%>
                     <asp:Label ID="lblForwardedDate" runat="server"></asp:Label>
            </td>
        </tr>   
        </table>
        <asp:Panel ID ="AcceptDetailPanel" runat="server">
            <table border="0" cellspacing="5" cellpadding="5" class="container">
                <tr>
                    <td class="style12" nowrap="nowrap">
                        Accepted By&nbsp;&nbsp;&nbsp; :                                                              
                    <asp:Label ID ="lblAcceptedBy" runat ="server"></asp:Label>
                    </td>
                    <td class="txtlbl" nowrap="nowrap">                                
                        Accepted Date&nbsp;&nbsp; :                  
                     <asp:Label ID="lblAcceptedDate" runat="server"></asp:Label>                  
                    </td>
                </tr>
            </table>
        </asp:Panel>       
        <table border="0" cellspacing="5" cellpadding="5" class="container">
        <tr>
          <td nowrap="nowrap" valign="top">Comments :<br />
                <asp:TextBox ID="TxtRecievedComment" runat="server" CssClass="inputTextBoxLP" 
                     ReadOnly="true"  Width="421px" Height="40px" TextMode="MultiLine"></asp:TextBox>                         
         </td>
         </tr>
         <tr>
            <td>
                <asp:Button ID="Btn_Accept" runat="server" CssClass="button" 
                        onclick="Btn_Accept_Click" Text="Accept" />
            </td>
         </tr>
              
        </table>         
        <asp:Panel ID="ForwardPanel" runat="server">
        <table border="0" cellspacing="5" cellpadding="5" class="container">
        <tr>             
            <td class="style10">           
            Job Status <span class="errormsg">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" 
                    runat="server" ControlToValidate="DdlJobStatus" Display="None" 
                    ErrorMessage="RequiredFieldValidator" ValidationGroup="Paticipant"></asp:RequiredFieldValidator>
                 </span><br />
              <asp:DropDownList ID="DdlJobStatus" runat="server" CssClass="CMBDesign">
                </asp:DropDownList>
            </td>
            <td class="txtlbl">
                    Forward To   <span class="errormsg">*</span><asp:RequiredFieldValidator ID="RequiredFieldValidator2" 
                    runat="server" ControlToValidate="DdlStaffName" Display="None" 
                    ErrorMessage="RequiredFieldValidator" ValidationGroup="Paticipant"></asp:RequiredFieldValidator><br />
                <asp:DropDownList ID="DdlStaffName" runat="server" CssClass="CMBDesign">
                </asp:DropDownList>
            </td>  
        </tr>
        
        <tr>
         <td valign="top" class="txtlbl" colspan="2">        
                    Comments : <span class="errormsg">*</span><asp:RequiredFieldValidator ID="RequiredFieldValidator1" 
                    runat="server" ControlToValidate="TxtJobDescription" Display="None" ErrorMessage="*" 
                    ValidationGroup="Paticipant"></asp:RequiredFieldValidator><br />
                <asp:TextBox ID="TxtJobDescription" runat="server" CssClass="inputTextBoxLP" 
                    TextMode="MultiLine" Width="423px" Height="47px"></asp:TextBox>        
         </td>             
       </tr>                                               
        <tr>
            <td class="style10">
            
                <asp:Button ID="Btn_Save" runat="server" CssClass="button" onclick="Btn_Save_Click" Text="Save" ValidationGroup="Paticipant" />
                <asp:Button ID="Btn_Update" runat="server" CssClass="button" Text="Update" 
                    ValidationGroup="Paticipant" onclick="Btn_Update_Click1" Visible="False" />                                       
                <asp:Button ID="Btn_Delete" runat="server" CssClass="button" Text="Delete" onclick="Btn_Delete_Click" />
                <asp:Button ID="Btn_Back" runat="server" CssClass="button" OnClick="Btn_Back_Click" Text="&lt;&lt; Back" Width="53px" />
                  
            </td>                                        
        </tr>
        </table>
       </asp:Panel>
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