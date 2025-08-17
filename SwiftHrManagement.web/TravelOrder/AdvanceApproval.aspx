<%@ Page Title="" Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="AdvanceApproval.aspx.cs" Inherits="SwiftHrManagement.web.TravelOrder.AdvanceApproval" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<link href="/Css/style.css" rel="Stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">

<table width="50%" border="0" cellspacing="0" cellpadding="0" style="padding-left:20px;">
    <tr>
        <td class="style4" colspan="2">
            <div align="center">
                <table width="600px" cellspacing="5" cellpadding="5">
                    <tr>
                        <td>
                            <div align="center" class="ReportHeader">NABIL BANK</div>
                            <div align="center" class="ReportSubHeader">Travel Request Authorization Form</div>
                        </td>
                    </tr>
                </table>
            </div>                              
        </td>
    </tr>    
    <tr>
        <td>
            <div style="text-align:center; margin-top:-2px;">
            </div>                             
        </td>
    </tr>
    <tr>
        <td>
            <div align="center">                           
                <table border="0">
                    <tr>
                        <td>
                            <div align="right" class="txtlbl">Date: <asp:Label ID="lblDate" runat="server"/></div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table width="100%" border="0" class="TBL2" cellpadding="10" cellspacing="10" align="center">
                                <tr>
                                    <td nowrap="nowrap"><div align="left" class="txtlbl"> Name of the Staff </div>
                                    </td>
                                    <td> 
                                        <asp:label runat="server" ID="lblEmpName"></asp:label>
                                    </td>
                                </tr>
                                <tr>
                                    <td><div align="left" class="txtlbl">Designation</div></td>
                                    <td>
                                        <asp:label runat="server" ID="lblDesignation"></asp:label>
                                    </td>
                                </tr>
                                <tr>
                                    <td><div align="left" class="txtlbl">Branch/Department</div></td>
                                    <td>
                                        <asp:label runat="server" ID="lblLocation"></asp:label>
                                    </td>
                                </tr>
                                <tr>
                                    <td><div align="left" class="txtlbl">Place of visit</div> </td>
                                    <td>
                                        <asp:label runat="server" ID="lblVisitArea"></asp:label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <div align="left" class="txtlbl">
                                        Purpose of Visit 
                                        </div>
                                    </td>
                                    <td>
                                        <asp:label runat="server" ID="lblVisitPurpose"></asp:label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <div align="left" class="txtlbl">
                                        Duration of Visit  
                                        </div>
                                    </td>
                                    <td>
                                        <asp:label runat="server" ID="lblVisitDuration"></asp:label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <div align="left" class="txtlbl">
                                        Mode of tavel
                                        </div>
                                    </td>
                                    <td>
                                        <asp:label runat="server" ID="lblModeofTravel"></asp:label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <div align="left" class="txtlbl">
                                        Date of Departure
                                        </div>
                                    </td>
                                    <td>
                                        <asp:label runat="server" ID="lblDepartureDate"></asp:label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <div align="left" class="txtlbl">
                                        Date of Arrival
                                        </div>
                                    </td>
                                    <td>
                                        <asp:label runat="server" ID="lblArrivalDate"></asp:label>
                                    </td>
                                </tr>
                                <tr>
                                    <td nowrap="nowrap">
                                        <div align="left" class="txtlbl">
                                        Requirement of Air Tickets
                                        </div>
                                    </td>
                                    <td>
                                        <asp:label runat="server" ID="lblAirTicket"></asp:label>
                                    </td>
                                </tr>
                                <tr>
                                    <td nowrap="nowrap">
                                        <div align="left" class="txtlbl">
                                        Cash Advance Against TA/DA
                                        </div>
                                    </td>
                                    <td>
                                        <asp:label runat="server" ID="lblCashAdvance"></asp:label><br /><br />
                                        <div runat="server" id="currency"></div>
                                    </td>
                                </tr>
                                <tr>
                                    <td nowrap="nowrap">
                                        <div align="left" class="txtlbl">
                                        Authorised By
                                        </div>
                                    </td>
                                    <td>
                                    <div runat="server" id="authorised"></div>
                                        <%--<asp:label runat="server" ID="lblAuthorisedBy"></asp:label>--%>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <br/>
                            <div align="left" class="txtlbl"> 
                            <asp:Label ID="lblNote" Text= "Note: System generated Request does not need physical signature." runat="server"></asp:Label>
                            </div>
                        </td>
                    </tr>
                </table>
            </div>
        </td>
    </tr>
</table>	
</asp:Content>
