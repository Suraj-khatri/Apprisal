<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/SwiftHRManager.Master" CodeBehind="Manage.aspx.cs" Inherits="SwiftHrManagement.web.Report.Leave.IdividualHistory.Manage" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">


<asp:UpdatePanel ID="UpdatePanel1" runat="server" >
<ContentTemplate> 

    <table width="80%" height="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td valign="top">
                <table width="60%" height="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr> 
                        <td valign="top">
                            <table width="100%" height="30" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td valign="bottom" class="wellcome">
                                        <img src="/images/spacer.gif" width="5" height="1"><img src="/images/big_bullit.gif">&nbsp;&nbsp;Leave 
                                       Individual History Report
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
                                                <td width="91%" class="container_tmid"><div>Leave Individual History Report</div></td>
                                                <td width="8%" class="container_tr"><div></div></td>
                                            </tr>
                                            <tr>
                                                <td class="container_l"></td>
                                                <td class="container_content">

                                                <!--################ END FORM STYLE-->

                                                    <table border="0" cellspacing="2" cellpadding="2" class="container" >  
                                                        
                                                       
                                                        <tr>
                                                            <td><div align="right" class="text_form1">BS Year :</div></td>
                                                            <td><asp:DropDownList ID="DdlYear" runat="server" CssClass="FltCMBDesign" 
                                                                Width="150px" AutoPostBack="true"></asp:DropDownList> 
                                                              <span class="errormsg"><asp:Label ID="lblyear" runat="server" Text="">
                                                              </asp:Label></span>              
                                                            </td>
                                                        </tr>
                                                        <%--<asp:Panel Visible="true" ID="fromtodate" runat="server">--%>
                                                        <tr>
                                                            <td><div align="right" class="text_form1" >Requested From Date :</div></td>
                                                            <td><asp:TextBox ID="txtReqDateFrom" runat="server" CssClass="inputTextBoxLP1">
                                                            </asp:TextBox>   
                                                                <cc1:CalendarExtender ID="txtReqDateFrom_CalendarExtender" runat="server" 
                                                                    Enabled="True" TargetControlID="txtReqDateFrom">
                                                                </cc1:CalendarExtender>
                                                                </td>
                                                        </tr>  
                                                        <tr>
                                                            <td><div align="right" class="text_form1">To Date :</div></td>
                                                            <td>
                                                                <asp:TextBox ID="txtReqDateTo" runat="server" CssClass="inputTextBoxLP1" >
                                                                </asp:TextBox> 
                                                                <cc1:CalendarExtender ID="ReqDateTo_CalendarExtender" runat="server" 
                                                                    Enabled="True" TargetControlID="txtReqDateTo">
                                                                </cc1:CalendarExtender>
                                                                </td>
                                                        </tr>
                                                        <%--</asp:Panel>  --%>      
                                                        <tr>
                                                            <td><div align="right" class="text_form1"></div></td>
                                                            <td norwap="norwap">                
                                                                <asp:Button ID="BtnShowReportType" runat="server" Text="Report" 
                                                                CssClass="button"  onclick="BtnShowReportType_Click" />
                                                                &nbsp;&nbsp;&nbsp;</td>           
                                                        </tr>
                                                         <tr>
                                                        <td> </td>
                                                        <td>
                                                            &nbsp;</td>
                                                        </tr>

                                                        <tr>
                                                            <td colspan="2">
                                                                &nbsp;</td>
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

