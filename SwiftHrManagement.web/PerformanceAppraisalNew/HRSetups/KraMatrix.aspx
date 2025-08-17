<%@ Page Title="" Language="C#" MasterPageFile="~/Apprisal.Master" AutoEventWireup="true" CodeBehind="KraMatrix.aspx.cs" Inherits="SwiftHrManagement.web.PerformanceAppraisalNew.HRSetups.KraMatrix" %>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainPlaceHolder" runat="server">

    <div class="row">

        <section class="panel">
            <header class="panel-heading">
                Appraisal Matrix KRA List
            </header>
            <div class="panel-body">
                <div id="rptDiv" runat="server">
                </div>

            </div>
        </section>

    </div>



</asp:Content>
