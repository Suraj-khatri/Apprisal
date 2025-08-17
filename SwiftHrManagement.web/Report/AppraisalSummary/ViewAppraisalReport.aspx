<%@ Page Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="ViewAppraisalReport.aspx.cs" Inherits="SwiftHrManagement.web.Report.AppraisalSummary.ViewAppraisalReport" Title="Swift HR Management System 1.0" %>
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
                                    <asp:Label ID="lblHeading" Text= "myHeading" runat="server"></asp:Label><br />
                                   </font>
                                   <font size="-1">
                                 <asp:Label ID="lbldesc"  Text="test it " runat="server"></asp:Label>
                                </font>
                            </strong>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-12 col-sm-12" align="center">
                        <asp:Panel ID="Report_History" runat="server">  
                            <strong>Employee Appraisal Report On
                            From Date:<asp:Label ID="From_Date"  Text="" runat="server"></asp:Label>&nbsp;
                            To:<asp:Label ID="To_Date"  runat="server"></asp:Label>
                           </strong>
                        </asp:Panel>
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
