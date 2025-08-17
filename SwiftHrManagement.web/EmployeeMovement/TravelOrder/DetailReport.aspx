<%@ Page Title="" Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="DetailReport.aspx.cs" Inherits="SwiftHrManagement.web.EmployeeMovement.TravelOrder.DetailReport" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../Css/style.css" rel="stylesheet" type="text/css" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
<table width="60%" cellpadding="2" cellspacing="2" border="0" align="center">
    <tr>
        <td colspan="3">
            <div align="center"><strong><font size="+1">
                <asp:Label ID="lblHeading" runat="server"></asp:Label><br />
                </font></strong>
                <font size="-1"><strong>
                <asp:Label ID="lbldesc" runat="server"></asp:Label></strong></font>
            </div> 
        </td>
    </tr>
    <tr><td>&nbsp;</td></tr>
    <tr>
        <td align="left" width="350px"><div id="Branch" runat="server" class="txtlbl" align="left">Branch : &nbsp;
            <asp:Label ID="lblBranch" runat="server" CssClass="label"></asp:Label>
            </div>
        </td>
        <td width="40px"></td>
        <td align="right" width="210px">
            <div id="ReqDate" runat="server" class="txtlbl" align="left">Request Date :&nbsp;
            <asp:Label ID="lblReqDate" runat="server" CssClass="label"></asp:Label>
            </div>
        </td>
    </tr>
    <tr>
        <td align="left" width="350px"><div id="Dept" runat="server" class="txtlbl" align="left">Department : &nbsp;
            <asp:Label ID="lblDept" runat="server" CssClass="label"></asp:Label>
            </div>
        </td>
        <td width="40px"></td>
        <td align="right" width="210px">
            <div id="From" runat="server" class="txtlbl" align="left">From Date:&nbsp;
            <asp:Label ID="lblfrom" runat="server" CssClass="label"></asp:Label>
            </div>
        </td>
    </tr>
    <tr>
        <td align="left" width="350px"><div id="Employee" runat="server" class="txtlbl" align="left">Employee : &nbsp;
            <asp:Label ID="lblEmp" runat="server" CssClass="label"></asp:Label>
            </div>
        </td>
        <td width="40px"></td>
        <td align="right" width="210px">
            <div id="To" runat="server" class="txtlbl" align="left">To Date :&nbsp;
            <asp:Label ID="lblTo" runat="server" CssClass="label"></asp:Label>
            </div>
        </td>
    </tr>
    <tr>
        <td align="left" width="350px"><div id="Place" runat="server" class="txtlbl" align="left">Place Of Visit : &nbsp;
            <asp:Label ID="lblPlace" runat="server" CssClass="label"></asp:Label>
            </div>
        </td>
        <td width="40px"></td>
        <td align="right" width="210px">
            <div id="Transport" runat="server" class="txtlbl" align="left">Transport :&nbsp;
            <asp:Label ID="lblTransport" runat="server" CssClass="label"></asp:Label>
            </div>
        </td>
    </tr>
    <tr>
        <td align="left" width="350px">
            <div id="Purpose" runat="server" class="txtlbl" align="left">Purpose : &nbsp;
            <asp:Label ID="lblPurpose" runat="server" CssClass="label"></asp:Label>
            </div>
        </td>
        <td width="40px"></td>
        <td align="right" width="210px">
            <%--<div id="Advance" runat="server" class="txtlbl" align="left">Advance :&nbsp;
            <asp:Label ID="lblAdvance" runat="server" CssClass="label"></asp:Label>
            </div>--%>
        </td>
    </tr>
    <tr><td>&nbsp;</td></tr>
    <tr>
        <td colspan="3">
            <div id="rptAllowance" runat="server"></div>
        </td>
    </tr>
    <tr><td>&nbsp;</td></tr>
    <tr>
        <td colspan="3">
            <div id="RecommendedBy" runat="server">
                <table border="0" cellpadding="2" cellspacing="2" width="100%">
                    <tr>
                        <td  width="310px">
                            <div id="Recommend" runat="server" class="txtlbl" align="left">Recommended By :
                            <asp:Label ID="lblRecommend" runat="server" CssClass="label"></asp:Label>
                            </div>
                        </td>   
                        <td width="170px">
                            <div id="RDate" runat="server" class="txtlbl" align="left">Date :
                            <asp:Label ID="lblRDate" runat="server" CssClass="label"></asp:Label>
                            </div>
                        </td>
                        <td>
                            <div id="RRemarks" runat="server" class="txtlbl" align="left">Remarks :
                            <asp:Label ID="lblRRemarks" runat="server" CssClass="label"></asp:Label>
                            </div>
                        </td>
                    </tr>
                </table>
            </div>
        </td>
    </tr>
    <tr>
        <td colspan="3">
            <div id="VerifyBy" runat="server">
                <table border="0" cellpadding="2" cellspacing="2" width="100%">
                    <tr>
                        <td  width="310px">
                            <div id="Verify" runat="server" class="txtlbl" align="left">Verified By :
                            <asp:Label ID="lblVerify" runat="server" CssClass="label"></asp:Label>   
                            </div>
                        </td>
                        <td width="170px">
                            <div id="VDate" runat="server" class="txtlbl" align="left">Date :
                            <asp:Label ID="lblVDate" runat="server" CssClass="label"></asp:Label>
                            </div>
                        </td>
                        <td>
                            <div id="VRemarks" runat="server" class="txtlbl" align="left">Remarks :
                            <asp:Label ID="lblVRemarks" runat="server" CssClass="label"></asp:Label>
                            </div>
                        </td>
                    </tr>
                </table>
            </div>
        </td>
    </tr>
    <tr>
        <td colspan="3">
            <div id="ApproveBY" runat="server">
                <table border="0" cellpadding="2" cellspacing="2" width="100%">
                    <tr>
                        <td  width="310px">
                            <div id="Approve" runat="server" class="txtlbl" align="left">Approved By :
                            <asp:Label ID="lblApprove" runat="server" CssClass="label"></asp:Label>
                            </div>
                        </td>
                        <td width="170px">
                            <div id="ADate" runat="server" class="txtlbl" align="left">Date :
                            <asp:Label ID="lblADate" runat="server" CssClass="label"></asp:Label>
                            </div>
                        </td>
                        <td>
                            <div id="ARemarks" runat="server" class="txtlbl" align="left">Remarks :
                            <asp:Label ID="lblARemarks" runat="server" CssClass="label"></asp:Label>
                            </div>
                        </td>
                    </tr>
                </table>
            </div>
        </td>
    </tr>
</table>
</asp:Content>
