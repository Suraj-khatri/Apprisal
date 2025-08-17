<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/SwiftHRManager.Master" CodeBehind="DateWiseRpt.aspx.cs" Inherits="SwiftHrManagement.web.Report.TrainingRpt.DateWiseRpt" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
<div class="panel">
        <div class="panel-body">
            <div class="row">
                <div class="col-md-12">
                    <section class="panel">
                        <div class="panel-body">
                            <div class="form-group" align="center">
                                <strong><font size="+1">
                                    <asp:Label ID="RptHead" runat="server"></asp:Label><br />
                                       </font></strong>
                                       <font size="-1"><strong>
                                     <asp:Label ID="RptSubHead"  runat="server"></asp:Label></strong></font>
                                
                                <center><b>
                                    <asp:Label ID="RptDesc"  runat="server"></asp:Label><br />
                                        From Date:<asp:Label ID="lblFromDate" runat="server" CssClass="txtlbl"></asp:Label>
                                        To Date: <asp:Label ID="lblToDate" runat="server" CssClass="txtlbl"></asp:Label>
                                    <br /></b></center>
                            </div>
                            <div id="rptDiv" runat="server"></div>
                        </div>
                    </section>
                </div>
            </div>
            <asp:HiddenField ID="Hdnflag" runat="server" />
        </div>
    </div>
</asp:Content>
