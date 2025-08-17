<%@ Page Title="" Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="SwiftHrManagement.web.Company.EmployeeWeb.MedicalAppointment.Manage" %>
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
						<img src="/images/big_bullit.gif">&nbsp;Request for doctor appointment</td>
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
    <td width="91%" class="container_tmid"><div>Doctor Appointment</div></td>
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
            <td nowrap="nowrap"><div align="right" class="txtlbl">Employee Name :</div>
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
            <td nowrap="nowrap"><div align="right" class="txtlbl">Patient's Name :</div></td>
            <td nowrap="nowrap">
                <asp:TextBox ID="txtPatientName" runat="server" CssClass="inputTextBoxLP1" Width="300px"></asp:TextBox>&nbsp;<span class="required">*</span>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ControlToValidate="txtPatientName" Display="Dynamic" 
                        ErrorMessage="Required!" ValidationGroup="doctor" 
                        SetFocusOnError="True"></asp:RequiredFieldValidator>

           </td>
        </tr>
        <tr>
            <td nowrap="nowrap"><div align="right" class="txtlbl">Symptoms/Desease :</div></td>
            <td nowrap="nowrap">
                     <asp:TextBox ID="txtSymptoms" runat="server" CssClass="inputTextBoxLP" 
                        TextMode="MultiLine" Height="30px" Width="400px"></asp:TextBox>&nbsp;<span class="errormsg">*</span>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                        ControlToValidate="txtSymptoms" Display="Dynamic" 
                        ErrorMessage="Required!" ValidationGroup="Data" 
                        SetFocusOnError="True"></asp:RequiredFieldValidator>
                                     
                </td>
        </tr>
        <tr>
            <td nowrap="nowrap"><div align="right" class="txtlbl">Extension Number :</div></td>
            <td nowrap="nowrap">
                <asp:TextBox ID="txtExtensionNum" runat="server" CssClass="inputTextBoxLP1"></asp:TextBox>&nbsp;<span class="required">*</span>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                        ControlToValidate="txtExtensionNum" Display="Dynamic" 
                        ErrorMessage="Required!" ValidationGroup="doctor" 
                        SetFocusOnError="True"></asp:RequiredFieldValidator>

           </td>
        </tr>
        <tr>
            <td nowrap="nowrap"><div align="right" class="txtlbl">Is Consulted? :</div></td>
            <td nowrap="nowrap">
                <asp:DropDownList ID="ddlIsConsulted" runat="server" CssClass="CMBDesign" Enabled="false">
                <asp:ListItem Value="Yes">Yes</asp:ListItem>
                <asp:ListItem Value="No" Selected="True">No</asp:ListItem>
                </asp:DropDownList>
           

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
