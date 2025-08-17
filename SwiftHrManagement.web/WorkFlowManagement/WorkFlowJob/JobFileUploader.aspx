<%@ Page Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="JobFileUploader.aspx.cs" Inherits="SwiftHrManagement.web.WorkFlowManagement.WorkFlowJob.JobFileUploader" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    <script language="javascript">
        
        function checkAll(me) {
            var checkBoxes = document.forms[0].chkTran;
            var boolChecked = me.checked;            

            for (i = 0; i < checkBoxes.length; i++){             
                checkBoxes[i].checked = boolChecked ;               
            }
        }    
        
    </script>

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
						<img src="/images/big_bullit.gif">&nbsp;&nbsp;Upload File For :- <span class="subheading">
                                    <asp:Label ID="lblWorkCategoryname" runat="server" Text="Label"></asp:Label>
                                </span></td>
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

 <table border="0" cellspacing="5" cellpadding="5" class="container" width="60%">  

        <tr>
            <td colspan="3">
                <span class="txtlbl" >Please enter valid data!</span>
                <span class="required" >(* Required fields)</span><br /><br />
                <asp:Label ID="lblMessage" runat="server"></asp:Label>
            </td>
          
        </tr>    
        <tr>
            <td>
                File Description <span class="errormsg">*</span>                
                <asp:RequiredFieldValidator ID="RFC" 
                    runat="server" ControlToValidate="TxtFileDescription" Display="None" 
                    ErrorMessage="*" SetFocusOnError="True" ValidationGroup="uploader"></asp:RequiredFieldValidator><br />
                <asp:TextBox ID="TxtFileDescription" runat="server" CssClass="inputTextBoxLP" 
                    Width="165px"></asp:TextBox>
            </td>
            <td valign="top" nowrap="nowrap">Select File<br />
                <input id="fileUpload" runat="server" name="fileUpload" type="file" class="inputTextBoxLP"/></td>
            <td valign="top" nowrap="nowrap"><br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="BtnUpload" runat="server" Text="Upload" CssClass="button" 
                    class="inputTextBoxLP" size="15" ValidationGroup="uploader" 
                    onclick="BtnUpload_Click1"/>                        
            </td>
        </tr>
        <tr>
            <td colspan="3">
                    <asp:Table ID="tblResult" runat="server" Width="100%"></asp:Table>
            </td>
        </tr>
        <tr>
            <td colspan="3" align="right">
                <asp:Button ID="Delete" runat="server" CssClass="button" onclick="Delete_Click" 
                    Text="Delete" />
                <asp:Button ID="Btn_Back" runat="server" CssClass="button" 
                 OnClick="Btn_Back_Click" Text="&lt;&lt; Back" />
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