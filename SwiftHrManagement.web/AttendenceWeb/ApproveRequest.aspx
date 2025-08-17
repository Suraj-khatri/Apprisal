<%@ Page Title="" Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="ApproveRequest.aspx.cs" Inherits="SwiftHrManagement.web.AttendenceWeb.ApproveRequest" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
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
						<img src="/images/big_bullit.gif">&nbsp;Approve Attendance Request</td>
					</tr>
					<tr>
						<td valign="top" bgcolor="#999999" height="1"></td>
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
    <td width="91%" class="container_tmid"><div>Approve Attendance Request</div></td>
    <td width="8%" class="container_tr"><div></div></td>
  </tr>
      <tr>
        <td class="container_l"></td>
        <td class="container_content">
        
<!--################ END FORM STYLE-->

<table border="0" cellspacing="5" cellpadding="5" class="container"> 
    <tr>
        <td><span class="txtlbl"> Plese enter valid data! </span>
                   <span class="required"> (* Required Fields)</span><br />   <br />      
                  <asp:Label ID="lblmsg" runat="server" style="font-weight: 700"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="txtlbl"> Employee Name
          <asp:Label ID="Label1" runat="server" CssClass="required" Text="*"></asp:Label>
            <asp:RequiredFieldValidator ID="rfc" runat="server" 
                ControlToValidate="txtEmpId" Display="None" ErrorMessage="*" 
                SetFocusOnError="True" ValidationGroup="back"></asp:RequiredFieldValidator>
            <br />
            
            <cc1:TextBoxWatermarkExtender ID="txtEmpId_TextBoxWatermarkExtender" 
            runat="server" Enabled="True" TargetControlID="txtEmpId" 
            WatermarkText="Auto Complete" WatermarkCssClass="watermark">
            </cc1:TextBoxWatermarkExtender>
        
            <cc1:AutoCompleteExtender ID="AutoCompleteExtender3" runat="server"
                    DelimiterCharacters="" Enabled="true" ServicePath="~/Autocomplete.asmx" ServiceMethod="GetEmployeeList"
                    TargetControlID="txtEmpId" MinimumPrefixLength="1" CompletionInterval="10"
                    EnableCaching="true" CompletionListCssClass="autocompleteTextBoxLP" >
            </cc1:AutoCompleteExtender>
            <asp:TextBox ID="txtEmpId" runat="server" CssClass="inputTextBoxLP" 
                Width="450px" AutoComplete="Off"></asp:TextBox>
            </td>
    </tr>

      <tr>
        <td nowrap="nowrap"><span class="txtlbl">Login Date Time</span>
              <asp:Label ID="Label3" runat="server" CssClass="required" Text="*"></asp:Label>
                <asp:RequiredFieldValidator ID="rfv1" runat="server" 
                    ControlToValidate="ddlhourin" Display="None" ErrorMessage="*" InitialValue="" 
                    SetFocusOnError="True" ValidationGroup="back"></asp:RequiredFieldValidator>
                <asp:RequiredFieldValidator ID="rfv3" runat="server" 
                    ControlToValidate="ddlminutein" Display="None" ErrorMessage="*" 
                    InitialValue="" SetFocusOnError="True" ValidationGroup="back"></asp:RequiredFieldValidator>
                <br />
                
                <asp:TextBox ID="txtLoginDate" runat="server" Width="100px" CssClass="inputTextBoxLP"></asp:TextBox>
                  <cc1:CalendarExtender ID="txtLoginDate_CalendarExtender" runat="server" 
                      Enabled="True" TargetControlID="txtLoginDate">
                  </cc1:CalendarExtender>
                <asp:DropDownList ID="ddlhourin" runat="server" CssClass="CMBDesign" Width="100px">
                </asp:DropDownList>
                <asp:DropDownList ID="ddlminutein" runat="server" CssClass="CMBDesign" Width="100px">
              </asp:DropDownList>
        </td>
      </tr>
      <tr>
        <td><span class="txtlbl">Logout Date Time</span>
            <br />
            
            <asp:TextBox ID="txtLogoutDate" runat="server" Width="100px" CssClass="inputTextBoxLP"></asp:TextBox>
                  <cc1:CalendarExtender ID="CalendarExtender1" runat="server" 
                      Enabled="True" TargetControlID="txtLogoutDate">
                  </cc1:CalendarExtender>
                  
            <asp:DropDownList ID="ddlhourout" runat="server" CssClass="CMBDesign" 
                width="100px" AutoPostBack="True" >
            </asp:DropDownList>
            <asp:DropDownList ID="ddlminuteout" runat="server" CssClass="CMBDesign" 
                Width="100px">
          </asp:DropDownList></td>
      </tr>
      <tr>
            <td>Approved By <span class="required">*</span>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="ddlApprovedBy" Display="Dynamic" ErrorMessage="Required!" 
                    SetFocusOnError="True" ValidationGroup="back">
                </asp:RequiredFieldValidator><br />

                <asp:DropDownList ID="ddlApprovedBy" runat="server" CssClass="CMBDesign"></asp:DropDownList>
            </td>
      </tr>
      <tr>
        <td class="txtlbl">Remarks
          <asp:Label ID="Label4" runat="server" CssClass="required" Text="*"></asp:Label>
            <asp:RequiredFieldValidator ID="rfv5" runat="server" 
                ControlToValidate="txtRemarks" Display="None" ErrorMessage="*" 
                SetFocusOnError="True" ValidationGroup="back"></asp:RequiredFieldValidator>
            <br />
            <asp:TextBox ID="txtRemarks" runat="server" CssClass="inputTextBoxMultiLine" 
                TextMode="MultiLine" Width="400px" Height="52px"></asp:TextBox></td>
      </tr>
      <tr>
        <td align="left">
            <asp:Button ID="btnApprove" runat="server" CssClass="button" Text="Approve" 
                onclick="btnApprove_Click"/>

             <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" 
                ConfirmText="Confim To Approve?" Enabled="True" 
                TargetControlID="btnApprove">
            </cc1:ConfirmButtonExtender>

            <asp:Button ID="btnReject" runat="server" CssClass="button"  Text="Reject" 
                onclick="btnReject_Click" />

            <cc1:ConfirmButtonExtender ID="btnReject_ConfirmButtonExtender" runat="server" 
                ConfirmText="Confirm To Reject?" Enabled="True" 
                TargetControlID="btnReject">
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