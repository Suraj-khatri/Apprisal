<%@ Page Title="Swift HRM" Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="FeedbackManage.aspx.cs" Inherits="SwiftHrManagement.web.PerformanceAppraisal.Feedback.Manage" %>
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
						<img src="/images/big_bullit.gif">&nbsp;&nbsp;Appraisal Feedback of Employee : <span class="subheading">
                            <asp:Label ID="LblEmpName" runat="server" Text=""></asp:Label></span></td>
					</tr>
					<tr>
						<td valign="top" bgcolor="#999999" height="1"></td>
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
    <td width="91%" class="container_tmid"><div>Appraisal Feedback Entry</div></td>
    <td width="8%" class="container_tr"><div></div></td>
  </tr>
      <tr>
        <td class="container_l"></td>
        <td class="container_content">
        
<!--################ END FORM STYLE-->

 <table border="0" cellspacing="5" cellpadding="5" class="container">  

        <tr>
            <td><span class="txtlbl">Please enter valid data!</span><br />    
               <span class="errormsg">(* Required Field) </span><br />
               <asp:Label ID="LblMsg" runat="server"></asp:Label>
                <asp:HiddenField ID="hdnAppraisalId" runat="server" />
            </td>
          
        </tr>       
        <tr>
              <td class="txtlbl">
                 Appraisal Title <span class="errormsg">*</span><asp:RequiredFieldValidator 
                      ID="RequiredFieldValidator4" runat="server" 
                      ErrorMessage="RequiredFieldValidator" ControlToValidate="TxtTitle" 
                      Display="None" SetFocusOnError="True" ValidationGroup="feedback"></asp:RequiredFieldValidator>
                  <br />
            <asp:TextBox ID="TxtTitle" runat="server" CssClass="inputTextBoxLP" 
                    ReadOnly="true"  ValidationGroup="evaluate"></asp:TextBox>
             </td>    
        </tr>
        <tr>         
            <td class="txtlbl">               
                Feedback <span class="errormsg">*</span><asp:RequiredFieldValidator 
                          ID="RequiredFieldValidator1" runat="server" 
                          ErrorMessage="RequiredFieldValidator" ControlToValidate="TxtFeedback" 
                          Display="None" SetFocusOnError="True" ValidationGroup="feedback"></asp:RequiredFieldValidator>
                      <br />
                <asp:TextBox ID="TxtFeedback" runat="server" CssClass="inputTextBoxLP" 
                    Width="415px" Height="60px" TextMode="MultiLine"></asp:TextBox>               
            </td>            
        </tr>
        <tr>
            <td>
                <asp:Button ID="BtnSave" runat="server" CssClass="button" 
                    onclick="BtnSave_Click" Text="Save" ValidationGroup="feedback" />
                <asp:Button ID="BtnDelete" runat="server" CssClass="button" 
                    onclick="BtnDelete_Click" Text="Delete" />
                <asp:Button ID="BtnBack" runat="server" CssClass="button" 
                    onclick="BtnBack_Click" Text="&lt;&lt; Back" />
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

