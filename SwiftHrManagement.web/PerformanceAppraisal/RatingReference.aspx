<%@ Page Title="" Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="RatingReference.aspx.cs" Inherits="SwiftHrManagement.web.PerformanceAppraisal.RatingReference" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">

<table width="100%">
                        <tr>
                            <td align="left" class="wellcome" valign="bottom">
                                <img src="../Images/big_bullit.gif" />&nbsp;&nbsp;Performance Appraisal Rating Reference
                            </td>
                        </tr>
                        <tr>
                            <td></td>
                        </tr>
                        <tr>
                        <table cellspacing="0" cellpadding="0" border="3" class="TBL2">

                              <tr align="center">
                                <th>Parameters</th>
                                <th>Legends</th>
                                <th>Achievement Range</th>
                                <th>Marks Range</th>
                                <th>Description</th>
                              </tr>
                              <tr>
                                <td>Excellent (E)</td>
                                <td align="center">E</td>
                                <td>Above 110%</td>
                                <td>&gt;80</td>
                                <td>Consistently far exceeds the requirement of the job. Exceptionally high level of performance consistently displayed.</td>
                              </tr>
                              <tr>
                                <td>Very Good (VG)</td>
                                <td align="center">VG</td>
                                <td>Above 100% and upto    110%</td>
                                <td>80 &ge; VG &gt; 60</td>
                                <td>Exceeds the requirements of the job at most of the times. Very high level of performance consistently displayed.</td>
                              </tr>
                              <tr>
                                <td>Good (G)</td>
                                <td align="center">G</td>
                                <td>Above 70% and upto    100%</td>
                                <td>60&ge; G &gt; 40</td>
                                <td>Meets, on average, the requirements of the job but frequently exceeds the requirements. Good level of achievement / performance consistently displayed.</td>
                              </tr>
                              <tr>
                                <td>Satisfactory    (S)</td>
                                <td align="center">S</td>
                                <td>Above 50% and upto    70%</td>
                                <td>40 &ge; S &gt; 20</td>
                                <td>Meets the requirements of the job but there is room for improvement. Continuous average level of performance and occassional above average performance displayed.</td>
                              </tr>
                              <tr>
                                <td>Unsatisfactory (US)</td>
                                <td align="center">US</td>
                                <td>Upto 50%</td>
                                <td>20 &ge; US &gt;10</td>
                                <td>Fails to meet the requirements of the job. Below minimum performance standard.</td>
                              </tr>
                            </table>
                       </tr>
             </table>
</asp:Content>
