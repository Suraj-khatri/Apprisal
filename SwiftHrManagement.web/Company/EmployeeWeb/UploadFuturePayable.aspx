<%@ Page Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="UploadFuturePayable.aspx.cs" Inherits="SwiftHrManagement.web.Company.EmployeeWeb.UploadFuturePayable" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    <table width="100%" border="0" cellspacing="0" cellpadding="0">
					<tr>
						<td valign="top" align="center">
                        <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                <tr>
                                    <td class="wellcome" valign="bottom">
                                        <img height="1" src="../../Images/spacer.gif" width="5" /><img src="../../Images/big_bullit.gif" />
                                        &nbsp;Future Payable Upload CSV File
                                    </td>
                                </tr>
                                <tr>
                                    <td bgcolor="#999999" height="1" valign="top">
                                        <img height="1" src="../../Images/spacer.gif" width="100%" /></td>
                                </tr>
                        </table><br />

						<!--		Begin content	-->

						
<!--################ START FORM STYLE-->
 <table class="container" border="0" cellpadding="0" cellspacing="0" width="40%">
  <tbody><tr>
    <td width="1%" class="container_tl"><div></div></td>
    <td width="91%" class="container_tmid"><div>Upload CSV file for Future payable</div></td>
    <td width="8%" class="container_tr"><div></div></td>
  </tr>
      <tr>
        <td class="container_l"></td>
        <td class="container_content">
        
<!--################ END FORM STYLE-->

 <table border="0" cellspacing="5" cellpadding="5" class="container" width="40%">  

        <tr>
            <td colspan="2" nowrap="nowrap">
              
                <a target='_blank' href="../../doc/payroll_upload/payable/excel_upload.csv" alt="Sample File">Get Sample Upload File</a>
                <br />
                <asp:Label ID="lblMessage" runat="server" CssClass="errormsg"></asp:Label><br />
            </td>
          
        </tr>
        <tr>
            <td colspan="2">
                Benefit Head <span class="errormsg">*</span>
                <asp:RequiredFieldValidator ID="rfv2" runat="server" 
                    ErrorMessage="Required!" ControlToValidate="DdlBenefitHead" 
                    Display="Dynamic" SetFocusOnError="True" ValidationGroup="payable"></asp:RequiredFieldValidator>
                <br />
                <asp:DropDownList ID="DdlBenefitHead" runat="server" CssClass="CMBDesign"></asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td valign="top" nowrap="nowrap">
                Select File <span class="errormsg">*</span> 
                <asp:RequiredFieldValidator ID="rfv1" runat="server" ErrorMessage="Required!"
                ValidationGroup="adhoc" ControlToValidate="fileUpload" Display="Dynamic" 
                    SetFocusOnError="True"></asp:RequiredFieldValidator>
                <br />
            <input id="fileUpload" runat="server" name="fileUpload" type="file" size="20" 
                        class="inputTextBoxLP" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        
            </td>
            <td><br />
                <asp:Button ID="BtnUpload" runat="server" Text="Upload To Server" CssClass="button" 
                    onclick="BtnUpload_Click" ValidationGroup="adhoc"/>
                <cc1:ConfirmButtonExtender ID="BtnUpload_ConfirmButtonExtender" runat="server" 
                    ConfirmText="Confirm To Upload?" Enabled="True" TargetControlID="BtnUpload">
                </cc1:ConfirmButtonExtender>
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
			  </table>		
</asp:Content>