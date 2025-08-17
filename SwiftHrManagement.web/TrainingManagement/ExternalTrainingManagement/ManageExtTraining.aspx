<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/SwiftHRManager.Master"  CodeBehind="ManageExtTraining.aspx.cs" Inherits="SwiftHrManagement.web.TrainingManagement.ExternalTrainingManagement.ManageExtTraining" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style10
        {
            font-weight: bold;
            color: #333333;
            width: 280px;
        }
        .style11
        {
            width: 280px;
        }
        </style>
    
     
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">

    <script src="../../Jsfunc.js" type="text/javascript"></script>

<script language="javascript">
    function AutocompleteOnSelected(sender, e) {
        var CustodianValueArray = (e._value).split("|");
        var HiddenFieldEmpID = document.getElementById("<%=HiddenFieldEmpID.ClientID %>");

        HiddenFieldEmpID.value = CustodianValueArray[1];
        //alert(HiddenFieldEmpID.value);
    } 
    
        function GetId() {            
            var notificationList = document.getElementById("notificationList");
            var ids = notificationList.contentWindow.GetIdListForNotification();
            //alert(ids);
            var HiddenFieldempEmail = document.getElementById("<%=HiddenFieldEmpEmail.ClientID %>");
            HiddenFieldempEmail.value = ids;
            return false;
        }
       
    
    </script>
    <%--<script language="javascript">
        function CheckDate() {
            var startDate = document.getElementById("<%=txtStartDate.ClientID%>").value;
            var endDate = document.getElementById("<%=txtEndDate.ClientID%>").value;
            var nominateDate = document.getElementById("<%=txtNominateWithin.ClientID%>").value;

            if (startDate > endDate) {
                alert("Start Date must be smaller then end date");

            }
            else if (endDate < startDate) {
                alert("End date must be Greater then start date");
            }
            else if (nominateDate < startDate) {
                alert("nominate date must be smaller then start date");
            }




        }
    
    
    </script>--%>
    <style type="text/css">
        #notificationList
        {
            width: 423px;
        }
    </style>

    
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
 <table class="container" border="0" cellpadding="0" cellspacing="0" width="40%" align="center">
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
                <br />
    <asp:HiddenField ID="HiddenFieldEmpID" runat="server" />
                <asp:HiddenField ID="HiddenFieldEmpEmail" runat="server" />
                <br />
            </td>     
        </tr>
   
          

        
        <tr>
       <td colspan="3">
    
 <fieldset style="list-style:circle; list-style-type:circle;"><legend>Training Information:</legend>
     <asp:UpdatePanel ID="UpdatePanel1" runat="server">
     <ContentTemplate>
     
        
