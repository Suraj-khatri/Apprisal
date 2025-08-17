<%@ Page Title="" Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="ManageBankDeposit.aspx.cs" Inherits="SwiftHrManagement.web.Report.PayRollReport.HeadWise.ManageBankDeposit" %>

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
                        <td class="wellcome" valign="bottom">
                            <img height="1" src="/images/spacer.gif" width="5"><img 
                                src="/images/big_bullit.gif"> Report</img></img></td>
                    </tr>
                    <tr>
                        <td bgcolor="#999999" height="1" valign="top">
                            <img height="1" src="/images/spacer.gif" width="100%"></img></td>
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
                                    <td>
                                        <div align="right" class="text_form1">Fiscal Year :</div>
                                    </td>
                                    <td nowrap>
                                        <asp:DropDownList ID="DdlFiscalYear" runat="server" CssClass="FltCMBDesign" Width="250px"></asp:DropDownList> 
                                        <span class="errormsg">*</span>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic" ControlToValidate="DdlFiscalYear" 
                                        SetFocusOnError="True" ErrorMessage="Required" ValidationGroup="contribution" ></asp:RequiredFieldValidator>
                                    </td>
                                </tr>

                                <tr>
                                    <td>
                                        <div align="right" class="text_form1">Month :</div>
                                    </td>
                                    <td nowrap>
                                        <asp:DropDownList ID="DdlMonth" runat="server" CssClass="FltCMBDesign" 
                                        Width="250px" ></asp:DropDownList> 
                                        <span class="errormsg">*</span>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Display="Dynamic" ControlToValidate="DdlMonth" 
                                        SetFocusOnError="True" ErrorMessage="Required" ValidationGroup="contribution" ></asp:RequiredFieldValidator>             
                                    </td>
                                </tr>
   
                                <tr>
                                    <td>
                                        <div align="right" class="text_form1">Branch :</div>
                                    </td>
                                    <td nowrap>
                                        <asp:DropDownList ID="DdlBranchType" runat="server" CssClass="FltCMBDesign" AutoPostBack="True" 
                                        Width="250px"></asp:DropDownList>  
                                    </td>
                                </tr>

                                <tr>
                                    <td>
                                        <div align="right" class="text_form1">Bank :</div>
                                    </td>
                                    <td nowrap>
                                        <asp:DropDownList ID="DdlBank" runat="server" CssClass="FltCMBDesign" AutoPostBack="True" Width="250px"></asp:DropDownList>
                                        <span class="errormsg">*</span>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" Display="Dynamic" ControlToValidate="DdlBank" 
                                        SetFocusOnError="True" ErrorMessage="Required" ValidationGroup="contribution" ></asp:RequiredFieldValidator>            
                                    </td>
                                </tr>
           
                                <tr>
                                    <td></td>
                                    <td style="text-align:left">
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
