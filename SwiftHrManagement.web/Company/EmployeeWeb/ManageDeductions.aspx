<%@ Page Title="" Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="ManageDeductions.aspx.cs" Inherits="SwiftHrManagement.web.Company.EmployeeWeb.ManageDeductions" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">    
    <style type="text/css">
        .style10
        {
            width: 319px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    <table width="100%" height="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td valign="top">
		<table width="60%" height="100%" border="0" cellspacing="0" cellpadding="0">
		  <tr> 
			<td valign="top">
				<table height="30" border="0" cellspacing="0" cellpadding="0" 
                    style="width: 100%">
					<tr>
						<td valign="bottom" class="wellcome">
						<img src="/images/spacer.gif" width="5" height="1"><img src="/images/big_bullit.gif">&nbsp;&nbsp;Manage Deductions  
                            :
                            <asp:Label ID="LblEmpName" runat="server"></asp:Label>
                        </td>
					</tr>
					<tr>
						<td valign="top" bgcolor="#999999" height="1"><img src="/images/spacer.gif" width="100%" height="1"></td>
					</tr>
				</table>
				<table width="99%" border="0" cellspacing="0" cellpadding="0">
					<tr>
						<td valign="top" align="center"><br>

						<!--		Begin content	-->

						
<!--################ START FORM STYLE-->
 <table class="container" border="0" cellpadding="0" cellspacing="0" width="40%">
  <tbody><tr>
    <td width="1%" class="container_tl"><div></div></td>
    <td width="91%" class="container_tmid"><div>Manage Deduction</div></td>
    <td width="8%" class="container_tr"><div></div></td>
  </tr>
      <tr>
        <td class="container_l"></td>
        <td class="container_content">
        
<!--################ END FORM STYLE-->
 <table border="0" cellspacing="2" cellpadding="2" class="container">
    <tr>          
                <td align=left class="style10">
                Plese enter valid data<br />
                <span class="required" >(* Required fields)</span><br />             
                 <asp:Label ID="LblMsg" runat="server"></asp:Label> <asp:HiddenField ID="hdnempid" runat="server"/> 
                </td>
                <td align=left>
                    &nbsp;</td>
    </tr>
    <tr>
        <td class="style10">
                      Deduction Name:<span class = "errormsg">*</span><asp:RequiredFieldValidator ID="RequiredFieldValidator1" 
                          runat="server" ControlToValidate="DdlDeduction" Display="None" 
                          ErrorMessage="RequiredFieldValidator" ValidationGroup="deduction" 
                          SetFocusOnError="True"></asp:RequiredFieldValidator><br />
                      <asp:DropDownList ID="DdlDeduction" runat="server" CssClass="CMBDesign">
                      </asp:DropDownList>
        </td>       
        <td>
                      &nbsp;</td>       
    </tr>
    <tr>
        <td class="style10">
                      Deduction Date:<span class="errormsg">*</span><asp:RequiredFieldValidator 
                          ID="RequiredFieldValidator2" runat="server" 
                          ControlToValidate="TxtDeductionDate" ErrorMessage="RequiredFieldValidator" 
                          ValidationGroup="deduction" Display="None" SetFocusOnError="True"></asp:RequiredFieldValidator><br />
                      <asp:TextBox ID="TxtDeductionDate" runat="server" CssClass="inputTextBoxLP"></asp:TextBox>
                      <cc1:CalendarExtender ID="TxtDeductionDate_CalendarExtender" runat="server" 
                          Enabled="True" TargetControlID="TxtDeductionDate">
                      </cc1:CalendarExtender>
        </td>
       
        <td class="style7">
                      &nbsp;</td>
       
    </tr>
    <tr>
        <td class="style10">
                      Deduction Amount:<span class="errormsg">*</span><asp:RequiredFieldValidator ID="RequiredFieldValidator3" 
                          runat="server" ControlToValidate="TxtDeductionAmount" Display="None" 
                          ErrorMessage="RequiredFieldValidator" ValidationGroup="deduction" 
                          SetFocusOnError="True"></asp:RequiredFieldValidator><asp:TextBox ID="TxtDeductionAmount" runat="server" CssClass="inputTextBoxLP"></asp:TextBox><cc1:FilteredTextBoxExtender ID="TxtDeductionAmount_FilteredTextBoxExtender" 
                          runat="server" Enabled="True" FilterType="Numbers" 
                          TargetControlID="TxtDeductionAmount">
                      </cc1:FilteredTextBoxExtender>
                      <br />
        </td>      
        <td class="style7">
                      &nbsp;</td>      
    </tr>
    <tr>
        <td class="style10">
                      Is Taxable<br />
                      <asp:CheckBox ID="ChkTaxable" runat="server" />
        </td>      
        <td class="style7">
                      &nbsp;</td>      
    </tr>
    <tr>
        <td class="style10">
            <br />
            <asp:Button ID="BtnSave" runat="server" CssClass="button" Text="Save" 
                onclick="BtnSave_Click" ValidationGroup="deduction" />
            <cc1:ConfirmButtonExtender ID="BtnSave_ConfirmButtonExtender" runat="server" 
                ConfirmText="Confirm To Save?" Enabled="True" TargetControlID="BtnSave">
            </cc1:ConfirmButtonExtender>
            &nbsp;<asp:Button ID="BtnDelete" runat="server" CssClass="button" 
                onclick="BtnDelete_Click" Text="Delete" />
            <cc1:ConfirmButtonExtender ID="BtnDelete_ConfirmButtonExtender" runat="server" 
                ConfirmText="Confirm To Delete?" Enabled="True" TargetControlID="BtnDelete">
            </cc1:ConfirmButtonExtender>
&nbsp;<asp:Button ID="BtnCancel" runat="server" CssClass="button" Text="&lt;&lt;Back" 
                onclick="BtnCancel_Click" />
            <br />
        </td>      
        <td class="style13">
            &nbsp;</td>      
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