<table border="0" cellpadding="5" cellspacing="5" width="98%">
<tr>


           <td class="style10">
               Conducted By<span class="errormsg">*</span><asp:RequiredFieldValidator ID="RequiredFieldValidator1" 
                    runat="server" ControlToValidate="txtConductedBy" Display="dynamic" 
                    ErrorMessage="Required" ValidationGroup="externalTraning" 
                    SetFocusOnError="True"></asp:RequiredFieldValidator><br />
                <asp:TextBox ID="txtConductedBy" runat="server"
                    CssClass="inputTextBoxLP"></asp:TextBox>    
            </td>
             <td class="txtlbl">
                 Program Name<span class="errormsg">*</span><asp:RequiredFieldValidator ID="RequiredFieldValidator2" 
                     runat="server" ControlToValidate="TxtProgramName" Display="dynamic" 
                     ErrorMessage="Required" ValidationGroup="externalTraning" 
                     SetFocusOnError="True"></asp:RequiredFieldValidator><br />
                <asp:TextBox ID="TxtProgramName" runat="server"
                    CssClass="inputTextBoxLP"></asp:TextBox>          
            </td>
                   <td class="txtlbl">
                        Estimated Cost  <span class="errormsg">* </span><asp:RequiredFieldValidator ID="RequiredFieldValidator3" 
                     runat="server" ControlToValidate="TxtCostEstimate" Display="dynamic" 
                     ErrorMessage="Required" ValidationGroup="externalTraning" 
                     SetFocusOnError="True"></asp:RequiredFieldValidator><br />
                <asp:TextBox ID="TxtCostEstimate" runat="server"
                    CssClass="inputTextBoxLP"></asp:TextBox>          
            </td>
            
            
        </tr>
           <tr>
           <td class="style10">
               Start Date<span class="errormsg">*</span><asp:RequiredFieldValidator ID="RequiredFieldValidator4" 
                    runat="server" ControlToValidate="txtStartDate" Display="dynamic" 
                    ErrorMessage="Required" ValidationGroup="externalTraning" 
                    SetFocusOnError="True"></asp:RequiredFieldValidator><br />
                <asp:TextBox ID="txtStartDate" runat="server"
                    CssClass="inputTextBoxLP"></asp:TextBox>    
           
               <cc1:CalendarExtender ID="StartDate_CalendarExtender" runat="server" 
                   Enabled="True" TargetControlID="txtStartDate">
               </cc1:CalendarExtender>
           
            </td>
             <td class="txtlbl">
                 End Date<span class="errormsg">*</span><asp:RequiredFieldValidator ID="RequiredFieldValidator5" 
                     runat="server" ControlToValidate="txtEndDate" Display="dynamic" 
                     ErrorMessage="Required" ValidationGroup="externalTraning" 
                     SetFocusOnError="True"></asp:RequiredFieldValidator><asp:CompareValidator ID="CompareValidator1" ControlToValidate="txtEndDate" 
                ControlToCompare="txtStartDate" runat="server" 
                ErrorMessage="End Date Must be greater than start Date" Display="Dynamic" 
                Enabled="true" Operator="GreaterThan" Type="Date">
                </asp:CompareValidator><br />
                <asp:TextBox ID="txtEndDate" runat="server" 
                    CssClass="inputTextBoxLP" ontextchanged="txtEndDate_TextChanged" AutoPostBack="true"></asp:TextBox>          
                 
           
                 <cc1:CalendarExtender ID="EndDate_CalendarExtender" runat="server" 
                     Enabled="True" TargetControlID="txtEndDate">
                 </cc1:CalendarExtender>
           
            </td>   
            
                <td class="txtlbl">
                 Nominate Within
                 <span class="errormsg">*</span><asp:RequiredFieldValidator ID="RequiredFieldValidator11" 
                     runat="server" ControlToValidate="txtNominateWithin" Display="dynamic" 
                     ErrorMessage="Required" ValidationGroup="externalTraning" 
                     SetFocusOnError="True"></asp:RequiredFieldValidator><asp:CompareValidator ID="CompareValidator2" ControlToValidate="txtNominateWithin" 
                ControlToCompare="txtStartDate" runat="server" 
                ErrorMessage="Nominate Date Must be smaller than start Date" Display="Dynamic" 
                Enabled="true" Operator="LessThan" Type="Date">
                </asp:CompareValidator><br />
                <asp:TextBox ID="txtNominateWithin" runat="server"
                    CssClass="inputTextBoxLP"></asp:TextBox>          
           
                 
           
                   <cc1:CalendarExtender ID="txtNominateWithin_CalendarExtender" runat="server" 
                       Enabled="True" TargetControlID="txtNominateWithin">
                   </cc1:CalendarExtender>
           
            </td>          
        </tr>
          <tr>
           <td class="style10">
               No. Of Days<br />
                <asp:TextBox ID="txtNoOfDays" runat="server"
                    CssClass="inputTextBoxLP"></asp:TextBox>    
            </td>
             <td class="txtlbl">
                 No. of Hours/Day<br />
                <asp:TextBox ID="txtNoOfHOurs" runat="server"
                    CssClass="inputTextBoxLP"></asp:TextBox>          
            </td>
                   <td class="txtlbl">
                       Total Capacity<br />
                <asp:TextBox ID="txtTotalCapacity" runat="server"
                    CssClass="inputTextBoxLP"></asp:TextBox>          
            </td>
            
        </tr>
        <tr>
           <td class="style10">
               Country<span class="errormsg">*</span><asp:RequiredFieldValidator ID="RequiredFieldValidator6" 
                    runat="server" ControlToValidate="txtCountry" Display="dynamic" 
                    ErrorMessage="Required" ValidationGroup="externalTraning" 
                    SetFocusOnError="True"></asp:RequiredFieldValidator><br />
               <asp:TextBox ID="txtCountry" runat="server"
                    CssClass="inputTextBoxLP"></asp:TextBox>     
            </td>
             <td class="txtlbl">
                 City<span class="errormsg">*</span><asp:RequiredFieldValidator ID="RequiredFieldValidator7" 
                    runat="server" ControlToValidate="txtCity" Display="dynamic" 
                    ErrorMessage="Required" ValidationGroup="externalTraning" 
                    SetFocusOnError="True"></asp:RequiredFieldValidator><br />
                 <asp:TextBox ID="txtCity" runat="server"
                    CssClass="inputTextBoxLP"></asp:TextBox>         
            </td>
                   <td class="txtlbl">
                       Venue<span class="errormsg">*</span><asp:RequiredFieldValidator ID="RequiredFieldValidator8" 
                    runat="server" ControlToValidate="txtVenue" Display="dynamic" 
                    ErrorMessage="Required" ValidationGroup="externalTraning" 
                    SetFocusOnError="True"></asp:RequiredFieldValidator><br />
                <asp:TextBox ID="txtVenue" runat="server"
                    CssClass="inputTextBoxLP"></asp:TextBox>          
            </td>
            </tr>
          <tr>
            <td colspan="3">
                        Program Description  <span class="errormsg">*</span>
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator9" 
                    runat="server" ControlToValidate="txtVenue" Display="dynamic" 
                    ErrorMessage="Required" ValidationGroup="externalTraning" 
                    SetFocusOnError="True"></asp:RequiredFieldValidator>
                    <br />
                <asp:TextBox ID="txtProgramDesc" runat="server" TextMode="MultiLine"
                    CssClass="inputTextBoxLP" Width="650px" Height="55px" EnableViewState="False"></asp:TextBox>          
            </td>
        </tr>
       
    
 </table>

            <fieldset style="list-style:circle; list-style-type:circle;"><legend>Requested To:</legend>
            <table>
            <tr>
            <td>Recommended To<br />
                <asp:TextBox ID="txtEmpId" runat="server" CssClass="inputTextBoxLP" 
                Width="600px" AutoComplete="Off" ontextchanged="txtEmpId_TextChanged" ></asp:TextBox>
                <asp:Button ID="btnAddRec" runat="server" Text="ADD" class="button" onclick="btnAddRec_Click" 
                    />
                <cc1:TextBoxWatermarkExtender ID="txtEmpId_TextBoxWatermarkExtender" 
                    runat="server" Enabled="True" TargetControlID="txtEmpId"
                    WatermarkCssClass="watermark" WatermarkText="Auto Complete">
                </cc1:TextBoxWatermarkExtender>
                  
                <cc1:AutoCompleteExtender ID="txtEmpId_AutoCompleteExtender" runat="server" 
                    DelimiterCharacters="" Enabled="True" ServicePath="~/Autocomplete.asmx" ServiceMethod="GetApprovedBy" TargetControlID="txtEmpId"
                    MinimumPrefixLength="1" CompletionInterval="10"
                    EnableCaching="true" CompletionListCssClass="autocompleteTextBoxLP" OnClientItemSelected="AutocompleteOnSelected">
                </cc1:AutoCompleteExtender>
                
                
                <br />
               
                </td>
            </tr>
            <tr>
                <td class="style13">
                    <asp:Label ID="lblRecMsg" runat="server" Text=""></asp:Label>
                    <div align=center id="TraineeRecommender" runat="server">
                    </div>
                    <div align="left" id="Div1">
                    <asp:Button ID="BtnDeleteReco" runat="server" CssClass="button" Text="Delete" 
                       onclick="BtnDeleteReco_Click"/>

                    </div>
                </td>
            </tr>            
            <tr>
            
                <td>&nbsp;
            <br />Approved By<span class="errormsg">*</span><asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" 
                        ErrorMessage="Required" ControlToValidate="DDLApprovedBy"  Display="dynamic" 
                        ValidationGroup="externalTraning" SetFocusOnError="True"></asp:RequiredFieldValidator><br />
                    <asp:DropDownList ID="DDLApprovedBy" runat="server" 
                        onselectedindexchanged="DDLApprovedBy_SelectedIndexChanged" CssClass="CMBDesign">
                    </asp:DropDownList>
                   
                </td>
            </tr>
            </table>
  
            </fieldset>
  
  
 </ContentTemplate>
     </asp:UpdatePanel>
 <br />
            <div id="showcc" runat="server">
            <fieldset style="list-style:circle; list-style-type:circle;"><legend>CC:</legend>
            <table>
                <tr>
                    <td>
                  

                            <iframe id = "notificationList"  src = "../../cc/cc.aspx" height = "200px" width="100%"
                                frameborder="0" scrolling="auto"></iframe>
                       
               
                    
                    </td>
                </tr>
            </table>
            
            </fieldset>
            </div>  
 </fieldset>
 </td>
 </tr>
      
       
       

    <tr>
    <td colspan="3">
    
 <fieldset style="list-style:circle; list-style-type:circle;"><legend>Document Information:Panel>
   
 </fieldset>
 </td>
 </tr>
      
       
       

    <tr>
    <td colspan="3">
    
 <fieldset style="list-style:circle; list-style-type:circle;"><legend>Document Information:</legend>
   
        
