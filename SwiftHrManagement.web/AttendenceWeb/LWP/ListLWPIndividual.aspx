<%@ Page Title="" Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="ListLWPIndividual.aspx.cs" Inherits="SwiftHrManagement.web.AttendenceWeb.LWP.ListLWPIndividual" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">

  

    <div class="panel">
        <header class="panel-heading">
            <i class="fa fa-caret-right"></i>
         LWP-Attendance
        </header>
        <div class="panel-body">
            <div class="row">
                <div class="col-md-12 col-sm-12">
                    <section class="panel">
                        <div class="panel-body">

                <div id="rpt" runat="server"></div>
        </div>
             </section>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
