<%@ Page Title="" Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true"
    CodeBehind="ViewAppraisal.aspx.cs" Inherits="SwiftHrManagement.web.Report.AppraisalSummary.ViewAppraisal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    <style type="text/css">
        @media print
        {
            .no-print, .no-print *
            {
                display: none !important;
            }
        }
        
        @font-face
        {
            font-family: 'Futura LT Book';
            src: url('../../Css/fonts/ufonts.com_futura_lt_book_1_.eot');
            src: url('../../Css/fonts/ufonts.com_futura_lt_book_1_.eot?#iefix') format('embedded-opentype'), url('../../Css/fonts/ufonts.com_futura-lt-book.woff') format('woff'), url('../../Css/fonts/ufonts.com_futura-lt-book.ttf') format('truetype');
            font-weight: normal;
            font-style: normal;
        }
        .nabilfont
        {
            font-family: 'Futura LT Book' !important;
        }
        .nabilfont tr td, .nabilfont tr th
        {
            font-family: 'Futura LT Book' !important;
        }
    </style>
    <asp:HiddenField ID="HiddenField2" runat="server" />
    <asp:HiddenField ID="HiddenField1" runat="server" />
    <table border="0" class="appraisalFormatText nabilfont" cellspacing="3" width="100%"
        height="30" cellpadding="0" align="center">
        <tr>
            <td>
                <div align="center">
                    <strong><font size="+1">
                        <asp:Label ID="lblHeading" Text="myHeading" runat="server"></asp:Label><br />
                    </font></strong><font size="-1"><strong>
                        <asp:Label ID="lbldesc" Text="test it " runat="server"></asp:Label><br />
                        <asp:Label ID="lblTopic" runat="server"></asp:Label></strong> </font>
                </div>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td width="100%">
                <h3>
                    Employee Information</h3>
                <table border="0" cellpadding="2" cellspacing="2" width="100%">
                    <tr>
                        <td align="left">
                            <div class="label" style="text-align: left">
                                <strong>Employee Name :</strong>
                                <asp:Label ID="lblEmpName" runat="server" CssClass="txtlbl" Style="text-align: left"></asp:Label></div>
                        </td>
                        <td align="right">
                            <div class="label" style="text-align: left">
                                <strong>Branch :</strong>
                                <asp:Label ID="lblBranch" runat="server" CssClass="txtlbl" Style="text-align: left"></asp:Label></div>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <div class="label" style="text-align: left">
                                <strong>Designation :</strong>
                                <asp:Label ID="lblDesignation" runat="server" CssClass="txtlbl" Style="text-align: left"></asp:Label></div>
                        </td>
                        <td align="right">
                            <div class="label" style="text-align: left">
                                <strong>Functional Title :</strong>
                                <asp:Label ID="lblTitle" runat="server" CssClass="txtlbl" Style="text-align: left"></asp:Label></div>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <div class="label" style="text-align: left">
                                <strong>Department :</strong>
                                <asp:Label ID="lblDept" runat="server" CssClass="txtlbl" Style="text-align: left"></asp:Label></div>
                        </td>
                        <td align="right">
                            <div class="label" style="text-align: left">
                                <strong>Total Period in Bank(In Days) :</strong>
                                <asp:Label ID="lblTotalPeriod" runat="server" CssClass="txtlbl" Style="text-align: left"></asp:Label></div>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <div class="label" style="text-align: left">
                                <strong>Appraisal From :</strong>
                                <asp:Label ID="lblAppraisalFrom" runat="server" CssClass="txtlbl" Style="text-align: left"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;
                                <strong>Appraisal To :</strong>
                                <asp:Label ID="lblAppraisalTo" runat="server" CssClass="txtlbl" Style="text-align: left"></asp:Label></div>
                        </td>
                        <td align="right">
                            <div class="label" style="text-align: left">
                                <strong>Date of previous Appraisal(if any) :</strong>
                                <asp:Label ID="lblPreviousAppraisal" runat="server" CssClass="txtlbl" Style="text-align: left"></asp:Label></div>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td width="100%">
                <h3>
                    Section 1</h3>
                <table border="0" cellpadding="2" class="TBL2" cellspacing="0" width="100%">
                    <tr>
                        <td>
                            <b>Target/Duties and Responsibilities</b>
                        </td>
                        <td>
                            <b>Achievement</b>
                        </td>
                        <td>
                            <b>Comments on Target/Duties and Responsibilities</b>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div id="txtTaskDefinition" runat="server">
                            </div>
                        </td>
                        <td>
                            <div id="txtOtherAchievements" runat="server">
                            </div>
                        </td>
                        <td>
                            <div id="txtCommentsOnDuties" runat="server">
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
        </tr>
        <tr>
            <td>
                <h3>
                    Section 2</h3>
                <table border="0" cellpadding="2" cellspacing="2" width="100%">
                    <tr>
                        <td>
                            <div id="setSection2" runat="server">
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
        </tr>
        <tr>
            <td>
                <h3>
                    Strenghts/Improvements/Potential Area</h3>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <div id="setSection3" runat="server">
                </div>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <h3>
                    Recommendations for Actions</h3>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <div id="setSection4" runat="server">
                </div>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <h3>
                    Overall Rating (By Reviewer)</h3>
                <table border="0" cellpadding="2" cellspacing="2" width="100%">
                    <tr>
                        <td class="style3">
                            <%--style="font-weight: bold"--%>
                            <asp:RadioButtonList ID="radioChk" runat="server" RepeatDirection="Horizontal" Enabled="false"
                                Height="39px" Width="603px">
                                <asp:ListItem id="option1" runat="server" Value="Unsatisfactory" />
                                <asp:ListItem id="option2" runat="server" Value="Satisfactory" />
                                <asp:ListItem id="option3" runat="server" Value="Good" />
                                <asp:ListItem id="option4" runat="server" Value="Very Good" />
                                <asp:ListItem id="option5" runat="server" Value="Excellent" />
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" class="style3">
                            <strong>Reviewer's Comment</strong>
                            <br />
                            <div id="reviewrsComment" runat="server" style="border: solid 1px; font-weight: bold">
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
        </tr>
        <tr>
            <td>
                <h3>
                    Other Information</h3>
                <table border="0" cellpadding="2" cellspacing="2" width="100%">
                    <tr>
                        <td>
                            <div id="section6" runat="server">
                            </div>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <h3>
                    Appraisee's Comments</h3>
                <table border="0" cellpadding="2" cellspacing="2" width="100%">
                    <tr>
                        <td align="left">
                            <asp:RadioButtonList ID="rdoResponse" runat="server" Enabled="false">
                                <asp:ListItem Value="Agree"><strong>I agree with the assesment made by the supervisor and the reviewer</strong></asp:ListItem>
                                <asp:ListItem Value="DisAgree"><strong>I  do not agree with the assesment made by the supervisor and the reviewer</strong></asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top">
                            <strong>Comments of the Employee (if any)</strong>
                            <br />
                            <div id="divComments" runat="server" style="border: solid 1px; font-weight: bold">
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
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td width="100%">
                <table border="0" cellpadding="2" cellspacing="2" width="100%">
                    <tr>
                        <td width="400px">
                            <strong>Appraisee :</strong><asp:Label ID="lblAppraisee" runat="server" CssClass="txtlbl"></asp:Label>
                        </td>
                        <td>
                            <strong>Date : </strong>
                            <asp:Label ID="lblADate" runat="server" CssClass="txtlbl"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td width="400px">
                            <strong>Appraiser :</strong><asp:Label ID="lblAppraiser" runat="server" CssClass="txtlbl"></asp:Label>
                        </td>
                        <td>
                            <strong>Date : </strong>
                            <asp:Label ID="lblSDate" runat="server" CssClass="txtlbl"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td width="400px">
                            <strong>Reviewer :</strong>
                            <asp:Label ID="lblReviewer" runat="server" CssClass="txtlbl"></asp:Label>
                        </td>
                        <td>
                            <strong>Date : </strong>
                            <asp:Label ID="lblRDate" runat="server" CssClass="txtlbl"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td width="100%">
                <h3>
                    Review of Appraisal (to be completed by Review Committee)</h3>
                <table border="0" cellpadding="2" cellspacing="2" width="100%">
                    <tr>
                        <td>
                            <div id="setSection8" runat="server">
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
        </tr>
        <tr>
            <td class="style3">
                 <asp:Label ID="Label2" runat="server" Text=" Overall Performance Rating by Review Committee" style="font-weight: bold !important;"></asp:Label><br />
                <asp:RadioButtonList ID="reviewCommitteeChk" runat="server" RepeatDirection="Horizontal"
                    Enabled="false" Height="39px" Width="603px">
                    <asp:ListItem id="a1" runat="server" Value="Substandard" />
                    <asp:ListItem id="a2" runat="server" Value="Acceptable" />
                    <asp:ListItem id="a3" runat="server" Value="Good" />
                    <asp:ListItem id="a4" runat="server" Value="Very Good" />
                    <asp:ListItem id="a5" runat="server" Value="Excellent" />
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td>
                <strong>Review Committee Members Comment On Appraisal</strong>
            </td>
        </tr>
        >
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <div id="setReviewCommittee" runat="server">
                </div>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <h3>
                    Action Taken by HR</h3>
                <table border="0" cellpadding="2" cellspacing="0" width="40%">
                    <tr>
                        <td>
                            1. Letter issued on:
                        </td>
                        <td>
                            <div id="txtLetterIssuedOn" runat="server">
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            2. Salary/Grade Increment effected on:
                        </td>
                        <td>
                            <div id="txtSalaryIncrement" runat="server">
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
        </tr>
        <tr>
            <td>
                <table border="0" cellpadding="2" cellspacing="2" width="100%">
                    <tr>
                        <td style="text-align: left" width="300px">
                            <strong>Signature :</strong>
                        </td>
                        <td width="400px">
                            <strong>HR Manager :</strong>
                            <asp:Label ID="lblHrName" runat="server" CssClass="txtlbl"></asp:Label>
                        </td>
                        <td>
                            <strong>Date : </strong>
                            <asp:Label ID="lblHrDate" runat="server" CssClass="txtlbl"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
            </td>
        </tr>
    </table>
</asp:Content>
