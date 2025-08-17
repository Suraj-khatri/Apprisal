<%@ Page Title="" Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="ListLWP.aspx.cs" Inherits="SwiftHrManagement.web.AttendenceWeb.LWP.ListLWP" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
     <div class="row">
        <div class="col-md-10 col-md-offset-1">
            <section class="panel">
                <div class="panel-body">
                    <div class="form-group" align="center">
                        <asp:Label ID="Lblcompany" Text= "Company" runat="server" CssClass="ReportHeader"></asp:Label><br />
                        <asp:Label ID="LblDesc"  Text="Description" runat="server" CssClass="ReportSubHeader"></asp:Label><br /> 
                        Absent Details From                                                
                        <asp:Label ID="lblFromDate"  runat="server" CssClass="ReportSubHeader"></asp:Label> To
                        <asp:Label ID="lblToDate" runat="server" CssClass="ReportSubHeader"></asp:Label><br /> 
                    </div>
                    <div class="form-group">
                        <label>Employee Absent History</label>
                    </div>
                    <div class="form-group">
                        <div id="rptDivAbsent" runat="server"></div>
                    </div>
                </div>
            </section>
        </div>
    </div>
</asp:Content>
