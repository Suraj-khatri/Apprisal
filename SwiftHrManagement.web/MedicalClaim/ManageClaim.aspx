<%@ Page Title="" Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true"
    CodeBehind="ManageClaim.aspx.cs" Inherits="SwiftHrManagement.web.MedicalClaim.ManageClaim" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="/js/Swift_grid.js" type="text/javascript"> </script>
    <script src="/js/functions.js" type="text/javascript"> </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    <table width="100%" height="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td valign="top">
                <table width="100%" height="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td valign="top">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td valign="bottom" class="wellcome">
                                        <img src="/images/spacer.gif" width="5" height="1">
                                        <img src="/images/big_bullit.gif">&nbsp;Manage Medical Claim
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="top" bgcolor="#999999" height="1">
                                    </td>
                                </tr>
                            </table>
                            <table width="80%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td valign="top" align="center">
                                        <br>
                                        <!--		Begin content	-->
                                        <!--################ START FORM STYLE-->
                                        <table class="container" border="0" cellpadding="0" cellspacing="0" width="80%">
                                            <tbody>
                                                <tr>
                                                    <td width="1%" class="container_tl">
                                                        <div>
                                                        </div>
                                                    </td>
                                                    <td width="91%" class="container_tmid">
                                                        <div>
                                                            Manage Medical Claim</div>
                                                    </td>
                                                    <td width="8%" class="container_tr">
                                                        <div>
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="container_l">
                                                    </td>
                                                    <td class="container_content">
                                                        <!--################ END FORM STYLE-->
                                                        <table border="0" cellspacing="5" cellpadding="5" class="container" width="80%">
                                                            <tr>
                                                                <td colspan="2">
                                                                    <asp:Label ID="LblMsg" runat="server" CssClass="txtlbl"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td nowrap="nowrap">
                                                                    <div align="right" class="txtlbl">
                                                                        Employee Name :</div>
                                                                </td>
                                                                <td nowrap="nowrap">
                                                                    <asp:Label ID="lblEmpName" runat="server" CssClass="txtlbl"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td nowrap="nowrap">
                                                                    <div align="right" class="txtlbl">
                                                                        Branch :</div>
                                                                </td>
                                                                <td nowrap="nowrap">
                                                                    <asp:Label ID="lblBranch" runat="server" CssClass="txtlbl"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td nowrap="nowrap">
                                                                    <div align="right" class="txtlbl">
                                                                        Department :</div>
                                                                </td>
                                                                <td nowrap="nowrap">
                                                                    <asp:Label ID="lblDept" runat="server" CssClass="txtlbl"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td nowrap="nowrap">
                                                                    <div align="right" class="txtlbl">
                                                                        Position :</div>
                                                                </td>
                                                                <td nowrap="nowrap">
                                                                    <asp:Label ID="lblPosition" runat="server" CssClass="txtlbl"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td nowrap="nowrap">
                                                                    <div align="right" class="txtlbl">
                                                                        Age :</div>
                                                                </td>
                                                                <td nowrap="nowrap">
                                                                    <asp:Label ID="lblAge" runat="server" CssClass="txtlbl"></asp:Label>
                                                                    (In Years)
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td nowrap="nowrap">
                                                                    <div align="right" class="txtlbl">
                                                                        Dependent Name :</div>
                                                                </td>
                                                                <td nowrap="nowrap">
                                                                    <asp:Label ID="lblDependedName" runat="server" CssClass="txtlbl"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td nowrap="nowrap">
                                                                    <div align="right" class="txtlbl">
                                                                        Relation :</div>
                                                                </td>
                                                                <td nowrap="nowrap">
                                                                    <asp:Label ID="lblRelation" runat="server" CssClass="txtlbl"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td nowrap="nowrap">
                                                                    <div align="right" class="txtlbl">
                                                                        Age :</div>
                                                                </td>
                                                                <td nowrap="nowrap">
                                                                    <asp:Label ID="lblDependendAge" runat="server" CssClass="txtlbl"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td nowrap="nowrap">
                                                                    <div align="right" class="txtlbl">
                                                                        Claim Type :</div>
                                                                </td>
                                                                <td nowrap="nowrap">
                                                                    <asp:Label ID="lblClaimType" runat="server" CssClass="txtlbl"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <div id="divHospitalization" runat="server" visible="false">                                                                                                                                                                                            
                                                                <tr>
                                                                    <td nowrap="nowrap">
                                                                        <div align="right" class="txtlbl">
                                                                            Name Of Attending Doctor :</div>
                                                                    </td>
                                                                    <td nowrap="nowrap">
                                                                        <asp:Label ID="txtAccAttendingDoctor" runat="server" CssClass="txtlbl"></asp:Label>
                                                                    </td>
                                                                </tr>

                                                                 <tr>
                                                                    <td nowrap="nowrap">
                                                                        <div align="right" class="txtlbl">
                                                                            Date Of Admission : </div>
                                                                    </td>
                                                                    <td nowrap="nowrap">
                                                                        <asp:Label ID="hosAdmissionDate" runat="server" CssClass="txtlbl"></asp:Label>
                                                                    </td>
                                                                </tr>

                                                                 <tr>
                                                                    <td nowrap="nowrap">
                                                                        <div align="right" class="txtlbl">
                                                                            Diagnosis : </div>
                                                                    </td>
                                                                    <td nowrap="nowrap">
                                                                        <asp:Label ID="hosDiagnosis" runat="server" CssClass="txtlbl"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                            </div>
                                                            <div id="divSickness" runat="server" visible="false">
                                                                <tr>
                                                                    <td nowrap="nowrap">
                                                                        <div align="right" class="txtlbl">
                                                                            Date :</div>
                                                                    </td>
                                                                    <td nowrap="nowrap">
                                                                        <asp:Label ID="txtSickDate" runat="server" CssClass="txtlbl"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td nowrap="nowrap">
                                                                        <div align="right" class="txtlbl">
                                                                            Name Of Attending Doctor :</div>
                                                                    </td>
                                                                    <td nowrap="nowrap">
                                                                        <asp:Label ID="txtSickAttendingDoctor" runat="server" CssClass="txtlbl"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td nowrap="nowrap">
                                                                        <div align="right" class="txtlbl">
                                                                            Name Of Hospital :</div>
                                                                    </td>
                                                                    <td nowrap="nowrap">
                                                                        <asp:Label ID="txtSickHospital" runat="server" CssClass="txtlbl"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td nowrap="nowrap">
                                                                        <div align="right" class="txtlbl">
                                                                            Diagnosis :</div>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="txtSickDiagnosis" runat="server" CssClass="txtlbl"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td nowrap="nowrap">
                                                                        <div align="right" class="txtlbl">
                                                                            From Date :</div>
                                                                    </td>
                                                                    <td nowrap="nowrap">
                                                                        <asp:Label ID="txtLeaveFrom" runat="server" CssClass="txtlbl"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td nowrap="nowrap">
                                                                        <div align="right" class="txtlbl">
                                                                            To Date :</div>
                                                                    </td>
                                                                    <td nowrap="nowrap">
                                                                        <asp:Label ID="txtLeaveTo" runat="server" CssClass="txtlbl"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                            </div>
                                                            <tr>
                                                                <td colspan="2">
                                                                    <div id="rptShow" runat="server">
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="2">
                                                                    <div id="divDoc" runat="server">
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="2">
                                                                    <div id="divRpt" runat="server">
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                            <div id="divlblPRemarks" runat="server" visible="false">
                                                            <tr>
                                                            
                                                                <td nowrap="nowrap">
                                                                    <div align="right" class="txtlbl">
                                                                        Process Remarks :</div>
                                                                </td>
                                                                <td nowrap="nowrap">
                                                                    <asp:Label ID="lblPRemarks" runat="server" CssClass="txtlbl"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            </div>
                                                            <div id="divOnproc" runat="server">
                                                                <tr>
                                                                    <td nowrap="nowrap">
                                                                        <div align="right" class="txtlbl">
                                                                            Process Remarks :</div>
                                                                    </td>
                                                                    <td nowrap="nowrap">
                                                                        <asp:TextBox ID="onProcremarks" runat="server" CssClass="inputTextBoxLP1" Width="300px"
                                                                            Height="45px" TextMode="MultiLine"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                            </div>
                                                            <div id="divApproved" runat="server" visible="false">
                                                                <tr>
                                                                    <td nowrap="nowrap">
                                                                        <div align="right" class="txtlbl">
                                                                            Actual Amount :</div>
                                                                    </td>
                                                                    <td nowrap="nowrap">
                                                                        <asp:TextBox ID="actualAmt" runat="server" CssClass="inputTextBoxLP1"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td nowrap="nowrap">
                                                                        <div align="right" class="txtlbl">
                                                                            Remarks :</div>
                                                                    </td>
                                                                    <td nowrap="nowrap">
                                                                        <asp:TextBox ID="remarks" runat="server" CssClass="inputTextBoxLP1" Width="300px"
                                                                            Height="45px" TextMode="MultiLine"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                            </div>
                                                            <div id="divFile" runat="server">
                                                                <tr>
                                                                    <td colspan="2">
                                                                        <asp:Table ID="tblResult" runat="server" Width="100%">
                                                                        </asp:Table>
                                                                    </td>
                                                                </tr>
                                                            </div>
                                                            <tr>
                                                                <td colspan="2" nowrap="nowrap">
                                                                    <asp:Button ID="btnProcess" runat="server" CssClass="button" OnClick="btnProcess_Click"
                                                                        Text="Process" ValidationGroup="claim" Width="75px" />
                                                                    <cc1:ConfirmButtonExtender ID="BtnSave_ConfirmButtonExtender" runat="server" ConfirmText="Confirm To Process?"
                                                                        Enabled="True" TargetControlID="btnProcess">
                                                                    </cc1:ConfirmButtonExtender>
                                                                    <asp:Button ID="BtnBack" runat="server" CssClass="button" OnClick="BtnBack_Click"
                                                                        Text="&lt;&lt; Back" Width="75px" />&nbsp;
                                                                    <asp:Button ID="btnApprove" runat="server" Text="Reimburse" CssClass="button" OnClick="btnApprove_Click"
                                                                        Visible="false" Width="75px" />&nbsp;
                                                                    <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" ConfirmText="Confirm To Approve?"
                                                                        Enabled="True" TargetControlID="btnApprove">
                                                                    </cc1:ConfirmButtonExtender>
                                                                    <asp:Button ID="btnReject" runat="server" Text="Reject" CssClass="button" OnClick="btnReject_Click"
                                                                        Width="75px" />
                                                                    <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender2" runat="server" ConfirmText="Confirm To Reject?"
                                                                        Enabled="True" TargetControlID="btnReject">
                                                                    </cc1:ConfirmButtonExtender>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                        <!--################ START FORM STYLE-->
                                                    </td>
                                                    <td class="container_r">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="container_bl">
                                                    </td>
                                                    <td class="container_bmid">
                                                    </td>
                                                    <td class="container_br">
                                                    </td>
                                                </tr>
                                            </tbody>
                                        </table>
                                        <!--################ END FORM STYLE-->
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
