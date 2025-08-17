<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/SwiftHRManager.Master" CodeBehind="RecommendedTrainingRpt.aspx.cs" Inherits="SwiftHrManagement.web.PerformanceAppraisal.RecommendedTrainingRpt" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
<div class="panel">
        <div class="panel-body">
            <section class="panel">
                <div class="row">
                    <div class="col-md-12 col-sm-12">
                        <div align="center">
                            <strong>
                                <font size="+1">
                                    <asp:Label ID="RptHead" runat="server"></asp:Label><br />
                                       </font>
                                       <font size="-1">
                                     <asp:Label ID="RptSubHead"  runat="server"></asp:Label></font>
                            </strong>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-12 col-sm-12" align="center">
                        <asp:Label ID="RptDesc"  runat="server"></asp:Label><br />
                        From Date:<asp:Label ID="lblFromDate" runat="server" CssClass="txtlbl"></asp:Label>
                        To Date: <asp:Label ID="lblToDate" runat="server" CssClass="txtlbl"></asp:Label>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-12 col-sm-12">
                        <div id="rptDiv" runat="server">
                        </div>
                    </div>
                </div>
        </section>
        </div>
    </div>
</asp:Content>
