<%@ Page Title="" Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="EmpTaxDetail.aspx.cs" Inherits="SwiftHrManagement.web.Report.PayRollReport.EmpTaxDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    
    <asp:UpdatePanel ID="up" runat="server">
        <ContentTemplate>
            <div class="row">
                <div class="col-md-12">
                    <section class="panel">
                        <div class="panel-body">
                            <div class="text-center"><font  size="+1"><strong><asp:Label ID="Lblcompany" Text= "Company" runat="server" ></asp:Label></strong></font><br />
                                   <font > <asp:Label ID="LblDesc"  Text="Description" runat="server" ></asp:Label><br />                                                        
                                    <asp:Label ID="Lblmonth"  Text="" runat="server" ></asp:Label><br />
                                    <asp:Label ID="lblEmpName" runat="server"></asp:Label><br /> </font>
                            </div>
                            <br/>
                             <div id="rptDiv" runat="server" class="table-responsive "></div>    
                        </div>
                    </section>
                </div>
            </div>
        </ContentTemplate>
</asp:UpdatePanel>


</asp:Content>
