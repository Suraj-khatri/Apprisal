<%@ Page Title="" Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="ReportForJobBuddySystem.aspx.cs" Inherits="SwiftHrManagement.web.Report.OnThe_Job_and_Buddy.ReportForJobBuddySystem" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
<asp:UpdatePanel ID="udtpanel" runat="server">
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
						<img src="/images/spacer.gif" width="5" height="1"><img src="/images/big_bullit.gif">&nbsp;&nbsp;On The Job Training/Buddy System Report</td>
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

<!--################ END FORM STYLE-->


   <!--Start Training Report Report-->
        <!--START FORM STYLE-->
        <table class="container" border="0" cellpadding="0" cellspacing="0" width="40%">
        <tbody>
        <tr>
        <td width="1%" class="container_tl"><div></div></td>
        <td width="91%" class="container_tmid"><div>On The Job And Buddy Report</div></td>
        <td width="8%" class="container_tr"><div></div></td>
        </tr>
        <tr>
        <td class="container_l"></td>
        <td class="container_content">

        <!--################ END FORM STYLE-->

        <table border="0" cellspacing="2" cellpadding="2" class="container">  
        <tr>
        <td nowrap="nowrap"><div align="right" class="text_form1">Branch :</div></td>
        <td>
        <asp:DropDownList ID="DdlBranchName" runat="server" CssClass="FltCMBDesign" 
        AutoPostBack="True"  Width="300px" onselectedindexchanged="DdlBranchName_SelectedIndexChanged" 
               ></asp:DropDownList>            
        </td>
        </tr>
        <tr>
        <td nowrap="nowrap"><div align="right" class="text_form1">Department :</div></td>
        <td>
        <asp:DropDownList ID="DdlDeptName" runat="server" CssClass="FltCMBDesign" 
        AutoPostBack="True"  Width="300px" onselectedindexchanged="DdlDeptName_SelectedIndexChanged" 
                ></asp:DropDownList>              
        </td>
        </tr>
        <tr>
        <td nowrap="nowrap"><div align="right" class="text_form1">Employee :</div></td>
        <td>
        <asp:DropDownList ID="DdlEmpName" runat="server" CssClass="FltCMBDesign" Width="300px"></asp:DropDownList>             
        </td>
        </tr>
        <tr>
        <td nowrap><div align="right" class="text_form1">From Date :</div></td>
        <td>
        <asp:TextBox ID="txtFrom" runat="server" CssClass="inputTextBoxLP1"></asp:TextBox>
       <%-- <asp:RequiredFieldValidator 
                    ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtFrom" 
                    Display="Dynamic" ErrorMessage="Required!" ValidationGroup="Training" 
                    SetFocusOnError="True"></asp:RequiredFieldValidator>   --%>          
        <cc1:CalendarExtender ID="txtFrom_CalendarExtender" runat="server" 
        Enabled="True" TargetControlID="txtFrom">
        </cc1:CalendarExtender>
        </td>
        </tr>
        <tr>
        <td><div align="right" class="text_form1">To Date :</div></td>
        <td>
        <asp:TextBox ID="txtTo" runat="server" CssClass="inputTextBoxLP1"></asp:TextBox>
       <%-- <asp:RequiredFieldValidator 
                    ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtTo" 
                    Display="Dynamic" ErrorMessage="Required!" ValidationGroup="Training" 
                    SetFocusOnError="True"></asp:RequiredFieldValidator>  --%>           
        <cc1:CalendarExtender ID="txtTo_CalendarExtender" runat="server" Enabled="True" 
        TargetControlID="txtTo">
        </cc1:CalendarExtender>
        </td>
        </tr>
        <tr>
           <td nowrap="nowrap"><div align="right" class="text_form1">Training Type :</div></td>
           <td>
             <%-- <asp:DropDownList ID="DdlTrainingProgram" runat="server" CssClass="FltCMBDesign" 
                       Width="200px" ></asp:DropDownList> --%>
              <asp:DropDownList ID="DdlTrainingType" runat="server" CssClass="CMBDesign" >
                 <asp:ListItem Value="">Select </asp:ListItem>
                 <asp:ListItem Value="o">OJT</asp:ListItem>
                  <asp:ListItem Value="b">Buddy</asp:ListItem>
              </asp:DropDownList>      
               
           </td>
        </tr>
        
 
        <tr>
        <td><div align="right" class="text_form1"></div></td>
        <td>                
        <asp:Button ID="Btn_ShowReport" runat="server" Text="Search" 
        CssClass="button"  ValidationGroup="Training" onclick="Btn_ShowReport_Click" />
        </td>           
        </tr>
        
         <tr>
              <td colspan="2">
                 <asp:Label ID="LblMsg" runat="server" CssClass="errormsg" Text=""></asp:Label>
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
        <!--End FORM STYLE-->
        <!--End Training Report Report -->



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
