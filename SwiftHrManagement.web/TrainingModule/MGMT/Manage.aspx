<%@ Page Title="" Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="SwiftHrManagement.web.TrainingModule.MGMT.Manage" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../../Jsfunc.js" type="text/javascript"></script>
    <script language="javascript">
        function AutocompleteOnSelected(sender, e) 
        {
            var CustodianValueArray = (e._value).split("|");
            var HiddenFieldEmpID = document.getElementById("<%=hdnEmpId.ClientID %>");
            hdnEmpId.value = CustodianValueArray[1];
        }
        function GetForwardEmployee(sender, e) {
            var CustodianValueArray = (e._value).split("|");
            var HiddenFieldEmpID = document.getElementById("<%=hdnForwardEmp.ClientID %>");
            hdnForwardEmp.value = CustodianValueArray[1];
        }
        
        function OnDelete(id) {
            if (confirm("Confirm To Delete?")) {
                document.getElementById("<% =hdnId.ClientID %>").value = id;
                document.getElementById("<% =btnDeleteNominee.ClientID %>").click();
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">

    <asp:HiddenField ID="hdnEmpId" runat="server" />
    <asp:HiddenField ID="hdnForwardEmp" runat="server" />
    <asp:HiddenField ID="hdnId" runat="server" />    
    <asp:Button ID="btnDeleteNominee" runat="server" Text="Button" onclick="btnDeleteNominee_Click" style="display:none;"/>
    
<table width="100%" height="100%" border="0" cellspacing="0" cellpadding="0" align="center">
  <tr>
    <td valign="top">
		<table width="100%" height="100%" border="0" cellspacing="0" cellpadding="0">
		  <tr> 
			<td valign="top">
				<table width="100%" border="0" cellspacing="0" cellpadding="0">
					<tr>
						<td valign="bottom" class="wellcome">
						<img src="/images/spacer.gif" width="5" height="1">
						<img src="/images/big_bullit.gif">&nbsp;Training Program Details</td>
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
 <table class="container" border="0" cellpadding="0" cellspacing="0" width="60%" align="center">
  <tbody><tr>
    <td width="1%" class="container_tl"><div></div></td>
    <td width="91%" class="container_tmid"><div>Training Program</div></td>
    <td width="8%" class="container_tr"><div></div></td>
  </tr>
      <tr>
        <td class="container_l"></td>
        <td class="container_content">
        
<!--################ END FORM STYLE-->

   <table cellpadding="5" cellpadding="5" class="container" > 
    <tr>
        <td>
            <asp:Label ID="LblMsg" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            <fieldset style="list-style:circle; list-style-type:circle; width:98%;">
        <legend>Training Program Information:</legend>
     <table cellpadding="5" cellpadding="5" class="container"> 
        <tr>
            <td nowrap="nowrap"><div align="right" class="txtlbl">Training Category:</div></td>
            <td width="40%"><asp:Label ID="lblCategory" runat="server"></asp:Label> </td>
            <td nowrap="nowrap"></td>
            <td></td>
        </tr>     
        <tr>
            <td nowrap="nowrap"><div align="right" class="txtlbl">Program Type:</div></td>
            <td width="40%"><asp:Label ID="lblProgramType" runat="server"></asp:Label> </td>
            <td nowrap="nowrap"><div align="right" class="txtlbl">Conducted By:</div></td>
            <td><asp:Label ID="lblConductedBy" runat="server"></asp:Label> </td>
        </tr>
        <tr>
            <td nowrap="nowrap"><div align="right" class="txtlbl">Program Name:</div></td>
            <td><asp:Label ID="lblProgramName" runat="server"></asp:Label> </td>
            <td nowrap="nowrap"><div align="right" class="txtlbl">Estimated Cost:</div></td>
            <td><asp:Label ID="lblEstimatedCost" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td nowrap="nowrap"><div align="right" class="txtlbl">Start Date:</div></td>
            <td><asp:Label ID="lblStartDate" runat="server"></asp:Label></td>
            <td nowrap="nowrap"><div align="right" class="txtlbl">End Date:</div></td>
            <td><asp:Label ID="lblEndDate" runat="server"></asp:Label></td>
        </tr>
        <tr>        
            <td nowrap="nowrap"><div align="right" class="txtlbl">No Of Hours:</div></td>
            <td><asp:Label ID="lblNoOfHours" runat="server"></asp:Label> </td>
            <td nowrap="nowrap"><div align="right" class="txtlbl">No Of Days:</div></td>
            <td><asp:Label ID="lblNoOfDays" runat="server"></asp:Label> </td>
        </tr>
        <tr>        
            <td nowrap="nowrap"><div align="right" class="txtlbl">Nominee Within:</div></td>
            <td><asp:Label ID="lblNomineeWithin" runat="server"></asp:Label> </td>
            <td nowrap="nowrap"><div align="right" class="txtlbl">Total Capacity:</div></td>
            <td><asp:Label ID="lblTotCapacity" runat="server"></asp:Label> </td>
        </tr>
        <tr>        
            <td nowrap="nowrap"><div align="right" class="txtlbl">Country:</div></td>
            <td><asp:Label ID="lblCountry" runat="server"></asp:Label> </td>
            <td nowrap="nowrap"><div align="right" class="txtlbl">City:</div></td>
            <td><asp:Label ID="lblCity" runat="server"></asp:Label> </td>
        </tr>
        <tr>        
            <td nowrap="nowrap"><div align="right" class="txtlbl">Venue:</div></td>
            <td><asp:Label ID="lblVenue" runat="server"></asp:Label> </td>
            <td nowrap="nowrap"><div align="right" class="txtlbl">Created By:</div></td>
            <td><asp:Label ID="lblCreatedBy" runat="server"></asp:Label> </td>
        </tr>
        <tr>        
            <td nowrap="nowrap"><div align="right" class="txtlbl">Created Date:</div></td>
            <td><asp:Label ID="lblCreatedDate" runat="server"></asp:Label> </td>
            <td nowrap="nowrap"><div align="right" class="txtlbl">Status:</div></td>
            <td><asp:Label ID="lblStatus" runat="server"></asp:Label> </td>
        </tr>
        <tr>        
            <td nowrap="nowrap"><div align="right" class="txtlbl">Narration:</div></td>
            <td colspan="3"><asp:Label ID="lblNarration" runat="server"></asp:Label> </td>
        </tr>
        <tr>        
            <td nowrap="nowrap"><div align="right" class="txtlbl">Trainer Cost:</div></td>
            <td><asp:Label ID="lblTrainerCost" runat="server"></asp:Label></td>
            <td nowrap="nowrap"><div align="right" class="txtlbl">Cost of Food/Venue :</div></td>
            <td><asp:Label ID="lblFoodVenueCost" runat="server"></asp:Label> </td>
        </tr>  
        <tr>        
            <td nowrap="nowrap"><div align="right" class="txtlbl">Cost of Per Person :</div></td>
            <td><asp:Label ID="lblPerPersonCost" runat="server"></asp:Label></td>
            <td nowrap="nowrap"><div align="right" class="txtlbl">Other Cost :</div></td>
            <td><asp:Label ID="lblOtherCost" runat="server"></asp:Label> </td>
        </tr>         
        <tr>        
            <td nowrap="nowrap"><div align="right" class="txtlbl">Total Cost:</div></td>
            <td><asp:Label ID="lblTotalCost" runat="server"></asp:Label></td>
            <td nowrap="nowrap">&nbsp;</td>
            <td>&nbsp;</td>
        </tr> 
     </table>
    </fieldset>
    </td>
    </tr>
       <div id="forwardArea" runat="server">
    <tr>
        <td colspan="3">
    <fieldset style="list-style:circle; list-style-type:circle; width:98%;">
    <legend>Forward Training:</legend>
     <table> 
        <tr>
            <td nowrap="nowrap"><div align="right" class="txtlbl">Forward To:</div></td>
            <td>
                <asp:DropDownList ID="ddlForwardedTo" runat="server" CssClass="CMBDesign" Width="300px" ></asp:DropDownList>
                <span class="required">*</span>                
                
                <asp:RequiredFieldValidator ID="RequiredFieldValidator12" 
                    runat="server" ControlToValidate="ddlForwardedTo" Display="dynamic" 
                    ErrorMessage="Required" ValidationGroup="training" 
                    SetFocusOnError="True">
                </asp:RequiredFieldValidator>
                
            </td>
        </tr>
     </table>     
    </fieldset>
        </td>
    </tr>
    </div>
    <tr>
    <td>

    <asp:Panel ID="pnlAddNominee" runat="server">
            <fieldset style="list-style:circle; list-style-type:circle; width:98%;">
                <legend>Add Nominees Information:</legend>
                <table border="0" class="container"> 
                <tr>
                <td nowrap="nowrap"><div align="right" class="txtlbl">Employee Name:</div></td>
                <td>
                <asp:TextBox ID="txtEmployeeName" runat="server" CssClass="inputTextBoxLP" Width="600px" AutoComplete="Off"></asp:TextBox>


                <cc1:TextBoxWatermarkExtender ID="txtEmployeeName_TextBoxWatermarkExtender" 
                runat="server" Enabled="True" TargetControlID="txtEmployeeName"
                WatermarkCssClass="watermark" WatermarkText="Auto Complete">
                </cc1:TextBoxWatermarkExtender>

                <cc1:AutoCompleteExtender ID="txtEmployeeName_AutoCompleteExtender" runat="server" 
                DelimiterCharacters="" Enabled="True" ServicePath="~/Autocomplete.asmx" 
                ServiceMethod="GetEmployeeList" TargetControlID="txtEmployeeName"
                MinimumPrefixLength="1" CompletionInterval="10"
                EnableCaching="true" CompletionListCssClass="autocompleteTextBoxLP" 
                OnClientItemSelected="AutocompleteOnSelected">
                </cc1:AutoCompleteExtender>
                </td>
                <td><asp:Button ID="btnAddNominee" runat="server" Text="Add New" class="button" 
                onclick="btnAddNominee_Click"/></td>
                </tr>
                <tr>
                <td colspan="3"><div id="displayNomniee" runat="server"></div></td>

                </tr>
                </table>     
            </fieldset>
    </asp:Panel>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Button ID="btnApprove" runat="server" CssClass="button" Text="Approve" 
                onclick="btnApprove_Click"/>&nbsp;
                
            <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender3" runat="server" 
                    ConfirmText="Confirm to approve?" Enabled="True" TargetControlID="btnApprove">
            </cc1:ConfirmButtonExtender>
                
            <asp:Button ID="btnReject" runat="server" CssClass="button" Text="Reject" 
                onclick="btnReject_Click" />&nbsp;
                
            <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender2" runat="server" 
                    ConfirmText="Confirm to Reject?" Enabled="True" TargetControlID="btnReject">
            </cc1:ConfirmButtonExtender>
                       <asp:Button ID="btnSave" runat="server" Text=" Save & Forward" CssClass="button" 
                onclick="btnSave_Click" ValidationGroup="training"/>&nbsp;

            <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" 
                ConfirmText="Confirm to Save?" Enabled="True" TargetControlID="btnSave">
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
</asp:Content>