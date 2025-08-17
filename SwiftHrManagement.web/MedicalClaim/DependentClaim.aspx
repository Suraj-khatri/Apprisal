<%@ Page Title="" Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true"
    CodeBehind="DependentClaim.aspx.cs" Inherits="SwiftHrManagement.web.MedicalClaim.DependentClaim" %>

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
                                        <img src="/images/big_bullit.gif">&nbsp;Manage Dependent Claim
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
                                                    <a href="List.aspx">Medical Claim</a> <a href="#" class="selected">Dependent Claim</a>
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
                                                            Manage Dependent Claim</div>
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
                                                                        Dependent Name :</div>
                                                                </td>
                                                                <td nowrap="nowrap">
                                                                    <asp:DropDownList ID="ddlDependedName" runat="server" CssClass="CMBDesign" AutoPostBack="True"
                                                                        OnSelectedIndexChanged="ddlDependedName_SelectedIndexChanged1">
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
                                                                    <asp:DropDownList ID="ddlClaimType" runat="server" CssClass="CMBDesign" AutoPostBack="true"
                                                                        OnSelectedIndexChanged="ddlClaimType_SelectedIndexChanged1">
                                                                        <asp:ListItem Value="">Select</asp:ListItem>
                                                                        <asp:ListItem Value="Sickness">Sickness</asp:ListItem>
                                                                        <asp:ListItem Value="Hospitalization">Hospitalization</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <div id="divHospitalize" runat="server" visible="false">
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
                                                                <tr>
                                                                    <td nowrap="nowrap">
                                                                        <div align="right" class="txtlbl">
                                                                            Diagnosis :</div>
                                                                    </td>
                                                                    <td nowrap="nowrap">
                                                                        <asp:TextBox ID="hosDiagnosis" runat="server" CssClass="inputTextBoxLP1" Width="300px"
                                                                            Height="45px" TextMode="MultiLine" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td nowrap="nowrap">
                                                                        <div align="right" class="txtlbl">
                                                                            Date of admission:</div>
                                                                    </td>
                                                                    <td nowrap="nowrap">
                                                                        <asp:TextBox ID="hosAdmissionDate" runat="server" CssClass="inputTextBoxLP1" Width="200px"></asp:TextBox>
                                                                        <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Enabled="True" TargetControlID="hosAdmissionDate">
                                                                        </cc1:CalendarExtender>
                                                                    </td>
                                                                </tr>
                                                            </div>
                                                            <div id="divSickness" runat="server" visible="false">
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
                                                                            Diagnosis :</div>
                                                                    </td>
                                                                    <td nowrap="nowrap">
                                                                        <asp:TextBox ID="txtSickDiagnosis" runat="server" CssClass="inputTextBoxLP1" Width="300px"
                                                                            Height="45px" TextMode="MultiLine" />
                                                                    </td>
                                                                </tr>
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
                                                                                <asp:Button ID="btnAdd" runat="server" Text="Add New" CssClass="button" Width="75px"
                                                                                    OnClick="btnAdd_Click" />
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
                                                                                <asp:Button ID="btnAddDoc" runat="server" Text="Add New" CssClass="button" Width="75px"
                                                                                    OnClick="btnAddDoc_Click" />
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
                                                                                <asp:Button ID="btnAddReport" runat="server" Text="Add New" CssClass="button" Width="75px"
                                                                                    OnClick="btnAddReport_Click" />
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
                                                                    <asp:Button ID="BtnSave" runat="server" CssClass="button" Text="Save" ValidationGroup="claim"
                                                                        OnClick="BtnSave_Click" Width="75px" />
                                                                    <cc1:ConfirmButtonExtender ID="BtnSave_ConfirmButtonExtender" runat="server" ConfirmText="Confirm To Save?"
                                                                        Enabled="True" TargetControlID="BtnSave">
                                                                    </cc1:ConfirmButtonExtender>
                                                                    <asp:Button ID="BtnDelete" runat="server" CssClass="button" Text="Delete" Width="75px"
                                                                        OnClick="BtnDelete_Click" />
                                                                    <cc1:ConfirmButtonExtender ID="BtnDelete_ConfirmButtonExtender" runat="server" ConfirmText="Confirm To Delete?"
                                                                        Enabled="True" TargetControlID="BtnDelete">
                                                                    </cc1:ConfirmButtonExtender>
                                                                    <asp:Button ID="BtnBack" runat="server" CssClass="button" Text="&lt;&lt; Back" Width="75px"
                                                                        OnClick="BtnBack_Click" />
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
