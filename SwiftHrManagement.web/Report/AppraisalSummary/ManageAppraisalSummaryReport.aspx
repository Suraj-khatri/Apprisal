<%@ Page Language="C#" MasterPageFile="~/SwiftHRManager.Master"  AutoEventWireup="true" CodeBehind="ManageAppraisalSummaryReport.aspx.cs" Inherits="SwiftHrManagement.web.Report.AppraisalSummary.ManageAppraisalSummaryReport" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style10
        {
            width: 104px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">

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
						<img src="/images/spacer.gif" width="5" height="1">
						<img src="/images/big_bullit.gif">&nbsp;&nbsp;Employee Appraisal Reports </td>
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
  <table class="container" border="0" cellpadding="0" cellspacing="0" width="35%">
  <tbody><tr>
    <td width="1%" class="container_tl"><div></div></td>
    <td width="91%" class="container_tmid"><div>Employee Appraisal Report</div></td>
    <td width="8%" class="container_tr"><div></div></td>
  </tr>
      <tr>
        <td class="container_l"></td>
        <td class="container_content">
        
<!--################ END FORM STYLE-->

<table border="0" cellspacing="2" cellpadding="2" class="container">
    <tr>
                <td class="style10"><div align="right" class="text_form1">Branch :</div></td>
                <td nowrap>
                   <asp:DropDownList ID="DdlBranchName" runat="server" CssClass="FltCMBDesign" 
                        AutoPostBack="True" 
                        onselectedindexchanged="DdlBranchName_SelectedIndexChanged" Width="300px">
                        </asp:DropDownList> 
                     <%--   <span class="errormsg">*</span>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Enabled="true"  ValidationGroup="appraisal"
                    ControlToValidate="DdlBranchName" ErrorMessage="Required" SetFocusOnError="true"></asp:RequiredFieldValidator>           
                --%>
                </td>
    </tr>  
     <tr>
                <td class="style10"><div align="right" class="text_form1">Department :</div></td>
                <td>
                      <asp:DropDownList ID="DdlDeptName" runat="server" CssClass="FltCMBDesign" 
                          AutoPostBack="True" 
                          onselectedindexchanged="DdlDeptName_SelectedIndexChanged" Width="300px"></asp:DropDownList>              
                </td>
    </tr>       
    <tr>
            <td class="style10"><div align="right" class="text_form1">Employee Name :</div></td>
            <td>                             
                <asp:DropDownList ID="ddlEmpName" runat="server" CssClass="FltCMBDesign" 
                    Width="300px">
                </asp:DropDownList>
            </td>
    </tr>
    <tr>
            <td class="style10"><div align="right" class="text_form1">From Date :</div></td>
            <td class="">
                    
                    <asp:TextBox ID="txtFromDate" runat="server" CssClass="inputTextBoxLP1"></asp:TextBox><span class="errormsg">*</span>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Enabled="true" 
                    ControlToValidate="txtFromDate" ErrorMessage="Required" SetFocusOnError="true" ValidationGroup="appraisal">
                    </asp:RequiredFieldValidator>
                    <cc1:CalendarExtender ID="txtfromDate_CalendarExtender" runat="server" 
                        Enabled="True" TargetControlID="txtfromDate">
                    </cc1:CalendarExtender>
            </td>
    </tr>
    <tr>
            <td class="style10"><div align="right" class="text_form1">To Date :</div></td>
            <td class="">
                <asp:TextBox ID="txtToDate" runat="server" CssClass="inputTextBoxLP1"></asp:TextBox><span class="errormsg">*</span>
                <asp:RequiredFieldValidator ID="rfv1" runat="server" Enabled="true"  ValidationGroup="appraisal"
                    ControlToValidate="txtToDate" ErrorMessage="Required" SetFocusOnError="true"></asp:RequiredFieldValidator>
                <cc1:CalendarExtender ID="txttoDate_CalendarExtender" runat="server" 
                    Enabled="True" TargetControlID="txttoDate">
                </cc1:CalendarExtender>
            </td>
    </tr>                   
    <tr>
            <td class="style10">&nbsp;</td>
            <td style="text-align: left" class="">
                <asp:Button ID="Btn_Search" runat="server" CssClass="button" Text="Search"  ValidationGroup="appraisal"
                    onclick="Btn_Search_Click"/>
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
	                    </td>
					</tr>
			  </table>
			  </td>
		  </tr>
	</table>
	</td>
  </tr>
</table>

</ContentTemplate>
</asp:UpdatePanel>
</asp:Content>