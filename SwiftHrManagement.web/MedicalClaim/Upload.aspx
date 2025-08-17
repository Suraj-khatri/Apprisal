<%@ Page Title="" Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="Upload.aspx.cs" Inherits="SwiftHrManagement.web.MedicalClaim.Upload" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
      function DeleteUploadFile(upload_Id) {
          if (confirm("Are you sure to delete this record?")) {
              document.getElementById("<% =upload_Id.ClientID %>").value = upload_Id;
              document.getElementById("<% =Delete.ClientID %>").click();
          }
      }
    </script>
    <script language="javascript">
        function checkAll(me) {
            var checkBoxes = document.forms[0].chkTran;
            var boolChecked = me.checked;

            for (i = 0; i < checkBoxes.length; i++) {
                checkBoxes[i].checked = boolChecked;
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
            	<!-- BREAD CRUMBS START !-->
				<table width="100%" border="0" cellspacing="0" cellpadding="0">
					<tr>
						<td valign="bottom" class="wellcome">
						<img src="/images/spacer.gif" width="5" height="1">
						
						<img src="/images/big_bullit.gif"> 
					 Manage Documents
						 
                           
                        </td>
					</tr>
					<tr>
						<td valign="top" bgcolor="#999999" height="1"><img src="/images/spacer.gif" width="100%" height="1"></td>
					</tr>
				</table>
				<!-- BREAD CRUMBS END !-->
				<table width="80%" border="0" cellspacing="0" cellpadding="0">
					<tr>
						<td valign="top" align="center"><br>

						<!--		Begin content	-->

						
<!--################ START FORM STYLE-->
 <table class="container" border="0" cellpadding="0" cellspacing="0" width="60%">
  <tbody><tr>
    <td width="1%" class="container_tl"><div></div></td>
    <td width="91%" class="container_tmid"><div>Upload File</div></td>
    <td width="8%" class="container_tr"><div></div></td>
  </tr>
      <tr>
        <td class="container_l"></td>
        <td class="container_content">
        
<!--################ END FORM STYLE-->

 <table border="0" cellspacing="5" cellpadding="5" class="container">  

        <tr>
            <td colspan="2">
                <asp:Label ID="lblMessage" runat="server" CssClass="txtlbl"></asp:Label>
                <asp:Label ID="lblEmpNo" runat="server"></asp:Label>
               <asp:HiddenField ID="upload_Id" runat="server" Value = "" />
            </td>
          
        </tr>
        
        <tr>
            <td nowrap="nowrap"><div align="right" class="txtlbl">Description: </div> </td>
            <td nowrap="nowrap">                 
                    <asp:TextBox ID="TxtFileDescription" runat="server" CssClass="inputTextBoxLP" Width="165px"></asp:TextBox>
                    <span class="errormsg">*</span>
                    <asp:RequiredFieldValidator ID="rfv3" 
                        runat="server" ControlToValidate="TxtFileDescription" Display="Dynamic" 
                        ErrorMessage="Required!" SetFocusOnError="True" ValidationGroup="uploader">
                    </asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td nowrap="nowrap"><div align="right" class="txtlbl">Location: </div> </td>
            <td nowrap="nowrap">
                        <input id="fileUpload" runat="server" name="fileUpload" type="file" size="20" class="inputTextBoxLP" /> 
                        <span class="errormsg">*</span> 
                        <asp:RequiredFieldValidator ID="rfv1" runat="server" ErrorMessage="Required!"
                        ValidationGroup="uploader" ControlToValidate="fileUpload" Display="Dynamic" 
                        SetFocusOnError="True">
                        </asp:RequiredFieldValidator>
                        
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:Table ID="tblResult" runat="server" Width="100%"></asp:Table>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>

                    <asp:Button ID="Delete" runat="server" CssClass="button" onclick="Delete_Click" 
                    Text="Delete" />

                <asp:Button ID="BtnUpload" runat="server" Text="Upload" CssClass="button" 
                    onclick="BtnUpload_Click" ValidationGroup="uploader"/>
                <cc1:ConfirmButtonExtender ID="BtnUpload_ConfirmButtonExtender" runat="server" 
                    ConfirmText="Confirm To Upload?" Enabled="True" TargetControlID="BtnUpload">
                </cc1:ConfirmButtonExtender>

                <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" 
                    ConfirmText="Confirm To Delete?" Enabled="True" TargetControlID="Delete">
                </cc1:ConfirmButtonExtender>

                <asp:Button ID="btnBack" runat="server" CssClass="button" 
                    Text="<< Back" OnClick="btnBack_Click"/>
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
