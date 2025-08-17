<%@ Page Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="SwiftHrManagement.web.InternalTransferPlan.Manage" Title="Swift HRM" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">   
    <link href="../Css/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../../Jsfunc.js" ></script>
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
						<img src="/images/big_bullit.gif">&nbsp;&nbsp;Employee Internal Transfer Entry Details </td>
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
    <td width="91%" class="container_tmid"><div>Employee Internal Transfer Entry </div></td>
    <td width="8%" class="container_tr"><div></div></td>
  </tr>
      <tr>
        <td class="container_l"></td>
        <td class="container_content">
        
<!--################ END FORM STYLE-->

 <table border="0" cellspacing="5" cellpadding="5" class="container"> 
    <tr>
        <td colspan="3">
            <span class="txtlbl" >Please enter valid data</span><br />
            <span class="required" >(* Required fields)</span><br />
            <asp:Label ID="lblmsg" runat="server" Text=""></asp:Label>
        </td>
    </tr>
     <tr>
        <td colspan="3">&nbsp;
        </td>
    </tr>
    <tr>
        <td class="txtlbl">
            From Department<span class="errormsg">*</span>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" 
                ControlToValidate="DdlFromDept" Display="None" 
                ErrorMessage="RequiredFieldValidator" SetFocusOnError="True" 
                ValidationGroup="Internal"></asp:RequiredFieldValidator>
            <br />
            <asp:DropDownList ID="DdlFromDept" runat="server" CssClass="CMBDesign" 
                AutoPostBack="True" 
                onselectedindexchanged="DdlFromDept_SelectedIndexChanged">
            </asp:DropDownList>
         </td>  
        <td class="txtlbl">
            Employee Name <span class="errormsg">*</span><asp:RequiredFieldValidator ID="RequiredFieldValidator1" 
                runat="server" ControlToValidate="DdlEmpName" Display="None" 
                ErrorMessage="RequiredFieldValidator" ValidationGroup="Internal" 
                SetFocusOnError="True"></asp:RequiredFieldValidator>
            <br />
            <asp:DropDownList ID="DdlEmpName" runat="server" CssClass="CMBDesign">
            </asp:DropDownList>
         </td>
          <td class="txtlbl">           
           Transfer Department <span class="errormsg">*</span><asp:RequiredFieldValidator ID="RequiredFieldValidator10" 
                runat="server" ControlToValidate="DdlToDept" Display="None" 
                ErrorMessage="RequiredFieldValidator" ValidationGroup="Internal" 
                  SetFocusOnError="True"></asp:RequiredFieldValidator>
            <br />
            <asp:DropDownList ID="DdlToDept" runat="server" CssClass="CMBDesign">
            </asp:DropDownList>
        </td>
  </tr>
  <tr>
        <td class="txtlbl">
            Transfer Position <span class="errormsg">*</span><asp:RequiredFieldValidator ID="RequiredFieldValidator2" 
                runat="server" ControlToValidate="DdlPosition" Display="None" 
                ErrorMessage="RequiredFieldValidator" ValidationGroup="Internal" 
                SetFocusOnError="True"></asp:RequiredFieldValidator>
            <br />
            <asp:DropDownList ID="DdlPosition" runat="server" CssClass="CMBDesign">
            </asp:DropDownList>
          </td>
   
        <td class="txtlbl">Effective Date
           <span class="errormsg">*</span><asp:RequiredFieldValidator ID="RequiredFieldValidator3" 
                runat="server" ControlToValidate="txtEffectiveDate" Display="None" 
                ErrorMessage="RequiredFieldValidator" ValidationGroup="Internal" 
                SetFocusOnError="True"></asp:RequiredFieldValidator>
            <br />
            <asp:TextBox ID="txtEffectiveDate" runat="server" CssClass="inputTextBoxLP" 
                Width="197px"></asp:TextBox>
            <cc1:CalendarExtender ID="txtEffectiveDate_CalendarExtender" runat="server" 
                Enabled="True" TargetControlID="txtEffectiveDate">
            </cc1:CalendarExtender>
        </td>
        <td class="txtlbl">Actual Reported Date 
            <span class="errormsg">*</span><asp:RequiredFieldValidator ID="RequiredFieldValidator4" 
                runat="server" ControlToValidate="txtReportDate" Display="None" 
                ErrorMessage="RequiredFieldValidator" ValidationGroup="Internal" 
                SetFocusOnError="True"></asp:RequiredFieldValidator>
            <br />
            <asp:TextBox ID="txtReportDate" runat="server" CssClass="inputTextBoxLP" 
                CausesValidation="True"></asp:TextBox>
                <cc1:CalendarExtender ID="txtReportDate_CalendarExtender" runat="server" 
                Enabled="True" TargetControlID="txtReportDate">
            </cc1:CalendarExtender>
         </td>
  </tr>
  <tr>
        <td class="txtlbl">
         Transfer Description <span class="errormsg">*</span><asp:RequiredFieldValidator ID="RequiredFieldValidator8" 
                runat="server" ControlToValidate="txtTransferDesc" Display="None" 
                ErrorMessage="RequiredFieldValidator" ValidationGroup="Internal" 
                SetFocusOnError="True"></asp:RequiredFieldValidator>
            <br />
            <asp:TextBox ID="txtTransferDesc" runat="server" 
                CssClass="inputTextBoxMultiLine" TextMode="MultiLine"></asp:TextBox>
        </td>
        <td>&nbsp;</td>
         <td>&nbsp;</td>
    </tr>
        <tr>
            <td colspan="2">
               
                <asp:Button ID="BtnSave" runat="server" Text="Save" 
                    CssClass="button" onclick="BtnSave_Click" ValidationGroup="Internal"/>
             
                <asp:Button ID="BtnDelete" runat="server" CssClass="button" Text="Delete" 
                    onclick="BtnDelete_Click" />
                <asp:Button ID="BtnBack" runat="server" CssClass="button" 
                    Text="&lt;&lt; Back" onclick="BtnBack_Click" />
             
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
</asp:Content>

