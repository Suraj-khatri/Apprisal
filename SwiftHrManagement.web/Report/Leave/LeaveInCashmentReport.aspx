<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/SwiftHRManager.Master" CodeBehind="LeaveInCashmentReport.aspx.cs" Inherits="SwiftHrManagement.web.Report.Leave.LeaveInCashmentReport" %>



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
                                        <img src="/images/spacer.gif" width="5" height="1"><img src="/images/big_bullit.gif">&nbsp;&nbsp;Leave 
                                        InCashment Report
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="top" bgcolor="#999999" height="1"><img src="/images/spacer.gif" width="100%" height="1"></td>
                                </tr>
                            </table>
                            <table width="99%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td valign="top" align="center">                                    
                                    <!-- -->
                                        <!--Start Leave Used Summary Report-->
                                        <!--START FORM STYLE-->       

                                        <table class="container" border="0" cellpadding="0" cellspacing="0" width="80%">
                                        <tbody>
                                            <tr>
                                                <td width="1%" class="container_tl"><div></div></td>
                                                <td width="91%" class="container_tmid"><div>Leave InCashment Report</div></td>
                                                <td width="8%" class="container_tr"><div></div></td>
                                            </tr>
                                            <tr>
                                                <td class="container_l"></td>
                                                <td class="container_content">

                                                <!--################ END FORM STYLE-->

                                                    <table border="0" cellspacing="2" cellpadding="2" class="container" >  
                                                        <tr>
                                                            <td><div align="right" class="text_form1">Branch :</div></td>
                                                            <td nowrap="nowrap"><asp:DropDownList ID="DdlBranchType" runat="server" CssClass="FltCMBDesign" 
                                                                AutoPostBack="True" Width="300px" 
                                                                    onselectedindexchanged="DdlBranchType_SelectedIndexChanged"></asp:DropDownList> * 
                                                                <asp:Label ID="lblBranch" runat="server" Text=""></asp:Label>          
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td><div align="right" class="text_form1">Department :</div></td>
                                                            <td nowrap="nowrap"><asp:DropDownList ID="DdlDepartmentType" runat="server" CssClass="FltCMBDesign" 
                                                                AutoPostBack="True" Width="300px" 
                                                                ValidationGroup="inCashReportSummary"
                                                                onselectedindexchanged="DdlDepartmentType_SelectedIndexChanged"></asp:DropDownList>  * 
                                                                <asp:Label ID="lblDept" runat="server" Text=""></asp:Label>             
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td><div align="right" class="text_form1">Employee :</div></td>
                                                            <td nowrap="nowrap"><asp:DropDownList ID="DdlEmployeeType" runat="server" CssClass="FltCMBDesign" 
                                                                Width="300px" ></asp:DropDownList> * 
                                                                <asp:Label ID="lblEmp" runat="server" Text=""></asp:Label>             
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td><div align="right" class="text_form1">Year :</div></td>
                                                            <td nowrap="nowrap"><asp:DropDownList ID="DdlYear" runat="server" CssClass="FltCMBDesign" 
                                                                Width="300px" 
                                                                AutoPostBack="true">
                                                                </asp:DropDownList> * 
                                                                <asp:Label ID="lblYear" runat="server" Text=""></asp:Label>             
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>&nbsp;</td>
                                                            <td norwap="norwap">
                                                                <div align="left">                
                                                                    <asp:Button ID="BtnShowReportType" runat="server" Text="Summary Report" 
                                                                    CssClass="button" onclick="BtnShowReportType_Click"  />
                                                                    &nbsp;
                                                                    <asp:Button ID="BtnDetailReport" runat="server" Text="Detail Report" 
                                                                    CssClass="button" onclick="BtnDetailReport_Click"/>
                                                                    &nbsp;&nbsp;
                                                               </div>
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
                                            <!--################ START FORM STYLE-->
                                            <!--End of Leave Used Summary Report -->
                                            <!--		End  content	-->
                                        </tbody>
                                        </table> 
                                    <!-- -->
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

