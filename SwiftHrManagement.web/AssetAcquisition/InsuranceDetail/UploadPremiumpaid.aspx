<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/SwiftHRManager.Master" CodeBehind="UploadPremiumpaid.aspx.cs" Inherits="SwiftAssetManagement.AssetAcquisition.InsuranceDetail.UploadPremiumpaid" %>
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
				<table width="100%" border="0" cellspacing="0" cellpadding="0" style="margin-top:10px;">
					<tr>
						<td valign="bottom" class="wellcome"><img src="/images/spacer.gif" width="5" height="1">
						<img src="/images/big_bullit.gif">&nbsp;Upload File for Insurance Details<asp:ScriptManager 
                                ID="ScriptManager1" runat="server">
                            </asp:ScriptManager>
                        </td>
					</tr>
					<tr>
						<td valign="top" bgcolor="#999999" height="1"><img src="/images/spacer.gif" width="100%" height="1"></td>
					</tr>
				</table>
				<table width="100%" border="0" cellspacing="0" cellpadding="0">
					<tr>
						<td valign="top" align="center"><br>

						<!--		Begin content	-->

						
<!--################ START FORM STYLE-->
 <table class="container" border="0" cellpadding="0" cellspacing="0" width="25%">
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
            <td colspan="4">
                <span class="txtlbl" nowrap="nowrap">Please Enter Valid Data! </span>
                <span class="required" >( * are required fields)</span><br /><br />
                <asp:Label ID="lblMessage" runat="server"></asp:Label>
            </td>     
        </tr>
    <tr>
        <td colspan="4">
            <fieldset style="list-style:circle; list-style-type:circle;"><legend class="subheading">Upload File</legend>
        <table border="0" cellspacing="5" cellpadding="5" class="container">         
        <tr>
         <td nowrap="nowrap"><div align="right">Select File : </div></td>
             <td nowrap="nowrap">
                                    
                        <input id="fileUpload" runat="server" class="inputTextBoxLP" name="fileUpload" 
                            type="file" width="200px"/><span class="required">*<asp:RequiredFieldValidator ID="RequiredFieldValidator1" 
                            runat="server" ControlToValidate="fileUpload" Display="Dynamic" 
                            ErrorMessage="Required!" SetFocusOnError="True" ValidationGroup="upload">
                            </asp:RequiredFieldValidator></span></td>           

            
        </tr>
        
        <tr>
                <td><div align="right">File Description :</div></td>
                <td align="left" nowrap="nowrap">
             
                    <asp:TextBox ID="TxtFileDesc" runat="server" CssClass="inputTextBox" 
                        Width="178px"></asp:TextBox>
                        
                    <span class="errormsg">*</span><asp:RequiredFieldValidator ID="rfv2" runat="server" 
                        ControlToValidate="TxtFileDesc" Display="Dynamic" ErrorMessage="Required!" 
                        SetFocusOnError="True" ValidationGroup="upload"></asp:RequiredFieldValidator></td>

            
        </tr>
        
        <tr>
            <td nowrap="nowrap"></td>
            <td align="left" nowrap="nowrap">
                    <asp:Button ID="BtnUpload" runat="server" CssClass="button" 
                        onclick="BtnUpload_Click" Text="Upload" ValidationGroup="upload" 
                        Width="65px" />
                    </td>
        </tr>
        
              </table>
            </fieldset>
        </td>
    </tr> 
     <tr>                 
            <td class="txtlbl" colspan="4">
                <asp:Table ID="tblResult" runat="server" Width="100%">
                </asp:Table>
            </td>                                       
            <td>
                &nbsp;</td>
        </tr>
     <tr>                 
            <td class="txtlbl">
                &nbsp;</td>                                       
            <td class="txtlbl">
                &nbsp;</td>                                       
            <td class="style4">
                &nbsp;</td>                                       
            <td class="txtlbl">
                &nbsp;</td>                                       
            <td>
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

