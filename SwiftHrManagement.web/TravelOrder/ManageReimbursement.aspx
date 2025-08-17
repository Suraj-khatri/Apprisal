<%@ Page Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="ManageReimbursement.aspx.cs" Inherits="SwiftHrManagement.web.Payrole_management.TADA.ManageReimbursement" %>
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
						<img src="/images/big_bullit.gif">&nbsp;Expense Reimbursement for TADA</td>
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
    <td width="91%" class="container_tmid"><div>Expense Reimbursement for TADA</div></td>
    <td width="8%" class="container_tr"><div></div></td>
  </tr>
      <tr>
        <td class="container_l"></td>
        <td class="container_content">
<!--################ END FORM STYLE-->

 <table border="0" cellspacing="2" cellpadding="2" class="container">

        <tr>
            <td>&nbsp;</td>
            <td>
                <span class="txtlbl" >Please enter valid  data!</span><span class="required" > (* Required fields)</span><br />             
                <asp:Label ID="LblMsg" runat="server" CssClass="txtlbl"></asp:Label>          
            </td>
        </tr>
        <tr>
            <td nowrap="nowrap" valign="bottom"><div align="right" class="txtlbl">Employee Name :</div></td>
            <td nowrap="nowrap"> 
                         <asp:Label ID="LblEmpName" runat="server" CssClass="txtlbl"></asp:Label> <br />                   
                         <asp:TextBox ID="txtEmpName" runat="server" AutoComplete="Off" 
                            Width="450px" AutoPostBack="true"  CssClass="inputTextBoxLP" 
                             ontextchanged="txtEmpName_TextChanged"></asp:TextBox>
                        <cc1:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" 
                            CompletionInterval="10" CompletionListCssClass="autocompleteTextBoxLP" 
                            DelimiterCharacters="" EnableCaching="true" Enabled="true" 
                            MinimumPrefixLength="1" ServiceMethod="GetEmployeeListByNameORId" 
                            ServicePath="~/Autocomplete.asmx" TargetControlID="txtEmpName">
                        </cc1:AutoCompleteExtender>                        
                        <cc1:TextBoxWatermarkExtender ID="vendor_TextBoxWatermarkExtender" 
                            runat="server" Enabled="True" TargetControlID="txtEmpName" 
                            WatermarkCssClass="watermark" WatermarkText="All Employee">
                        </cc1:TextBoxWatermarkExtender>      
            </td>  
        </tr>
        <tr>
            <td colspan="2" width="100%">
            <asp:Panel ID="Panel1" runat="server" GroupingText="Employee Information">
                <table width="100%">
                    <tr>
                        <td nowrap="nowrap"><div align="right" class="txtlbl">Branch :</div></td>
                        <td><asp:TextBox ID="txtBranch" runat="server" CssClass="inputTextBoxLP1" Width="100px"></asp:TextBox></td>

                        <td nowrap="nowrap"><div align="right" class="txtlbl">Department :</div></td>
                        <td><asp:TextBox ID="txtDepartment" runat="server" CssClass="inputTextBoxLP1" Width="100px"></asp:TextBox></td>

                        <td nowrap="nowrap"><div align="right" class="txtlbl">Designation :</div></td>
                        <td><asp:TextBox ID="txtDesignation" runat="server" CssClass="inputTextBoxLP1" Width="100px"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td colspan="6">
                            <asp:Panel ID="panel7" runat="server" GroupingText="Destination">
                                <table width="100%">
                                    <tr>
                                        <td nowrap="nowrap"><div align="right" class="txtlbl">Country :</div></td><td>
                                        <asp:TextBox ID="txtCountry" runat="server" CssClass="inputTextBoxLP1" Width="100px"></asp:TextBox></td>

                                        <td nowrap="nowrap"><div align="right" class="txtlbl">City :</div></td><td>
                                        <asp:TextBox ID="txtCity" runat="server" CssClass="inputTextBoxLP1" Width="100px"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td nowrap="nowrap"><div align="right" class="txtlbl">Extension of Visit :</div></td><td>
                                        <asp:TextBox ID="txtExtVisit" runat="server" CssClass="inputTextBoxLP1" Width="100px"></asp:TextBox></td>

                                        <td nowrap="nowrap"><div align="right" class="txtlbl">Leave Applied :</div></td><td>
                                        <asp:TextBox ID="txtLeaveApplied" runat="server" CssClass="inputTextBoxLP1" Width="100px"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td nowrap="nowrap"><div align="right" class="txtlbl">Mode of Travel :</div></td><td>
                                        <asp:TextBox ID="txtModeOfTravel" runat="server" CssClass="inputTextBoxLP1" Width="100px"></asp:TextBox></td>

                                        <td nowrap="nowrap"><div align="right" class="txtlbl">Transportation Arrangement :</div></td><td>
                                        <asp:TextBox ID="txtTransArrangement" runat="server" CssClass="inputTextBoxLP1" Width="100px"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td nowrap="nowrap"><div align="right" class="txtlbl">Accomodation :</div></td><td>
                                        <asp:TextBox ID="txtAccomodation" runat="server" CssClass="inputTextBoxLP1" Width="100px"></asp:TextBox></td>

                                        <td nowrap="nowrap"><div align="right" class="txtlbl">Fooding :</div></td><td>
                                        <asp:TextBox ID="txtFooding" runat="server" CssClass="inputTextBoxLP1" Width="100px"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td nowrap="nowrap"><div align="right" class="txtlbl">Cash Advance :</div></td><td>
                                        <asp:TextBox ID="txtCashAdvance" runat="server" CssClass="inputTextBoxLP1" Width="100px"></asp:TextBox></td>

                                        <td nowrap="nowrap"><div align="right" class="txtlbl">Amount :</div></td><td>
                                        <asp:TextBox ID="txtAmount" runat="server" CssClass="inputTextBoxLP1" Width="100px"></asp:TextBox></td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
            </td>
        </tr>
        <tr>
            <td colspan="2" width="100%">
            <asp:Panel ID="Panel2" runat="server" GroupingText="Accomodation">
                <table>
                    <tr>
                        <td nowrap="nowrap"><div align="left" class="txtlbl"></div></td>
                        <td nowrap="nowrap"><div align="left" class="txtlbl"></div></td>

                        <td nowrap="nowrap"><div align="left" class="txtlbl">Entitlement :<br />(Per day/night)</div></td>
                        <td nowrap="nowrap"><div align="left" class="txtlbl">Total Entitlement :<br />(entitlement*days)</div></td>

                        <td nowrap="nowrap"><div align="left" class="txtlbl">Claim Amount :</div></td>
                        <td nowrap="nowrap"><div align="left" class="txtlbl">Reason for Variance :</div></td>
                    </tr>
                    <tr>
                        <td nowrap="nowrap"><div align="right" class="txtlbl">Accomodation Bill Enclosed :</div></td>
                        <td><asp:DropDownList ID="DropDownList10" runat="server" CssClass="CMBDesign" AutoPostBack="true"
                                Width="105px" onselectedindexchanged="DropDownList10_SelectedIndexChanged">
                            <asp:ListItem Value="Yes">Yes</asp:ListItem>
                            <asp:ListItem Value="No" Selected="True">No</asp:ListItem>
                            </asp:DropDownList></td>

                        <td><asp:TextBox ID="TextBox19" runat="server" CssClass="inputTextBoxLP1" Width="100px"></asp:TextBox></td>
                        <td><asp:TextBox ID="TextBox10" runat="server" CssClass="inputTextBoxLP1" Width="100px"></asp:TextBox></td>

                        <td><asp:TextBox ID="TextBox13" runat="server" CssClass="inputTextBoxLP1" Width="100px"></asp:TextBox></td>
                        <td><asp:TextBox ID="TextBox11" runat="server" CssClass="inputTextBoxLP1" Width="100px"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td nowrap="nowrap"><div align="right" class="txtlbl">Per diem Allowance :</div></td>
                        <td></td>

                        <td><asp:TextBox ID="TextBox9" runat="server" CssClass="inputTextBoxLP1" Width="100px"></asp:TextBox></td>
                        <td><asp:TextBox ID="TextBox21" runat="server" CssClass="inputTextBoxLP1" Width="100px"></asp:TextBox></td>

                        <td><asp:TextBox ID="TextBox23" runat="server" CssClass="inputTextBoxLP1" Width="100px"></asp:TextBox></td>
                        <td><asp:TextBox ID="TextBox29" runat="server" CssClass="inputTextBoxLP1" Width="100px"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td colspan="6"><div align="left" class="txtlbl"><font color="green">OTHER EXPENSES</font></div></td>
                    </tr>
                    <tr>
                        <td nowrap="nowrap"><div align="right" class="txtlbl">Cost of Taxi/Bus or Fuel :</div></td>
                        <td><asp:CheckBox ID="chk1" runat="server" /></td>

                        <td><asp:TextBox ID="TextBox37" runat="server" CssClass="inputTextBoxLP1" Width="100px" Visible="false"></asp:TextBox></td>
                        <td><asp:TextBox ID="TextBox38" runat="server" CssClass="inputTextBoxLP1" Width="100px" Visible="false"></asp:TextBox></td>

                        <td><asp:TextBox ID="TextBox28" runat="server" CssClass="inputTextBoxLP1" Width="100px"></asp:TextBox></td>
                        <td><asp:TextBox ID="TextBox18" runat="server" CssClass="inputTextBoxLP1" Width="100px" Visible="false"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td nowrap="nowrap"><div align="right" class="txtlbl">Airport Tax :</div></td>
                        <td><asp:CheckBox ID="CheckBox1" runat="server" /></td>

                        <td><asp:TextBox ID="TextBox31" runat="server" CssClass="inputTextBoxLP1" Width="100px" Visible="false"></asp:TextBox></td>
                        <td><asp:TextBox ID="TextBox32" runat="server" CssClass="inputTextBoxLP1" Width="100px" Visible="false"></asp:TextBox></td>

                        <td><asp:TextBox ID="TextBox27" runat="server" CssClass="inputTextBoxLP1" Width="100px"></asp:TextBox></td>
                        <td><asp:TextBox ID="TextBox20" runat="server" CssClass="inputTextBoxLP1" Width="100px" Visible="false"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td nowrap="nowrap"><div align="right" class="txtlbl">Communication :</div></td>
                        <td><asp:CheckBox ID="CheckBox2" runat="server" /></td>

                        <td><asp:TextBox ID="TextBox33" runat="server" CssClass="inputTextBoxLP1" Width="100px" Visible="false"></asp:TextBox></td>
                        <td><asp:TextBox ID="TextBox34" runat="server" CssClass="inputTextBoxLP1" Width="100px" Visible="false"></asp:TextBox></td>

                        <td><asp:TextBox ID="TextBox26" runat="server" CssClass="inputTextBoxLP1" Width="100px"></asp:TextBox></td>
                        <td><asp:TextBox ID="TextBox22" runat="server" CssClass="inputTextBoxLP1" Width="100px" Visible="false"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td colspan="6"></td>
                    </tr>
                    <tr>
                        <td nowrap="nowrap"><div align="right" class="txtlbl">Total Recievable/Payable :</div></td>
                        <td><asp:CheckBox ID="CheckBox3" runat="server" /></td>

                        <td><asp:TextBox ID="TextBox35" runat="server" CssClass="inputTextBoxLP1" Width="100px" Visible="false"></asp:TextBox></td>
                        <td><asp:TextBox ID="TextBox36" runat="server" CssClass="inputTextBoxLP1" Width="100px" Visible="false"></asp:TextBox></td>

                        <td><asp:TextBox ID="TextBox25" runat="server" CssClass="inputTextBoxLP1" Width="100px"></asp:TextBox></td>
                        <td><asp:TextBox ID="TextBox24" runat="server" CssClass="inputTextBoxLP1" Width="100px" Visible="false"></asp:TextBox></td>
                    </tr>
                </table>
            </asp:Panel>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:Button ID="BtnSave" runat="server" CssClass="button" 
                    onclick="BtnSave_Click" Text="Save" ValidationGroup="doctor" />
                <cc1:ConfirmButtonExtender ID="BtnSave_ConfirmButtonExtender" runat="server" 
                    ConfirmText="Confirm To Save?" Enabled="True" TargetControlID="BtnSave">
                </cc1:ConfirmButtonExtender>
                <asp:Button ID="BtnDelete" runat="server" CssClass="button" 
                    onclick="BtnDelete_Click" Text="Delete" />
                <cc1:ConfirmButtonExtender ID="BtnDelete_ConfirmButtonExtender" runat="server" 
                    ConfirmText="Confirm To Delete?" Enabled="True" TargetControlID="BtnDelete">
                </cc1:ConfirmButtonExtender>
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