<table border="0" cellpadding="0" cellspacing="0" width="98%">
<div id="trainingUpload" runat="server" visible="true">
<tr>


<td>

<asp:Label ID="lblMessage" runat="server"></asp:Label>
</td>

</tr>

<tr>
<td nowrap>File Description <span class="errormsg">*</span>

<asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtFileDesc" Display="Dynamic"
ErrorMessage="Required" SetFocusOnError="True" ValidationGroup="upload"></asp:RequiredFieldValidator>


<br />
    <asp:TextBox ID="txtFileDesc" runat="server" CssClass="inputTextBox" Width="200px"></asp:TextBox>
</td>
<td nowrap colspan="">File<br />

<input id="fileUpload" runat="server" name="fileUpload" type="file" class="inputTextBoxLP"/>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;<asp:Button ID="BtnUpload" runat="server" CssClass="button"
Text="Upload" onclick="BtnUpload_Click" ValidationGroup="upload" />


<asp:Button ID="DelateUpload" runat="server" CssClass="button"
Text="Delete" Width="45" onclick="DelateUpload_Click" />


</td>
</tr>
</div>



<tr>
<td colspan="5">

<asp:Table ID="tblResult" runat="server" Width="100%"></asp:Table>

</td>
</tr>


</table>



</fieldset>
    
    
    </td>
    
    
    </tr>





    
        <tr>
            <td class="style11">
                <asp:Button ID="Btn_Save" runat="server" CssClass="button" 
                    onclick="Btn_Save_Click" Text="Save" ValidationGroup="externalTraning" />
                    
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

