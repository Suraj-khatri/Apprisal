<%@ Page Title="" Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="AssignProject.aspx.cs" Inherits="SwiftHrManagement.web.Project.AssignProject" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script language="javascript">
        function checkAll(me) {
            var checkBoxes = document.forms[0].chkTran;
            var boolChecked = me.checked;            

            for (i = 0; i < checkBoxes.length; i++){             
                checkBoxes[i].checked = boolChecked ;               
            }
        }    
    </script>
    <link href="../Css/style.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
<asp:UpdatePanel ID="updtAssignprj" runat="server">
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
						<img src="/images/spacer.gif" width="5" height="1"><img src="/images/big_bullit.gif">&nbsp;&nbsp;Assign Project</td>
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
<table class="container" border="0" cellpadding="0" cellspacing="0" width="40%">
<tbody><tr>
<td width="1%" class="container_tl"><div></div></td>
<td width="91%" class="container_tmid"><div>Assign Project</div></td>
<td width="8%" class="container_tr"><div></div></td>
</tr>
<tr>
<td class="container_l"></td>
<td class="container_content">
        
<!--################ END FORM STYLE-->						
        
<!--################ END FORM STYLE-->

    <table border="0" cellspacing="5" cellpadding="5" class="container">
            <tr>
                <td colspan="2">
                    <asp:Label ID="lblmsg" runat="server" Text=""></asp:Label>
                    <br />
                </td>
            </tr>
            <tr>
                <td colspan="2" align ="center" > Project Title :
                    <asp:Label ID="LblTitle" runat="server" CssClass="wellcome"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="2" align ="center" > Project Category :
                    <asp:Label ID="LblCategory" runat="server" CssClass="wellcome"></asp:Label>
                </td>
            </tr>

            <tr>
                <td><span class="txtlbl">From Date :</span>                 
                    <asp:Label ID="LblFromDate" runat="server" CssClass="wellcome"></asp:Label>
                </td>           
                <td nowrap="nowrap"><span class="txtlbl">To Date :</span>
                    <asp:Label ID="LblToDate" runat="server" CssClass="wellcome"></asp:Label>
                </td>
            </tr>
            <tr>
                <td><span class="txtlbl">Project Manager :</span>
                    <asp:Label ID="LblProjectManager" runat="server" CssClass="wellcome"></asp:Label>
                </td>
                <td nowrap="nowrap"><span class="txtlbl">Project Owner :</span>
                    <asp:Label ID="LblProjectOwner" runat="server" CssClass="wellcome"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="2">Find Employee to Assign This Task </td>
            </tr>
            <tr>
                <td>Branch Name <span class="errormsg">*</span>
                <br />
                <asp:DropDownList ID="ddlBranchName" runat="server" CssClass="CMBDesign" 
                        AutoPostBack="True" onselectedindexchanged="ddlBranchName_SelectedIndexChanged"></asp:DropDownList>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>Department Name <span class="errormsg">*</span>
                <br />
                <asp:DropDownList ID="DdlDeptName" runat="server" CssClass="CMBDesign" 
                        AutoPostBack="True" onselectedindexchanged="DdlDeptName_SelectedIndexChanged"></asp:DropDownList>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td><span class="txtlbl">Employee to Assign</span>
                    <span class="errormsg">*</span>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ControlToValidate="DdlEmployee" Display="None" 
                        ErrorMessage="RequiredFieldValidator" SetFocusOnError="True" 
                        ValidationGroup="assign"></asp:RequiredFieldValidator>
                    <br />
                    <asp:DropDownList ID="DdlEmployee" runat="server" CssClass="CMBDesign" 
                        AutoPostBack="True" onselectedindexchanged="DdlEmployee_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
                <td><br />
                    <asp:Button ID="BtnSave" runat="server" CssClass="button" 
                        onclick="BtnSave_Click" Text="Add" ValidationGroup="assign" />
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <div style="border: thin solid #C0C0C0; text-align:left; width: 185px;">
                    <asp:Table ID="tblResult" runat="server" Width="100%"></asp:Table>
                    </div>
                </td>
            </tr>
            <tr>
                <td><asp:Button ID="BtnDelete" runat="server" CssClass="button" onclick="BtnDelete_Click" Text="Delete" />
                    <asp:Button ID="Btnback" runat="server" CssClass="button" 
                        onclick="Btnback_Click" Text="&lt;&lt; Back" />
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

</ContentTemplate>
</asp:UpdatePanel>
</asp:Content>
