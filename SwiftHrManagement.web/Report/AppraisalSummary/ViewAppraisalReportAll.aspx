<%@ Page Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="ViewAppraisalReportAll.aspx.cs" Inherits="SwiftHrManagement.web.Report.AppraisalSummary.ViewAppraisalReportAll" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
 <style type="text/css">
        .style10
        {
            color:#666666;           
        }
</style>
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
                                    <asp:Label ID="lblHeading" Text= "myHeading" runat="server"></asp:Label><br /></font>
                                <font size="-1">
                                 <asp:Label ID="lbldesc"  Text="test it " runat="server"></asp:Label>
                                </font>
                            </strong>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-12 col-sm-12" align="center">
                        <strong>Employee Appraisal Report on
                        From Date:<asp:Label ID="From_Date"  Text="" runat="server"></asp:Label>
                        To:<asp:Label ID="To_Date"  runat="server"></asp:Label></strong>
                    </div>
                </div>
                <div class="row">
                    &nbsp;
                </div>
                <div class="row">
                    <div class="col-md-12 col-sm-12">
                        <div id="rptDiv" runat="server"></div>         
                    </div>
                </div>
        </section>
        </div>
    </div>
 
</asp:Content>
