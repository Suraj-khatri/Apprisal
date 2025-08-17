<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/SwiftHRManager.Master" CodeBehind="ManageOJT.aspx.cs" Inherits="SwiftHrManagement.web.OnTheJobTraining.ManageOJT" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style11
        {
            height: 60px;
        }
        </style>
    <script type="text/javascript" language="javascript">
    function GetEmpID(sender, e) {
        var customerValueArray = (e._value).split("|");
        document.getElementById("<%=Hdnempid.ClientID%>").Value = customerValueArray[1];
     

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
						<td valign="bottom" class="wellcome">
						<img src="/images/spacer.gif" width="5" height="1">
						<img src="/images/big_bullit.gif">&nbsp;Job Group Entry</td>
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
    <td width="91%" class="container_tmid"><div>Job Group form</div></td>
    <td width="8%" class="container_tr"><div></div></td>
  </tr>
      <tr>
        <td class="container_l"></td>
        <td class="container_content">
        
<!--################ END FORM STYLE-->
<asp:UpdatePanel ID="updatepanel1" runat="server">
<ContentTemplate>
<table border="0" cellspacing="5" cellpadding="5" class="container"> 
    <tr>
        <%--<td></td>--%>
        <td colspan="3" class="txtlbl" ><span > Plese enter valid data! </span>
                   <span class="required"> (* Required Fields)</span><br />  
                  <asp:Label ID="lblmsg" runat="server" style="font-weight: 700"></asp:Label>
            <asp:HiddenField ID="Hdnempid" runat="server" />
        </td>
    </tr>
    <tr>

    
      <td colspan="2" class="txtlbl"> Training Type:  <span class="errormsg">*</span>  
      <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                ControlToValidate="DdlTrainingType" Display="Dynamic" ErrorMessage="Required!" 
                SetFocusOnError="True" ValidationGroup="ojt"></asp:RequiredFieldValidator><br />
           <asp:DropDownList ID="DdlTrainingType" runat="server" CssClass="CMBDesign" >
             <asp:ListItem Value="">Select </asp:ListItem>
             <asp:ListItem Value="o">OJT</asp:ListItem>
              <asp:ListItem Value="b">Buddy</asp:ListItem>
          </asp:DropDownList>
    
      </td>
      
      
    
     
     <td class="txtlbl">Job Type: <span class="errormsg">*</span>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                ControlToValidate="DdlJobType" Display="Dynamic" ErrorMessage="Required!" 
                SetFocusOnError="True" ValidationGroup="ojt">
           </asp:RequiredFieldValidator>
       <br />
     
      <asp:DropDownList ID="DdlJobType" runat="server" CssClass="CMBDesign">

          </asp:DropDownList>

      </td>
       
    </tr>
    
    <tr>
      
          <td colspan="3" class="txtlbl">Branch: <span class="errormsg">*</span>
             <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                ControlToValidate="DdlBranch" Display="Dynamic" ErrorMessage="Required!" 
                SetFocusOnError="True" ValidationGroup="ojt"></asp:RequiredFieldValidator>
          <br />
           <asp:DropDownList ID="DdlBranch" runat="server" CssClass="CMBDesign" 
                  onselectedindexchanged="DdlBranch_SelectedIndexChanged" Width="438px" AutoPostBack="true">
                </asp:DropDownList>
       
        
        </td>
     
 
    </tr>
    
        <tr>
              <td class="txtlbl" >Department:<span class="errormsg">*</span>
               <asp:RequiredFieldValidator ID="rfc" runat="server" 
                ControlToValidate="DdlDepartment" Display="Dynamic" ErrorMessage="Required!" 
                SetFocusOnError="True" ValidationGroup="ojt">
                </asp:RequiredFieldValidator>
              <br />
           <asp:DropDownList ID="DdlDepartment" runat="server" CssClass="CMBDesign"  AutoPostBack="true"
               onselectedindexchanged="DdlDepartment_SelectedIndexChanged">
                </asp:DropDownList>
       
          
        </td>
       
          <td colspan="2"  class="txtlbl">Employee:<span class="errormsg">*</span>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                ControlToValidate="DdlEmployee" Display="Dynamic" ErrorMessage="Required!" 
                SetFocusOnError="True" ValidationGroup="ojt"></asp:RequiredFieldValidator>
          <br />
           <asp:DropDownList ID="DdlEmployee" runat="server" CssClass="CMBDesign" 
                  AutoPostBack="True" onselectedindexchanged="DdlEmployee_SelectedIndexChanged">
                </asp:DropDownList>
         
         
        </td>
        <td class="style11" ></td>
  
    </tr>
    
    <tr>
   
     <td colspan="0"  class="txtlbl">SuperVisor/Mentor:<span class="errormsg">*</span>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                ControlToValidate="DdlSuperVisorMentor" Display="Dynamic" ErrorMessage="Required!" 
                SetFocusOnError="True" ValidationGroup="ojt"></asp:RequiredFieldValidator>
          <br />
           <asp:DropDownList ID="DdlSuperVisorMentor" runat="server" CssClass="CMBDesign">
                </asp:DropDownList>
         
         
        </td>
    
    
    
    </tr>
    
<%--    <tr>
    <td colspan="3" class="txtlbl"> SuperVisor/Mentor:<span class="errormsg">*</span>
     <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" 
                ControlToValidate="txtSuperVisorMentor" Display="Dynamic" ErrorMessage="Required!" 
                SetFocusOnError="True" ValidationGroup="ojt"></asp:RequiredFieldValidator>
    <br />
            <asp:TextBox ID="txtSuperVisorMentor" runat="server"  CssClass="inputTextBox" 
            AutoComplete="off" Width="430px"></asp:TextBox>
             
               
                
                <cc1:AutoCompleteExtender ID="AutoCompleteExtender3" runat="server"
                    DelimiterCharacters="" Enabled="true" 
                ServicePath="~/Autocomplete.asmx" ServiceMethod="GetEmployeeList"
                    TargetControlID="txtSuperVisorMentor" MinimumPrefixLength="1" CompletionInterval="10"
                    EnableCaching="true" CompletionListCssClass="autocompleteTextBoxLP" 
                     OnClientItemSelected="GetEmpID">
                </cc1:AutoCompleteExtender>
                
                <cc1:TextBoxWatermarkExtender ID="txtSuperVisorMentor_TextBoxWatermarkExtender" 
                      runat="server" Enabled="True" TargetControlID="txtSuperVisorMentor" 
                      WatermarkCssClass="watermark" WatermarkText="Auto Complete">
                </cc1:TextBoxWatermarkExtender>
      </td>
    
        
    
        
    
        
    
    </tr>--%>
    
    
    <tr>
    <td colspan="3" class="txtlbl"> Segment Head:
     <br />
            <asp:TextBox ID="txtEvaluator" runat="server"  CssClass="inputTextBox" 
            AutoComplete="off" Width="430px"></asp:TextBox>
             
               
                
                <cc1:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server"
                    DelimiterCharacters="" Enabled="true" 
                ServicePath="~/Autocomplete.asmx" ServiceMethod="GetEmployeeList"
                    TargetControlID="txtEvaluator" MinimumPrefixLength="1" CompletionInterval="10"
                    EnableCaching="true" CompletionListCssClass="autocompleteTextBoxLP" 
                     OnClientItemSelected="GetEmpID">
                </cc1:AutoCompleteExtender>
                
                <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" 
                      runat="server" Enabled="True" TargetControlID="txtEvaluator" 
                      WatermarkCssClass="watermark" WatermarkText="Auto Complete">
                </cc1:TextBoxWatermarkExtender>
      </td>
    
        
    
        
    
        
    
    </tr>
    
    
    
            <tr>

         <td colspan="2" class="txtlbl">From Date:<span class="errormsg">*</span>
         <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                ControlToValidate="DdlEmployee" Display="Dynamic" ErrorMessage="Required!" 
                SetFocusOnError="True" ValidationGroup="ojt"></asp:RequiredFieldValidator>
         <br />
          
            <asp:TextBox ID="txtFromDate" runat="server" CssClass="inputTextBoxLP"></asp:TextBox>
          
         
            <cc1:CalendarExtender ID="txtFromDate_CalendarExtender" runat="server" 
                Enabled="True" TargetControlID="txtFromDate">
            </cc1:CalendarExtender>
          
         
           
        </td>
      
                <td nowrap  class="txtlbl" > To Date:<span class="errormsg">*</span> 
                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                        ControlToValidate="DdlEmployee" Display="Dynamic" ErrorMessage="Required!" 
                        SetFocusOnError="True" ValidationGroup="ojt">
                </asp:RequiredFieldValidator>
                <asp:CompareValidator ID="CompareValidator1" runat="server" 
                         ControlToCompare="txtFromDate" Operator="GreaterThanEqual"
                     ControlToValidate="txtToDate"  ErrorMessage="From Date must be smaller then To Date" Type="Date">
                 </asp:CompareValidator>
 
              <br />
              <asp:TextBox ID="txtToDate" runat="server" CssClass="inputTextBoxLP">
              </asp:TextBox>
   
             <cc1:CalendarExtender ID="txtToDate_CalendarExtender" runat="server" 
                Enabled="True" TargetControlID="txtToDate">
            </cc1:CalendarExtender>
         
          
            
    
                
        </td>
        
        
    </tr>


  
     

      <tr>
       
         <td colspan="2"  >
            <asp:Button ID="btnSave" runat="server" CssClass="button" 
                 Text="Save" ValidationGroup="ojt" onclick="btnSave_Click" />
                 
            <cc1:ConfirmButtonExtender ID="btnSave_ConfirmButtonExtender" runat="server" 
                    ConfirmText="Confirm to Save?" Enabled="True" TargetControlID="btnSave">
            </cc1:ConfirmButtonExtender>
            
            <asp:Button ID="BtnDelete" runat="server" CssClass="button" 
                 Text="Delete" onclick="BtnDelete_Click" />
            
            <cc1:ConfirmButtonExtender ID="BtnDelete_ConfirmButtonExtender" runat="server" 
                ConfirmText="Are you sure to delete?" Enabled="True" 
                TargetControlID="BtnDelete">
            </cc1:ConfirmButtonExtender>
            
                    <asp:Button ID="BtnBack" runat="server" CssClass="button" 
                    onclick="BtnBack_Click" Text="&lt;&lt; Back" />
         <%--   <asp:Button ID="BtnBack" runat="server" CssClass="button" 
                Text="&lt;&lt; Back" onclick="BtnBack_Click" />--%>
          </td>
      </tr>
</table>
</ContentTemplate>
</asp:UpdatePanel>

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

