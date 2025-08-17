<%@ Page Language="C#" MasterPageFile="~/ProjectMaster.Master" AutoEventWireup="true" CodeBehind="ManageLoanCollection.aspx.cs" Inherits="SwiftHrManagement.web.Company.EmployeeWeb.ManageLoanCollection" Title="Untitled Page" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    <table border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td valign="top">
                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td valign="top">
                           <!-- BREAD CRUMBS START !-->
				<table width="100%" border="0" cellspacing="0" cellpadding="0">
					<tr>
						<td valign="bottom" class="wellcome">
						<img src="/images/spacer.gif" width="5" height="1">
						
						<img src="/images/big_bullit.gif"> 
						<a href="ListLoan.aspx?Id=<%=GetEmpId().ToString()%>">List Loan  </a>
						<a href="ListLoanCollection.aspx?EmpId=<%=GetEmpId().ToString()%>&Id=<%=GetLoanId().ToString()%>">&raquo; List Loan Collection </a> &raquo;Manage Loan Collection
                            <asp:Label ID="LblEmpName" runat="server"></asp:Label>
                        </td>
					</tr>
					<tr>
						<td valign="top" bgcolor="#999999" height="1"><img src="/images/spacer.gif" width="100%" height="1"></td>
					</tr>
				</table>
				<!-- BREAD CRUMBS END !-->
                            <table border="0" cellpadding="0" cellspacing="0" width="80%">
                                <tr>
                                    <td align="center" valign="top">
                                        <br />

						<!--		Begin content	-->

						
<!--################ START FORM STYLE-->
 <table class="container" border="0" cellpadding="0" cellspacing="0" width="20%">
  <tbody><tr>
    <td width="1%" class="container_tl"><div></div></td>
    <td width="91%" class="container_tmid"><div>Manage Loan Collection </div></td>
    <td width="8%" class="container_tr"><div></div></td>
  </tr>
      <tr>
        <td class="container_l"></td>
        <td class="container_content">
<!--################ END FORM STYLE-->

    <table border="0" cellpadding="5" cellspacing="5">
            <tr>
                <td align="right" nowrap="nowrap">
                    Loan Type Taken :</td>
                <td align="left" nowrap="nowrap">
                    <asp:Label ID="loanType" runat="server" CssClass="lblText"></asp:Label>
                </td>
                <td align="right" nowrap="nowrap">
                    Loan Amount :</td>
                <td align="left" nowrap="nowrap">
                    <asp:Label ID="loan_amount" runat="server" CssClass="lblText"></asp:Label>
                </td>
            </tr>
        </table>
     <table border="0" cellpadding="5" cellspacing="5" class="container">
            <tr>
                <td colspan="2">Please enter valid data! <span class="errormsg"> (* are required fields)</span> <br />
                    <asp:Label ID="LblMsg" runat="server" Text=""></asp:Label>
                    <asp:HiddenField ID="hdnempid" runat="server" />
                </td>
            </tr>
            <tr>
                <td>Paid Amount  <span class="errormsg">*</span>
                    <asp:RequiredFieldValidator 
                            ID="rfv1" runat="server" ControlToValidate="txtPaidAmount" Display="None" 
                            SetFocusOnError="True" ValidationGroup="loan"></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="cv1" runat="server" ControlToValidate="txtPaidAmount" 
                            Display="Dynamic" ErrorMessage="Invalid Amount!" SetFocusOnError="True" 
                            Type="Double" ValidationGroup="loan"></asp:CompareValidator>
                    <br />                        
                    <asp:TextBox ID="txtPaidAmount" runat="server" CssClass="inputTextBoxLP"></asp:TextBox>
                </td>
                    
                    <td>Paid Date <span class="errormsg">*</span>
                    <asp:RequiredFieldValidator ID="rfv2" runat="server" 
                            ControlToValidate="txtPaidDate" Display="None" SetFocusOnError="True" 
                            ValidationGroup="loan"></asp:RequiredFieldValidator>
                    <br />
                    <asp:TextBox ID="txtPaidDate" runat="server" CssClass="inputTextBoxLP"></asp:TextBox>
                        <cc1:CalendarExtender ID="txtPaidDate_CalendarExtender" runat="server" 
                            Enabled="True" TargetControlID="txtPaidDate">
                        </cc1:CalendarExtender>
                </td>
            </tr>
            <tr>
                <td colspan="2">Narration <span class="errormsg">*</span><asp:RequiredFieldValidator 
                        ID="rfv34" runat="server" ControlToValidate="txtNarration" Display="None" 
                        ErrorMessage="RequiredFieldValidator" SetFocusOnError="True" 
                        ValidationGroup="loan"></asp:RequiredFieldValidator><br />
                <asp:TextBox ID="txtNarration" runat="server" CssClass="inputTextBoxMultiLine" Width="415px" Height="35px"></asp:TextBox> </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Button ID="BtnSave" runat="server" CssClass="button" 
                        onclick="BtnSave_Click" Text="Save" ValidationGroup="loan" />
                    <cc1:ConfirmButtonExtender ID="BtnSave_ConfirmButtonExtender" runat="server" 
                        ConfirmText="Confirm To Save?" Enabled="True" TargetControlID="BtnSave">
                    </cc1:ConfirmButtonExtender>
                    &nbsp;&nbsp;<asp:Button ID="BtnDelete" runat="server" CssClass="button" 
                        Text="Delete" onclick="BtnDelete_Click" />
                    <cc1:ConfirmButtonExtender ID="BtnDelete_ConfirmButtonExtender" runat="server" 
                        ConfirmText="Confirm To Delete?" Enabled="True" TargetControlID="BtnDelete">
                    </cc1:ConfirmButtonExtender>
&nbsp;<asp:Button ID="BtnCancel" runat="server" CssClass="button" 
                        Text="&lt;&lt;Back" onclick="BtnCancel_Click" />                
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


	<!--		End  content	-->	
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
