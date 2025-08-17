<%@ Page Title="" Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true"
    CodeBehind="Manage.aspx.cs" Inherits="SwiftHrManagement.web.MedicalClaim.Manage" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="/js/Swift_grid.js" type="text/javascript"> </script>
    <script src="/js/functions.js" type="text/javascript"> </script>
    <script type="text/javascript" language="javascript">

        function IsDelete(id) {
            if (confirm("Confirm Delete?")) {
                document.getElementById("<% =hdnId.ClientID %>").value = id;
                document.getElementById("<% =btnDeleteRecord.ClientID %>").click();
            }
        }
        function IsDeleteDoc(id) {
            if (confirm("Confirm Delete?")) {
                document.getElementById("<% =hdnDocId.ClientID %>").value = id;
                document.getElementById("<% =btnDeleteDocType.ClientID %>").click();
            }
        }
        function IsDeleteDoc(id) {
            if (confirm("Confirm Delete?")) {
                document.getElementById("<% =hdnRptId.ClientID %>").value = id;
                document.getElementById("<% =btnDeleteRptType.ClientID %>").click();
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    <asp:HiddenField ID="hdnId" runat="server" />
    <asp:Button ID="btnDeleteRecord" runat="server" Text="Delete" OnClick="btnDeleteRecord_Click"
        Style="display: none;" />
    <asp:HiddenField ID="hdnDocId" runat="server" />
    <asp:Button ID="btnDeleteDocType" runat="server" Text="Delete" OnClick="btnDeleteDocType_Click"
        Style="display: none;" />
    <asp:HiddenField ID="hdnRptId" runat="server" />
    <asp:Button ID="btnDeleteRptType" runat="server" Text="Delete" OnClick="btnDeleteRptType_Click"
        Style="display: none;" />
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
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <table style="width: 100%" class="tabs">
                                            <tr>
                                                <td height="10">
                                                    <a href="#" class="selected">Medical Claim</a><a href="DependentClaimList.aspx">Dependent
                                                        Claim</a>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                            <table width="80%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td valign="top" align="center">
                                        <br>
                                        <!--		Begin content	-->
                                        <!--################ START FORM STYLE-->
                                        <table class="container" border="0" cellpadding="0" cellspacing="0" width="20%">
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
                                                        <table border="0" cellspacing="2" cellpadding="2" class="container">
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
                                                                        Self /Dependent Name :</div>
                                                                </td>
                                                                <td nowrap="nowrap">
                                                                    <asp:DropDownList ID="ddlDependedName" runat="server" CssClass="CMBDesign" AutoPostBack="True"
                                                                        OnSelectedIndexChanged="ddlDependedName_SelectedIndexChanged">
                                                                    </asp:DropDownList>
                                                                    &nbsp;<span class="required">*</span>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlDependedName"
                                                                        Display="Dynamic" ErrorMessage="Required!" ValidationGroup="claim" SetFocusOnError="True">
                                                                    </asp:RequiredFieldValidator>
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
                                                                    <asp:DropDownList ID="ddlClaimType" runat="server" CssClass="CMBDesign" AutoPostBack="True"
                                                                        OnSelectedIndexChanged="ddlClaimType_SelectedIndexChanged">
                                                                        <asp:ListItem Value="">Select</asp:ListItem>
                                                                        <asp:ListItem Value="Accident">Accident</asp:ListItem>
                                                                        <asp:ListItem Value="Sickness">Sickness</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <div id="divAccident" runat="server" visible="false">
                                                                <tr>
                                                                    <td nowrap="nowrap">
                                                                        <div align="right" class="txtlbl">
                                                                            Date & Time :</div>
                                                                    </td>
                                                                    <td nowrap="nowrap">
                                                                        <asp:TextBox ID="txtAccDateTime" runat="server" CssClass="inputTextBoxLP1" Width="200px"></asp:TextBox>
                                                                        <cc1:CalendarExtender ID="txtFromDate_CalendarExtender" runat="server" Enabled="True"
                                                                            TargetControlID="txtAccDateTime">
                                                                        </cc1:CalendarExtender>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td nowrap="nowrap">
                                                                        <div align="right" class="txtlbl">
                                                                            Place :</div>
                                                                    </td>
                                                                    <td nowrap="nowrap">
                                                                        <asp:TextBox ID="txtAccPlace" runat="server" CssClass="inputTextBoxLP1" Width="200px" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td nowrap="nowrap">
                                                                        <div align="right" class="txtlbl">
                                                                            How did it occur? :</div>
                                                                    </td>
                                                                    <td nowrap="nowrap">
                                                                        <asp:TextBox ID="txtAccOccur" runat="server" CssClass="inputTextBoxLP1" Width="300px"
                                                                            Height="45px" TextMode="MultiLine" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td nowrap="nowrap">
                                                                        <div align="right" class="txtlbl">
                                                                            Details of Injury :</div>
                                                                    </td>
                                                                    <td nowrap="nowrap">
                                                                        <asp:TextBox ID="txtAccInjury" runat="server" CssClass="inputTextBoxLP1" Width="300px"
                                                                            Height="45px" TextMode="MultiLine"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td nowrap="nowrap">
                                                                        <div align="right" class="txtlbl">
                                                                            Name Of Attending Doctor :</div>
                                                                    </td>
                                                                    <td nowrap="nowrap">
                                                                        <asp:TextBox ID="txtAccAttendingDoctor" runat="server" CssClass="inputTextBoxLP1"
                                                                            Width="200px" />
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
                                                                        <asp:TextBox ID="txtSickDate" runat="server" CssClass="inputTextBoxLP1" Width="200px"></asp:TextBox>
                                                                        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True" TargetControlID="txtSickDate">
                                                                        </cc1:CalendarExtender>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td nowrap="nowrap">
                                                                        <div align="right" class="txtlbl">
                                                                            Name Of Attending Doctor :</div>
                                                                    </td>
                                                                    <td nowrap="nowrap">
                                                                        <asp:TextBox ID="txtSickAttendingDoctor" runat="server" CssClass="inputTextBoxLP1"
                                                                            Width="200px" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td nowrap="nowrap">
                                                                        <div align="right" class="txtlbl">
                                                                            Name Of Hospital :</div>
                                                                    </td>
                                                                    <td nowrap="nowrap">
                                                                        <asp:TextBox ID="txtSickHospital" runat="server" CssClass="inputTextBoxLP1" Width="200px" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td nowrap="nowrap">
                                                                        <div align="right" class="txtlbl">
                                                                            Diagnosis :</div>
                                                                    </td>
                                                                    <td nowrap="nowrap">
                                                                        <asp:TextBox ID="txtSickDiagnosis" runat="server" CssClass="inputTextBoxLP1" Width="300px"
                                                                            Height="45px" TextMode="MultiLine" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                    </td>
                                                                    <td nowrap="nowrap" colspan="3">
                                                                        <div align="left" class="txtlbl">
                                                                            Sick Leave if Any
                                                                        </div>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td nowrap="nowrap">
                                                                        <div align="right" class="txtlbl">
                                                                            From Date :</div>
                                                                    </td>
                                                                    <td nowrap="nowrap">
                                                                        <asp:TextBox ID="txtLeaveFrom" runat="server" CssClass="inputTextBoxLP1" Width="150px"></asp:TextBox>
                                                                        <cc1:CalendarExtender ID="txtLeaveFrom_CalendarExtender" runat="server" Enabled="True"
                                                                            TargetControlID="txtLeaveFrom">
                                                                        </cc1:CalendarExtender>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td nowrap="nowrap">
                                                                        <div align="right" class="txtlbl">
                                                                            To Date :</div>
                                                                    </td>
                                                                    <td nowrap="nowrap">
                                                                        <asp:TextBox ID="txtLeaveTo" runat="server" CssClass="inputTextBoxLP1" Width="150px" />
                                                                        <cc1:CalendarExtender ID="txtLeaveToID" runat="server" Enabled="True" TargetControlID="txtLeaveTo">
                                                                        </cc1:CalendarExtender>
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
                                                                        <asp:Label ID="actualAmt" runat="server" CssClass="txtlbl"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td nowrap="nowrap">
                                                                        <div align="right" class="txtlbl">
                                                                            Remarks :</div>
                                                                    </td>
                                                                    <td nowrap="nowrap">
                                                                        <asp:Label ID="remarks" runat="server" CssClass="txtlbl"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                            </div>
                                                            <tr>
                                                                <td>
                                                                </td>
                                                                <td>
                                                                    <table>
                                                                        <tr>
                                                                            <td>
                                                                                Particulars Of Treatment<br />
                                                                                <asp:DropDownList ID="ddlParticulars" runat="server" CssClass="CMBDesign" Width="400px">
                                                                                </asp:DropDownList>
                                                                            </td>
                                                                            <td>
                                                                                Amount
                                                                                <br />
                                                                                <asp:TextBox ID="txtAmount" runat="server" CssClass="inputTextBox"></asp:TextBox>
                                                                            </td>
                                                                            <td valign="bottom">
                                                                                <asp:Button ID="btnAdd" runat="server" Text="Add New" CssClass="button" OnClick="btnAdd_Click"
                                                                                    Width="75px" />
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="3">
                                                                                <div id="rptShow" runat="server">
                                                                                </div>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                Documents of :<br />
                                                                                <asp:DropDownList runat="server" ID="ddlDocumentOf" CssClass="CMBDesign" Width="400px">
                                                                                    <asp:ListItem Value="Prescription">Prescription</asp:ListItem>
                                                                                    <asp:ListItem Value="MedicalBills">Medical Bills</asp:ListItem>
                                                                                </asp:DropDownList>
                                                                            </td>
                                                                            <td>
                                                                                Document Type :<br />
                                                                                <asp:DropDownList ID="ddlDocType" runat="server" CssClass="CMBDesign" Width="150px">
                                                                                    <asp:ListItem Value="Original">Original</asp:ListItem>
                                                                                    <asp:ListItem Value="Photocopy">Photocopy</asp:ListItem>
                                                                                </asp:DropDownList>
                                                                            </td>
                                                                            <td valign="bottom">
                                                                                <asp:Button ID="btnAddDoc" runat="server" Text="Add New" CssClass="button" OnClick="btnAddDoc_Click"
                                                                                    Width="75px" />
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="3">
                                                                                <div id="divDocument" runat="server">
                                                                                </div>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                Details of Reports<br />
                                                                                <asp:TextBox ID="txtReport" runat="server" Width="400px" CssClass="inputTextBoxLP1" />
                                                                            </td>
                                                                            <td>
                                                                                Document Type
                                                                                <br />
                                                                                <asp:DropDownList ID="ddlReportType" runat="server" CssClass="CMBDesign" Width="150px">
                                                                                    <asp:ListItem Value="Original">Original</asp:ListItem>
                                                                                    <asp:ListItem Value="Photocopy">Photocopy</asp:ListItem>
                                                                                </asp:DropDownList>
                                                                            </td>
                                                                            <td valign="bottom">
                                                                                <asp:Button ID="btnAddReport" runat="server" Text="Add New" CssClass="button" OnClick="btnAddReport_Click"
                                                                                    Width="75px" />
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="3">
                                                                                <div id="divReport" runat="server">
                                                                                </div>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    &nbsp;
                                                                </td>
                                                                <td>
                                                                    <asp:Button ID="BtnSave" runat="server" CssClass="button" OnClick="BtnSave_Click"
                                                                        Text="Save" ValidationGroup="claim" Width="75px" />
                                                                    <cc1:ConfirmButtonExtender ID="BtnSave_ConfirmButtonExtender" runat="server" ConfirmText="Confirm To Save?"
                                                                        Enabled="True" TargetControlID="BtnSave">
                                                                    </cc1:ConfirmButtonExtender>
                                                                    <asp:Button ID="BtnDelete" runat="server" CssClass="button" OnClick="BtnDelete_Click"
                                                                        Text="Delete" Width="75px" />
                                                                    <cc1:ConfirmButtonExtender ID="BtnDelete_ConfirmButtonExtender" runat="server" ConfirmText="Confirm To Delete?"
                                                                        Enabled="True" TargetControlID="BtnDelete">
                                                                    </cc1:ConfirmButtonExtender>
                                                                    <asp:Button ID="BtnBack" runat="server" CssClass="button" OnClick="BtnBack_Click"
                                                                        Text="&lt;&lt; Back" Width="75px" />
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
