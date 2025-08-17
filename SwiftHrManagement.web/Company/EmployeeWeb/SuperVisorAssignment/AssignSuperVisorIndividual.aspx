<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/ProjectMaster.Master"  CodeBehind="AssignSuperVisorIndividual.aspx.cs" Inherits="SwiftHrManagement.web.Company.EmployeeWeb.SuperVisorAssignment.AssignSuperVisorIndividual" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .LblClass
        {
            font-size:small; font-weight:bold;
        }
        .style1
        {
            height: 50px;
        }
    </style>
    <script type="text/javascript" language="javascript">
    function GetEmpID(sender, e) {
        var customerValueArray = (e._value).split("|");
        document.getElementById("<%=Hdnempid.ClientID%>").Value = customerValueArray[1];
    }

    
    </script>
  <script type="text/javascript">
      var GB_ROOT_DIR = "./greybox/";
    </script>

    <script type="text/javascript" src="greybox/AJS.js"></script>
    <script type="text/javascript" src="greybox/AJS_fx.js"></script>
    <script type="text/javascript" src="greybox/gb_scripts.js"></script>
    <link href="greybox/gb_styles.css" rel="stylesheet" type="text/css" media="all" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    <div style="vertical-align:middle; margin-left:200px;">
    <table width="100%" height="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>

    <td valign="top">
		<table width="100%" height="100%" border="0" cellspacing="0" cellpadding="0">
		  <tr> 
			<td valign="top">
			
				<table width="60%" border="0" cellspacing="0" cellpadding="0">
					<tr>
						<td valign="top" align="center"><br>

						<!--		Begin content	-->

						
<!--################ START FORM STYLE-->
 <table class="container" border="0" cellpadding="0" cellspacing="0" width="40%" align="center">
  <tbody><tr>
    <td width="1%" class="container_tl"><div></div></td>
    <td width="91%" class="container_tmid"><div>Individual SuperVisor Assignment form</div></td>
    <td width="8%" class="container_tr"><div></div></td>
  </tr>
      <tr>
        <td class="container_l"></td>
        <td class="container_content">
        
<!--################ END FORM STYLE-->
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
   <ContentTemplate>
  
            
<table border="0" cellspacing="5" cellpadding="5" class="container" align="center"> 
    <tr>
        <%--<td></td>--%>
        <td colspan="3" ><span class="txtlbl"> Plese enter valid data! </span>
                   <span class="required"> (* Required Fields)</span><br />  
                  <asp:Label ID="lblmsg" runat="server" style="font-weight: 700"></asp:Label>
        </td>
        
        
    </tr>
     
    
      <tr>
        <td  nowrap="nowrap" ><div align="right"><span class="LblClass" > Employee:</span></div></td>
        <td nowrap colspan="2">
           
       
            <asp:Label ID="lblEmpName" runat="server" Text="" class="LblClass"></asp:Label>
              
            
        </td>
    </tr>
    
<tr>
            <td><div align="right" class="txtlbl">SuperVisor:</div></td>
            <td colspan="2">
                    
                    <asp:TextBox ID="txtSuperVisor" runat="server" Width="400px"
                      CssClass="inputTextBox" AutoPostBack="True" AutoComplete="off"></asp:TextBox>
                
                     <cc1:AutoCompleteExtender ID="AutoCompleteExtender3" runat="server"
                        DelimiterCharacters="" Enabled="true" 
                    ServicePath="~/Autocomplete.asmx" ServiceMethod="GetEmployeeList"
                        TargetControlID="txtSuperVisor" MinimumPrefixLength="1" CompletionInterval="10"
                        EnableCaching="true" CompletionListCssClass="autocompleteTextBoxLP" 
                         OnClientItemSelected="GetEmpID">
                    </cc1:AutoCompleteExtender>
                    
                    <cc1:TextBoxWatermarkExtender ID="txtemployee_TextBoxWatermarkExtender" 
                          runat="server" Enabled="True" TargetControlID="txtSuperVisor" 
                          WatermarkCssClass="watermark" WatermarkText="Auto Complete">
                    </cc1:TextBoxWatermarkExtender>
                  
            </td>
        </tr>
  
         <tr>
        <td  nowrap="nowrap" class="style1" ><div align="right"><span class="txtlbl" > SuperVisor Type:</span></div></td>
        <td nowrap class="style1">
           <asp:DropDownList ID="DdlSuperVisorType" runat="server" CssClass="CMBDesign">
               <asp:ListItem>Select</asp:ListItem>
               <asp:ListItem Value="i">Immediate SuperVisor</asp:ListItem>
               <asp:ListItem Value="s">SuperVisor</asp:ListItem>
          </asp:DropDownList>
       
           <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                ControlToValidate="DdlSuperVisorType" Display="Dynamic" ErrorMessage="Required!" 
                SetFocusOnError="True" ValidationGroup="Supervisor"></asp:RequiredFieldValidator>
         </td>
         
             <td class="style1" nowrap>
             <span class="txtlbl" >  Is Active </span><asp:CheckBox ID="ChkActive" runat="server" Checked="true"/></td>
         
      
        
         
       
        
    </tr>

    

      <tr>
         <td></td>
         <td align="right" colspan="2"  >
            <asp:Button ID="btnSave" runat="server" CssClass="button" 
                 Text="Save" ValidationGroup="Supervisor" onclick="btnSave_Click" />
            <cc1:ConfirmButtonExtender runat="server" ConfirmText ="Are u sure to disable" TargetControlID=                 "btnSave" Enabled="true" ID="btnSave_ConfirmButtonExtender" >
            
            </cc1:ConfirmButtonExtender>     
            <input type =button class="button" value ="&lt;&lt;Back"
             onClick="parent.history.back(); return false;" />   
  
            <%--<asp:Button ID="BtnBack" runat="server" CssClass="button" 
                Text="&lt;&lt; Back" onclick="BtnBack_Click"/>--%>
                <asp:HiddenField ID="Hdnempid" runat="server" />
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
</div>


<%-- <script type="text/javascript">

     function SearchEmp() {
             var branchId = document.getElementById("<%=DdlBranch.ClientID%>").value;
             var deptId = document.getElementById("<%=DdlDepartment.ClientID%>").value;
             var empId = document.getElementById("<%=DdlEmployee.ClientID%>").value;
         
             var URL = "../ManageSearch.aspx?BranchId=" + branchId + "&DeptId="+deptId+"&EmpId="+empId;
                 GB_show("", URL,500,850);
   }

    
     
     
 </script>--%>

</asp:Content>
