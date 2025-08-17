<%@ Page Title="" Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="ManageInv.aspx.cs" Inherits="SwiftHrManagement.web.DutyRooster.ManageInv" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
<asp:UpdatePanel ID="up" runat="server">
<ContentTemplate>

<table width="100%" height="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td valign="top">
		<table width="100%" height="100%" border="0" cellspacing="0" cellpadding="0">
		  <tr> 
			<td valign="top">
				<table width="100%" border="0" cellspacing="0" cellpadding="0" style="margin-top:10px;">
					<tr>
						<td valign="bottom" class="wellcome">
                        <img src="/images/spacer.gif" width="5" height="1">
                        <img src="/images/big_bullit.gif"> Duty Rooster Schedule List</td>
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
 <table class="container" border="0" cellpadding="" cellspacing="" width="40%">
  <tbody><tr>
    <td width="1%" class="container_tl"><div></div></td>
    <td width="91%" class="container_tmid"><div> Duty Rooster Schedule</div></td>
    <td width="8%" class="container_tr"><div></div></td>
  </tr>
      <tr>
        <td class="container_l"></td>
        <td class="container_content">
        
<!--################ END FORM STYLE-->

    <table border="0" cellspacing="5" cellpadding="5" class="container">
        <tr>
            <td colspan="4"><asp:Label ID="lblMsg" runat="server" CssClass="txtlbl"></asp:Label> </td>
        </tr>
        <tr>
            <td nowrap="nowrap"><div align="right" class="txtlbl">Employee Name:</div></td>
             <td nowrap="nowrap" colspan="3">
                    <asp:Label ID="lblEmpName" runat="server" CssClass="txtlbl"></asp:Label> <br />                   
                         <asp:TextBox ID="txtEmpName" runat="server" AutoComplete="Off" 
                            Width="450px" AutoPostBack="true"  CssClass="inputTextBoxLP" 
                             ontextchanged="txtEmpName_TextChanged" ReadOnly="true"></asp:TextBox>
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
            <td nowrap="nowrap"><div align="right" class="txtlbl">Day Name:</div></td>
            <td colspan="3" align="left" NOWRAP="NOWRAP"> 
                <asp:Label ID="lblDayName" runat="server" CssClass="txtlbl"/>
              
            </td>
        </tr>
        <tr>
            <td nowrap="nowrap"><div align="right" class="txtlbl">Is Day Off:</div></td>
            <td colspan="3" align="left" NOWRAP="NOWRAP"> 
                <asp:CheckBox ID="chkSunday" runat="server"/>
              
            </td>
        </tr>
        <tr>
             <td nowrap="nowrap"><div align="right" class="txtlbl">Login Date:</div></td>
             <td nowrap="nowrap">
               <asp:TextBox ID="txtStartDate" runat="server" CssClass="inputTextBox"></asp:TextBox>  
               <span class="required">*</span>

                 <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="txtStartDate" Display="Dynamic" ErrorMessage="Required!" 
                    ValidationGroup="add"  SetFocusOnError="True"></asp:RequiredFieldValidator>

                <cc1:CalendarExtender ID="txtStartDate_CalendarExtender" runat="server" 
                    Enabled="True" TargetControlID="txtStartDate">
                </cc1:CalendarExtender>    
            </td>
            <td nowrap="nowrap"><div align="right" class="txtlbl">Logout Date:</div></td>
             <td nowrap="nowrap">
               <asp:TextBox ID="txtEndDate" runat="server" CssClass="inputTextBox"></asp:TextBox>  
               <span class="required">*</span>

                 <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                    ControlToValidate="txtEndDate" Display="Dynamic" ErrorMessage="Required!" 
                    ValidationGroup="add"  SetFocusOnError="True"></asp:RequiredFieldValidator>

                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" 
                    Enabled="True" TargetControlID="txtEndDate">
                </cc1:CalendarExtender>    
            </td>
        </tr>

        <tr>
             <td nowrap="nowrap"><div align="right" class="txtlbl">Office In time:</div></td>
             <td nowrap="nowrap">
                
                <asp:DropDownList ID="ddlHourIn" runat="server" CssClass="CMBDesign" 
                    Width="100px" AutoPostBack="true" 
                     onselectedindexchanged="ddlHourIn_SelectedIndexChanged" >              
                </asp:DropDownList>

                <asp:DropDownList ID="ddlMinuteIn" runat="server" CssClass="CMBDesign" 
                    Width="100px" AutoPostBack="true" 
                     onselectedindexchanged="ddlMinuteIn_SelectedIndexChanged">              
                </asp:DropDownList>  
                
                <asp:RequiredFieldValidator ID="rfv1" runat="server" 
                    ControlToValidate="ddlHourIn" Display="Dynamic" ErrorMessage="Required!" InitialValue="" 
                    SetFocusOnError="True"  ValidationGroup="add"  >
                </asp:RequiredFieldValidator>
                <asp:RequiredFieldValidator ID="rfv3" runat="server" 
                    ControlToValidate="ddlMinuteIn" Display="Dynamic" ErrorMessage="Required!" 
                    InitialValue="" SetFocusOnError="True" ValidationGroup="add">
                </asp:RequiredFieldValidator>  
              
            </td>
            <td nowrap="nowrap"><div align="right" class="txtlbl">Office Out Time:</div></td>
             <td nowrap="nowrap">
                
                <asp:DropDownList ID="ddlHourOut" runat="server" CssClass="CMBDesign" 
                    Width="100px" AutoPostBack="true" 
                     onselectedindexchanged="ddlHourOut_SelectedIndexChanged" >              
                </asp:DropDownList>

                <asp:DropDownList ID="ddlMinuteOut" runat="server" CssClass="CMBDesign" 
                    Width="100px" AutoPostBack="true" 
                     onselectedindexchanged="ddlMinuteOut_SelectedIndexChanged">              
                </asp:DropDownList>  
                
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                    ControlToValidate="ddlHourOut" Display="Dynamic" ErrorMessage="Required!" InitialValue="" 
                    SetFocusOnError="True"  ValidationGroup="add"  >
                </asp:RequiredFieldValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                    ControlToValidate="ddlMinuteOut" Display="Dynamic" ErrorMessage="Required!" 
                    InitialValue="" SetFocusOnError="True" ValidationGroup="add">
                </asp:RequiredFieldValidator>  
              
            </td>
        </tr>
        <tr>
             <td nowrap="nowrap"><div align="right" class="txtlbl">Lunch Out Time:</div></td>
             <td nowrap="nowrap">

                <asp:DropDownList ID="ddlLHourOut" runat="server" CssClass="CMBDesign" 
                    Width="100px" AutoPostBack="true" 
                     onselectedindexchanged="ddlLHourOut_SelectedIndexChanged">              
                </asp:DropDownList>

                <asp:DropDownList ID="ddlLMinuteOut" runat="server" CssClass="CMBDesign" 
                    Width="100px" AutoPostBack="true" 
                     onselectedindexchanged="ddlLMinuteOut_SelectedIndexChanged">              
                </asp:DropDownList>  
                
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="ddlLHourOut" Display="Dynamic" ErrorMessage="Required!" InitialValue="" 
                    SetFocusOnError="True"  ValidationGroup="add"  >
                </asp:RequiredFieldValidator>

                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                    ControlToValidate="ddlLMinuteOut" Display="Dynamic" ErrorMessage="Required!" 
                    InitialValue="" SetFocusOnError="True" ValidationGroup="add">
                </asp:RequiredFieldValidator>
               
            </td>
            <td nowrap="nowrap"><div align="right" class="txtlbl">Lunch InTime:</div></td>
             <td nowrap="nowrap">

                <asp:DropDownList ID="ddlLhourIn" runat="server" CssClass="CMBDesign" 
                    Width="100px" AutoPostBack="true" 
                     onselectedindexchanged="ddlLhourIn_SelectedIndexChanged">              
                </asp:DropDownList>

                <asp:DropDownList ID="ddlLMinuteIn" runat="server" CssClass="CMBDesign" 
                    Width="100px" AutoPostBack="true" 
                     onselectedindexchanged="ddlLMinuteIn_SelectedIndexChanged">              
                </asp:DropDownList>  
                
                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                    ControlToValidate="ddlLhourIn" Display="Dynamic" ErrorMessage="Required!" InitialValue="" 
                    SetFocusOnError="True"  ValidationGroup="add"  >
                </asp:RequiredFieldValidator>

                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" 
                    ControlToValidate="ddlLMinuteIn" Display="Dynamic" ErrorMessage="Required!" 
                    InitialValue="" SetFocusOnError="True" ValidationGroup="add">
                </asp:RequiredFieldValidator>
               
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td nowrap="nowrap" colspan="3">
                    <asp:Button ID="btnSave" ValidationGroup="add"  runat="server" 
                    CssClass="button" Text=" Save " onclick="btnSave_Click"  />&nbsp;

                <cc1:ConfirmButtonExtender ID="Btn_Save_ConfirmButtonExtender" runat="server" 
                    ConfirmText="Confirm to Save?" Enabled="True" TargetControlID="btnSave">
                </cc1:ConfirmButtonExtender>


                    <asp:Button ID="btnDelete" runat="server" 
                    CssClass="button" Text=" Delete " onclick="btnDelete_Click"  />&nbsp;

                <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" 
                    ConfirmText="Confirm to Delete?" Enabled="True" TargetControlID="btnDelete">
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
			  </table>			</td>
		  </tr>
	</table>	</td>
  </tr>
</table>

</ContentTemplate>
</asp:UpdatePanel>
</asp:Content>
