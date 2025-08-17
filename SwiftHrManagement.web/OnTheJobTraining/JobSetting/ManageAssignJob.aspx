<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/SwiftHRManager.Master"  CodeBehind="ManageAssignJob.aspx.cs" Inherits="SwiftHrManagement.web.OnTheJobTraining.JobSetting.ManageAssignJob" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style10
        {
            height: 35px;
        }
    </style>
    
        <script language = "javascript">
        function DeleteNotification(job_Id) {
            if (confirm("Are you sure to delete this message?")) {
                document.getElementById("<% =job_Id.ClientID %>").value = job_Id;
                document.getElementById("<% =btn_delete.ClientID %>").click();
            }
        }
   
        </script>
    
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
						<img src="/images/big_bullit.gif">&nbsp;Job Assign Entry</td>
					</tr>
					<tr>
						<td valign="top" bgcolor="#999999" height="1"></td>
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
    <td width="91%" class="container_tmid"><div>Job Assign form</div></td>
    <td width="8%" class="container_tr"><div></div></td>
  </tr>
      <tr>
        <td class="container_l"></td>
        <td class="container_content">
        
<!--################ END FORM STYLE-->
<asp:UpdatePanel ID="updatepanel1" runat="server">
<ContentTemplate>
<table border="0" cellspacing="3" cellpadding="3" class="container"> 
    <tr>
        <%--<td></td>--%>
        <td colspan="2" ><span class="txtlbl"> Plese enter valid data! </span>
                   <span class="required"> (* Required Fields)</span><br />  
                  <asp:Label ID="lblmsg" runat="server" style="font-weight: 700"></asp:Label>
        </td>
    </tr>
   
    

    
            <tr>
                <td  nowrap="nowrap" ><div align="right"><span class="txtlbl" > Job Type:</span></div></td>
                <td nowrap>
                   <asp:DropDownList ID="DdlJobType" runat="server" CssClass="CMBDesign">
                        </asp:DropDownList>
                 
                   <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ControlToValidate="DdlJobType" Display="Dynamic" ErrorMessage="Required!" 
                        SetFocusOnError="True" ValidationGroup="add"></asp:RequiredFieldValidator>
                              <asp:Button ID="BtnAdd" runat="server" CssClass="button" 
                         Text="Add" ValidationGroup="add" onclick="BtnAdd_Click" />
                </td>
        </tr>
    <tr>
          <td colspan="2">
           
                <div id="rptResult" runat="server"></div>
          
          </td>
  </tr>
  
  <asp:HiddenField ID="job_Id" runat="server" Value = "" />
<asp:Button ID = "btn_delete" runat="server" onclick="btn_delete_Click" style = "display:none" />
     
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
