<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReportDetail.aspx.cs" Inherits="SwiftHrManagement.web.MedicalClaim.ReportDetail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
         <link href="/Css/style.css" rel="Stylesheet" type="text/css" />
            <script src="/js/functions.js" type="text/javascript"></script>
    </head>
    <body>
        <form id="form1" runat="server">
            <div>
            <!--################ START FORM STYLE-->
                <table class="" border="0" cellpadding="0" cellspacing="0" width="80%">
                    <tbody>
                        <tr>
                            <td class="reportHead"><div><u> Medical Claim Information</u> </div>
                                    <div runat = "server" id= "exportDiv" class = "noprint" style = "padding-top: 10px">
                                        <div style = "float: left; margin-left: 10px; vertical-align: top">
                                            <img alt = "Print" title = "Print" style = "cursor: pointer; width: 14px; height: 14px" onclick = " javascript:PrintWindow(); "  src="/images/printer.png" border="0" />
                                            <img alt = "Export to Excel" title = "Export to Excel" style = "cursor: pointer; width: 14px; height: 14px" onclick = " javascript:downloadInNewWindow('<% =Request.Url.AbsoluteUri + "&mode=download"%>');"  src="../images/excel.gif" border="0" />
                                        </div>
                                    </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                    <!--################ END FORM STYLE-->
                                <table border="0" cellspacing="5" cellpadding="5" class="" width="80%">

                                    <tr>
                                        <td colspan="2"><asp:Label ID="LblMsg" runat="server" CssClass="txtlbl"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td nowrap="nowrap"><div align="right" class="txtlbl">Employee Name :</div></td>
                                        <td nowrap="nowrap"><asp:Label ID="lblEmpName" runat="server" CssClass="txtlbl"></asp:Label> </td>
                                    </tr>
                                    <tr>
                                        <td nowrap="nowrap"><div align="right" class="txtlbl">Branch :</div></td>
                                        <td nowrap="nowrap"><asp:Label ID="lblBranch" runat="server" CssClass="txtlbl"></asp:Label> </td>
                                    </tr>
                                    <tr>
                                        <td nowrap="nowrap"><div align="right" class="txtlbl">Department :</div></td>
                                        <td nowrap="nowrap"><asp:Label ID="lblDept" runat="server" CssClass="txtlbl"></asp:Label> </td>
                                    </tr>
                                    <tr>
                                        <td nowrap="nowrap"><div align="right" class="txtlbl">Position :</div></td>
                                        <td nowrap="nowrap"><asp:Label ID="lblPosition" runat="server" CssClass="txtlbl"></asp:Label> </td>
                                    </tr>
                                    <tr>
                                        <td nowrap="nowrap"><div align="right" class="txtlbl">Age :</div></td>
                                        <td nowrap="nowrap"><asp:Label ID="lblAge" runat="server" CssClass="txtlbl"></asp:Label> (In Years)</td>
                                    </tr>
                                    <tr>
                                        <td nowrap="nowrap"><div align="right" class="txtlbl">Dependent Name :</div></td>
                                        <td nowrap="nowrap">
                                            <asp:Label ID="lblDependedName" runat="server" CssClass="txtlbl"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td nowrap="nowrap"><div align="right" class="txtlbl">Relation :</div></td>
                                        <td nowrap="nowrap"><asp:Label ID="lblRelation" runat="server" CssClass="txtlbl"></asp:Label> </td>
                                    </tr>
                                    <tr>
                                        <td nowrap="nowrap"><div align="right" class="txtlbl">Age :</div></td>
                                        <td nowrap="nowrap"><asp:Label ID="lblDependendAge" runat="server" CssClass="txtlbl"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td nowrap="nowrap"><div align="right" class="txtlbl">Claim Type :</div></td>
                                        <td nowrap="nowrap">
                                            <asp:Label ID="lblClaimType" runat="server" CssClass="txtlbl"></asp:Label>
                                        </td>
                                    </tr>
                                    <div id="divAccident" runat="server" visible="false">
                                        <tr>
                                            <td nowrap="nowrap"><div align="right" class="txtlbl">Date & Time :</div></td>
                                            <td nowrap="nowrap">
                                                <asp:Label ID="txtAccDateTime" runat="server" CssClass="txtlbl"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td nowrap="nowrap"><div align="right" class="txtlbl">Place :</div></td>
                                            <td nowrap="nowrap">
                                                <asp:Label ID="txtAccPlace" runat="server" CssClass="txtlbl"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td nowrap="nowrap"><div align="right" class="txtlbl">How did it occur? :</div></td>
                                            <td>
                                                <asp:Label ID="txtAccOccur" runat="server" CssClass="txtlbl"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td nowrap="nowrap"><div align="right" class="txtlbl">Details of Injury :</div></td>
                                            <td>
                                                <asp:Label ID="txtAccInjury" runat="server" CssClass="txtlbl"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td nowrap="nowrap"><div align="right" class="txtlbl">Name Of Attending Doctor :</div></td>
                                            <td nowrap="nowrap">
                                                <asp:Label ID="txtAccAttendingDoctor" runat="server" CssClass="txtlbl"></asp:Label>
                                            </td>
                                        </tr>
                                    </div>
                                    <div id="divSickness" runat="server" visible="false">
                                        <tr>
                                            <td nowrap="nowrap"><div align="right" class="txtlbl">Date :</div></td>
                                            <td nowrap="nowrap">
                                                <asp:Label ID="txtSickDate" runat="server" CssClass="txtlbl"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td nowrap="nowrap"><div align="right" class="txtlbl">Name Of Attending Doctor :</div></td>
                                            <td nowrap="nowrap">
                                                <asp:Label ID="txtSickAttendingDoctor" runat="server" 
                                                    CssClass="txtlbl"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td nowrap="nowrap"><div align="right" class="txtlbl">Name Of Hospital :</div></td>
                                            <td nowrap="nowrap">
                                                <asp:Label ID="txtSickHospital" runat="server" CssClass="txtlbl"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td nowrap="nowrap"><div align="right" class="txtlbl">Diagnosis :</div></td>
                                            <td>
                                                <asp:Label ID="txtSickDiagnosis" runat="server" CssClass="txtlbl"></asp:Label>

                                            </td>
                                        </tr>
                                        <tr>
                                            <td nowrap="nowrap"><div align="right" class="txtlbl">From Date :</div></td>
                                            <td nowrap="nowrap"><asp:Label ID="txtLeaveFrom" runat="server" 
                                                    CssClass="txtlbl"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td nowrap="nowrap"><div align="right" class="txtlbl">To Date :</div></td>
                                            <td nowrap="nowrap"><asp:Label ID="txtLeaveTo" runat="server" 
                                                    CssClass="txtlbl"></asp:Label>
                                            </td>
                                        </tr>   
                                    </div>
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td> 
                                            <div id="rptShow" runat="server"></div>
                                        </td>                                            
                                    </tr>
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td> 
                                            <div id="divDoc" runat="server"></div>
                                        </td>                                            
                                    </tr>
                                     <tr>
                                        <td>&nbsp;</td>
                                        <td> 
                                            <div id="divRpt" runat="server"></div>
                                        </td>                                            
                                    </tr>
                                    <div id="divApproved" runat="server" visible="false">
                                        <tr>
                                            <td nowrap="nowrap"><div align="right" class="txtlbl">Actual Amount :</div></td>
                                            <td nowrap="nowrap"><asp:TextBox ID="actualAmt" runat="server" CssClass="inputTextBoxLP1"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td nowrap="nowrap"><div align="right" class="txtlbl">Remarks :</div></td>
                                            <td nowrap="nowrap"><asp:TextBox ID="remarks" runat="server" CssClass="inputTextBoxLP1" 
                                            Width="300px" Height="45px" TextMode="MultiLine"></asp:TextBox></td>
                                        </tr>   
                                    </div>
                                    <div id="divFile" runat="server">
                                        <tr>
                                            <td>&nbsp;</td>
                                            <td>
                                                <asp:Table ID="tblResult" runat="server" Width="100%"></asp:Table>
                                            </td>
                                        </tr>
                                    </div>
                                </table>
                    <!--################ START FORM STYLE-->

	                        </td>
                        </tr>
                    </tbody>    
                </table>
            </div>
        </form>
    </body>
</html>
