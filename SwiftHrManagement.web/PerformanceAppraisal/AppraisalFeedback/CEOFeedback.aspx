<%@ Page Title="" Language="C#" MasterPageFile="~/ProjectMaster.Master" AutoEventWireup="true" CodeBehind="CEOFeedback.aspx.cs" Inherits="SwiftHrManagement.web.PerformanceAppraisal.AppraisalFeedback.CEOFeedback" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style1
        {
            height: 71px;
        }
    </style>
    <script type="text/javascript">
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
<table width="100%" height="100%" border="0" cellpadding="2" cellspacing="2">
        <tr>    
        <td colspan="3">
            <span class="txtlbl" >Please enter valid  data</span><br />
            <span class="required" >(* Required fields)</span><br />
            <asp:Label ID="lblmsg" runat="server" Text=""></asp:Label>
        </td>
    </tr>
   <tr>
       <td>
            <div id ="DivMsg" runat="server">
            </div>
       </td>
   </tr>
    <tr>
        <td colspan="2">
            <asp:Panel ID="Panel1" runat="server" GroupingText="Action(s) taken by HR Department" CssClass="" Visible="true">
                   <%-- <table cellpadding="5" cellspacing="5">
                        <tr>
                            <td valign = "top" class="style1">
                                <strong>CEO's Comment <br />
                                (if any)</strong>
                                    <span class="errormsg">*</span>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" 
                                runat="server" ControlToValidate="txtCEOComment" Display="Dynamic" 
                                ErrorMessage="Required!" ValidationGroup="ceo" 
                                SetFocusOnError="True"></asp:RequiredFieldValidator>
                            </td>
                            <td valign="top" class="style1" nowrap="nowrap">
                                <asp:TextBox ID="txtCEOComment" runat="server" CssClass="inputTextBoxLP"
                                Width = "600px" Height="60px" TextMode="MultiLine"></asp:TextBox>
                            
                            </td>
                        </tr>
                        <tr>
                        <td></td>
                            <td >
                                <asp:Button ID="BtnSave" runat="server" Text="Save" CssClass="button" Visible="false" 
                                onclick="BtnSave_Click" ValidationGroup="ceo" />
                            </td> 
                        </tr>
                    </table>--%>
                  <table border="0" cellpadding="2" cellspacing="2">
                    <tr>
                    <td>
                    Letter issued on:
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfv2" runat="server" 
                        ControlToValidate="letterIssuedOn" Display="dynamic" ErrorMessage="Required" 
                        ValidationGroup="ceo"></asp:RequiredFieldValidator><br />
                        <asp:TextBox ID="letterIssuedOn" runat="server" CssClass="inputTextBox"></asp:TextBox>
                        <cc1:CalendarExtender ID="txtFromDate_CalendarExtender" runat="server" 
                        Enabled="True" TargetControlID="letterIssuedOn">
                        </cc1:CalendarExtender>
                      
                  </td> 
                  </tr>
                  <tr>
                  <td>
                    Salary/Grade Increment effected on:
                  </td>
                        <td>
                           <asp:RequiredFieldValidator ID="frv" runat="server" 
                            ControlToValidate="incrementOn" Display="dynamic" ErrorMessage="Required" 
                            ValidationGroup="ceo"></asp:RequiredFieldValidator><br />
                            <asp:TextBox ID="incrementOn" runat="server" CssClass="inputTextBox"></asp:TextBox>
                            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" 
                            Enabled="True" TargetControlID="incrementOn">
                            </cc1:CalendarExtender>                      
                      </td>                      
                </tr>
                <tr>
                <td>&nbsp;</td>
                <td><asp:Button runat="server" ID="btnSave" Text="Save" CssClass="button" 
                        Visible="false" onclick="btnSave_Click" ValidationGroup="ceo" /></td>
                </tr>
                
                </table>
            </asp:Panel>
        </td>
    </tr>
</table>
</asp:Content>
