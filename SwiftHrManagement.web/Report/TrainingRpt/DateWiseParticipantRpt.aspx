<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/SwiftHRManager.Master" CodeBehind="DateWiseParticipantRpt.aspx.cs" Inherits="SwiftHrManagement.web.Report.TrainingRpt.DateWiseParticipantRpt" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">

                            <table border="0" cellspacing="3"  cellpadding="0" style="margin-top:20px;" align="center">
                            <tr>
                                  <td>
                                    <div align="center">
                                        <strong><font size="+1">
                                        <asp:Label ID="RptHead" runat="server"></asp:Label><br />
                                       </font></strong>
                                       <font size="-1"><strong>
                                     <asp:Label ID="RptSubHead"  runat="server"></asp:Label></strong></font></div>
                                 </td>
                            </tr>
                            <tr>
                                <td>
                                  <div style="text-align:center; margin-top:-5px;">
                                    <font size="-1"><strong>
                                                    <asp:Label ID="RptDesc"  runat="server"></asp:Label><br />
                                                    From Date:<asp:Label ID="lblFromDate" runat="server" CssClass="txtlbl"></asp:Label>
                                                    To Date: <asp:Label ID="lblToDate" runat="server" CssClass="txtlbl"></asp:Label>
                                                      <br />
                                                      </strong>
                                    </font>
                                    </div>
                                </td>
                            </tr>    
                            <tr>
                                <td>
                                    <div id="rptDiv" runat="server">
                                    </div>
                                </td>
                            </tr>
                          </table>
</asp:Content>
