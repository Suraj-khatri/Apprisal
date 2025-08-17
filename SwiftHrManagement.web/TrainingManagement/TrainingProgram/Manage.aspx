<%@ Page Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="SwiftHrManagement.web.TrainingManagement.TrainingProgram.Manage" Title="Swift HRM" %>
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
						<img src="/images/big_bullit.gif">&nbsp;&nbsp;Training Program Entry Details</td>
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
 <table class="container" border="0" cellpadding="0" cellspacing="0" width="40%">
  <tbody><tr>
    <td width="1%" class="container_tl"><div></div></td>
    <td width="91%" class="container_tmid"><div>Training Program Entry Details</div></td>
    <td width="8%" class="container_tr"><div></div></td>
  </tr>
      <tr>
        <td class="container_l"></td>
        <td class="container_content">
        
<!--################ END FORM STYLE-->

 <table border="0" cellspacing="5" cellpadding="5" class="container"> 
        <tr>
            <td colspan="2">
                <span class="txtlbl">Please Enter Valid Data!</span><br />
                <span class="required" >(* Required fields)</span><br />
                <asp:Label ID="LblMsg" runat="server"></asp:Label>
            </td>     
        </tr>
        <tr>
           <td class="txtlbl">
                Training Category <span class="errormsg">*</span>
                
                        <asp:RequiredFieldValidator ID="rfc" runat="server" 
                ControlToValidate="DdlTrainingList" Display="Dynamic" ErrorMessage="Required!" 
                SetFocusOnError="True" ValidationGroup="Program">
                </asp:RequiredFieldValidator>
                <br />
                
                <asp:DropDownList ID="DdlTrainingList" runat="server" CssClass="CMBDesign">  
                </asp:DropDownList>
                
            </td>
             <td class="txtlbl">
               Program Title  <span class="errormsg">*</span>
               
               <asp:RequiredFieldValidator ID="RequiredFieldValidator2" 
                     runat="server" ControlToValidate="TxtTProgramTitle" Display="dynamic" 
                     ErrorMessage="Required!" ValidationGroup="Program" 
                     SetFocusOnError="True"></asp:RequiredFieldValidator>
                 <br />
                <asp:TextBox ID="TxtTProgramTitle" runat="server"
                    CssClass="inputTextBoxLP"></asp:TextBox>          
            </td>
        </tr>
         <tr>     
           <td  class="txtlbl">Planned Start Date
                <span class="errormsg">*</span><asp:RequiredFieldValidator ID="RequiredFieldValidator3" 
                    runat="server" ControlToValidate="TxtPStartDate" Display="dynamic" 
                    ErrorMessage="Required!" ValidationGroup="Program" 
                   SetFocusOnError="True"></asp:RequiredFieldValidator>
                <br />
                <asp:TextBox ID="TxtPStartDate" runat="server"
                    CssClass="inputTextBoxLP"></asp:TextBox>
                <cc1:CalendarExtender ID="TxtPStartDate_CalendarExtender" runat="server" 
                    Enabled="True" TargetControlID="TxtPStartDate">
                </cc1:CalendarExtender>
         </td>        
            <td class="txtlbl">Planned End Date
                  <span class="errormsg">*</span><asp:RequiredFieldValidator ID="RequiredFieldValidator4" 
                    runat="server" ControlToValidate="TxtPEndDate" Display="dynamic" 
                    ErrorMessage="Required!" ValidationGroup="Program" 
                    SetFocusOnError="True"></asp:RequiredFieldValidator>
                <asp:CompareValidator ID="CompareValidator3" runat="server" 
                    ControlToCompare="TxtPStartDate" ControlToValidate="TxtPEndDate" 
                    ErrorMessage="Invalid Date" Operator="GreaterThanEqual" SetFocusOnError="True" Type="Date"
                    ValidationGroup="Program"></asp:CompareValidator>
                <br />
                <asp:TextBox ID="TxtPEndDate" runat="server" CssClass="inputTextBoxLP"></asp:TextBox>
                <cc1:CalendarExtender ID="TxtPEndDate_CalendarExtender" runat="server" 
                    Enabled="True" TargetControlID="TxtPEndDate">
                </cc1:CalendarExtender>
            </td>
        </tr>
        <tr>
           <td  class="txtlbl">Actual Start Date<br />
                <asp:TextBox ID="TxtAStartDate" runat="server"
                  CssClass="inputTextBoxLP"></asp:TextBox>
                <cc1:CalendarExtender ID="TxtAStartDate_CalendarExtender" runat="server" 
                   Enabled="True" TargetControlID="TxtAStartDate">
               </cc1:CalendarExtender>
            </td>
           <td class="txtlbl">Actual End Date
               <asp:CompareValidator ID="CompareValidator2" runat="server" 
                   ControlToCompare="TxtAStartDate" ControlToValidate="TxtAEndDate" 
                   ErrorMessage="Invalid Date!" Operator="GreaterThanEqual"  Type="Date"
                   SetFocusOnError="True" ValidationGroup="Program"></asp:CompareValidator>
               <br />
                <asp:TextBox ID="TxtAEndDate" runat="server" 
                   CssClass="inputTextBoxLP"></asp:TextBox>
                <cc1:CalendarExtender ID="TxtAEndDate_CalendarExtender" runat="server" 
                   Enabled="True" TargetControlID="TxtAEndDate">
               </cc1:CalendarExtender>
            </td>
            </tr>
            <tr>
                <td class="txtlbl">
                    Maximum Capacity  <span class="errormsg">*</span><asp:RequiredFieldValidator 
                        ID="RequiredFieldValidator5" runat="server" 
                        ControlToValidate="TxtMaxiCapacity" Display="dynamic" 
                        ErrorMessage="Required!" ValidationGroup="Program" 
                        SetFocusOnError="True"></asp:RequiredFieldValidator>
                    <br />
                    <asp:TextBox ID="TxtMaxiCapacity" runat="server"
                    CssClass="inputTextBoxLP"></asp:TextBox>
                    
                    <cc1:FilteredTextBoxExtender ID="TxtMaxiCapacity_FilteredTextBoxExtender" 
                        runat="server" Enabled="True" FilterType="Numbers"
                        TargetControlID="TxtMaxiCapacity">
                    </cc1:FilteredTextBoxExtender>
              </td> 
                <td class="txtlbl">
                    Venue  <span class="errormsg">*</span><asp:RequiredFieldValidator 
                        ID="RequiredFieldValidator6" runat="server" 
                        ControlToValidate="TxtVenue" Display="dynamic" 
                        ErrorMessage="Required!" ValidationGroup="Program" 
                        SetFocusOnError="True"></asp:RequiredFieldValidator>
                    <br />
                    <asp:TextBox ID="TxtVenue" runat="server"
                    CssClass="inputTextBoxLP"></asp:TextBox>                   
          </td>
          </tr>
        <tr>
                <td class="txtlbl">
                City  <span class="errormsg">*</span><asp:RequiredFieldValidator 
                        ID="RequiredFieldValidator7" runat="server" 
                        ControlToValidate="TxtCity" Display="dynamic" 
                        ErrorMessage="Required!" ValidationGroup="Program" 
                        SetFocusOnError="True"></asp:RequiredFieldValidator>
                    <br />
                    <asp:TextBox ID="TxtCity" runat="server" 
                    CssClass="inputTextBoxLP"></asp:TextBox>
             </td>
                <td class="txtlbl">
                    Country  <span class="errormsg">*</span><asp:RequiredFieldValidator ID="RequiredFieldValidator8" 
                        runat="server" ControlToValidate="TxtCountry" Display="dynamic" 
                        ErrorMessage="Required!" ValidationGroup="Program" 
                        SetFocusOnError="True"></asp:RequiredFieldValidator>
                    <br />
                    <asp:TextBox ID="TxtCountry" runat="server"
                      CssClass="inputTextBoxLP"></asp:TextBox>
            </td>
           </tr>
            <tr>
            <td class="txtlbl">
                No of Days  <span class="errormsg">*</span><asp:RequiredFieldValidator ID="RequiredFieldValidator9" 
                    runat="server" ControlToValidate="TxtNoOfDays" Display="Dynamic" 
                    ErrorMessage="Required!" ValidationGroup="Program" 
                    SetFocusOnError="True"></asp:RequiredFieldValidator>
                <br />
                <asp:TextBox ID="TxtNoOfDays" runat="server"
                CssClass="inputTextBoxLP"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="TxtNoOfDays_FilteredTextBoxExtender" 
                    runat="server" Enabled="True" FilterType="Numbers" 
                    TargetControlID="TxtNoOfDays">
                </cc1:FilteredTextBoxExtender>
            </td>  
           <td class="txtlbl">
                Total Hours <br />
                <asp:TextBox ID="TxtTotHours" runat="server" 
                    CssClass="inputTextBoxLP"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="TxtTotHours_FilteredTextBoxExtender" 
                    runat="server" Enabled="True" FilterType="Numbers" 
                    TargetControlID="TxtTotHours">
                </cc1:FilteredTextBoxExtender>
            </td>
            </tr>
            <tr>
               <td class="txtlbl">
                            Total Hours per Day <br />
                            <asp:TextBox ID="TxtHoursDay" runat="server"
                            CssClass="inputTextBoxLP"></asp:TextBox>
                            <cc1:FilteredTextBoxExtender ID="TxtHoursDay_FilteredTextBoxExtender" 
                            runat="server" Enabled="True" FilterType="Numbers" 
                            TargetControlID="TxtHoursDay">
                            </cc1:FilteredTextBoxExtender>
                </td>
                <td>
                    Is Active?<br /> <asp:CheckBox ID="ChkActive" runat="server" />
                </td>
            </tr>
            <tr>
          
           <td class="txtlbl" colspan="2">
                Program Description<br />
                <asp:TextBox ID="TxtDetailContent" runat="server" 
               CssClass="inputTextBoxMultiLine" TextMode="MultiLine" Height="45px" 
                    Width="415px"></asp:TextBox>
            </td>
        </tr> 
        <%--by Sujit--%>   
       <%-- <tr>       
            <td>
                <asp:CheckBox ID="ChkActive" Text="  Active" runat="server" />
            </td>
        </tr>--%>
        <%--uptohere--%> 
        <tr>
            <td>
                <asp:Button ID="Btn_Save" runat="server" CssClass="button" 
                    onclick="Btn_Save_Click" Text="Save" ValidationGroup="Program" />
                    
                <cc1:ConfirmButtonExtender ID="Btn_Save_ConfirmButtonExtender" runat="server" 
                    ConfirmText="Confirm to Save?" Enabled="True" TargetControlID="Btn_Save">
                </cc1:ConfirmButtonExtender>
                    
                <asp:Button ID="BtnDelete" runat="server" CssClass="button" Text="Delete" 
                    onclick="BtnDelete_Click" />    
                    
                <cc1:ConfirmButtonExtender ID="BtnDelete_ConfirmButtonExtender" runat="server" 
                    ConfirmText="Confirm to Delete?" Enabled="True" TargetControlID="BtnDelete">
                </cc1:ConfirmButtonExtender>
                    
                <asp:Button ID="BtnBack" runat="server" CssClass="button" 
                    onclick="BtnBack_Click" Text="&lt;&lt; Back" />
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
</asp:Content>
