<%@ Page Title="" Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="TaxReportForm.aspx.cs" Inherits="SwiftHrManagement.web.Report.PayRollReport.TaxReport.TaxReportForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<style type="text/css">
        .style10
        {
            background-image: url('/Images/container-tl_big.gif');
            width: 1%;
        }
        .style11
        {
            background: url(/Images/container-left.gif) repeat-y;
            width: 1%;
        }
        .style12
        {
            background-image: url('/Images/container-bl.gif');
            width: 1%;
        }
        .style14
        {
            font-style: normal;
            font-variant: normal;
            font-weight: normal;
            font-size: 11px;
            line-height: normal;
            font-family: Arial, Helvetica, sans-serif;
            color: #191919;
            width: 91%;
            padding: 10px;
            background-color: #f3f3f3;
        }
        .style15
        {
            height: 12px;
            width: 100%;
            background: url('/Images/container-bottom.gif') repeat-x 0 0;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
<asp:UpdatePanel ID="UpdatePanel1" runat="server" >
<ContentTemplate> 

<table width="100%" height="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td valign="top">
		<table width="60%" height="50%" border="0" cellspacing="0" cellpadding="0">
		  <tr> 
			<td valign="top">
				<table width="100%" height="30" border="0" cellspacing="0" cellpadding="0">
					<tr>
						<td valign="bottom" class="wellcome">
						<img src="/images/spacer.gif" width="5" height="1"><img src="/images/big_bullit.gif">&nbsp;&nbsp;Tax 
                            Summary Report</td>
					</tr>
					<tr>
						<td valign="top" bgcolor="#999999" height="1"><img src="/images/spacer.gif" width="100%" height="1"></td>
					</tr>
				</table>
				<table width="99%" border="0" cellspacing="0" cellpadding="0">
					<tr>
						<td valign="top" align="center"><br>

						<!--		Begin content	-->
						




<!--Start Leave Assignment Leave Summary Report-->
<!--START FORM STYLE-->
 <table class="container" border="0" cellpadding="0" cellspacing="0" width="50%">
    <tbody>
      <tr>
        <td class="style10"><div></div></td>
      <td width="99%" class="container_tmid"><div>Tax Calculation Report</div></td>
        <td width="8%" class="container_tr"><div></div></td>
      </tr>
      <tr>
            <td class="style11"></td>
            <td class="style14">
            
    <!--################ END FORM STYLE-->

       <table border="0" cellspacing="2" cellpadding="2" > 
              <tr>
                <td><div align="right" class="text_form1">Fiscal Year :</div></td>
                <td>
                <asp:DropDownList ID="DdlYear" runat="server" CssClass="FltCMBDesign">
                    </asp:DropDownList>  
                     <span class="errormsg">*</span><asp:RequiredFieldValidator 
                    ID="RequiredFieldValidator2" runat="server" ControlToValidate="DdlYear" 
                    Display="Dynamic" ErrorMessage="Required!" ValidationGroup="Tax" 
                    SetFocusOnError="True"></asp:RequiredFieldValidator>                       
                    
                    
                    
                </td>
            </tr>
            <tr>
             <td><div align="right" class="text_form1" >Month :</div></td>
             <td>   
                    <span class="errormsg">                                                       
                    <asp:DropDownList ID="DdlMonth" runat="server" CssClass="FltCMBDesign">
                    </asp:DropDownList>
                    <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator4" 
                    runat="server" ControlToValidate="DdlMonth" Display="Dynamic" 
                    ErrorMessage="Required!" ValidationGroup="yearly" SetFocusOnError="True"></asp:RequiredFieldValidator>
                    *</span>--%>  
                                                 
             </td>    
    </tr> 
            <tr>
                <td><div align="right" class="text_form1">Branch :</div></td>
                <td>
                   <asp:DropDownList ID="DdlBranchName" runat="server" CssClass="FltCMBDesign" 
                        AutoPostBack="true"  Width="300px" 
                        onselectedindexchanged="DdlBranchName_SelectedIndexChanged"></asp:DropDownList>            
                </td>
           </tr>
           <tr>
                <td><div align="right" class="text_form1">Department :</div></td>
                <td>
                      <asp:DropDownList ID="DdlDeptName" runat="server" CssClass="FltCMBDesign" 
                          AutoPostBack="True"  Width="300px" 
                          onselectedindexchanged="DdlDeptName_SelectedIndexChanged"></asp:DropDownList>              
                </td>
            </tr>
              <tr>
                <td nowrap><div align="right" class="text_form1">Employee :</div></td>
                <td nowrap>
                      <asp:DropDownList ID="DdlEmpName" runat="server" CssClass="FltCMBDesign" 
                          Width="300px" ></asp:DropDownList>  
                 <%--   <span class="errormsg">*</span><asp:RequiredFieldValidator 
                    ID="RequiredFieldValidator1" runat="server" ControlToValidate="DdlEmpName" 
                    Display="Dynamic" ErrorMessage="Required!" ValidationGroup="Tax" 
                    SetFocusOnError="True"></asp:RequiredFieldValidator>   --%>        
                </td>
           </tr>

            <tr>
                <td><div align="right" class="text_form1">
                    <asp:Label ID="LblMassge" runat="server" Text=""></asp:Label>
                    </div></td>
                <td>                
                    <asp:Button ID="BtnViewSummery" runat="server" Text="Employee Wise" 
                        CssClass="button"  ValidationGroup="Tax" onclick="BtnViewSummery_Click"  />
                        
                   <asp:Button ID="BtnBranch" runat="server" Text="Branch Wise" 
                        CssClass="button" onclick="BtnBranch_Click"   />
                </td>           
            </tr>
        </table>
        
 
        
    <!--################ START FORM STYLE-->
	        </td>
            <td class="container_r"></td>
      </tr>
      <tr>
        <td class="style12"></td>
        <td class="style15"></td>
        <td class="container_br"></td>
      </tr>
   </tbody>
</table>
<!--End FORM STYLE-->
<!--End Leave Assignment Leave Summary Report -->


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
