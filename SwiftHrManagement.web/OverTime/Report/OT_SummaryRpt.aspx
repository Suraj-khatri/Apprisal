<%@ Page Title="" Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="OT_SummaryRpt.aspx.cs" Inherits="SwiftHrManagement.web.OverTime.Report.OT_SummaryRpt" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
<div class="panel">
    <div class="panel-body">
        <div class="row">
            <div class="col-md-12 col-sm-12">
                <section class="panel">
                    <div class="panel-body">
                        <div class="form-group" align="center">
                            <strong><font size="+1">
                                <asp:Label ID="lblCompany" runat="server"></asp:Label><br />
                            </font></strong>
                            <font size="-1"><strong>
                                <asp:Label ID="lbldesc"  Text="Date Wise OT Summary Rpt" runat="server"></asp:Label></strong><br />
                            </font>
                            <font size="-1">
                                Report From:<asp:Label id="lblFromDate" runat="server"></asp:Label> To: <asp:Label id="lblToDate" runat="server"></asp:Label>
                            </font>
                            <div align="right">
                                Report Date:<asp:Label ID="lblprintDate" runat="server" Text="Label"  CssClass="txtlbl"></asp:Label>
                            </div>
                        </div>
                        <div class="form-group">
                            <strong>OT ADJUSTED IN SYSTEM PAYROLL</strong>
                        </div>
                        <div class="form-group">
                            <div id="rpt1" runat="server"></div>
                        </div>
                        <div class="form-group">
                            <strong>OT APPROVED BY SUPERVISOR BUT STILL PENDING IN HR</strong>
                        </div>
                        <div class="form-group">
                            <div id="rpt2" runat="server"></div>
                        </div>
                        <div class="form-group">
                            <strong>OT APPROVED BY HR BUT STILL PENDING IN AHOC PAYMENT</strong>
                        </div>
                        <div class="form-group">
                            <div id="rpt3" runat="server"></div>
                        </div>
                    </div>
                </section>
            </div>
        </div>
    </div>
</div>
</asp:Content>
