<%@ Page Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="SwiftHrManagement.web.TrainingManagement.TrainingEvaluation.Manage" Title="Swift HRM" %>
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
						<td valign="bottom" class="wellcome"><img src="/images/spacer.gif" width="5" height="1">
						<img src="/images/big_bullit.gif">&nbsp;Training Program Evaluation</td>
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
    <td width="91%" class="container_tmid"><div>Training Program Evaluation</div></td>
    <td width="8%" class="container_tr"><div></div></td>
  </tr>
      <tr>
        <td class="container_l"></td>
        <td class="container_content">
        
<!--################ END FORM STYLE-->

 <table border="0" cellspacing="3" cellpadding="3" class="container"> 
        <tr>
          
            <td colspan="2">
                <span class="txtlbl" >Please enter valid data!</span><span class="required" > (* Required fields)</span><br />
                <asp:Label ID="LblMsg" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
             <td>&nbsp;</td>
        </tr>
        <tr>
            <td colspan="2" class="txtlbl">Program Category<br />
            <asp:TextBox ID="txtProgramCategory" runat="server" CssClass="inputTextBoxLP" 
                    ReadOnly="True" Width="250px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td valign="top" class="txtlbl">
                Training Program Title 
                <br />
                <asp:TextBox ID="TxtTrainProgramTitle" runat="server" CssClass="inputTextBoxLP" 
                    ReadOnly="True" Width="250px"></asp:TextBox>
             </td>
            <td class="txtlbl">Evaluation Rating  <span class="errormsg">*</span>  
            
                <asp:RequiredFieldValidator ID="rfv" runat="server" 
                    ControlToValidate="DdlEvalutionRate" Display="Dynamic" 
                    ErrorMessage="Required!" SetFocusOnError="True" 
                    ValidationGroup="Evaluation"></asp:RequiredFieldValidator>
            
            <br />
                <asp:DropDownList ID="DdlEvalutionRate" runat="server" CssClass="CMBDesign">
                </asp:DropDownList>
            </td>
            
        </tr>
        <tr>            
            <td class="txtlbl" colspan="2">     
                Evaluation Details <span class="errormsg">*</span><asp:RequiredFieldValidator ID="rfv1" 
                    runat="server" ControlToValidate="TxtEvaluation" Display="Dynamic" 
                    ErrorMessage="Required!" ValidationGroup="Evaluation" 
                    SetFocusOnError="True"></asp:RequiredFieldValidator><br />
                <asp:TextBox ID="TxtEvaluation" runat="server" CssClass="inputTextBoxLP" 
                    TextMode="MultiLine" Height="30px" Width="458px" 
                    AutoCompleteType="Disabled"></asp:TextBox>
        
            </td>
            
        </tr>
        <tr>
            <td colspan="2">  
            <asp:Button ID="Btn_Save" runat="server" CssClass="button" 
                onclick="Btn_Save_Click" Text="Save" ValidationGroup="Evaluation" 
                    Width="75px" />
                <cc1:ConfirmButtonExtender ID="Btn_Save_ConfirmButtonExtender" runat="server" 
                    ConfirmText="Confirm To Save?" Enabled="True" TargetControlID="Btn_Save">
                </cc1:ConfirmButtonExtender>
                <asp:Button ID="BtnDelete" runat="server" CssClass="button" 
                    onclick="BtnDelete_Click" Text="Delete" Width="75px" />
                <cc1:ConfirmButtonExtender ID="BtnDelete_ConfirmButtonExtender" runat="server" 
                    ConfirmText="Confirm To Delete?" Enabled="True" TargetControlID="BtnDelete">
                </cc1:ConfirmButtonExtender>
<asp:Button ID="BtnBack" runat="server" Text="&lt;&lt; Back" CssClass="button" 
                    onclick="BtnBack_Click" Width="75px" />
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
    
