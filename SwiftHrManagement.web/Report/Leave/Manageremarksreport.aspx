<%@ Page Title="" Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="Manageremarksreport.aspx.cs" Inherits="SwiftHrManagement.web.Report.Leave.Manageremarksreport" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    <table width="100%" height="100%" border="0" cellspacing="0" cellpadding="0" 
        __designer:mapid="1">
        <tr __designer:mapid="2">
            <td valign="top" __designer:mapid="3">
                <table width="60%" height="100%" border="0" cellspacing="0" cellpadding="0" 
            __designer:mapid="4">
                    <tr __designer:mapid="5">
                        <td valign="top" __designer:mapid="6">
                            <table width="100%" height="30" border="0" cellspacing="0" cellpadding="0" 
                    __designer:mapid="7">
                                <tr __designer:mapid="8">
                                    <td valign="bottom" class="wellcome" __designer:mapid="9">
                                        <img src="/images/spacer.gif" width="5" height="1" __designer:mapid="a"><img 
                                src="/images/big_bullit.gif" __designer:mapid="b">&nbsp;&nbsp;Holiday Calander Report</td>
                                </tr>
                                <tr __designer:mapid="c">
                                    <td valign="top" bgcolor="#999999" height="1" __designer:mapid="d">
                                        <img src="/images/spacer.gif" width="100%" height="1" __designer:mapid="e"></td>
                                </tr>
                            </table>
                            <table width="99%" border="0" cellspacing="0" cellpadding="0" 
                    __designer:mapid="f">
                                <tr __designer:mapid="10">
                                    <td valign="top" align="center" __designer:mapid="11">

						<!--		Begin content	-->
						

<!--Start Leave Type Approval Summary Report-->						
<!--START FORM STYLE-->
                                        <table class="container" border="0" cellpadding="0" cellspacing="0" width="40%" __designer:mapid="16">
                                            <tbody __designer:mapid="17">
                                                <tr __designer:mapid="18">
                                                    <td width="1%" class="container_tl" __designer:mapid="19">
                                                        <div __designer:mapid="1a">
                                                        </div>
                                                    </td>
                                                    <td width="91%" class="container_tmid" __designer:mapid="1b">
                                                        <div __designer:mapid="1c">
                                                            Holiday calander report</div>
                                                    </td>
                                                    <td width="8%" class="container_tr" __designer:mapid="1d">
                                                        <div __designer:mapid="1e">
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr __designer:mapid="1f">
                                                    <td class="container_l" __designer:mapid="20">
                                                    </td>
                                                    <td class="container_content" __designer:mapid="21">
        
<!--################ END FORM STYLE-->

                                                        <table border="0" cellspacing="2" cellpadding="2" class="container" 
                __designer:mapid="23">
                                                            <tr __designer:mapid="24">
                                                                <td __designer:mapid="25">
                                                                    <div align="right" class="text_form1" 
                    __designer:mapid="26">
                                                                        From Date :</div>
                                                                </td>
                                                                <td width="300px" __designer:mapid="27">
                                                                    <asp:TextBox ID="TxtFromDate" runat="server" CssClass="inputTextBoxLP1"></asp:TextBox>
                                                                    <cc1:CalendarExtender ID="TxtFromDate_CalendarExtender" runat="server" 
                    Enabled="True" TargetControlID="TxtFromDate">
                                                                    </cc1:CalendarExtender>
                                                                </td>
                                                            </tr>
                                                            <tr __designer:mapid="2a">
                                                                <td __designer:mapid="2b">
                                                                    <div align="right" class="text_form1" 
                    __designer:mapid="2c">
                                                                        To Date :</div>
                                                                </td>
                                                                <td width="300px" __designer:mapid="2d">
                                                                    <asp:TextBox ID="TxtToDate" runat="server" CssClass="inputTextBoxLP1"></asp:TextBox>
                                                                    <cc1:CalendarExtender ID="TxtToDate_CalendarExtender" runat="server" 
                    Enabled="True" TargetControlID="TxtToDate">
                                                                    </cc1:CalendarExtender>
                                                                </td>
                                                            </tr>
                                                            <tr __designer:mapid="30">
                                                                <td __designer:mapid="31">
                                                                    <div align="right" class="text_form1" 
                     __designer:mapid="32">
                                                                    </div>
                                                                </td>
                                                                <td __designer:mapid="33">
                                                                    <asp:Button ID="BtnReport" runat="server" onclick="BtnReport_Click" 
                    Text="Show Report" CssClass="button" />
                                                                </td>
                                                            </tr>
                                                        </table>
<!--################ START FORM STYLE-->
	                                                </td>
                                                    <td class="container_r" __designer:mapid="36">
                                                    </td>
                                                </tr>
                                                <tr __designer:mapid="37">
                                                    <td class="container_bl" __designer:mapid="38">
                                                    </td>
                                                    <td class="container_bmid" __designer:mapid="39">
                                                    </td>
                                                    <td class="container_br" __designer:mapid="3a">
                                                    </td>
                                                </tr>
                                            </tbody>
                                        </table>
<!--END FORM STYLE-->
<!--End Leave Type Approval Summary Report-->	



<!--Start Leave Assignment Leave Summary Report-->
<!--START FORM STYLE-->
<!--End FORM STYLE-->
<!--End Leave Assignment Leave Summary Report -->



<!--Start Leave Used Summary Report-->
<!--START FORM STYLE-->

 
       
        
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
</asp:Content>
