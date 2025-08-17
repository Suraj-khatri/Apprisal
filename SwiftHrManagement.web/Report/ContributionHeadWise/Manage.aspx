<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/SwiftHRManager.Master"  CodeBehind="Manage.aspx.cs" Inherits="SwiftHrManagement.web.Report.ContributionHeadWise.Manage" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">


<asp:UpdatePanel ID="UpdatePanel1" runat="server" >
<ContentTemplate> 

<table width="100%" height="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td valign="top">
		<table width="60%" height="100%" border="0" cellspacing="0" cellpadding="0">
		  <tr> 
			<td valign="top">
				<table width="100%" height="30" border="0" cellspacing="0" cellpadding="0">
					<tr>
						<td valign="bottom" class="wellcome">
						<img src="/images/spacer.gif" width="5" height="1"><img src="/images/big_bullit.gif"> 
                             Report</td>
					</tr>
					<tr>
						<td valign="top" bgcolor="#999999" height="1"><img src="/images/spacer.gif" width="100%" height="1"></td>
					</tr>
				</table>
				<table width="99%" border="0" cellspacing="0" cellpadding="0">
					<tr>
						<td valign="top" align="center"><br>

						<!--		Begin content	-->
						






 
       
        
 
        
 <table class="container" border="0" cellpadding="0" cellspacing="0" width="40%">
    <tbody>
      <tr>
        <td width="1%" class="container_tl"><div></div></td>
        <td width="91%" class="container_tmid"><div>&nbsp; report</div></td>
        <td width="8%" class="container_tr"><div></div></td>
      </tr>
      <tr>
            <td class="container_l"></td>
            <td class="container_content">
            
    <!--################ END FORM STYLE-->

       <table border="0" cellspacing="2" cellpadding="2" class="container">  
        <tr>
                <td><div align="right" class="text_form1">Fiscal Year :</div></td>
                <td nowrap>
                   <asp:DropDownList ID="DdlFiscalYear" runat="server" CssClass="FltCMBDesign" 
                     Width="250px" ></asp:DropDownList> 
                     
                    <span class="errormsg">*</span>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic" ControlToValidate="DdlFiscalYear" 
                    SetFocusOnError="True" ErrorMessage="Required" ValidationGroup="contribution" ></asp:RequiredFieldValidator>
                
                                
                </td>
           </tr>
   
            <tr>
                <td><div align="right" class="text_form1">Branch :</div></td>
                <td nowrap>
                   <asp:DropDownList ID="DdlBranchType" runat="server" CssClass="FltCMBDesign" 
                        AutoPostBack="True" 
                         Width="250px" 
                        onselectedindexchanged="DdlBranchType_SelectedIndexChanged" ></asp:DropDownList>  
                          
                    <span class="errormsg">*</span>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Display="Dynamic" ControlToValidate="DdlBranchType" 
                    SetFocusOnError="True" ErrorMessage="Required" ValidationGroup="contribution" ></asp:RequiredFieldValidator>
                                  
                </td>
           </tr>
        
                <tr>
                <td><div align="right" class="text_form1">Department :</div></td>
                <td>
                   <asp:DropDownList ID="DdlDepartment" runat="server" CssClass="FltCMBDesign" Width="250px">
                   </asp:DropDownList>  
                     
                          
                </td>
           </tr>
           
               <tr>
                <td><div align="right" class="text_form1">Report :</div></td>
                <td nowrap>
                   <asp:DropDownList ID="ddlReport" runat="server" CssClass="FltCMBDesign" Width="250px">
                   <asp:ListItem Value="">Select</asp:ListItem>
                   <asp:ListItem Value="cit">CIT</asp:ListItem>
                     <asp:ListItem Value="epf">EPF</asp:ListItem>
                       <asp:ListItem Value="tax">TAX</asp:ListItem>
                     </asp:DropDownList>
                       
                    <span class="errormsg">*</span>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" Display="Dynamic" ControlToValidate="ddlReport" 
                    SetFocusOnError="True" ErrorMessage="Required" ValidationGroup="contribution" ></asp:RequiredFieldValidator>            
                </td>
           </tr>
           
               <tr>
            <td class="">&nbsp;</td>
            <td style="text-align: left" class="">
                <asp:Button ID="BtnSearch" runat="server" CssClass="button" Text="Search" 
                    ValidationGroup="contribution" onclick="BtnSearch_Click"/>
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
<!--End of Leave Used Summary Report -->


<!--		End  content	-->						
                    </td>
                </tr>
        </table>			
        </td>
    </tr>
    </table>	
    </td>
    </tr>
 </table>

</ContentTemplate>
</asp:UpdatePanel>

</asp:Content>