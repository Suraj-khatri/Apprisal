<%@ Page Title="" Language="C#" MasterPageFile="~/ProjectMaster.Master" AutoEventWireup="true"
    CodeBehind="HRFeedback.aspx.cs" Inherits="SwiftHrManagement.web.PerformanceAppraisal.AppraisalFeedback.HRFeedback" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script language="javascript">
        function ValidateForm() {
            try {
                var elements = document.getElementsByName("appraisal_fb");
                for (var i = 0; i < elements.length; i++) {
                    elements[i].value = ReplaceInvalidChar(elements[i].value);
                }
                return true;
            }
            catch (ex) {
                return false;
            }
        }
        function GetConfirm() {
            if (confirm('Are you sure to save?') == true) {
                GetFormData();
                return true;
            }
            return false;
        }

        function GetFormData() {
            try {
                var elements = document.getElementsByTagName("textarea");
                var value = "";
                for (var i = 0; i < elements.length; i++) {
                    value = value + elements[i].value + ',';
                }
                document.getElementById("ctl00_MainPlaceHolder_HiddenField1").value = value.substring(0, (value.length - 1));
                return true;
            }

            catch (ex) {
                return false;
            }
        }

        function ReplaceInvalidChar(value) {
            value = value.replace(/'/g, "`");
            value = value.replace(/,/g, " ");
            return value;
        }

        function PrintMessage(errorCode, errorMsg, url) {
            alert(errorMsg);
            if (errorCode == "0") {
                if (url != "") {
                    window.location.href = url;
                }
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    <table border="0" cellpadding="2" cellspacing="2" align="center" width="100%">
        <tr>
            <td>
                <div id="DivMsg" runat="server">

                </div>
             </td>
        </tr>
   <%--  <tr>--%>
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
                            <asp:RadioButtonList ID="rdReviewer" runat="server" RepeatDirection="Horizontal" Enabled="false"
                                Height="39px" Width="603px">
                                <asp:ListItem id="option6" runat="server" Value="Unsatisfactory" />
                                <asp:ListItem id="option7" runat="server" Value="Satisfactory" />
                                <asp:ListItem id="option8" runat="server" Value="Good" />
                                <asp:ListItem id="option9" runat="server" Value="Very Good" />
                                <asp:ListItem id="option10" runat="server" Value="Excellent" />
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
            <td>
                <strong>Review Committee Members Comment On Appraisal</strong>
            </td>
        </tr>
        <tr>
            <td>
                <div id="HRSection" runat="server">
               
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
                   </div>
            </td>
        </tr>
        
        <tr>
            <td align="center">
                <asp:HiddenField ID="hddQuesionId" runat="server" />
            </td>
        </tr>          
        <asp:HiddenField ID="HiddenField2" runat="server" />      
        <asp:HiddenField ID="HiddenField1" runat="server" />
    </table>
    <table border="0" cellpadding="2" cellspacing="2" align="center" width="100%">
        <tr>
            <td nowrap="nowrap">
                <div style="margin-top: 50px">
                    <asp:Label ID="Label2" runat="server" Text=" Overall Performance Rating by Review Committee" style="font-weight: bold !important;"></asp:Label><br />
                    <asp:RadioButtonList ID="radioChk" runat="server" RepeatDirection="Horizontal" Height="39px"
                        Width="603px" Enabled="false">
                        <asp:ListItem id="option1" runat="server" Value="Substandard" />
                        <asp:ListItem id="option2" runat="server" Value="Acceptable" />
                        <asp:ListItem id="option3" runat="server" Value="Good" />
                        <asp:ListItem id="option4" runat="server" Value="Very Good" />
                        <asp:ListItem id="option5" runat="server" Value="Excellent" />
                    </asp:RadioButtonList>
                </div>
            </td>
        </tr>
        <tr>
            <td>
                <div id="reviewSection" style="margin-top: 30px">
                    <asp:Label ID="Label1" runat="server" Text=" Overall Comment on Appraisal (to be filled by member of review committee)" style="font-weight: bold !important;"></asp:Label><br />
                    <br />
                    <asp:TextBox ID="txtReview" runat="server" CssClass="inputTextBoxLP1" TextMode="MultiLine"
                        Style="width: 550px !important; height: 115px !important;"></asp:TextBox>
                </div>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btnSave" runat="server" CssClass="button" Text="Save" Style="margin-top: 20px"
                    OnClick="btnSave_Click" OnClientClick="return GetConfirm();" Visible="true" />
                &nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnForward" runat="server" CssClass="button" Text="Save & Forward"
                    Style="margin-top: 20px" OnClick="btnForward_Click" OnClientClick="return GetConfirm();" />
            </td>
        </tr>
    </table>
</asp:Content>
