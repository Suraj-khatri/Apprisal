<%@ Page Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="SwiftHrManagement.web.Report.PayRollReport.empDetails.List" Title="" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    <asp:UpdatePanel ID="up" runat="server">
        <ContentTemplate>
            <div class="row">
                <div class="col-md-6 col-md-offset-3">
                    <section class="panel">
                        <div class="panel-body">
                            <div class="text-center"><strong><div id="divCompany" class="ReportHeader" runat="server"></div></strong>
                               <div id="Div1"> Employee Information Details<br />
                                   Branch Name: <asp:Label ID="lblBranchName" runat="server" ></asp:Label><br />
                                    Department Name: <asp:Label ID="lblDeptName" runat="server" ></asp:Label></div>  
                                     
                                    <div style="text-align: right">
                                    Report Date : <asp:Label ID="lblprintDate" runat="server"  ></asp:Label>
                                </div>
                            </div>
                               
                            <div id="rpt" runat="server"></div> 
                        </div>
                    </section>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <%--<table align="center">
        <tr>
            <td colspan="2" style="text-align: center"><div id="divCompany" class="ReportHeader" runat="server"></div>
                <div id="Div1" class="ReportSubHeader">Employee Information Details<br />
                    Branch Name: <asp:Label ID="lblBranchName" runat="server" CssClass="txtlbl"></asp:Label><br />
                    Department Name: <asp:Label ID="lblDeptName" runat="server" CssClass="txtlbl"></asp:Label></div>  
                                     
                    <div style="text-align: right" class="ReportSubHeader">
                    Report Date : <asp:Label ID="lblprintDate" runat="server" Text="Label"  CssClass="txtlbl"></asp:Label>
                </div>                    
                </td>
        </tr>
        <tr>
            <td colspan="2"><div id="rpt" runat="server"></div></td>
        </tr>
</table>--%>
</asp:Content>
