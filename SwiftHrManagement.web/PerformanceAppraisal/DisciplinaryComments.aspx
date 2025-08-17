<%@ Page Title="" Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="DisciplinaryComments.aspx.cs" Inherits="SwiftHrManagement.web.PerformanceAppraisal.DisciplinaryComments" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Css/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        function DeleteNotification(ID) {
            if (confirm("Are you sure to delete this message?")) {
                document.getElementById("<% =hdnRowid.ClientID %>").value = ID;
                document.getElementById("<% =BtnDelete.ClientID %>").click();
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
				<table width="100%" border="0" cellspacing="0" cellpadding="0">
					<tr>
						<td valign="bottom" class="wellcome"><img src="/images/spacer.gif" width="5" height="1">
						<img src="/images/big_bullit.gif">&nbsp;Disciplinary Comments</td>
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
 <table class="container" border="0" cellpadding="0" cellspacing="0" width="20%">
  <tbody><tr>
    <td width="1%" class="container_tl"><div></div></td>
    <td width="91%" class="container_tmid"><div>Disciplinary Comments</div></td>
    <td width="8%" class="container_tr"><div></div></td>
  </tr>
      <tr>
        <td class="container_l"></td>
        <td class="container_content">
<!--################ END FORM STYLE-->

 <table border="0" cellspacing="5" cellpadding="5" class="container">
    <tr>
        <td>&nbsp;</td>       
        <td colspan="3">
             <span class="txtlbl">Please enter valid data!</span><span class="required" >&nbsp; (* Required fields)</span><br />      
            <asp:Label ID="lblmsg" runat="server" Text=""></asp:Label><br />
            <asp:HiddenField ID="hdnRowid" runat="server" />
        </td>
    </tr>
    <tr>
        <td>&nbsp;</td>
        <td colspan="3">
            <div id="info" runat="server">
                <table border="0" cellpadding="2" cellspacing="2">
                    <tr>
                        <td align="left"><div class="txtlbl"><strong>Branch :</strong><span class="errormsg">*</span> <br />
                            <asp:DropDownList ID="ddlBranch" runat="server" CssClass="CMBDesign" AutoPostBack="true" Width="170px"
                                                onselectedindexchanged="ddlBranch_SelectedIndexChanged"></asp:DropDownList><br />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Enabled="true" ControlToValidate="ddlBranch"
                             ErrorMessage="Required" ValidationGroup="Save"></asp:RequiredFieldValidator>
                        </div></td>
                        <td align="left"><div class="txtlbl"><strong>Department :</strong><span class="errormsg">*</span> <br />
                            <asp:DropDownList ID="ddlDepartment" runat="server" CssClass="CMBDesign" AutoPostBack="true" Width="170px" 
                                                onselectedindexchanged="ddlDepartment_SelectedIndexChanged"></asp:DropDownList><br />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Enabled="true" ControlToValidate="ddlDepartment"
                             ErrorMessage="Required" ValidationGroup="Save"></asp:RequiredFieldValidator>
                        </div></td>
                        <td align="left" colspan="2"><div class="txtlbl"><strong>Employee :</strong><span class="errormsg">*</span> <br />
                            <asp:DropDownList ID="ddlEmployee" runat="server" CssClass="CMBDesign" Width="310px"></asp:DropDownList><br />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" Enabled="true" ControlToValidate="ddlEmployee"
                             ErrorMessage="Required" ValidationGroup="Save"></asp:RequiredFieldValidator>
                        </div></td>
                    </tr>
                </table>
            </div>
        </td>
    </tr>
    <tr>
        <td>&nbsp;</td>
        <td>
            <div id="detail" runat="server">
                <table border="0" cellpadding="2" cellspacing="2">
                    <tr>
                        <td align="left"><div class="txtlbl"><strong>Comment Type :</strong><span class="errormsg">*</span> <br />
                            <asp:DropDownList ID="ddlComments" runat="server" CssClass="CMBDesign" Width="170px" 
                                onselectedindexchanged="ddlComments_SelectedIndexChanged" AutoPostBack="true">
                                <asp:ListItem Value="">Select</asp:ListItem>
                                <asp:ListItem Value="Appreciation">Appreciation</asp:ListItem>
                                <asp:ListItem Value="Action">Action</asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" Enabled="true" ControlToValidate="ddlComments"
                             ErrorMessage="Required" ValidationGroup="Add"></asp:RequiredFieldValidator>
                            </div></td>
                        <td align="left"><div class="txtlbl"><strong>Category :</strong><span class="errormsg">*</span> <br />
                            <asp:DropDownList ID="ddlCategory" runat="server" CssClass="CMBDesign" Width="170px"></asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" Enabled="true" ControlToValidate="ddlCategory"
                             ErrorMessage="Required" ValidationGroup="Add"></asp:RequiredFieldValidator>
                        </div></td>
                           <td align="left"><div class="txtlbl"><strong>Start Date :</strong><span class="errormsg">*</span> <br />
                            <asp:TextBox ID="txtStartDate" runat="server" CssClass="inputTextBoxLP1"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" Enabled="true" ControlToValidate="txtStartDate"
                             ErrorMessage="Required" ValidationGroup="Add"></asp:RequiredFieldValidator>
                                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="true" TargetControlID="txtStartDate"></cc1:CalendarExtender>
                        </div></td>
                        <td align="left" valign="top"><div class="txtlbl"><strong>End Date :</strong><br />
                            <asp:TextBox ID="txtEndDate" runat="server" CssClass="inputTextBoxLP1"></asp:TextBox>
                                <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Enabled="true" TargetControlID="txtEndDate"></cc1:CalendarExtender>
                        </div></td>
                     
                    </tr>
                    <tr>
                        <td align="left" colspan="4"><div class="txtlbl"><strong>Remarks :</strong><br />
                            <asp:TextBox ID="txtRemarks" runat="server" CssClass="inputTextBoxLP" TextMode="MultiLine" Width="658px" Height="40px"></asp:TextBox>
                        </div></td>
                           <td valign="bottom">
                            <asp:Button ID="btnAdd" runat="server" Text="Add" CssClass="button" ValidationGroup="Add" 
                                onclick="btnAdd_Click" />
                        </td>
                    </tr>
                   
                </table>
            </div>
        </td>
    </tr>
    
    <tr>
   <td></td>
        <td colspan="">
            <div id="rptComments" runat="server"></div>
        </td>
     </tr>
  
    <tr>
        <td>&nbsp;</td>
        <td class="txtlbl">
            <asp:Button ID="BtnSave" runat="server" CssClass="button" 
                Text="Save" Width="75px" onclick="BtnSave_Click" ValidationGroup="Save" />
            <cc1:confirmbuttonextender ID="BtnSave_ConfirmButtonExtender" runat="server" 
                ConfirmText="Confirm To Save?" Enabled="True" TargetControlID="BtnSave">
            </cc1:confirmbuttonextender>
            <asp:Button ID="BtnBack" runat="server" CssClass="button" 
                Text="&lt;&lt; Back" Width="75px" onclick="BtnBack_Click" />
            <asp:Button ID="BtnDelete" runat="server" style="display:none" 
                onclick="BtnDelete_Click"/>
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
